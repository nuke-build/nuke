// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Chocolatey/Chocolatey.json

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

namespace Nuke.Common.Tools.Chocolatey
{
    /// <summary>
    ///   <p>Chocolatey has the largest online registry of Windows packages. Chocolatey packages encapsulate everything required to manage a particular piece of software into one deployment artifact by wrapping installers, executables, zips, and/or scripts into a compiled package file.</p>
    ///   <p>For more details, visit the <a href="https://chocolatey.org/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [PathToolRequirement(ChocolateyPathExecutable)]
    public partial class ChocolateyTasks
        : IRequirePathTool
    {
        public const string ChocolateyPathExecutable = "choco";
        /// <summary>
        ///   Path to the Chocolatey executable.
        /// </summary>
        public static string ChocolateyPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("CHOCOLATEY_EXE") ??
            ToolPathResolver.GetPathExecutable("choco");
        public static Action<OutputType, string> ChocolateyLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Chocolatey has the largest online registry of Windows packages. Chocolatey packages encapsulate everything required to manage a particular piece of software into one deployment artifact by wrapping installers, executables, zips, and/or scripts into a compiled package file.</p>
        ///   <p>For more details, visit the <a href="https://chocolatey.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Chocolatey(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(ChocolateyPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? ChocolateyLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Searches remote or local packages (alias for <c>list</c>).</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/search">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;filter&gt;</c> via <see cref="ChocolateySearchSettings.Filter"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateySearchSettings.AcceptLicense"/></li>
        ///     <li><c>--all-versions</c> via <see cref="ChocolateySearchSettings.AllVersions"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateySearchSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--approved-only</c> via <see cref="ChocolateySearchSettings.ApprovedOnly"/></li>
        ///     <li><c>--by-id-only</c> via <see cref="ChocolateySearchSettings.ByIdOnly"/></li>
        ///     <li><c>--by-tag-only</c> via <see cref="ChocolateySearchSettings.ByTagOnly"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateySearchSettings.CacheLocation"/></li>
        ///     <li><c>--cert</c> via <see cref="ChocolateySearchSettings.ClientCertificate"/></li>
        ///     <li><c>--certpassword</c> via <see cref="ChocolateySearchSettings.CertificatePassword"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateySearchSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateySearchSettings.Debug"/></li>
        ///     <li><c>--detailed</c> via <see cref="ChocolateySearchSettings.Detailed"/></li>
        ///     <li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/></li>
        ///     <li><c>--download-cache-only</c> via <see cref="ChocolateySearchSettings.DownloadCacheAvailable"/></li>
        ///     <li><c>--exact</c> via <see cref="ChocolateySearchSettings.Exact"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateySearchSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateySearchSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateySearchSettings.Force"/></li>
        ///     <li><c>--id-only</c> via <see cref="ChocolateySearchSettings.IdOnly"/></li>
        ///     <li><c>--id-starts-with</c> via <see cref="ChocolateySearchSettings.IdStartsWith"/></li>
        ///     <li><c>--include-programs</c> via <see cref="ChocolateySearchSettings.IncludePrograms"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateySearchSettings.LimitOutput"/></li>
        ///     <li><c>--local-only</c> via <see cref="ChocolateySearchSettings.LocalOnly"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateySearchSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateySearchSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateySearchSettings.DoNotShowProgress"/></li>
        ///     <li><c>--not-broken</c> via <see cref="ChocolateySearchSettings.NotBroken"/></li>
        ///     <li><c>--order-by-popularity</c> via <see cref="ChocolateySearchSettings.OrderByPopularity"/></li>
        ///     <li><c>--page</c> via <see cref="ChocolateySearchSettings.Page"/></li>
        ///     <li><c>--page-size</c> via <see cref="ChocolateySearchSettings.PageSize"/></li>
        ///     <li><c>--password</c> via <see cref="ChocolateySearchSettings.Password"/></li>
        ///     <li><c>--prerelease</c> via <see cref="ChocolateySearchSettings.Prerelease"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateySearchSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateySearchSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateySearchSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateySearchSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateySearchSettings.ProxyUserName"/></li>
        ///     <li><c>--show-audit-info</c> via <see cref="ChocolateySearchSettings.ShowAuditInformation"/></li>
        ///     <li><c>--source</c> via <see cref="ChocolateySearchSettings.Source"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateySearchSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateySearchSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--user</c> via <see cref="ChocolateySearchSettings.User"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateySearchSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="ChocolateySearchSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ChocolateySearch(ChocolateySearchSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new ChocolateySearchSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Searches remote or local packages (alias for <c>list</c>).</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/search">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;filter&gt;</c> via <see cref="ChocolateySearchSettings.Filter"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateySearchSettings.AcceptLicense"/></li>
        ///     <li><c>--all-versions</c> via <see cref="ChocolateySearchSettings.AllVersions"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateySearchSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--approved-only</c> via <see cref="ChocolateySearchSettings.ApprovedOnly"/></li>
        ///     <li><c>--by-id-only</c> via <see cref="ChocolateySearchSettings.ByIdOnly"/></li>
        ///     <li><c>--by-tag-only</c> via <see cref="ChocolateySearchSettings.ByTagOnly"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateySearchSettings.CacheLocation"/></li>
        ///     <li><c>--cert</c> via <see cref="ChocolateySearchSettings.ClientCertificate"/></li>
        ///     <li><c>--certpassword</c> via <see cref="ChocolateySearchSettings.CertificatePassword"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateySearchSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateySearchSettings.Debug"/></li>
        ///     <li><c>--detailed</c> via <see cref="ChocolateySearchSettings.Detailed"/></li>
        ///     <li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/></li>
        ///     <li><c>--download-cache-only</c> via <see cref="ChocolateySearchSettings.DownloadCacheAvailable"/></li>
        ///     <li><c>--exact</c> via <see cref="ChocolateySearchSettings.Exact"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateySearchSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateySearchSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateySearchSettings.Force"/></li>
        ///     <li><c>--id-only</c> via <see cref="ChocolateySearchSettings.IdOnly"/></li>
        ///     <li><c>--id-starts-with</c> via <see cref="ChocolateySearchSettings.IdStartsWith"/></li>
        ///     <li><c>--include-programs</c> via <see cref="ChocolateySearchSettings.IncludePrograms"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateySearchSettings.LimitOutput"/></li>
        ///     <li><c>--local-only</c> via <see cref="ChocolateySearchSettings.LocalOnly"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateySearchSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateySearchSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateySearchSettings.DoNotShowProgress"/></li>
        ///     <li><c>--not-broken</c> via <see cref="ChocolateySearchSettings.NotBroken"/></li>
        ///     <li><c>--order-by-popularity</c> via <see cref="ChocolateySearchSettings.OrderByPopularity"/></li>
        ///     <li><c>--page</c> via <see cref="ChocolateySearchSettings.Page"/></li>
        ///     <li><c>--page-size</c> via <see cref="ChocolateySearchSettings.PageSize"/></li>
        ///     <li><c>--password</c> via <see cref="ChocolateySearchSettings.Password"/></li>
        ///     <li><c>--prerelease</c> via <see cref="ChocolateySearchSettings.Prerelease"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateySearchSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateySearchSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateySearchSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateySearchSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateySearchSettings.ProxyUserName"/></li>
        ///     <li><c>--show-audit-info</c> via <see cref="ChocolateySearchSettings.ShowAuditInformation"/></li>
        ///     <li><c>--source</c> via <see cref="ChocolateySearchSettings.Source"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateySearchSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateySearchSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--user</c> via <see cref="ChocolateySearchSettings.User"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateySearchSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="ChocolateySearchSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ChocolateySearch(Configure<ChocolateySearchSettings> configurator)
        {
            return ChocolateySearch(configurator(new ChocolateySearchSettings()));
        }
        /// <summary>
        ///   <p>Searches remote or local packages (alias for <c>list</c>).</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/search">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;filter&gt;</c> via <see cref="ChocolateySearchSettings.Filter"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateySearchSettings.AcceptLicense"/></li>
        ///     <li><c>--all-versions</c> via <see cref="ChocolateySearchSettings.AllVersions"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateySearchSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--approved-only</c> via <see cref="ChocolateySearchSettings.ApprovedOnly"/></li>
        ///     <li><c>--by-id-only</c> via <see cref="ChocolateySearchSettings.ByIdOnly"/></li>
        ///     <li><c>--by-tag-only</c> via <see cref="ChocolateySearchSettings.ByTagOnly"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateySearchSettings.CacheLocation"/></li>
        ///     <li><c>--cert</c> via <see cref="ChocolateySearchSettings.ClientCertificate"/></li>
        ///     <li><c>--certpassword</c> via <see cref="ChocolateySearchSettings.CertificatePassword"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateySearchSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateySearchSettings.Debug"/></li>
        ///     <li><c>--detailed</c> via <see cref="ChocolateySearchSettings.Detailed"/></li>
        ///     <li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/></li>
        ///     <li><c>--download-cache-only</c> via <see cref="ChocolateySearchSettings.DownloadCacheAvailable"/></li>
        ///     <li><c>--exact</c> via <see cref="ChocolateySearchSettings.Exact"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateySearchSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateySearchSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateySearchSettings.Force"/></li>
        ///     <li><c>--id-only</c> via <see cref="ChocolateySearchSettings.IdOnly"/></li>
        ///     <li><c>--id-starts-with</c> via <see cref="ChocolateySearchSettings.IdStartsWith"/></li>
        ///     <li><c>--include-programs</c> via <see cref="ChocolateySearchSettings.IncludePrograms"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateySearchSettings.LimitOutput"/></li>
        ///     <li><c>--local-only</c> via <see cref="ChocolateySearchSettings.LocalOnly"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateySearchSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateySearchSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateySearchSettings.DoNotShowProgress"/></li>
        ///     <li><c>--not-broken</c> via <see cref="ChocolateySearchSettings.NotBroken"/></li>
        ///     <li><c>--order-by-popularity</c> via <see cref="ChocolateySearchSettings.OrderByPopularity"/></li>
        ///     <li><c>--page</c> via <see cref="ChocolateySearchSettings.Page"/></li>
        ///     <li><c>--page-size</c> via <see cref="ChocolateySearchSettings.PageSize"/></li>
        ///     <li><c>--password</c> via <see cref="ChocolateySearchSettings.Password"/></li>
        ///     <li><c>--prerelease</c> via <see cref="ChocolateySearchSettings.Prerelease"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateySearchSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateySearchSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateySearchSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateySearchSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateySearchSettings.ProxyUserName"/></li>
        ///     <li><c>--show-audit-info</c> via <see cref="ChocolateySearchSettings.ShowAuditInformation"/></li>
        ///     <li><c>--source</c> via <see cref="ChocolateySearchSettings.Source"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateySearchSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateySearchSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--user</c> via <see cref="ChocolateySearchSettings.User"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateySearchSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="ChocolateySearchSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(ChocolateySearchSettings Settings, IReadOnlyCollection<Output> Output)> ChocolateySearch(CombinatorialConfigure<ChocolateySearchSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(ChocolateySearch, ChocolateyLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Lists remote or local packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/list">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;filter&gt;</c> via <see cref="ChocolateyListSettings.Filter"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyListSettings.AcceptLicense"/></li>
        ///     <li><c>--all-versions</c> via <see cref="ChocolateyListSettings.AllVersions"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyListSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--approved-only</c> via <see cref="ChocolateyListSettings.ApprovedOnly"/></li>
        ///     <li><c>--by-id-only</c> via <see cref="ChocolateyListSettings.ByIdOnly"/></li>
        ///     <li><c>--by-tag-only</c> via <see cref="ChocolateyListSettings.ByTagOnly"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyListSettings.CacheLocation"/></li>
        ///     <li><c>--cert</c> via <see cref="ChocolateyListSettings.ClientCertificate"/></li>
        ///     <li><c>--certpassword</c> via <see cref="ChocolateyListSettings.CertificatePassword"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyListSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyListSettings.Debug"/></li>
        ///     <li><c>--detailed</c> via <see cref="ChocolateyListSettings.Detailed"/></li>
        ///     <li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/></li>
        ///     <li><c>--download-cache-only</c> via <see cref="ChocolateyListSettings.DownloadCacheAvailable"/></li>
        ///     <li><c>--exact</c> via <see cref="ChocolateyListSettings.Exact"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyListSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyListSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyListSettings.Force"/></li>
        ///     <li><c>--id-only</c> via <see cref="ChocolateyListSettings.IdOnly"/></li>
        ///     <li><c>--id-starts-with</c> via <see cref="ChocolateyListSettings.IdStartsWith"/></li>
        ///     <li><c>--include-programs</c> via <see cref="ChocolateyListSettings.IncludePrograms"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyListSettings.LimitOutput"/></li>
        ///     <li><c>--local-only</c> via <see cref="ChocolateyListSettings.LocalOnly"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyListSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyListSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyListSettings.DoNotShowProgress"/></li>
        ///     <li><c>--not-broken</c> via <see cref="ChocolateyListSettings.NotBroken"/></li>
        ///     <li><c>--order-by-popularity</c> via <see cref="ChocolateyListSettings.OrderByPopularity"/></li>
        ///     <li><c>--page</c> via <see cref="ChocolateyListSettings.Page"/></li>
        ///     <li><c>--page-size</c> via <see cref="ChocolateyListSettings.PageSize"/></li>
        ///     <li><c>--password</c> via <see cref="ChocolateyListSettings.Password"/></li>
        ///     <li><c>--prerelease</c> via <see cref="ChocolateyListSettings.Prerelease"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyListSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyListSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyListSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyListSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyListSettings.ProxyUserName"/></li>
        ///     <li><c>--show-audit-info</c> via <see cref="ChocolateyListSettings.ShowAuditInformation"/></li>
        ///     <li><c>--source</c> via <see cref="ChocolateyListSettings.Source"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyListSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyListSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--user</c> via <see cref="ChocolateyListSettings.User"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyListSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="ChocolateyListSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ChocolateyList(ChocolateyListSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new ChocolateyListSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Lists remote or local packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/list">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;filter&gt;</c> via <see cref="ChocolateyListSettings.Filter"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyListSettings.AcceptLicense"/></li>
        ///     <li><c>--all-versions</c> via <see cref="ChocolateyListSettings.AllVersions"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyListSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--approved-only</c> via <see cref="ChocolateyListSettings.ApprovedOnly"/></li>
        ///     <li><c>--by-id-only</c> via <see cref="ChocolateyListSettings.ByIdOnly"/></li>
        ///     <li><c>--by-tag-only</c> via <see cref="ChocolateyListSettings.ByTagOnly"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyListSettings.CacheLocation"/></li>
        ///     <li><c>--cert</c> via <see cref="ChocolateyListSettings.ClientCertificate"/></li>
        ///     <li><c>--certpassword</c> via <see cref="ChocolateyListSettings.CertificatePassword"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyListSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyListSettings.Debug"/></li>
        ///     <li><c>--detailed</c> via <see cref="ChocolateyListSettings.Detailed"/></li>
        ///     <li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/></li>
        ///     <li><c>--download-cache-only</c> via <see cref="ChocolateyListSettings.DownloadCacheAvailable"/></li>
        ///     <li><c>--exact</c> via <see cref="ChocolateyListSettings.Exact"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyListSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyListSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyListSettings.Force"/></li>
        ///     <li><c>--id-only</c> via <see cref="ChocolateyListSettings.IdOnly"/></li>
        ///     <li><c>--id-starts-with</c> via <see cref="ChocolateyListSettings.IdStartsWith"/></li>
        ///     <li><c>--include-programs</c> via <see cref="ChocolateyListSettings.IncludePrograms"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyListSettings.LimitOutput"/></li>
        ///     <li><c>--local-only</c> via <see cref="ChocolateyListSettings.LocalOnly"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyListSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyListSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyListSettings.DoNotShowProgress"/></li>
        ///     <li><c>--not-broken</c> via <see cref="ChocolateyListSettings.NotBroken"/></li>
        ///     <li><c>--order-by-popularity</c> via <see cref="ChocolateyListSettings.OrderByPopularity"/></li>
        ///     <li><c>--page</c> via <see cref="ChocolateyListSettings.Page"/></li>
        ///     <li><c>--page-size</c> via <see cref="ChocolateyListSettings.PageSize"/></li>
        ///     <li><c>--password</c> via <see cref="ChocolateyListSettings.Password"/></li>
        ///     <li><c>--prerelease</c> via <see cref="ChocolateyListSettings.Prerelease"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyListSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyListSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyListSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyListSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyListSettings.ProxyUserName"/></li>
        ///     <li><c>--show-audit-info</c> via <see cref="ChocolateyListSettings.ShowAuditInformation"/></li>
        ///     <li><c>--source</c> via <see cref="ChocolateyListSettings.Source"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyListSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyListSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--user</c> via <see cref="ChocolateyListSettings.User"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyListSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="ChocolateyListSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ChocolateyList(Configure<ChocolateyListSettings> configurator)
        {
            return ChocolateyList(configurator(new ChocolateyListSettings()));
        }
        /// <summary>
        ///   <p>Lists remote or local packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/list">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;filter&gt;</c> via <see cref="ChocolateyListSettings.Filter"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyListSettings.AcceptLicense"/></li>
        ///     <li><c>--all-versions</c> via <see cref="ChocolateyListSettings.AllVersions"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyListSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--approved-only</c> via <see cref="ChocolateyListSettings.ApprovedOnly"/></li>
        ///     <li><c>--by-id-only</c> via <see cref="ChocolateyListSettings.ByIdOnly"/></li>
        ///     <li><c>--by-tag-only</c> via <see cref="ChocolateyListSettings.ByTagOnly"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyListSettings.CacheLocation"/></li>
        ///     <li><c>--cert</c> via <see cref="ChocolateyListSettings.ClientCertificate"/></li>
        ///     <li><c>--certpassword</c> via <see cref="ChocolateyListSettings.CertificatePassword"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyListSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyListSettings.Debug"/></li>
        ///     <li><c>--detailed</c> via <see cref="ChocolateyListSettings.Detailed"/></li>
        ///     <li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/></li>
        ///     <li><c>--download-cache-only</c> via <see cref="ChocolateyListSettings.DownloadCacheAvailable"/></li>
        ///     <li><c>--exact</c> via <see cref="ChocolateyListSettings.Exact"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyListSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyListSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyListSettings.Force"/></li>
        ///     <li><c>--id-only</c> via <see cref="ChocolateyListSettings.IdOnly"/></li>
        ///     <li><c>--id-starts-with</c> via <see cref="ChocolateyListSettings.IdStartsWith"/></li>
        ///     <li><c>--include-programs</c> via <see cref="ChocolateyListSettings.IncludePrograms"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyListSettings.LimitOutput"/></li>
        ///     <li><c>--local-only</c> via <see cref="ChocolateyListSettings.LocalOnly"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyListSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyListSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyListSettings.DoNotShowProgress"/></li>
        ///     <li><c>--not-broken</c> via <see cref="ChocolateyListSettings.NotBroken"/></li>
        ///     <li><c>--order-by-popularity</c> via <see cref="ChocolateyListSettings.OrderByPopularity"/></li>
        ///     <li><c>--page</c> via <see cref="ChocolateyListSettings.Page"/></li>
        ///     <li><c>--page-size</c> via <see cref="ChocolateyListSettings.PageSize"/></li>
        ///     <li><c>--password</c> via <see cref="ChocolateyListSettings.Password"/></li>
        ///     <li><c>--prerelease</c> via <see cref="ChocolateyListSettings.Prerelease"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyListSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyListSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyListSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyListSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyListSettings.ProxyUserName"/></li>
        ///     <li><c>--show-audit-info</c> via <see cref="ChocolateyListSettings.ShowAuditInformation"/></li>
        ///     <li><c>--source</c> via <see cref="ChocolateyListSettings.Source"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyListSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyListSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--user</c> via <see cref="ChocolateyListSettings.User"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyListSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="ChocolateyListSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(ChocolateyListSettings Settings, IReadOnlyCollection<Output> Output)> ChocolateyList(CombinatorialConfigure<ChocolateyListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(ChocolateyList, ChocolateyLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Searches remote or local packages (alias for <c>search</c>).</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/find">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;filter&gt;</c> via <see cref="ChocolateyFindSettings.Filter"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyFindSettings.AcceptLicense"/></li>
        ///     <li><c>--all-versions</c> via <see cref="ChocolateyFindSettings.AllVersions"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyFindSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--approved-only</c> via <see cref="ChocolateyFindSettings.ApprovedOnly"/></li>
        ///     <li><c>--by-id-only</c> via <see cref="ChocolateyFindSettings.ByIdOnly"/></li>
        ///     <li><c>--by-tag-only</c> via <see cref="ChocolateyFindSettings.ByTagOnly"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyFindSettings.CacheLocation"/></li>
        ///     <li><c>--cert</c> via <see cref="ChocolateyFindSettings.ClientCertificate"/></li>
        ///     <li><c>--certpassword</c> via <see cref="ChocolateyFindSettings.CertificatePassword"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyFindSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyFindSettings.Debug"/></li>
        ///     <li><c>--detailed</c> via <see cref="ChocolateyFindSettings.Detailed"/></li>
        ///     <li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/></li>
        ///     <li><c>--download-cache-only</c> via <see cref="ChocolateyFindSettings.DownloadCacheAvailable"/></li>
        ///     <li><c>--exact</c> via <see cref="ChocolateyFindSettings.Exact"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyFindSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyFindSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyFindSettings.Force"/></li>
        ///     <li><c>--id-only</c> via <see cref="ChocolateyFindSettings.IdOnly"/></li>
        ///     <li><c>--id-starts-with</c> via <see cref="ChocolateyFindSettings.IdStartsWith"/></li>
        ///     <li><c>--include-programs</c> via <see cref="ChocolateyFindSettings.IncludePrograms"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyFindSettings.LimitOutput"/></li>
        ///     <li><c>--local-only</c> via <see cref="ChocolateyFindSettings.LocalOnly"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyFindSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyFindSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyFindSettings.DoNotShowProgress"/></li>
        ///     <li><c>--not-broken</c> via <see cref="ChocolateyFindSettings.NotBroken"/></li>
        ///     <li><c>--order-by-popularity</c> via <see cref="ChocolateyFindSettings.OrderByPopularity"/></li>
        ///     <li><c>--page</c> via <see cref="ChocolateyFindSettings.Page"/></li>
        ///     <li><c>--page-size</c> via <see cref="ChocolateyFindSettings.PageSize"/></li>
        ///     <li><c>--password</c> via <see cref="ChocolateyFindSettings.Password"/></li>
        ///     <li><c>--prerelease</c> via <see cref="ChocolateyFindSettings.Prerelease"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyFindSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyFindSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyFindSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyFindSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyFindSettings.ProxyUserName"/></li>
        ///     <li><c>--show-audit-info</c> via <see cref="ChocolateyFindSettings.ShowAuditInformation"/></li>
        ///     <li><c>--source</c> via <see cref="ChocolateyFindSettings.Source"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyFindSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyFindSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--user</c> via <see cref="ChocolateyFindSettings.User"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyFindSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="ChocolateyFindSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ChocolateyFind(ChocolateyFindSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new ChocolateyFindSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Searches remote or local packages (alias for <c>search</c>).</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/find">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;filter&gt;</c> via <see cref="ChocolateyFindSettings.Filter"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyFindSettings.AcceptLicense"/></li>
        ///     <li><c>--all-versions</c> via <see cref="ChocolateyFindSettings.AllVersions"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyFindSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--approved-only</c> via <see cref="ChocolateyFindSettings.ApprovedOnly"/></li>
        ///     <li><c>--by-id-only</c> via <see cref="ChocolateyFindSettings.ByIdOnly"/></li>
        ///     <li><c>--by-tag-only</c> via <see cref="ChocolateyFindSettings.ByTagOnly"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyFindSettings.CacheLocation"/></li>
        ///     <li><c>--cert</c> via <see cref="ChocolateyFindSettings.ClientCertificate"/></li>
        ///     <li><c>--certpassword</c> via <see cref="ChocolateyFindSettings.CertificatePassword"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyFindSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyFindSettings.Debug"/></li>
        ///     <li><c>--detailed</c> via <see cref="ChocolateyFindSettings.Detailed"/></li>
        ///     <li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/></li>
        ///     <li><c>--download-cache-only</c> via <see cref="ChocolateyFindSettings.DownloadCacheAvailable"/></li>
        ///     <li><c>--exact</c> via <see cref="ChocolateyFindSettings.Exact"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyFindSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyFindSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyFindSettings.Force"/></li>
        ///     <li><c>--id-only</c> via <see cref="ChocolateyFindSettings.IdOnly"/></li>
        ///     <li><c>--id-starts-with</c> via <see cref="ChocolateyFindSettings.IdStartsWith"/></li>
        ///     <li><c>--include-programs</c> via <see cref="ChocolateyFindSettings.IncludePrograms"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyFindSettings.LimitOutput"/></li>
        ///     <li><c>--local-only</c> via <see cref="ChocolateyFindSettings.LocalOnly"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyFindSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyFindSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyFindSettings.DoNotShowProgress"/></li>
        ///     <li><c>--not-broken</c> via <see cref="ChocolateyFindSettings.NotBroken"/></li>
        ///     <li><c>--order-by-popularity</c> via <see cref="ChocolateyFindSettings.OrderByPopularity"/></li>
        ///     <li><c>--page</c> via <see cref="ChocolateyFindSettings.Page"/></li>
        ///     <li><c>--page-size</c> via <see cref="ChocolateyFindSettings.PageSize"/></li>
        ///     <li><c>--password</c> via <see cref="ChocolateyFindSettings.Password"/></li>
        ///     <li><c>--prerelease</c> via <see cref="ChocolateyFindSettings.Prerelease"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyFindSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyFindSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyFindSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyFindSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyFindSettings.ProxyUserName"/></li>
        ///     <li><c>--show-audit-info</c> via <see cref="ChocolateyFindSettings.ShowAuditInformation"/></li>
        ///     <li><c>--source</c> via <see cref="ChocolateyFindSettings.Source"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyFindSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyFindSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--user</c> via <see cref="ChocolateyFindSettings.User"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyFindSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="ChocolateyFindSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ChocolateyFind(Configure<ChocolateyFindSettings> configurator)
        {
            return ChocolateyFind(configurator(new ChocolateyFindSettings()));
        }
        /// <summary>
        ///   <p>Searches remote or local packages (alias for <c>search</c>).</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/find">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;filter&gt;</c> via <see cref="ChocolateyFindSettings.Filter"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyFindSettings.AcceptLicense"/></li>
        ///     <li><c>--all-versions</c> via <see cref="ChocolateyFindSettings.AllVersions"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyFindSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--approved-only</c> via <see cref="ChocolateyFindSettings.ApprovedOnly"/></li>
        ///     <li><c>--by-id-only</c> via <see cref="ChocolateyFindSettings.ByIdOnly"/></li>
        ///     <li><c>--by-tag-only</c> via <see cref="ChocolateyFindSettings.ByTagOnly"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyFindSettings.CacheLocation"/></li>
        ///     <li><c>--cert</c> via <see cref="ChocolateyFindSettings.ClientCertificate"/></li>
        ///     <li><c>--certpassword</c> via <see cref="ChocolateyFindSettings.CertificatePassword"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyFindSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyFindSettings.Debug"/></li>
        ///     <li><c>--detailed</c> via <see cref="ChocolateyFindSettings.Detailed"/></li>
        ///     <li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/></li>
        ///     <li><c>--download-cache-only</c> via <see cref="ChocolateyFindSettings.DownloadCacheAvailable"/></li>
        ///     <li><c>--exact</c> via <see cref="ChocolateyFindSettings.Exact"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyFindSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyFindSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyFindSettings.Force"/></li>
        ///     <li><c>--id-only</c> via <see cref="ChocolateyFindSettings.IdOnly"/></li>
        ///     <li><c>--id-starts-with</c> via <see cref="ChocolateyFindSettings.IdStartsWith"/></li>
        ///     <li><c>--include-programs</c> via <see cref="ChocolateyFindSettings.IncludePrograms"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyFindSettings.LimitOutput"/></li>
        ///     <li><c>--local-only</c> via <see cref="ChocolateyFindSettings.LocalOnly"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyFindSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyFindSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyFindSettings.DoNotShowProgress"/></li>
        ///     <li><c>--not-broken</c> via <see cref="ChocolateyFindSettings.NotBroken"/></li>
        ///     <li><c>--order-by-popularity</c> via <see cref="ChocolateyFindSettings.OrderByPopularity"/></li>
        ///     <li><c>--page</c> via <see cref="ChocolateyFindSettings.Page"/></li>
        ///     <li><c>--page-size</c> via <see cref="ChocolateyFindSettings.PageSize"/></li>
        ///     <li><c>--password</c> via <see cref="ChocolateyFindSettings.Password"/></li>
        ///     <li><c>--prerelease</c> via <see cref="ChocolateyFindSettings.Prerelease"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyFindSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyFindSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyFindSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyFindSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyFindSettings.ProxyUserName"/></li>
        ///     <li><c>--show-audit-info</c> via <see cref="ChocolateyFindSettings.ShowAuditInformation"/></li>
        ///     <li><c>--source</c> via <see cref="ChocolateyFindSettings.Source"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyFindSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyFindSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--user</c> via <see cref="ChocolateyFindSettings.User"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyFindSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="ChocolateyFindSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(ChocolateyFindSettings Settings, IReadOnlyCollection<Output> Output)> ChocolateyFind(CombinatorialConfigure<ChocolateyFindSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(ChocolateyFind, ChocolateyLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Retrieves packages that are outdated. Similar to <c>upgrade all --noop</c>.</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/outdated">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyOutdatedSettings.AcceptLicense"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyOutdatedSettings.CacheLocation"/></li>
        ///     <li><c>--cert</c> via <see cref="ChocolateyOutdatedSettings.ClientCertificate"/></li>
        ///     <li><c>--certpassword</c> via <see cref="ChocolateyOutdatedSettings.CertificatePassword"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyOutdatedSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyOutdatedSettings.Debug"/></li>
        ///     <li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyOutdatedSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyOutdatedSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyOutdatedSettings.Force"/></li>
        ///     <li><c>--ignore-pinned</c> via <see cref="ChocolateyOutdatedSettings.IgnorePinned"/></li>
        ///     <li><c>--ignore-unfound</c> via <see cref="ChocolateyOutdatedSettings.IgnoreUnfound"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyOutdatedSettings.LimitOutput"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyOutdatedSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyOutdatedSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyOutdatedSettings.DoNotShowProgress"/></li>
        ///     <li><c>--password</c> via <see cref="ChocolateyOutdatedSettings.Password"/></li>
        ///     <li><c>--prerelease</c> via <see cref="ChocolateyOutdatedSettings.Prerelease"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyOutdatedSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyOutdatedSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyOutdatedSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyOutdatedSettings.ProxyUserName"/></li>
        ///     <li><c>--source</c> via <see cref="ChocolateyOutdatedSettings.Source"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyOutdatedSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--user</c> via <see cref="ChocolateyOutdatedSettings.User"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyOutdatedSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ChocolateyOutdated(ChocolateyOutdatedSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new ChocolateyOutdatedSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Retrieves packages that are outdated. Similar to <c>upgrade all --noop</c>.</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/outdated">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyOutdatedSettings.AcceptLicense"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyOutdatedSettings.CacheLocation"/></li>
        ///     <li><c>--cert</c> via <see cref="ChocolateyOutdatedSettings.ClientCertificate"/></li>
        ///     <li><c>--certpassword</c> via <see cref="ChocolateyOutdatedSettings.CertificatePassword"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyOutdatedSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyOutdatedSettings.Debug"/></li>
        ///     <li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyOutdatedSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyOutdatedSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyOutdatedSettings.Force"/></li>
        ///     <li><c>--ignore-pinned</c> via <see cref="ChocolateyOutdatedSettings.IgnorePinned"/></li>
        ///     <li><c>--ignore-unfound</c> via <see cref="ChocolateyOutdatedSettings.IgnoreUnfound"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyOutdatedSettings.LimitOutput"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyOutdatedSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyOutdatedSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyOutdatedSettings.DoNotShowProgress"/></li>
        ///     <li><c>--password</c> via <see cref="ChocolateyOutdatedSettings.Password"/></li>
        ///     <li><c>--prerelease</c> via <see cref="ChocolateyOutdatedSettings.Prerelease"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyOutdatedSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyOutdatedSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyOutdatedSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyOutdatedSettings.ProxyUserName"/></li>
        ///     <li><c>--source</c> via <see cref="ChocolateyOutdatedSettings.Source"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyOutdatedSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--user</c> via <see cref="ChocolateyOutdatedSettings.User"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyOutdatedSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ChocolateyOutdated(Configure<ChocolateyOutdatedSettings> configurator)
        {
            return ChocolateyOutdated(configurator(new ChocolateyOutdatedSettings()));
        }
        /// <summary>
        ///   <p>Retrieves packages that are outdated. Similar to <c>upgrade all --noop</c>.</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/outdated">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyOutdatedSettings.AcceptLicense"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyOutdatedSettings.CacheLocation"/></li>
        ///     <li><c>--cert</c> via <see cref="ChocolateyOutdatedSettings.ClientCertificate"/></li>
        ///     <li><c>--certpassword</c> via <see cref="ChocolateyOutdatedSettings.CertificatePassword"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyOutdatedSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyOutdatedSettings.Debug"/></li>
        ///     <li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyOutdatedSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyOutdatedSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyOutdatedSettings.Force"/></li>
        ///     <li><c>--ignore-pinned</c> via <see cref="ChocolateyOutdatedSettings.IgnorePinned"/></li>
        ///     <li><c>--ignore-unfound</c> via <see cref="ChocolateyOutdatedSettings.IgnoreUnfound"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyOutdatedSettings.LimitOutput"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyOutdatedSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyOutdatedSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyOutdatedSettings.DoNotShowProgress"/></li>
        ///     <li><c>--password</c> via <see cref="ChocolateyOutdatedSettings.Password"/></li>
        ///     <li><c>--prerelease</c> via <see cref="ChocolateyOutdatedSettings.Prerelease"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyOutdatedSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyOutdatedSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyOutdatedSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyOutdatedSettings.ProxyUserName"/></li>
        ///     <li><c>--source</c> via <see cref="ChocolateyOutdatedSettings.Source"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyOutdatedSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--user</c> via <see cref="ChocolateyOutdatedSettings.User"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyOutdatedSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(ChocolateyOutdatedSettings Settings, IReadOnlyCollection<Output> Output)> ChocolateyOutdated(CombinatorialConfigure<ChocolateyOutdatedSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(ChocolateyOutdated, ChocolateyLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Packages up a nuspec to a compiled nupkg.</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/pack">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;pathToNuspec&gt;</c> via <see cref="ChocolateyPackSettings.PathToNuspec"/></li>
        ///     <li><c>--</c> via <see cref="ChocolateyPackSettings.Properties"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyPackSettings.AcceptLicense"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyPackSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyPackSettings.CacheLocation"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyPackSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyPackSettings.Debug"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyPackSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyPackSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyPackSettings.Force"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyPackSettings.LimitOutput"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyPackSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyPackSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyPackSettings.DoNotShowProgress"/></li>
        ///     <li><c>--output-directory</c> via <see cref="ChocolateyPackSettings.OutputDirectory"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyPackSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyPackSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyPackSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyPackSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyPackSettings.ProxyUserName"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyPackSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyPackSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyPackSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="ChocolateyPackSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ChocolateyPack(ChocolateyPackSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new ChocolateyPackSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Packages up a nuspec to a compiled nupkg.</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/pack">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;pathToNuspec&gt;</c> via <see cref="ChocolateyPackSettings.PathToNuspec"/></li>
        ///     <li><c>--</c> via <see cref="ChocolateyPackSettings.Properties"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyPackSettings.AcceptLicense"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyPackSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyPackSettings.CacheLocation"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyPackSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyPackSettings.Debug"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyPackSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyPackSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyPackSettings.Force"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyPackSettings.LimitOutput"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyPackSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyPackSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyPackSettings.DoNotShowProgress"/></li>
        ///     <li><c>--output-directory</c> via <see cref="ChocolateyPackSettings.OutputDirectory"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyPackSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyPackSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyPackSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyPackSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyPackSettings.ProxyUserName"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyPackSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyPackSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyPackSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="ChocolateyPackSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ChocolateyPack(Configure<ChocolateyPackSettings> configurator)
        {
            return ChocolateyPack(configurator(new ChocolateyPackSettings()));
        }
        /// <summary>
        ///   <p>Packages up a nuspec to a compiled nupkg.</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/pack">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;pathToNuspec&gt;</c> via <see cref="ChocolateyPackSettings.PathToNuspec"/></li>
        ///     <li><c>--</c> via <see cref="ChocolateyPackSettings.Properties"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyPackSettings.AcceptLicense"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyPackSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyPackSettings.CacheLocation"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyPackSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyPackSettings.Debug"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyPackSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyPackSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyPackSettings.Force"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyPackSettings.LimitOutput"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyPackSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyPackSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyPackSettings.DoNotShowProgress"/></li>
        ///     <li><c>--output-directory</c> via <see cref="ChocolateyPackSettings.OutputDirectory"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyPackSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyPackSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyPackSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyPackSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyPackSettings.ProxyUserName"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyPackSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyPackSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyPackSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="ChocolateyPackSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(ChocolateyPackSettings Settings, IReadOnlyCollection<Output> Output)> ChocolateyPack(CombinatorialConfigure<ChocolateyPackSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(ChocolateyPack, ChocolateyLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Pushes a compiled nupkg.</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/push">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;pathToNuGetPackage&gt;</c> via <see cref="ChocolateyPushSettings.PathToNuGetPackage"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyPushSettings.AcceptLicense"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyPushSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--api-key</c> via <see cref="ChocolateyPushSettings.ApiKey"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyPushSettings.CacheLocation"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyPushSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyPushSettings.Debug"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyPushSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyPushSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyPushSettings.Force"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyPushSettings.LimitOutput"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyPushSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyPushSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyPushSettings.DoNotShowProgress"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyPushSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyPushSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyPushSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyPushSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyPushSettings.ProxyUserName"/></li>
        ///     <li><c>--source</c> via <see cref="ChocolateyPushSettings.Source"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyPushSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyPushSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyPushSettings.Verbose"/></li>
        ///     <li><c>-t</c> via <see cref="ChocolateyPushSettings.Timeout"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ChocolateyPush(ChocolateyPushSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new ChocolateyPushSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Pushes a compiled nupkg.</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/push">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;pathToNuGetPackage&gt;</c> via <see cref="ChocolateyPushSettings.PathToNuGetPackage"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyPushSettings.AcceptLicense"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyPushSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--api-key</c> via <see cref="ChocolateyPushSettings.ApiKey"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyPushSettings.CacheLocation"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyPushSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyPushSettings.Debug"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyPushSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyPushSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyPushSettings.Force"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyPushSettings.LimitOutput"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyPushSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyPushSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyPushSettings.DoNotShowProgress"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyPushSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyPushSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyPushSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyPushSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyPushSettings.ProxyUserName"/></li>
        ///     <li><c>--source</c> via <see cref="ChocolateyPushSettings.Source"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyPushSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyPushSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyPushSettings.Verbose"/></li>
        ///     <li><c>-t</c> via <see cref="ChocolateyPushSettings.Timeout"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ChocolateyPush(Configure<ChocolateyPushSettings> configurator)
        {
            return ChocolateyPush(configurator(new ChocolateyPushSettings()));
        }
        /// <summary>
        ///   <p>Pushes a compiled nupkg.</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/push">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;pathToNuGetPackage&gt;</c> via <see cref="ChocolateyPushSettings.PathToNuGetPackage"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyPushSettings.AcceptLicense"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyPushSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--api-key</c> via <see cref="ChocolateyPushSettings.ApiKey"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyPushSettings.CacheLocation"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyPushSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyPushSettings.Debug"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyPushSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyPushSettings.FailOnStandardError"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyPushSettings.Force"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyPushSettings.LimitOutput"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyPushSettings.LogFile"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyPushSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyPushSettings.DoNotShowProgress"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyPushSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyPushSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyPushSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyPushSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyPushSettings.ProxyUserName"/></li>
        ///     <li><c>--source</c> via <see cref="ChocolateyPushSettings.Source"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyPushSettings.Trace"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyPushSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyPushSettings.Verbose"/></li>
        ///     <li><c>-t</c> via <see cref="ChocolateyPushSettings.Timeout"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(ChocolateyPushSettings Settings, IReadOnlyCollection<Output> Output)> ChocolateyPush(CombinatorialConfigure<ChocolateyPushSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(ChocolateyPush, ChocolateyLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Generates files necessary for a chocolatey package from a template.</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/new">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="ChocolateyNewSettings.Properties"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyNewSettings.AcceptLicense"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyNewSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--automaticpackage</c> via <see cref="ChocolateyNewSettings.AutomaticPackage"/></li>
        ///     <li><c>--build-package</c> via <see cref="ChocolateyNewSettings.BuildPackage"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyNewSettings.CacheLocation"/></li>
        ///     <li><c>--checksum</c> via <see cref="ChocolateyNewSettings.Checksum"/></li>
        ///     <li><c>--checksum-type</c> via <see cref="ChocolateyNewSettings.ChecksumType"/></li>
        ///     <li><c>--checksum-x64</c> via <see cref="ChocolateyNewSettings.Checksum64"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyNewSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyNewSettings.Debug"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyNewSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyNewSettings.FailOnStandardError"/></li>
        ///     <li><c>--file</c> via <see cref="ChocolateyNewSettings.LocationOfBinary"/></li>
        ///     <li><c>--file64</c> via <see cref="ChocolateyNewSettings.LocationOfBinary64"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyNewSettings.Force"/></li>
        ///     <li><c>--from-programs-and-features</c> via <see cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/></li>
        ///     <li><c>--generate-for-community</c> via <see cref="ChocolateyNewSettings.GenerateForCommunity"/></li>
        ///     <li><c>--include-architecture-in-name</c> via <see cref="ChocolateyNewSettings.IncludeArchitectureInName"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyNewSettings.LimitOutput"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyNewSettings.LogFile"/></li>
        ///     <li><c>--maintainer</c> via <see cref="ChocolateyNewSettings.Maintainer"/></li>
        ///     <li><c>--name</c> via <see cref="ChocolateyNewSettings.Name"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyNewSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyNewSettings.DoNotShowProgress"/></li>
        ///     <li><c>--output-directory</c> via <see cref="ChocolateyNewSettings.OutputDirectory"/></li>
        ///     <li><c>--pause-on-error</c> via <see cref="ChocolateyNewSettings.PauseOnError"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyNewSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyNewSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyNewSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyNewSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyNewSettings.ProxyUserName"/></li>
        ///     <li><c>--remove-architecture-from-name</c> via <see cref="ChocolateyNewSettings.RemoveArchitectureFromName"/></li>
        ///     <li><c>--template-name</c> via <see cref="ChocolateyNewSettings.TemplateName"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyNewSettings.Trace"/></li>
        ///     <li><c>--use-built-in-template</c> via <see cref="ChocolateyNewSettings.BuildInTemplate"/></li>
        ///     <li><c>--use-original-files-location</c> via <see cref="ChocolateyNewSettings.UseOriginalFilesLocation"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyNewSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyNewSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="ChocolateyNewSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ChocolateyNew(ChocolateyNewSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new ChocolateyNewSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Generates files necessary for a chocolatey package from a template.</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/new">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="ChocolateyNewSettings.Properties"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyNewSettings.AcceptLicense"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyNewSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--automaticpackage</c> via <see cref="ChocolateyNewSettings.AutomaticPackage"/></li>
        ///     <li><c>--build-package</c> via <see cref="ChocolateyNewSettings.BuildPackage"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyNewSettings.CacheLocation"/></li>
        ///     <li><c>--checksum</c> via <see cref="ChocolateyNewSettings.Checksum"/></li>
        ///     <li><c>--checksum-type</c> via <see cref="ChocolateyNewSettings.ChecksumType"/></li>
        ///     <li><c>--checksum-x64</c> via <see cref="ChocolateyNewSettings.Checksum64"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyNewSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyNewSettings.Debug"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyNewSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyNewSettings.FailOnStandardError"/></li>
        ///     <li><c>--file</c> via <see cref="ChocolateyNewSettings.LocationOfBinary"/></li>
        ///     <li><c>--file64</c> via <see cref="ChocolateyNewSettings.LocationOfBinary64"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyNewSettings.Force"/></li>
        ///     <li><c>--from-programs-and-features</c> via <see cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/></li>
        ///     <li><c>--generate-for-community</c> via <see cref="ChocolateyNewSettings.GenerateForCommunity"/></li>
        ///     <li><c>--include-architecture-in-name</c> via <see cref="ChocolateyNewSettings.IncludeArchitectureInName"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyNewSettings.LimitOutput"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyNewSettings.LogFile"/></li>
        ///     <li><c>--maintainer</c> via <see cref="ChocolateyNewSettings.Maintainer"/></li>
        ///     <li><c>--name</c> via <see cref="ChocolateyNewSettings.Name"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyNewSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyNewSettings.DoNotShowProgress"/></li>
        ///     <li><c>--output-directory</c> via <see cref="ChocolateyNewSettings.OutputDirectory"/></li>
        ///     <li><c>--pause-on-error</c> via <see cref="ChocolateyNewSettings.PauseOnError"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyNewSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyNewSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyNewSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyNewSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyNewSettings.ProxyUserName"/></li>
        ///     <li><c>--remove-architecture-from-name</c> via <see cref="ChocolateyNewSettings.RemoveArchitectureFromName"/></li>
        ///     <li><c>--template-name</c> via <see cref="ChocolateyNewSettings.TemplateName"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyNewSettings.Trace"/></li>
        ///     <li><c>--use-built-in-template</c> via <see cref="ChocolateyNewSettings.BuildInTemplate"/></li>
        ///     <li><c>--use-original-files-location</c> via <see cref="ChocolateyNewSettings.UseOriginalFilesLocation"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyNewSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyNewSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="ChocolateyNewSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ChocolateyNew(Configure<ChocolateyNewSettings> configurator)
        {
            return ChocolateyNew(configurator(new ChocolateyNewSettings()));
        }
        /// <summary>
        ///   <p>Generates files necessary for a chocolatey package from a template.</p>
        ///   <p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/new">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="ChocolateyNewSettings.Properties"/></li>
        ///     <li><c>--accept-license</c> via <see cref="ChocolateyNewSettings.AcceptLicense"/></li>
        ///     <li><c>--allow-unofficial-build</c> via <see cref="ChocolateyNewSettings.AllowUnofficialBuild"/></li>
        ///     <li><c>--automaticpackage</c> via <see cref="ChocolateyNewSettings.AutomaticPackage"/></li>
        ///     <li><c>--build-package</c> via <see cref="ChocolateyNewSettings.BuildPackage"/></li>
        ///     <li><c>--cache-location</c> via <see cref="ChocolateyNewSettings.CacheLocation"/></li>
        ///     <li><c>--checksum</c> via <see cref="ChocolateyNewSettings.Checksum"/></li>
        ///     <li><c>--checksum-type</c> via <see cref="ChocolateyNewSettings.ChecksumType"/></li>
        ///     <li><c>--checksum-x64</c> via <see cref="ChocolateyNewSettings.Checksum64"/></li>
        ///     <li><c>--confirm</c> via <see cref="ChocolateyNewSettings.Confirm"/></li>
        ///     <li><c>--debug</c> via <see cref="ChocolateyNewSettings.Debug"/></li>
        ///     <li><c>--execution-timeout</c> via <see cref="ChocolateyNewSettings.CommandExecutionTimeout"/></li>
        ///     <li><c>--fail-on-standard-error</c> via <see cref="ChocolateyNewSettings.FailOnStandardError"/></li>
        ///     <li><c>--file</c> via <see cref="ChocolateyNewSettings.LocationOfBinary"/></li>
        ///     <li><c>--file64</c> via <see cref="ChocolateyNewSettings.LocationOfBinary64"/></li>
        ///     <li><c>--force</c> via <see cref="ChocolateyNewSettings.Force"/></li>
        ///     <li><c>--from-programs-and-features</c> via <see cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/></li>
        ///     <li><c>--generate-for-community</c> via <see cref="ChocolateyNewSettings.GenerateForCommunity"/></li>
        ///     <li><c>--include-architecture-in-name</c> via <see cref="ChocolateyNewSettings.IncludeArchitectureInName"/></li>
        ///     <li><c>--limit-output</c> via <see cref="ChocolateyNewSettings.LimitOutput"/></li>
        ///     <li><c>--log-file</c> via <see cref="ChocolateyNewSettings.LogFile"/></li>
        ///     <li><c>--maintainer</c> via <see cref="ChocolateyNewSettings.Maintainer"/></li>
        ///     <li><c>--name</c> via <see cref="ChocolateyNewSettings.Name"/></li>
        ///     <li><c>--no-color</c> via <see cref="ChocolateyNewSettings.NoColor"/></li>
        ///     <li><c>--no-progress</c> via <see cref="ChocolateyNewSettings.DoNotShowProgress"/></li>
        ///     <li><c>--output-directory</c> via <see cref="ChocolateyNewSettings.OutputDirectory"/></li>
        ///     <li><c>--pause-on-error</c> via <see cref="ChocolateyNewSettings.PauseOnError"/></li>
        ///     <li><c>--proxy</c> via <see cref="ChocolateyNewSettings.Proxy"/></li>
        ///     <li><c>--proxy-bypass-list</c> via <see cref="ChocolateyNewSettings.ProxyBypassList"/></li>
        ///     <li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyNewSettings.ProxyBypassOnLocal"/></li>
        ///     <li><c>--proxy-password</c> via <see cref="ChocolateyNewSettings.ProxyPassword"/></li>
        ///     <li><c>--proxy-user</c> via <see cref="ChocolateyNewSettings.ProxyUserName"/></li>
        ///     <li><c>--remove-architecture-from-name</c> via <see cref="ChocolateyNewSettings.RemoveArchitectureFromName"/></li>
        ///     <li><c>--template-name</c> via <see cref="ChocolateyNewSettings.TemplateName"/></li>
        ///     <li><c>--trace</c> via <see cref="ChocolateyNewSettings.Trace"/></li>
        ///     <li><c>--use-built-in-template</c> via <see cref="ChocolateyNewSettings.BuildInTemplate"/></li>
        ///     <li><c>--use-original-files-location</c> via <see cref="ChocolateyNewSettings.UseOriginalFilesLocation"/></li>
        ///     <li><c>--use-system-powershell</c> via <see cref="ChocolateyNewSettings.UseSystemPowerShell"/></li>
        ///     <li><c>--verbose</c> via <see cref="ChocolateyNewSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="ChocolateyNewSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(ChocolateyNewSettings Settings, IReadOnlyCollection<Output> Output)> ChocolateyNew(CombinatorialConfigure<ChocolateyNewSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(ChocolateyNew, ChocolateyLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region ChocolateySearchSettings
    /// <summary>
    ///   Used within <see cref="ChocolateyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class ChocolateySearchSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Chocolatey executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? ChocolateyTasks.ChocolateyPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? ChocolateyTasks.ChocolateyLogger;
        /// <summary>
        ///   Search filter.
        /// </summary>
        public virtual string Filter { get; internal set; }
        /// <summary>
        ///   Source location for install. Can use special 'webpi' or 'windowsfeatures' sources. Defaults to sources.
        /// </summary>
        public virtual string Source { get; internal set; }
        /// <summary>
        ///   Only search against local machine items.
        /// </summary>
        public virtual bool? LocalOnly { get; internal set; }
        /// <summary>
        ///   Only return Package Ids in the list results.
        /// </summary>
        public virtual bool? IdOnly { get; internal set; }
        /// <summary>
        ///   Include Prereleases? Defaults to false.
        /// </summary>
        public virtual bool? Prerelease { get; internal set; }
        /// <summary>
        ///   Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.
        /// </summary>
        public virtual bool? IncludePrograms { get; internal set; }
        /// <summary>
        ///   Include results from all versions.
        /// </summary>
        public virtual bool? AllVersions { get; internal set; }
        /// <summary>
        ///   Specific version of a package to return.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   The 'page' of results to return. Defaults to return all results.
        /// </summary>
        public virtual int? Page { get; internal set; }
        /// <summary>
        ///   The amount of package results to return per page. Defaults to 25.
        /// </summary>
        public virtual int? PageSize { get; internal set; }
        /// <summary>
        ///   Only return packages with this exact name.
        /// </summary>
        public virtual bool? Exact { get; internal set; }
        /// <summary>
        ///   Only return packages where the id contains the search filter.
        /// </summary>
        public virtual bool? ByIdOnly { get; internal set; }
        /// <summary>
        ///   Only return packages where the search filter matches on the tags.
        /// </summary>
        public virtual bool? ByTagOnly { get; internal set; }
        /// <summary>
        ///   Only return packages where the id starts with the search filter.
        /// </summary>
        public virtual bool? IdStartsWith { get; internal set; }
        /// <summary>
        ///   Sort by package results by popularity.
        /// </summary>
        public virtual bool? OrderByPopularity { get; internal set; }
        /// <summary>
        ///   Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.
        /// </summary>
        public virtual bool? ApprovedOnly { get; internal set; }
        /// <summary>
        ///   Only return packages that have a download cache available - this option will filter out results not from the community repository.
        /// </summary>
        public virtual bool? DownloadCacheAvailable { get; internal set; }
        /// <summary>
        ///   Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.
        /// </summary>
        public virtual bool? NotBroken { get; internal set; }
        /// <summary>
        ///   Alias for verbose.
        /// </summary>
        public virtual bool? Detailed { get; internal set; }
        /// <summary>
        ///   Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.
        /// </summary>
        public virtual bool? DisablePackageRepositoryOptimizations { get; internal set; }
        /// <summary>
        ///   Display auditing information for a package.
        /// </summary>
        public virtual bool? ShowAuditInformation { get; internal set; }
        /// <summary>
        ///   Used with authenticated feeds. Defaults to empty.
        /// </summary>
        public virtual string User { get; internal set; }
        /// <summary>
        ///   The user's password to the source. Defaults to empty.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   PFX pathname for an x509 authenticated feeds. Defaults to empty.
        /// </summary>
        public virtual string ClientCertificate { get; internal set; }
        /// <summary>
        ///   The client certificate's password to the source. Defaults to empty.
        /// </summary>
        public virtual string CertificatePassword { get; internal set; }
        /// <summary>
        ///   Show debug messaging.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.
        /// </summary>
        public virtual bool? Trace { get; internal set; }
        /// <summary>
        ///   Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Accept license dialogs automatically. Reserved for future use.
        /// </summary>
        public virtual bool? AcceptLicense { get; internal set; }
        /// <summary>
        ///   Chooses affirmative answer instead of prompting. Implies --accept-license
        /// </summary>
        public virtual bool? Confirm { get; internal set; }
        /// <summary>
        ///   Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Limit the output to essential information
        /// </summary>
        public virtual bool? LimitOutput { get; internal set; }
        /// <summary>
        ///   The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.
        /// </summary>
        public virtual int? CommandExecutionTimeout { get; internal set; }
        /// <summary>
        ///   Location for download cache, defaults to %TEMP% or value in chocolatey.config file.
        /// </summary>
        public virtual string CacheLocation { get; internal set; }
        /// <summary>
        ///   When not using the official build you must set this flag for choco to continue.
        /// </summary>
        public virtual bool? AllowUnofficialBuild { get; internal set; }
        /// <summary>
        ///   Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.
        /// </summary>
        public virtual bool? FailOnStandardError { get; internal set; }
        /// <summary>
        ///   Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.
        /// </summary>
        public virtual bool? UseSystemPowerShell { get; internal set; }
        /// <summary>
        ///   Do not show download progress percentages.
        /// </summary>
        public virtual bool? DoNotShowProgress { get; internal set; }
        /// <summary>
        ///   Explicit proxy location. Overrides the default proxy location of ''.
        /// </summary>
        public virtual string Proxy { get; internal set; }
        /// <summary>
        ///   Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.
        /// </summary>
        public virtual string ProxyUserName { get; internal set; }
        /// <summary>
        ///   Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).
        /// </summary>
        public virtual string ProxyPassword { get; internal set; }
        /// <summary>
        ///   Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).
        /// </summary>
        public virtual IReadOnlyList<string> ProxyBypassList => ProxyBypassListInternal.AsReadOnly();
        internal List<string> ProxyBypassListInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).
        /// </summary>
        public virtual bool? ProxyBypassOnLocal { get; internal set; }
        /// <summary>
        ///   Log File to output to in addition to regular loggers.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("search")
              .Add("{value}", Filter)
              .Add("--source={value}", Source)
              .Add("--local-only", LocalOnly)
              .Add("--id-only", IdOnly)
              .Add("--prerelease", Prerelease)
              .Add("--include-programs", IncludePrograms)
              .Add("--all-versions", AllVersions)
              .Add("--version={value}", Version)
              .Add("--page={value}", Page)
              .Add("--page-size={value}", PageSize)
              .Add("--exact", Exact)
              .Add("--by-id-only", ByIdOnly)
              .Add("--by-tag-only", ByTagOnly)
              .Add("--id-starts-with", IdStartsWith)
              .Add("--order-by-popularity", OrderByPopularity)
              .Add("--approved-only", ApprovedOnly)
              .Add("--download-cache-only", DownloadCacheAvailable)
              .Add("--not-broken", NotBroken)
              .Add("--detailed", Detailed)
              .Add("--disable-package-repository-optimizations", DisablePackageRepositoryOptimizations)
              .Add("--show-audit-info", ShowAuditInformation)
              .Add("--user={value}", User)
              .Add("--password={value}", Password, secret: true)
              .Add("--cert={value}", ClientCertificate)
              .Add("--certpassword={value}", CertificatePassword, secret: true)
              .Add("--debug", Debug)
              .Add("--verbose", Verbose)
              .Add("--trace", Trace)
              .Add("--no-color", NoColor)
              .Add("--accept-license", AcceptLicense)
              .Add("--confirm", Confirm)
              .Add("--force", Force)
              .Add("--limit-output", LimitOutput)
              .Add("--execution-timeout={value}", CommandExecutionTimeout)
              .Add("--cache-location {value}", CacheLocation)
              .Add("--allow-unofficial-build", AllowUnofficialBuild)
              .Add("--fail-on-standard-error", FailOnStandardError)
              .Add("--use-system-powershell", UseSystemPowerShell)
              .Add("--no-progress", DoNotShowProgress)
              .Add("--proxy={value}", Proxy)
              .Add("--proxy-user={value}", ProxyUserName)
              .Add("--proxy-password={value}", ProxyPassword, secret: true)
              .Add("--proxy-bypass-list={value}", ProxyBypassList, separator: ',')
              .Add("--proxy-bypass-on-local", ProxyBypassOnLocal)
              .Add("--log-file={value}", LogFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region ChocolateyListSettings
    /// <summary>
    ///   Used within <see cref="ChocolateyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class ChocolateyListSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Chocolatey executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? ChocolateyTasks.ChocolateyPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? ChocolateyTasks.ChocolateyLogger;
        /// <summary>
        ///   Search filter.
        /// </summary>
        public virtual string Filter { get; internal set; }
        /// <summary>
        ///   Source location for install. Can use special 'webpi' or 'windowsfeatures' sources. Defaults to sources.
        /// </summary>
        public virtual string Source { get; internal set; }
        /// <summary>
        ///   Only search against local machine items.
        /// </summary>
        public virtual bool? LocalOnly { get; internal set; }
        /// <summary>
        ///   Only return Package Ids in the list results.
        /// </summary>
        public virtual bool? IdOnly { get; internal set; }
        /// <summary>
        ///   Include Prereleases? Defaults to false.
        /// </summary>
        public virtual bool? Prerelease { get; internal set; }
        /// <summary>
        ///   Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.
        /// </summary>
        public virtual bool? IncludePrograms { get; internal set; }
        /// <summary>
        ///   Include results from all versions.
        /// </summary>
        public virtual bool? AllVersions { get; internal set; }
        /// <summary>
        ///   Specific version of a package to return.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   The 'page' of results to return. Defaults to return all results.
        /// </summary>
        public virtual int? Page { get; internal set; }
        /// <summary>
        ///   The amount of package results to return per page. Defaults to 25.
        /// </summary>
        public virtual int? PageSize { get; internal set; }
        /// <summary>
        ///   Only return packages with this exact name.
        /// </summary>
        public virtual bool? Exact { get; internal set; }
        /// <summary>
        ///   Only return packages where the id contains the search filter.
        /// </summary>
        public virtual bool? ByIdOnly { get; internal set; }
        /// <summary>
        ///   Only return packages where the search filter matches on the tags.
        /// </summary>
        public virtual bool? ByTagOnly { get; internal set; }
        /// <summary>
        ///   Only return packages where the id starts with the search filter.
        /// </summary>
        public virtual bool? IdStartsWith { get; internal set; }
        /// <summary>
        ///   Sort by package results by popularity.
        /// </summary>
        public virtual bool? OrderByPopularity { get; internal set; }
        /// <summary>
        ///   Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.
        /// </summary>
        public virtual bool? ApprovedOnly { get; internal set; }
        /// <summary>
        ///   Only return packages that have a download cache available - this option will filter out results not from the community repository.
        /// </summary>
        public virtual bool? DownloadCacheAvailable { get; internal set; }
        /// <summary>
        ///   Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.
        /// </summary>
        public virtual bool? NotBroken { get; internal set; }
        /// <summary>
        ///   Alias for verbose.
        /// </summary>
        public virtual bool? Detailed { get; internal set; }
        /// <summary>
        ///   Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.
        /// </summary>
        public virtual bool? DisablePackageRepositoryOptimizations { get; internal set; }
        /// <summary>
        ///   Display auditing information for a package.
        /// </summary>
        public virtual bool? ShowAuditInformation { get; internal set; }
        /// <summary>
        ///   Used with authenticated feeds. Defaults to empty.
        /// </summary>
        public virtual string User { get; internal set; }
        /// <summary>
        ///   The user's password to the source. Defaults to empty.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   PFX pathname for an x509 authenticated feeds. Defaults to empty.
        /// </summary>
        public virtual string ClientCertificate { get; internal set; }
        /// <summary>
        ///   The client certificate's password to the source. Defaults to empty.
        /// </summary>
        public virtual string CertificatePassword { get; internal set; }
        /// <summary>
        ///   Show debug messaging.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.
        /// </summary>
        public virtual bool? Trace { get; internal set; }
        /// <summary>
        ///   Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Accept license dialogs automatically. Reserved for future use.
        /// </summary>
        public virtual bool? AcceptLicense { get; internal set; }
        /// <summary>
        ///   Chooses affirmative answer instead of prompting. Implies --accept-license
        /// </summary>
        public virtual bool? Confirm { get; internal set; }
        /// <summary>
        ///   Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Limit the output to essential information
        /// </summary>
        public virtual bool? LimitOutput { get; internal set; }
        /// <summary>
        ///   The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.
        /// </summary>
        public virtual int? CommandExecutionTimeout { get; internal set; }
        /// <summary>
        ///   Location for download cache, defaults to %TEMP% or value in chocolatey.config file.
        /// </summary>
        public virtual string CacheLocation { get; internal set; }
        /// <summary>
        ///   When not using the official build you must set this flag for choco to continue.
        /// </summary>
        public virtual bool? AllowUnofficialBuild { get; internal set; }
        /// <summary>
        ///   Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.
        /// </summary>
        public virtual bool? FailOnStandardError { get; internal set; }
        /// <summary>
        ///   Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.
        /// </summary>
        public virtual bool? UseSystemPowerShell { get; internal set; }
        /// <summary>
        ///   Do not show download progress percentages.
        /// </summary>
        public virtual bool? DoNotShowProgress { get; internal set; }
        /// <summary>
        ///   Explicit proxy location. Overrides the default proxy location of ''.
        /// </summary>
        public virtual string Proxy { get; internal set; }
        /// <summary>
        ///   Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.
        /// </summary>
        public virtual string ProxyUserName { get; internal set; }
        /// <summary>
        ///   Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).
        /// </summary>
        public virtual string ProxyPassword { get; internal set; }
        /// <summary>
        ///   Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).
        /// </summary>
        public virtual IReadOnlyList<string> ProxyBypassList => ProxyBypassListInternal.AsReadOnly();
        internal List<string> ProxyBypassListInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).
        /// </summary>
        public virtual bool? ProxyBypassOnLocal { get; internal set; }
        /// <summary>
        ///   Log File to output to in addition to regular loggers.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("list")
              .Add("{value}", Filter)
              .Add("--source={value}", Source)
              .Add("--local-only", LocalOnly)
              .Add("--id-only", IdOnly)
              .Add("--prerelease", Prerelease)
              .Add("--include-programs", IncludePrograms)
              .Add("--all-versions", AllVersions)
              .Add("--version={value}", Version)
              .Add("--page={value}", Page)
              .Add("--page-size={value}", PageSize)
              .Add("--exact", Exact)
              .Add("--by-id-only", ByIdOnly)
              .Add("--by-tag-only", ByTagOnly)
              .Add("--id-starts-with", IdStartsWith)
              .Add("--order-by-popularity", OrderByPopularity)
              .Add("--approved-only", ApprovedOnly)
              .Add("--download-cache-only", DownloadCacheAvailable)
              .Add("--not-broken", NotBroken)
              .Add("--detailed", Detailed)
              .Add("--disable-package-repository-optimizations", DisablePackageRepositoryOptimizations)
              .Add("--show-audit-info", ShowAuditInformation)
              .Add("--user={value}", User)
              .Add("--password={value}", Password, secret: true)
              .Add("--cert={value}", ClientCertificate)
              .Add("--certpassword={value}", CertificatePassword, secret: true)
              .Add("--debug", Debug)
              .Add("--verbose", Verbose)
              .Add("--trace", Trace)
              .Add("--no-color", NoColor)
              .Add("--accept-license", AcceptLicense)
              .Add("--confirm", Confirm)
              .Add("--force", Force)
              .Add("--limit-output", LimitOutput)
              .Add("--execution-timeout={value}", CommandExecutionTimeout)
              .Add("--cache-location {value}", CacheLocation)
              .Add("--allow-unofficial-build", AllowUnofficialBuild)
              .Add("--fail-on-standard-error", FailOnStandardError)
              .Add("--use-system-powershell", UseSystemPowerShell)
              .Add("--no-progress", DoNotShowProgress)
              .Add("--proxy={value}", Proxy)
              .Add("--proxy-user={value}", ProxyUserName)
              .Add("--proxy-password={value}", ProxyPassword, secret: true)
              .Add("--proxy-bypass-list={value}", ProxyBypassList, separator: ',')
              .Add("--proxy-bypass-on-local", ProxyBypassOnLocal)
              .Add("--log-file={value}", LogFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region ChocolateyFindSettings
    /// <summary>
    ///   Used within <see cref="ChocolateyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class ChocolateyFindSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Chocolatey executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? ChocolateyTasks.ChocolateyPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? ChocolateyTasks.ChocolateyLogger;
        /// <summary>
        ///   Search filter.
        /// </summary>
        public virtual string Filter { get; internal set; }
        /// <summary>
        ///   Source location for install. Can use special 'webpi' or 'windowsfeatures' sources. Defaults to sources.
        /// </summary>
        public virtual string Source { get; internal set; }
        /// <summary>
        ///   Only search against local machine items.
        /// </summary>
        public virtual bool? LocalOnly { get; internal set; }
        /// <summary>
        ///   Only return Package Ids in the list results.
        /// </summary>
        public virtual bool? IdOnly { get; internal set; }
        /// <summary>
        ///   Include Prereleases? Defaults to false.
        /// </summary>
        public virtual bool? Prerelease { get; internal set; }
        /// <summary>
        ///   Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.
        /// </summary>
        public virtual bool? IncludePrograms { get; internal set; }
        /// <summary>
        ///   Include results from all versions.
        /// </summary>
        public virtual bool? AllVersions { get; internal set; }
        /// <summary>
        ///   Specific version of a package to return.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   The 'page' of results to return. Defaults to return all results.
        /// </summary>
        public virtual int? Page { get; internal set; }
        /// <summary>
        ///   The amount of package results to return per page. Defaults to 25.
        /// </summary>
        public virtual int? PageSize { get; internal set; }
        /// <summary>
        ///   Only return packages with this exact name.
        /// </summary>
        public virtual bool? Exact { get; internal set; }
        /// <summary>
        ///   Only return packages where the id contains the search filter.
        /// </summary>
        public virtual bool? ByIdOnly { get; internal set; }
        /// <summary>
        ///   Only return packages where the search filter matches on the tags.
        /// </summary>
        public virtual bool? ByTagOnly { get; internal set; }
        /// <summary>
        ///   Only return packages where the id starts with the search filter.
        /// </summary>
        public virtual bool? IdStartsWith { get; internal set; }
        /// <summary>
        ///   Sort by package results by popularity.
        /// </summary>
        public virtual bool? OrderByPopularity { get; internal set; }
        /// <summary>
        ///   Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.
        /// </summary>
        public virtual bool? ApprovedOnly { get; internal set; }
        /// <summary>
        ///   Only return packages that have a download cache available - this option will filter out results not from the community repository.
        /// </summary>
        public virtual bool? DownloadCacheAvailable { get; internal set; }
        /// <summary>
        ///   Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.
        /// </summary>
        public virtual bool? NotBroken { get; internal set; }
        /// <summary>
        ///   Alias for verbose.
        /// </summary>
        public virtual bool? Detailed { get; internal set; }
        /// <summary>
        ///   Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.
        /// </summary>
        public virtual bool? DisablePackageRepositoryOptimizations { get; internal set; }
        /// <summary>
        ///   Display auditing information for a package.
        /// </summary>
        public virtual bool? ShowAuditInformation { get; internal set; }
        /// <summary>
        ///   Used with authenticated feeds. Defaults to empty.
        /// </summary>
        public virtual string User { get; internal set; }
        /// <summary>
        ///   The user's password to the source. Defaults to empty.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   PFX pathname for an x509 authenticated feeds. Defaults to empty.
        /// </summary>
        public virtual string ClientCertificate { get; internal set; }
        /// <summary>
        ///   The client certificate's password to the source. Defaults to empty.
        /// </summary>
        public virtual string CertificatePassword { get; internal set; }
        /// <summary>
        ///   Show debug messaging.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.
        /// </summary>
        public virtual bool? Trace { get; internal set; }
        /// <summary>
        ///   Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Accept license dialogs automatically. Reserved for future use.
        /// </summary>
        public virtual bool? AcceptLicense { get; internal set; }
        /// <summary>
        ///   Chooses affirmative answer instead of prompting. Implies --accept-license
        /// </summary>
        public virtual bool? Confirm { get; internal set; }
        /// <summary>
        ///   Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Limit the output to essential information
        /// </summary>
        public virtual bool? LimitOutput { get; internal set; }
        /// <summary>
        ///   The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.
        /// </summary>
        public virtual int? CommandExecutionTimeout { get; internal set; }
        /// <summary>
        ///   Location for download cache, defaults to %TEMP% or value in chocolatey.config file.
        /// </summary>
        public virtual string CacheLocation { get; internal set; }
        /// <summary>
        ///   When not using the official build you must set this flag for choco to continue.
        /// </summary>
        public virtual bool? AllowUnofficialBuild { get; internal set; }
        /// <summary>
        ///   Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.
        /// </summary>
        public virtual bool? FailOnStandardError { get; internal set; }
        /// <summary>
        ///   Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.
        /// </summary>
        public virtual bool? UseSystemPowerShell { get; internal set; }
        /// <summary>
        ///   Do not show download progress percentages.
        /// </summary>
        public virtual bool? DoNotShowProgress { get; internal set; }
        /// <summary>
        ///   Explicit proxy location. Overrides the default proxy location of ''.
        /// </summary>
        public virtual string Proxy { get; internal set; }
        /// <summary>
        ///   Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.
        /// </summary>
        public virtual string ProxyUserName { get; internal set; }
        /// <summary>
        ///   Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).
        /// </summary>
        public virtual string ProxyPassword { get; internal set; }
        /// <summary>
        ///   Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).
        /// </summary>
        public virtual IReadOnlyList<string> ProxyBypassList => ProxyBypassListInternal.AsReadOnly();
        internal List<string> ProxyBypassListInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).
        /// </summary>
        public virtual bool? ProxyBypassOnLocal { get; internal set; }
        /// <summary>
        ///   Log File to output to in addition to regular loggers.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("find")
              .Add("{value}", Filter)
              .Add("--source={value}", Source)
              .Add("--local-only", LocalOnly)
              .Add("--id-only", IdOnly)
              .Add("--prerelease", Prerelease)
              .Add("--include-programs", IncludePrograms)
              .Add("--all-versions", AllVersions)
              .Add("--version={value}", Version)
              .Add("--page={value}", Page)
              .Add("--page-size={value}", PageSize)
              .Add("--exact", Exact)
              .Add("--by-id-only", ByIdOnly)
              .Add("--by-tag-only", ByTagOnly)
              .Add("--id-starts-with", IdStartsWith)
              .Add("--order-by-popularity", OrderByPopularity)
              .Add("--approved-only", ApprovedOnly)
              .Add("--download-cache-only", DownloadCacheAvailable)
              .Add("--not-broken", NotBroken)
              .Add("--detailed", Detailed)
              .Add("--disable-package-repository-optimizations", DisablePackageRepositoryOptimizations)
              .Add("--show-audit-info", ShowAuditInformation)
              .Add("--user={value}", User)
              .Add("--password={value}", Password, secret: true)
              .Add("--cert={value}", ClientCertificate)
              .Add("--certpassword={value}", CertificatePassword, secret: true)
              .Add("--debug", Debug)
              .Add("--verbose", Verbose)
              .Add("--trace", Trace)
              .Add("--no-color", NoColor)
              .Add("--accept-license", AcceptLicense)
              .Add("--confirm", Confirm)
              .Add("--force", Force)
              .Add("--limit-output", LimitOutput)
              .Add("--execution-timeout={value}", CommandExecutionTimeout)
              .Add("--cache-location {value}", CacheLocation)
              .Add("--allow-unofficial-build", AllowUnofficialBuild)
              .Add("--fail-on-standard-error", FailOnStandardError)
              .Add("--use-system-powershell", UseSystemPowerShell)
              .Add("--no-progress", DoNotShowProgress)
              .Add("--proxy={value}", Proxy)
              .Add("--proxy-user={value}", ProxyUserName)
              .Add("--proxy-password={value}", ProxyPassword, secret: true)
              .Add("--proxy-bypass-list={value}", ProxyBypassList, separator: ',')
              .Add("--proxy-bypass-on-local", ProxyBypassOnLocal)
              .Add("--log-file={value}", LogFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region ChocolateyOutdatedSettings
    /// <summary>
    ///   Used within <see cref="ChocolateyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class ChocolateyOutdatedSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Chocolatey executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? ChocolateyTasks.ChocolateyPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? ChocolateyTasks.ChocolateyLogger;
        /// <summary>
        ///   The source to find the package(s) to install. Special sources include: ruby, webpi, cygwin, windowsfeatures, and python. To specify more than one source, pass it with a semi-colon separating the values (-e.g. "'source1;source2'"). Defaults to default feeds.
        /// </summary>
        public virtual string Source { get; internal set; }
        /// <summary>
        ///   Include Prereleases? Defaults to false.
        /// </summary>
        public virtual bool? Prerelease { get; internal set; }
        /// <summary>
        ///   Ignore pinned packages. Defaults to false.
        /// </summary>
        public virtual bool? IgnorePinned { get; internal set; }
        /// <summary>
        ///   Ignore packages that are not found on the sources used (or the defaults). Overrides the default feature 'ignoreUnfoundPackagesOnUpgradeOutdated' set to 'False'.
        /// </summary>
        public virtual bool? IgnoreUnfound { get; internal set; }
        /// <summary>
        ///   Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.
        /// </summary>
        public virtual bool? DisablePackageRepositoryOptimizations { get; internal set; }
        /// <summary>
        ///   Used with authenticated feeds. Defaults to empty.
        /// </summary>
        public virtual string User { get; internal set; }
        /// <summary>
        ///   The user's password to the source. Defaults to empty.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   PFX pathname for an x509 authenticated feeds. Defaults to empty.
        /// </summary>
        public virtual string ClientCertificate { get; internal set; }
        /// <summary>
        ///   The client certificate's password to the source. Defaults to empty.
        /// </summary>
        public virtual string CertificatePassword { get; internal set; }
        /// <summary>
        ///   Show debug messaging.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.
        /// </summary>
        public virtual bool? Trace { get; internal set; }
        /// <summary>
        ///   Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Accept license dialogs automatically. Reserved for future use.
        /// </summary>
        public virtual bool? AcceptLicense { get; internal set; }
        /// <summary>
        ///   Chooses affirmative answer instead of prompting. Implies --accept-license
        /// </summary>
        public virtual bool? Confirm { get; internal set; }
        /// <summary>
        ///   Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Limit the output to essential information
        /// </summary>
        public virtual bool? LimitOutput { get; internal set; }
        /// <summary>
        ///   The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.
        /// </summary>
        public virtual int? CommandExecutionTimeout { get; internal set; }
        /// <summary>
        ///   Location for download cache, defaults to %TEMP% or value in chocolatey.config file.
        /// </summary>
        public virtual string CacheLocation { get; internal set; }
        /// <summary>
        ///   When not using the official build you must set this flag for choco to continue.
        /// </summary>
        public virtual bool? AllowUnofficialBuild { get; internal set; }
        /// <summary>
        ///   Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.
        /// </summary>
        public virtual bool? FailOnStandardError { get; internal set; }
        /// <summary>
        ///   Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.
        /// </summary>
        public virtual bool? UseSystemPowerShell { get; internal set; }
        /// <summary>
        ///   Do not show download progress percentages.
        /// </summary>
        public virtual bool? DoNotShowProgress { get; internal set; }
        /// <summary>
        ///   Explicit proxy location. Overrides the default proxy location of ''.
        /// </summary>
        public virtual string Proxy { get; internal set; }
        /// <summary>
        ///   Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.
        /// </summary>
        public virtual string ProxyUserName { get; internal set; }
        /// <summary>
        ///   Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).
        /// </summary>
        public virtual string ProxyPassword { get; internal set; }
        /// <summary>
        ///   Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).
        /// </summary>
        public virtual IReadOnlyList<string> ProxyBypassList => ProxyBypassListInternal.AsReadOnly();
        internal List<string> ProxyBypassListInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).
        /// </summary>
        public virtual bool? ProxyBypassOnLocal { get; internal set; }
        /// <summary>
        ///   Log File to output to in addition to regular loggers.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("outdated")
              .Add("--source={value}", Source)
              .Add("--prerelease", Prerelease)
              .Add("--ignore-pinned", IgnorePinned)
              .Add("--ignore-unfound", IgnoreUnfound)
              .Add("--disable-package-repository-optimizations", DisablePackageRepositoryOptimizations)
              .Add("--user={value}", User)
              .Add("--password={value}", Password, secret: true)
              .Add("--cert={value}", ClientCertificate)
              .Add("--certpassword={value}", CertificatePassword, secret: true)
              .Add("--debug", Debug)
              .Add("--verbose", Verbose)
              .Add("--trace", Trace)
              .Add("--no-color", NoColor)
              .Add("--accept-license", AcceptLicense)
              .Add("--confirm", Confirm)
              .Add("--force", Force)
              .Add("--limit-output", LimitOutput)
              .Add("--execution-timeout={value}", CommandExecutionTimeout)
              .Add("--cache-location {value}", CacheLocation)
              .Add("--allow-unofficial-build", AllowUnofficialBuild)
              .Add("--fail-on-standard-error", FailOnStandardError)
              .Add("--use-system-powershell", UseSystemPowerShell)
              .Add("--no-progress", DoNotShowProgress)
              .Add("--proxy={value}", Proxy)
              .Add("--proxy-user={value}", ProxyUserName)
              .Add("--proxy-password={value}", ProxyPassword, secret: true)
              .Add("--proxy-bypass-list={value}", ProxyBypassList, separator: ',')
              .Add("--proxy-bypass-on-local", ProxyBypassOnLocal)
              .Add("--log-file={value}", LogFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region ChocolateyPackSettings
    /// <summary>
    ///   Used within <see cref="ChocolateyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class ChocolateyPackSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Chocolatey executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? ChocolateyTasks.ChocolateyPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? ChocolateyTasks.ChocolateyLogger;
        /// <summary>
        ///   Path to nuspec
        /// </summary>
        public virtual string PathToNuspec { get; internal set; }
        /// <summary>
        ///   The version you would like to insert into the package.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   Specifies the directory for the created Chocolatey package file. If not specified, uses the current directory.
        /// </summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary>
        ///   Show debug messaging.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.
        /// </summary>
        public virtual bool? Trace { get; internal set; }
        /// <summary>
        ///   Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Accept license dialogs automatically. Reserved for future use.
        /// </summary>
        public virtual bool? AcceptLicense { get; internal set; }
        /// <summary>
        ///   Chooses affirmative answer instead of prompting. Implies --accept-license
        /// </summary>
        public virtual bool? Confirm { get; internal set; }
        /// <summary>
        ///   Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Limit the output to essential information
        /// </summary>
        public virtual bool? LimitOutput { get; internal set; }
        /// <summary>
        ///   The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.
        /// </summary>
        public virtual int? CommandExecutionTimeout { get; internal set; }
        /// <summary>
        ///   Location for download cache, defaults to %TEMP% or value in chocolatey.config file.
        /// </summary>
        public virtual string CacheLocation { get; internal set; }
        /// <summary>
        ///   When not using the official build you must set this flag for choco to continue.
        /// </summary>
        public virtual bool? AllowUnofficialBuild { get; internal set; }
        /// <summary>
        ///   Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.
        /// </summary>
        public virtual bool? FailOnStandardError { get; internal set; }
        /// <summary>
        ///   Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.
        /// </summary>
        public virtual bool? UseSystemPowerShell { get; internal set; }
        /// <summary>
        ///   Do not show download progress percentages.
        /// </summary>
        public virtual bool? DoNotShowProgress { get; internal set; }
        /// <summary>
        ///   Explicit proxy location. Overrides the default proxy location of ''.
        /// </summary>
        public virtual string Proxy { get; internal set; }
        /// <summary>
        ///   Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.
        /// </summary>
        public virtual string ProxyUserName { get; internal set; }
        /// <summary>
        ///   Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).
        /// </summary>
        public virtual string ProxyPassword { get; internal set; }
        /// <summary>
        ///   Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).
        /// </summary>
        public virtual IReadOnlyList<string> ProxyBypassList => ProxyBypassListInternal.AsReadOnly();
        internal List<string> ProxyBypassListInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).
        /// </summary>
        public virtual bool? ProxyBypassOnLocal { get; internal set; }
        /// <summary>
        ///   Log File to output to in addition to regular loggers.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        /// <summary>
        ///   You can pass arbitrary property value pairs through to nuspecs. These will replace variables formatted as <em>$property$</em> with the value passed.
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, object> PropertiesInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("pack")
              .Add("{value}", PathToNuspec)
              .Add("--version={value}", Version)
              .Add("--output-directory={value}", OutputDirectory)
              .Add("--debug", Debug)
              .Add("--verbose", Verbose)
              .Add("--trace", Trace)
              .Add("--no-color", NoColor)
              .Add("--accept-license", AcceptLicense)
              .Add("--confirm", Confirm)
              .Add("--force", Force)
              .Add("--limit-output", LimitOutput)
              .Add("--execution-timeout={value}", CommandExecutionTimeout)
              .Add("--cache-location {value}", CacheLocation)
              .Add("--allow-unofficial-build", AllowUnofficialBuild)
              .Add("--fail-on-standard-error", FailOnStandardError)
              .Add("--use-system-powershell", UseSystemPowerShell)
              .Add("--no-progress", DoNotShowProgress)
              .Add("--proxy={value}", Proxy)
              .Add("--proxy-user={value}", ProxyUserName)
              .Add("--proxy-password={value}", ProxyPassword, secret: true)
              .Add("--proxy-bypass-list={value}", ProxyBypassList, separator: ',')
              .Add("--proxy-bypass-on-local", ProxyBypassOnLocal)
              .Add("--log-file={value}", LogFile)
              .Add("-- {value}", Properties, "{key}={value}", separator: ' ');
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region ChocolateyPushSettings
    /// <summary>
    ///   Used within <see cref="ChocolateyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class ChocolateyPushSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Chocolatey executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? ChocolateyTasks.ChocolateyPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? ChocolateyTasks.ChocolateyLogger;
        /// <summary>
        ///   Path to Nuget package (.nupkg).
        /// </summary>
        public virtual string PathToNuGetPackage { get; internal set; }
        /// <summary>
        ///   The source we are pushing the package to. Use <a href="https://pus-h.chocolatey.org/">https://pus-h.chocolatey.org/</a> to push to <a href="https://comminty.chocolatey.org/packages">community feed</a>.
        /// </summary>
        public virtual string Source { get; internal set; }
        /// <summary>
        ///   The api key for the source. If not specified (and not local file source), does a lookup. If not specified and one is not found for an https source, push will fail.
        /// </summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary>
        ///   The time to allow a package push to occur before timing out. Defaults to execution timeout 2700 seconds.
        /// </summary>
        public virtual int? Timeout { get; internal set; }
        /// <summary>
        ///   Show debug messaging.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.
        /// </summary>
        public virtual bool? Trace { get; internal set; }
        /// <summary>
        ///   Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Accept license dialogs automatically. Reserved for future use.
        /// </summary>
        public virtual bool? AcceptLicense { get; internal set; }
        /// <summary>
        ///   Chooses affirmative answer instead of prompting. Implies --accept-license
        /// </summary>
        public virtual bool? Confirm { get; internal set; }
        /// <summary>
        ///   Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Limit the output to essential information
        /// </summary>
        public virtual bool? LimitOutput { get; internal set; }
        /// <summary>
        ///   The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.
        /// </summary>
        public virtual int? CommandExecutionTimeout { get; internal set; }
        /// <summary>
        ///   Location for download cache, defaults to %TEMP% or value in chocolatey.config file.
        /// </summary>
        public virtual string CacheLocation { get; internal set; }
        /// <summary>
        ///   When not using the official build you must set this flag for choco to continue.
        /// </summary>
        public virtual bool? AllowUnofficialBuild { get; internal set; }
        /// <summary>
        ///   Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.
        /// </summary>
        public virtual bool? FailOnStandardError { get; internal set; }
        /// <summary>
        ///   Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.
        /// </summary>
        public virtual bool? UseSystemPowerShell { get; internal set; }
        /// <summary>
        ///   Do not show download progress percentages.
        /// </summary>
        public virtual bool? DoNotShowProgress { get; internal set; }
        /// <summary>
        ///   Explicit proxy location. Overrides the default proxy location of ''.
        /// </summary>
        public virtual string Proxy { get; internal set; }
        /// <summary>
        ///   Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.
        /// </summary>
        public virtual string ProxyUserName { get; internal set; }
        /// <summary>
        ///   Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).
        /// </summary>
        public virtual string ProxyPassword { get; internal set; }
        /// <summary>
        ///   Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).
        /// </summary>
        public virtual IReadOnlyList<string> ProxyBypassList => ProxyBypassListInternal.AsReadOnly();
        internal List<string> ProxyBypassListInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).
        /// </summary>
        public virtual bool? ProxyBypassOnLocal { get; internal set; }
        /// <summary>
        ///   Log File to output to in addition to regular loggers.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("push")
              .Add("{value}", PathToNuGetPackage)
              .Add("--source={value}", Source)
              .Add("--api-key={value}", ApiKey, secret: true)
              .Add("-t={value}", Timeout)
              .Add("--debug", Debug)
              .Add("--verbose", Verbose)
              .Add("--trace", Trace)
              .Add("--no-color", NoColor)
              .Add("--accept-license", AcceptLicense)
              .Add("--confirm", Confirm)
              .Add("--force", Force)
              .Add("--limit-output", LimitOutput)
              .Add("--execution-timeout={value}", CommandExecutionTimeout)
              .Add("--cache-location {value}", CacheLocation)
              .Add("--allow-unofficial-build", AllowUnofficialBuild)
              .Add("--fail-on-standard-error", FailOnStandardError)
              .Add("--use-system-powershell", UseSystemPowerShell)
              .Add("--no-progress", DoNotShowProgress)
              .Add("--proxy={value}", Proxy)
              .Add("--proxy-user={value}", ProxyUserName)
              .Add("--proxy-password={value}", ProxyPassword, secret: true)
              .Add("--proxy-bypass-list={value}", ProxyBypassList, separator: ',')
              .Add("--proxy-bypass-on-local", ProxyBypassOnLocal)
              .Add("--log-file={value}", LogFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region ChocolateyNewSettings
    /// <summary>
    ///   Used within <see cref="ChocolateyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class ChocolateyNewSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Chocolatey executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? ChocolateyTasks.ChocolateyPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? ChocolateyTasks.ChocolateyLogger;
        /// <summary>
        ///   Generate automatic package instead of normal. Defaults to false.
        /// </summary>
        public virtual bool? AutomaticPackage { get; internal set; }
        /// <summary>
        ///   Use a named template in <em>C:\ProgramData\chocolatey\templates\templatename</em> instead of built-in template.
        /// </summary>
        public virtual string TemplateName { get; internal set; }
        /// <summary>
        ///   The required name of the package.
        /// </summary>
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   The version of the package.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   The name of the maintainer.
        /// </summary>
        public virtual string Maintainer { get; internal set; }
        /// <summary>
        ///   Specifies the directory for the created Chocolatey package file. If not specified, uses the current directory.
        /// </summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary>
        ///   Use the original built-in template instead of any override.
        /// </summary>
        public virtual bool? BuildInTemplate { get; internal set; }
        /// <summary>
        ///   In <a href="https://chocolatey.org/compare">Chocolatey for Business</a>, file is used for auto-detection (native installer, zip, patch/upgrade file, or remote url to download first) to completely create a package with proper silent arguments! Can be 32-bit or 64-bit architecture.
        /// </summary>
        public virtual string LocationOfBinary { get; internal set; }
        /// <summary>
        ///   Used when specifying both a 32-bit and a 64-bit file. Can be an installer or a zip, or remote url to download.
        /// </summary>
        public virtual string LocationOfBinary64 { get; internal set; }
        /// <summary>
        ///   When using file or url, use the original location in packaging.
        /// </summary>
        public virtual bool? UseOriginalFilesLocation { get; internal set; }
        /// <summary>
        ///   Checksum to verify File/Url with. Defaults to empty.
        /// </summary>
        public virtual string Checksum { get; internal set; }
        /// <summary>
        ///   Checksum to verify File64/Url64 with. Defaults to empty.
        /// </summary>
        public virtual string Checksum64 { get; internal set; }
        /// <summary>
        ///   checksum type for File/Url (and optional separate 64-bit files when specifying both). Used in conjunction with Download Checksum and Download Checksum 64-bit. Available values are 'md5', 'sha1', 'sha256' or 'sha512'. Defaults to 'sha256'.
        /// </summary>
        public virtual string ChecksumType { get; internal set; }
        /// <summary>
        ///   Pause when there is an error with creating the package.
        /// </summary>
        public virtual bool? PauseOnError { get; internal set; }
        /// <summary>
        ///   Attempt to compile the package after creating it.
        /// </summary>
        public virtual bool? BuildPackage { get; internal set; }
        /// <summary>
        ///   Generate packages from the installed software on a system (does not handle dependencies).
        /// </summary>
        public virtual bool? GenerateFromInstalledSoftware { get; internal set; }
        /// <summary>
        ///   Generate the package for community use.
        /// </summary>
        public virtual bool? GenerateForCommunity { get; internal set; }
        /// <summary>
        ///   Remove x86, x64, 64-bit, etc from the package id. Default setting is to remove architecture.
        /// </summary>
        public virtual bool? RemoveArchitectureFromName { get; internal set; }
        /// <summary>
        ///   Leave x86, x64, 64-bit, etc as part of the package id. Default setting is to remove architecture.
        /// </summary>
        public virtual bool? IncludeArchitectureInName { get; internal set; }
        /// <summary>
        ///   Show debug messaging.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.
        /// </summary>
        public virtual bool? Trace { get; internal set; }
        /// <summary>
        ///   Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Accept license dialogs automatically. Reserved for future use.
        /// </summary>
        public virtual bool? AcceptLicense { get; internal set; }
        /// <summary>
        ///   Chooses affirmative answer instead of prompting. Implies --accept-license
        /// </summary>
        public virtual bool? Confirm { get; internal set; }
        /// <summary>
        ///   Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Limit the output to essential information
        /// </summary>
        public virtual bool? LimitOutput { get; internal set; }
        /// <summary>
        ///   The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.
        /// </summary>
        public virtual int? CommandExecutionTimeout { get; internal set; }
        /// <summary>
        ///   Location for download cache, defaults to %TEMP% or value in chocolatey.config file.
        /// </summary>
        public virtual string CacheLocation { get; internal set; }
        /// <summary>
        ///   When not using the official build you must set this flag for choco to continue.
        /// </summary>
        public virtual bool? AllowUnofficialBuild { get; internal set; }
        /// <summary>
        ///   Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.
        /// </summary>
        public virtual bool? FailOnStandardError { get; internal set; }
        /// <summary>
        ///   Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.
        /// </summary>
        public virtual bool? UseSystemPowerShell { get; internal set; }
        /// <summary>
        ///   Do not show download progress percentages.
        /// </summary>
        public virtual bool? DoNotShowProgress { get; internal set; }
        /// <summary>
        ///   Explicit proxy location. Overrides the default proxy location of ''.
        /// </summary>
        public virtual string Proxy { get; internal set; }
        /// <summary>
        ///   Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.
        /// </summary>
        public virtual string ProxyUserName { get; internal set; }
        /// <summary>
        ///   Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).
        /// </summary>
        public virtual string ProxyPassword { get; internal set; }
        /// <summary>
        ///   Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).
        /// </summary>
        public virtual IReadOnlyList<string> ProxyBypassList => ProxyBypassListInternal.AsReadOnly();
        internal List<string> ProxyBypassListInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).
        /// </summary>
        public virtual bool? ProxyBypassOnLocal { get; internal set; }
        /// <summary>
        ///   Log File to output to in addition to regular loggers.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        /// <summary>
        ///   You can pass arbitrary property value pairs through to templates. This really unlocks your ability to create packages automatically!
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, object> PropertiesInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("new")
              .Add("--automaticpackage", AutomaticPackage)
              .Add("--template-name={value}", TemplateName)
              .Add("--name={value}", Name)
              .Add("--version={value}", Version)
              .Add("--maintainer={value}", Maintainer)
              .Add("--output-directory={value}", OutputDirectory)
              .Add("--use-built-in-template", BuildInTemplate)
              .Add("--file={value}", LocationOfBinary)
              .Add("--file64={value}", LocationOfBinary64)
              .Add("--use-original-files-location", UseOriginalFilesLocation)
              .Add("--checksum={value}", Checksum)
              .Add("--checksum-x64={value}", Checksum64)
              .Add("--checksum-type={value}", ChecksumType)
              .Add("--pause-on-error", PauseOnError)
              .Add("--build-package", BuildPackage)
              .Add("--from-programs-and-features", GenerateFromInstalledSoftware)
              .Add("--generate-for-community", GenerateForCommunity)
              .Add("--remove-architecture-from-name", RemoveArchitectureFromName)
              .Add("--include-architecture-in-name", IncludeArchitectureInName)
              .Add("--debug", Debug)
              .Add("--verbose", Verbose)
              .Add("--trace", Trace)
              .Add("--no-color", NoColor)
              .Add("--accept-license", AcceptLicense)
              .Add("--confirm", Confirm)
              .Add("--force", Force)
              .Add("--limit-output", LimitOutput)
              .Add("--execution-timeout={value}", CommandExecutionTimeout)
              .Add("--cache-location {value}", CacheLocation)
              .Add("--allow-unofficial-build", AllowUnofficialBuild)
              .Add("--fail-on-standard-error", FailOnStandardError)
              .Add("--use-system-powershell", UseSystemPowerShell)
              .Add("--no-progress", DoNotShowProgress)
              .Add("--proxy={value}", Proxy)
              .Add("--proxy-user={value}", ProxyUserName)
              .Add("--proxy-password={value}", ProxyPassword, secret: true)
              .Add("--proxy-bypass-list={value}", ProxyBypassList, separator: ',')
              .Add("--proxy-bypass-on-local", ProxyBypassOnLocal)
              .Add("--log-file={value}", LogFile)
              .Add("-- {value}", Properties, "{key}={value}", separator: ' ');
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region ChocolateySearchSettingsExtensions
    /// <summary>
    ///   Used within <see cref="ChocolateyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class ChocolateySearchSettingsExtensions
    {
        #region Filter
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.Filter"/></em></p>
        ///   <p>Search filter.</p>
        /// </summary>
        [Pure]
        public static T SetFilter<T>(this T toolSettings, string filter) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = filter;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.Filter"/></em></p>
        ///   <p>Search filter.</p>
        /// </summary>
        [Pure]
        public static T ResetFilter<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.Source"/></em></p>
        ///   <p>Source location for install. Can use special 'webpi' or 'windowsfeatures' sources. Defaults to sources.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, string source) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.Source"/></em></p>
        ///   <p>Source location for install. Can use special 'webpi' or 'windowsfeatures' sources. Defaults to sources.</p>
        /// </summary>
        [Pure]
        public static T ResetSource<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region LocalOnly
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.LocalOnly"/></em></p>
        ///   <p>Only search against local machine items.</p>
        /// </summary>
        [Pure]
        public static T SetLocalOnly<T>(this T toolSettings, bool? localOnly) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocalOnly = localOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.LocalOnly"/></em></p>
        ///   <p>Only search against local machine items.</p>
        /// </summary>
        [Pure]
        public static T ResetLocalOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocalOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.LocalOnly"/></em></p>
        ///   <p>Only search against local machine items.</p>
        /// </summary>
        [Pure]
        public static T EnableLocalOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocalOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.LocalOnly"/></em></p>
        ///   <p>Only search against local machine items.</p>
        /// </summary>
        [Pure]
        public static T DisableLocalOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocalOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.LocalOnly"/></em></p>
        ///   <p>Only search against local machine items.</p>
        /// </summary>
        [Pure]
        public static T ToggleLocalOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocalOnly = !toolSettings.LocalOnly;
            return toolSettings;
        }
        #endregion
        #region IdOnly
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.IdOnly"/></em></p>
        ///   <p>Only return Package Ids in the list results.</p>
        /// </summary>
        [Pure]
        public static T SetIdOnly<T>(this T toolSettings, bool? idOnly) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdOnly = idOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.IdOnly"/></em></p>
        ///   <p>Only return Package Ids in the list results.</p>
        /// </summary>
        [Pure]
        public static T ResetIdOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.IdOnly"/></em></p>
        ///   <p>Only return Package Ids in the list results.</p>
        /// </summary>
        [Pure]
        public static T EnableIdOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.IdOnly"/></em></p>
        ///   <p>Only return Package Ids in the list results.</p>
        /// </summary>
        [Pure]
        public static T DisableIdOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.IdOnly"/></em></p>
        ///   <p>Only return Package Ids in the list results.</p>
        /// </summary>
        [Pure]
        public static T ToggleIdOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdOnly = !toolSettings.IdOnly;
            return toolSettings;
        }
        #endregion
        #region Prerelease
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T SetPrerelease<T>(this T toolSettings, bool? prerelease) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = prerelease;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T ResetPrerelease<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T EnablePrerelease<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T DisablePrerelease<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T TogglePrerelease<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = !toolSettings.Prerelease;
            return toolSettings;
        }
        #endregion
        #region IncludePrograms
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.IncludePrograms"/></em></p>
        ///   <p>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T SetIncludePrograms<T>(this T toolSettings, bool? includePrograms) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludePrograms = includePrograms;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.IncludePrograms"/></em></p>
        ///   <p>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T ResetIncludePrograms<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludePrograms = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.IncludePrograms"/></em></p>
        ///   <p>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T EnableIncludePrograms<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludePrograms = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.IncludePrograms"/></em></p>
        ///   <p>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T DisableIncludePrograms<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludePrograms = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.IncludePrograms"/></em></p>
        ///   <p>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T ToggleIncludePrograms<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludePrograms = !toolSettings.IncludePrograms;
            return toolSettings;
        }
        #endregion
        #region AllVersions
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.AllVersions"/></em></p>
        ///   <p>Include results from all versions.</p>
        /// </summary>
        [Pure]
        public static T SetAllVersions<T>(this T toolSettings, bool? allVersions) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVersions = allVersions;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.AllVersions"/></em></p>
        ///   <p>Include results from all versions.</p>
        /// </summary>
        [Pure]
        public static T ResetAllVersions<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVersions = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.AllVersions"/></em></p>
        ///   <p>Include results from all versions.</p>
        /// </summary>
        [Pure]
        public static T EnableAllVersions<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVersions = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.AllVersions"/></em></p>
        ///   <p>Include results from all versions.</p>
        /// </summary>
        [Pure]
        public static T DisableAllVersions<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVersions = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.AllVersions"/></em></p>
        ///   <p>Include results from all versions.</p>
        /// </summary>
        [Pure]
        public static T ToggleAllVersions<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVersions = !toolSettings.AllVersions;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.Version"/></em></p>
        ///   <p>Specific version of a package to return.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.Version"/></em></p>
        ///   <p>Specific version of a package to return.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Page
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.Page"/></em></p>
        ///   <p>The 'page' of results to return. Defaults to return all results.</p>
        /// </summary>
        [Pure]
        public static T SetPage<T>(this T toolSettings, int? page) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Page = page;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.Page"/></em></p>
        ///   <p>The 'page' of results to return. Defaults to return all results.</p>
        /// </summary>
        [Pure]
        public static T ResetPage<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Page = null;
            return toolSettings;
        }
        #endregion
        #region PageSize
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.PageSize"/></em></p>
        ///   <p>The amount of package results to return per page. Defaults to 25.</p>
        /// </summary>
        [Pure]
        public static T SetPageSize<T>(this T toolSettings, int? pageSize) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageSize = pageSize;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.PageSize"/></em></p>
        ///   <p>The amount of package results to return per page. Defaults to 25.</p>
        /// </summary>
        [Pure]
        public static T ResetPageSize<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageSize = null;
            return toolSettings;
        }
        #endregion
        #region Exact
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.Exact"/></em></p>
        ///   <p>Only return packages with this exact name.</p>
        /// </summary>
        [Pure]
        public static T SetExact<T>(this T toolSettings, bool? exact) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exact = exact;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.Exact"/></em></p>
        ///   <p>Only return packages with this exact name.</p>
        /// </summary>
        [Pure]
        public static T ResetExact<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exact = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.Exact"/></em></p>
        ///   <p>Only return packages with this exact name.</p>
        /// </summary>
        [Pure]
        public static T EnableExact<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exact = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.Exact"/></em></p>
        ///   <p>Only return packages with this exact name.</p>
        /// </summary>
        [Pure]
        public static T DisableExact<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exact = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.Exact"/></em></p>
        ///   <p>Only return packages with this exact name.</p>
        /// </summary>
        [Pure]
        public static T ToggleExact<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exact = !toolSettings.Exact;
            return toolSettings;
        }
        #endregion
        #region ByIdOnly
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.ByIdOnly"/></em></p>
        ///   <p>Only return packages where the id contains the search filter.</p>
        /// </summary>
        [Pure]
        public static T SetByIdOnly<T>(this T toolSettings, bool? byIdOnly) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByIdOnly = byIdOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.ByIdOnly"/></em></p>
        ///   <p>Only return packages where the id contains the search filter.</p>
        /// </summary>
        [Pure]
        public static T ResetByIdOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByIdOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.ByIdOnly"/></em></p>
        ///   <p>Only return packages where the id contains the search filter.</p>
        /// </summary>
        [Pure]
        public static T EnableByIdOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByIdOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.ByIdOnly"/></em></p>
        ///   <p>Only return packages where the id contains the search filter.</p>
        /// </summary>
        [Pure]
        public static T DisableByIdOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByIdOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.ByIdOnly"/></em></p>
        ///   <p>Only return packages where the id contains the search filter.</p>
        /// </summary>
        [Pure]
        public static T ToggleByIdOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByIdOnly = !toolSettings.ByIdOnly;
            return toolSettings;
        }
        #endregion
        #region ByTagOnly
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.ByTagOnly"/></em></p>
        ///   <p>Only return packages where the search filter matches on the tags.</p>
        /// </summary>
        [Pure]
        public static T SetByTagOnly<T>(this T toolSettings, bool? byTagOnly) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByTagOnly = byTagOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.ByTagOnly"/></em></p>
        ///   <p>Only return packages where the search filter matches on the tags.</p>
        /// </summary>
        [Pure]
        public static T ResetByTagOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByTagOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.ByTagOnly"/></em></p>
        ///   <p>Only return packages where the search filter matches on the tags.</p>
        /// </summary>
        [Pure]
        public static T EnableByTagOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByTagOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.ByTagOnly"/></em></p>
        ///   <p>Only return packages where the search filter matches on the tags.</p>
        /// </summary>
        [Pure]
        public static T DisableByTagOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByTagOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.ByTagOnly"/></em></p>
        ///   <p>Only return packages where the search filter matches on the tags.</p>
        /// </summary>
        [Pure]
        public static T ToggleByTagOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByTagOnly = !toolSettings.ByTagOnly;
            return toolSettings;
        }
        #endregion
        #region IdStartsWith
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.IdStartsWith"/></em></p>
        ///   <p>Only return packages where the id starts with the search filter.</p>
        /// </summary>
        [Pure]
        public static T SetIdStartsWith<T>(this T toolSettings, bool? idStartsWith) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdStartsWith = idStartsWith;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.IdStartsWith"/></em></p>
        ///   <p>Only return packages where the id starts with the search filter.</p>
        /// </summary>
        [Pure]
        public static T ResetIdStartsWith<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdStartsWith = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.IdStartsWith"/></em></p>
        ///   <p>Only return packages where the id starts with the search filter.</p>
        /// </summary>
        [Pure]
        public static T EnableIdStartsWith<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdStartsWith = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.IdStartsWith"/></em></p>
        ///   <p>Only return packages where the id starts with the search filter.</p>
        /// </summary>
        [Pure]
        public static T DisableIdStartsWith<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdStartsWith = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.IdStartsWith"/></em></p>
        ///   <p>Only return packages where the id starts with the search filter.</p>
        /// </summary>
        [Pure]
        public static T ToggleIdStartsWith<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdStartsWith = !toolSettings.IdStartsWith;
            return toolSettings;
        }
        #endregion
        #region OrderByPopularity
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.OrderByPopularity"/></em></p>
        ///   <p>Sort by package results by popularity.</p>
        /// </summary>
        [Pure]
        public static T SetOrderByPopularity<T>(this T toolSettings, bool? orderByPopularity) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OrderByPopularity = orderByPopularity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.OrderByPopularity"/></em></p>
        ///   <p>Sort by package results by popularity.</p>
        /// </summary>
        [Pure]
        public static T ResetOrderByPopularity<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OrderByPopularity = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.OrderByPopularity"/></em></p>
        ///   <p>Sort by package results by popularity.</p>
        /// </summary>
        [Pure]
        public static T EnableOrderByPopularity<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OrderByPopularity = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.OrderByPopularity"/></em></p>
        ///   <p>Sort by package results by popularity.</p>
        /// </summary>
        [Pure]
        public static T DisableOrderByPopularity<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OrderByPopularity = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.OrderByPopularity"/></em></p>
        ///   <p>Sort by package results by popularity.</p>
        /// </summary>
        [Pure]
        public static T ToggleOrderByPopularity<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OrderByPopularity = !toolSettings.OrderByPopularity;
            return toolSettings;
        }
        #endregion
        #region ApprovedOnly
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.ApprovedOnly"/></em></p>
        ///   <p>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</p>
        /// </summary>
        [Pure]
        public static T SetApprovedOnly<T>(this T toolSettings, bool? approvedOnly) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApprovedOnly = approvedOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.ApprovedOnly"/></em></p>
        ///   <p>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetApprovedOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApprovedOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.ApprovedOnly"/></em></p>
        ///   <p>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</p>
        /// </summary>
        [Pure]
        public static T EnableApprovedOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApprovedOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.ApprovedOnly"/></em></p>
        ///   <p>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</p>
        /// </summary>
        [Pure]
        public static T DisableApprovedOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApprovedOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.ApprovedOnly"/></em></p>
        ///   <p>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</p>
        /// </summary>
        [Pure]
        public static T ToggleApprovedOnly<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApprovedOnly = !toolSettings.ApprovedOnly;
            return toolSettings;
        }
        #endregion
        #region DownloadCacheAvailable
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.DownloadCacheAvailable"/></em></p>
        ///   <p>Only return packages that have a download cache available - this option will filter out results not from the community repository.</p>
        /// </summary>
        [Pure]
        public static T SetDownloadCacheAvailable<T>(this T toolSettings, bool? downloadCacheAvailable) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DownloadCacheAvailable = downloadCacheAvailable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.DownloadCacheAvailable"/></em></p>
        ///   <p>Only return packages that have a download cache available - this option will filter out results not from the community repository.</p>
        /// </summary>
        [Pure]
        public static T ResetDownloadCacheAvailable<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DownloadCacheAvailable = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.DownloadCacheAvailable"/></em></p>
        ///   <p>Only return packages that have a download cache available - this option will filter out results not from the community repository.</p>
        /// </summary>
        [Pure]
        public static T EnableDownloadCacheAvailable<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DownloadCacheAvailable = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.DownloadCacheAvailable"/></em></p>
        ///   <p>Only return packages that have a download cache available - this option will filter out results not from the community repository.</p>
        /// </summary>
        [Pure]
        public static T DisableDownloadCacheAvailable<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DownloadCacheAvailable = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.DownloadCacheAvailable"/></em></p>
        ///   <p>Only return packages that have a download cache available - this option will filter out results not from the community repository.</p>
        /// </summary>
        [Pure]
        public static T ToggleDownloadCacheAvailable<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DownloadCacheAvailable = !toolSettings.DownloadCacheAvailable;
            return toolSettings;
        }
        #endregion
        #region NotBroken
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.NotBroken"/></em></p>
        ///   <p>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</p>
        /// </summary>
        [Pure]
        public static T SetNotBroken<T>(this T toolSettings, bool? notBroken) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NotBroken = notBroken;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.NotBroken"/></em></p>
        ///   <p>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</p>
        /// </summary>
        [Pure]
        public static T ResetNotBroken<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NotBroken = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.NotBroken"/></em></p>
        ///   <p>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</p>
        /// </summary>
        [Pure]
        public static T EnableNotBroken<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NotBroken = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.NotBroken"/></em></p>
        ///   <p>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</p>
        /// </summary>
        [Pure]
        public static T DisableNotBroken<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NotBroken = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.NotBroken"/></em></p>
        ///   <p>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</p>
        /// </summary>
        [Pure]
        public static T ToggleNotBroken<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NotBroken = !toolSettings.NotBroken;
            return toolSettings;
        }
        #endregion
        #region Detailed
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.Detailed"/></em></p>
        ///   <p>Alias for verbose.</p>
        /// </summary>
        [Pure]
        public static T SetDetailed<T>(this T toolSettings, bool? detailed) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Detailed = detailed;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.Detailed"/></em></p>
        ///   <p>Alias for verbose.</p>
        /// </summary>
        [Pure]
        public static T ResetDetailed<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Detailed = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.Detailed"/></em></p>
        ///   <p>Alias for verbose.</p>
        /// </summary>
        [Pure]
        public static T EnableDetailed<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Detailed = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.Detailed"/></em></p>
        ///   <p>Alias for verbose.</p>
        /// </summary>
        [Pure]
        public static T DisableDetailed<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Detailed = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.Detailed"/></em></p>
        ///   <p>Alias for verbose.</p>
        /// </summary>
        [Pure]
        public static T ToggleDetailed<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Detailed = !toolSettings.Detailed;
            return toolSettings;
        }
        #endregion
        #region DisablePackageRepositoryOptimizations
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T SetDisablePackageRepositoryOptimizations<T>(this T toolSettings, bool? disablePackageRepositoryOptimizations) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = disablePackageRepositoryOptimizations;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T ResetDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T EnableDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T DisableDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = !toolSettings.DisablePackageRepositoryOptimizations;
            return toolSettings;
        }
        #endregion
        #region ShowAuditInformation
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.ShowAuditInformation"/></em></p>
        ///   <p>Display auditing information for a package.</p>
        /// </summary>
        [Pure]
        public static T SetShowAuditInformation<T>(this T toolSettings, bool? showAuditInformation) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowAuditInformation = showAuditInformation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.ShowAuditInformation"/></em></p>
        ///   <p>Display auditing information for a package.</p>
        /// </summary>
        [Pure]
        public static T ResetShowAuditInformation<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowAuditInformation = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.ShowAuditInformation"/></em></p>
        ///   <p>Display auditing information for a package.</p>
        /// </summary>
        [Pure]
        public static T EnableShowAuditInformation<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowAuditInformation = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.ShowAuditInformation"/></em></p>
        ///   <p>Display auditing information for a package.</p>
        /// </summary>
        [Pure]
        public static T DisableShowAuditInformation<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowAuditInformation = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.ShowAuditInformation"/></em></p>
        ///   <p>Display auditing information for a package.</p>
        /// </summary>
        [Pure]
        public static T ToggleShowAuditInformation<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowAuditInformation = !toolSettings.ShowAuditInformation;
            return toolSettings;
        }
        #endregion
        #region User
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.User"/></em></p>
        ///   <p>Used with authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetUser<T>(this T toolSettings, string user) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.User = user;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.User"/></em></p>
        ///   <p>Used with authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetUser<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.User = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.Password"/></em></p>
        ///   <p>The user's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.Password"/></em></p>
        ///   <p>The user's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region ClientCertificate
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.ClientCertificate"/></em></p>
        ///   <p>PFX pathname for an x509 authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetClientCertificate<T>(this T toolSettings, string clientCertificate) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientCertificate = clientCertificate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.ClientCertificate"/></em></p>
        ///   <p>PFX pathname for an x509 authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetClientCertificate<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientCertificate = null;
            return toolSettings;
        }
        #endregion
        #region CertificatePassword
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.CertificatePassword"/></em></p>
        ///   <p>The client certificate's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetCertificatePassword<T>(this T toolSettings, [Secret] string certificatePassword) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertificatePassword = certificatePassword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.CertificatePassword"/></em></p>
        ///   <p>The client certificate's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetCertificatePassword<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertificatePassword = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Trace
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T SetTrace<T>(this T toolSettings, bool? trace) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = trace;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T ResetTrace<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T EnableTrace<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T DisableTrace<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T ToggleTrace<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = !toolSettings.Trace;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T SetNoColor<T>(this T toolSettings, bool? noColor) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T ResetNoColor<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T EnableNoColor<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T DisableNoColor<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoColor<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region AcceptLicense
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T SetAcceptLicense<T>(this T toolSettings, bool? acceptLicense) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = acceptLicense;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T ResetAcceptLicense<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T EnableAcceptLicense<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T DisableAcceptLicense<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T ToggleAcceptLicense<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = !toolSettings.AcceptLicense;
            return toolSettings;
        }
        #endregion
        #region Confirm
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T SetConfirm<T>(this T toolSettings, bool? confirm) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = confirm;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T ResetConfirm<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T EnableConfirm<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T DisableConfirm<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T ToggleConfirm<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = !toolSettings.Confirm;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region LimitOutput
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T SetLimitOutput<T>(this T toolSettings, bool? limitOutput) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = limitOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T ResetLimitOutput<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T EnableLimitOutput<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T DisableLimitOutput<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T ToggleLimitOutput<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = !toolSettings.LimitOutput;
            return toolSettings;
        }
        #endregion
        #region CommandExecutionTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.CommandExecutionTimeout"/></em></p>
        ///   <p>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T SetCommandExecutionTimeout<T>(this T toolSettings, int? commandExecutionTimeout) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommandExecutionTimeout = commandExecutionTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.CommandExecutionTimeout"/></em></p>
        ///   <p>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T ResetCommandExecutionTimeout<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommandExecutionTimeout = null;
            return toolSettings;
        }
        #endregion
        #region CacheLocation
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.CacheLocation"/></em></p>
        ///   <p>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</p>
        /// </summary>
        [Pure]
        public static T SetCacheLocation<T>(this T toolSettings, string cacheLocation) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheLocation = cacheLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.CacheLocation"/></em></p>
        ///   <p>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</p>
        /// </summary>
        [Pure]
        public static T ResetCacheLocation<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheLocation = null;
            return toolSettings;
        }
        #endregion
        #region AllowUnofficialBuild
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T SetAllowUnofficialBuild<T>(this T toolSettings, bool? allowUnofficialBuild) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = allowUnofficialBuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T ResetAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T EnableAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T DisableAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T ToggleAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = !toolSettings.AllowUnofficialBuild;
            return toolSettings;
        }
        #endregion
        #region FailOnStandardError
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T SetFailOnStandardError<T>(this T toolSettings, bool? failOnStandardError) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = failOnStandardError;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T ResetFailOnStandardError<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T EnableFailOnStandardError<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T DisableFailOnStandardError<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T ToggleFailOnStandardError<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = !toolSettings.FailOnStandardError;
            return toolSettings;
        }
        #endregion
        #region UseSystemPowerShell
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T SetUseSystemPowerShell<T>(this T toolSettings, bool? useSystemPowerShell) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = useSystemPowerShell;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T ResetUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T EnableUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T DisableUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T ToggleUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = !toolSettings.UseSystemPowerShell;
            return toolSettings;
        }
        #endregion
        #region DoNotShowProgress
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T SetDoNotShowProgress<T>(this T toolSettings, bool? doNotShowProgress) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = doNotShowProgress;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T ResetDoNotShowProgress<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T EnableDoNotShowProgress<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T DisableDoNotShowProgress<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T ToggleDoNotShowProgress<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = !toolSettings.DoNotShowProgress;
            return toolSettings;
        }
        #endregion
        #region Proxy
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.Proxy"/></em></p>
        ///   <p>Explicit proxy location. Overrides the default proxy location of ''.</p>
        /// </summary>
        [Pure]
        public static T SetProxy<T>(this T toolSettings, string proxy) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = proxy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.Proxy"/></em></p>
        ///   <p>Explicit proxy location. Overrides the default proxy location of ''.</p>
        /// </summary>
        [Pure]
        public static T ResetProxy<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = null;
            return toolSettings;
        }
        #endregion
        #region ProxyUserName
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.ProxyUserName"/></em></p>
        ///   <p>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</p>
        /// </summary>
        [Pure]
        public static T SetProxyUserName<T>(this T toolSettings, string proxyUserName) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUserName = proxyUserName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.ProxyUserName"/></em></p>
        ///   <p>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</p>
        /// </summary>
        [Pure]
        public static T ResetProxyUserName<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUserName = null;
            return toolSettings;
        }
        #endregion
        #region ProxyPassword
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.ProxyPassword"/></em></p>
        ///   <p>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</p>
        /// </summary>
        [Pure]
        public static T SetProxyPassword<T>(this T toolSettings, [Secret] string proxyPassword) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = proxyPassword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.ProxyPassword"/></em></p>
        ///   <p>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</p>
        /// </summary>
        [Pure]
        public static T ResetProxyPassword<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = null;
            return toolSettings;
        }
        #endregion
        #region ProxyBypassList
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.ProxyBypassList"/> to a new list</em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal = proxyBypassList.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.ProxyBypassList"/> to a new list</em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal = proxyBypassList.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ChocolateySearchSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T AddProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.AddRange(proxyBypassList);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ChocolateySearchSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T AddProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.AddRange(proxyBypassList);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ChocolateySearchSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ClearProxyBypassList<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ChocolateySearchSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T RemoveProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(proxyBypassList);
            toolSettings.ProxyBypassListInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ChocolateySearchSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T RemoveProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(proxyBypassList);
            toolSettings.ProxyBypassListInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ProxyBypassOnLocal
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassOnLocal<T>(this T toolSettings, bool? proxyBypassOnLocal) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = proxyBypassOnLocal;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ResetProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateySearchSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T EnableProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateySearchSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T DisableProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateySearchSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ToggleProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = !toolSettings.ProxyBypassOnLocal;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateySearchSettings.LogFile"/></em></p>
        ///   <p>Log File to output to in addition to regular loggers.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateySearchSettings.LogFile"/></em></p>
        ///   <p>Log File to output to in addition to regular loggers.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : ChocolateySearchSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region ChocolateyListSettingsExtensions
    /// <summary>
    ///   Used within <see cref="ChocolateyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class ChocolateyListSettingsExtensions
    {
        #region Filter
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.Filter"/></em></p>
        ///   <p>Search filter.</p>
        /// </summary>
        [Pure]
        public static T SetFilter<T>(this T toolSettings, string filter) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = filter;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.Filter"/></em></p>
        ///   <p>Search filter.</p>
        /// </summary>
        [Pure]
        public static T ResetFilter<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.Source"/></em></p>
        ///   <p>Source location for install. Can use special 'webpi' or 'windowsfeatures' sources. Defaults to sources.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, string source) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.Source"/></em></p>
        ///   <p>Source location for install. Can use special 'webpi' or 'windowsfeatures' sources. Defaults to sources.</p>
        /// </summary>
        [Pure]
        public static T ResetSource<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region LocalOnly
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.LocalOnly"/></em></p>
        ///   <p>Only search against local machine items.</p>
        /// </summary>
        [Pure]
        public static T SetLocalOnly<T>(this T toolSettings, bool? localOnly) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocalOnly = localOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.LocalOnly"/></em></p>
        ///   <p>Only search against local machine items.</p>
        /// </summary>
        [Pure]
        public static T ResetLocalOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocalOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.LocalOnly"/></em></p>
        ///   <p>Only search against local machine items.</p>
        /// </summary>
        [Pure]
        public static T EnableLocalOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocalOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.LocalOnly"/></em></p>
        ///   <p>Only search against local machine items.</p>
        /// </summary>
        [Pure]
        public static T DisableLocalOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocalOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.LocalOnly"/></em></p>
        ///   <p>Only search against local machine items.</p>
        /// </summary>
        [Pure]
        public static T ToggleLocalOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocalOnly = !toolSettings.LocalOnly;
            return toolSettings;
        }
        #endregion
        #region IdOnly
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.IdOnly"/></em></p>
        ///   <p>Only return Package Ids in the list results.</p>
        /// </summary>
        [Pure]
        public static T SetIdOnly<T>(this T toolSettings, bool? idOnly) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdOnly = idOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.IdOnly"/></em></p>
        ///   <p>Only return Package Ids in the list results.</p>
        /// </summary>
        [Pure]
        public static T ResetIdOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.IdOnly"/></em></p>
        ///   <p>Only return Package Ids in the list results.</p>
        /// </summary>
        [Pure]
        public static T EnableIdOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.IdOnly"/></em></p>
        ///   <p>Only return Package Ids in the list results.</p>
        /// </summary>
        [Pure]
        public static T DisableIdOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.IdOnly"/></em></p>
        ///   <p>Only return Package Ids in the list results.</p>
        /// </summary>
        [Pure]
        public static T ToggleIdOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdOnly = !toolSettings.IdOnly;
            return toolSettings;
        }
        #endregion
        #region Prerelease
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T SetPrerelease<T>(this T toolSettings, bool? prerelease) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = prerelease;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T ResetPrerelease<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T EnablePrerelease<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T DisablePrerelease<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T TogglePrerelease<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = !toolSettings.Prerelease;
            return toolSettings;
        }
        #endregion
        #region IncludePrograms
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.IncludePrograms"/></em></p>
        ///   <p>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T SetIncludePrograms<T>(this T toolSettings, bool? includePrograms) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludePrograms = includePrograms;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.IncludePrograms"/></em></p>
        ///   <p>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T ResetIncludePrograms<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludePrograms = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.IncludePrograms"/></em></p>
        ///   <p>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T EnableIncludePrograms<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludePrograms = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.IncludePrograms"/></em></p>
        ///   <p>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T DisableIncludePrograms<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludePrograms = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.IncludePrograms"/></em></p>
        ///   <p>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T ToggleIncludePrograms<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludePrograms = !toolSettings.IncludePrograms;
            return toolSettings;
        }
        #endregion
        #region AllVersions
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.AllVersions"/></em></p>
        ///   <p>Include results from all versions.</p>
        /// </summary>
        [Pure]
        public static T SetAllVersions<T>(this T toolSettings, bool? allVersions) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVersions = allVersions;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.AllVersions"/></em></p>
        ///   <p>Include results from all versions.</p>
        /// </summary>
        [Pure]
        public static T ResetAllVersions<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVersions = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.AllVersions"/></em></p>
        ///   <p>Include results from all versions.</p>
        /// </summary>
        [Pure]
        public static T EnableAllVersions<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVersions = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.AllVersions"/></em></p>
        ///   <p>Include results from all versions.</p>
        /// </summary>
        [Pure]
        public static T DisableAllVersions<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVersions = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.AllVersions"/></em></p>
        ///   <p>Include results from all versions.</p>
        /// </summary>
        [Pure]
        public static T ToggleAllVersions<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVersions = !toolSettings.AllVersions;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.Version"/></em></p>
        ///   <p>Specific version of a package to return.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.Version"/></em></p>
        ///   <p>Specific version of a package to return.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Page
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.Page"/></em></p>
        ///   <p>The 'page' of results to return. Defaults to return all results.</p>
        /// </summary>
        [Pure]
        public static T SetPage<T>(this T toolSettings, int? page) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Page = page;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.Page"/></em></p>
        ///   <p>The 'page' of results to return. Defaults to return all results.</p>
        /// </summary>
        [Pure]
        public static T ResetPage<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Page = null;
            return toolSettings;
        }
        #endregion
        #region PageSize
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.PageSize"/></em></p>
        ///   <p>The amount of package results to return per page. Defaults to 25.</p>
        /// </summary>
        [Pure]
        public static T SetPageSize<T>(this T toolSettings, int? pageSize) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageSize = pageSize;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.PageSize"/></em></p>
        ///   <p>The amount of package results to return per page. Defaults to 25.</p>
        /// </summary>
        [Pure]
        public static T ResetPageSize<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageSize = null;
            return toolSettings;
        }
        #endregion
        #region Exact
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.Exact"/></em></p>
        ///   <p>Only return packages with this exact name.</p>
        /// </summary>
        [Pure]
        public static T SetExact<T>(this T toolSettings, bool? exact) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exact = exact;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.Exact"/></em></p>
        ///   <p>Only return packages with this exact name.</p>
        /// </summary>
        [Pure]
        public static T ResetExact<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exact = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.Exact"/></em></p>
        ///   <p>Only return packages with this exact name.</p>
        /// </summary>
        [Pure]
        public static T EnableExact<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exact = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.Exact"/></em></p>
        ///   <p>Only return packages with this exact name.</p>
        /// </summary>
        [Pure]
        public static T DisableExact<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exact = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.Exact"/></em></p>
        ///   <p>Only return packages with this exact name.</p>
        /// </summary>
        [Pure]
        public static T ToggleExact<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exact = !toolSettings.Exact;
            return toolSettings;
        }
        #endregion
        #region ByIdOnly
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.ByIdOnly"/></em></p>
        ///   <p>Only return packages where the id contains the search filter.</p>
        /// </summary>
        [Pure]
        public static T SetByIdOnly<T>(this T toolSettings, bool? byIdOnly) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByIdOnly = byIdOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.ByIdOnly"/></em></p>
        ///   <p>Only return packages where the id contains the search filter.</p>
        /// </summary>
        [Pure]
        public static T ResetByIdOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByIdOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.ByIdOnly"/></em></p>
        ///   <p>Only return packages where the id contains the search filter.</p>
        /// </summary>
        [Pure]
        public static T EnableByIdOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByIdOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.ByIdOnly"/></em></p>
        ///   <p>Only return packages where the id contains the search filter.</p>
        /// </summary>
        [Pure]
        public static T DisableByIdOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByIdOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.ByIdOnly"/></em></p>
        ///   <p>Only return packages where the id contains the search filter.</p>
        /// </summary>
        [Pure]
        public static T ToggleByIdOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByIdOnly = !toolSettings.ByIdOnly;
            return toolSettings;
        }
        #endregion
        #region ByTagOnly
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.ByTagOnly"/></em></p>
        ///   <p>Only return packages where the search filter matches on the tags.</p>
        /// </summary>
        [Pure]
        public static T SetByTagOnly<T>(this T toolSettings, bool? byTagOnly) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByTagOnly = byTagOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.ByTagOnly"/></em></p>
        ///   <p>Only return packages where the search filter matches on the tags.</p>
        /// </summary>
        [Pure]
        public static T ResetByTagOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByTagOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.ByTagOnly"/></em></p>
        ///   <p>Only return packages where the search filter matches on the tags.</p>
        /// </summary>
        [Pure]
        public static T EnableByTagOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByTagOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.ByTagOnly"/></em></p>
        ///   <p>Only return packages where the search filter matches on the tags.</p>
        /// </summary>
        [Pure]
        public static T DisableByTagOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByTagOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.ByTagOnly"/></em></p>
        ///   <p>Only return packages where the search filter matches on the tags.</p>
        /// </summary>
        [Pure]
        public static T ToggleByTagOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByTagOnly = !toolSettings.ByTagOnly;
            return toolSettings;
        }
        #endregion
        #region IdStartsWith
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.IdStartsWith"/></em></p>
        ///   <p>Only return packages where the id starts with the search filter.</p>
        /// </summary>
        [Pure]
        public static T SetIdStartsWith<T>(this T toolSettings, bool? idStartsWith) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdStartsWith = idStartsWith;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.IdStartsWith"/></em></p>
        ///   <p>Only return packages where the id starts with the search filter.</p>
        /// </summary>
        [Pure]
        public static T ResetIdStartsWith<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdStartsWith = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.IdStartsWith"/></em></p>
        ///   <p>Only return packages where the id starts with the search filter.</p>
        /// </summary>
        [Pure]
        public static T EnableIdStartsWith<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdStartsWith = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.IdStartsWith"/></em></p>
        ///   <p>Only return packages where the id starts with the search filter.</p>
        /// </summary>
        [Pure]
        public static T DisableIdStartsWith<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdStartsWith = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.IdStartsWith"/></em></p>
        ///   <p>Only return packages where the id starts with the search filter.</p>
        /// </summary>
        [Pure]
        public static T ToggleIdStartsWith<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdStartsWith = !toolSettings.IdStartsWith;
            return toolSettings;
        }
        #endregion
        #region OrderByPopularity
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.OrderByPopularity"/></em></p>
        ///   <p>Sort by package results by popularity.</p>
        /// </summary>
        [Pure]
        public static T SetOrderByPopularity<T>(this T toolSettings, bool? orderByPopularity) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OrderByPopularity = orderByPopularity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.OrderByPopularity"/></em></p>
        ///   <p>Sort by package results by popularity.</p>
        /// </summary>
        [Pure]
        public static T ResetOrderByPopularity<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OrderByPopularity = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.OrderByPopularity"/></em></p>
        ///   <p>Sort by package results by popularity.</p>
        /// </summary>
        [Pure]
        public static T EnableOrderByPopularity<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OrderByPopularity = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.OrderByPopularity"/></em></p>
        ///   <p>Sort by package results by popularity.</p>
        /// </summary>
        [Pure]
        public static T DisableOrderByPopularity<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OrderByPopularity = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.OrderByPopularity"/></em></p>
        ///   <p>Sort by package results by popularity.</p>
        /// </summary>
        [Pure]
        public static T ToggleOrderByPopularity<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OrderByPopularity = !toolSettings.OrderByPopularity;
            return toolSettings;
        }
        #endregion
        #region ApprovedOnly
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.ApprovedOnly"/></em></p>
        ///   <p>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</p>
        /// </summary>
        [Pure]
        public static T SetApprovedOnly<T>(this T toolSettings, bool? approvedOnly) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApprovedOnly = approvedOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.ApprovedOnly"/></em></p>
        ///   <p>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetApprovedOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApprovedOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.ApprovedOnly"/></em></p>
        ///   <p>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</p>
        /// </summary>
        [Pure]
        public static T EnableApprovedOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApprovedOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.ApprovedOnly"/></em></p>
        ///   <p>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</p>
        /// </summary>
        [Pure]
        public static T DisableApprovedOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApprovedOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.ApprovedOnly"/></em></p>
        ///   <p>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</p>
        /// </summary>
        [Pure]
        public static T ToggleApprovedOnly<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApprovedOnly = !toolSettings.ApprovedOnly;
            return toolSettings;
        }
        #endregion
        #region DownloadCacheAvailable
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.DownloadCacheAvailable"/></em></p>
        ///   <p>Only return packages that have a download cache available - this option will filter out results not from the community repository.</p>
        /// </summary>
        [Pure]
        public static T SetDownloadCacheAvailable<T>(this T toolSettings, bool? downloadCacheAvailable) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DownloadCacheAvailable = downloadCacheAvailable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.DownloadCacheAvailable"/></em></p>
        ///   <p>Only return packages that have a download cache available - this option will filter out results not from the community repository.</p>
        /// </summary>
        [Pure]
        public static T ResetDownloadCacheAvailable<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DownloadCacheAvailable = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.DownloadCacheAvailable"/></em></p>
        ///   <p>Only return packages that have a download cache available - this option will filter out results not from the community repository.</p>
        /// </summary>
        [Pure]
        public static T EnableDownloadCacheAvailable<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DownloadCacheAvailable = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.DownloadCacheAvailable"/></em></p>
        ///   <p>Only return packages that have a download cache available - this option will filter out results not from the community repository.</p>
        /// </summary>
        [Pure]
        public static T DisableDownloadCacheAvailable<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DownloadCacheAvailable = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.DownloadCacheAvailable"/></em></p>
        ///   <p>Only return packages that have a download cache available - this option will filter out results not from the community repository.</p>
        /// </summary>
        [Pure]
        public static T ToggleDownloadCacheAvailable<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DownloadCacheAvailable = !toolSettings.DownloadCacheAvailable;
            return toolSettings;
        }
        #endregion
        #region NotBroken
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.NotBroken"/></em></p>
        ///   <p>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</p>
        /// </summary>
        [Pure]
        public static T SetNotBroken<T>(this T toolSettings, bool? notBroken) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NotBroken = notBroken;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.NotBroken"/></em></p>
        ///   <p>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</p>
        /// </summary>
        [Pure]
        public static T ResetNotBroken<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NotBroken = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.NotBroken"/></em></p>
        ///   <p>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</p>
        /// </summary>
        [Pure]
        public static T EnableNotBroken<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NotBroken = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.NotBroken"/></em></p>
        ///   <p>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</p>
        /// </summary>
        [Pure]
        public static T DisableNotBroken<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NotBroken = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.NotBroken"/></em></p>
        ///   <p>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</p>
        /// </summary>
        [Pure]
        public static T ToggleNotBroken<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NotBroken = !toolSettings.NotBroken;
            return toolSettings;
        }
        #endregion
        #region Detailed
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.Detailed"/></em></p>
        ///   <p>Alias for verbose.</p>
        /// </summary>
        [Pure]
        public static T SetDetailed<T>(this T toolSettings, bool? detailed) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Detailed = detailed;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.Detailed"/></em></p>
        ///   <p>Alias for verbose.</p>
        /// </summary>
        [Pure]
        public static T ResetDetailed<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Detailed = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.Detailed"/></em></p>
        ///   <p>Alias for verbose.</p>
        /// </summary>
        [Pure]
        public static T EnableDetailed<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Detailed = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.Detailed"/></em></p>
        ///   <p>Alias for verbose.</p>
        /// </summary>
        [Pure]
        public static T DisableDetailed<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Detailed = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.Detailed"/></em></p>
        ///   <p>Alias for verbose.</p>
        /// </summary>
        [Pure]
        public static T ToggleDetailed<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Detailed = !toolSettings.Detailed;
            return toolSettings;
        }
        #endregion
        #region DisablePackageRepositoryOptimizations
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T SetDisablePackageRepositoryOptimizations<T>(this T toolSettings, bool? disablePackageRepositoryOptimizations) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = disablePackageRepositoryOptimizations;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T ResetDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T EnableDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T DisableDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = !toolSettings.DisablePackageRepositoryOptimizations;
            return toolSettings;
        }
        #endregion
        #region ShowAuditInformation
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.ShowAuditInformation"/></em></p>
        ///   <p>Display auditing information for a package.</p>
        /// </summary>
        [Pure]
        public static T SetShowAuditInformation<T>(this T toolSettings, bool? showAuditInformation) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowAuditInformation = showAuditInformation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.ShowAuditInformation"/></em></p>
        ///   <p>Display auditing information for a package.</p>
        /// </summary>
        [Pure]
        public static T ResetShowAuditInformation<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowAuditInformation = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.ShowAuditInformation"/></em></p>
        ///   <p>Display auditing information for a package.</p>
        /// </summary>
        [Pure]
        public static T EnableShowAuditInformation<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowAuditInformation = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.ShowAuditInformation"/></em></p>
        ///   <p>Display auditing information for a package.</p>
        /// </summary>
        [Pure]
        public static T DisableShowAuditInformation<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowAuditInformation = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.ShowAuditInformation"/></em></p>
        ///   <p>Display auditing information for a package.</p>
        /// </summary>
        [Pure]
        public static T ToggleShowAuditInformation<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowAuditInformation = !toolSettings.ShowAuditInformation;
            return toolSettings;
        }
        #endregion
        #region User
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.User"/></em></p>
        ///   <p>Used with authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetUser<T>(this T toolSettings, string user) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.User = user;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.User"/></em></p>
        ///   <p>Used with authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetUser<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.User = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.Password"/></em></p>
        ///   <p>The user's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.Password"/></em></p>
        ///   <p>The user's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region ClientCertificate
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.ClientCertificate"/></em></p>
        ///   <p>PFX pathname for an x509 authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetClientCertificate<T>(this T toolSettings, string clientCertificate) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientCertificate = clientCertificate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.ClientCertificate"/></em></p>
        ///   <p>PFX pathname for an x509 authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetClientCertificate<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientCertificate = null;
            return toolSettings;
        }
        #endregion
        #region CertificatePassword
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.CertificatePassword"/></em></p>
        ///   <p>The client certificate's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetCertificatePassword<T>(this T toolSettings, [Secret] string certificatePassword) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertificatePassword = certificatePassword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.CertificatePassword"/></em></p>
        ///   <p>The client certificate's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetCertificatePassword<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertificatePassword = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Trace
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T SetTrace<T>(this T toolSettings, bool? trace) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = trace;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T ResetTrace<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T EnableTrace<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T DisableTrace<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T ToggleTrace<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = !toolSettings.Trace;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T SetNoColor<T>(this T toolSettings, bool? noColor) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T ResetNoColor<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T EnableNoColor<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T DisableNoColor<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoColor<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region AcceptLicense
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T SetAcceptLicense<T>(this T toolSettings, bool? acceptLicense) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = acceptLicense;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T ResetAcceptLicense<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T EnableAcceptLicense<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T DisableAcceptLicense<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T ToggleAcceptLicense<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = !toolSettings.AcceptLicense;
            return toolSettings;
        }
        #endregion
        #region Confirm
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T SetConfirm<T>(this T toolSettings, bool? confirm) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = confirm;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T ResetConfirm<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T EnableConfirm<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T DisableConfirm<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T ToggleConfirm<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = !toolSettings.Confirm;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region LimitOutput
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T SetLimitOutput<T>(this T toolSettings, bool? limitOutput) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = limitOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T ResetLimitOutput<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T EnableLimitOutput<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T DisableLimitOutput<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T ToggleLimitOutput<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = !toolSettings.LimitOutput;
            return toolSettings;
        }
        #endregion
        #region CommandExecutionTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.CommandExecutionTimeout"/></em></p>
        ///   <p>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T SetCommandExecutionTimeout<T>(this T toolSettings, int? commandExecutionTimeout) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommandExecutionTimeout = commandExecutionTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.CommandExecutionTimeout"/></em></p>
        ///   <p>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T ResetCommandExecutionTimeout<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommandExecutionTimeout = null;
            return toolSettings;
        }
        #endregion
        #region CacheLocation
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.CacheLocation"/></em></p>
        ///   <p>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</p>
        /// </summary>
        [Pure]
        public static T SetCacheLocation<T>(this T toolSettings, string cacheLocation) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheLocation = cacheLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.CacheLocation"/></em></p>
        ///   <p>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</p>
        /// </summary>
        [Pure]
        public static T ResetCacheLocation<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheLocation = null;
            return toolSettings;
        }
        #endregion
        #region AllowUnofficialBuild
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T SetAllowUnofficialBuild<T>(this T toolSettings, bool? allowUnofficialBuild) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = allowUnofficialBuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T ResetAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T EnableAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T DisableAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T ToggleAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = !toolSettings.AllowUnofficialBuild;
            return toolSettings;
        }
        #endregion
        #region FailOnStandardError
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T SetFailOnStandardError<T>(this T toolSettings, bool? failOnStandardError) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = failOnStandardError;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T ResetFailOnStandardError<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T EnableFailOnStandardError<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T DisableFailOnStandardError<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T ToggleFailOnStandardError<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = !toolSettings.FailOnStandardError;
            return toolSettings;
        }
        #endregion
        #region UseSystemPowerShell
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T SetUseSystemPowerShell<T>(this T toolSettings, bool? useSystemPowerShell) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = useSystemPowerShell;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T ResetUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T EnableUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T DisableUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T ToggleUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = !toolSettings.UseSystemPowerShell;
            return toolSettings;
        }
        #endregion
        #region DoNotShowProgress
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T SetDoNotShowProgress<T>(this T toolSettings, bool? doNotShowProgress) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = doNotShowProgress;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T ResetDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T EnableDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T DisableDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T ToggleDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = !toolSettings.DoNotShowProgress;
            return toolSettings;
        }
        #endregion
        #region Proxy
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.Proxy"/></em></p>
        ///   <p>Explicit proxy location. Overrides the default proxy location of ''.</p>
        /// </summary>
        [Pure]
        public static T SetProxy<T>(this T toolSettings, string proxy) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = proxy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.Proxy"/></em></p>
        ///   <p>Explicit proxy location. Overrides the default proxy location of ''.</p>
        /// </summary>
        [Pure]
        public static T ResetProxy<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = null;
            return toolSettings;
        }
        #endregion
        #region ProxyUserName
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.ProxyUserName"/></em></p>
        ///   <p>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</p>
        /// </summary>
        [Pure]
        public static T SetProxyUserName<T>(this T toolSettings, string proxyUserName) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUserName = proxyUserName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.ProxyUserName"/></em></p>
        ///   <p>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</p>
        /// </summary>
        [Pure]
        public static T ResetProxyUserName<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUserName = null;
            return toolSettings;
        }
        #endregion
        #region ProxyPassword
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.ProxyPassword"/></em></p>
        ///   <p>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</p>
        /// </summary>
        [Pure]
        public static T SetProxyPassword<T>(this T toolSettings, [Secret] string proxyPassword) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = proxyPassword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.ProxyPassword"/></em></p>
        ///   <p>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</p>
        /// </summary>
        [Pure]
        public static T ResetProxyPassword<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = null;
            return toolSettings;
        }
        #endregion
        #region ProxyBypassList
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.ProxyBypassList"/> to a new list</em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal = proxyBypassList.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.ProxyBypassList"/> to a new list</em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal = proxyBypassList.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ChocolateyListSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T AddProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.AddRange(proxyBypassList);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ChocolateyListSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T AddProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.AddRange(proxyBypassList);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ChocolateyListSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ClearProxyBypassList<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ChocolateyListSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T RemoveProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(proxyBypassList);
            toolSettings.ProxyBypassListInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ChocolateyListSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T RemoveProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(proxyBypassList);
            toolSettings.ProxyBypassListInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ProxyBypassOnLocal
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassOnLocal<T>(this T toolSettings, bool? proxyBypassOnLocal) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = proxyBypassOnLocal;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ResetProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyListSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T EnableProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyListSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T DisableProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyListSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ToggleProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = !toolSettings.ProxyBypassOnLocal;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyListSettings.LogFile"/></em></p>
        ///   <p>Log File to output to in addition to regular loggers.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyListSettings.LogFile"/></em></p>
        ///   <p>Log File to output to in addition to regular loggers.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : ChocolateyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region ChocolateyFindSettingsExtensions
    /// <summary>
    ///   Used within <see cref="ChocolateyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class ChocolateyFindSettingsExtensions
    {
        #region Filter
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.Filter"/></em></p>
        ///   <p>Search filter.</p>
        /// </summary>
        [Pure]
        public static T SetFilter<T>(this T toolSettings, string filter) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = filter;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.Filter"/></em></p>
        ///   <p>Search filter.</p>
        /// </summary>
        [Pure]
        public static T ResetFilter<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.Source"/></em></p>
        ///   <p>Source location for install. Can use special 'webpi' or 'windowsfeatures' sources. Defaults to sources.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, string source) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.Source"/></em></p>
        ///   <p>Source location for install. Can use special 'webpi' or 'windowsfeatures' sources. Defaults to sources.</p>
        /// </summary>
        [Pure]
        public static T ResetSource<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region LocalOnly
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.LocalOnly"/></em></p>
        ///   <p>Only search against local machine items.</p>
        /// </summary>
        [Pure]
        public static T SetLocalOnly<T>(this T toolSettings, bool? localOnly) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocalOnly = localOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.LocalOnly"/></em></p>
        ///   <p>Only search against local machine items.</p>
        /// </summary>
        [Pure]
        public static T ResetLocalOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocalOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.LocalOnly"/></em></p>
        ///   <p>Only search against local machine items.</p>
        /// </summary>
        [Pure]
        public static T EnableLocalOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocalOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.LocalOnly"/></em></p>
        ///   <p>Only search against local machine items.</p>
        /// </summary>
        [Pure]
        public static T DisableLocalOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocalOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.LocalOnly"/></em></p>
        ///   <p>Only search against local machine items.</p>
        /// </summary>
        [Pure]
        public static T ToggleLocalOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocalOnly = !toolSettings.LocalOnly;
            return toolSettings;
        }
        #endregion
        #region IdOnly
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.IdOnly"/></em></p>
        ///   <p>Only return Package Ids in the list results.</p>
        /// </summary>
        [Pure]
        public static T SetIdOnly<T>(this T toolSettings, bool? idOnly) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdOnly = idOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.IdOnly"/></em></p>
        ///   <p>Only return Package Ids in the list results.</p>
        /// </summary>
        [Pure]
        public static T ResetIdOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.IdOnly"/></em></p>
        ///   <p>Only return Package Ids in the list results.</p>
        /// </summary>
        [Pure]
        public static T EnableIdOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.IdOnly"/></em></p>
        ///   <p>Only return Package Ids in the list results.</p>
        /// </summary>
        [Pure]
        public static T DisableIdOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.IdOnly"/></em></p>
        ///   <p>Only return Package Ids in the list results.</p>
        /// </summary>
        [Pure]
        public static T ToggleIdOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdOnly = !toolSettings.IdOnly;
            return toolSettings;
        }
        #endregion
        #region Prerelease
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T SetPrerelease<T>(this T toolSettings, bool? prerelease) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = prerelease;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T ResetPrerelease<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T EnablePrerelease<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T DisablePrerelease<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T TogglePrerelease<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = !toolSettings.Prerelease;
            return toolSettings;
        }
        #endregion
        #region IncludePrograms
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.IncludePrograms"/></em></p>
        ///   <p>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T SetIncludePrograms<T>(this T toolSettings, bool? includePrograms) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludePrograms = includePrograms;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.IncludePrograms"/></em></p>
        ///   <p>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T ResetIncludePrograms<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludePrograms = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.IncludePrograms"/></em></p>
        ///   <p>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T EnableIncludePrograms<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludePrograms = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.IncludePrograms"/></em></p>
        ///   <p>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T DisableIncludePrograms<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludePrograms = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.IncludePrograms"/></em></p>
        ///   <p>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T ToggleIncludePrograms<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludePrograms = !toolSettings.IncludePrograms;
            return toolSettings;
        }
        #endregion
        #region AllVersions
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.AllVersions"/></em></p>
        ///   <p>Include results from all versions.</p>
        /// </summary>
        [Pure]
        public static T SetAllVersions<T>(this T toolSettings, bool? allVersions) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVersions = allVersions;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.AllVersions"/></em></p>
        ///   <p>Include results from all versions.</p>
        /// </summary>
        [Pure]
        public static T ResetAllVersions<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVersions = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.AllVersions"/></em></p>
        ///   <p>Include results from all versions.</p>
        /// </summary>
        [Pure]
        public static T EnableAllVersions<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVersions = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.AllVersions"/></em></p>
        ///   <p>Include results from all versions.</p>
        /// </summary>
        [Pure]
        public static T DisableAllVersions<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVersions = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.AllVersions"/></em></p>
        ///   <p>Include results from all versions.</p>
        /// </summary>
        [Pure]
        public static T ToggleAllVersions<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVersions = !toolSettings.AllVersions;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.Version"/></em></p>
        ///   <p>Specific version of a package to return.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.Version"/></em></p>
        ///   <p>Specific version of a package to return.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Page
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.Page"/></em></p>
        ///   <p>The 'page' of results to return. Defaults to return all results.</p>
        /// </summary>
        [Pure]
        public static T SetPage<T>(this T toolSettings, int? page) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Page = page;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.Page"/></em></p>
        ///   <p>The 'page' of results to return. Defaults to return all results.</p>
        /// </summary>
        [Pure]
        public static T ResetPage<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Page = null;
            return toolSettings;
        }
        #endregion
        #region PageSize
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.PageSize"/></em></p>
        ///   <p>The amount of package results to return per page. Defaults to 25.</p>
        /// </summary>
        [Pure]
        public static T SetPageSize<T>(this T toolSettings, int? pageSize) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageSize = pageSize;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.PageSize"/></em></p>
        ///   <p>The amount of package results to return per page. Defaults to 25.</p>
        /// </summary>
        [Pure]
        public static T ResetPageSize<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageSize = null;
            return toolSettings;
        }
        #endregion
        #region Exact
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.Exact"/></em></p>
        ///   <p>Only return packages with this exact name.</p>
        /// </summary>
        [Pure]
        public static T SetExact<T>(this T toolSettings, bool? exact) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exact = exact;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.Exact"/></em></p>
        ///   <p>Only return packages with this exact name.</p>
        /// </summary>
        [Pure]
        public static T ResetExact<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exact = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.Exact"/></em></p>
        ///   <p>Only return packages with this exact name.</p>
        /// </summary>
        [Pure]
        public static T EnableExact<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exact = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.Exact"/></em></p>
        ///   <p>Only return packages with this exact name.</p>
        /// </summary>
        [Pure]
        public static T DisableExact<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exact = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.Exact"/></em></p>
        ///   <p>Only return packages with this exact name.</p>
        /// </summary>
        [Pure]
        public static T ToggleExact<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exact = !toolSettings.Exact;
            return toolSettings;
        }
        #endregion
        #region ByIdOnly
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.ByIdOnly"/></em></p>
        ///   <p>Only return packages where the id contains the search filter.</p>
        /// </summary>
        [Pure]
        public static T SetByIdOnly<T>(this T toolSettings, bool? byIdOnly) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByIdOnly = byIdOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.ByIdOnly"/></em></p>
        ///   <p>Only return packages where the id contains the search filter.</p>
        /// </summary>
        [Pure]
        public static T ResetByIdOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByIdOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.ByIdOnly"/></em></p>
        ///   <p>Only return packages where the id contains the search filter.</p>
        /// </summary>
        [Pure]
        public static T EnableByIdOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByIdOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.ByIdOnly"/></em></p>
        ///   <p>Only return packages where the id contains the search filter.</p>
        /// </summary>
        [Pure]
        public static T DisableByIdOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByIdOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.ByIdOnly"/></em></p>
        ///   <p>Only return packages where the id contains the search filter.</p>
        /// </summary>
        [Pure]
        public static T ToggleByIdOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByIdOnly = !toolSettings.ByIdOnly;
            return toolSettings;
        }
        #endregion
        #region ByTagOnly
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.ByTagOnly"/></em></p>
        ///   <p>Only return packages where the search filter matches on the tags.</p>
        /// </summary>
        [Pure]
        public static T SetByTagOnly<T>(this T toolSettings, bool? byTagOnly) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByTagOnly = byTagOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.ByTagOnly"/></em></p>
        ///   <p>Only return packages where the search filter matches on the tags.</p>
        /// </summary>
        [Pure]
        public static T ResetByTagOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByTagOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.ByTagOnly"/></em></p>
        ///   <p>Only return packages where the search filter matches on the tags.</p>
        /// </summary>
        [Pure]
        public static T EnableByTagOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByTagOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.ByTagOnly"/></em></p>
        ///   <p>Only return packages where the search filter matches on the tags.</p>
        /// </summary>
        [Pure]
        public static T DisableByTagOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByTagOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.ByTagOnly"/></em></p>
        ///   <p>Only return packages where the search filter matches on the tags.</p>
        /// </summary>
        [Pure]
        public static T ToggleByTagOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ByTagOnly = !toolSettings.ByTagOnly;
            return toolSettings;
        }
        #endregion
        #region IdStartsWith
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.IdStartsWith"/></em></p>
        ///   <p>Only return packages where the id starts with the search filter.</p>
        /// </summary>
        [Pure]
        public static T SetIdStartsWith<T>(this T toolSettings, bool? idStartsWith) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdStartsWith = idStartsWith;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.IdStartsWith"/></em></p>
        ///   <p>Only return packages where the id starts with the search filter.</p>
        /// </summary>
        [Pure]
        public static T ResetIdStartsWith<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdStartsWith = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.IdStartsWith"/></em></p>
        ///   <p>Only return packages where the id starts with the search filter.</p>
        /// </summary>
        [Pure]
        public static T EnableIdStartsWith<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdStartsWith = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.IdStartsWith"/></em></p>
        ///   <p>Only return packages where the id starts with the search filter.</p>
        /// </summary>
        [Pure]
        public static T DisableIdStartsWith<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdStartsWith = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.IdStartsWith"/></em></p>
        ///   <p>Only return packages where the id starts with the search filter.</p>
        /// </summary>
        [Pure]
        public static T ToggleIdStartsWith<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IdStartsWith = !toolSettings.IdStartsWith;
            return toolSettings;
        }
        #endregion
        #region OrderByPopularity
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.OrderByPopularity"/></em></p>
        ///   <p>Sort by package results by popularity.</p>
        /// </summary>
        [Pure]
        public static T SetOrderByPopularity<T>(this T toolSettings, bool? orderByPopularity) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OrderByPopularity = orderByPopularity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.OrderByPopularity"/></em></p>
        ///   <p>Sort by package results by popularity.</p>
        /// </summary>
        [Pure]
        public static T ResetOrderByPopularity<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OrderByPopularity = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.OrderByPopularity"/></em></p>
        ///   <p>Sort by package results by popularity.</p>
        /// </summary>
        [Pure]
        public static T EnableOrderByPopularity<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OrderByPopularity = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.OrderByPopularity"/></em></p>
        ///   <p>Sort by package results by popularity.</p>
        /// </summary>
        [Pure]
        public static T DisableOrderByPopularity<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OrderByPopularity = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.OrderByPopularity"/></em></p>
        ///   <p>Sort by package results by popularity.</p>
        /// </summary>
        [Pure]
        public static T ToggleOrderByPopularity<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OrderByPopularity = !toolSettings.OrderByPopularity;
            return toolSettings;
        }
        #endregion
        #region ApprovedOnly
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.ApprovedOnly"/></em></p>
        ///   <p>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</p>
        /// </summary>
        [Pure]
        public static T SetApprovedOnly<T>(this T toolSettings, bool? approvedOnly) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApprovedOnly = approvedOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.ApprovedOnly"/></em></p>
        ///   <p>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetApprovedOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApprovedOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.ApprovedOnly"/></em></p>
        ///   <p>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</p>
        /// </summary>
        [Pure]
        public static T EnableApprovedOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApprovedOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.ApprovedOnly"/></em></p>
        ///   <p>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</p>
        /// </summary>
        [Pure]
        public static T DisableApprovedOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApprovedOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.ApprovedOnly"/></em></p>
        ///   <p>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</p>
        /// </summary>
        [Pure]
        public static T ToggleApprovedOnly<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApprovedOnly = !toolSettings.ApprovedOnly;
            return toolSettings;
        }
        #endregion
        #region DownloadCacheAvailable
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.DownloadCacheAvailable"/></em></p>
        ///   <p>Only return packages that have a download cache available - this option will filter out results not from the community repository.</p>
        /// </summary>
        [Pure]
        public static T SetDownloadCacheAvailable<T>(this T toolSettings, bool? downloadCacheAvailable) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DownloadCacheAvailable = downloadCacheAvailable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.DownloadCacheAvailable"/></em></p>
        ///   <p>Only return packages that have a download cache available - this option will filter out results not from the community repository.</p>
        /// </summary>
        [Pure]
        public static T ResetDownloadCacheAvailable<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DownloadCacheAvailable = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.DownloadCacheAvailable"/></em></p>
        ///   <p>Only return packages that have a download cache available - this option will filter out results not from the community repository.</p>
        /// </summary>
        [Pure]
        public static T EnableDownloadCacheAvailable<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DownloadCacheAvailable = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.DownloadCacheAvailable"/></em></p>
        ///   <p>Only return packages that have a download cache available - this option will filter out results not from the community repository.</p>
        /// </summary>
        [Pure]
        public static T DisableDownloadCacheAvailable<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DownloadCacheAvailable = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.DownloadCacheAvailable"/></em></p>
        ///   <p>Only return packages that have a download cache available - this option will filter out results not from the community repository.</p>
        /// </summary>
        [Pure]
        public static T ToggleDownloadCacheAvailable<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DownloadCacheAvailable = !toolSettings.DownloadCacheAvailable;
            return toolSettings;
        }
        #endregion
        #region NotBroken
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.NotBroken"/></em></p>
        ///   <p>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</p>
        /// </summary>
        [Pure]
        public static T SetNotBroken<T>(this T toolSettings, bool? notBroken) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NotBroken = notBroken;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.NotBroken"/></em></p>
        ///   <p>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</p>
        /// </summary>
        [Pure]
        public static T ResetNotBroken<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NotBroken = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.NotBroken"/></em></p>
        ///   <p>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</p>
        /// </summary>
        [Pure]
        public static T EnableNotBroken<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NotBroken = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.NotBroken"/></em></p>
        ///   <p>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</p>
        /// </summary>
        [Pure]
        public static T DisableNotBroken<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NotBroken = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.NotBroken"/></em></p>
        ///   <p>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</p>
        /// </summary>
        [Pure]
        public static T ToggleNotBroken<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NotBroken = !toolSettings.NotBroken;
            return toolSettings;
        }
        #endregion
        #region Detailed
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.Detailed"/></em></p>
        ///   <p>Alias for verbose.</p>
        /// </summary>
        [Pure]
        public static T SetDetailed<T>(this T toolSettings, bool? detailed) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Detailed = detailed;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.Detailed"/></em></p>
        ///   <p>Alias for verbose.</p>
        /// </summary>
        [Pure]
        public static T ResetDetailed<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Detailed = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.Detailed"/></em></p>
        ///   <p>Alias for verbose.</p>
        /// </summary>
        [Pure]
        public static T EnableDetailed<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Detailed = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.Detailed"/></em></p>
        ///   <p>Alias for verbose.</p>
        /// </summary>
        [Pure]
        public static T DisableDetailed<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Detailed = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.Detailed"/></em></p>
        ///   <p>Alias for verbose.</p>
        /// </summary>
        [Pure]
        public static T ToggleDetailed<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Detailed = !toolSettings.Detailed;
            return toolSettings;
        }
        #endregion
        #region DisablePackageRepositoryOptimizations
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T SetDisablePackageRepositoryOptimizations<T>(this T toolSettings, bool? disablePackageRepositoryOptimizations) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = disablePackageRepositoryOptimizations;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T ResetDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T EnableDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T DisableDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = !toolSettings.DisablePackageRepositoryOptimizations;
            return toolSettings;
        }
        #endregion
        #region ShowAuditInformation
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.ShowAuditInformation"/></em></p>
        ///   <p>Display auditing information for a package.</p>
        /// </summary>
        [Pure]
        public static T SetShowAuditInformation<T>(this T toolSettings, bool? showAuditInformation) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowAuditInformation = showAuditInformation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.ShowAuditInformation"/></em></p>
        ///   <p>Display auditing information for a package.</p>
        /// </summary>
        [Pure]
        public static T ResetShowAuditInformation<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowAuditInformation = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.ShowAuditInformation"/></em></p>
        ///   <p>Display auditing information for a package.</p>
        /// </summary>
        [Pure]
        public static T EnableShowAuditInformation<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowAuditInformation = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.ShowAuditInformation"/></em></p>
        ///   <p>Display auditing information for a package.</p>
        /// </summary>
        [Pure]
        public static T DisableShowAuditInformation<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowAuditInformation = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.ShowAuditInformation"/></em></p>
        ///   <p>Display auditing information for a package.</p>
        /// </summary>
        [Pure]
        public static T ToggleShowAuditInformation<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowAuditInformation = !toolSettings.ShowAuditInformation;
            return toolSettings;
        }
        #endregion
        #region User
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.User"/></em></p>
        ///   <p>Used with authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetUser<T>(this T toolSettings, string user) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.User = user;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.User"/></em></p>
        ///   <p>Used with authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetUser<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.User = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.Password"/></em></p>
        ///   <p>The user's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.Password"/></em></p>
        ///   <p>The user's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region ClientCertificate
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.ClientCertificate"/></em></p>
        ///   <p>PFX pathname for an x509 authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetClientCertificate<T>(this T toolSettings, string clientCertificate) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientCertificate = clientCertificate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.ClientCertificate"/></em></p>
        ///   <p>PFX pathname for an x509 authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetClientCertificate<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientCertificate = null;
            return toolSettings;
        }
        #endregion
        #region CertificatePassword
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.CertificatePassword"/></em></p>
        ///   <p>The client certificate's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetCertificatePassword<T>(this T toolSettings, [Secret] string certificatePassword) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertificatePassword = certificatePassword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.CertificatePassword"/></em></p>
        ///   <p>The client certificate's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetCertificatePassword<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertificatePassword = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Trace
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T SetTrace<T>(this T toolSettings, bool? trace) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = trace;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T ResetTrace<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T EnableTrace<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T DisableTrace<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T ToggleTrace<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = !toolSettings.Trace;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T SetNoColor<T>(this T toolSettings, bool? noColor) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T ResetNoColor<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T EnableNoColor<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T DisableNoColor<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoColor<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region AcceptLicense
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T SetAcceptLicense<T>(this T toolSettings, bool? acceptLicense) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = acceptLicense;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T ResetAcceptLicense<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T EnableAcceptLicense<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T DisableAcceptLicense<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T ToggleAcceptLicense<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = !toolSettings.AcceptLicense;
            return toolSettings;
        }
        #endregion
        #region Confirm
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T SetConfirm<T>(this T toolSettings, bool? confirm) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = confirm;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T ResetConfirm<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T EnableConfirm<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T DisableConfirm<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T ToggleConfirm<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = !toolSettings.Confirm;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region LimitOutput
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T SetLimitOutput<T>(this T toolSettings, bool? limitOutput) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = limitOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T ResetLimitOutput<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T EnableLimitOutput<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T DisableLimitOutput<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T ToggleLimitOutput<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = !toolSettings.LimitOutput;
            return toolSettings;
        }
        #endregion
        #region CommandExecutionTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.CommandExecutionTimeout"/></em></p>
        ///   <p>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T SetCommandExecutionTimeout<T>(this T toolSettings, int? commandExecutionTimeout) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommandExecutionTimeout = commandExecutionTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.CommandExecutionTimeout"/></em></p>
        ///   <p>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T ResetCommandExecutionTimeout<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommandExecutionTimeout = null;
            return toolSettings;
        }
        #endregion
        #region CacheLocation
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.CacheLocation"/></em></p>
        ///   <p>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</p>
        /// </summary>
        [Pure]
        public static T SetCacheLocation<T>(this T toolSettings, string cacheLocation) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheLocation = cacheLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.CacheLocation"/></em></p>
        ///   <p>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</p>
        /// </summary>
        [Pure]
        public static T ResetCacheLocation<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheLocation = null;
            return toolSettings;
        }
        #endregion
        #region AllowUnofficialBuild
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T SetAllowUnofficialBuild<T>(this T toolSettings, bool? allowUnofficialBuild) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = allowUnofficialBuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T ResetAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T EnableAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T DisableAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T ToggleAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = !toolSettings.AllowUnofficialBuild;
            return toolSettings;
        }
        #endregion
        #region FailOnStandardError
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T SetFailOnStandardError<T>(this T toolSettings, bool? failOnStandardError) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = failOnStandardError;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T ResetFailOnStandardError<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T EnableFailOnStandardError<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T DisableFailOnStandardError<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T ToggleFailOnStandardError<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = !toolSettings.FailOnStandardError;
            return toolSettings;
        }
        #endregion
        #region UseSystemPowerShell
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T SetUseSystemPowerShell<T>(this T toolSettings, bool? useSystemPowerShell) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = useSystemPowerShell;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T ResetUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T EnableUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T DisableUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T ToggleUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = !toolSettings.UseSystemPowerShell;
            return toolSettings;
        }
        #endregion
        #region DoNotShowProgress
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T SetDoNotShowProgress<T>(this T toolSettings, bool? doNotShowProgress) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = doNotShowProgress;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T ResetDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T EnableDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T DisableDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T ToggleDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = !toolSettings.DoNotShowProgress;
            return toolSettings;
        }
        #endregion
        #region Proxy
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.Proxy"/></em></p>
        ///   <p>Explicit proxy location. Overrides the default proxy location of ''.</p>
        /// </summary>
        [Pure]
        public static T SetProxy<T>(this T toolSettings, string proxy) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = proxy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.Proxy"/></em></p>
        ///   <p>Explicit proxy location. Overrides the default proxy location of ''.</p>
        /// </summary>
        [Pure]
        public static T ResetProxy<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = null;
            return toolSettings;
        }
        #endregion
        #region ProxyUserName
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.ProxyUserName"/></em></p>
        ///   <p>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</p>
        /// </summary>
        [Pure]
        public static T SetProxyUserName<T>(this T toolSettings, string proxyUserName) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUserName = proxyUserName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.ProxyUserName"/></em></p>
        ///   <p>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</p>
        /// </summary>
        [Pure]
        public static T ResetProxyUserName<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUserName = null;
            return toolSettings;
        }
        #endregion
        #region ProxyPassword
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.ProxyPassword"/></em></p>
        ///   <p>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</p>
        /// </summary>
        [Pure]
        public static T SetProxyPassword<T>(this T toolSettings, [Secret] string proxyPassword) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = proxyPassword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.ProxyPassword"/></em></p>
        ///   <p>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</p>
        /// </summary>
        [Pure]
        public static T ResetProxyPassword<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = null;
            return toolSettings;
        }
        #endregion
        #region ProxyBypassList
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.ProxyBypassList"/> to a new list</em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal = proxyBypassList.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.ProxyBypassList"/> to a new list</em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal = proxyBypassList.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ChocolateyFindSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T AddProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.AddRange(proxyBypassList);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ChocolateyFindSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T AddProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.AddRange(proxyBypassList);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ChocolateyFindSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ClearProxyBypassList<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ChocolateyFindSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T RemoveProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(proxyBypassList);
            toolSettings.ProxyBypassListInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ChocolateyFindSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T RemoveProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(proxyBypassList);
            toolSettings.ProxyBypassListInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ProxyBypassOnLocal
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassOnLocal<T>(this T toolSettings, bool? proxyBypassOnLocal) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = proxyBypassOnLocal;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ResetProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyFindSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T EnableProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyFindSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T DisableProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyFindSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ToggleProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = !toolSettings.ProxyBypassOnLocal;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyFindSettings.LogFile"/></em></p>
        ///   <p>Log File to output to in addition to regular loggers.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyFindSettings.LogFile"/></em></p>
        ///   <p>Log File to output to in addition to regular loggers.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : ChocolateyFindSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region ChocolateyOutdatedSettingsExtensions
    /// <summary>
    ///   Used within <see cref="ChocolateyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class ChocolateyOutdatedSettingsExtensions
    {
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.Source"/></em></p>
        ///   <p>The source to find the package(s) to install. Special sources include: ruby, webpi, cygwin, windowsfeatures, and python. To specify more than one source, pass it with a semi-colon separating the values (-e.g. "'source1;source2'"). Defaults to default feeds.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, string source) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.Source"/></em></p>
        ///   <p>The source to find the package(s) to install. Special sources include: ruby, webpi, cygwin, windowsfeatures, and python. To specify more than one source, pass it with a semi-colon separating the values (-e.g. "'source1;source2'"). Defaults to default feeds.</p>
        /// </summary>
        [Pure]
        public static T ResetSource<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region Prerelease
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T SetPrerelease<T>(this T toolSettings, bool? prerelease) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = prerelease;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T ResetPrerelease<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T EnablePrerelease<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T DisablePrerelease<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.Prerelease"/></em></p>
        ///   <p>Include Prereleases? Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T TogglePrerelease<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = !toolSettings.Prerelease;
            return toolSettings;
        }
        #endregion
        #region IgnorePinned
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.IgnorePinned"/></em></p>
        ///   <p>Ignore pinned packages. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T SetIgnorePinned<T>(this T toolSettings, bool? ignorePinned) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnorePinned = ignorePinned;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.IgnorePinned"/></em></p>
        ///   <p>Ignore pinned packages. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnorePinned<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnorePinned = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.IgnorePinned"/></em></p>
        ///   <p>Ignore pinned packages. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnorePinned<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnorePinned = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.IgnorePinned"/></em></p>
        ///   <p>Ignore pinned packages. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnorePinned<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnorePinned = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.IgnorePinned"/></em></p>
        ///   <p>Ignore pinned packages. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnorePinned<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnorePinned = !toolSettings.IgnorePinned;
            return toolSettings;
        }
        #endregion
        #region IgnoreUnfound
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.IgnoreUnfound"/></em></p>
        ///   <p>Ignore packages that are not found on the sources used (or the defaults). Overrides the default feature 'ignoreUnfoundPackagesOnUpgradeOutdated' set to 'False'.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreUnfound<T>(this T toolSettings, bool? ignoreUnfound) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreUnfound = ignoreUnfound;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.IgnoreUnfound"/></em></p>
        ///   <p>Ignore packages that are not found on the sources used (or the defaults). Overrides the default feature 'ignoreUnfoundPackagesOnUpgradeOutdated' set to 'False'.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreUnfound<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreUnfound = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.IgnoreUnfound"/></em></p>
        ///   <p>Ignore packages that are not found on the sources used (or the defaults). Overrides the default feature 'ignoreUnfoundPackagesOnUpgradeOutdated' set to 'False'.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreUnfound<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreUnfound = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.IgnoreUnfound"/></em></p>
        ///   <p>Ignore packages that are not found on the sources used (or the defaults). Overrides the default feature 'ignoreUnfoundPackagesOnUpgradeOutdated' set to 'False'.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreUnfound<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreUnfound = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.IgnoreUnfound"/></em></p>
        ///   <p>Ignore packages that are not found on the sources used (or the defaults). Overrides the default feature 'ignoreUnfoundPackagesOnUpgradeOutdated' set to 'False'.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreUnfound<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreUnfound = !toolSettings.IgnoreUnfound;
            return toolSettings;
        }
        #endregion
        #region DisablePackageRepositoryOptimizations
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T SetDisablePackageRepositoryOptimizations<T>(this T toolSettings, bool? disablePackageRepositoryOptimizations) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = disablePackageRepositoryOptimizations;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T ResetDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T EnableDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T DisableDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/></em></p>
        ///   <p>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisablePackageRepositoryOptimizations<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisablePackageRepositoryOptimizations = !toolSettings.DisablePackageRepositoryOptimizations;
            return toolSettings;
        }
        #endregion
        #region User
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.User"/></em></p>
        ///   <p>Used with authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetUser<T>(this T toolSettings, string user) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.User = user;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.User"/></em></p>
        ///   <p>Used with authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetUser<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.User = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.Password"/></em></p>
        ///   <p>The user's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.Password"/></em></p>
        ///   <p>The user's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region ClientCertificate
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.ClientCertificate"/></em></p>
        ///   <p>PFX pathname for an x509 authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetClientCertificate<T>(this T toolSettings, string clientCertificate) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientCertificate = clientCertificate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.ClientCertificate"/></em></p>
        ///   <p>PFX pathname for an x509 authenticated feeds. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetClientCertificate<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientCertificate = null;
            return toolSettings;
        }
        #endregion
        #region CertificatePassword
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.CertificatePassword"/></em></p>
        ///   <p>The client certificate's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetCertificatePassword<T>(this T toolSettings, [Secret] string certificatePassword) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertificatePassword = certificatePassword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.CertificatePassword"/></em></p>
        ///   <p>The client certificate's password to the source. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetCertificatePassword<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertificatePassword = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Trace
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T SetTrace<T>(this T toolSettings, bool? trace) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = trace;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T ResetTrace<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T EnableTrace<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T DisableTrace<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T ToggleTrace<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = !toolSettings.Trace;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T SetNoColor<T>(this T toolSettings, bool? noColor) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T ResetNoColor<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T EnableNoColor<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T DisableNoColor<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoColor<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region AcceptLicense
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T SetAcceptLicense<T>(this T toolSettings, bool? acceptLicense) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = acceptLicense;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T ResetAcceptLicense<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T EnableAcceptLicense<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T DisableAcceptLicense<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T ToggleAcceptLicense<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = !toolSettings.AcceptLicense;
            return toolSettings;
        }
        #endregion
        #region Confirm
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T SetConfirm<T>(this T toolSettings, bool? confirm) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = confirm;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T ResetConfirm<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T EnableConfirm<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T DisableConfirm<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T ToggleConfirm<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = !toolSettings.Confirm;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region LimitOutput
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T SetLimitOutput<T>(this T toolSettings, bool? limitOutput) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = limitOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T ResetLimitOutput<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T EnableLimitOutput<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T DisableLimitOutput<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T ToggleLimitOutput<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = !toolSettings.LimitOutput;
            return toolSettings;
        }
        #endregion
        #region CommandExecutionTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.CommandExecutionTimeout"/></em></p>
        ///   <p>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T SetCommandExecutionTimeout<T>(this T toolSettings, int? commandExecutionTimeout) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommandExecutionTimeout = commandExecutionTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.CommandExecutionTimeout"/></em></p>
        ///   <p>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T ResetCommandExecutionTimeout<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommandExecutionTimeout = null;
            return toolSettings;
        }
        #endregion
        #region CacheLocation
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.CacheLocation"/></em></p>
        ///   <p>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</p>
        /// </summary>
        [Pure]
        public static T SetCacheLocation<T>(this T toolSettings, string cacheLocation) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheLocation = cacheLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.CacheLocation"/></em></p>
        ///   <p>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</p>
        /// </summary>
        [Pure]
        public static T ResetCacheLocation<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheLocation = null;
            return toolSettings;
        }
        #endregion
        #region AllowUnofficialBuild
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T SetAllowUnofficialBuild<T>(this T toolSettings, bool? allowUnofficialBuild) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = allowUnofficialBuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T ResetAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T EnableAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T DisableAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T ToggleAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = !toolSettings.AllowUnofficialBuild;
            return toolSettings;
        }
        #endregion
        #region FailOnStandardError
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T SetFailOnStandardError<T>(this T toolSettings, bool? failOnStandardError) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = failOnStandardError;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T ResetFailOnStandardError<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T EnableFailOnStandardError<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T DisableFailOnStandardError<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T ToggleFailOnStandardError<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = !toolSettings.FailOnStandardError;
            return toolSettings;
        }
        #endregion
        #region UseSystemPowerShell
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T SetUseSystemPowerShell<T>(this T toolSettings, bool? useSystemPowerShell) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = useSystemPowerShell;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T ResetUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T EnableUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T DisableUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T ToggleUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = !toolSettings.UseSystemPowerShell;
            return toolSettings;
        }
        #endregion
        #region DoNotShowProgress
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T SetDoNotShowProgress<T>(this T toolSettings, bool? doNotShowProgress) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = doNotShowProgress;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T ResetDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T EnableDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T DisableDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T ToggleDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = !toolSettings.DoNotShowProgress;
            return toolSettings;
        }
        #endregion
        #region Proxy
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.Proxy"/></em></p>
        ///   <p>Explicit proxy location. Overrides the default proxy location of ''.</p>
        /// </summary>
        [Pure]
        public static T SetProxy<T>(this T toolSettings, string proxy) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = proxy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.Proxy"/></em></p>
        ///   <p>Explicit proxy location. Overrides the default proxy location of ''.</p>
        /// </summary>
        [Pure]
        public static T ResetProxy<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = null;
            return toolSettings;
        }
        #endregion
        #region ProxyUserName
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.ProxyUserName"/></em></p>
        ///   <p>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</p>
        /// </summary>
        [Pure]
        public static T SetProxyUserName<T>(this T toolSettings, string proxyUserName) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUserName = proxyUserName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.ProxyUserName"/></em></p>
        ///   <p>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</p>
        /// </summary>
        [Pure]
        public static T ResetProxyUserName<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUserName = null;
            return toolSettings;
        }
        #endregion
        #region ProxyPassword
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.ProxyPassword"/></em></p>
        ///   <p>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</p>
        /// </summary>
        [Pure]
        public static T SetProxyPassword<T>(this T toolSettings, [Secret] string proxyPassword) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = proxyPassword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.ProxyPassword"/></em></p>
        ///   <p>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</p>
        /// </summary>
        [Pure]
        public static T ResetProxyPassword<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = null;
            return toolSettings;
        }
        #endregion
        #region ProxyBypassList
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.ProxyBypassList"/> to a new list</em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal = proxyBypassList.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.ProxyBypassList"/> to a new list</em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal = proxyBypassList.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ChocolateyOutdatedSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T AddProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.AddRange(proxyBypassList);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ChocolateyOutdatedSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T AddProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.AddRange(proxyBypassList);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ChocolateyOutdatedSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ClearProxyBypassList<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ChocolateyOutdatedSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T RemoveProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(proxyBypassList);
            toolSettings.ProxyBypassListInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ChocolateyOutdatedSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T RemoveProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(proxyBypassList);
            toolSettings.ProxyBypassListInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ProxyBypassOnLocal
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassOnLocal<T>(this T toolSettings, bool? proxyBypassOnLocal) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = proxyBypassOnLocal;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ResetProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T EnableProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T DisableProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ToggleProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = !toolSettings.ProxyBypassOnLocal;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyOutdatedSettings.LogFile"/></em></p>
        ///   <p>Log File to output to in addition to regular loggers.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyOutdatedSettings.LogFile"/></em></p>
        ///   <p>Log File to output to in addition to regular loggers.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : ChocolateyOutdatedSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region ChocolateyPackSettingsExtensions
    /// <summary>
    ///   Used within <see cref="ChocolateyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class ChocolateyPackSettingsExtensions
    {
        #region PathToNuspec
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.PathToNuspec"/></em></p>
        ///   <p>Path to nuspec</p>
        /// </summary>
        [Pure]
        public static T SetPathToNuspec<T>(this T toolSettings, string pathToNuspec) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PathToNuspec = pathToNuspec;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.PathToNuspec"/></em></p>
        ///   <p>Path to nuspec</p>
        /// </summary>
        [Pure]
        public static T ResetPathToNuspec<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PathToNuspec = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.Version"/></em></p>
        ///   <p>The version you would like to insert into the package.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.Version"/></em></p>
        ///   <p>The version you would like to insert into the package.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region OutputDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.OutputDirectory"/></em></p>
        ///   <p>Specifies the directory for the created Chocolatey package file. If not specified, uses the current directory.</p>
        /// </summary>
        [Pure]
        public static T SetOutputDirectory<T>(this T toolSettings, string outputDirectory) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.OutputDirectory"/></em></p>
        ///   <p>Specifies the directory for the created Chocolatey package file. If not specified, uses the current directory.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputDirectory<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPackSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPackSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPackSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPackSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPackSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPackSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Trace
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T SetTrace<T>(this T toolSettings, bool? trace) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = trace;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T ResetTrace<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPackSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T EnableTrace<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPackSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T DisableTrace<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPackSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T ToggleTrace<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = !toolSettings.Trace;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T SetNoColor<T>(this T toolSettings, bool? noColor) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T ResetNoColor<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPackSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T EnableNoColor<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPackSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T DisableNoColor<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPackSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoColor<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region AcceptLicense
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T SetAcceptLicense<T>(this T toolSettings, bool? acceptLicense) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = acceptLicense;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T ResetAcceptLicense<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPackSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T EnableAcceptLicense<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPackSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T DisableAcceptLicense<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPackSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T ToggleAcceptLicense<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = !toolSettings.AcceptLicense;
            return toolSettings;
        }
        #endregion
        #region Confirm
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T SetConfirm<T>(this T toolSettings, bool? confirm) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = confirm;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T ResetConfirm<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPackSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T EnableConfirm<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPackSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T DisableConfirm<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPackSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T ToggleConfirm<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = !toolSettings.Confirm;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPackSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPackSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPackSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region LimitOutput
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T SetLimitOutput<T>(this T toolSettings, bool? limitOutput) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = limitOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T ResetLimitOutput<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPackSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T EnableLimitOutput<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPackSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T DisableLimitOutput<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPackSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T ToggleLimitOutput<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = !toolSettings.LimitOutput;
            return toolSettings;
        }
        #endregion
        #region CommandExecutionTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.CommandExecutionTimeout"/></em></p>
        ///   <p>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T SetCommandExecutionTimeout<T>(this T toolSettings, int? commandExecutionTimeout) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommandExecutionTimeout = commandExecutionTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.CommandExecutionTimeout"/></em></p>
        ///   <p>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T ResetCommandExecutionTimeout<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommandExecutionTimeout = null;
            return toolSettings;
        }
        #endregion
        #region CacheLocation
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.CacheLocation"/></em></p>
        ///   <p>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</p>
        /// </summary>
        [Pure]
        public static T SetCacheLocation<T>(this T toolSettings, string cacheLocation) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheLocation = cacheLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.CacheLocation"/></em></p>
        ///   <p>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</p>
        /// </summary>
        [Pure]
        public static T ResetCacheLocation<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheLocation = null;
            return toolSettings;
        }
        #endregion
        #region AllowUnofficialBuild
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T SetAllowUnofficialBuild<T>(this T toolSettings, bool? allowUnofficialBuild) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = allowUnofficialBuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T ResetAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPackSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T EnableAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPackSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T DisableAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPackSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T ToggleAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = !toolSettings.AllowUnofficialBuild;
            return toolSettings;
        }
        #endregion
        #region FailOnStandardError
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T SetFailOnStandardError<T>(this T toolSettings, bool? failOnStandardError) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = failOnStandardError;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T ResetFailOnStandardError<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPackSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T EnableFailOnStandardError<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPackSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T DisableFailOnStandardError<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPackSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T ToggleFailOnStandardError<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = !toolSettings.FailOnStandardError;
            return toolSettings;
        }
        #endregion
        #region UseSystemPowerShell
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T SetUseSystemPowerShell<T>(this T toolSettings, bool? useSystemPowerShell) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = useSystemPowerShell;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T ResetUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPackSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T EnableUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPackSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T DisableUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPackSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T ToggleUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = !toolSettings.UseSystemPowerShell;
            return toolSettings;
        }
        #endregion
        #region DoNotShowProgress
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T SetDoNotShowProgress<T>(this T toolSettings, bool? doNotShowProgress) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = doNotShowProgress;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T ResetDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPackSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T EnableDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPackSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T DisableDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPackSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T ToggleDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = !toolSettings.DoNotShowProgress;
            return toolSettings;
        }
        #endregion
        #region Proxy
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.Proxy"/></em></p>
        ///   <p>Explicit proxy location. Overrides the default proxy location of ''.</p>
        /// </summary>
        [Pure]
        public static T SetProxy<T>(this T toolSettings, string proxy) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = proxy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.Proxy"/></em></p>
        ///   <p>Explicit proxy location. Overrides the default proxy location of ''.</p>
        /// </summary>
        [Pure]
        public static T ResetProxy<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = null;
            return toolSettings;
        }
        #endregion
        #region ProxyUserName
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.ProxyUserName"/></em></p>
        ///   <p>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</p>
        /// </summary>
        [Pure]
        public static T SetProxyUserName<T>(this T toolSettings, string proxyUserName) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUserName = proxyUserName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.ProxyUserName"/></em></p>
        ///   <p>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</p>
        /// </summary>
        [Pure]
        public static T ResetProxyUserName<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUserName = null;
            return toolSettings;
        }
        #endregion
        #region ProxyPassword
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.ProxyPassword"/></em></p>
        ///   <p>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</p>
        /// </summary>
        [Pure]
        public static T SetProxyPassword<T>(this T toolSettings, [Secret] string proxyPassword) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = proxyPassword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.ProxyPassword"/></em></p>
        ///   <p>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</p>
        /// </summary>
        [Pure]
        public static T ResetProxyPassword<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = null;
            return toolSettings;
        }
        #endregion
        #region ProxyBypassList
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.ProxyBypassList"/> to a new list</em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal = proxyBypassList.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.ProxyBypassList"/> to a new list</em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal = proxyBypassList.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ChocolateyPackSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T AddProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.AddRange(proxyBypassList);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ChocolateyPackSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T AddProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.AddRange(proxyBypassList);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ChocolateyPackSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ClearProxyBypassList<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ChocolateyPackSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T RemoveProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(proxyBypassList);
            toolSettings.ProxyBypassListInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ChocolateyPackSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T RemoveProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(proxyBypassList);
            toolSettings.ProxyBypassListInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ProxyBypassOnLocal
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassOnLocal<T>(this T toolSettings, bool? proxyBypassOnLocal) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = proxyBypassOnLocal;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ResetProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPackSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T EnableProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPackSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T DisableProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPackSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ToggleProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = !toolSettings.ProxyBypassOnLocal;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.LogFile"/></em></p>
        ///   <p>Log File to output to in addition to regular loggers.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPackSettings.LogFile"/></em></p>
        ///   <p>Log File to output to in addition to regular loggers.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPackSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>You can pass arbitrary property value pairs through to nuspecs. These will replace variables formatted as <em>$property$</em> with the value passed.</p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, object> properties) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ChocolateyPackSettings.Properties"/></em></p>
        ///   <p>You can pass arbitrary property value pairs through to nuspecs. These will replace variables formatted as <em>$property$</em> with the value passed.</p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="ChocolateyPackSettings.Properties"/></em></p>
        ///   <p>You can pass arbitrary property value pairs through to nuspecs. These will replace variables formatted as <em>$property$</em> with the value passed.</p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="ChocolateyPackSettings.Properties"/></em></p>
        ///   <p>You can pass arbitrary property value pairs through to nuspecs. These will replace variables formatted as <em>$property$</em> with the value passed.</p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="ChocolateyPackSettings.Properties"/></em></p>
        ///   <p>You can pass arbitrary property value pairs through to nuspecs. These will replace variables formatted as <em>$property$</em> with the value passed.</p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : ChocolateyPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region ChocolateyPushSettingsExtensions
    /// <summary>
    ///   Used within <see cref="ChocolateyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class ChocolateyPushSettingsExtensions
    {
        #region PathToNuGetPackage
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.PathToNuGetPackage"/></em></p>
        ///   <p>Path to Nuget package (.nupkg).</p>
        /// </summary>
        [Pure]
        public static T SetPathToNuGetPackage<T>(this T toolSettings, string pathToNuGetPackage) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PathToNuGetPackage = pathToNuGetPackage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.PathToNuGetPackage"/></em></p>
        ///   <p>Path to Nuget package (.nupkg).</p>
        /// </summary>
        [Pure]
        public static T ResetPathToNuGetPackage<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PathToNuGetPackage = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.Source"/></em></p>
        ///   <p>The source we are pushing the package to. Use <a href="https://pus-h.chocolatey.org/">https://pus-h.chocolatey.org/</a> to push to <a href="https://comminty.chocolatey.org/packages">community feed</a>.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, string source) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.Source"/></em></p>
        ///   <p>The source we are pushing the package to. Use <a href="https://pus-h.chocolatey.org/">https://pus-h.chocolatey.org/</a> to push to <a href="https://comminty.chocolatey.org/packages">community feed</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetSource<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region ApiKey
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.ApiKey"/></em></p>
        ///   <p>The api key for the source. If not specified (and not local file source), does a lookup. If not specified and one is not found for an https source, push will fail.</p>
        /// </summary>
        [Pure]
        public static T SetApiKey<T>(this T toolSettings, [Secret] string apiKey) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = apiKey;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.ApiKey"/></em></p>
        ///   <p>The api key for the source. If not specified (and not local file source), does a lookup. If not specified and one is not found for an https source, push will fail.</p>
        /// </summary>
        [Pure]
        public static T ResetApiKey<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = null;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.Timeout"/></em></p>
        ///   <p>The time to allow a package push to occur before timing out. Defaults to execution timeout 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, int? timeout) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.Timeout"/></em></p>
        ///   <p>The time to allow a package push to occur before timing out. Defaults to execution timeout 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPushSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPushSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPushSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPushSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPushSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPushSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Trace
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T SetTrace<T>(this T toolSettings, bool? trace) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = trace;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T ResetTrace<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPushSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T EnableTrace<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPushSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T DisableTrace<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPushSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T ToggleTrace<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = !toolSettings.Trace;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T SetNoColor<T>(this T toolSettings, bool? noColor) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T ResetNoColor<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPushSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T EnableNoColor<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPushSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T DisableNoColor<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPushSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoColor<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region AcceptLicense
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T SetAcceptLicense<T>(this T toolSettings, bool? acceptLicense) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = acceptLicense;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T ResetAcceptLicense<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPushSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T EnableAcceptLicense<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPushSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T DisableAcceptLicense<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPushSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T ToggleAcceptLicense<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = !toolSettings.AcceptLicense;
            return toolSettings;
        }
        #endregion
        #region Confirm
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T SetConfirm<T>(this T toolSettings, bool? confirm) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = confirm;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T ResetConfirm<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPushSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T EnableConfirm<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPushSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T DisableConfirm<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPushSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T ToggleConfirm<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = !toolSettings.Confirm;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPushSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPushSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPushSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region LimitOutput
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T SetLimitOutput<T>(this T toolSettings, bool? limitOutput) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = limitOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T ResetLimitOutput<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPushSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T EnableLimitOutput<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPushSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T DisableLimitOutput<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPushSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T ToggleLimitOutput<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = !toolSettings.LimitOutput;
            return toolSettings;
        }
        #endregion
        #region CommandExecutionTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.CommandExecutionTimeout"/></em></p>
        ///   <p>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T SetCommandExecutionTimeout<T>(this T toolSettings, int? commandExecutionTimeout) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommandExecutionTimeout = commandExecutionTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.CommandExecutionTimeout"/></em></p>
        ///   <p>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T ResetCommandExecutionTimeout<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommandExecutionTimeout = null;
            return toolSettings;
        }
        #endregion
        #region CacheLocation
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.CacheLocation"/></em></p>
        ///   <p>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</p>
        /// </summary>
        [Pure]
        public static T SetCacheLocation<T>(this T toolSettings, string cacheLocation) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheLocation = cacheLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.CacheLocation"/></em></p>
        ///   <p>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</p>
        /// </summary>
        [Pure]
        public static T ResetCacheLocation<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheLocation = null;
            return toolSettings;
        }
        #endregion
        #region AllowUnofficialBuild
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T SetAllowUnofficialBuild<T>(this T toolSettings, bool? allowUnofficialBuild) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = allowUnofficialBuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T ResetAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPushSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T EnableAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPushSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T DisableAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPushSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T ToggleAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = !toolSettings.AllowUnofficialBuild;
            return toolSettings;
        }
        #endregion
        #region FailOnStandardError
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T SetFailOnStandardError<T>(this T toolSettings, bool? failOnStandardError) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = failOnStandardError;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T ResetFailOnStandardError<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPushSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T EnableFailOnStandardError<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPushSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T DisableFailOnStandardError<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPushSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T ToggleFailOnStandardError<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = !toolSettings.FailOnStandardError;
            return toolSettings;
        }
        #endregion
        #region UseSystemPowerShell
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T SetUseSystemPowerShell<T>(this T toolSettings, bool? useSystemPowerShell) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = useSystemPowerShell;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T ResetUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPushSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T EnableUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPushSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T DisableUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPushSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T ToggleUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = !toolSettings.UseSystemPowerShell;
            return toolSettings;
        }
        #endregion
        #region DoNotShowProgress
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T SetDoNotShowProgress<T>(this T toolSettings, bool? doNotShowProgress) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = doNotShowProgress;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T ResetDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPushSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T EnableDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPushSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T DisableDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPushSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T ToggleDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = !toolSettings.DoNotShowProgress;
            return toolSettings;
        }
        #endregion
        #region Proxy
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.Proxy"/></em></p>
        ///   <p>Explicit proxy location. Overrides the default proxy location of ''.</p>
        /// </summary>
        [Pure]
        public static T SetProxy<T>(this T toolSettings, string proxy) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = proxy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.Proxy"/></em></p>
        ///   <p>Explicit proxy location. Overrides the default proxy location of ''.</p>
        /// </summary>
        [Pure]
        public static T ResetProxy<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = null;
            return toolSettings;
        }
        #endregion
        #region ProxyUserName
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.ProxyUserName"/></em></p>
        ///   <p>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</p>
        /// </summary>
        [Pure]
        public static T SetProxyUserName<T>(this T toolSettings, string proxyUserName) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUserName = proxyUserName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.ProxyUserName"/></em></p>
        ///   <p>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</p>
        /// </summary>
        [Pure]
        public static T ResetProxyUserName<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUserName = null;
            return toolSettings;
        }
        #endregion
        #region ProxyPassword
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.ProxyPassword"/></em></p>
        ///   <p>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</p>
        /// </summary>
        [Pure]
        public static T SetProxyPassword<T>(this T toolSettings, [Secret] string proxyPassword) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = proxyPassword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.ProxyPassword"/></em></p>
        ///   <p>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</p>
        /// </summary>
        [Pure]
        public static T ResetProxyPassword<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = null;
            return toolSettings;
        }
        #endregion
        #region ProxyBypassList
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.ProxyBypassList"/> to a new list</em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal = proxyBypassList.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.ProxyBypassList"/> to a new list</em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal = proxyBypassList.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ChocolateyPushSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T AddProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.AddRange(proxyBypassList);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ChocolateyPushSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T AddProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.AddRange(proxyBypassList);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ChocolateyPushSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ClearProxyBypassList<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ChocolateyPushSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T RemoveProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(proxyBypassList);
            toolSettings.ProxyBypassListInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ChocolateyPushSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T RemoveProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(proxyBypassList);
            toolSettings.ProxyBypassListInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ProxyBypassOnLocal
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassOnLocal<T>(this T toolSettings, bool? proxyBypassOnLocal) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = proxyBypassOnLocal;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ResetProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyPushSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T EnableProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyPushSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T DisableProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyPushSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ToggleProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = !toolSettings.ProxyBypassOnLocal;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyPushSettings.LogFile"/></em></p>
        ///   <p>Log File to output to in addition to regular loggers.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyPushSettings.LogFile"/></em></p>
        ///   <p>Log File to output to in addition to regular loggers.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : ChocolateyPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region ChocolateyNewSettingsExtensions
    /// <summary>
    ///   Used within <see cref="ChocolateyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class ChocolateyNewSettingsExtensions
    {
        #region AutomaticPackage
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.AutomaticPackage"/></em></p>
        ///   <p>Generate automatic package instead of normal. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T SetAutomaticPackage<T>(this T toolSettings, bool? automaticPackage) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutomaticPackage = automaticPackage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.AutomaticPackage"/></em></p>
        ///   <p>Generate automatic package instead of normal. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T ResetAutomaticPackage<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutomaticPackage = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.AutomaticPackage"/></em></p>
        ///   <p>Generate automatic package instead of normal. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T EnableAutomaticPackage<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutomaticPackage = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.AutomaticPackage"/></em></p>
        ///   <p>Generate automatic package instead of normal. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T DisableAutomaticPackage<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutomaticPackage = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.AutomaticPackage"/></em></p>
        ///   <p>Generate automatic package instead of normal. Defaults to false.</p>
        /// </summary>
        [Pure]
        public static T ToggleAutomaticPackage<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutomaticPackage = !toolSettings.AutomaticPackage;
            return toolSettings;
        }
        #endregion
        #region TemplateName
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.TemplateName"/></em></p>
        ///   <p>Use a named template in <em>C:\ProgramData\chocolatey\templates\templatename</em> instead of built-in template.</p>
        /// </summary>
        [Pure]
        public static T SetTemplateName<T>(this T toolSettings, string templateName) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateName = templateName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.TemplateName"/></em></p>
        ///   <p>Use a named template in <em>C:\ProgramData\chocolatey\templates\templatename</em> instead of built-in template.</p>
        /// </summary>
        [Pure]
        public static T ResetTemplateName<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateName = null;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.Name"/></em></p>
        ///   <p>The required name of the package.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.Name"/></em></p>
        ///   <p>The required name of the package.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.Version"/></em></p>
        ///   <p>The version of the package.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.Version"/></em></p>
        ///   <p>The version of the package.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Maintainer
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.Maintainer"/></em></p>
        ///   <p>The name of the maintainer.</p>
        /// </summary>
        [Pure]
        public static T SetMaintainer<T>(this T toolSettings, string maintainer) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Maintainer = maintainer;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.Maintainer"/></em></p>
        ///   <p>The name of the maintainer.</p>
        /// </summary>
        [Pure]
        public static T ResetMaintainer<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Maintainer = null;
            return toolSettings;
        }
        #endregion
        #region OutputDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.OutputDirectory"/></em></p>
        ///   <p>Specifies the directory for the created Chocolatey package file. If not specified, uses the current directory.</p>
        /// </summary>
        [Pure]
        public static T SetOutputDirectory<T>(this T toolSettings, string outputDirectory) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.OutputDirectory"/></em></p>
        ///   <p>Specifies the directory for the created Chocolatey package file. If not specified, uses the current directory.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputDirectory<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region BuildInTemplate
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.BuildInTemplate"/></em></p>
        ///   <p>Use the original built-in template instead of any override.</p>
        /// </summary>
        [Pure]
        public static T SetBuildInTemplate<T>(this T toolSettings, bool? buildInTemplate) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildInTemplate = buildInTemplate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.BuildInTemplate"/></em></p>
        ///   <p>Use the original built-in template instead of any override.</p>
        /// </summary>
        [Pure]
        public static T ResetBuildInTemplate<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildInTemplate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.BuildInTemplate"/></em></p>
        ///   <p>Use the original built-in template instead of any override.</p>
        /// </summary>
        [Pure]
        public static T EnableBuildInTemplate<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildInTemplate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.BuildInTemplate"/></em></p>
        ///   <p>Use the original built-in template instead of any override.</p>
        /// </summary>
        [Pure]
        public static T DisableBuildInTemplate<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildInTemplate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.BuildInTemplate"/></em></p>
        ///   <p>Use the original built-in template instead of any override.</p>
        /// </summary>
        [Pure]
        public static T ToggleBuildInTemplate<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildInTemplate = !toolSettings.BuildInTemplate;
            return toolSettings;
        }
        #endregion
        #region LocationOfBinary
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.LocationOfBinary"/></em></p>
        ///   <p>In <a href="https://chocolatey.org/compare">Chocolatey for Business</a>, file is used for auto-detection (native installer, zip, patch/upgrade file, or remote url to download first) to completely create a package with proper silent arguments! Can be 32-bit or 64-bit architecture.</p>
        /// </summary>
        [Pure]
        public static T SetLocationOfBinary<T>(this T toolSettings, string locationOfBinary) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocationOfBinary = locationOfBinary;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.LocationOfBinary"/></em></p>
        ///   <p>In <a href="https://chocolatey.org/compare">Chocolatey for Business</a>, file is used for auto-detection (native installer, zip, patch/upgrade file, or remote url to download first) to completely create a package with proper silent arguments! Can be 32-bit or 64-bit architecture.</p>
        /// </summary>
        [Pure]
        public static T ResetLocationOfBinary<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocationOfBinary = null;
            return toolSettings;
        }
        #endregion
        #region LocationOfBinary64
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.LocationOfBinary64"/></em></p>
        ///   <p>Used when specifying both a 32-bit and a 64-bit file. Can be an installer or a zip, or remote url to download.</p>
        /// </summary>
        [Pure]
        public static T SetLocationOfBinary64<T>(this T toolSettings, string locationOfBinary64) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocationOfBinary64 = locationOfBinary64;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.LocationOfBinary64"/></em></p>
        ///   <p>Used when specifying both a 32-bit and a 64-bit file. Can be an installer or a zip, or remote url to download.</p>
        /// </summary>
        [Pure]
        public static T ResetLocationOfBinary64<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LocationOfBinary64 = null;
            return toolSettings;
        }
        #endregion
        #region UseOriginalFilesLocation
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.UseOriginalFilesLocation"/></em></p>
        ///   <p>When using file or url, use the original location in packaging.</p>
        /// </summary>
        [Pure]
        public static T SetUseOriginalFilesLocation<T>(this T toolSettings, bool? useOriginalFilesLocation) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseOriginalFilesLocation = useOriginalFilesLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.UseOriginalFilesLocation"/></em></p>
        ///   <p>When using file or url, use the original location in packaging.</p>
        /// </summary>
        [Pure]
        public static T ResetUseOriginalFilesLocation<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseOriginalFilesLocation = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.UseOriginalFilesLocation"/></em></p>
        ///   <p>When using file or url, use the original location in packaging.</p>
        /// </summary>
        [Pure]
        public static T EnableUseOriginalFilesLocation<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseOriginalFilesLocation = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.UseOriginalFilesLocation"/></em></p>
        ///   <p>When using file or url, use the original location in packaging.</p>
        /// </summary>
        [Pure]
        public static T DisableUseOriginalFilesLocation<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseOriginalFilesLocation = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.UseOriginalFilesLocation"/></em></p>
        ///   <p>When using file or url, use the original location in packaging.</p>
        /// </summary>
        [Pure]
        public static T ToggleUseOriginalFilesLocation<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseOriginalFilesLocation = !toolSettings.UseOriginalFilesLocation;
            return toolSettings;
        }
        #endregion
        #region Checksum
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.Checksum"/></em></p>
        ///   <p>Checksum to verify File/Url with. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetChecksum<T>(this T toolSettings, string checksum) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Checksum = checksum;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.Checksum"/></em></p>
        ///   <p>Checksum to verify File/Url with. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetChecksum<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Checksum = null;
            return toolSettings;
        }
        #endregion
        #region Checksum64
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.Checksum64"/></em></p>
        ///   <p>Checksum to verify File64/Url64 with. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T SetChecksum64<T>(this T toolSettings, string checksum64) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Checksum64 = checksum64;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.Checksum64"/></em></p>
        ///   <p>Checksum to verify File64/Url64 with. Defaults to empty.</p>
        /// </summary>
        [Pure]
        public static T ResetChecksum64<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Checksum64 = null;
            return toolSettings;
        }
        #endregion
        #region ChecksumType
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.ChecksumType"/></em></p>
        ///   <p>checksum type for File/Url (and optional separate 64-bit files when specifying both). Used in conjunction with Download Checksum and Download Checksum 64-bit. Available values are 'md5', 'sha1', 'sha256' or 'sha512'. Defaults to 'sha256'.</p>
        /// </summary>
        [Pure]
        public static T SetChecksumType<T>(this T toolSettings, string checksumType) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChecksumType = checksumType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.ChecksumType"/></em></p>
        ///   <p>checksum type for File/Url (and optional separate 64-bit files when specifying both). Used in conjunction with Download Checksum and Download Checksum 64-bit. Available values are 'md5', 'sha1', 'sha256' or 'sha512'. Defaults to 'sha256'.</p>
        /// </summary>
        [Pure]
        public static T ResetChecksumType<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChecksumType = null;
            return toolSettings;
        }
        #endregion
        #region PauseOnError
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.PauseOnError"/></em></p>
        ///   <p>Pause when there is an error with creating the package.</p>
        /// </summary>
        [Pure]
        public static T SetPauseOnError<T>(this T toolSettings, bool? pauseOnError) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PauseOnError = pauseOnError;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.PauseOnError"/></em></p>
        ///   <p>Pause when there is an error with creating the package.</p>
        /// </summary>
        [Pure]
        public static T ResetPauseOnError<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PauseOnError = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.PauseOnError"/></em></p>
        ///   <p>Pause when there is an error with creating the package.</p>
        /// </summary>
        [Pure]
        public static T EnablePauseOnError<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PauseOnError = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.PauseOnError"/></em></p>
        ///   <p>Pause when there is an error with creating the package.</p>
        /// </summary>
        [Pure]
        public static T DisablePauseOnError<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PauseOnError = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.PauseOnError"/></em></p>
        ///   <p>Pause when there is an error with creating the package.</p>
        /// </summary>
        [Pure]
        public static T TogglePauseOnError<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PauseOnError = !toolSettings.PauseOnError;
            return toolSettings;
        }
        #endregion
        #region BuildPackage
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.BuildPackage"/></em></p>
        ///   <p>Attempt to compile the package after creating it.</p>
        /// </summary>
        [Pure]
        public static T SetBuildPackage<T>(this T toolSettings, bool? buildPackage) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildPackage = buildPackage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.BuildPackage"/></em></p>
        ///   <p>Attempt to compile the package after creating it.</p>
        /// </summary>
        [Pure]
        public static T ResetBuildPackage<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildPackage = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.BuildPackage"/></em></p>
        ///   <p>Attempt to compile the package after creating it.</p>
        /// </summary>
        [Pure]
        public static T EnableBuildPackage<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildPackage = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.BuildPackage"/></em></p>
        ///   <p>Attempt to compile the package after creating it.</p>
        /// </summary>
        [Pure]
        public static T DisableBuildPackage<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildPackage = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.BuildPackage"/></em></p>
        ///   <p>Attempt to compile the package after creating it.</p>
        /// </summary>
        [Pure]
        public static T ToggleBuildPackage<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildPackage = !toolSettings.BuildPackage;
            return toolSettings;
        }
        #endregion
        #region GenerateFromInstalledSoftware
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/></em></p>
        ///   <p>Generate packages from the installed software on a system (does not handle dependencies).</p>
        /// </summary>
        [Pure]
        public static T SetGenerateFromInstalledSoftware<T>(this T toolSettings, bool? generateFromInstalledSoftware) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateFromInstalledSoftware = generateFromInstalledSoftware;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/></em></p>
        ///   <p>Generate packages from the installed software on a system (does not handle dependencies).</p>
        /// </summary>
        [Pure]
        public static T ResetGenerateFromInstalledSoftware<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateFromInstalledSoftware = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/></em></p>
        ///   <p>Generate packages from the installed software on a system (does not handle dependencies).</p>
        /// </summary>
        [Pure]
        public static T EnableGenerateFromInstalledSoftware<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateFromInstalledSoftware = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/></em></p>
        ///   <p>Generate packages from the installed software on a system (does not handle dependencies).</p>
        /// </summary>
        [Pure]
        public static T DisableGenerateFromInstalledSoftware<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateFromInstalledSoftware = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/></em></p>
        ///   <p>Generate packages from the installed software on a system (does not handle dependencies).</p>
        /// </summary>
        [Pure]
        public static T ToggleGenerateFromInstalledSoftware<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateFromInstalledSoftware = !toolSettings.GenerateFromInstalledSoftware;
            return toolSettings;
        }
        #endregion
        #region GenerateForCommunity
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.GenerateForCommunity"/></em></p>
        ///   <p>Generate the package for community use.</p>
        /// </summary>
        [Pure]
        public static T SetGenerateForCommunity<T>(this T toolSettings, bool? generateForCommunity) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateForCommunity = generateForCommunity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.GenerateForCommunity"/></em></p>
        ///   <p>Generate the package for community use.</p>
        /// </summary>
        [Pure]
        public static T ResetGenerateForCommunity<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateForCommunity = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.GenerateForCommunity"/></em></p>
        ///   <p>Generate the package for community use.</p>
        /// </summary>
        [Pure]
        public static T EnableGenerateForCommunity<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateForCommunity = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.GenerateForCommunity"/></em></p>
        ///   <p>Generate the package for community use.</p>
        /// </summary>
        [Pure]
        public static T DisableGenerateForCommunity<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateForCommunity = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.GenerateForCommunity"/></em></p>
        ///   <p>Generate the package for community use.</p>
        /// </summary>
        [Pure]
        public static T ToggleGenerateForCommunity<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateForCommunity = !toolSettings.GenerateForCommunity;
            return toolSettings;
        }
        #endregion
        #region RemoveArchitectureFromName
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.RemoveArchitectureFromName"/></em></p>
        ///   <p>Remove x86, x64, 64-bit, etc from the package id. Default setting is to remove architecture.</p>
        /// </summary>
        [Pure]
        public static T SetRemoveArchitectureFromName<T>(this T toolSettings, bool? removeArchitectureFromName) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RemoveArchitectureFromName = removeArchitectureFromName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.RemoveArchitectureFromName"/></em></p>
        ///   <p>Remove x86, x64, 64-bit, etc from the package id. Default setting is to remove architecture.</p>
        /// </summary>
        [Pure]
        public static T ResetRemoveArchitectureFromName<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RemoveArchitectureFromName = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.RemoveArchitectureFromName"/></em></p>
        ///   <p>Remove x86, x64, 64-bit, etc from the package id. Default setting is to remove architecture.</p>
        /// </summary>
        [Pure]
        public static T EnableRemoveArchitectureFromName<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RemoveArchitectureFromName = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.RemoveArchitectureFromName"/></em></p>
        ///   <p>Remove x86, x64, 64-bit, etc from the package id. Default setting is to remove architecture.</p>
        /// </summary>
        [Pure]
        public static T DisableRemoveArchitectureFromName<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RemoveArchitectureFromName = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.RemoveArchitectureFromName"/></em></p>
        ///   <p>Remove x86, x64, 64-bit, etc from the package id. Default setting is to remove architecture.</p>
        /// </summary>
        [Pure]
        public static T ToggleRemoveArchitectureFromName<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RemoveArchitectureFromName = !toolSettings.RemoveArchitectureFromName;
            return toolSettings;
        }
        #endregion
        #region IncludeArchitectureInName
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.IncludeArchitectureInName"/></em></p>
        ///   <p>Leave x86, x64, 64-bit, etc as part of the package id. Default setting is to remove architecture.</p>
        /// </summary>
        [Pure]
        public static T SetIncludeArchitectureInName<T>(this T toolSettings, bool? includeArchitectureInName) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeArchitectureInName = includeArchitectureInName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.IncludeArchitectureInName"/></em></p>
        ///   <p>Leave x86, x64, 64-bit, etc as part of the package id. Default setting is to remove architecture.</p>
        /// </summary>
        [Pure]
        public static T ResetIncludeArchitectureInName<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeArchitectureInName = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.IncludeArchitectureInName"/></em></p>
        ///   <p>Leave x86, x64, 64-bit, etc as part of the package id. Default setting is to remove architecture.</p>
        /// </summary>
        [Pure]
        public static T EnableIncludeArchitectureInName<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeArchitectureInName = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.IncludeArchitectureInName"/></em></p>
        ///   <p>Leave x86, x64, 64-bit, etc as part of the package id. Default setting is to remove architecture.</p>
        /// </summary>
        [Pure]
        public static T DisableIncludeArchitectureInName<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeArchitectureInName = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.IncludeArchitectureInName"/></em></p>
        ///   <p>Leave x86, x64, 64-bit, etc as part of the package id. Default setting is to remove architecture.</p>
        /// </summary>
        [Pure]
        public static T ToggleIncludeArchitectureInName<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeArchitectureInName = !toolSettings.IncludeArchitectureInName;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.Debug"/></em></p>
        ///   <p>Show debug messaging.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.Verbose"/></em></p>
        ///   <p>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Trace
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T SetTrace<T>(this T toolSettings, bool? trace) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = trace;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T ResetTrace<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T EnableTrace<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T DisableTrace<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.Trace"/></em></p>
        ///   <p>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</p>
        /// </summary>
        [Pure]
        public static T ToggleTrace<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = !toolSettings.Trace;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T SetNoColor<T>(this T toolSettings, bool? noColor) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T ResetNoColor<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T EnableNoColor<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T DisableNoColor<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.NoColor"/></em></p>
        ///   <p>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoColor<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region AcceptLicense
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T SetAcceptLicense<T>(this T toolSettings, bool? acceptLicense) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = acceptLicense;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T ResetAcceptLicense<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T EnableAcceptLicense<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T DisableAcceptLicense<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.AcceptLicense"/></em></p>
        ///   <p>Accept license dialogs automatically. Reserved for future use.</p>
        /// </summary>
        [Pure]
        public static T ToggleAcceptLicense<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptLicense = !toolSettings.AcceptLicense;
            return toolSettings;
        }
        #endregion
        #region Confirm
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T SetConfirm<T>(this T toolSettings, bool? confirm) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = confirm;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T ResetConfirm<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T EnableConfirm<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T DisableConfirm<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.Confirm"/></em></p>
        ///   <p>Chooses affirmative answer instead of prompting. Implies --accept-license</p>
        /// </summary>
        [Pure]
        public static T ToggleConfirm<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Confirm = !toolSettings.Confirm;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.Force"/></em></p>
        ///   <p>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region LimitOutput
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T SetLimitOutput<T>(this T toolSettings, bool? limitOutput) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = limitOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T ResetLimitOutput<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T EnableLimitOutput<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T DisableLimitOutput<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.LimitOutput"/></em></p>
        ///   <p>Limit the output to essential information</p>
        /// </summary>
        [Pure]
        public static T ToggleLimitOutput<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LimitOutput = !toolSettings.LimitOutput;
            return toolSettings;
        }
        #endregion
        #region CommandExecutionTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.CommandExecutionTimeout"/></em></p>
        ///   <p>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T SetCommandExecutionTimeout<T>(this T toolSettings, int? commandExecutionTimeout) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommandExecutionTimeout = commandExecutionTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.CommandExecutionTimeout"/></em></p>
        ///   <p>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</p>
        /// </summary>
        [Pure]
        public static T ResetCommandExecutionTimeout<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommandExecutionTimeout = null;
            return toolSettings;
        }
        #endregion
        #region CacheLocation
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.CacheLocation"/></em></p>
        ///   <p>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</p>
        /// </summary>
        [Pure]
        public static T SetCacheLocation<T>(this T toolSettings, string cacheLocation) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheLocation = cacheLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.CacheLocation"/></em></p>
        ///   <p>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</p>
        /// </summary>
        [Pure]
        public static T ResetCacheLocation<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheLocation = null;
            return toolSettings;
        }
        #endregion
        #region AllowUnofficialBuild
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T SetAllowUnofficialBuild<T>(this T toolSettings, bool? allowUnofficialBuild) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = allowUnofficialBuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T ResetAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T EnableAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T DisableAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.AllowUnofficialBuild"/></em></p>
        ///   <p>When not using the official build you must set this flag for choco to continue.</p>
        /// </summary>
        [Pure]
        public static T ToggleAllowUnofficialBuild<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowUnofficialBuild = !toolSettings.AllowUnofficialBuild;
            return toolSettings;
        }
        #endregion
        #region FailOnStandardError
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T SetFailOnStandardError<T>(this T toolSettings, bool? failOnStandardError) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = failOnStandardError;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T ResetFailOnStandardError<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T EnableFailOnStandardError<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T DisableFailOnStandardError<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.FailOnStandardError"/></em></p>
        ///   <p>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</p>
        /// </summary>
        [Pure]
        public static T ToggleFailOnStandardError<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnStandardError = !toolSettings.FailOnStandardError;
            return toolSettings;
        }
        #endregion
        #region UseSystemPowerShell
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T SetUseSystemPowerShell<T>(this T toolSettings, bool? useSystemPowerShell) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = useSystemPowerShell;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T ResetUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T EnableUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T DisableUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.UseSystemPowerShell"/></em></p>
        ///   <p>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</p>
        /// </summary>
        [Pure]
        public static T ToggleUseSystemPowerShell<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSystemPowerShell = !toolSettings.UseSystemPowerShell;
            return toolSettings;
        }
        #endregion
        #region DoNotShowProgress
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T SetDoNotShowProgress<T>(this T toolSettings, bool? doNotShowProgress) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = doNotShowProgress;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T ResetDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T EnableDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T DisableDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.DoNotShowProgress"/></em></p>
        ///   <p>Do not show download progress percentages.</p>
        /// </summary>
        [Pure]
        public static T ToggleDoNotShowProgress<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DoNotShowProgress = !toolSettings.DoNotShowProgress;
            return toolSettings;
        }
        #endregion
        #region Proxy
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.Proxy"/></em></p>
        ///   <p>Explicit proxy location. Overrides the default proxy location of ''.</p>
        /// </summary>
        [Pure]
        public static T SetProxy<T>(this T toolSettings, string proxy) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = proxy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.Proxy"/></em></p>
        ///   <p>Explicit proxy location. Overrides the default proxy location of ''.</p>
        /// </summary>
        [Pure]
        public static T ResetProxy<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = null;
            return toolSettings;
        }
        #endregion
        #region ProxyUserName
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.ProxyUserName"/></em></p>
        ///   <p>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</p>
        /// </summary>
        [Pure]
        public static T SetProxyUserName<T>(this T toolSettings, string proxyUserName) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUserName = proxyUserName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.ProxyUserName"/></em></p>
        ///   <p>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</p>
        /// </summary>
        [Pure]
        public static T ResetProxyUserName<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUserName = null;
            return toolSettings;
        }
        #endregion
        #region ProxyPassword
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.ProxyPassword"/></em></p>
        ///   <p>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</p>
        /// </summary>
        [Pure]
        public static T SetProxyPassword<T>(this T toolSettings, [Secret] string proxyPassword) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = proxyPassword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.ProxyPassword"/></em></p>
        ///   <p>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</p>
        /// </summary>
        [Pure]
        public static T ResetProxyPassword<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = null;
            return toolSettings;
        }
        #endregion
        #region ProxyBypassList
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.ProxyBypassList"/> to a new list</em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal = proxyBypassList.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.ProxyBypassList"/> to a new list</em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal = proxyBypassList.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ChocolateyNewSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T AddProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.AddRange(proxyBypassList);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ChocolateyNewSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T AddProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.AddRange(proxyBypassList);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ChocolateyNewSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ClearProxyBypassList<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassListInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ChocolateyNewSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T RemoveProxyBypassList<T>(this T toolSettings, params string[] proxyBypassList) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(proxyBypassList);
            toolSettings.ProxyBypassListInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ChocolateyNewSettings.ProxyBypassList"/></em></p>
        ///   <p>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T RemoveProxyBypassList<T>(this T toolSettings, IEnumerable<string> proxyBypassList) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(proxyBypassList);
            toolSettings.ProxyBypassListInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ProxyBypassOnLocal
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T SetProxyBypassOnLocal<T>(this T toolSettings, bool? proxyBypassOnLocal) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = proxyBypassOnLocal;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ResetProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ChocolateyNewSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T EnableProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ChocolateyNewSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T DisableProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ChocolateyNewSettings.ProxyBypassOnLocal"/></em></p>
        ///   <p>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</p>
        /// </summary>
        [Pure]
        public static T ToggleProxyBypassOnLocal<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyBypassOnLocal = !toolSettings.ProxyBypassOnLocal;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.LogFile"/></em></p>
        ///   <p>Log File to output to in addition to regular loggers.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ChocolateyNewSettings.LogFile"/></em></p>
        ///   <p>Log File to output to in addition to regular loggers.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="ChocolateyNewSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>You can pass arbitrary property value pairs through to templates. This really unlocks your ability to create packages automatically!</p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, object> properties) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ChocolateyNewSettings.Properties"/></em></p>
        ///   <p>You can pass arbitrary property value pairs through to templates. This really unlocks your ability to create packages automatically!</p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="ChocolateyNewSettings.Properties"/></em></p>
        ///   <p>You can pass arbitrary property value pairs through to templates. This really unlocks your ability to create packages automatically!</p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="ChocolateyNewSettings.Properties"/></em></p>
        ///   <p>You can pass arbitrary property value pairs through to templates. This really unlocks your ability to create packages automatically!</p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="ChocolateyNewSettings.Properties"/></em></p>
        ///   <p>You can pass arbitrary property value pairs through to templates. This really unlocks your ability to create packages automatically!</p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : ChocolateyNewSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
