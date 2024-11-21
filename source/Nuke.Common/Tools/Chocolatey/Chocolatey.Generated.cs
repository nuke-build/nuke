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

namespace Nuke.Common.Tools.Chocolatey;

/// <summary><p>Chocolatey has the largest online registry of Windows packages. Chocolatey packages encapsulate everything required to manage a particular piece of software into one deployment artifact by wrapping installers, executables, zips, and/or scripts into a compiled package file.</p><p>For more details, visit the <a href="https://chocolatey.org/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[PathToolRequirement(PathExecutable)]
[PathTool(Executable = PathExecutable)]
public partial class ChocolateyTasks : ToolTasks, IRequirePathTool
{
    public static string ChocolateyPath => new ChocolateyTasks().GetToolPath();
    public const string PathExecutable = "choco";
    /// <summary><p>Chocolatey has the largest online registry of Windows packages. Chocolatey packages encapsulate everything required to manage a particular piece of software into one deployment artifact by wrapping installers, executables, zips, and/or scripts into a compiled package file.</p><p>For more details, visit the <a href="https://chocolatey.org/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> Chocolatey(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new ChocolateyTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Searches remote or local packages (alias for <c>list</c>).</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/search">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;filter&gt;</c> via <see cref="ChocolateySearchSettings.Filter"/></li><li><c>--accept-license</c> via <see cref="ChocolateySearchSettings.AcceptLicense"/></li><li><c>--all-versions</c> via <see cref="ChocolateySearchSettings.AllVersions"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateySearchSettings.AllowUnofficialBuild"/></li><li><c>--approved-only</c> via <see cref="ChocolateySearchSettings.ApprovedOnly"/></li><li><c>--by-id-only</c> via <see cref="ChocolateySearchSettings.ByIdOnly"/></li><li><c>--by-tag-only</c> via <see cref="ChocolateySearchSettings.ByTagOnly"/></li><li><c>--cache-location</c> via <see cref="ChocolateySearchSettings.CacheLocation"/></li><li><c>--cert</c> via <see cref="ChocolateySearchSettings.ClientCertificate"/></li><li><c>--certpassword</c> via <see cref="ChocolateySearchSettings.CertificatePassword"/></li><li><c>--confirm</c> via <see cref="ChocolateySearchSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateySearchSettings.Debug"/></li><li><c>--detailed</c> via <see cref="ChocolateySearchSettings.Detailed"/></li><li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/></li><li><c>--download-cache-only</c> via <see cref="ChocolateySearchSettings.DownloadCacheAvailable"/></li><li><c>--exact</c> via <see cref="ChocolateySearchSettings.Exact"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateySearchSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateySearchSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateySearchSettings.Force"/></li><li><c>--id-only</c> via <see cref="ChocolateySearchSettings.IdOnly"/></li><li><c>--id-starts-with</c> via <see cref="ChocolateySearchSettings.IdStartsWith"/></li><li><c>--include-programs</c> via <see cref="ChocolateySearchSettings.IncludePrograms"/></li><li><c>--limit-output</c> via <see cref="ChocolateySearchSettings.LimitOutput"/></li><li><c>--local-only</c> via <see cref="ChocolateySearchSettings.LocalOnly"/></li><li><c>--log-file</c> via <see cref="ChocolateySearchSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateySearchSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateySearchSettings.DoNotShowProgress"/></li><li><c>--not-broken</c> via <see cref="ChocolateySearchSettings.NotBroken"/></li><li><c>--order-by-popularity</c> via <see cref="ChocolateySearchSettings.OrderByPopularity"/></li><li><c>--page</c> via <see cref="ChocolateySearchSettings.Page"/></li><li><c>--page-size</c> via <see cref="ChocolateySearchSettings.PageSize"/></li><li><c>--password</c> via <see cref="ChocolateySearchSettings.Password"/></li><li><c>--prerelease</c> via <see cref="ChocolateySearchSettings.Prerelease"/></li><li><c>--proxy</c> via <see cref="ChocolateySearchSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateySearchSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateySearchSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateySearchSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateySearchSettings.ProxyUserName"/></li><li><c>--show-audit-info</c> via <see cref="ChocolateySearchSettings.ShowAuditInformation"/></li><li><c>--source</c> via <see cref="ChocolateySearchSettings.Source"/></li><li><c>--trace</c> via <see cref="ChocolateySearchSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateySearchSettings.UseSystemPowerShell"/></li><li><c>--user</c> via <see cref="ChocolateySearchSettings.User"/></li><li><c>--verbose</c> via <see cref="ChocolateySearchSettings.Verbose"/></li><li><c>--version</c> via <see cref="ChocolateySearchSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ChocolateySearch(ChocolateySearchSettings options = null) => new ChocolateyTasks().Run(options);
    /// <summary><p>Searches remote or local packages (alias for <c>list</c>).</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/search">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;filter&gt;</c> via <see cref="ChocolateySearchSettings.Filter"/></li><li><c>--accept-license</c> via <see cref="ChocolateySearchSettings.AcceptLicense"/></li><li><c>--all-versions</c> via <see cref="ChocolateySearchSettings.AllVersions"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateySearchSettings.AllowUnofficialBuild"/></li><li><c>--approved-only</c> via <see cref="ChocolateySearchSettings.ApprovedOnly"/></li><li><c>--by-id-only</c> via <see cref="ChocolateySearchSettings.ByIdOnly"/></li><li><c>--by-tag-only</c> via <see cref="ChocolateySearchSettings.ByTagOnly"/></li><li><c>--cache-location</c> via <see cref="ChocolateySearchSettings.CacheLocation"/></li><li><c>--cert</c> via <see cref="ChocolateySearchSettings.ClientCertificate"/></li><li><c>--certpassword</c> via <see cref="ChocolateySearchSettings.CertificatePassword"/></li><li><c>--confirm</c> via <see cref="ChocolateySearchSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateySearchSettings.Debug"/></li><li><c>--detailed</c> via <see cref="ChocolateySearchSettings.Detailed"/></li><li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/></li><li><c>--download-cache-only</c> via <see cref="ChocolateySearchSettings.DownloadCacheAvailable"/></li><li><c>--exact</c> via <see cref="ChocolateySearchSettings.Exact"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateySearchSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateySearchSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateySearchSettings.Force"/></li><li><c>--id-only</c> via <see cref="ChocolateySearchSettings.IdOnly"/></li><li><c>--id-starts-with</c> via <see cref="ChocolateySearchSettings.IdStartsWith"/></li><li><c>--include-programs</c> via <see cref="ChocolateySearchSettings.IncludePrograms"/></li><li><c>--limit-output</c> via <see cref="ChocolateySearchSettings.LimitOutput"/></li><li><c>--local-only</c> via <see cref="ChocolateySearchSettings.LocalOnly"/></li><li><c>--log-file</c> via <see cref="ChocolateySearchSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateySearchSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateySearchSettings.DoNotShowProgress"/></li><li><c>--not-broken</c> via <see cref="ChocolateySearchSettings.NotBroken"/></li><li><c>--order-by-popularity</c> via <see cref="ChocolateySearchSettings.OrderByPopularity"/></li><li><c>--page</c> via <see cref="ChocolateySearchSettings.Page"/></li><li><c>--page-size</c> via <see cref="ChocolateySearchSettings.PageSize"/></li><li><c>--password</c> via <see cref="ChocolateySearchSettings.Password"/></li><li><c>--prerelease</c> via <see cref="ChocolateySearchSettings.Prerelease"/></li><li><c>--proxy</c> via <see cref="ChocolateySearchSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateySearchSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateySearchSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateySearchSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateySearchSettings.ProxyUserName"/></li><li><c>--show-audit-info</c> via <see cref="ChocolateySearchSettings.ShowAuditInformation"/></li><li><c>--source</c> via <see cref="ChocolateySearchSettings.Source"/></li><li><c>--trace</c> via <see cref="ChocolateySearchSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateySearchSettings.UseSystemPowerShell"/></li><li><c>--user</c> via <see cref="ChocolateySearchSettings.User"/></li><li><c>--verbose</c> via <see cref="ChocolateySearchSettings.Verbose"/></li><li><c>--version</c> via <see cref="ChocolateySearchSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ChocolateySearch(Configure<ChocolateySearchSettings> configurator) => new ChocolateyTasks().Run(configurator.Invoke(new ChocolateySearchSettings()));
    /// <summary><p>Searches remote or local packages (alias for <c>list</c>).</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/search">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;filter&gt;</c> via <see cref="ChocolateySearchSettings.Filter"/></li><li><c>--accept-license</c> via <see cref="ChocolateySearchSettings.AcceptLicense"/></li><li><c>--all-versions</c> via <see cref="ChocolateySearchSettings.AllVersions"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateySearchSettings.AllowUnofficialBuild"/></li><li><c>--approved-only</c> via <see cref="ChocolateySearchSettings.ApprovedOnly"/></li><li><c>--by-id-only</c> via <see cref="ChocolateySearchSettings.ByIdOnly"/></li><li><c>--by-tag-only</c> via <see cref="ChocolateySearchSettings.ByTagOnly"/></li><li><c>--cache-location</c> via <see cref="ChocolateySearchSettings.CacheLocation"/></li><li><c>--cert</c> via <see cref="ChocolateySearchSettings.ClientCertificate"/></li><li><c>--certpassword</c> via <see cref="ChocolateySearchSettings.CertificatePassword"/></li><li><c>--confirm</c> via <see cref="ChocolateySearchSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateySearchSettings.Debug"/></li><li><c>--detailed</c> via <see cref="ChocolateySearchSettings.Detailed"/></li><li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/></li><li><c>--download-cache-only</c> via <see cref="ChocolateySearchSettings.DownloadCacheAvailable"/></li><li><c>--exact</c> via <see cref="ChocolateySearchSettings.Exact"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateySearchSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateySearchSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateySearchSettings.Force"/></li><li><c>--id-only</c> via <see cref="ChocolateySearchSettings.IdOnly"/></li><li><c>--id-starts-with</c> via <see cref="ChocolateySearchSettings.IdStartsWith"/></li><li><c>--include-programs</c> via <see cref="ChocolateySearchSettings.IncludePrograms"/></li><li><c>--limit-output</c> via <see cref="ChocolateySearchSettings.LimitOutput"/></li><li><c>--local-only</c> via <see cref="ChocolateySearchSettings.LocalOnly"/></li><li><c>--log-file</c> via <see cref="ChocolateySearchSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateySearchSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateySearchSettings.DoNotShowProgress"/></li><li><c>--not-broken</c> via <see cref="ChocolateySearchSettings.NotBroken"/></li><li><c>--order-by-popularity</c> via <see cref="ChocolateySearchSettings.OrderByPopularity"/></li><li><c>--page</c> via <see cref="ChocolateySearchSettings.Page"/></li><li><c>--page-size</c> via <see cref="ChocolateySearchSettings.PageSize"/></li><li><c>--password</c> via <see cref="ChocolateySearchSettings.Password"/></li><li><c>--prerelease</c> via <see cref="ChocolateySearchSettings.Prerelease"/></li><li><c>--proxy</c> via <see cref="ChocolateySearchSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateySearchSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateySearchSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateySearchSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateySearchSettings.ProxyUserName"/></li><li><c>--show-audit-info</c> via <see cref="ChocolateySearchSettings.ShowAuditInformation"/></li><li><c>--source</c> via <see cref="ChocolateySearchSettings.Source"/></li><li><c>--trace</c> via <see cref="ChocolateySearchSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateySearchSettings.UseSystemPowerShell"/></li><li><c>--user</c> via <see cref="ChocolateySearchSettings.User"/></li><li><c>--verbose</c> via <see cref="ChocolateySearchSettings.Verbose"/></li><li><c>--version</c> via <see cref="ChocolateySearchSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(ChocolateySearchSettings Settings, IReadOnlyCollection<Output> Output)> ChocolateySearch(CombinatorialConfigure<ChocolateySearchSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(ChocolateySearch, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Lists remote or local packages.</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/list">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;filter&gt;</c> via <see cref="ChocolateyListSettings.Filter"/></li><li><c>--accept-license</c> via <see cref="ChocolateyListSettings.AcceptLicense"/></li><li><c>--all-versions</c> via <see cref="ChocolateyListSettings.AllVersions"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyListSettings.AllowUnofficialBuild"/></li><li><c>--approved-only</c> via <see cref="ChocolateyListSettings.ApprovedOnly"/></li><li><c>--by-id-only</c> via <see cref="ChocolateyListSettings.ByIdOnly"/></li><li><c>--by-tag-only</c> via <see cref="ChocolateyListSettings.ByTagOnly"/></li><li><c>--cache-location</c> via <see cref="ChocolateyListSettings.CacheLocation"/></li><li><c>--cert</c> via <see cref="ChocolateyListSettings.ClientCertificate"/></li><li><c>--certpassword</c> via <see cref="ChocolateyListSettings.CertificatePassword"/></li><li><c>--confirm</c> via <see cref="ChocolateyListSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyListSettings.Debug"/></li><li><c>--detailed</c> via <see cref="ChocolateyListSettings.Detailed"/></li><li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/></li><li><c>--download-cache-only</c> via <see cref="ChocolateyListSettings.DownloadCacheAvailable"/></li><li><c>--exact</c> via <see cref="ChocolateyListSettings.Exact"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyListSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyListSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateyListSettings.Force"/></li><li><c>--id-only</c> via <see cref="ChocolateyListSettings.IdOnly"/></li><li><c>--id-starts-with</c> via <see cref="ChocolateyListSettings.IdStartsWith"/></li><li><c>--include-programs</c> via <see cref="ChocolateyListSettings.IncludePrograms"/></li><li><c>--limit-output</c> via <see cref="ChocolateyListSettings.LimitOutput"/></li><li><c>--local-only</c> via <see cref="ChocolateyListSettings.LocalOnly"/></li><li><c>--log-file</c> via <see cref="ChocolateyListSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateyListSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyListSettings.DoNotShowProgress"/></li><li><c>--not-broken</c> via <see cref="ChocolateyListSettings.NotBroken"/></li><li><c>--order-by-popularity</c> via <see cref="ChocolateyListSettings.OrderByPopularity"/></li><li><c>--page</c> via <see cref="ChocolateyListSettings.Page"/></li><li><c>--page-size</c> via <see cref="ChocolateyListSettings.PageSize"/></li><li><c>--password</c> via <see cref="ChocolateyListSettings.Password"/></li><li><c>--prerelease</c> via <see cref="ChocolateyListSettings.Prerelease"/></li><li><c>--proxy</c> via <see cref="ChocolateyListSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyListSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyListSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyListSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyListSettings.ProxyUserName"/></li><li><c>--show-audit-info</c> via <see cref="ChocolateyListSettings.ShowAuditInformation"/></li><li><c>--source</c> via <see cref="ChocolateyListSettings.Source"/></li><li><c>--trace</c> via <see cref="ChocolateyListSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyListSettings.UseSystemPowerShell"/></li><li><c>--user</c> via <see cref="ChocolateyListSettings.User"/></li><li><c>--verbose</c> via <see cref="ChocolateyListSettings.Verbose"/></li><li><c>--version</c> via <see cref="ChocolateyListSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ChocolateyList(ChocolateyListSettings options = null) => new ChocolateyTasks().Run(options);
    /// <summary><p>Lists remote or local packages.</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/list">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;filter&gt;</c> via <see cref="ChocolateyListSettings.Filter"/></li><li><c>--accept-license</c> via <see cref="ChocolateyListSettings.AcceptLicense"/></li><li><c>--all-versions</c> via <see cref="ChocolateyListSettings.AllVersions"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyListSettings.AllowUnofficialBuild"/></li><li><c>--approved-only</c> via <see cref="ChocolateyListSettings.ApprovedOnly"/></li><li><c>--by-id-only</c> via <see cref="ChocolateyListSettings.ByIdOnly"/></li><li><c>--by-tag-only</c> via <see cref="ChocolateyListSettings.ByTagOnly"/></li><li><c>--cache-location</c> via <see cref="ChocolateyListSettings.CacheLocation"/></li><li><c>--cert</c> via <see cref="ChocolateyListSettings.ClientCertificate"/></li><li><c>--certpassword</c> via <see cref="ChocolateyListSettings.CertificatePassword"/></li><li><c>--confirm</c> via <see cref="ChocolateyListSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyListSettings.Debug"/></li><li><c>--detailed</c> via <see cref="ChocolateyListSettings.Detailed"/></li><li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/></li><li><c>--download-cache-only</c> via <see cref="ChocolateyListSettings.DownloadCacheAvailable"/></li><li><c>--exact</c> via <see cref="ChocolateyListSettings.Exact"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyListSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyListSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateyListSettings.Force"/></li><li><c>--id-only</c> via <see cref="ChocolateyListSettings.IdOnly"/></li><li><c>--id-starts-with</c> via <see cref="ChocolateyListSettings.IdStartsWith"/></li><li><c>--include-programs</c> via <see cref="ChocolateyListSettings.IncludePrograms"/></li><li><c>--limit-output</c> via <see cref="ChocolateyListSettings.LimitOutput"/></li><li><c>--local-only</c> via <see cref="ChocolateyListSettings.LocalOnly"/></li><li><c>--log-file</c> via <see cref="ChocolateyListSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateyListSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyListSettings.DoNotShowProgress"/></li><li><c>--not-broken</c> via <see cref="ChocolateyListSettings.NotBroken"/></li><li><c>--order-by-popularity</c> via <see cref="ChocolateyListSettings.OrderByPopularity"/></li><li><c>--page</c> via <see cref="ChocolateyListSettings.Page"/></li><li><c>--page-size</c> via <see cref="ChocolateyListSettings.PageSize"/></li><li><c>--password</c> via <see cref="ChocolateyListSettings.Password"/></li><li><c>--prerelease</c> via <see cref="ChocolateyListSettings.Prerelease"/></li><li><c>--proxy</c> via <see cref="ChocolateyListSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyListSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyListSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyListSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyListSettings.ProxyUserName"/></li><li><c>--show-audit-info</c> via <see cref="ChocolateyListSettings.ShowAuditInformation"/></li><li><c>--source</c> via <see cref="ChocolateyListSettings.Source"/></li><li><c>--trace</c> via <see cref="ChocolateyListSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyListSettings.UseSystemPowerShell"/></li><li><c>--user</c> via <see cref="ChocolateyListSettings.User"/></li><li><c>--verbose</c> via <see cref="ChocolateyListSettings.Verbose"/></li><li><c>--version</c> via <see cref="ChocolateyListSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ChocolateyList(Configure<ChocolateyListSettings> configurator) => new ChocolateyTasks().Run(configurator.Invoke(new ChocolateyListSettings()));
    /// <summary><p>Lists remote or local packages.</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/list">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;filter&gt;</c> via <see cref="ChocolateyListSettings.Filter"/></li><li><c>--accept-license</c> via <see cref="ChocolateyListSettings.AcceptLicense"/></li><li><c>--all-versions</c> via <see cref="ChocolateyListSettings.AllVersions"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyListSettings.AllowUnofficialBuild"/></li><li><c>--approved-only</c> via <see cref="ChocolateyListSettings.ApprovedOnly"/></li><li><c>--by-id-only</c> via <see cref="ChocolateyListSettings.ByIdOnly"/></li><li><c>--by-tag-only</c> via <see cref="ChocolateyListSettings.ByTagOnly"/></li><li><c>--cache-location</c> via <see cref="ChocolateyListSettings.CacheLocation"/></li><li><c>--cert</c> via <see cref="ChocolateyListSettings.ClientCertificate"/></li><li><c>--certpassword</c> via <see cref="ChocolateyListSettings.CertificatePassword"/></li><li><c>--confirm</c> via <see cref="ChocolateyListSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyListSettings.Debug"/></li><li><c>--detailed</c> via <see cref="ChocolateyListSettings.Detailed"/></li><li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/></li><li><c>--download-cache-only</c> via <see cref="ChocolateyListSettings.DownloadCacheAvailable"/></li><li><c>--exact</c> via <see cref="ChocolateyListSettings.Exact"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyListSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyListSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateyListSettings.Force"/></li><li><c>--id-only</c> via <see cref="ChocolateyListSettings.IdOnly"/></li><li><c>--id-starts-with</c> via <see cref="ChocolateyListSettings.IdStartsWith"/></li><li><c>--include-programs</c> via <see cref="ChocolateyListSettings.IncludePrograms"/></li><li><c>--limit-output</c> via <see cref="ChocolateyListSettings.LimitOutput"/></li><li><c>--local-only</c> via <see cref="ChocolateyListSettings.LocalOnly"/></li><li><c>--log-file</c> via <see cref="ChocolateyListSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateyListSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyListSettings.DoNotShowProgress"/></li><li><c>--not-broken</c> via <see cref="ChocolateyListSettings.NotBroken"/></li><li><c>--order-by-popularity</c> via <see cref="ChocolateyListSettings.OrderByPopularity"/></li><li><c>--page</c> via <see cref="ChocolateyListSettings.Page"/></li><li><c>--page-size</c> via <see cref="ChocolateyListSettings.PageSize"/></li><li><c>--password</c> via <see cref="ChocolateyListSettings.Password"/></li><li><c>--prerelease</c> via <see cref="ChocolateyListSettings.Prerelease"/></li><li><c>--proxy</c> via <see cref="ChocolateyListSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyListSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyListSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyListSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyListSettings.ProxyUserName"/></li><li><c>--show-audit-info</c> via <see cref="ChocolateyListSettings.ShowAuditInformation"/></li><li><c>--source</c> via <see cref="ChocolateyListSettings.Source"/></li><li><c>--trace</c> via <see cref="ChocolateyListSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyListSettings.UseSystemPowerShell"/></li><li><c>--user</c> via <see cref="ChocolateyListSettings.User"/></li><li><c>--verbose</c> via <see cref="ChocolateyListSettings.Verbose"/></li><li><c>--version</c> via <see cref="ChocolateyListSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(ChocolateyListSettings Settings, IReadOnlyCollection<Output> Output)> ChocolateyList(CombinatorialConfigure<ChocolateyListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(ChocolateyList, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Searches remote or local packages (alias for <c>search</c>).</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/find">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;filter&gt;</c> via <see cref="ChocolateyFindSettings.Filter"/></li><li><c>--accept-license</c> via <see cref="ChocolateyFindSettings.AcceptLicense"/></li><li><c>--all-versions</c> via <see cref="ChocolateyFindSettings.AllVersions"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyFindSettings.AllowUnofficialBuild"/></li><li><c>--approved-only</c> via <see cref="ChocolateyFindSettings.ApprovedOnly"/></li><li><c>--by-id-only</c> via <see cref="ChocolateyFindSettings.ByIdOnly"/></li><li><c>--by-tag-only</c> via <see cref="ChocolateyFindSettings.ByTagOnly"/></li><li><c>--cache-location</c> via <see cref="ChocolateyFindSettings.CacheLocation"/></li><li><c>--cert</c> via <see cref="ChocolateyFindSettings.ClientCertificate"/></li><li><c>--certpassword</c> via <see cref="ChocolateyFindSettings.CertificatePassword"/></li><li><c>--confirm</c> via <see cref="ChocolateyFindSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyFindSettings.Debug"/></li><li><c>--detailed</c> via <see cref="ChocolateyFindSettings.Detailed"/></li><li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/></li><li><c>--download-cache-only</c> via <see cref="ChocolateyFindSettings.DownloadCacheAvailable"/></li><li><c>--exact</c> via <see cref="ChocolateyFindSettings.Exact"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyFindSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyFindSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateyFindSettings.Force"/></li><li><c>--id-only</c> via <see cref="ChocolateyFindSettings.IdOnly"/></li><li><c>--id-starts-with</c> via <see cref="ChocolateyFindSettings.IdStartsWith"/></li><li><c>--include-programs</c> via <see cref="ChocolateyFindSettings.IncludePrograms"/></li><li><c>--limit-output</c> via <see cref="ChocolateyFindSettings.LimitOutput"/></li><li><c>--local-only</c> via <see cref="ChocolateyFindSettings.LocalOnly"/></li><li><c>--log-file</c> via <see cref="ChocolateyFindSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateyFindSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyFindSettings.DoNotShowProgress"/></li><li><c>--not-broken</c> via <see cref="ChocolateyFindSettings.NotBroken"/></li><li><c>--order-by-popularity</c> via <see cref="ChocolateyFindSettings.OrderByPopularity"/></li><li><c>--page</c> via <see cref="ChocolateyFindSettings.Page"/></li><li><c>--page-size</c> via <see cref="ChocolateyFindSettings.PageSize"/></li><li><c>--password</c> via <see cref="ChocolateyFindSettings.Password"/></li><li><c>--prerelease</c> via <see cref="ChocolateyFindSettings.Prerelease"/></li><li><c>--proxy</c> via <see cref="ChocolateyFindSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyFindSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyFindSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyFindSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyFindSettings.ProxyUserName"/></li><li><c>--show-audit-info</c> via <see cref="ChocolateyFindSettings.ShowAuditInformation"/></li><li><c>--source</c> via <see cref="ChocolateyFindSettings.Source"/></li><li><c>--trace</c> via <see cref="ChocolateyFindSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyFindSettings.UseSystemPowerShell"/></li><li><c>--user</c> via <see cref="ChocolateyFindSettings.User"/></li><li><c>--verbose</c> via <see cref="ChocolateyFindSettings.Verbose"/></li><li><c>--version</c> via <see cref="ChocolateyFindSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ChocolateyFind(ChocolateyFindSettings options = null) => new ChocolateyTasks().Run(options);
    /// <summary><p>Searches remote or local packages (alias for <c>search</c>).</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/find">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;filter&gt;</c> via <see cref="ChocolateyFindSettings.Filter"/></li><li><c>--accept-license</c> via <see cref="ChocolateyFindSettings.AcceptLicense"/></li><li><c>--all-versions</c> via <see cref="ChocolateyFindSettings.AllVersions"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyFindSettings.AllowUnofficialBuild"/></li><li><c>--approved-only</c> via <see cref="ChocolateyFindSettings.ApprovedOnly"/></li><li><c>--by-id-only</c> via <see cref="ChocolateyFindSettings.ByIdOnly"/></li><li><c>--by-tag-only</c> via <see cref="ChocolateyFindSettings.ByTagOnly"/></li><li><c>--cache-location</c> via <see cref="ChocolateyFindSettings.CacheLocation"/></li><li><c>--cert</c> via <see cref="ChocolateyFindSettings.ClientCertificate"/></li><li><c>--certpassword</c> via <see cref="ChocolateyFindSettings.CertificatePassword"/></li><li><c>--confirm</c> via <see cref="ChocolateyFindSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyFindSettings.Debug"/></li><li><c>--detailed</c> via <see cref="ChocolateyFindSettings.Detailed"/></li><li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/></li><li><c>--download-cache-only</c> via <see cref="ChocolateyFindSettings.DownloadCacheAvailable"/></li><li><c>--exact</c> via <see cref="ChocolateyFindSettings.Exact"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyFindSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyFindSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateyFindSettings.Force"/></li><li><c>--id-only</c> via <see cref="ChocolateyFindSettings.IdOnly"/></li><li><c>--id-starts-with</c> via <see cref="ChocolateyFindSettings.IdStartsWith"/></li><li><c>--include-programs</c> via <see cref="ChocolateyFindSettings.IncludePrograms"/></li><li><c>--limit-output</c> via <see cref="ChocolateyFindSettings.LimitOutput"/></li><li><c>--local-only</c> via <see cref="ChocolateyFindSettings.LocalOnly"/></li><li><c>--log-file</c> via <see cref="ChocolateyFindSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateyFindSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyFindSettings.DoNotShowProgress"/></li><li><c>--not-broken</c> via <see cref="ChocolateyFindSettings.NotBroken"/></li><li><c>--order-by-popularity</c> via <see cref="ChocolateyFindSettings.OrderByPopularity"/></li><li><c>--page</c> via <see cref="ChocolateyFindSettings.Page"/></li><li><c>--page-size</c> via <see cref="ChocolateyFindSettings.PageSize"/></li><li><c>--password</c> via <see cref="ChocolateyFindSettings.Password"/></li><li><c>--prerelease</c> via <see cref="ChocolateyFindSettings.Prerelease"/></li><li><c>--proxy</c> via <see cref="ChocolateyFindSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyFindSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyFindSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyFindSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyFindSettings.ProxyUserName"/></li><li><c>--show-audit-info</c> via <see cref="ChocolateyFindSettings.ShowAuditInformation"/></li><li><c>--source</c> via <see cref="ChocolateyFindSettings.Source"/></li><li><c>--trace</c> via <see cref="ChocolateyFindSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyFindSettings.UseSystemPowerShell"/></li><li><c>--user</c> via <see cref="ChocolateyFindSettings.User"/></li><li><c>--verbose</c> via <see cref="ChocolateyFindSettings.Verbose"/></li><li><c>--version</c> via <see cref="ChocolateyFindSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ChocolateyFind(Configure<ChocolateyFindSettings> configurator) => new ChocolateyTasks().Run(configurator.Invoke(new ChocolateyFindSettings()));
    /// <summary><p>Searches remote or local packages (alias for <c>search</c>).</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/find">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;filter&gt;</c> via <see cref="ChocolateyFindSettings.Filter"/></li><li><c>--accept-license</c> via <see cref="ChocolateyFindSettings.AcceptLicense"/></li><li><c>--all-versions</c> via <see cref="ChocolateyFindSettings.AllVersions"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyFindSettings.AllowUnofficialBuild"/></li><li><c>--approved-only</c> via <see cref="ChocolateyFindSettings.ApprovedOnly"/></li><li><c>--by-id-only</c> via <see cref="ChocolateyFindSettings.ByIdOnly"/></li><li><c>--by-tag-only</c> via <see cref="ChocolateyFindSettings.ByTagOnly"/></li><li><c>--cache-location</c> via <see cref="ChocolateyFindSettings.CacheLocation"/></li><li><c>--cert</c> via <see cref="ChocolateyFindSettings.ClientCertificate"/></li><li><c>--certpassword</c> via <see cref="ChocolateyFindSettings.CertificatePassword"/></li><li><c>--confirm</c> via <see cref="ChocolateyFindSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyFindSettings.Debug"/></li><li><c>--detailed</c> via <see cref="ChocolateyFindSettings.Detailed"/></li><li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/></li><li><c>--download-cache-only</c> via <see cref="ChocolateyFindSettings.DownloadCacheAvailable"/></li><li><c>--exact</c> via <see cref="ChocolateyFindSettings.Exact"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyFindSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyFindSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateyFindSettings.Force"/></li><li><c>--id-only</c> via <see cref="ChocolateyFindSettings.IdOnly"/></li><li><c>--id-starts-with</c> via <see cref="ChocolateyFindSettings.IdStartsWith"/></li><li><c>--include-programs</c> via <see cref="ChocolateyFindSettings.IncludePrograms"/></li><li><c>--limit-output</c> via <see cref="ChocolateyFindSettings.LimitOutput"/></li><li><c>--local-only</c> via <see cref="ChocolateyFindSettings.LocalOnly"/></li><li><c>--log-file</c> via <see cref="ChocolateyFindSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateyFindSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyFindSettings.DoNotShowProgress"/></li><li><c>--not-broken</c> via <see cref="ChocolateyFindSettings.NotBroken"/></li><li><c>--order-by-popularity</c> via <see cref="ChocolateyFindSettings.OrderByPopularity"/></li><li><c>--page</c> via <see cref="ChocolateyFindSettings.Page"/></li><li><c>--page-size</c> via <see cref="ChocolateyFindSettings.PageSize"/></li><li><c>--password</c> via <see cref="ChocolateyFindSettings.Password"/></li><li><c>--prerelease</c> via <see cref="ChocolateyFindSettings.Prerelease"/></li><li><c>--proxy</c> via <see cref="ChocolateyFindSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyFindSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyFindSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyFindSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyFindSettings.ProxyUserName"/></li><li><c>--show-audit-info</c> via <see cref="ChocolateyFindSettings.ShowAuditInformation"/></li><li><c>--source</c> via <see cref="ChocolateyFindSettings.Source"/></li><li><c>--trace</c> via <see cref="ChocolateyFindSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyFindSettings.UseSystemPowerShell"/></li><li><c>--user</c> via <see cref="ChocolateyFindSettings.User"/></li><li><c>--verbose</c> via <see cref="ChocolateyFindSettings.Verbose"/></li><li><c>--version</c> via <see cref="ChocolateyFindSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(ChocolateyFindSettings Settings, IReadOnlyCollection<Output> Output)> ChocolateyFind(CombinatorialConfigure<ChocolateyFindSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(ChocolateyFind, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Retrieves packages that are outdated. Similar to <c>upgrade all --noop</c>.</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/outdated">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--accept-license</c> via <see cref="ChocolateyOutdatedSettings.AcceptLicense"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/></li><li><c>--cache-location</c> via <see cref="ChocolateyOutdatedSettings.CacheLocation"/></li><li><c>--cert</c> via <see cref="ChocolateyOutdatedSettings.ClientCertificate"/></li><li><c>--certpassword</c> via <see cref="ChocolateyOutdatedSettings.CertificatePassword"/></li><li><c>--confirm</c> via <see cref="ChocolateyOutdatedSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyOutdatedSettings.Debug"/></li><li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyOutdatedSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyOutdatedSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateyOutdatedSettings.Force"/></li><li><c>--ignore-pinned</c> via <see cref="ChocolateyOutdatedSettings.IgnorePinned"/></li><li><c>--ignore-unfound</c> via <see cref="ChocolateyOutdatedSettings.IgnoreUnfound"/></li><li><c>--limit-output</c> via <see cref="ChocolateyOutdatedSettings.LimitOutput"/></li><li><c>--log-file</c> via <see cref="ChocolateyOutdatedSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateyOutdatedSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyOutdatedSettings.DoNotShowProgress"/></li><li><c>--password</c> via <see cref="ChocolateyOutdatedSettings.Password"/></li><li><c>--prerelease</c> via <see cref="ChocolateyOutdatedSettings.Prerelease"/></li><li><c>--proxy</c> via <see cref="ChocolateyOutdatedSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyOutdatedSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyOutdatedSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyOutdatedSettings.ProxyUserName"/></li><li><c>--source</c> via <see cref="ChocolateyOutdatedSettings.Source"/></li><li><c>--trace</c> via <see cref="ChocolateyOutdatedSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/></li><li><c>--user</c> via <see cref="ChocolateyOutdatedSettings.User"/></li><li><c>--verbose</c> via <see cref="ChocolateyOutdatedSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ChocolateyOutdated(ChocolateyOutdatedSettings options = null) => new ChocolateyTasks().Run(options);
    /// <summary><p>Retrieves packages that are outdated. Similar to <c>upgrade all --noop</c>.</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/outdated">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--accept-license</c> via <see cref="ChocolateyOutdatedSettings.AcceptLicense"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/></li><li><c>--cache-location</c> via <see cref="ChocolateyOutdatedSettings.CacheLocation"/></li><li><c>--cert</c> via <see cref="ChocolateyOutdatedSettings.ClientCertificate"/></li><li><c>--certpassword</c> via <see cref="ChocolateyOutdatedSettings.CertificatePassword"/></li><li><c>--confirm</c> via <see cref="ChocolateyOutdatedSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyOutdatedSettings.Debug"/></li><li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyOutdatedSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyOutdatedSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateyOutdatedSettings.Force"/></li><li><c>--ignore-pinned</c> via <see cref="ChocolateyOutdatedSettings.IgnorePinned"/></li><li><c>--ignore-unfound</c> via <see cref="ChocolateyOutdatedSettings.IgnoreUnfound"/></li><li><c>--limit-output</c> via <see cref="ChocolateyOutdatedSettings.LimitOutput"/></li><li><c>--log-file</c> via <see cref="ChocolateyOutdatedSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateyOutdatedSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyOutdatedSettings.DoNotShowProgress"/></li><li><c>--password</c> via <see cref="ChocolateyOutdatedSettings.Password"/></li><li><c>--prerelease</c> via <see cref="ChocolateyOutdatedSettings.Prerelease"/></li><li><c>--proxy</c> via <see cref="ChocolateyOutdatedSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyOutdatedSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyOutdatedSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyOutdatedSettings.ProxyUserName"/></li><li><c>--source</c> via <see cref="ChocolateyOutdatedSettings.Source"/></li><li><c>--trace</c> via <see cref="ChocolateyOutdatedSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/></li><li><c>--user</c> via <see cref="ChocolateyOutdatedSettings.User"/></li><li><c>--verbose</c> via <see cref="ChocolateyOutdatedSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ChocolateyOutdated(Configure<ChocolateyOutdatedSettings> configurator) => new ChocolateyTasks().Run(configurator.Invoke(new ChocolateyOutdatedSettings()));
    /// <summary><p>Retrieves packages that are outdated. Similar to <c>upgrade all --noop</c>.</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/choco/commands/outdated">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--accept-license</c> via <see cref="ChocolateyOutdatedSettings.AcceptLicense"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/></li><li><c>--cache-location</c> via <see cref="ChocolateyOutdatedSettings.CacheLocation"/></li><li><c>--cert</c> via <see cref="ChocolateyOutdatedSettings.ClientCertificate"/></li><li><c>--certpassword</c> via <see cref="ChocolateyOutdatedSettings.CertificatePassword"/></li><li><c>--confirm</c> via <see cref="ChocolateyOutdatedSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyOutdatedSettings.Debug"/></li><li><c>--disable-package-repository-optimizations</c> via <see cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyOutdatedSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyOutdatedSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateyOutdatedSettings.Force"/></li><li><c>--ignore-pinned</c> via <see cref="ChocolateyOutdatedSettings.IgnorePinned"/></li><li><c>--ignore-unfound</c> via <see cref="ChocolateyOutdatedSettings.IgnoreUnfound"/></li><li><c>--limit-output</c> via <see cref="ChocolateyOutdatedSettings.LimitOutput"/></li><li><c>--log-file</c> via <see cref="ChocolateyOutdatedSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateyOutdatedSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyOutdatedSettings.DoNotShowProgress"/></li><li><c>--password</c> via <see cref="ChocolateyOutdatedSettings.Password"/></li><li><c>--prerelease</c> via <see cref="ChocolateyOutdatedSettings.Prerelease"/></li><li><c>--proxy</c> via <see cref="ChocolateyOutdatedSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyOutdatedSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyOutdatedSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyOutdatedSettings.ProxyUserName"/></li><li><c>--source</c> via <see cref="ChocolateyOutdatedSettings.Source"/></li><li><c>--trace</c> via <see cref="ChocolateyOutdatedSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/></li><li><c>--user</c> via <see cref="ChocolateyOutdatedSettings.User"/></li><li><c>--verbose</c> via <see cref="ChocolateyOutdatedSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(ChocolateyOutdatedSettings Settings, IReadOnlyCollection<Output> Output)> ChocolateyOutdated(CombinatorialConfigure<ChocolateyOutdatedSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(ChocolateyOutdated, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Packages up a nuspec to a compiled nupkg.</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/pack">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;pathToNuspec&gt;</c> via <see cref="ChocolateyPackSettings.PathToNuspec"/></li><li><c>--</c> via <see cref="ChocolateyPackSettings.Properties"/></li><li><c>--accept-license</c> via <see cref="ChocolateyPackSettings.AcceptLicense"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyPackSettings.AllowUnofficialBuild"/></li><li><c>--cache-location</c> via <see cref="ChocolateyPackSettings.CacheLocation"/></li><li><c>--confirm</c> via <see cref="ChocolateyPackSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyPackSettings.Debug"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyPackSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyPackSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateyPackSettings.Force"/></li><li><c>--limit-output</c> via <see cref="ChocolateyPackSettings.LimitOutput"/></li><li><c>--log-file</c> via <see cref="ChocolateyPackSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateyPackSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyPackSettings.DoNotShowProgress"/></li><li><c>--output-directory</c> via <see cref="ChocolateyPackSettings.OutputDirectory"/></li><li><c>--proxy</c> via <see cref="ChocolateyPackSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyPackSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyPackSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyPackSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyPackSettings.ProxyUserName"/></li><li><c>--trace</c> via <see cref="ChocolateyPackSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyPackSettings.UseSystemPowerShell"/></li><li><c>--verbose</c> via <see cref="ChocolateyPackSettings.Verbose"/></li><li><c>--version</c> via <see cref="ChocolateyPackSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ChocolateyPack(ChocolateyPackSettings options = null) => new ChocolateyTasks().Run(options);
    /// <summary><p>Packages up a nuspec to a compiled nupkg.</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/pack">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;pathToNuspec&gt;</c> via <see cref="ChocolateyPackSettings.PathToNuspec"/></li><li><c>--</c> via <see cref="ChocolateyPackSettings.Properties"/></li><li><c>--accept-license</c> via <see cref="ChocolateyPackSettings.AcceptLicense"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyPackSettings.AllowUnofficialBuild"/></li><li><c>--cache-location</c> via <see cref="ChocolateyPackSettings.CacheLocation"/></li><li><c>--confirm</c> via <see cref="ChocolateyPackSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyPackSettings.Debug"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyPackSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyPackSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateyPackSettings.Force"/></li><li><c>--limit-output</c> via <see cref="ChocolateyPackSettings.LimitOutput"/></li><li><c>--log-file</c> via <see cref="ChocolateyPackSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateyPackSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyPackSettings.DoNotShowProgress"/></li><li><c>--output-directory</c> via <see cref="ChocolateyPackSettings.OutputDirectory"/></li><li><c>--proxy</c> via <see cref="ChocolateyPackSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyPackSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyPackSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyPackSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyPackSettings.ProxyUserName"/></li><li><c>--trace</c> via <see cref="ChocolateyPackSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyPackSettings.UseSystemPowerShell"/></li><li><c>--verbose</c> via <see cref="ChocolateyPackSettings.Verbose"/></li><li><c>--version</c> via <see cref="ChocolateyPackSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ChocolateyPack(Configure<ChocolateyPackSettings> configurator) => new ChocolateyTasks().Run(configurator.Invoke(new ChocolateyPackSettings()));
    /// <summary><p>Packages up a nuspec to a compiled nupkg.</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/pack">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;pathToNuspec&gt;</c> via <see cref="ChocolateyPackSettings.PathToNuspec"/></li><li><c>--</c> via <see cref="ChocolateyPackSettings.Properties"/></li><li><c>--accept-license</c> via <see cref="ChocolateyPackSettings.AcceptLicense"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyPackSettings.AllowUnofficialBuild"/></li><li><c>--cache-location</c> via <see cref="ChocolateyPackSettings.CacheLocation"/></li><li><c>--confirm</c> via <see cref="ChocolateyPackSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyPackSettings.Debug"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyPackSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyPackSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateyPackSettings.Force"/></li><li><c>--limit-output</c> via <see cref="ChocolateyPackSettings.LimitOutput"/></li><li><c>--log-file</c> via <see cref="ChocolateyPackSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateyPackSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyPackSettings.DoNotShowProgress"/></li><li><c>--output-directory</c> via <see cref="ChocolateyPackSettings.OutputDirectory"/></li><li><c>--proxy</c> via <see cref="ChocolateyPackSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyPackSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyPackSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyPackSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyPackSettings.ProxyUserName"/></li><li><c>--trace</c> via <see cref="ChocolateyPackSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyPackSettings.UseSystemPowerShell"/></li><li><c>--verbose</c> via <see cref="ChocolateyPackSettings.Verbose"/></li><li><c>--version</c> via <see cref="ChocolateyPackSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(ChocolateyPackSettings Settings, IReadOnlyCollection<Output> Output)> ChocolateyPack(CombinatorialConfigure<ChocolateyPackSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(ChocolateyPack, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pushes a compiled nupkg.</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/push">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;pathToNuGetPackage&gt;</c> via <see cref="ChocolateyPushSettings.PathToNuGetPackage"/></li><li><c>--accept-license</c> via <see cref="ChocolateyPushSettings.AcceptLicense"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyPushSettings.AllowUnofficialBuild"/></li><li><c>--api-key</c> via <see cref="ChocolateyPushSettings.ApiKey"/></li><li><c>--cache-location</c> via <see cref="ChocolateyPushSettings.CacheLocation"/></li><li><c>--confirm</c> via <see cref="ChocolateyPushSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyPushSettings.Debug"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyPushSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyPushSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateyPushSettings.Force"/></li><li><c>--limit-output</c> via <see cref="ChocolateyPushSettings.LimitOutput"/></li><li><c>--log-file</c> via <see cref="ChocolateyPushSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateyPushSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyPushSettings.DoNotShowProgress"/></li><li><c>--proxy</c> via <see cref="ChocolateyPushSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyPushSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyPushSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyPushSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyPushSettings.ProxyUserName"/></li><li><c>--source</c> via <see cref="ChocolateyPushSettings.Source"/></li><li><c>--trace</c> via <see cref="ChocolateyPushSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyPushSettings.UseSystemPowerShell"/></li><li><c>--verbose</c> via <see cref="ChocolateyPushSettings.Verbose"/></li><li><c>-t</c> via <see cref="ChocolateyPushSettings.Timeout"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ChocolateyPush(ChocolateyPushSettings options = null) => new ChocolateyTasks().Run(options);
    /// <summary><p>Pushes a compiled nupkg.</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/push">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;pathToNuGetPackage&gt;</c> via <see cref="ChocolateyPushSettings.PathToNuGetPackage"/></li><li><c>--accept-license</c> via <see cref="ChocolateyPushSettings.AcceptLicense"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyPushSettings.AllowUnofficialBuild"/></li><li><c>--api-key</c> via <see cref="ChocolateyPushSettings.ApiKey"/></li><li><c>--cache-location</c> via <see cref="ChocolateyPushSettings.CacheLocation"/></li><li><c>--confirm</c> via <see cref="ChocolateyPushSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyPushSettings.Debug"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyPushSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyPushSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateyPushSettings.Force"/></li><li><c>--limit-output</c> via <see cref="ChocolateyPushSettings.LimitOutput"/></li><li><c>--log-file</c> via <see cref="ChocolateyPushSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateyPushSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyPushSettings.DoNotShowProgress"/></li><li><c>--proxy</c> via <see cref="ChocolateyPushSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyPushSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyPushSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyPushSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyPushSettings.ProxyUserName"/></li><li><c>--source</c> via <see cref="ChocolateyPushSettings.Source"/></li><li><c>--trace</c> via <see cref="ChocolateyPushSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyPushSettings.UseSystemPowerShell"/></li><li><c>--verbose</c> via <see cref="ChocolateyPushSettings.Verbose"/></li><li><c>-t</c> via <see cref="ChocolateyPushSettings.Timeout"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ChocolateyPush(Configure<ChocolateyPushSettings> configurator) => new ChocolateyTasks().Run(configurator.Invoke(new ChocolateyPushSettings()));
    /// <summary><p>Pushes a compiled nupkg.</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/push">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;pathToNuGetPackage&gt;</c> via <see cref="ChocolateyPushSettings.PathToNuGetPackage"/></li><li><c>--accept-license</c> via <see cref="ChocolateyPushSettings.AcceptLicense"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyPushSettings.AllowUnofficialBuild"/></li><li><c>--api-key</c> via <see cref="ChocolateyPushSettings.ApiKey"/></li><li><c>--cache-location</c> via <see cref="ChocolateyPushSettings.CacheLocation"/></li><li><c>--confirm</c> via <see cref="ChocolateyPushSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyPushSettings.Debug"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyPushSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyPushSettings.FailOnStandardError"/></li><li><c>--force</c> via <see cref="ChocolateyPushSettings.Force"/></li><li><c>--limit-output</c> via <see cref="ChocolateyPushSettings.LimitOutput"/></li><li><c>--log-file</c> via <see cref="ChocolateyPushSettings.LogFile"/></li><li><c>--no-color</c> via <see cref="ChocolateyPushSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyPushSettings.DoNotShowProgress"/></li><li><c>--proxy</c> via <see cref="ChocolateyPushSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyPushSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyPushSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyPushSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyPushSettings.ProxyUserName"/></li><li><c>--source</c> via <see cref="ChocolateyPushSettings.Source"/></li><li><c>--trace</c> via <see cref="ChocolateyPushSettings.Trace"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyPushSettings.UseSystemPowerShell"/></li><li><c>--verbose</c> via <see cref="ChocolateyPushSettings.Verbose"/></li><li><c>-t</c> via <see cref="ChocolateyPushSettings.Timeout"/></li></ul></remarks>
    public static IEnumerable<(ChocolateyPushSettings Settings, IReadOnlyCollection<Output> Output)> ChocolateyPush(CombinatorialConfigure<ChocolateyPushSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(ChocolateyPush, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Generates files necessary for a chocolatey package from a template.</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/new">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="ChocolateyNewSettings.Properties"/></li><li><c>--accept-license</c> via <see cref="ChocolateyNewSettings.AcceptLicense"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyNewSettings.AllowUnofficialBuild"/></li><li><c>--automaticpackage</c> via <see cref="ChocolateyNewSettings.AutomaticPackage"/></li><li><c>--build-package</c> via <see cref="ChocolateyNewSettings.BuildPackage"/></li><li><c>--cache-location</c> via <see cref="ChocolateyNewSettings.CacheLocation"/></li><li><c>--checksum</c> via <see cref="ChocolateyNewSettings.Checksum"/></li><li><c>--checksum-type</c> via <see cref="ChocolateyNewSettings.ChecksumType"/></li><li><c>--checksum-x64</c> via <see cref="ChocolateyNewSettings.Checksum64"/></li><li><c>--confirm</c> via <see cref="ChocolateyNewSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyNewSettings.Debug"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyNewSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyNewSettings.FailOnStandardError"/></li><li><c>--file</c> via <see cref="ChocolateyNewSettings.LocationOfBinary"/></li><li><c>--file64</c> via <see cref="ChocolateyNewSettings.LocationOfBinary64"/></li><li><c>--force</c> via <see cref="ChocolateyNewSettings.Force"/></li><li><c>--from-programs-and-features</c> via <see cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/></li><li><c>--generate-for-community</c> via <see cref="ChocolateyNewSettings.GenerateForCommunity"/></li><li><c>--include-architecture-in-name</c> via <see cref="ChocolateyNewSettings.IncludeArchitectureInName"/></li><li><c>--limit-output</c> via <see cref="ChocolateyNewSettings.LimitOutput"/></li><li><c>--log-file</c> via <see cref="ChocolateyNewSettings.LogFile"/></li><li><c>--maintainer</c> via <see cref="ChocolateyNewSettings.Maintainer"/></li><li><c>--name</c> via <see cref="ChocolateyNewSettings.Name"/></li><li><c>--no-color</c> via <see cref="ChocolateyNewSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyNewSettings.DoNotShowProgress"/></li><li><c>--output-directory</c> via <see cref="ChocolateyNewSettings.OutputDirectory"/></li><li><c>--pause-on-error</c> via <see cref="ChocolateyNewSettings.PauseOnError"/></li><li><c>--proxy</c> via <see cref="ChocolateyNewSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyNewSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyNewSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyNewSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyNewSettings.ProxyUserName"/></li><li><c>--remove-architecture-from-name</c> via <see cref="ChocolateyNewSettings.RemoveArchitectureFromName"/></li><li><c>--template-name</c> via <see cref="ChocolateyNewSettings.TemplateName"/></li><li><c>--trace</c> via <see cref="ChocolateyNewSettings.Trace"/></li><li><c>--use-built-in-template</c> via <see cref="ChocolateyNewSettings.BuildInTemplate"/></li><li><c>--use-original-files-location</c> via <see cref="ChocolateyNewSettings.UseOriginalFilesLocation"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyNewSettings.UseSystemPowerShell"/></li><li><c>--verbose</c> via <see cref="ChocolateyNewSettings.Verbose"/></li><li><c>--version</c> via <see cref="ChocolateyNewSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ChocolateyNew(ChocolateyNewSettings options = null) => new ChocolateyTasks().Run(options);
    /// <summary><p>Generates files necessary for a chocolatey package from a template.</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/new">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="ChocolateyNewSettings.Properties"/></li><li><c>--accept-license</c> via <see cref="ChocolateyNewSettings.AcceptLicense"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyNewSettings.AllowUnofficialBuild"/></li><li><c>--automaticpackage</c> via <see cref="ChocolateyNewSettings.AutomaticPackage"/></li><li><c>--build-package</c> via <see cref="ChocolateyNewSettings.BuildPackage"/></li><li><c>--cache-location</c> via <see cref="ChocolateyNewSettings.CacheLocation"/></li><li><c>--checksum</c> via <see cref="ChocolateyNewSettings.Checksum"/></li><li><c>--checksum-type</c> via <see cref="ChocolateyNewSettings.ChecksumType"/></li><li><c>--checksum-x64</c> via <see cref="ChocolateyNewSettings.Checksum64"/></li><li><c>--confirm</c> via <see cref="ChocolateyNewSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyNewSettings.Debug"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyNewSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyNewSettings.FailOnStandardError"/></li><li><c>--file</c> via <see cref="ChocolateyNewSettings.LocationOfBinary"/></li><li><c>--file64</c> via <see cref="ChocolateyNewSettings.LocationOfBinary64"/></li><li><c>--force</c> via <see cref="ChocolateyNewSettings.Force"/></li><li><c>--from-programs-and-features</c> via <see cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/></li><li><c>--generate-for-community</c> via <see cref="ChocolateyNewSettings.GenerateForCommunity"/></li><li><c>--include-architecture-in-name</c> via <see cref="ChocolateyNewSettings.IncludeArchitectureInName"/></li><li><c>--limit-output</c> via <see cref="ChocolateyNewSettings.LimitOutput"/></li><li><c>--log-file</c> via <see cref="ChocolateyNewSettings.LogFile"/></li><li><c>--maintainer</c> via <see cref="ChocolateyNewSettings.Maintainer"/></li><li><c>--name</c> via <see cref="ChocolateyNewSettings.Name"/></li><li><c>--no-color</c> via <see cref="ChocolateyNewSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyNewSettings.DoNotShowProgress"/></li><li><c>--output-directory</c> via <see cref="ChocolateyNewSettings.OutputDirectory"/></li><li><c>--pause-on-error</c> via <see cref="ChocolateyNewSettings.PauseOnError"/></li><li><c>--proxy</c> via <see cref="ChocolateyNewSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyNewSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyNewSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyNewSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyNewSettings.ProxyUserName"/></li><li><c>--remove-architecture-from-name</c> via <see cref="ChocolateyNewSettings.RemoveArchitectureFromName"/></li><li><c>--template-name</c> via <see cref="ChocolateyNewSettings.TemplateName"/></li><li><c>--trace</c> via <see cref="ChocolateyNewSettings.Trace"/></li><li><c>--use-built-in-template</c> via <see cref="ChocolateyNewSettings.BuildInTemplate"/></li><li><c>--use-original-files-location</c> via <see cref="ChocolateyNewSettings.UseOriginalFilesLocation"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyNewSettings.UseSystemPowerShell"/></li><li><c>--verbose</c> via <see cref="ChocolateyNewSettings.Verbose"/></li><li><c>--version</c> via <see cref="ChocolateyNewSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ChocolateyNew(Configure<ChocolateyNewSettings> configurator) => new ChocolateyTasks().Run(configurator.Invoke(new ChocolateyNewSettings()));
    /// <summary><p>Generates files necessary for a chocolatey package from a template.</p><p>For more details, visit the <a href="https://docs.chocolatey.org/en-us/create/commands/new">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="ChocolateyNewSettings.Properties"/></li><li><c>--accept-license</c> via <see cref="ChocolateyNewSettings.AcceptLicense"/></li><li><c>--allow-unofficial-build</c> via <see cref="ChocolateyNewSettings.AllowUnofficialBuild"/></li><li><c>--automaticpackage</c> via <see cref="ChocolateyNewSettings.AutomaticPackage"/></li><li><c>--build-package</c> via <see cref="ChocolateyNewSettings.BuildPackage"/></li><li><c>--cache-location</c> via <see cref="ChocolateyNewSettings.CacheLocation"/></li><li><c>--checksum</c> via <see cref="ChocolateyNewSettings.Checksum"/></li><li><c>--checksum-type</c> via <see cref="ChocolateyNewSettings.ChecksumType"/></li><li><c>--checksum-x64</c> via <see cref="ChocolateyNewSettings.Checksum64"/></li><li><c>--confirm</c> via <see cref="ChocolateyNewSettings.Confirm"/></li><li><c>--debug</c> via <see cref="ChocolateyNewSettings.Debug"/></li><li><c>--execution-timeout</c> via <see cref="ChocolateyNewSettings.CommandExecutionTimeout"/></li><li><c>--fail-on-standard-error</c> via <see cref="ChocolateyNewSettings.FailOnStandardError"/></li><li><c>--file</c> via <see cref="ChocolateyNewSettings.LocationOfBinary"/></li><li><c>--file64</c> via <see cref="ChocolateyNewSettings.LocationOfBinary64"/></li><li><c>--force</c> via <see cref="ChocolateyNewSettings.Force"/></li><li><c>--from-programs-and-features</c> via <see cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/></li><li><c>--generate-for-community</c> via <see cref="ChocolateyNewSettings.GenerateForCommunity"/></li><li><c>--include-architecture-in-name</c> via <see cref="ChocolateyNewSettings.IncludeArchitectureInName"/></li><li><c>--limit-output</c> via <see cref="ChocolateyNewSettings.LimitOutput"/></li><li><c>--log-file</c> via <see cref="ChocolateyNewSettings.LogFile"/></li><li><c>--maintainer</c> via <see cref="ChocolateyNewSettings.Maintainer"/></li><li><c>--name</c> via <see cref="ChocolateyNewSettings.Name"/></li><li><c>--no-color</c> via <see cref="ChocolateyNewSettings.NoColor"/></li><li><c>--no-progress</c> via <see cref="ChocolateyNewSettings.DoNotShowProgress"/></li><li><c>--output-directory</c> via <see cref="ChocolateyNewSettings.OutputDirectory"/></li><li><c>--pause-on-error</c> via <see cref="ChocolateyNewSettings.PauseOnError"/></li><li><c>--proxy</c> via <see cref="ChocolateyNewSettings.Proxy"/></li><li><c>--proxy-bypass-list</c> via <see cref="ChocolateyNewSettings.ProxyBypassList"/></li><li><c>--proxy-bypass-on-local</c> via <see cref="ChocolateyNewSettings.ProxyBypassOnLocal"/></li><li><c>--proxy-password</c> via <see cref="ChocolateyNewSettings.ProxyPassword"/></li><li><c>--proxy-user</c> via <see cref="ChocolateyNewSettings.ProxyUserName"/></li><li><c>--remove-architecture-from-name</c> via <see cref="ChocolateyNewSettings.RemoveArchitectureFromName"/></li><li><c>--template-name</c> via <see cref="ChocolateyNewSettings.TemplateName"/></li><li><c>--trace</c> via <see cref="ChocolateyNewSettings.Trace"/></li><li><c>--use-built-in-template</c> via <see cref="ChocolateyNewSettings.BuildInTemplate"/></li><li><c>--use-original-files-location</c> via <see cref="ChocolateyNewSettings.UseOriginalFilesLocation"/></li><li><c>--use-system-powershell</c> via <see cref="ChocolateyNewSettings.UseSystemPowerShell"/></li><li><c>--verbose</c> via <see cref="ChocolateyNewSettings.Verbose"/></li><li><c>--version</c> via <see cref="ChocolateyNewSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(ChocolateyNewSettings Settings, IReadOnlyCollection<Output> Output)> ChocolateyNew(CombinatorialConfigure<ChocolateyNewSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(ChocolateyNew, degreeOfParallelism, completeOnFailure);
}
#region ChocolateySearchSettings
/// <summary>Used within <see cref="ChocolateyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<ChocolateySearchSettings>))]
[Command(Type = typeof(ChocolateyTasks), Command = nameof(ChocolateyTasks.ChocolateySearch), Arguments = "search")]
public partial class ChocolateySearchSettings : ToolOptions
{
    /// <summary>Search filter.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Filter => Get<string>(() => Filter);
    /// <summary>Source location for install. Can use special 'webpi' or 'windowsfeatures' sources. Defaults to sources.</summary>
    [Argument(Format = "--source={value}")] public string Source => Get<string>(() => Source);
    /// <summary>Only search against local machine items.</summary>
    [Argument(Format = "--local-only")] public bool? LocalOnly => Get<bool?>(() => LocalOnly);
    /// <summary>Only return Package Ids in the list results.</summary>
    [Argument(Format = "--id-only")] public bool? IdOnly => Get<bool?>(() => IdOnly);
    /// <summary>Include Prereleases? Defaults to false.</summary>
    [Argument(Format = "--prerelease")] public bool? Prerelease => Get<bool?>(() => Prerelease);
    /// <summary>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</summary>
    [Argument(Format = "--include-programs")] public bool? IncludePrograms => Get<bool?>(() => IncludePrograms);
    /// <summary>Include results from all versions.</summary>
    [Argument(Format = "--all-versions")] public bool? AllVersions => Get<bool?>(() => AllVersions);
    /// <summary>Specific version of a package to return.</summary>
    [Argument(Format = "--version={value}")] public string Version => Get<string>(() => Version);
    /// <summary>The 'page' of results to return. Defaults to return all results.</summary>
    [Argument(Format = "--page={value}")] public int? Page => Get<int?>(() => Page);
    /// <summary>The amount of package results to return per page. Defaults to 25.</summary>
    [Argument(Format = "--page-size={value}")] public int? PageSize => Get<int?>(() => PageSize);
    /// <summary>Only return packages with this exact name.</summary>
    [Argument(Format = "--exact")] public bool? Exact => Get<bool?>(() => Exact);
    /// <summary>Only return packages where the id contains the search filter.</summary>
    [Argument(Format = "--by-id-only")] public bool? ByIdOnly => Get<bool?>(() => ByIdOnly);
    /// <summary>Only return packages where the search filter matches on the tags.</summary>
    [Argument(Format = "--by-tag-only")] public bool? ByTagOnly => Get<bool?>(() => ByTagOnly);
    /// <summary>Only return packages where the id starts with the search filter.</summary>
    [Argument(Format = "--id-starts-with")] public bool? IdStartsWith => Get<bool?>(() => IdStartsWith);
    /// <summary>Sort by package results by popularity.</summary>
    [Argument(Format = "--order-by-popularity")] public bool? OrderByPopularity => Get<bool?>(() => OrderByPopularity);
    /// <summary>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</summary>
    [Argument(Format = "--approved-only")] public bool? ApprovedOnly => Get<bool?>(() => ApprovedOnly);
    /// <summary>Only return packages that have a download cache available - this option will filter out results not from the community repository.</summary>
    [Argument(Format = "--download-cache-only")] public bool? DownloadCacheAvailable => Get<bool?>(() => DownloadCacheAvailable);
    /// <summary>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</summary>
    [Argument(Format = "--not-broken")] public bool? NotBroken => Get<bool?>(() => NotBroken);
    /// <summary>Alias for verbose.</summary>
    [Argument(Format = "--detailed")] public bool? Detailed => Get<bool?>(() => Detailed);
    /// <summary>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</summary>
    [Argument(Format = "--disable-package-repository-optimizations")] public bool? DisablePackageRepositoryOptimizations => Get<bool?>(() => DisablePackageRepositoryOptimizations);
    /// <summary>Display auditing information for a package.</summary>
    [Argument(Format = "--show-audit-info")] public bool? ShowAuditInformation => Get<bool?>(() => ShowAuditInformation);
    /// <summary>Used with authenticated feeds. Defaults to empty.</summary>
    [Argument(Format = "--user={value}")] public string User => Get<string>(() => User);
    /// <summary>The user's password to the source. Defaults to empty.</summary>
    [Argument(Format = "--password={value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>PFX pathname for an x509 authenticated feeds. Defaults to empty.</summary>
    [Argument(Format = "--cert={value}")] public string ClientCertificate => Get<string>(() => ClientCertificate);
    /// <summary>The client certificate's password to the source. Defaults to empty.</summary>
    [Argument(Format = "--certpassword={value}", Secret = true)] public string CertificatePassword => Get<string>(() => CertificatePassword);
    /// <summary>Show debug messaging.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</summary>
    [Argument(Format = "--verbose")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</summary>
    [Argument(Format = "--trace")] public bool? Trace => Get<bool?>(() => Trace);
    /// <summary>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</summary>
    [Argument(Format = "--no-color")] public bool? NoColor => Get<bool?>(() => NoColor);
    /// <summary>Accept license dialogs automatically. Reserved for future use.</summary>
    [Argument(Format = "--accept-license")] public bool? AcceptLicense => Get<bool?>(() => AcceptLicense);
    /// <summary>Chooses affirmative answer instead of prompting. Implies --accept-license</summary>
    [Argument(Format = "--confirm")] public bool? Confirm => Get<bool?>(() => Confirm);
    /// <summary>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Limit the output to essential information</summary>
    [Argument(Format = "--limit-output")] public bool? LimitOutput => Get<bool?>(() => LimitOutput);
    /// <summary>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</summary>
    [Argument(Format = "--execution-timeout={value}")] public int? CommandExecutionTimeout => Get<int?>(() => CommandExecutionTimeout);
    /// <summary>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</summary>
    [Argument(Format = "--cache-location {value}")] public string CacheLocation => Get<string>(() => CacheLocation);
    /// <summary>When not using the official build you must set this flag for choco to continue.</summary>
    [Argument(Format = "--allow-unofficial-build")] public bool? AllowUnofficialBuild => Get<bool?>(() => AllowUnofficialBuild);
    /// <summary>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</summary>
    [Argument(Format = "--fail-on-standard-error")] public bool? FailOnStandardError => Get<bool?>(() => FailOnStandardError);
    /// <summary>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</summary>
    [Argument(Format = "--use-system-powershell")] public bool? UseSystemPowerShell => Get<bool?>(() => UseSystemPowerShell);
    /// <summary>Do not show download progress percentages.</summary>
    [Argument(Format = "--no-progress")] public bool? DoNotShowProgress => Get<bool?>(() => DoNotShowProgress);
    /// <summary>Explicit proxy location. Overrides the default proxy location of ''.</summary>
    [Argument(Format = "--proxy={value}")] public string Proxy => Get<string>(() => Proxy);
    /// <summary>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</summary>
    [Argument(Format = "--proxy-user={value}")] public string ProxyUserName => Get<string>(() => ProxyUserName);
    /// <summary>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</summary>
    [Argument(Format = "--proxy-password={value}", Secret = true)] public string ProxyPassword => Get<string>(() => ProxyPassword);
    /// <summary>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</summary>
    [Argument(Format = "--proxy-bypass-list={value}", Separator = ",")] public IReadOnlyList<string> ProxyBypassList => Get<List<string>>(() => ProxyBypassList);
    /// <summary>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</summary>
    [Argument(Format = "--proxy-bypass-on-local")] public bool? ProxyBypassOnLocal => Get<bool?>(() => ProxyBypassOnLocal);
    /// <summary>Log File to output to in addition to regular loggers.</summary>
    [Argument(Format = "--log-file={value}")] public string LogFile => Get<string>(() => LogFile);
}
#endregion
#region ChocolateyListSettings
/// <summary>Used within <see cref="ChocolateyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<ChocolateyListSettings>))]
[Command(Type = typeof(ChocolateyTasks), Command = nameof(ChocolateyTasks.ChocolateyList), Arguments = "list")]
public partial class ChocolateyListSettings : ToolOptions
{
    /// <summary>Search filter.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Filter => Get<string>(() => Filter);
    /// <summary>Source location for install. Can use special 'webpi' or 'windowsfeatures' sources. Defaults to sources.</summary>
    [Argument(Format = "--source={value}")] public string Source => Get<string>(() => Source);
    /// <summary>Only search against local machine items.</summary>
    [Argument(Format = "--local-only")] public bool? LocalOnly => Get<bool?>(() => LocalOnly);
    /// <summary>Only return Package Ids in the list results.</summary>
    [Argument(Format = "--id-only")] public bool? IdOnly => Get<bool?>(() => IdOnly);
    /// <summary>Include Prereleases? Defaults to false.</summary>
    [Argument(Format = "--prerelease")] public bool? Prerelease => Get<bool?>(() => Prerelease);
    /// <summary>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</summary>
    [Argument(Format = "--include-programs")] public bool? IncludePrograms => Get<bool?>(() => IncludePrograms);
    /// <summary>Include results from all versions.</summary>
    [Argument(Format = "--all-versions")] public bool? AllVersions => Get<bool?>(() => AllVersions);
    /// <summary>Specific version of a package to return.</summary>
    [Argument(Format = "--version={value}")] public string Version => Get<string>(() => Version);
    /// <summary>The 'page' of results to return. Defaults to return all results.</summary>
    [Argument(Format = "--page={value}")] public int? Page => Get<int?>(() => Page);
    /// <summary>The amount of package results to return per page. Defaults to 25.</summary>
    [Argument(Format = "--page-size={value}")] public int? PageSize => Get<int?>(() => PageSize);
    /// <summary>Only return packages with this exact name.</summary>
    [Argument(Format = "--exact")] public bool? Exact => Get<bool?>(() => Exact);
    /// <summary>Only return packages where the id contains the search filter.</summary>
    [Argument(Format = "--by-id-only")] public bool? ByIdOnly => Get<bool?>(() => ByIdOnly);
    /// <summary>Only return packages where the search filter matches on the tags.</summary>
    [Argument(Format = "--by-tag-only")] public bool? ByTagOnly => Get<bool?>(() => ByTagOnly);
    /// <summary>Only return packages where the id starts with the search filter.</summary>
    [Argument(Format = "--id-starts-with")] public bool? IdStartsWith => Get<bool?>(() => IdStartsWith);
    /// <summary>Sort by package results by popularity.</summary>
    [Argument(Format = "--order-by-popularity")] public bool? OrderByPopularity => Get<bool?>(() => OrderByPopularity);
    /// <summary>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</summary>
    [Argument(Format = "--approved-only")] public bool? ApprovedOnly => Get<bool?>(() => ApprovedOnly);
    /// <summary>Only return packages that have a download cache available - this option will filter out results not from the community repository.</summary>
    [Argument(Format = "--download-cache-only")] public bool? DownloadCacheAvailable => Get<bool?>(() => DownloadCacheAvailable);
    /// <summary>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</summary>
    [Argument(Format = "--not-broken")] public bool? NotBroken => Get<bool?>(() => NotBroken);
    /// <summary>Alias for verbose.</summary>
    [Argument(Format = "--detailed")] public bool? Detailed => Get<bool?>(() => Detailed);
    /// <summary>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</summary>
    [Argument(Format = "--disable-package-repository-optimizations")] public bool? DisablePackageRepositoryOptimizations => Get<bool?>(() => DisablePackageRepositoryOptimizations);
    /// <summary>Display auditing information for a package.</summary>
    [Argument(Format = "--show-audit-info")] public bool? ShowAuditInformation => Get<bool?>(() => ShowAuditInformation);
    /// <summary>Used with authenticated feeds. Defaults to empty.</summary>
    [Argument(Format = "--user={value}")] public string User => Get<string>(() => User);
    /// <summary>The user's password to the source. Defaults to empty.</summary>
    [Argument(Format = "--password={value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>PFX pathname for an x509 authenticated feeds. Defaults to empty.</summary>
    [Argument(Format = "--cert={value}")] public string ClientCertificate => Get<string>(() => ClientCertificate);
    /// <summary>The client certificate's password to the source. Defaults to empty.</summary>
    [Argument(Format = "--certpassword={value}", Secret = true)] public string CertificatePassword => Get<string>(() => CertificatePassword);
    /// <summary>Show debug messaging.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</summary>
    [Argument(Format = "--verbose")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</summary>
    [Argument(Format = "--trace")] public bool? Trace => Get<bool?>(() => Trace);
    /// <summary>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</summary>
    [Argument(Format = "--no-color")] public bool? NoColor => Get<bool?>(() => NoColor);
    /// <summary>Accept license dialogs automatically. Reserved for future use.</summary>
    [Argument(Format = "--accept-license")] public bool? AcceptLicense => Get<bool?>(() => AcceptLicense);
    /// <summary>Chooses affirmative answer instead of prompting. Implies --accept-license</summary>
    [Argument(Format = "--confirm")] public bool? Confirm => Get<bool?>(() => Confirm);
    /// <summary>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Limit the output to essential information</summary>
    [Argument(Format = "--limit-output")] public bool? LimitOutput => Get<bool?>(() => LimitOutput);
    /// <summary>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</summary>
    [Argument(Format = "--execution-timeout={value}")] public int? CommandExecutionTimeout => Get<int?>(() => CommandExecutionTimeout);
    /// <summary>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</summary>
    [Argument(Format = "--cache-location {value}")] public string CacheLocation => Get<string>(() => CacheLocation);
    /// <summary>When not using the official build you must set this flag for choco to continue.</summary>
    [Argument(Format = "--allow-unofficial-build")] public bool? AllowUnofficialBuild => Get<bool?>(() => AllowUnofficialBuild);
    /// <summary>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</summary>
    [Argument(Format = "--fail-on-standard-error")] public bool? FailOnStandardError => Get<bool?>(() => FailOnStandardError);
    /// <summary>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</summary>
    [Argument(Format = "--use-system-powershell")] public bool? UseSystemPowerShell => Get<bool?>(() => UseSystemPowerShell);
    /// <summary>Do not show download progress percentages.</summary>
    [Argument(Format = "--no-progress")] public bool? DoNotShowProgress => Get<bool?>(() => DoNotShowProgress);
    /// <summary>Explicit proxy location. Overrides the default proxy location of ''.</summary>
    [Argument(Format = "--proxy={value}")] public string Proxy => Get<string>(() => Proxy);
    /// <summary>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</summary>
    [Argument(Format = "--proxy-user={value}")] public string ProxyUserName => Get<string>(() => ProxyUserName);
    /// <summary>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</summary>
    [Argument(Format = "--proxy-password={value}", Secret = true)] public string ProxyPassword => Get<string>(() => ProxyPassword);
    /// <summary>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</summary>
    [Argument(Format = "--proxy-bypass-list={value}", Separator = ",")] public IReadOnlyList<string> ProxyBypassList => Get<List<string>>(() => ProxyBypassList);
    /// <summary>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</summary>
    [Argument(Format = "--proxy-bypass-on-local")] public bool? ProxyBypassOnLocal => Get<bool?>(() => ProxyBypassOnLocal);
    /// <summary>Log File to output to in addition to regular loggers.</summary>
    [Argument(Format = "--log-file={value}")] public string LogFile => Get<string>(() => LogFile);
}
#endregion
#region ChocolateyFindSettings
/// <summary>Used within <see cref="ChocolateyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<ChocolateyFindSettings>))]
[Command(Type = typeof(ChocolateyTasks), Command = nameof(ChocolateyTasks.ChocolateyFind), Arguments = "find")]
public partial class ChocolateyFindSettings : ToolOptions
{
    /// <summary>Search filter.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Filter => Get<string>(() => Filter);
    /// <summary>Source location for install. Can use special 'webpi' or 'windowsfeatures' sources. Defaults to sources.</summary>
    [Argument(Format = "--source={value}")] public string Source => Get<string>(() => Source);
    /// <summary>Only search against local machine items.</summary>
    [Argument(Format = "--local-only")] public bool? LocalOnly => Get<bool?>(() => LocalOnly);
    /// <summary>Only return Package Ids in the list results.</summary>
    [Argument(Format = "--id-only")] public bool? IdOnly => Get<bool?>(() => IdOnly);
    /// <summary>Include Prereleases? Defaults to false.</summary>
    [Argument(Format = "--prerelease")] public bool? Prerelease => Get<bool?>(() => Prerelease);
    /// <summary>Used in conjunction with LocalOnly, filters out apps chocolatey has listed as packages and includes those in the list. Defaults to false.</summary>
    [Argument(Format = "--include-programs")] public bool? IncludePrograms => Get<bool?>(() => IncludePrograms);
    /// <summary>Include results from all versions.</summary>
    [Argument(Format = "--all-versions")] public bool? AllVersions => Get<bool?>(() => AllVersions);
    /// <summary>Specific version of a package to return.</summary>
    [Argument(Format = "--version={value}")] public string Version => Get<string>(() => Version);
    /// <summary>The 'page' of results to return. Defaults to return all results.</summary>
    [Argument(Format = "--page={value}")] public int? Page => Get<int?>(() => Page);
    /// <summary>The amount of package results to return per page. Defaults to 25.</summary>
    [Argument(Format = "--page-size={value}")] public int? PageSize => Get<int?>(() => PageSize);
    /// <summary>Only return packages with this exact name.</summary>
    [Argument(Format = "--exact")] public bool? Exact => Get<bool?>(() => Exact);
    /// <summary>Only return packages where the id contains the search filter.</summary>
    [Argument(Format = "--by-id-only")] public bool? ByIdOnly => Get<bool?>(() => ByIdOnly);
    /// <summary>Only return packages where the search filter matches on the tags.</summary>
    [Argument(Format = "--by-tag-only")] public bool? ByTagOnly => Get<bool?>(() => ByTagOnly);
    /// <summary>Only return packages where the id starts with the search filter.</summary>
    [Argument(Format = "--id-starts-with")] public bool? IdStartsWith => Get<bool?>(() => IdStartsWith);
    /// <summary>Sort by package results by popularity.</summary>
    [Argument(Format = "--order-by-popularity")] public bool? OrderByPopularity => Get<bool?>(() => OrderByPopularity);
    /// <summary>Only return approved packages - this option will filter out results not from the <a href="https://comminty.chocolatey.org/packages">community repository</a>.</summary>
    [Argument(Format = "--approved-only")] public bool? ApprovedOnly => Get<bool?>(() => ApprovedOnly);
    /// <summary>Only return packages that have a download cache available - this option will filter out results not from the community repository.</summary>
    [Argument(Format = "--download-cache-only")] public bool? DownloadCacheAvailable => Get<bool?>(() => DownloadCacheAvailable);
    /// <summary>Only return packages that are not failing testing - this option only filters out failing results from the <a href="https://comminty.chocolatey.org/packages">community feed</a>. It willnot filter against other sources.</summary>
    [Argument(Format = "--not-broken")] public bool? NotBroken => Get<bool?>(() => NotBroken);
    /// <summary>Alias for verbose.</summary>
    [Argument(Format = "--detailed")] public bool? Detailed => Get<bool?>(() => Detailed);
    /// <summary>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</summary>
    [Argument(Format = "--disable-package-repository-optimizations")] public bool? DisablePackageRepositoryOptimizations => Get<bool?>(() => DisablePackageRepositoryOptimizations);
    /// <summary>Display auditing information for a package.</summary>
    [Argument(Format = "--show-audit-info")] public bool? ShowAuditInformation => Get<bool?>(() => ShowAuditInformation);
    /// <summary>Used with authenticated feeds. Defaults to empty.</summary>
    [Argument(Format = "--user={value}")] public string User => Get<string>(() => User);
    /// <summary>The user's password to the source. Defaults to empty.</summary>
    [Argument(Format = "--password={value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>PFX pathname for an x509 authenticated feeds. Defaults to empty.</summary>
    [Argument(Format = "--cert={value}")] public string ClientCertificate => Get<string>(() => ClientCertificate);
    /// <summary>The client certificate's password to the source. Defaults to empty.</summary>
    [Argument(Format = "--certpassword={value}", Secret = true)] public string CertificatePassword => Get<string>(() => CertificatePassword);
    /// <summary>Show debug messaging.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</summary>
    [Argument(Format = "--verbose")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</summary>
    [Argument(Format = "--trace")] public bool? Trace => Get<bool?>(() => Trace);
    /// <summary>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</summary>
    [Argument(Format = "--no-color")] public bool? NoColor => Get<bool?>(() => NoColor);
    /// <summary>Accept license dialogs automatically. Reserved for future use.</summary>
    [Argument(Format = "--accept-license")] public bool? AcceptLicense => Get<bool?>(() => AcceptLicense);
    /// <summary>Chooses affirmative answer instead of prompting. Implies --accept-license</summary>
    [Argument(Format = "--confirm")] public bool? Confirm => Get<bool?>(() => Confirm);
    /// <summary>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Limit the output to essential information</summary>
    [Argument(Format = "--limit-output")] public bool? LimitOutput => Get<bool?>(() => LimitOutput);
    /// <summary>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</summary>
    [Argument(Format = "--execution-timeout={value}")] public int? CommandExecutionTimeout => Get<int?>(() => CommandExecutionTimeout);
    /// <summary>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</summary>
    [Argument(Format = "--cache-location {value}")] public string CacheLocation => Get<string>(() => CacheLocation);
    /// <summary>When not using the official build you must set this flag for choco to continue.</summary>
    [Argument(Format = "--allow-unofficial-build")] public bool? AllowUnofficialBuild => Get<bool?>(() => AllowUnofficialBuild);
    /// <summary>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</summary>
    [Argument(Format = "--fail-on-standard-error")] public bool? FailOnStandardError => Get<bool?>(() => FailOnStandardError);
    /// <summary>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</summary>
    [Argument(Format = "--use-system-powershell")] public bool? UseSystemPowerShell => Get<bool?>(() => UseSystemPowerShell);
    /// <summary>Do not show download progress percentages.</summary>
    [Argument(Format = "--no-progress")] public bool? DoNotShowProgress => Get<bool?>(() => DoNotShowProgress);
    /// <summary>Explicit proxy location. Overrides the default proxy location of ''.</summary>
    [Argument(Format = "--proxy={value}")] public string Proxy => Get<string>(() => Proxy);
    /// <summary>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</summary>
    [Argument(Format = "--proxy-user={value}")] public string ProxyUserName => Get<string>(() => ProxyUserName);
    /// <summary>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</summary>
    [Argument(Format = "--proxy-password={value}", Secret = true)] public string ProxyPassword => Get<string>(() => ProxyPassword);
    /// <summary>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</summary>
    [Argument(Format = "--proxy-bypass-list={value}", Separator = ",")] public IReadOnlyList<string> ProxyBypassList => Get<List<string>>(() => ProxyBypassList);
    /// <summary>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</summary>
    [Argument(Format = "--proxy-bypass-on-local")] public bool? ProxyBypassOnLocal => Get<bool?>(() => ProxyBypassOnLocal);
    /// <summary>Log File to output to in addition to regular loggers.</summary>
    [Argument(Format = "--log-file={value}")] public string LogFile => Get<string>(() => LogFile);
}
#endregion
#region ChocolateyOutdatedSettings
/// <summary>Used within <see cref="ChocolateyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<ChocolateyOutdatedSettings>))]
[Command(Type = typeof(ChocolateyTasks), Command = nameof(ChocolateyTasks.ChocolateyOutdated), Arguments = "outdated")]
public partial class ChocolateyOutdatedSettings : ToolOptions
{
    /// <summary>The source to find the package(s) to install. Special sources include: ruby, webpi, cygwin, windowsfeatures, and python. To specify more than one source, pass it with a semi-colon separating the values (-e.g. "'source1;source2'"). Defaults to default feeds.</summary>
    [Argument(Format = "--source={value}")] public string Source => Get<string>(() => Source);
    /// <summary>Include Prereleases? Defaults to false.</summary>
    [Argument(Format = "--prerelease")] public bool? Prerelease => Get<bool?>(() => Prerelease);
    /// <summary>Ignore pinned packages. Defaults to false.</summary>
    [Argument(Format = "--ignore-pinned")] public bool? IgnorePinned => Get<bool?>(() => IgnorePinned);
    /// <summary>Ignore packages that are not found on the sources used (or the defaults). Overrides the default feature 'ignoreUnfoundPackagesOnUpgradeOutdated' set to 'False'.</summary>
    [Argument(Format = "--ignore-unfound")] public bool? IgnoreUnfound => Get<bool?>(() => IgnoreUnfound);
    /// <summary>Do not use optimizations for reducing bandwidth with repository queries during package install/upgrade/outdated operations. Should not generally be used, unless a repository needs to support older methods of query. When disabled, this makes queries similar to the way they were done in Chocolatey v0.10.11 and before. Overrides the default feature 'usePackageRepositoryOptimizations' set to 'True'.</summary>
    [Argument(Format = "--disable-package-repository-optimizations")] public bool? DisablePackageRepositoryOptimizations => Get<bool?>(() => DisablePackageRepositoryOptimizations);
    /// <summary>Used with authenticated feeds. Defaults to empty.</summary>
    [Argument(Format = "--user={value}")] public string User => Get<string>(() => User);
    /// <summary>The user's password to the source. Defaults to empty.</summary>
    [Argument(Format = "--password={value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>PFX pathname for an x509 authenticated feeds. Defaults to empty.</summary>
    [Argument(Format = "--cert={value}")] public string ClientCertificate => Get<string>(() => ClientCertificate);
    /// <summary>The client certificate's password to the source. Defaults to empty.</summary>
    [Argument(Format = "--certpassword={value}", Secret = true)] public string CertificatePassword => Get<string>(() => CertificatePassword);
    /// <summary>Show debug messaging.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</summary>
    [Argument(Format = "--verbose")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</summary>
    [Argument(Format = "--trace")] public bool? Trace => Get<bool?>(() => Trace);
    /// <summary>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</summary>
    [Argument(Format = "--no-color")] public bool? NoColor => Get<bool?>(() => NoColor);
    /// <summary>Accept license dialogs automatically. Reserved for future use.</summary>
    [Argument(Format = "--accept-license")] public bool? AcceptLicense => Get<bool?>(() => AcceptLicense);
    /// <summary>Chooses affirmative answer instead of prompting. Implies --accept-license</summary>
    [Argument(Format = "--confirm")] public bool? Confirm => Get<bool?>(() => Confirm);
    /// <summary>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Limit the output to essential information</summary>
    [Argument(Format = "--limit-output")] public bool? LimitOutput => Get<bool?>(() => LimitOutput);
    /// <summary>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</summary>
    [Argument(Format = "--execution-timeout={value}")] public int? CommandExecutionTimeout => Get<int?>(() => CommandExecutionTimeout);
    /// <summary>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</summary>
    [Argument(Format = "--cache-location {value}")] public string CacheLocation => Get<string>(() => CacheLocation);
    /// <summary>When not using the official build you must set this flag for choco to continue.</summary>
    [Argument(Format = "--allow-unofficial-build")] public bool? AllowUnofficialBuild => Get<bool?>(() => AllowUnofficialBuild);
    /// <summary>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</summary>
    [Argument(Format = "--fail-on-standard-error")] public bool? FailOnStandardError => Get<bool?>(() => FailOnStandardError);
    /// <summary>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</summary>
    [Argument(Format = "--use-system-powershell")] public bool? UseSystemPowerShell => Get<bool?>(() => UseSystemPowerShell);
    /// <summary>Do not show download progress percentages.</summary>
    [Argument(Format = "--no-progress")] public bool? DoNotShowProgress => Get<bool?>(() => DoNotShowProgress);
    /// <summary>Explicit proxy location. Overrides the default proxy location of ''.</summary>
    [Argument(Format = "--proxy={value}")] public string Proxy => Get<string>(() => Proxy);
    /// <summary>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</summary>
    [Argument(Format = "--proxy-user={value}")] public string ProxyUserName => Get<string>(() => ProxyUserName);
    /// <summary>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</summary>
    [Argument(Format = "--proxy-password={value}", Secret = true)] public string ProxyPassword => Get<string>(() => ProxyPassword);
    /// <summary>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</summary>
    [Argument(Format = "--proxy-bypass-list={value}", Separator = ",")] public IReadOnlyList<string> ProxyBypassList => Get<List<string>>(() => ProxyBypassList);
    /// <summary>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</summary>
    [Argument(Format = "--proxy-bypass-on-local")] public bool? ProxyBypassOnLocal => Get<bool?>(() => ProxyBypassOnLocal);
    /// <summary>Log File to output to in addition to regular loggers.</summary>
    [Argument(Format = "--log-file={value}")] public string LogFile => Get<string>(() => LogFile);
}
#endregion
#region ChocolateyPackSettings
/// <summary>Used within <see cref="ChocolateyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<ChocolateyPackSettings>))]
[Command(Type = typeof(ChocolateyTasks), Command = nameof(ChocolateyTasks.ChocolateyPack), Arguments = "pack")]
public partial class ChocolateyPackSettings : ToolOptions
{
    /// <summary>Path to nuspec</summary>
    [Argument(Format = "{value}", Position = 1)] public string PathToNuspec => Get<string>(() => PathToNuspec);
    /// <summary>The version you would like to insert into the package.</summary>
    [Argument(Format = "--version={value}")] public string Version => Get<string>(() => Version);
    /// <summary>Specifies the directory for the created Chocolatey package file. If not specified, uses the current directory.</summary>
    [Argument(Format = "--output-directory={value}")] public string OutputDirectory => Get<string>(() => OutputDirectory);
    /// <summary>You can pass arbitrary property value pairs through to nuspecs. These will replace variables formatted as <em>$property$</em> with the value passed.</summary>
    [Argument(Format = "-- {key}={value}", Position = -1, Separator = " ")] public IReadOnlyDictionary<string, object> Properties => Get<Dictionary<string, object>>(() => Properties);
    /// <summary>Show debug messaging.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</summary>
    [Argument(Format = "--verbose")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</summary>
    [Argument(Format = "--trace")] public bool? Trace => Get<bool?>(() => Trace);
    /// <summary>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</summary>
    [Argument(Format = "--no-color")] public bool? NoColor => Get<bool?>(() => NoColor);
    /// <summary>Accept license dialogs automatically. Reserved for future use.</summary>
    [Argument(Format = "--accept-license")] public bool? AcceptLicense => Get<bool?>(() => AcceptLicense);
    /// <summary>Chooses affirmative answer instead of prompting. Implies --accept-license</summary>
    [Argument(Format = "--confirm")] public bool? Confirm => Get<bool?>(() => Confirm);
    /// <summary>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Limit the output to essential information</summary>
    [Argument(Format = "--limit-output")] public bool? LimitOutput => Get<bool?>(() => LimitOutput);
    /// <summary>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</summary>
    [Argument(Format = "--execution-timeout={value}")] public int? CommandExecutionTimeout => Get<int?>(() => CommandExecutionTimeout);
    /// <summary>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</summary>
    [Argument(Format = "--cache-location {value}")] public string CacheLocation => Get<string>(() => CacheLocation);
    /// <summary>When not using the official build you must set this flag for choco to continue.</summary>
    [Argument(Format = "--allow-unofficial-build")] public bool? AllowUnofficialBuild => Get<bool?>(() => AllowUnofficialBuild);
    /// <summary>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</summary>
    [Argument(Format = "--fail-on-standard-error")] public bool? FailOnStandardError => Get<bool?>(() => FailOnStandardError);
    /// <summary>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</summary>
    [Argument(Format = "--use-system-powershell")] public bool? UseSystemPowerShell => Get<bool?>(() => UseSystemPowerShell);
    /// <summary>Do not show download progress percentages.</summary>
    [Argument(Format = "--no-progress")] public bool? DoNotShowProgress => Get<bool?>(() => DoNotShowProgress);
    /// <summary>Explicit proxy location. Overrides the default proxy location of ''.</summary>
    [Argument(Format = "--proxy={value}")] public string Proxy => Get<string>(() => Proxy);
    /// <summary>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</summary>
    [Argument(Format = "--proxy-user={value}")] public string ProxyUserName => Get<string>(() => ProxyUserName);
    /// <summary>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</summary>
    [Argument(Format = "--proxy-password={value}", Secret = true)] public string ProxyPassword => Get<string>(() => ProxyPassword);
    /// <summary>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</summary>
    [Argument(Format = "--proxy-bypass-list={value}", Separator = ",")] public IReadOnlyList<string> ProxyBypassList => Get<List<string>>(() => ProxyBypassList);
    /// <summary>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</summary>
    [Argument(Format = "--proxy-bypass-on-local")] public bool? ProxyBypassOnLocal => Get<bool?>(() => ProxyBypassOnLocal);
    /// <summary>Log File to output to in addition to regular loggers.</summary>
    [Argument(Format = "--log-file={value}")] public string LogFile => Get<string>(() => LogFile);
}
#endregion
#region ChocolateyPushSettings
/// <summary>Used within <see cref="ChocolateyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<ChocolateyPushSettings>))]
[Command(Type = typeof(ChocolateyTasks), Command = nameof(ChocolateyTasks.ChocolateyPush), Arguments = "push")]
public partial class ChocolateyPushSettings : ToolOptions
{
    /// <summary>Path to Nuget package (.nupkg).</summary>
    [Argument(Format = "{value}", Position = 1)] public string PathToNuGetPackage => Get<string>(() => PathToNuGetPackage);
    /// <summary>The source we are pushing the package to. Use <a href="https://pus-h.chocolatey.org/">https://pus-h.chocolatey.org/</a> to push to <a href="https://comminty.chocolatey.org/packages">community feed</a>.</summary>
    [Argument(Format = "--source={value}")] public string Source => Get<string>(() => Source);
    /// <summary>The api key for the source. If not specified (and not local file source), does a lookup. If not specified and one is not found for an https source, push will fail.</summary>
    [Argument(Format = "--api-key={value}", Secret = true)] public string ApiKey => Get<string>(() => ApiKey);
    /// <summary>The time to allow a package push to occur before timing out. Defaults to execution timeout 2700 seconds.</summary>
    [Argument(Format = "-t={value}")] public int? Timeout => Get<int?>(() => Timeout);
    /// <summary>Show debug messaging.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</summary>
    [Argument(Format = "--verbose")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</summary>
    [Argument(Format = "--trace")] public bool? Trace => Get<bool?>(() => Trace);
    /// <summary>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</summary>
    [Argument(Format = "--no-color")] public bool? NoColor => Get<bool?>(() => NoColor);
    /// <summary>Accept license dialogs automatically. Reserved for future use.</summary>
    [Argument(Format = "--accept-license")] public bool? AcceptLicense => Get<bool?>(() => AcceptLicense);
    /// <summary>Chooses affirmative answer instead of prompting. Implies --accept-license</summary>
    [Argument(Format = "--confirm")] public bool? Confirm => Get<bool?>(() => Confirm);
    /// <summary>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Limit the output to essential information</summary>
    [Argument(Format = "--limit-output")] public bool? LimitOutput => Get<bool?>(() => LimitOutput);
    /// <summary>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</summary>
    [Argument(Format = "--execution-timeout={value}")] public int? CommandExecutionTimeout => Get<int?>(() => CommandExecutionTimeout);
    /// <summary>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</summary>
    [Argument(Format = "--cache-location {value}")] public string CacheLocation => Get<string>(() => CacheLocation);
    /// <summary>When not using the official build you must set this flag for choco to continue.</summary>
    [Argument(Format = "--allow-unofficial-build")] public bool? AllowUnofficialBuild => Get<bool?>(() => AllowUnofficialBuild);
    /// <summary>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</summary>
    [Argument(Format = "--fail-on-standard-error")] public bool? FailOnStandardError => Get<bool?>(() => FailOnStandardError);
    /// <summary>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</summary>
    [Argument(Format = "--use-system-powershell")] public bool? UseSystemPowerShell => Get<bool?>(() => UseSystemPowerShell);
    /// <summary>Do not show download progress percentages.</summary>
    [Argument(Format = "--no-progress")] public bool? DoNotShowProgress => Get<bool?>(() => DoNotShowProgress);
    /// <summary>Explicit proxy location. Overrides the default proxy location of ''.</summary>
    [Argument(Format = "--proxy={value}")] public string Proxy => Get<string>(() => Proxy);
    /// <summary>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</summary>
    [Argument(Format = "--proxy-user={value}")] public string ProxyUserName => Get<string>(() => ProxyUserName);
    /// <summary>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</summary>
    [Argument(Format = "--proxy-password={value}", Secret = true)] public string ProxyPassword => Get<string>(() => ProxyPassword);
    /// <summary>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</summary>
    [Argument(Format = "--proxy-bypass-list={value}", Separator = ",")] public IReadOnlyList<string> ProxyBypassList => Get<List<string>>(() => ProxyBypassList);
    /// <summary>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</summary>
    [Argument(Format = "--proxy-bypass-on-local")] public bool? ProxyBypassOnLocal => Get<bool?>(() => ProxyBypassOnLocal);
    /// <summary>Log File to output to in addition to regular loggers.</summary>
    [Argument(Format = "--log-file={value}")] public string LogFile => Get<string>(() => LogFile);
}
#endregion
#region ChocolateyNewSettings
/// <summary>Used within <see cref="ChocolateyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<ChocolateyNewSettings>))]
[Command(Type = typeof(ChocolateyTasks), Command = nameof(ChocolateyTasks.ChocolateyNew), Arguments = "new")]
public partial class ChocolateyNewSettings : ToolOptions
{
    /// <summary>Generate automatic package instead of normal. Defaults to false.</summary>
    [Argument(Format = "--automaticpackage")] public bool? AutomaticPackage => Get<bool?>(() => AutomaticPackage);
    /// <summary>Use a named template in <em>C:\ProgramData\chocolatey\templates\templatename</em> instead of built-in template.</summary>
    [Argument(Format = "--template-name={value}")] public string TemplateName => Get<string>(() => TemplateName);
    /// <summary>The required name of the package.</summary>
    [Argument(Format = "--name={value}")] public string Name => Get<string>(() => Name);
    /// <summary>The version of the package.</summary>
    [Argument(Format = "--version={value}")] public string Version => Get<string>(() => Version);
    /// <summary>The name of the maintainer.</summary>
    [Argument(Format = "--maintainer={value}")] public string Maintainer => Get<string>(() => Maintainer);
    /// <summary>Specifies the directory for the created Chocolatey package file. If not specified, uses the current directory.</summary>
    [Argument(Format = "--output-directory={value}")] public string OutputDirectory => Get<string>(() => OutputDirectory);
    /// <summary>Use the original built-in template instead of any override.</summary>
    [Argument(Format = "--use-built-in-template")] public bool? BuildInTemplate => Get<bool?>(() => BuildInTemplate);
    /// <summary>In <a href="https://chocolatey.org/compare">Chocolatey for Business</a>, file is used for auto-detection (native installer, zip, patch/upgrade file, or remote url to download first) to completely create a package with proper silent arguments! Can be 32-bit or 64-bit architecture.</summary>
    [Argument(Format = "--file={value}")] public string LocationOfBinary => Get<string>(() => LocationOfBinary);
    /// <summary>Used when specifying both a 32-bit and a 64-bit file. Can be an installer or a zip, or remote url to download.</summary>
    [Argument(Format = "--file64={value}")] public string LocationOfBinary64 => Get<string>(() => LocationOfBinary64);
    /// <summary>When using file or url, use the original location in packaging.</summary>
    [Argument(Format = "--use-original-files-location")] public bool? UseOriginalFilesLocation => Get<bool?>(() => UseOriginalFilesLocation);
    /// <summary>Checksum to verify File/Url with. Defaults to empty.</summary>
    [Argument(Format = "--checksum={value}")] public string Checksum => Get<string>(() => Checksum);
    /// <summary>Checksum to verify File64/Url64 with. Defaults to empty.</summary>
    [Argument(Format = "--checksum-x64={value}")] public string Checksum64 => Get<string>(() => Checksum64);
    /// <summary>checksum type for File/Url (and optional separate 64-bit files when specifying both). Used in conjunction with Download Checksum and Download Checksum 64-bit. Available values are 'md5', 'sha1', 'sha256' or 'sha512'. Defaults to 'sha256'.</summary>
    [Argument(Format = "--checksum-type={value}")] public string ChecksumType => Get<string>(() => ChecksumType);
    /// <summary>Pause when there is an error with creating the package.</summary>
    [Argument(Format = "--pause-on-error")] public bool? PauseOnError => Get<bool?>(() => PauseOnError);
    /// <summary>Attempt to compile the package after creating it.</summary>
    [Argument(Format = "--build-package")] public bool? BuildPackage => Get<bool?>(() => BuildPackage);
    /// <summary>Generate packages from the installed software on a system (does not handle dependencies).</summary>
    [Argument(Format = "--from-programs-and-features")] public bool? GenerateFromInstalledSoftware => Get<bool?>(() => GenerateFromInstalledSoftware);
    /// <summary>Generate the package for community use.</summary>
    [Argument(Format = "--generate-for-community")] public bool? GenerateForCommunity => Get<bool?>(() => GenerateForCommunity);
    /// <summary>Remove x86, x64, 64-bit, etc from the package id. Default setting is to remove architecture.</summary>
    [Argument(Format = "--remove-architecture-from-name")] public bool? RemoveArchitectureFromName => Get<bool?>(() => RemoveArchitectureFromName);
    /// <summary>Leave x86, x64, 64-bit, etc as part of the package id. Default setting is to remove architecture.</summary>
    [Argument(Format = "--include-architecture-in-name")] public bool? IncludeArchitectureInName => Get<bool?>(() => IncludeArchitectureInName);
    /// <summary>You can pass arbitrary property value pairs through to templates. This really unlocks your ability to create packages automatically!</summary>
    [Argument(Format = "-- {key}={value}", Position = -1, Separator = " ")] public IReadOnlyDictionary<string, object> Properties => Get<Dictionary<string, object>>(() => Properties);
    /// <summary>Show debug messaging.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.</summary>
    [Argument(Format = "--verbose")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging. Available in 0.10.4+.</summary>
    [Argument(Format = "--trace")] public bool? Trace => Get<bool?>(() => Trace);
    /// <summary>Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'. Available in 0.10.9+.</summary>
    [Argument(Format = "--no-color")] public bool? NoColor => Get<bool?>(() => NoColor);
    /// <summary>Accept license dialogs automatically. Reserved for future use.</summary>
    [Argument(Format = "--accept-license")] public bool? AcceptLicense => Get<bool?>(() => AcceptLicense);
    /// <summary>Chooses affirmative answer instead of prompting. Implies --accept-license</summary>
    [Argument(Format = "--confirm")] public bool? Confirm => Get<bool?>(() => Confirm);
    /// <summary>Force the behavior. Do not use force during normal operation - it subverts some of the smart behavior for commands.</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Limit the output to essential information</summary>
    [Argument(Format = "--limit-output")] public bool? LimitOutput => Get<bool?>(() => LimitOutput);
    /// <summary>The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.</summary>
    [Argument(Format = "--execution-timeout={value}")] public int? CommandExecutionTimeout => Get<int?>(() => CommandExecutionTimeout);
    /// <summary>Location for download cache, defaults to %TEMP% or value in chocolatey.config file.</summary>
    [Argument(Format = "--cache-location {value}")] public string CacheLocation => Get<string>(() => CacheLocation);
    /// <summary>When not using the official build you must set this flag for choco to continue.</summary>
    [Argument(Format = "--allow-unofficial-build")] public bool? AllowUnofficialBuild => Get<bool?>(() => AllowUnofficialBuild);
    /// <summary>Fail on standard error output (stderr), typically received when running external commands during install providers. This overrides the feature failOnStandardError.</summary>
    [Argument(Format = "--fail-on-standard-error")] public bool? FailOnStandardError => Get<bool?>(() => FailOnStandardError);
    /// <summary>Execute PowerShell using an external process instead of the built-in PowerShell host. Should only be used when internal host is failing.</summary>
    [Argument(Format = "--use-system-powershell")] public bool? UseSystemPowerShell => Get<bool?>(() => UseSystemPowerShell);
    /// <summary>Do not show download progress percentages.</summary>
    [Argument(Format = "--no-progress")] public bool? DoNotShowProgress => Get<bool?>(() => DoNotShowProgress);
    /// <summary>Explicit proxy location. Overrides the default proxy location of ''.</summary>
    [Argument(Format = "--proxy={value}")] public string Proxy => Get<string>(() => Proxy);
    /// <summary>Explicit proxy user (optional). Requires explicit proxy (`--proxy` or config setting). Overrides the default proxy user of ''.</summary>
    [Argument(Format = "--proxy-user={value}")] public string ProxyUserName => Get<string>(() => ProxyUserName);
    /// <summary>Explicit proxy password (optional) to be used with username. Requires explicit proxy (`--proxy` or config setting) and user name. Overrides the default proxy password (encrypted in settings sif set).</summary>
    [Argument(Format = "--proxy-password={value}", Secret = true)] public string ProxyPassword => Get<string>(() => ProxyPassword);
    /// <summary>Comma separated list of regex locations to bypass on proxy. Requires explicit proxy (`--proxy` or config setting).</summary>
    [Argument(Format = "--proxy-bypass-list={value}", Separator = ",")] public IReadOnlyList<string> ProxyBypassList => Get<List<string>>(() => ProxyBypassList);
    /// <summary>Bypass proxy for local connections. Requires explicit proxy (`--proxy` or config setting).</summary>
    [Argument(Format = "--proxy-bypass-on-local")] public bool? ProxyBypassOnLocal => Get<bool?>(() => ProxyBypassOnLocal);
    /// <summary>Log File to output to in addition to regular loggers.</summary>
    [Argument(Format = "--log-file={value}")] public string LogFile => Get<string>(() => LogFile);
}
#endregion
#region ChocolateySearchSettingsExtensions
/// <summary>Used within <see cref="ChocolateyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class ChocolateySearchSettingsExtensions
{
    #region Filter
    /// <inheritdoc cref="ChocolateySearchSettings.Filter"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Filter))]
    public static T SetFilter<T>(this T o, string v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Filter, v));
    /// <inheritdoc cref="ChocolateySearchSettings.Filter"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Filter))]
    public static T ResetFilter<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.Filter));
    #endregion
    #region Source
    /// <inheritdoc cref="ChocolateySearchSettings.Source"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Source))]
    public static T SetSource<T>(this T o, string v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="ChocolateySearchSettings.Source"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Source))]
    public static T ResetSource<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.Source));
    #endregion
    #region LocalOnly
    /// <inheritdoc cref="ChocolateySearchSettings.LocalOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.LocalOnly))]
    public static T SetLocalOnly<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.LocalOnly, v));
    /// <inheritdoc cref="ChocolateySearchSettings.LocalOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.LocalOnly))]
    public static T ResetLocalOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.LocalOnly));
    /// <inheritdoc cref="ChocolateySearchSettings.LocalOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.LocalOnly))]
    public static T EnableLocalOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.LocalOnly, true));
    /// <inheritdoc cref="ChocolateySearchSettings.LocalOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.LocalOnly))]
    public static T DisableLocalOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.LocalOnly, false));
    /// <inheritdoc cref="ChocolateySearchSettings.LocalOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.LocalOnly))]
    public static T ToggleLocalOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.LocalOnly, !o.LocalOnly));
    #endregion
    #region IdOnly
    /// <inheritdoc cref="ChocolateySearchSettings.IdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.IdOnly))]
    public static T SetIdOnly<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.IdOnly, v));
    /// <inheritdoc cref="ChocolateySearchSettings.IdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.IdOnly))]
    public static T ResetIdOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.IdOnly));
    /// <inheritdoc cref="ChocolateySearchSettings.IdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.IdOnly))]
    public static T EnableIdOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.IdOnly, true));
    /// <inheritdoc cref="ChocolateySearchSettings.IdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.IdOnly))]
    public static T DisableIdOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.IdOnly, false));
    /// <inheritdoc cref="ChocolateySearchSettings.IdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.IdOnly))]
    public static T ToggleIdOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.IdOnly, !o.IdOnly));
    #endregion
    #region Prerelease
    /// <inheritdoc cref="ChocolateySearchSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Prerelease))]
    public static T SetPrerelease<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Prerelease, v));
    /// <inheritdoc cref="ChocolateySearchSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Prerelease))]
    public static T ResetPrerelease<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.Prerelease));
    /// <inheritdoc cref="ChocolateySearchSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Prerelease))]
    public static T EnablePrerelease<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Prerelease, true));
    /// <inheritdoc cref="ChocolateySearchSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Prerelease))]
    public static T DisablePrerelease<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Prerelease, false));
    /// <inheritdoc cref="ChocolateySearchSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Prerelease))]
    public static T TogglePrerelease<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Prerelease, !o.Prerelease));
    #endregion
    #region IncludePrograms
    /// <inheritdoc cref="ChocolateySearchSettings.IncludePrograms"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.IncludePrograms))]
    public static T SetIncludePrograms<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.IncludePrograms, v));
    /// <inheritdoc cref="ChocolateySearchSettings.IncludePrograms"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.IncludePrograms))]
    public static T ResetIncludePrograms<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.IncludePrograms));
    /// <inheritdoc cref="ChocolateySearchSettings.IncludePrograms"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.IncludePrograms))]
    public static T EnableIncludePrograms<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.IncludePrograms, true));
    /// <inheritdoc cref="ChocolateySearchSettings.IncludePrograms"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.IncludePrograms))]
    public static T DisableIncludePrograms<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.IncludePrograms, false));
    /// <inheritdoc cref="ChocolateySearchSettings.IncludePrograms"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.IncludePrograms))]
    public static T ToggleIncludePrograms<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.IncludePrograms, !o.IncludePrograms));
    #endregion
    #region AllVersions
    /// <inheritdoc cref="ChocolateySearchSettings.AllVersions"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.AllVersions))]
    public static T SetAllVersions<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.AllVersions, v));
    /// <inheritdoc cref="ChocolateySearchSettings.AllVersions"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.AllVersions))]
    public static T ResetAllVersions<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.AllVersions));
    /// <inheritdoc cref="ChocolateySearchSettings.AllVersions"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.AllVersions))]
    public static T EnableAllVersions<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.AllVersions, true));
    /// <inheritdoc cref="ChocolateySearchSettings.AllVersions"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.AllVersions))]
    public static T DisableAllVersions<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.AllVersions, false));
    /// <inheritdoc cref="ChocolateySearchSettings.AllVersions"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.AllVersions))]
    public static T ToggleAllVersions<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.AllVersions, !o.AllVersions));
    #endregion
    #region Version
    /// <inheritdoc cref="ChocolateySearchSettings.Version"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="ChocolateySearchSettings.Version"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Page
    /// <inheritdoc cref="ChocolateySearchSettings.Page"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Page))]
    public static T SetPage<T>(this T o, int? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Page, v));
    /// <inheritdoc cref="ChocolateySearchSettings.Page"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Page))]
    public static T ResetPage<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.Page));
    #endregion
    #region PageSize
    /// <inheritdoc cref="ChocolateySearchSettings.PageSize"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.PageSize))]
    public static T SetPageSize<T>(this T o, int? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.PageSize, v));
    /// <inheritdoc cref="ChocolateySearchSettings.PageSize"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.PageSize))]
    public static T ResetPageSize<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.PageSize));
    #endregion
    #region Exact
    /// <inheritdoc cref="ChocolateySearchSettings.Exact"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Exact))]
    public static T SetExact<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Exact, v));
    /// <inheritdoc cref="ChocolateySearchSettings.Exact"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Exact))]
    public static T ResetExact<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.Exact));
    /// <inheritdoc cref="ChocolateySearchSettings.Exact"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Exact))]
    public static T EnableExact<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Exact, true));
    /// <inheritdoc cref="ChocolateySearchSettings.Exact"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Exact))]
    public static T DisableExact<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Exact, false));
    /// <inheritdoc cref="ChocolateySearchSettings.Exact"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Exact))]
    public static T ToggleExact<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Exact, !o.Exact));
    #endregion
    #region ByIdOnly
    /// <inheritdoc cref="ChocolateySearchSettings.ByIdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ByIdOnly))]
    public static T SetByIdOnly<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ByIdOnly, v));
    /// <inheritdoc cref="ChocolateySearchSettings.ByIdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ByIdOnly))]
    public static T ResetByIdOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.ByIdOnly));
    /// <inheritdoc cref="ChocolateySearchSettings.ByIdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ByIdOnly))]
    public static T EnableByIdOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ByIdOnly, true));
    /// <inheritdoc cref="ChocolateySearchSettings.ByIdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ByIdOnly))]
    public static T DisableByIdOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ByIdOnly, false));
    /// <inheritdoc cref="ChocolateySearchSettings.ByIdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ByIdOnly))]
    public static T ToggleByIdOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ByIdOnly, !o.ByIdOnly));
    #endregion
    #region ByTagOnly
    /// <inheritdoc cref="ChocolateySearchSettings.ByTagOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ByTagOnly))]
    public static T SetByTagOnly<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ByTagOnly, v));
    /// <inheritdoc cref="ChocolateySearchSettings.ByTagOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ByTagOnly))]
    public static T ResetByTagOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.ByTagOnly));
    /// <inheritdoc cref="ChocolateySearchSettings.ByTagOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ByTagOnly))]
    public static T EnableByTagOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ByTagOnly, true));
    /// <inheritdoc cref="ChocolateySearchSettings.ByTagOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ByTagOnly))]
    public static T DisableByTagOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ByTagOnly, false));
    /// <inheritdoc cref="ChocolateySearchSettings.ByTagOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ByTagOnly))]
    public static T ToggleByTagOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ByTagOnly, !o.ByTagOnly));
    #endregion
    #region IdStartsWith
    /// <inheritdoc cref="ChocolateySearchSettings.IdStartsWith"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.IdStartsWith))]
    public static T SetIdStartsWith<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.IdStartsWith, v));
    /// <inheritdoc cref="ChocolateySearchSettings.IdStartsWith"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.IdStartsWith))]
    public static T ResetIdStartsWith<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.IdStartsWith));
    /// <inheritdoc cref="ChocolateySearchSettings.IdStartsWith"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.IdStartsWith))]
    public static T EnableIdStartsWith<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.IdStartsWith, true));
    /// <inheritdoc cref="ChocolateySearchSettings.IdStartsWith"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.IdStartsWith))]
    public static T DisableIdStartsWith<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.IdStartsWith, false));
    /// <inheritdoc cref="ChocolateySearchSettings.IdStartsWith"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.IdStartsWith))]
    public static T ToggleIdStartsWith<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.IdStartsWith, !o.IdStartsWith));
    #endregion
    #region OrderByPopularity
    /// <inheritdoc cref="ChocolateySearchSettings.OrderByPopularity"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.OrderByPopularity))]
    public static T SetOrderByPopularity<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.OrderByPopularity, v));
    /// <inheritdoc cref="ChocolateySearchSettings.OrderByPopularity"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.OrderByPopularity))]
    public static T ResetOrderByPopularity<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.OrderByPopularity));
    /// <inheritdoc cref="ChocolateySearchSettings.OrderByPopularity"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.OrderByPopularity))]
    public static T EnableOrderByPopularity<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.OrderByPopularity, true));
    /// <inheritdoc cref="ChocolateySearchSettings.OrderByPopularity"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.OrderByPopularity))]
    public static T DisableOrderByPopularity<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.OrderByPopularity, false));
    /// <inheritdoc cref="ChocolateySearchSettings.OrderByPopularity"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.OrderByPopularity))]
    public static T ToggleOrderByPopularity<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.OrderByPopularity, !o.OrderByPopularity));
    #endregion
    #region ApprovedOnly
    /// <inheritdoc cref="ChocolateySearchSettings.ApprovedOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ApprovedOnly))]
    public static T SetApprovedOnly<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ApprovedOnly, v));
    /// <inheritdoc cref="ChocolateySearchSettings.ApprovedOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ApprovedOnly))]
    public static T ResetApprovedOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.ApprovedOnly));
    /// <inheritdoc cref="ChocolateySearchSettings.ApprovedOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ApprovedOnly))]
    public static T EnableApprovedOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ApprovedOnly, true));
    /// <inheritdoc cref="ChocolateySearchSettings.ApprovedOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ApprovedOnly))]
    public static T DisableApprovedOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ApprovedOnly, false));
    /// <inheritdoc cref="ChocolateySearchSettings.ApprovedOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ApprovedOnly))]
    public static T ToggleApprovedOnly<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ApprovedOnly, !o.ApprovedOnly));
    #endregion
    #region DownloadCacheAvailable
    /// <inheritdoc cref="ChocolateySearchSettings.DownloadCacheAvailable"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.DownloadCacheAvailable))]
    public static T SetDownloadCacheAvailable<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.DownloadCacheAvailable, v));
    /// <inheritdoc cref="ChocolateySearchSettings.DownloadCacheAvailable"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.DownloadCacheAvailable))]
    public static T ResetDownloadCacheAvailable<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.DownloadCacheAvailable));
    /// <inheritdoc cref="ChocolateySearchSettings.DownloadCacheAvailable"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.DownloadCacheAvailable))]
    public static T EnableDownloadCacheAvailable<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.DownloadCacheAvailable, true));
    /// <inheritdoc cref="ChocolateySearchSettings.DownloadCacheAvailable"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.DownloadCacheAvailable))]
    public static T DisableDownloadCacheAvailable<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.DownloadCacheAvailable, false));
    /// <inheritdoc cref="ChocolateySearchSettings.DownloadCacheAvailable"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.DownloadCacheAvailable))]
    public static T ToggleDownloadCacheAvailable<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.DownloadCacheAvailable, !o.DownloadCacheAvailable));
    #endregion
    #region NotBroken
    /// <inheritdoc cref="ChocolateySearchSettings.NotBroken"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.NotBroken))]
    public static T SetNotBroken<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.NotBroken, v));
    /// <inheritdoc cref="ChocolateySearchSettings.NotBroken"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.NotBroken))]
    public static T ResetNotBroken<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.NotBroken));
    /// <inheritdoc cref="ChocolateySearchSettings.NotBroken"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.NotBroken))]
    public static T EnableNotBroken<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.NotBroken, true));
    /// <inheritdoc cref="ChocolateySearchSettings.NotBroken"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.NotBroken))]
    public static T DisableNotBroken<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.NotBroken, false));
    /// <inheritdoc cref="ChocolateySearchSettings.NotBroken"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.NotBroken))]
    public static T ToggleNotBroken<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.NotBroken, !o.NotBroken));
    #endregion
    #region Detailed
    /// <inheritdoc cref="ChocolateySearchSettings.Detailed"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Detailed))]
    public static T SetDetailed<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Detailed, v));
    /// <inheritdoc cref="ChocolateySearchSettings.Detailed"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Detailed))]
    public static T ResetDetailed<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.Detailed));
    /// <inheritdoc cref="ChocolateySearchSettings.Detailed"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Detailed))]
    public static T EnableDetailed<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Detailed, true));
    /// <inheritdoc cref="ChocolateySearchSettings.Detailed"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Detailed))]
    public static T DisableDetailed<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Detailed, false));
    /// <inheritdoc cref="ChocolateySearchSettings.Detailed"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Detailed))]
    public static T ToggleDetailed<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Detailed, !o.Detailed));
    #endregion
    #region DisablePackageRepositoryOptimizations
    /// <inheritdoc cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.DisablePackageRepositoryOptimizations))]
    public static T SetDisablePackageRepositoryOptimizations<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, v));
    /// <inheritdoc cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.DisablePackageRepositoryOptimizations))]
    public static T ResetDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.DisablePackageRepositoryOptimizations));
    /// <inheritdoc cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.DisablePackageRepositoryOptimizations))]
    public static T EnableDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, true));
    /// <inheritdoc cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.DisablePackageRepositoryOptimizations))]
    public static T DisableDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, false));
    /// <inheritdoc cref="ChocolateySearchSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.DisablePackageRepositoryOptimizations))]
    public static T ToggleDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, !o.DisablePackageRepositoryOptimizations));
    #endregion
    #region ShowAuditInformation
    /// <inheritdoc cref="ChocolateySearchSettings.ShowAuditInformation"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ShowAuditInformation))]
    public static T SetShowAuditInformation<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ShowAuditInformation, v));
    /// <inheritdoc cref="ChocolateySearchSettings.ShowAuditInformation"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ShowAuditInformation))]
    public static T ResetShowAuditInformation<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.ShowAuditInformation));
    /// <inheritdoc cref="ChocolateySearchSettings.ShowAuditInformation"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ShowAuditInformation))]
    public static T EnableShowAuditInformation<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ShowAuditInformation, true));
    /// <inheritdoc cref="ChocolateySearchSettings.ShowAuditInformation"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ShowAuditInformation))]
    public static T DisableShowAuditInformation<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ShowAuditInformation, false));
    /// <inheritdoc cref="ChocolateySearchSettings.ShowAuditInformation"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ShowAuditInformation))]
    public static T ToggleShowAuditInformation<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ShowAuditInformation, !o.ShowAuditInformation));
    #endregion
    #region User
    /// <inheritdoc cref="ChocolateySearchSettings.User"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.User))]
    public static T SetUser<T>(this T o, string v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.User, v));
    /// <inheritdoc cref="ChocolateySearchSettings.User"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.User))]
    public static T ResetUser<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.User));
    #endregion
    #region Password
    /// <inheritdoc cref="ChocolateySearchSettings.Password"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="ChocolateySearchSettings.Password"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region ClientCertificate
    /// <inheritdoc cref="ChocolateySearchSettings.ClientCertificate"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ClientCertificate))]
    public static T SetClientCertificate<T>(this T o, string v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ClientCertificate, v));
    /// <inheritdoc cref="ChocolateySearchSettings.ClientCertificate"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ClientCertificate))]
    public static T ResetClientCertificate<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.ClientCertificate));
    #endregion
    #region CertificatePassword
    /// <inheritdoc cref="ChocolateySearchSettings.CertificatePassword"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.CertificatePassword))]
    public static T SetCertificatePassword<T>(this T o, [Secret] string v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.CertificatePassword, v));
    /// <inheritdoc cref="ChocolateySearchSettings.CertificatePassword"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.CertificatePassword))]
    public static T ResetCertificatePassword<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.CertificatePassword));
    #endregion
    #region Debug
    /// <inheritdoc cref="ChocolateySearchSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="ChocolateySearchSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="ChocolateySearchSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="ChocolateySearchSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="ChocolateySearchSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region Verbose
    /// <inheritdoc cref="ChocolateySearchSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="ChocolateySearchSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="ChocolateySearchSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="ChocolateySearchSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="ChocolateySearchSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region Trace
    /// <inheritdoc cref="ChocolateySearchSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Trace))]
    public static T SetTrace<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Trace, v));
    /// <inheritdoc cref="ChocolateySearchSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Trace))]
    public static T ResetTrace<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.Trace));
    /// <inheritdoc cref="ChocolateySearchSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Trace))]
    public static T EnableTrace<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Trace, true));
    /// <inheritdoc cref="ChocolateySearchSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Trace))]
    public static T DisableTrace<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Trace, false));
    /// <inheritdoc cref="ChocolateySearchSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Trace))]
    public static T ToggleTrace<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Trace, !o.Trace));
    #endregion
    #region NoColor
    /// <inheritdoc cref="ChocolateySearchSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.NoColor))]
    public static T SetNoColor<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.NoColor, v));
    /// <inheritdoc cref="ChocolateySearchSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.NoColor))]
    public static T ResetNoColor<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.NoColor));
    /// <inheritdoc cref="ChocolateySearchSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.NoColor))]
    public static T EnableNoColor<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.NoColor, true));
    /// <inheritdoc cref="ChocolateySearchSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.NoColor))]
    public static T DisableNoColor<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.NoColor, false));
    /// <inheritdoc cref="ChocolateySearchSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.NoColor))]
    public static T ToggleNoColor<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.NoColor, !o.NoColor));
    #endregion
    #region AcceptLicense
    /// <inheritdoc cref="ChocolateySearchSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.AcceptLicense))]
    public static T SetAcceptLicense<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.AcceptLicense, v));
    /// <inheritdoc cref="ChocolateySearchSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.AcceptLicense))]
    public static T ResetAcceptLicense<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.AcceptLicense));
    /// <inheritdoc cref="ChocolateySearchSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.AcceptLicense))]
    public static T EnableAcceptLicense<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.AcceptLicense, true));
    /// <inheritdoc cref="ChocolateySearchSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.AcceptLicense))]
    public static T DisableAcceptLicense<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.AcceptLicense, false));
    /// <inheritdoc cref="ChocolateySearchSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.AcceptLicense))]
    public static T ToggleAcceptLicense<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.AcceptLicense, !o.AcceptLicense));
    #endregion
    #region Confirm
    /// <inheritdoc cref="ChocolateySearchSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Confirm))]
    public static T SetConfirm<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Confirm, v));
    /// <inheritdoc cref="ChocolateySearchSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Confirm))]
    public static T ResetConfirm<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.Confirm));
    /// <inheritdoc cref="ChocolateySearchSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Confirm))]
    public static T EnableConfirm<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Confirm, true));
    /// <inheritdoc cref="ChocolateySearchSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Confirm))]
    public static T DisableConfirm<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Confirm, false));
    /// <inheritdoc cref="ChocolateySearchSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Confirm))]
    public static T ToggleConfirm<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Confirm, !o.Confirm));
    #endregion
    #region Force
    /// <inheritdoc cref="ChocolateySearchSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="ChocolateySearchSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Force))]
    public static T ResetForce<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="ChocolateySearchSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Force))]
    public static T EnableForce<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="ChocolateySearchSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Force))]
    public static T DisableForce<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="ChocolateySearchSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region LimitOutput
    /// <inheritdoc cref="ChocolateySearchSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.LimitOutput))]
    public static T SetLimitOutput<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.LimitOutput, v));
    /// <inheritdoc cref="ChocolateySearchSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.LimitOutput))]
    public static T ResetLimitOutput<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.LimitOutput));
    /// <inheritdoc cref="ChocolateySearchSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.LimitOutput))]
    public static T EnableLimitOutput<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.LimitOutput, true));
    /// <inheritdoc cref="ChocolateySearchSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.LimitOutput))]
    public static T DisableLimitOutput<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.LimitOutput, false));
    /// <inheritdoc cref="ChocolateySearchSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.LimitOutput))]
    public static T ToggleLimitOutput<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.LimitOutput, !o.LimitOutput));
    #endregion
    #region CommandExecutionTimeout
    /// <inheritdoc cref="ChocolateySearchSettings.CommandExecutionTimeout"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.CommandExecutionTimeout))]
    public static T SetCommandExecutionTimeout<T>(this T o, int? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.CommandExecutionTimeout, v));
    /// <inheritdoc cref="ChocolateySearchSettings.CommandExecutionTimeout"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.CommandExecutionTimeout))]
    public static T ResetCommandExecutionTimeout<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.CommandExecutionTimeout));
    #endregion
    #region CacheLocation
    /// <inheritdoc cref="ChocolateySearchSettings.CacheLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.CacheLocation))]
    public static T SetCacheLocation<T>(this T o, string v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.CacheLocation, v));
    /// <inheritdoc cref="ChocolateySearchSettings.CacheLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.CacheLocation))]
    public static T ResetCacheLocation<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.CacheLocation));
    #endregion
    #region AllowUnofficialBuild
    /// <inheritdoc cref="ChocolateySearchSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.AllowUnofficialBuild))]
    public static T SetAllowUnofficialBuild<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, v));
    /// <inheritdoc cref="ChocolateySearchSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.AllowUnofficialBuild))]
    public static T ResetAllowUnofficialBuild<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.AllowUnofficialBuild));
    /// <inheritdoc cref="ChocolateySearchSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.AllowUnofficialBuild))]
    public static T EnableAllowUnofficialBuild<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, true));
    /// <inheritdoc cref="ChocolateySearchSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.AllowUnofficialBuild))]
    public static T DisableAllowUnofficialBuild<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, false));
    /// <inheritdoc cref="ChocolateySearchSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.AllowUnofficialBuild))]
    public static T ToggleAllowUnofficialBuild<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, !o.AllowUnofficialBuild));
    #endregion
    #region FailOnStandardError
    /// <inheritdoc cref="ChocolateySearchSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.FailOnStandardError))]
    public static T SetFailOnStandardError<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, v));
    /// <inheritdoc cref="ChocolateySearchSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.FailOnStandardError))]
    public static T ResetFailOnStandardError<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.FailOnStandardError));
    /// <inheritdoc cref="ChocolateySearchSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.FailOnStandardError))]
    public static T EnableFailOnStandardError<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, true));
    /// <inheritdoc cref="ChocolateySearchSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.FailOnStandardError))]
    public static T DisableFailOnStandardError<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, false));
    /// <inheritdoc cref="ChocolateySearchSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.FailOnStandardError))]
    public static T ToggleFailOnStandardError<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, !o.FailOnStandardError));
    #endregion
    #region UseSystemPowerShell
    /// <inheritdoc cref="ChocolateySearchSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.UseSystemPowerShell))]
    public static T SetUseSystemPowerShell<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, v));
    /// <inheritdoc cref="ChocolateySearchSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.UseSystemPowerShell))]
    public static T ResetUseSystemPowerShell<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.UseSystemPowerShell));
    /// <inheritdoc cref="ChocolateySearchSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.UseSystemPowerShell))]
    public static T EnableUseSystemPowerShell<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, true));
    /// <inheritdoc cref="ChocolateySearchSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.UseSystemPowerShell))]
    public static T DisableUseSystemPowerShell<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, false));
    /// <inheritdoc cref="ChocolateySearchSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.UseSystemPowerShell))]
    public static T ToggleUseSystemPowerShell<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, !o.UseSystemPowerShell));
    #endregion
    #region DoNotShowProgress
    /// <inheritdoc cref="ChocolateySearchSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.DoNotShowProgress))]
    public static T SetDoNotShowProgress<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, v));
    /// <inheritdoc cref="ChocolateySearchSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.DoNotShowProgress))]
    public static T ResetDoNotShowProgress<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.DoNotShowProgress));
    /// <inheritdoc cref="ChocolateySearchSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.DoNotShowProgress))]
    public static T EnableDoNotShowProgress<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, true));
    /// <inheritdoc cref="ChocolateySearchSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.DoNotShowProgress))]
    public static T DisableDoNotShowProgress<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, false));
    /// <inheritdoc cref="ChocolateySearchSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.DoNotShowProgress))]
    public static T ToggleDoNotShowProgress<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, !o.DoNotShowProgress));
    #endregion
    #region Proxy
    /// <inheritdoc cref="ChocolateySearchSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Proxy))]
    public static T SetProxy<T>(this T o, string v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.Proxy, v));
    /// <inheritdoc cref="ChocolateySearchSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.Proxy))]
    public static T ResetProxy<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.Proxy));
    #endregion
    #region ProxyUserName
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyUserName"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyUserName))]
    public static T SetProxyUserName<T>(this T o, string v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ProxyUserName, v));
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyUserName"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyUserName))]
    public static T ResetProxyUserName<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.ProxyUserName));
    #endregion
    #region ProxyPassword
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyPassword))]
    public static T SetProxyPassword<T>(this T o, [Secret] string v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ProxyPassword, v));
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyPassword))]
    public static T ResetProxyPassword<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.ProxyPassword));
    #endregion
    #region ProxyBypassList
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyBypassList))]
    public static T SetProxyBypassList<T>(this T o, params string[] v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyBypassList))]
    public static T SetProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyBypassList))]
    public static T AddProxyBypassList<T>(this T o, params string[] v) where T : ChocolateySearchSettings => o.Modify(b => b.AddCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyBypassList))]
    public static T AddProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateySearchSettings => o.Modify(b => b.AddCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyBypassList))]
    public static T RemoveProxyBypassList<T>(this T o, params string[] v) where T : ChocolateySearchSettings => o.Modify(b => b.RemoveCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyBypassList))]
    public static T RemoveProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateySearchSettings => o.Modify(b => b.RemoveCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyBypassList))]
    public static T ClearProxyBypassList<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.ClearCollection(() => o.ProxyBypassList));
    #endregion
    #region ProxyBypassOnLocal
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyBypassOnLocal))]
    public static T SetProxyBypassOnLocal<T>(this T o, bool? v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, v));
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyBypassOnLocal))]
    public static T ResetProxyBypassOnLocal<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.ProxyBypassOnLocal));
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyBypassOnLocal))]
    public static T EnableProxyBypassOnLocal<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, true));
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyBypassOnLocal))]
    public static T DisableProxyBypassOnLocal<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, false));
    /// <inheritdoc cref="ChocolateySearchSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.ProxyBypassOnLocal))]
    public static T ToggleProxyBypassOnLocal<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, !o.ProxyBypassOnLocal));
    #endregion
    #region LogFile
    /// <inheritdoc cref="ChocolateySearchSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : ChocolateySearchSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="ChocolateySearchSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ChocolateySearchSettings), Property = nameof(ChocolateySearchSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : ChocolateySearchSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
}
#endregion
#region ChocolateyListSettingsExtensions
/// <summary>Used within <see cref="ChocolateyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class ChocolateyListSettingsExtensions
{
    #region Filter
    /// <inheritdoc cref="ChocolateyListSettings.Filter"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Filter))]
    public static T SetFilter<T>(this T o, string v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Filter, v));
    /// <inheritdoc cref="ChocolateyListSettings.Filter"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Filter))]
    public static T ResetFilter<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.Filter));
    #endregion
    #region Source
    /// <inheritdoc cref="ChocolateyListSettings.Source"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Source))]
    public static T SetSource<T>(this T o, string v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="ChocolateyListSettings.Source"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Source))]
    public static T ResetSource<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.Source));
    #endregion
    #region LocalOnly
    /// <inheritdoc cref="ChocolateyListSettings.LocalOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.LocalOnly))]
    public static T SetLocalOnly<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.LocalOnly, v));
    /// <inheritdoc cref="ChocolateyListSettings.LocalOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.LocalOnly))]
    public static T ResetLocalOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.LocalOnly));
    /// <inheritdoc cref="ChocolateyListSettings.LocalOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.LocalOnly))]
    public static T EnableLocalOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.LocalOnly, true));
    /// <inheritdoc cref="ChocolateyListSettings.LocalOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.LocalOnly))]
    public static T DisableLocalOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.LocalOnly, false));
    /// <inheritdoc cref="ChocolateyListSettings.LocalOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.LocalOnly))]
    public static T ToggleLocalOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.LocalOnly, !o.LocalOnly));
    #endregion
    #region IdOnly
    /// <inheritdoc cref="ChocolateyListSettings.IdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.IdOnly))]
    public static T SetIdOnly<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.IdOnly, v));
    /// <inheritdoc cref="ChocolateyListSettings.IdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.IdOnly))]
    public static T ResetIdOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.IdOnly));
    /// <inheritdoc cref="ChocolateyListSettings.IdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.IdOnly))]
    public static T EnableIdOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.IdOnly, true));
    /// <inheritdoc cref="ChocolateyListSettings.IdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.IdOnly))]
    public static T DisableIdOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.IdOnly, false));
    /// <inheritdoc cref="ChocolateyListSettings.IdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.IdOnly))]
    public static T ToggleIdOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.IdOnly, !o.IdOnly));
    #endregion
    #region Prerelease
    /// <inheritdoc cref="ChocolateyListSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Prerelease))]
    public static T SetPrerelease<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Prerelease, v));
    /// <inheritdoc cref="ChocolateyListSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Prerelease))]
    public static T ResetPrerelease<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.Prerelease));
    /// <inheritdoc cref="ChocolateyListSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Prerelease))]
    public static T EnablePrerelease<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Prerelease, true));
    /// <inheritdoc cref="ChocolateyListSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Prerelease))]
    public static T DisablePrerelease<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Prerelease, false));
    /// <inheritdoc cref="ChocolateyListSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Prerelease))]
    public static T TogglePrerelease<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Prerelease, !o.Prerelease));
    #endregion
    #region IncludePrograms
    /// <inheritdoc cref="ChocolateyListSettings.IncludePrograms"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.IncludePrograms))]
    public static T SetIncludePrograms<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.IncludePrograms, v));
    /// <inheritdoc cref="ChocolateyListSettings.IncludePrograms"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.IncludePrograms))]
    public static T ResetIncludePrograms<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.IncludePrograms));
    /// <inheritdoc cref="ChocolateyListSettings.IncludePrograms"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.IncludePrograms))]
    public static T EnableIncludePrograms<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.IncludePrograms, true));
    /// <inheritdoc cref="ChocolateyListSettings.IncludePrograms"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.IncludePrograms))]
    public static T DisableIncludePrograms<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.IncludePrograms, false));
    /// <inheritdoc cref="ChocolateyListSettings.IncludePrograms"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.IncludePrograms))]
    public static T ToggleIncludePrograms<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.IncludePrograms, !o.IncludePrograms));
    #endregion
    #region AllVersions
    /// <inheritdoc cref="ChocolateyListSettings.AllVersions"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.AllVersions))]
    public static T SetAllVersions<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.AllVersions, v));
    /// <inheritdoc cref="ChocolateyListSettings.AllVersions"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.AllVersions))]
    public static T ResetAllVersions<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.AllVersions));
    /// <inheritdoc cref="ChocolateyListSettings.AllVersions"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.AllVersions))]
    public static T EnableAllVersions<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.AllVersions, true));
    /// <inheritdoc cref="ChocolateyListSettings.AllVersions"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.AllVersions))]
    public static T DisableAllVersions<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.AllVersions, false));
    /// <inheritdoc cref="ChocolateyListSettings.AllVersions"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.AllVersions))]
    public static T ToggleAllVersions<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.AllVersions, !o.AllVersions));
    #endregion
    #region Version
    /// <inheritdoc cref="ChocolateyListSettings.Version"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="ChocolateyListSettings.Version"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Page
    /// <inheritdoc cref="ChocolateyListSettings.Page"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Page))]
    public static T SetPage<T>(this T o, int? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Page, v));
    /// <inheritdoc cref="ChocolateyListSettings.Page"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Page))]
    public static T ResetPage<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.Page));
    #endregion
    #region PageSize
    /// <inheritdoc cref="ChocolateyListSettings.PageSize"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.PageSize))]
    public static T SetPageSize<T>(this T o, int? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.PageSize, v));
    /// <inheritdoc cref="ChocolateyListSettings.PageSize"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.PageSize))]
    public static T ResetPageSize<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.PageSize));
    #endregion
    #region Exact
    /// <inheritdoc cref="ChocolateyListSettings.Exact"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Exact))]
    public static T SetExact<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Exact, v));
    /// <inheritdoc cref="ChocolateyListSettings.Exact"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Exact))]
    public static T ResetExact<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.Exact));
    /// <inheritdoc cref="ChocolateyListSettings.Exact"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Exact))]
    public static T EnableExact<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Exact, true));
    /// <inheritdoc cref="ChocolateyListSettings.Exact"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Exact))]
    public static T DisableExact<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Exact, false));
    /// <inheritdoc cref="ChocolateyListSettings.Exact"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Exact))]
    public static T ToggleExact<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Exact, !o.Exact));
    #endregion
    #region ByIdOnly
    /// <inheritdoc cref="ChocolateyListSettings.ByIdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ByIdOnly))]
    public static T SetByIdOnly<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ByIdOnly, v));
    /// <inheritdoc cref="ChocolateyListSettings.ByIdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ByIdOnly))]
    public static T ResetByIdOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.ByIdOnly));
    /// <inheritdoc cref="ChocolateyListSettings.ByIdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ByIdOnly))]
    public static T EnableByIdOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ByIdOnly, true));
    /// <inheritdoc cref="ChocolateyListSettings.ByIdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ByIdOnly))]
    public static T DisableByIdOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ByIdOnly, false));
    /// <inheritdoc cref="ChocolateyListSettings.ByIdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ByIdOnly))]
    public static T ToggleByIdOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ByIdOnly, !o.ByIdOnly));
    #endregion
    #region ByTagOnly
    /// <inheritdoc cref="ChocolateyListSettings.ByTagOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ByTagOnly))]
    public static T SetByTagOnly<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ByTagOnly, v));
    /// <inheritdoc cref="ChocolateyListSettings.ByTagOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ByTagOnly))]
    public static T ResetByTagOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.ByTagOnly));
    /// <inheritdoc cref="ChocolateyListSettings.ByTagOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ByTagOnly))]
    public static T EnableByTagOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ByTagOnly, true));
    /// <inheritdoc cref="ChocolateyListSettings.ByTagOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ByTagOnly))]
    public static T DisableByTagOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ByTagOnly, false));
    /// <inheritdoc cref="ChocolateyListSettings.ByTagOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ByTagOnly))]
    public static T ToggleByTagOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ByTagOnly, !o.ByTagOnly));
    #endregion
    #region IdStartsWith
    /// <inheritdoc cref="ChocolateyListSettings.IdStartsWith"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.IdStartsWith))]
    public static T SetIdStartsWith<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.IdStartsWith, v));
    /// <inheritdoc cref="ChocolateyListSettings.IdStartsWith"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.IdStartsWith))]
    public static T ResetIdStartsWith<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.IdStartsWith));
    /// <inheritdoc cref="ChocolateyListSettings.IdStartsWith"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.IdStartsWith))]
    public static T EnableIdStartsWith<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.IdStartsWith, true));
    /// <inheritdoc cref="ChocolateyListSettings.IdStartsWith"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.IdStartsWith))]
    public static T DisableIdStartsWith<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.IdStartsWith, false));
    /// <inheritdoc cref="ChocolateyListSettings.IdStartsWith"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.IdStartsWith))]
    public static T ToggleIdStartsWith<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.IdStartsWith, !o.IdStartsWith));
    #endregion
    #region OrderByPopularity
    /// <inheritdoc cref="ChocolateyListSettings.OrderByPopularity"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.OrderByPopularity))]
    public static T SetOrderByPopularity<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.OrderByPopularity, v));
    /// <inheritdoc cref="ChocolateyListSettings.OrderByPopularity"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.OrderByPopularity))]
    public static T ResetOrderByPopularity<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.OrderByPopularity));
    /// <inheritdoc cref="ChocolateyListSettings.OrderByPopularity"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.OrderByPopularity))]
    public static T EnableOrderByPopularity<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.OrderByPopularity, true));
    /// <inheritdoc cref="ChocolateyListSettings.OrderByPopularity"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.OrderByPopularity))]
    public static T DisableOrderByPopularity<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.OrderByPopularity, false));
    /// <inheritdoc cref="ChocolateyListSettings.OrderByPopularity"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.OrderByPopularity))]
    public static T ToggleOrderByPopularity<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.OrderByPopularity, !o.OrderByPopularity));
    #endregion
    #region ApprovedOnly
    /// <inheritdoc cref="ChocolateyListSettings.ApprovedOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ApprovedOnly))]
    public static T SetApprovedOnly<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ApprovedOnly, v));
    /// <inheritdoc cref="ChocolateyListSettings.ApprovedOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ApprovedOnly))]
    public static T ResetApprovedOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.ApprovedOnly));
    /// <inheritdoc cref="ChocolateyListSettings.ApprovedOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ApprovedOnly))]
    public static T EnableApprovedOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ApprovedOnly, true));
    /// <inheritdoc cref="ChocolateyListSettings.ApprovedOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ApprovedOnly))]
    public static T DisableApprovedOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ApprovedOnly, false));
    /// <inheritdoc cref="ChocolateyListSettings.ApprovedOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ApprovedOnly))]
    public static T ToggleApprovedOnly<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ApprovedOnly, !o.ApprovedOnly));
    #endregion
    #region DownloadCacheAvailable
    /// <inheritdoc cref="ChocolateyListSettings.DownloadCacheAvailable"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.DownloadCacheAvailable))]
    public static T SetDownloadCacheAvailable<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.DownloadCacheAvailable, v));
    /// <inheritdoc cref="ChocolateyListSettings.DownloadCacheAvailable"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.DownloadCacheAvailable))]
    public static T ResetDownloadCacheAvailable<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.DownloadCacheAvailable));
    /// <inheritdoc cref="ChocolateyListSettings.DownloadCacheAvailable"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.DownloadCacheAvailable))]
    public static T EnableDownloadCacheAvailable<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.DownloadCacheAvailable, true));
    /// <inheritdoc cref="ChocolateyListSettings.DownloadCacheAvailable"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.DownloadCacheAvailable))]
    public static T DisableDownloadCacheAvailable<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.DownloadCacheAvailable, false));
    /// <inheritdoc cref="ChocolateyListSettings.DownloadCacheAvailable"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.DownloadCacheAvailable))]
    public static T ToggleDownloadCacheAvailable<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.DownloadCacheAvailable, !o.DownloadCacheAvailable));
    #endregion
    #region NotBroken
    /// <inheritdoc cref="ChocolateyListSettings.NotBroken"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.NotBroken))]
    public static T SetNotBroken<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.NotBroken, v));
    /// <inheritdoc cref="ChocolateyListSettings.NotBroken"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.NotBroken))]
    public static T ResetNotBroken<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.NotBroken));
    /// <inheritdoc cref="ChocolateyListSettings.NotBroken"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.NotBroken))]
    public static T EnableNotBroken<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.NotBroken, true));
    /// <inheritdoc cref="ChocolateyListSettings.NotBroken"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.NotBroken))]
    public static T DisableNotBroken<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.NotBroken, false));
    /// <inheritdoc cref="ChocolateyListSettings.NotBroken"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.NotBroken))]
    public static T ToggleNotBroken<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.NotBroken, !o.NotBroken));
    #endregion
    #region Detailed
    /// <inheritdoc cref="ChocolateyListSettings.Detailed"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Detailed))]
    public static T SetDetailed<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Detailed, v));
    /// <inheritdoc cref="ChocolateyListSettings.Detailed"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Detailed))]
    public static T ResetDetailed<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.Detailed));
    /// <inheritdoc cref="ChocolateyListSettings.Detailed"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Detailed))]
    public static T EnableDetailed<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Detailed, true));
    /// <inheritdoc cref="ChocolateyListSettings.Detailed"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Detailed))]
    public static T DisableDetailed<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Detailed, false));
    /// <inheritdoc cref="ChocolateyListSettings.Detailed"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Detailed))]
    public static T ToggleDetailed<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Detailed, !o.Detailed));
    #endregion
    #region DisablePackageRepositoryOptimizations
    /// <inheritdoc cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.DisablePackageRepositoryOptimizations))]
    public static T SetDisablePackageRepositoryOptimizations<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, v));
    /// <inheritdoc cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.DisablePackageRepositoryOptimizations))]
    public static T ResetDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.DisablePackageRepositoryOptimizations));
    /// <inheritdoc cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.DisablePackageRepositoryOptimizations))]
    public static T EnableDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, true));
    /// <inheritdoc cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.DisablePackageRepositoryOptimizations))]
    public static T DisableDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, false));
    /// <inheritdoc cref="ChocolateyListSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.DisablePackageRepositoryOptimizations))]
    public static T ToggleDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, !o.DisablePackageRepositoryOptimizations));
    #endregion
    #region ShowAuditInformation
    /// <inheritdoc cref="ChocolateyListSettings.ShowAuditInformation"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ShowAuditInformation))]
    public static T SetShowAuditInformation<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ShowAuditInformation, v));
    /// <inheritdoc cref="ChocolateyListSettings.ShowAuditInformation"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ShowAuditInformation))]
    public static T ResetShowAuditInformation<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.ShowAuditInformation));
    /// <inheritdoc cref="ChocolateyListSettings.ShowAuditInformation"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ShowAuditInformation))]
    public static T EnableShowAuditInformation<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ShowAuditInformation, true));
    /// <inheritdoc cref="ChocolateyListSettings.ShowAuditInformation"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ShowAuditInformation))]
    public static T DisableShowAuditInformation<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ShowAuditInformation, false));
    /// <inheritdoc cref="ChocolateyListSettings.ShowAuditInformation"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ShowAuditInformation))]
    public static T ToggleShowAuditInformation<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ShowAuditInformation, !o.ShowAuditInformation));
    #endregion
    #region User
    /// <inheritdoc cref="ChocolateyListSettings.User"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.User))]
    public static T SetUser<T>(this T o, string v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.User, v));
    /// <inheritdoc cref="ChocolateyListSettings.User"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.User))]
    public static T ResetUser<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.User));
    #endregion
    #region Password
    /// <inheritdoc cref="ChocolateyListSettings.Password"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="ChocolateyListSettings.Password"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region ClientCertificate
    /// <inheritdoc cref="ChocolateyListSettings.ClientCertificate"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ClientCertificate))]
    public static T SetClientCertificate<T>(this T o, string v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ClientCertificate, v));
    /// <inheritdoc cref="ChocolateyListSettings.ClientCertificate"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ClientCertificate))]
    public static T ResetClientCertificate<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.ClientCertificate));
    #endregion
    #region CertificatePassword
    /// <inheritdoc cref="ChocolateyListSettings.CertificatePassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.CertificatePassword))]
    public static T SetCertificatePassword<T>(this T o, [Secret] string v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.CertificatePassword, v));
    /// <inheritdoc cref="ChocolateyListSettings.CertificatePassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.CertificatePassword))]
    public static T ResetCertificatePassword<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.CertificatePassword));
    #endregion
    #region Debug
    /// <inheritdoc cref="ChocolateyListSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="ChocolateyListSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="ChocolateyListSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="ChocolateyListSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="ChocolateyListSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region Verbose
    /// <inheritdoc cref="ChocolateyListSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="ChocolateyListSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="ChocolateyListSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="ChocolateyListSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="ChocolateyListSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region Trace
    /// <inheritdoc cref="ChocolateyListSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Trace))]
    public static T SetTrace<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Trace, v));
    /// <inheritdoc cref="ChocolateyListSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Trace))]
    public static T ResetTrace<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.Trace));
    /// <inheritdoc cref="ChocolateyListSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Trace))]
    public static T EnableTrace<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Trace, true));
    /// <inheritdoc cref="ChocolateyListSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Trace))]
    public static T DisableTrace<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Trace, false));
    /// <inheritdoc cref="ChocolateyListSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Trace))]
    public static T ToggleTrace<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Trace, !o.Trace));
    #endregion
    #region NoColor
    /// <inheritdoc cref="ChocolateyListSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.NoColor))]
    public static T SetNoColor<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.NoColor, v));
    /// <inheritdoc cref="ChocolateyListSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.NoColor))]
    public static T ResetNoColor<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.NoColor));
    /// <inheritdoc cref="ChocolateyListSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.NoColor))]
    public static T EnableNoColor<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.NoColor, true));
    /// <inheritdoc cref="ChocolateyListSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.NoColor))]
    public static T DisableNoColor<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.NoColor, false));
    /// <inheritdoc cref="ChocolateyListSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.NoColor))]
    public static T ToggleNoColor<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.NoColor, !o.NoColor));
    #endregion
    #region AcceptLicense
    /// <inheritdoc cref="ChocolateyListSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.AcceptLicense))]
    public static T SetAcceptLicense<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.AcceptLicense, v));
    /// <inheritdoc cref="ChocolateyListSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.AcceptLicense))]
    public static T ResetAcceptLicense<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.AcceptLicense));
    /// <inheritdoc cref="ChocolateyListSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.AcceptLicense))]
    public static T EnableAcceptLicense<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.AcceptLicense, true));
    /// <inheritdoc cref="ChocolateyListSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.AcceptLicense))]
    public static T DisableAcceptLicense<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.AcceptLicense, false));
    /// <inheritdoc cref="ChocolateyListSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.AcceptLicense))]
    public static T ToggleAcceptLicense<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.AcceptLicense, !o.AcceptLicense));
    #endregion
    #region Confirm
    /// <inheritdoc cref="ChocolateyListSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Confirm))]
    public static T SetConfirm<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Confirm, v));
    /// <inheritdoc cref="ChocolateyListSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Confirm))]
    public static T ResetConfirm<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.Confirm));
    /// <inheritdoc cref="ChocolateyListSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Confirm))]
    public static T EnableConfirm<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Confirm, true));
    /// <inheritdoc cref="ChocolateyListSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Confirm))]
    public static T DisableConfirm<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Confirm, false));
    /// <inheritdoc cref="ChocolateyListSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Confirm))]
    public static T ToggleConfirm<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Confirm, !o.Confirm));
    #endregion
    #region Force
    /// <inheritdoc cref="ChocolateyListSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="ChocolateyListSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Force))]
    public static T ResetForce<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="ChocolateyListSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Force))]
    public static T EnableForce<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="ChocolateyListSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Force))]
    public static T DisableForce<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="ChocolateyListSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region LimitOutput
    /// <inheritdoc cref="ChocolateyListSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.LimitOutput))]
    public static T SetLimitOutput<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.LimitOutput, v));
    /// <inheritdoc cref="ChocolateyListSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.LimitOutput))]
    public static T ResetLimitOutput<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.LimitOutput));
    /// <inheritdoc cref="ChocolateyListSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.LimitOutput))]
    public static T EnableLimitOutput<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.LimitOutput, true));
    /// <inheritdoc cref="ChocolateyListSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.LimitOutput))]
    public static T DisableLimitOutput<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.LimitOutput, false));
    /// <inheritdoc cref="ChocolateyListSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.LimitOutput))]
    public static T ToggleLimitOutput<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.LimitOutput, !o.LimitOutput));
    #endregion
    #region CommandExecutionTimeout
    /// <inheritdoc cref="ChocolateyListSettings.CommandExecutionTimeout"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.CommandExecutionTimeout))]
    public static T SetCommandExecutionTimeout<T>(this T o, int? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.CommandExecutionTimeout, v));
    /// <inheritdoc cref="ChocolateyListSettings.CommandExecutionTimeout"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.CommandExecutionTimeout))]
    public static T ResetCommandExecutionTimeout<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.CommandExecutionTimeout));
    #endregion
    #region CacheLocation
    /// <inheritdoc cref="ChocolateyListSettings.CacheLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.CacheLocation))]
    public static T SetCacheLocation<T>(this T o, string v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.CacheLocation, v));
    /// <inheritdoc cref="ChocolateyListSettings.CacheLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.CacheLocation))]
    public static T ResetCacheLocation<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.CacheLocation));
    #endregion
    #region AllowUnofficialBuild
    /// <inheritdoc cref="ChocolateyListSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.AllowUnofficialBuild))]
    public static T SetAllowUnofficialBuild<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, v));
    /// <inheritdoc cref="ChocolateyListSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.AllowUnofficialBuild))]
    public static T ResetAllowUnofficialBuild<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.AllowUnofficialBuild));
    /// <inheritdoc cref="ChocolateyListSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.AllowUnofficialBuild))]
    public static T EnableAllowUnofficialBuild<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, true));
    /// <inheritdoc cref="ChocolateyListSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.AllowUnofficialBuild))]
    public static T DisableAllowUnofficialBuild<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, false));
    /// <inheritdoc cref="ChocolateyListSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.AllowUnofficialBuild))]
    public static T ToggleAllowUnofficialBuild<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, !o.AllowUnofficialBuild));
    #endregion
    #region FailOnStandardError
    /// <inheritdoc cref="ChocolateyListSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.FailOnStandardError))]
    public static T SetFailOnStandardError<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, v));
    /// <inheritdoc cref="ChocolateyListSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.FailOnStandardError))]
    public static T ResetFailOnStandardError<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.FailOnStandardError));
    /// <inheritdoc cref="ChocolateyListSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.FailOnStandardError))]
    public static T EnableFailOnStandardError<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, true));
    /// <inheritdoc cref="ChocolateyListSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.FailOnStandardError))]
    public static T DisableFailOnStandardError<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, false));
    /// <inheritdoc cref="ChocolateyListSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.FailOnStandardError))]
    public static T ToggleFailOnStandardError<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, !o.FailOnStandardError));
    #endregion
    #region UseSystemPowerShell
    /// <inheritdoc cref="ChocolateyListSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.UseSystemPowerShell))]
    public static T SetUseSystemPowerShell<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, v));
    /// <inheritdoc cref="ChocolateyListSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.UseSystemPowerShell))]
    public static T ResetUseSystemPowerShell<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.UseSystemPowerShell));
    /// <inheritdoc cref="ChocolateyListSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.UseSystemPowerShell))]
    public static T EnableUseSystemPowerShell<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, true));
    /// <inheritdoc cref="ChocolateyListSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.UseSystemPowerShell))]
    public static T DisableUseSystemPowerShell<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, false));
    /// <inheritdoc cref="ChocolateyListSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.UseSystemPowerShell))]
    public static T ToggleUseSystemPowerShell<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, !o.UseSystemPowerShell));
    #endregion
    #region DoNotShowProgress
    /// <inheritdoc cref="ChocolateyListSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.DoNotShowProgress))]
    public static T SetDoNotShowProgress<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, v));
    /// <inheritdoc cref="ChocolateyListSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.DoNotShowProgress))]
    public static T ResetDoNotShowProgress<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.DoNotShowProgress));
    /// <inheritdoc cref="ChocolateyListSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.DoNotShowProgress))]
    public static T EnableDoNotShowProgress<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, true));
    /// <inheritdoc cref="ChocolateyListSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.DoNotShowProgress))]
    public static T DisableDoNotShowProgress<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, false));
    /// <inheritdoc cref="ChocolateyListSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.DoNotShowProgress))]
    public static T ToggleDoNotShowProgress<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, !o.DoNotShowProgress));
    #endregion
    #region Proxy
    /// <inheritdoc cref="ChocolateyListSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Proxy))]
    public static T SetProxy<T>(this T o, string v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.Proxy, v));
    /// <inheritdoc cref="ChocolateyListSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.Proxy))]
    public static T ResetProxy<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.Proxy));
    #endregion
    #region ProxyUserName
    /// <inheritdoc cref="ChocolateyListSettings.ProxyUserName"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyUserName))]
    public static T SetProxyUserName<T>(this T o, string v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ProxyUserName, v));
    /// <inheritdoc cref="ChocolateyListSettings.ProxyUserName"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyUserName))]
    public static T ResetProxyUserName<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.ProxyUserName));
    #endregion
    #region ProxyPassword
    /// <inheritdoc cref="ChocolateyListSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyPassword))]
    public static T SetProxyPassword<T>(this T o, [Secret] string v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ProxyPassword, v));
    /// <inheritdoc cref="ChocolateyListSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyPassword))]
    public static T ResetProxyPassword<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.ProxyPassword));
    #endregion
    #region ProxyBypassList
    /// <inheritdoc cref="ChocolateyListSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyBypassList))]
    public static T SetProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyListSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyBypassList))]
    public static T SetProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyListSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyBypassList))]
    public static T AddProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyListSettings => o.Modify(b => b.AddCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyListSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyBypassList))]
    public static T AddProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyListSettings => o.Modify(b => b.AddCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyListSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyBypassList))]
    public static T RemoveProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyListSettings => o.Modify(b => b.RemoveCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyListSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyBypassList))]
    public static T RemoveProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyListSettings => o.Modify(b => b.RemoveCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyListSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyBypassList))]
    public static T ClearProxyBypassList<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.ClearCollection(() => o.ProxyBypassList));
    #endregion
    #region ProxyBypassOnLocal
    /// <inheritdoc cref="ChocolateyListSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyBypassOnLocal))]
    public static T SetProxyBypassOnLocal<T>(this T o, bool? v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, v));
    /// <inheritdoc cref="ChocolateyListSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyBypassOnLocal))]
    public static T ResetProxyBypassOnLocal<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.ProxyBypassOnLocal));
    /// <inheritdoc cref="ChocolateyListSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyBypassOnLocal))]
    public static T EnableProxyBypassOnLocal<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, true));
    /// <inheritdoc cref="ChocolateyListSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyBypassOnLocal))]
    public static T DisableProxyBypassOnLocal<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, false));
    /// <inheritdoc cref="ChocolateyListSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.ProxyBypassOnLocal))]
    public static T ToggleProxyBypassOnLocal<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, !o.ProxyBypassOnLocal));
    #endregion
    #region LogFile
    /// <inheritdoc cref="ChocolateyListSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : ChocolateyListSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="ChocolateyListSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ChocolateyListSettings), Property = nameof(ChocolateyListSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : ChocolateyListSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
}
#endregion
#region ChocolateyFindSettingsExtensions
/// <summary>Used within <see cref="ChocolateyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class ChocolateyFindSettingsExtensions
{
    #region Filter
    /// <inheritdoc cref="ChocolateyFindSettings.Filter"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Filter))]
    public static T SetFilter<T>(this T o, string v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Filter, v));
    /// <inheritdoc cref="ChocolateyFindSettings.Filter"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Filter))]
    public static T ResetFilter<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.Filter));
    #endregion
    #region Source
    /// <inheritdoc cref="ChocolateyFindSettings.Source"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Source))]
    public static T SetSource<T>(this T o, string v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="ChocolateyFindSettings.Source"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Source))]
    public static T ResetSource<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.Source));
    #endregion
    #region LocalOnly
    /// <inheritdoc cref="ChocolateyFindSettings.LocalOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.LocalOnly))]
    public static T SetLocalOnly<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.LocalOnly, v));
    /// <inheritdoc cref="ChocolateyFindSettings.LocalOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.LocalOnly))]
    public static T ResetLocalOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.LocalOnly));
    /// <inheritdoc cref="ChocolateyFindSettings.LocalOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.LocalOnly))]
    public static T EnableLocalOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.LocalOnly, true));
    /// <inheritdoc cref="ChocolateyFindSettings.LocalOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.LocalOnly))]
    public static T DisableLocalOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.LocalOnly, false));
    /// <inheritdoc cref="ChocolateyFindSettings.LocalOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.LocalOnly))]
    public static T ToggleLocalOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.LocalOnly, !o.LocalOnly));
    #endregion
    #region IdOnly
    /// <inheritdoc cref="ChocolateyFindSettings.IdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.IdOnly))]
    public static T SetIdOnly<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.IdOnly, v));
    /// <inheritdoc cref="ChocolateyFindSettings.IdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.IdOnly))]
    public static T ResetIdOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.IdOnly));
    /// <inheritdoc cref="ChocolateyFindSettings.IdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.IdOnly))]
    public static T EnableIdOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.IdOnly, true));
    /// <inheritdoc cref="ChocolateyFindSettings.IdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.IdOnly))]
    public static T DisableIdOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.IdOnly, false));
    /// <inheritdoc cref="ChocolateyFindSettings.IdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.IdOnly))]
    public static T ToggleIdOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.IdOnly, !o.IdOnly));
    #endregion
    #region Prerelease
    /// <inheritdoc cref="ChocolateyFindSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Prerelease))]
    public static T SetPrerelease<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Prerelease, v));
    /// <inheritdoc cref="ChocolateyFindSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Prerelease))]
    public static T ResetPrerelease<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.Prerelease));
    /// <inheritdoc cref="ChocolateyFindSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Prerelease))]
    public static T EnablePrerelease<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Prerelease, true));
    /// <inheritdoc cref="ChocolateyFindSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Prerelease))]
    public static T DisablePrerelease<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Prerelease, false));
    /// <inheritdoc cref="ChocolateyFindSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Prerelease))]
    public static T TogglePrerelease<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Prerelease, !o.Prerelease));
    #endregion
    #region IncludePrograms
    /// <inheritdoc cref="ChocolateyFindSettings.IncludePrograms"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.IncludePrograms))]
    public static T SetIncludePrograms<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.IncludePrograms, v));
    /// <inheritdoc cref="ChocolateyFindSettings.IncludePrograms"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.IncludePrograms))]
    public static T ResetIncludePrograms<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.IncludePrograms));
    /// <inheritdoc cref="ChocolateyFindSettings.IncludePrograms"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.IncludePrograms))]
    public static T EnableIncludePrograms<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.IncludePrograms, true));
    /// <inheritdoc cref="ChocolateyFindSettings.IncludePrograms"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.IncludePrograms))]
    public static T DisableIncludePrograms<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.IncludePrograms, false));
    /// <inheritdoc cref="ChocolateyFindSettings.IncludePrograms"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.IncludePrograms))]
    public static T ToggleIncludePrograms<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.IncludePrograms, !o.IncludePrograms));
    #endregion
    #region AllVersions
    /// <inheritdoc cref="ChocolateyFindSettings.AllVersions"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.AllVersions))]
    public static T SetAllVersions<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.AllVersions, v));
    /// <inheritdoc cref="ChocolateyFindSettings.AllVersions"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.AllVersions))]
    public static T ResetAllVersions<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.AllVersions));
    /// <inheritdoc cref="ChocolateyFindSettings.AllVersions"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.AllVersions))]
    public static T EnableAllVersions<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.AllVersions, true));
    /// <inheritdoc cref="ChocolateyFindSettings.AllVersions"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.AllVersions))]
    public static T DisableAllVersions<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.AllVersions, false));
    /// <inheritdoc cref="ChocolateyFindSettings.AllVersions"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.AllVersions))]
    public static T ToggleAllVersions<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.AllVersions, !o.AllVersions));
    #endregion
    #region Version
    /// <inheritdoc cref="ChocolateyFindSettings.Version"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="ChocolateyFindSettings.Version"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Page
    /// <inheritdoc cref="ChocolateyFindSettings.Page"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Page))]
    public static T SetPage<T>(this T o, int? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Page, v));
    /// <inheritdoc cref="ChocolateyFindSettings.Page"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Page))]
    public static T ResetPage<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.Page));
    #endregion
    #region PageSize
    /// <inheritdoc cref="ChocolateyFindSettings.PageSize"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.PageSize))]
    public static T SetPageSize<T>(this T o, int? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.PageSize, v));
    /// <inheritdoc cref="ChocolateyFindSettings.PageSize"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.PageSize))]
    public static T ResetPageSize<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.PageSize));
    #endregion
    #region Exact
    /// <inheritdoc cref="ChocolateyFindSettings.Exact"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Exact))]
    public static T SetExact<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Exact, v));
    /// <inheritdoc cref="ChocolateyFindSettings.Exact"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Exact))]
    public static T ResetExact<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.Exact));
    /// <inheritdoc cref="ChocolateyFindSettings.Exact"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Exact))]
    public static T EnableExact<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Exact, true));
    /// <inheritdoc cref="ChocolateyFindSettings.Exact"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Exact))]
    public static T DisableExact<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Exact, false));
    /// <inheritdoc cref="ChocolateyFindSettings.Exact"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Exact))]
    public static T ToggleExact<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Exact, !o.Exact));
    #endregion
    #region ByIdOnly
    /// <inheritdoc cref="ChocolateyFindSettings.ByIdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ByIdOnly))]
    public static T SetByIdOnly<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ByIdOnly, v));
    /// <inheritdoc cref="ChocolateyFindSettings.ByIdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ByIdOnly))]
    public static T ResetByIdOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.ByIdOnly));
    /// <inheritdoc cref="ChocolateyFindSettings.ByIdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ByIdOnly))]
    public static T EnableByIdOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ByIdOnly, true));
    /// <inheritdoc cref="ChocolateyFindSettings.ByIdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ByIdOnly))]
    public static T DisableByIdOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ByIdOnly, false));
    /// <inheritdoc cref="ChocolateyFindSettings.ByIdOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ByIdOnly))]
    public static T ToggleByIdOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ByIdOnly, !o.ByIdOnly));
    #endregion
    #region ByTagOnly
    /// <inheritdoc cref="ChocolateyFindSettings.ByTagOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ByTagOnly))]
    public static T SetByTagOnly<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ByTagOnly, v));
    /// <inheritdoc cref="ChocolateyFindSettings.ByTagOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ByTagOnly))]
    public static T ResetByTagOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.ByTagOnly));
    /// <inheritdoc cref="ChocolateyFindSettings.ByTagOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ByTagOnly))]
    public static T EnableByTagOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ByTagOnly, true));
    /// <inheritdoc cref="ChocolateyFindSettings.ByTagOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ByTagOnly))]
    public static T DisableByTagOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ByTagOnly, false));
    /// <inheritdoc cref="ChocolateyFindSettings.ByTagOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ByTagOnly))]
    public static T ToggleByTagOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ByTagOnly, !o.ByTagOnly));
    #endregion
    #region IdStartsWith
    /// <inheritdoc cref="ChocolateyFindSettings.IdStartsWith"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.IdStartsWith))]
    public static T SetIdStartsWith<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.IdStartsWith, v));
    /// <inheritdoc cref="ChocolateyFindSettings.IdStartsWith"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.IdStartsWith))]
    public static T ResetIdStartsWith<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.IdStartsWith));
    /// <inheritdoc cref="ChocolateyFindSettings.IdStartsWith"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.IdStartsWith))]
    public static T EnableIdStartsWith<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.IdStartsWith, true));
    /// <inheritdoc cref="ChocolateyFindSettings.IdStartsWith"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.IdStartsWith))]
    public static T DisableIdStartsWith<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.IdStartsWith, false));
    /// <inheritdoc cref="ChocolateyFindSettings.IdStartsWith"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.IdStartsWith))]
    public static T ToggleIdStartsWith<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.IdStartsWith, !o.IdStartsWith));
    #endregion
    #region OrderByPopularity
    /// <inheritdoc cref="ChocolateyFindSettings.OrderByPopularity"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.OrderByPopularity))]
    public static T SetOrderByPopularity<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.OrderByPopularity, v));
    /// <inheritdoc cref="ChocolateyFindSettings.OrderByPopularity"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.OrderByPopularity))]
    public static T ResetOrderByPopularity<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.OrderByPopularity));
    /// <inheritdoc cref="ChocolateyFindSettings.OrderByPopularity"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.OrderByPopularity))]
    public static T EnableOrderByPopularity<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.OrderByPopularity, true));
    /// <inheritdoc cref="ChocolateyFindSettings.OrderByPopularity"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.OrderByPopularity))]
    public static T DisableOrderByPopularity<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.OrderByPopularity, false));
    /// <inheritdoc cref="ChocolateyFindSettings.OrderByPopularity"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.OrderByPopularity))]
    public static T ToggleOrderByPopularity<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.OrderByPopularity, !o.OrderByPopularity));
    #endregion
    #region ApprovedOnly
    /// <inheritdoc cref="ChocolateyFindSettings.ApprovedOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ApprovedOnly))]
    public static T SetApprovedOnly<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ApprovedOnly, v));
    /// <inheritdoc cref="ChocolateyFindSettings.ApprovedOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ApprovedOnly))]
    public static T ResetApprovedOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.ApprovedOnly));
    /// <inheritdoc cref="ChocolateyFindSettings.ApprovedOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ApprovedOnly))]
    public static T EnableApprovedOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ApprovedOnly, true));
    /// <inheritdoc cref="ChocolateyFindSettings.ApprovedOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ApprovedOnly))]
    public static T DisableApprovedOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ApprovedOnly, false));
    /// <inheritdoc cref="ChocolateyFindSettings.ApprovedOnly"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ApprovedOnly))]
    public static T ToggleApprovedOnly<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ApprovedOnly, !o.ApprovedOnly));
    #endregion
    #region DownloadCacheAvailable
    /// <inheritdoc cref="ChocolateyFindSettings.DownloadCacheAvailable"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.DownloadCacheAvailable))]
    public static T SetDownloadCacheAvailable<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.DownloadCacheAvailable, v));
    /// <inheritdoc cref="ChocolateyFindSettings.DownloadCacheAvailable"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.DownloadCacheAvailable))]
    public static T ResetDownloadCacheAvailable<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.DownloadCacheAvailable));
    /// <inheritdoc cref="ChocolateyFindSettings.DownloadCacheAvailable"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.DownloadCacheAvailable))]
    public static T EnableDownloadCacheAvailable<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.DownloadCacheAvailable, true));
    /// <inheritdoc cref="ChocolateyFindSettings.DownloadCacheAvailable"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.DownloadCacheAvailable))]
    public static T DisableDownloadCacheAvailable<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.DownloadCacheAvailable, false));
    /// <inheritdoc cref="ChocolateyFindSettings.DownloadCacheAvailable"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.DownloadCacheAvailable))]
    public static T ToggleDownloadCacheAvailable<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.DownloadCacheAvailable, !o.DownloadCacheAvailable));
    #endregion
    #region NotBroken
    /// <inheritdoc cref="ChocolateyFindSettings.NotBroken"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.NotBroken))]
    public static T SetNotBroken<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.NotBroken, v));
    /// <inheritdoc cref="ChocolateyFindSettings.NotBroken"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.NotBroken))]
    public static T ResetNotBroken<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.NotBroken));
    /// <inheritdoc cref="ChocolateyFindSettings.NotBroken"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.NotBroken))]
    public static T EnableNotBroken<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.NotBroken, true));
    /// <inheritdoc cref="ChocolateyFindSettings.NotBroken"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.NotBroken))]
    public static T DisableNotBroken<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.NotBroken, false));
    /// <inheritdoc cref="ChocolateyFindSettings.NotBroken"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.NotBroken))]
    public static T ToggleNotBroken<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.NotBroken, !o.NotBroken));
    #endregion
    #region Detailed
    /// <inheritdoc cref="ChocolateyFindSettings.Detailed"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Detailed))]
    public static T SetDetailed<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Detailed, v));
    /// <inheritdoc cref="ChocolateyFindSettings.Detailed"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Detailed))]
    public static T ResetDetailed<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.Detailed));
    /// <inheritdoc cref="ChocolateyFindSettings.Detailed"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Detailed))]
    public static T EnableDetailed<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Detailed, true));
    /// <inheritdoc cref="ChocolateyFindSettings.Detailed"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Detailed))]
    public static T DisableDetailed<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Detailed, false));
    /// <inheritdoc cref="ChocolateyFindSettings.Detailed"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Detailed))]
    public static T ToggleDetailed<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Detailed, !o.Detailed));
    #endregion
    #region DisablePackageRepositoryOptimizations
    /// <inheritdoc cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.DisablePackageRepositoryOptimizations))]
    public static T SetDisablePackageRepositoryOptimizations<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, v));
    /// <inheritdoc cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.DisablePackageRepositoryOptimizations))]
    public static T ResetDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.DisablePackageRepositoryOptimizations));
    /// <inheritdoc cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.DisablePackageRepositoryOptimizations))]
    public static T EnableDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, true));
    /// <inheritdoc cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.DisablePackageRepositoryOptimizations))]
    public static T DisableDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, false));
    /// <inheritdoc cref="ChocolateyFindSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.DisablePackageRepositoryOptimizations))]
    public static T ToggleDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, !o.DisablePackageRepositoryOptimizations));
    #endregion
    #region ShowAuditInformation
    /// <inheritdoc cref="ChocolateyFindSettings.ShowAuditInformation"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ShowAuditInformation))]
    public static T SetShowAuditInformation<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ShowAuditInformation, v));
    /// <inheritdoc cref="ChocolateyFindSettings.ShowAuditInformation"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ShowAuditInformation))]
    public static T ResetShowAuditInformation<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.ShowAuditInformation));
    /// <inheritdoc cref="ChocolateyFindSettings.ShowAuditInformation"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ShowAuditInformation))]
    public static T EnableShowAuditInformation<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ShowAuditInformation, true));
    /// <inheritdoc cref="ChocolateyFindSettings.ShowAuditInformation"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ShowAuditInformation))]
    public static T DisableShowAuditInformation<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ShowAuditInformation, false));
    /// <inheritdoc cref="ChocolateyFindSettings.ShowAuditInformation"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ShowAuditInformation))]
    public static T ToggleShowAuditInformation<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ShowAuditInformation, !o.ShowAuditInformation));
    #endregion
    #region User
    /// <inheritdoc cref="ChocolateyFindSettings.User"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.User))]
    public static T SetUser<T>(this T o, string v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.User, v));
    /// <inheritdoc cref="ChocolateyFindSettings.User"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.User))]
    public static T ResetUser<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.User));
    #endregion
    #region Password
    /// <inheritdoc cref="ChocolateyFindSettings.Password"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="ChocolateyFindSettings.Password"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region ClientCertificate
    /// <inheritdoc cref="ChocolateyFindSettings.ClientCertificate"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ClientCertificate))]
    public static T SetClientCertificate<T>(this T o, string v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ClientCertificate, v));
    /// <inheritdoc cref="ChocolateyFindSettings.ClientCertificate"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ClientCertificate))]
    public static T ResetClientCertificate<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.ClientCertificate));
    #endregion
    #region CertificatePassword
    /// <inheritdoc cref="ChocolateyFindSettings.CertificatePassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.CertificatePassword))]
    public static T SetCertificatePassword<T>(this T o, [Secret] string v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.CertificatePassword, v));
    /// <inheritdoc cref="ChocolateyFindSettings.CertificatePassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.CertificatePassword))]
    public static T ResetCertificatePassword<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.CertificatePassword));
    #endregion
    #region Debug
    /// <inheritdoc cref="ChocolateyFindSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="ChocolateyFindSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="ChocolateyFindSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="ChocolateyFindSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="ChocolateyFindSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region Verbose
    /// <inheritdoc cref="ChocolateyFindSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="ChocolateyFindSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="ChocolateyFindSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="ChocolateyFindSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="ChocolateyFindSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region Trace
    /// <inheritdoc cref="ChocolateyFindSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Trace))]
    public static T SetTrace<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Trace, v));
    /// <inheritdoc cref="ChocolateyFindSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Trace))]
    public static T ResetTrace<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.Trace));
    /// <inheritdoc cref="ChocolateyFindSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Trace))]
    public static T EnableTrace<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Trace, true));
    /// <inheritdoc cref="ChocolateyFindSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Trace))]
    public static T DisableTrace<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Trace, false));
    /// <inheritdoc cref="ChocolateyFindSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Trace))]
    public static T ToggleTrace<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Trace, !o.Trace));
    #endregion
    #region NoColor
    /// <inheritdoc cref="ChocolateyFindSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.NoColor))]
    public static T SetNoColor<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.NoColor, v));
    /// <inheritdoc cref="ChocolateyFindSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.NoColor))]
    public static T ResetNoColor<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.NoColor));
    /// <inheritdoc cref="ChocolateyFindSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.NoColor))]
    public static T EnableNoColor<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.NoColor, true));
    /// <inheritdoc cref="ChocolateyFindSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.NoColor))]
    public static T DisableNoColor<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.NoColor, false));
    /// <inheritdoc cref="ChocolateyFindSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.NoColor))]
    public static T ToggleNoColor<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.NoColor, !o.NoColor));
    #endregion
    #region AcceptLicense
    /// <inheritdoc cref="ChocolateyFindSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.AcceptLicense))]
    public static T SetAcceptLicense<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.AcceptLicense, v));
    /// <inheritdoc cref="ChocolateyFindSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.AcceptLicense))]
    public static T ResetAcceptLicense<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.AcceptLicense));
    /// <inheritdoc cref="ChocolateyFindSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.AcceptLicense))]
    public static T EnableAcceptLicense<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.AcceptLicense, true));
    /// <inheritdoc cref="ChocolateyFindSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.AcceptLicense))]
    public static T DisableAcceptLicense<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.AcceptLicense, false));
    /// <inheritdoc cref="ChocolateyFindSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.AcceptLicense))]
    public static T ToggleAcceptLicense<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.AcceptLicense, !o.AcceptLicense));
    #endregion
    #region Confirm
    /// <inheritdoc cref="ChocolateyFindSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Confirm))]
    public static T SetConfirm<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Confirm, v));
    /// <inheritdoc cref="ChocolateyFindSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Confirm))]
    public static T ResetConfirm<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.Confirm));
    /// <inheritdoc cref="ChocolateyFindSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Confirm))]
    public static T EnableConfirm<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Confirm, true));
    /// <inheritdoc cref="ChocolateyFindSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Confirm))]
    public static T DisableConfirm<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Confirm, false));
    /// <inheritdoc cref="ChocolateyFindSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Confirm))]
    public static T ToggleConfirm<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Confirm, !o.Confirm));
    #endregion
    #region Force
    /// <inheritdoc cref="ChocolateyFindSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="ChocolateyFindSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Force))]
    public static T ResetForce<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="ChocolateyFindSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Force))]
    public static T EnableForce<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="ChocolateyFindSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Force))]
    public static T DisableForce<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="ChocolateyFindSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region LimitOutput
    /// <inheritdoc cref="ChocolateyFindSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.LimitOutput))]
    public static T SetLimitOutput<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.LimitOutput, v));
    /// <inheritdoc cref="ChocolateyFindSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.LimitOutput))]
    public static T ResetLimitOutput<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.LimitOutput));
    /// <inheritdoc cref="ChocolateyFindSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.LimitOutput))]
    public static T EnableLimitOutput<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.LimitOutput, true));
    /// <inheritdoc cref="ChocolateyFindSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.LimitOutput))]
    public static T DisableLimitOutput<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.LimitOutput, false));
    /// <inheritdoc cref="ChocolateyFindSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.LimitOutput))]
    public static T ToggleLimitOutput<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.LimitOutput, !o.LimitOutput));
    #endregion
    #region CommandExecutionTimeout
    /// <inheritdoc cref="ChocolateyFindSettings.CommandExecutionTimeout"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.CommandExecutionTimeout))]
    public static T SetCommandExecutionTimeout<T>(this T o, int? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.CommandExecutionTimeout, v));
    /// <inheritdoc cref="ChocolateyFindSettings.CommandExecutionTimeout"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.CommandExecutionTimeout))]
    public static T ResetCommandExecutionTimeout<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.CommandExecutionTimeout));
    #endregion
    #region CacheLocation
    /// <inheritdoc cref="ChocolateyFindSettings.CacheLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.CacheLocation))]
    public static T SetCacheLocation<T>(this T o, string v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.CacheLocation, v));
    /// <inheritdoc cref="ChocolateyFindSettings.CacheLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.CacheLocation))]
    public static T ResetCacheLocation<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.CacheLocation));
    #endregion
    #region AllowUnofficialBuild
    /// <inheritdoc cref="ChocolateyFindSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.AllowUnofficialBuild))]
    public static T SetAllowUnofficialBuild<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, v));
    /// <inheritdoc cref="ChocolateyFindSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.AllowUnofficialBuild))]
    public static T ResetAllowUnofficialBuild<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.AllowUnofficialBuild));
    /// <inheritdoc cref="ChocolateyFindSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.AllowUnofficialBuild))]
    public static T EnableAllowUnofficialBuild<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, true));
    /// <inheritdoc cref="ChocolateyFindSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.AllowUnofficialBuild))]
    public static T DisableAllowUnofficialBuild<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, false));
    /// <inheritdoc cref="ChocolateyFindSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.AllowUnofficialBuild))]
    public static T ToggleAllowUnofficialBuild<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, !o.AllowUnofficialBuild));
    #endregion
    #region FailOnStandardError
    /// <inheritdoc cref="ChocolateyFindSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.FailOnStandardError))]
    public static T SetFailOnStandardError<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, v));
    /// <inheritdoc cref="ChocolateyFindSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.FailOnStandardError))]
    public static T ResetFailOnStandardError<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.FailOnStandardError));
    /// <inheritdoc cref="ChocolateyFindSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.FailOnStandardError))]
    public static T EnableFailOnStandardError<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, true));
    /// <inheritdoc cref="ChocolateyFindSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.FailOnStandardError))]
    public static T DisableFailOnStandardError<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, false));
    /// <inheritdoc cref="ChocolateyFindSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.FailOnStandardError))]
    public static T ToggleFailOnStandardError<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, !o.FailOnStandardError));
    #endregion
    #region UseSystemPowerShell
    /// <inheritdoc cref="ChocolateyFindSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.UseSystemPowerShell))]
    public static T SetUseSystemPowerShell<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, v));
    /// <inheritdoc cref="ChocolateyFindSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.UseSystemPowerShell))]
    public static T ResetUseSystemPowerShell<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.UseSystemPowerShell));
    /// <inheritdoc cref="ChocolateyFindSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.UseSystemPowerShell))]
    public static T EnableUseSystemPowerShell<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, true));
    /// <inheritdoc cref="ChocolateyFindSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.UseSystemPowerShell))]
    public static T DisableUseSystemPowerShell<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, false));
    /// <inheritdoc cref="ChocolateyFindSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.UseSystemPowerShell))]
    public static T ToggleUseSystemPowerShell<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, !o.UseSystemPowerShell));
    #endregion
    #region DoNotShowProgress
    /// <inheritdoc cref="ChocolateyFindSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.DoNotShowProgress))]
    public static T SetDoNotShowProgress<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, v));
    /// <inheritdoc cref="ChocolateyFindSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.DoNotShowProgress))]
    public static T ResetDoNotShowProgress<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.DoNotShowProgress));
    /// <inheritdoc cref="ChocolateyFindSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.DoNotShowProgress))]
    public static T EnableDoNotShowProgress<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, true));
    /// <inheritdoc cref="ChocolateyFindSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.DoNotShowProgress))]
    public static T DisableDoNotShowProgress<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, false));
    /// <inheritdoc cref="ChocolateyFindSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.DoNotShowProgress))]
    public static T ToggleDoNotShowProgress<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, !o.DoNotShowProgress));
    #endregion
    #region Proxy
    /// <inheritdoc cref="ChocolateyFindSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Proxy))]
    public static T SetProxy<T>(this T o, string v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.Proxy, v));
    /// <inheritdoc cref="ChocolateyFindSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.Proxy))]
    public static T ResetProxy<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.Proxy));
    #endregion
    #region ProxyUserName
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyUserName"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyUserName))]
    public static T SetProxyUserName<T>(this T o, string v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ProxyUserName, v));
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyUserName"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyUserName))]
    public static T ResetProxyUserName<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.ProxyUserName));
    #endregion
    #region ProxyPassword
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyPassword))]
    public static T SetProxyPassword<T>(this T o, [Secret] string v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ProxyPassword, v));
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyPassword))]
    public static T ResetProxyPassword<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.ProxyPassword));
    #endregion
    #region ProxyBypassList
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyBypassList))]
    public static T SetProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyBypassList))]
    public static T SetProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyBypassList))]
    public static T AddProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyFindSettings => o.Modify(b => b.AddCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyBypassList))]
    public static T AddProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyFindSettings => o.Modify(b => b.AddCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyBypassList))]
    public static T RemoveProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyFindSettings => o.Modify(b => b.RemoveCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyBypassList))]
    public static T RemoveProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyFindSettings => o.Modify(b => b.RemoveCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyBypassList))]
    public static T ClearProxyBypassList<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.ClearCollection(() => o.ProxyBypassList));
    #endregion
    #region ProxyBypassOnLocal
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyBypassOnLocal))]
    public static T SetProxyBypassOnLocal<T>(this T o, bool? v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, v));
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyBypassOnLocal))]
    public static T ResetProxyBypassOnLocal<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.ProxyBypassOnLocal));
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyBypassOnLocal))]
    public static T EnableProxyBypassOnLocal<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, true));
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyBypassOnLocal))]
    public static T DisableProxyBypassOnLocal<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, false));
    /// <inheritdoc cref="ChocolateyFindSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.ProxyBypassOnLocal))]
    public static T ToggleProxyBypassOnLocal<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, !o.ProxyBypassOnLocal));
    #endregion
    #region LogFile
    /// <inheritdoc cref="ChocolateyFindSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : ChocolateyFindSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="ChocolateyFindSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ChocolateyFindSettings), Property = nameof(ChocolateyFindSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : ChocolateyFindSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
}
#endregion
#region ChocolateyOutdatedSettingsExtensions
/// <summary>Used within <see cref="ChocolateyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class ChocolateyOutdatedSettingsExtensions
{
    #region Source
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Source"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Source))]
    public static T SetSource<T>(this T o, string v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Source"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Source))]
    public static T ResetSource<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.Source));
    #endregion
    #region Prerelease
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Prerelease))]
    public static T SetPrerelease<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Prerelease, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Prerelease))]
    public static T ResetPrerelease<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.Prerelease));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Prerelease))]
    public static T EnablePrerelease<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Prerelease, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Prerelease))]
    public static T DisablePrerelease<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Prerelease, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Prerelease))]
    public static T TogglePrerelease<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Prerelease, !o.Prerelease));
    #endregion
    #region IgnorePinned
    /// <inheritdoc cref="ChocolateyOutdatedSettings.IgnorePinned"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.IgnorePinned))]
    public static T SetIgnorePinned<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.IgnorePinned, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.IgnorePinned"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.IgnorePinned))]
    public static T ResetIgnorePinned<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.IgnorePinned));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.IgnorePinned"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.IgnorePinned))]
    public static T EnableIgnorePinned<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.IgnorePinned, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.IgnorePinned"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.IgnorePinned))]
    public static T DisableIgnorePinned<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.IgnorePinned, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.IgnorePinned"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.IgnorePinned))]
    public static T ToggleIgnorePinned<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.IgnorePinned, !o.IgnorePinned));
    #endregion
    #region IgnoreUnfound
    /// <inheritdoc cref="ChocolateyOutdatedSettings.IgnoreUnfound"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.IgnoreUnfound))]
    public static T SetIgnoreUnfound<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.IgnoreUnfound, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.IgnoreUnfound"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.IgnoreUnfound))]
    public static T ResetIgnoreUnfound<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.IgnoreUnfound));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.IgnoreUnfound"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.IgnoreUnfound))]
    public static T EnableIgnoreUnfound<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.IgnoreUnfound, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.IgnoreUnfound"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.IgnoreUnfound))]
    public static T DisableIgnoreUnfound<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.IgnoreUnfound, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.IgnoreUnfound"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.IgnoreUnfound))]
    public static T ToggleIgnoreUnfound<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.IgnoreUnfound, !o.IgnoreUnfound));
    #endregion
    #region DisablePackageRepositoryOptimizations
    /// <inheritdoc cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations))]
    public static T SetDisablePackageRepositoryOptimizations<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations))]
    public static T ResetDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.DisablePackageRepositoryOptimizations));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations))]
    public static T EnableDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations))]
    public static T DisableDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.DisablePackageRepositoryOptimizations))]
    public static T ToggleDisablePackageRepositoryOptimizations<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.DisablePackageRepositoryOptimizations, !o.DisablePackageRepositoryOptimizations));
    #endregion
    #region User
    /// <inheritdoc cref="ChocolateyOutdatedSettings.User"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.User))]
    public static T SetUser<T>(this T o, string v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.User, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.User"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.User))]
    public static T ResetUser<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.User));
    #endregion
    #region Password
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Password"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Password"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region ClientCertificate
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ClientCertificate"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ClientCertificate))]
    public static T SetClientCertificate<T>(this T o, string v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.ClientCertificate, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ClientCertificate"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ClientCertificate))]
    public static T ResetClientCertificate<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.ClientCertificate));
    #endregion
    #region CertificatePassword
    /// <inheritdoc cref="ChocolateyOutdatedSettings.CertificatePassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.CertificatePassword))]
    public static T SetCertificatePassword<T>(this T o, [Secret] string v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.CertificatePassword, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.CertificatePassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.CertificatePassword))]
    public static T ResetCertificatePassword<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.CertificatePassword));
    #endregion
    #region Debug
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region Verbose
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region Trace
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Trace))]
    public static T SetTrace<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Trace, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Trace))]
    public static T ResetTrace<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.Trace));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Trace))]
    public static T EnableTrace<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Trace, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Trace))]
    public static T DisableTrace<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Trace, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Trace))]
    public static T ToggleTrace<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Trace, !o.Trace));
    #endregion
    #region NoColor
    /// <inheritdoc cref="ChocolateyOutdatedSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.NoColor))]
    public static T SetNoColor<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.NoColor, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.NoColor))]
    public static T ResetNoColor<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.NoColor));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.NoColor))]
    public static T EnableNoColor<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.NoColor, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.NoColor))]
    public static T DisableNoColor<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.NoColor, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.NoColor))]
    public static T ToggleNoColor<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.NoColor, !o.NoColor));
    #endregion
    #region AcceptLicense
    /// <inheritdoc cref="ChocolateyOutdatedSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.AcceptLicense))]
    public static T SetAcceptLicense<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.AcceptLicense, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.AcceptLicense))]
    public static T ResetAcceptLicense<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.AcceptLicense));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.AcceptLicense))]
    public static T EnableAcceptLicense<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.AcceptLicense, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.AcceptLicense))]
    public static T DisableAcceptLicense<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.AcceptLicense, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.AcceptLicense))]
    public static T ToggleAcceptLicense<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.AcceptLicense, !o.AcceptLicense));
    #endregion
    #region Confirm
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Confirm))]
    public static T SetConfirm<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Confirm, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Confirm))]
    public static T ResetConfirm<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.Confirm));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Confirm))]
    public static T EnableConfirm<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Confirm, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Confirm))]
    public static T DisableConfirm<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Confirm, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Confirm))]
    public static T ToggleConfirm<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Confirm, !o.Confirm));
    #endregion
    #region Force
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Force))]
    public static T ResetForce<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Force))]
    public static T EnableForce<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Force))]
    public static T DisableForce<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region LimitOutput
    /// <inheritdoc cref="ChocolateyOutdatedSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.LimitOutput))]
    public static T SetLimitOutput<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.LimitOutput, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.LimitOutput))]
    public static T ResetLimitOutput<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.LimitOutput));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.LimitOutput))]
    public static T EnableLimitOutput<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.LimitOutput, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.LimitOutput))]
    public static T DisableLimitOutput<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.LimitOutput, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.LimitOutput))]
    public static T ToggleLimitOutput<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.LimitOutput, !o.LimitOutput));
    #endregion
    #region CommandExecutionTimeout
    /// <inheritdoc cref="ChocolateyOutdatedSettings.CommandExecutionTimeout"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.CommandExecutionTimeout))]
    public static T SetCommandExecutionTimeout<T>(this T o, int? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.CommandExecutionTimeout, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.CommandExecutionTimeout"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.CommandExecutionTimeout))]
    public static T ResetCommandExecutionTimeout<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.CommandExecutionTimeout));
    #endregion
    #region CacheLocation
    /// <inheritdoc cref="ChocolateyOutdatedSettings.CacheLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.CacheLocation))]
    public static T SetCacheLocation<T>(this T o, string v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.CacheLocation, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.CacheLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.CacheLocation))]
    public static T ResetCacheLocation<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.CacheLocation));
    #endregion
    #region AllowUnofficialBuild
    /// <inheritdoc cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.AllowUnofficialBuild))]
    public static T SetAllowUnofficialBuild<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.AllowUnofficialBuild))]
    public static T ResetAllowUnofficialBuild<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.AllowUnofficialBuild));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.AllowUnofficialBuild))]
    public static T EnableAllowUnofficialBuild<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.AllowUnofficialBuild))]
    public static T DisableAllowUnofficialBuild<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.AllowUnofficialBuild))]
    public static T ToggleAllowUnofficialBuild<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, !o.AllowUnofficialBuild));
    #endregion
    #region FailOnStandardError
    /// <inheritdoc cref="ChocolateyOutdatedSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.FailOnStandardError))]
    public static T SetFailOnStandardError<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.FailOnStandardError))]
    public static T ResetFailOnStandardError<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.FailOnStandardError));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.FailOnStandardError))]
    public static T EnableFailOnStandardError<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.FailOnStandardError))]
    public static T DisableFailOnStandardError<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.FailOnStandardError))]
    public static T ToggleFailOnStandardError<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, !o.FailOnStandardError));
    #endregion
    #region UseSystemPowerShell
    /// <inheritdoc cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.UseSystemPowerShell))]
    public static T SetUseSystemPowerShell<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.UseSystemPowerShell))]
    public static T ResetUseSystemPowerShell<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.UseSystemPowerShell));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.UseSystemPowerShell))]
    public static T EnableUseSystemPowerShell<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.UseSystemPowerShell))]
    public static T DisableUseSystemPowerShell<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.UseSystemPowerShell))]
    public static T ToggleUseSystemPowerShell<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, !o.UseSystemPowerShell));
    #endregion
    #region DoNotShowProgress
    /// <inheritdoc cref="ChocolateyOutdatedSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.DoNotShowProgress))]
    public static T SetDoNotShowProgress<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.DoNotShowProgress))]
    public static T ResetDoNotShowProgress<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.DoNotShowProgress));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.DoNotShowProgress))]
    public static T EnableDoNotShowProgress<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.DoNotShowProgress))]
    public static T DisableDoNotShowProgress<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.DoNotShowProgress))]
    public static T ToggleDoNotShowProgress<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, !o.DoNotShowProgress));
    #endregion
    #region Proxy
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Proxy))]
    public static T SetProxy<T>(this T o, string v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.Proxy, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.Proxy))]
    public static T ResetProxy<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.Proxy));
    #endregion
    #region ProxyUserName
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyUserName"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyUserName))]
    public static T SetProxyUserName<T>(this T o, string v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.ProxyUserName, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyUserName"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyUserName))]
    public static T ResetProxyUserName<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.ProxyUserName));
    #endregion
    #region ProxyPassword
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyPassword))]
    public static T SetProxyPassword<T>(this T o, [Secret] string v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.ProxyPassword, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyPassword))]
    public static T ResetProxyPassword<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.ProxyPassword));
    #endregion
    #region ProxyBypassList
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyBypassList))]
    public static T SetProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyBypassList))]
    public static T SetProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyBypassList))]
    public static T AddProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.AddCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyBypassList))]
    public static T AddProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.AddCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyBypassList))]
    public static T RemoveProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.RemoveCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyBypassList))]
    public static T RemoveProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.RemoveCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyBypassList))]
    public static T ClearProxyBypassList<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.ClearCollection(() => o.ProxyBypassList));
    #endregion
    #region ProxyBypassOnLocal
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyBypassOnLocal))]
    public static T SetProxyBypassOnLocal<T>(this T o, bool? v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyBypassOnLocal))]
    public static T ResetProxyBypassOnLocal<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.ProxyBypassOnLocal));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyBypassOnLocal))]
    public static T EnableProxyBypassOnLocal<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, true));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyBypassOnLocal))]
    public static T DisableProxyBypassOnLocal<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, false));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.ProxyBypassOnLocal))]
    public static T ToggleProxyBypassOnLocal<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, !o.ProxyBypassOnLocal));
    #endregion
    #region LogFile
    /// <inheritdoc cref="ChocolateyOutdatedSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="ChocolateyOutdatedSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ChocolateyOutdatedSettings), Property = nameof(ChocolateyOutdatedSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : ChocolateyOutdatedSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
}
#endregion
#region ChocolateyPackSettingsExtensions
/// <summary>Used within <see cref="ChocolateyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class ChocolateyPackSettingsExtensions
{
    #region PathToNuspec
    /// <inheritdoc cref="ChocolateyPackSettings.PathToNuspec"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.PathToNuspec))]
    public static T SetPathToNuspec<T>(this T o, string v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.PathToNuspec, v));
    /// <inheritdoc cref="ChocolateyPackSettings.PathToNuspec"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.PathToNuspec))]
    public static T ResetPathToNuspec<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.PathToNuspec));
    #endregion
    #region Version
    /// <inheritdoc cref="ChocolateyPackSettings.Version"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="ChocolateyPackSettings.Version"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region OutputDirectory
    /// <inheritdoc cref="ChocolateyPackSettings.OutputDirectory"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.OutputDirectory))]
    public static T SetOutputDirectory<T>(this T o, string v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.OutputDirectory, v));
    /// <inheritdoc cref="ChocolateyPackSettings.OutputDirectory"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.OutputDirectory))]
    public static T ResetOutputDirectory<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.OutputDirectory));
    #endregion
    #region Properties
    /// <inheritdoc cref="ChocolateyPackSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Properties))]
    public static T SetProperties<T>(this T o, IDictionary<string, object> v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Properties, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="ChocolateyPackSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Properties))]
    public static T SetProperty<T>(this T o, string k, object v) where T : ChocolateyPackSettings => o.Modify(b => b.SetDictionary(() => o.Properties, k, v));
    /// <inheritdoc cref="ChocolateyPackSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Properties))]
    public static T AddProperty<T>(this T o, string k, object v) where T : ChocolateyPackSettings => o.Modify(b => b.AddDictionary(() => o.Properties, k, v));
    /// <inheritdoc cref="ChocolateyPackSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Properties))]
    public static T RemoveProperty<T>(this T o, string k) where T : ChocolateyPackSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, k));
    /// <inheritdoc cref="ChocolateyPackSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Properties))]
    public static T ClearProperties<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.ClearDictionary(() => o.Properties));
    #endregion
    #region Debug
    /// <inheritdoc cref="ChocolateyPackSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="ChocolateyPackSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="ChocolateyPackSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="ChocolateyPackSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="ChocolateyPackSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region Verbose
    /// <inheritdoc cref="ChocolateyPackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="ChocolateyPackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="ChocolateyPackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="ChocolateyPackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="ChocolateyPackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region Trace
    /// <inheritdoc cref="ChocolateyPackSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Trace))]
    public static T SetTrace<T>(this T o, bool? v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Trace, v));
    /// <inheritdoc cref="ChocolateyPackSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Trace))]
    public static T ResetTrace<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.Trace));
    /// <inheritdoc cref="ChocolateyPackSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Trace))]
    public static T EnableTrace<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Trace, true));
    /// <inheritdoc cref="ChocolateyPackSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Trace))]
    public static T DisableTrace<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Trace, false));
    /// <inheritdoc cref="ChocolateyPackSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Trace))]
    public static T ToggleTrace<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Trace, !o.Trace));
    #endregion
    #region NoColor
    /// <inheritdoc cref="ChocolateyPackSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.NoColor))]
    public static T SetNoColor<T>(this T o, bool? v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.NoColor, v));
    /// <inheritdoc cref="ChocolateyPackSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.NoColor))]
    public static T ResetNoColor<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.NoColor));
    /// <inheritdoc cref="ChocolateyPackSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.NoColor))]
    public static T EnableNoColor<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.NoColor, true));
    /// <inheritdoc cref="ChocolateyPackSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.NoColor))]
    public static T DisableNoColor<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.NoColor, false));
    /// <inheritdoc cref="ChocolateyPackSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.NoColor))]
    public static T ToggleNoColor<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.NoColor, !o.NoColor));
    #endregion
    #region AcceptLicense
    /// <inheritdoc cref="ChocolateyPackSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.AcceptLicense))]
    public static T SetAcceptLicense<T>(this T o, bool? v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.AcceptLicense, v));
    /// <inheritdoc cref="ChocolateyPackSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.AcceptLicense))]
    public static T ResetAcceptLicense<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.AcceptLicense));
    /// <inheritdoc cref="ChocolateyPackSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.AcceptLicense))]
    public static T EnableAcceptLicense<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.AcceptLicense, true));
    /// <inheritdoc cref="ChocolateyPackSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.AcceptLicense))]
    public static T DisableAcceptLicense<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.AcceptLicense, false));
    /// <inheritdoc cref="ChocolateyPackSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.AcceptLicense))]
    public static T ToggleAcceptLicense<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.AcceptLicense, !o.AcceptLicense));
    #endregion
    #region Confirm
    /// <inheritdoc cref="ChocolateyPackSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Confirm))]
    public static T SetConfirm<T>(this T o, bool? v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Confirm, v));
    /// <inheritdoc cref="ChocolateyPackSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Confirm))]
    public static T ResetConfirm<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.Confirm));
    /// <inheritdoc cref="ChocolateyPackSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Confirm))]
    public static T EnableConfirm<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Confirm, true));
    /// <inheritdoc cref="ChocolateyPackSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Confirm))]
    public static T DisableConfirm<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Confirm, false));
    /// <inheritdoc cref="ChocolateyPackSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Confirm))]
    public static T ToggleConfirm<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Confirm, !o.Confirm));
    #endregion
    #region Force
    /// <inheritdoc cref="ChocolateyPackSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="ChocolateyPackSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Force))]
    public static T ResetForce<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="ChocolateyPackSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Force))]
    public static T EnableForce<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="ChocolateyPackSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Force))]
    public static T DisableForce<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="ChocolateyPackSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region LimitOutput
    /// <inheritdoc cref="ChocolateyPackSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.LimitOutput))]
    public static T SetLimitOutput<T>(this T o, bool? v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.LimitOutput, v));
    /// <inheritdoc cref="ChocolateyPackSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.LimitOutput))]
    public static T ResetLimitOutput<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.LimitOutput));
    /// <inheritdoc cref="ChocolateyPackSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.LimitOutput))]
    public static T EnableLimitOutput<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.LimitOutput, true));
    /// <inheritdoc cref="ChocolateyPackSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.LimitOutput))]
    public static T DisableLimitOutput<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.LimitOutput, false));
    /// <inheritdoc cref="ChocolateyPackSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.LimitOutput))]
    public static T ToggleLimitOutput<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.LimitOutput, !o.LimitOutput));
    #endregion
    #region CommandExecutionTimeout
    /// <inheritdoc cref="ChocolateyPackSettings.CommandExecutionTimeout"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.CommandExecutionTimeout))]
    public static T SetCommandExecutionTimeout<T>(this T o, int? v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.CommandExecutionTimeout, v));
    /// <inheritdoc cref="ChocolateyPackSettings.CommandExecutionTimeout"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.CommandExecutionTimeout))]
    public static T ResetCommandExecutionTimeout<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.CommandExecutionTimeout));
    #endregion
    #region CacheLocation
    /// <inheritdoc cref="ChocolateyPackSettings.CacheLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.CacheLocation))]
    public static T SetCacheLocation<T>(this T o, string v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.CacheLocation, v));
    /// <inheritdoc cref="ChocolateyPackSettings.CacheLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.CacheLocation))]
    public static T ResetCacheLocation<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.CacheLocation));
    #endregion
    #region AllowUnofficialBuild
    /// <inheritdoc cref="ChocolateyPackSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.AllowUnofficialBuild))]
    public static T SetAllowUnofficialBuild<T>(this T o, bool? v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, v));
    /// <inheritdoc cref="ChocolateyPackSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.AllowUnofficialBuild))]
    public static T ResetAllowUnofficialBuild<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.AllowUnofficialBuild));
    /// <inheritdoc cref="ChocolateyPackSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.AllowUnofficialBuild))]
    public static T EnableAllowUnofficialBuild<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, true));
    /// <inheritdoc cref="ChocolateyPackSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.AllowUnofficialBuild))]
    public static T DisableAllowUnofficialBuild<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, false));
    /// <inheritdoc cref="ChocolateyPackSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.AllowUnofficialBuild))]
    public static T ToggleAllowUnofficialBuild<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, !o.AllowUnofficialBuild));
    #endregion
    #region FailOnStandardError
    /// <inheritdoc cref="ChocolateyPackSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.FailOnStandardError))]
    public static T SetFailOnStandardError<T>(this T o, bool? v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, v));
    /// <inheritdoc cref="ChocolateyPackSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.FailOnStandardError))]
    public static T ResetFailOnStandardError<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.FailOnStandardError));
    /// <inheritdoc cref="ChocolateyPackSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.FailOnStandardError))]
    public static T EnableFailOnStandardError<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, true));
    /// <inheritdoc cref="ChocolateyPackSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.FailOnStandardError))]
    public static T DisableFailOnStandardError<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, false));
    /// <inheritdoc cref="ChocolateyPackSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.FailOnStandardError))]
    public static T ToggleFailOnStandardError<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, !o.FailOnStandardError));
    #endregion
    #region UseSystemPowerShell
    /// <inheritdoc cref="ChocolateyPackSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.UseSystemPowerShell))]
    public static T SetUseSystemPowerShell<T>(this T o, bool? v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, v));
    /// <inheritdoc cref="ChocolateyPackSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.UseSystemPowerShell))]
    public static T ResetUseSystemPowerShell<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.UseSystemPowerShell));
    /// <inheritdoc cref="ChocolateyPackSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.UseSystemPowerShell))]
    public static T EnableUseSystemPowerShell<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, true));
    /// <inheritdoc cref="ChocolateyPackSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.UseSystemPowerShell))]
    public static T DisableUseSystemPowerShell<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, false));
    /// <inheritdoc cref="ChocolateyPackSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.UseSystemPowerShell))]
    public static T ToggleUseSystemPowerShell<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, !o.UseSystemPowerShell));
    #endregion
    #region DoNotShowProgress
    /// <inheritdoc cref="ChocolateyPackSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.DoNotShowProgress))]
    public static T SetDoNotShowProgress<T>(this T o, bool? v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, v));
    /// <inheritdoc cref="ChocolateyPackSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.DoNotShowProgress))]
    public static T ResetDoNotShowProgress<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.DoNotShowProgress));
    /// <inheritdoc cref="ChocolateyPackSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.DoNotShowProgress))]
    public static T EnableDoNotShowProgress<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, true));
    /// <inheritdoc cref="ChocolateyPackSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.DoNotShowProgress))]
    public static T DisableDoNotShowProgress<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, false));
    /// <inheritdoc cref="ChocolateyPackSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.DoNotShowProgress))]
    public static T ToggleDoNotShowProgress<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, !o.DoNotShowProgress));
    #endregion
    #region Proxy
    /// <inheritdoc cref="ChocolateyPackSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Proxy))]
    public static T SetProxy<T>(this T o, string v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.Proxy, v));
    /// <inheritdoc cref="ChocolateyPackSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.Proxy))]
    public static T ResetProxy<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.Proxy));
    #endregion
    #region ProxyUserName
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyUserName"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyUserName))]
    public static T SetProxyUserName<T>(this T o, string v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.ProxyUserName, v));
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyUserName"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyUserName))]
    public static T ResetProxyUserName<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.ProxyUserName));
    #endregion
    #region ProxyPassword
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyPassword))]
    public static T SetProxyPassword<T>(this T o, [Secret] string v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.ProxyPassword, v));
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyPassword))]
    public static T ResetProxyPassword<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.ProxyPassword));
    #endregion
    #region ProxyBypassList
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyBypassList))]
    public static T SetProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyBypassList))]
    public static T SetProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyBypassList))]
    public static T AddProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyPackSettings => o.Modify(b => b.AddCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyBypassList))]
    public static T AddProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyPackSettings => o.Modify(b => b.AddCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyBypassList))]
    public static T RemoveProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyPackSettings => o.Modify(b => b.RemoveCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyBypassList))]
    public static T RemoveProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyPackSettings => o.Modify(b => b.RemoveCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyBypassList))]
    public static T ClearProxyBypassList<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.ClearCollection(() => o.ProxyBypassList));
    #endregion
    #region ProxyBypassOnLocal
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyBypassOnLocal))]
    public static T SetProxyBypassOnLocal<T>(this T o, bool? v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, v));
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyBypassOnLocal))]
    public static T ResetProxyBypassOnLocal<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.ProxyBypassOnLocal));
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyBypassOnLocal))]
    public static T EnableProxyBypassOnLocal<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, true));
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyBypassOnLocal))]
    public static T DisableProxyBypassOnLocal<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, false));
    /// <inheritdoc cref="ChocolateyPackSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.ProxyBypassOnLocal))]
    public static T ToggleProxyBypassOnLocal<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, !o.ProxyBypassOnLocal));
    #endregion
    #region LogFile
    /// <inheritdoc cref="ChocolateyPackSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : ChocolateyPackSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="ChocolateyPackSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ChocolateyPackSettings), Property = nameof(ChocolateyPackSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : ChocolateyPackSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
}
#endregion
#region ChocolateyPushSettingsExtensions
/// <summary>Used within <see cref="ChocolateyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class ChocolateyPushSettingsExtensions
{
    #region PathToNuGetPackage
    /// <inheritdoc cref="ChocolateyPushSettings.PathToNuGetPackage"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.PathToNuGetPackage))]
    public static T SetPathToNuGetPackage<T>(this T o, string v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.PathToNuGetPackage, v));
    /// <inheritdoc cref="ChocolateyPushSettings.PathToNuGetPackage"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.PathToNuGetPackage))]
    public static T ResetPathToNuGetPackage<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.PathToNuGetPackage));
    #endregion
    #region Source
    /// <inheritdoc cref="ChocolateyPushSettings.Source"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Source))]
    public static T SetSource<T>(this T o, string v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="ChocolateyPushSettings.Source"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Source))]
    public static T ResetSource<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.Source));
    #endregion
    #region ApiKey
    /// <inheritdoc cref="ChocolateyPushSettings.ApiKey"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ApiKey))]
    public static T SetApiKey<T>(this T o, [Secret] string v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.ApiKey, v));
    /// <inheritdoc cref="ChocolateyPushSettings.ApiKey"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ApiKey))]
    public static T ResetApiKey<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.ApiKey));
    #endregion
    #region Timeout
    /// <inheritdoc cref="ChocolateyPushSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Timeout))]
    public static T SetTimeout<T>(this T o, int? v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Timeout, v));
    /// <inheritdoc cref="ChocolateyPushSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Timeout))]
    public static T ResetTimeout<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.Timeout));
    #endregion
    #region Debug
    /// <inheritdoc cref="ChocolateyPushSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="ChocolateyPushSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="ChocolateyPushSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="ChocolateyPushSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="ChocolateyPushSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region Verbose
    /// <inheritdoc cref="ChocolateyPushSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="ChocolateyPushSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="ChocolateyPushSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="ChocolateyPushSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="ChocolateyPushSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region Trace
    /// <inheritdoc cref="ChocolateyPushSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Trace))]
    public static T SetTrace<T>(this T o, bool? v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Trace, v));
    /// <inheritdoc cref="ChocolateyPushSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Trace))]
    public static T ResetTrace<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.Trace));
    /// <inheritdoc cref="ChocolateyPushSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Trace))]
    public static T EnableTrace<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Trace, true));
    /// <inheritdoc cref="ChocolateyPushSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Trace))]
    public static T DisableTrace<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Trace, false));
    /// <inheritdoc cref="ChocolateyPushSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Trace))]
    public static T ToggleTrace<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Trace, !o.Trace));
    #endregion
    #region NoColor
    /// <inheritdoc cref="ChocolateyPushSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.NoColor))]
    public static T SetNoColor<T>(this T o, bool? v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.NoColor, v));
    /// <inheritdoc cref="ChocolateyPushSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.NoColor))]
    public static T ResetNoColor<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.NoColor));
    /// <inheritdoc cref="ChocolateyPushSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.NoColor))]
    public static T EnableNoColor<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.NoColor, true));
    /// <inheritdoc cref="ChocolateyPushSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.NoColor))]
    public static T DisableNoColor<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.NoColor, false));
    /// <inheritdoc cref="ChocolateyPushSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.NoColor))]
    public static T ToggleNoColor<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.NoColor, !o.NoColor));
    #endregion
    #region AcceptLicense
    /// <inheritdoc cref="ChocolateyPushSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.AcceptLicense))]
    public static T SetAcceptLicense<T>(this T o, bool? v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.AcceptLicense, v));
    /// <inheritdoc cref="ChocolateyPushSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.AcceptLicense))]
    public static T ResetAcceptLicense<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.AcceptLicense));
    /// <inheritdoc cref="ChocolateyPushSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.AcceptLicense))]
    public static T EnableAcceptLicense<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.AcceptLicense, true));
    /// <inheritdoc cref="ChocolateyPushSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.AcceptLicense))]
    public static T DisableAcceptLicense<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.AcceptLicense, false));
    /// <inheritdoc cref="ChocolateyPushSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.AcceptLicense))]
    public static T ToggleAcceptLicense<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.AcceptLicense, !o.AcceptLicense));
    #endregion
    #region Confirm
    /// <inheritdoc cref="ChocolateyPushSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Confirm))]
    public static T SetConfirm<T>(this T o, bool? v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Confirm, v));
    /// <inheritdoc cref="ChocolateyPushSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Confirm))]
    public static T ResetConfirm<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.Confirm));
    /// <inheritdoc cref="ChocolateyPushSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Confirm))]
    public static T EnableConfirm<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Confirm, true));
    /// <inheritdoc cref="ChocolateyPushSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Confirm))]
    public static T DisableConfirm<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Confirm, false));
    /// <inheritdoc cref="ChocolateyPushSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Confirm))]
    public static T ToggleConfirm<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Confirm, !o.Confirm));
    #endregion
    #region Force
    /// <inheritdoc cref="ChocolateyPushSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="ChocolateyPushSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Force))]
    public static T ResetForce<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="ChocolateyPushSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Force))]
    public static T EnableForce<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="ChocolateyPushSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Force))]
    public static T DisableForce<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="ChocolateyPushSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region LimitOutput
    /// <inheritdoc cref="ChocolateyPushSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.LimitOutput))]
    public static T SetLimitOutput<T>(this T o, bool? v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.LimitOutput, v));
    /// <inheritdoc cref="ChocolateyPushSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.LimitOutput))]
    public static T ResetLimitOutput<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.LimitOutput));
    /// <inheritdoc cref="ChocolateyPushSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.LimitOutput))]
    public static T EnableLimitOutput<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.LimitOutput, true));
    /// <inheritdoc cref="ChocolateyPushSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.LimitOutput))]
    public static T DisableLimitOutput<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.LimitOutput, false));
    /// <inheritdoc cref="ChocolateyPushSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.LimitOutput))]
    public static T ToggleLimitOutput<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.LimitOutput, !o.LimitOutput));
    #endregion
    #region CommandExecutionTimeout
    /// <inheritdoc cref="ChocolateyPushSettings.CommandExecutionTimeout"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.CommandExecutionTimeout))]
    public static T SetCommandExecutionTimeout<T>(this T o, int? v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.CommandExecutionTimeout, v));
    /// <inheritdoc cref="ChocolateyPushSettings.CommandExecutionTimeout"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.CommandExecutionTimeout))]
    public static T ResetCommandExecutionTimeout<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.CommandExecutionTimeout));
    #endregion
    #region CacheLocation
    /// <inheritdoc cref="ChocolateyPushSettings.CacheLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.CacheLocation))]
    public static T SetCacheLocation<T>(this T o, string v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.CacheLocation, v));
    /// <inheritdoc cref="ChocolateyPushSettings.CacheLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.CacheLocation))]
    public static T ResetCacheLocation<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.CacheLocation));
    #endregion
    #region AllowUnofficialBuild
    /// <inheritdoc cref="ChocolateyPushSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.AllowUnofficialBuild))]
    public static T SetAllowUnofficialBuild<T>(this T o, bool? v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, v));
    /// <inheritdoc cref="ChocolateyPushSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.AllowUnofficialBuild))]
    public static T ResetAllowUnofficialBuild<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.AllowUnofficialBuild));
    /// <inheritdoc cref="ChocolateyPushSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.AllowUnofficialBuild))]
    public static T EnableAllowUnofficialBuild<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, true));
    /// <inheritdoc cref="ChocolateyPushSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.AllowUnofficialBuild))]
    public static T DisableAllowUnofficialBuild<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, false));
    /// <inheritdoc cref="ChocolateyPushSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.AllowUnofficialBuild))]
    public static T ToggleAllowUnofficialBuild<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, !o.AllowUnofficialBuild));
    #endregion
    #region FailOnStandardError
    /// <inheritdoc cref="ChocolateyPushSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.FailOnStandardError))]
    public static T SetFailOnStandardError<T>(this T o, bool? v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, v));
    /// <inheritdoc cref="ChocolateyPushSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.FailOnStandardError))]
    public static T ResetFailOnStandardError<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.FailOnStandardError));
    /// <inheritdoc cref="ChocolateyPushSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.FailOnStandardError))]
    public static T EnableFailOnStandardError<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, true));
    /// <inheritdoc cref="ChocolateyPushSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.FailOnStandardError))]
    public static T DisableFailOnStandardError<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, false));
    /// <inheritdoc cref="ChocolateyPushSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.FailOnStandardError))]
    public static T ToggleFailOnStandardError<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, !o.FailOnStandardError));
    #endregion
    #region UseSystemPowerShell
    /// <inheritdoc cref="ChocolateyPushSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.UseSystemPowerShell))]
    public static T SetUseSystemPowerShell<T>(this T o, bool? v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, v));
    /// <inheritdoc cref="ChocolateyPushSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.UseSystemPowerShell))]
    public static T ResetUseSystemPowerShell<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.UseSystemPowerShell));
    /// <inheritdoc cref="ChocolateyPushSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.UseSystemPowerShell))]
    public static T EnableUseSystemPowerShell<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, true));
    /// <inheritdoc cref="ChocolateyPushSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.UseSystemPowerShell))]
    public static T DisableUseSystemPowerShell<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, false));
    /// <inheritdoc cref="ChocolateyPushSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.UseSystemPowerShell))]
    public static T ToggleUseSystemPowerShell<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, !o.UseSystemPowerShell));
    #endregion
    #region DoNotShowProgress
    /// <inheritdoc cref="ChocolateyPushSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.DoNotShowProgress))]
    public static T SetDoNotShowProgress<T>(this T o, bool? v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, v));
    /// <inheritdoc cref="ChocolateyPushSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.DoNotShowProgress))]
    public static T ResetDoNotShowProgress<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.DoNotShowProgress));
    /// <inheritdoc cref="ChocolateyPushSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.DoNotShowProgress))]
    public static T EnableDoNotShowProgress<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, true));
    /// <inheritdoc cref="ChocolateyPushSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.DoNotShowProgress))]
    public static T DisableDoNotShowProgress<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, false));
    /// <inheritdoc cref="ChocolateyPushSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.DoNotShowProgress))]
    public static T ToggleDoNotShowProgress<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, !o.DoNotShowProgress));
    #endregion
    #region Proxy
    /// <inheritdoc cref="ChocolateyPushSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Proxy))]
    public static T SetProxy<T>(this T o, string v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.Proxy, v));
    /// <inheritdoc cref="ChocolateyPushSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.Proxy))]
    public static T ResetProxy<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.Proxy));
    #endregion
    #region ProxyUserName
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyUserName"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyUserName))]
    public static T SetProxyUserName<T>(this T o, string v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.ProxyUserName, v));
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyUserName"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyUserName))]
    public static T ResetProxyUserName<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.ProxyUserName));
    #endregion
    #region ProxyPassword
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyPassword))]
    public static T SetProxyPassword<T>(this T o, [Secret] string v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.ProxyPassword, v));
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyPassword))]
    public static T ResetProxyPassword<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.ProxyPassword));
    #endregion
    #region ProxyBypassList
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyBypassList))]
    public static T SetProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyBypassList))]
    public static T SetProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyBypassList))]
    public static T AddProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyPushSettings => o.Modify(b => b.AddCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyBypassList))]
    public static T AddProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyPushSettings => o.Modify(b => b.AddCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyBypassList))]
    public static T RemoveProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyPushSettings => o.Modify(b => b.RemoveCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyBypassList))]
    public static T RemoveProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyPushSettings => o.Modify(b => b.RemoveCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyBypassList))]
    public static T ClearProxyBypassList<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.ClearCollection(() => o.ProxyBypassList));
    #endregion
    #region ProxyBypassOnLocal
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyBypassOnLocal))]
    public static T SetProxyBypassOnLocal<T>(this T o, bool? v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, v));
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyBypassOnLocal))]
    public static T ResetProxyBypassOnLocal<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.ProxyBypassOnLocal));
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyBypassOnLocal))]
    public static T EnableProxyBypassOnLocal<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, true));
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyBypassOnLocal))]
    public static T DisableProxyBypassOnLocal<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, false));
    /// <inheritdoc cref="ChocolateyPushSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.ProxyBypassOnLocal))]
    public static T ToggleProxyBypassOnLocal<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, !o.ProxyBypassOnLocal));
    #endregion
    #region LogFile
    /// <inheritdoc cref="ChocolateyPushSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : ChocolateyPushSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="ChocolateyPushSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ChocolateyPushSettings), Property = nameof(ChocolateyPushSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : ChocolateyPushSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
}
#endregion
#region ChocolateyNewSettingsExtensions
/// <summary>Used within <see cref="ChocolateyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class ChocolateyNewSettingsExtensions
{
    #region AutomaticPackage
    /// <inheritdoc cref="ChocolateyNewSettings.AutomaticPackage"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.AutomaticPackage))]
    public static T SetAutomaticPackage<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.AutomaticPackage, v));
    /// <inheritdoc cref="ChocolateyNewSettings.AutomaticPackage"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.AutomaticPackage))]
    public static T ResetAutomaticPackage<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.AutomaticPackage));
    /// <inheritdoc cref="ChocolateyNewSettings.AutomaticPackage"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.AutomaticPackage))]
    public static T EnableAutomaticPackage<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.AutomaticPackage, true));
    /// <inheritdoc cref="ChocolateyNewSettings.AutomaticPackage"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.AutomaticPackage))]
    public static T DisableAutomaticPackage<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.AutomaticPackage, false));
    /// <inheritdoc cref="ChocolateyNewSettings.AutomaticPackage"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.AutomaticPackage))]
    public static T ToggleAutomaticPackage<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.AutomaticPackage, !o.AutomaticPackage));
    #endregion
    #region TemplateName
    /// <inheritdoc cref="ChocolateyNewSettings.TemplateName"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.TemplateName))]
    public static T SetTemplateName<T>(this T o, string v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.TemplateName, v));
    /// <inheritdoc cref="ChocolateyNewSettings.TemplateName"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.TemplateName))]
    public static T ResetTemplateName<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.TemplateName));
    #endregion
    #region Name
    /// <inheritdoc cref="ChocolateyNewSettings.Name"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="ChocolateyNewSettings.Name"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Name))]
    public static T ResetName<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region Version
    /// <inheritdoc cref="ChocolateyNewSettings.Version"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="ChocolateyNewSettings.Version"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Maintainer
    /// <inheritdoc cref="ChocolateyNewSettings.Maintainer"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Maintainer))]
    public static T SetMaintainer<T>(this T o, string v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Maintainer, v));
    /// <inheritdoc cref="ChocolateyNewSettings.Maintainer"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Maintainer))]
    public static T ResetMaintainer<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.Maintainer));
    #endregion
    #region OutputDirectory
    /// <inheritdoc cref="ChocolateyNewSettings.OutputDirectory"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.OutputDirectory))]
    public static T SetOutputDirectory<T>(this T o, string v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.OutputDirectory, v));
    /// <inheritdoc cref="ChocolateyNewSettings.OutputDirectory"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.OutputDirectory))]
    public static T ResetOutputDirectory<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.OutputDirectory));
    #endregion
    #region BuildInTemplate
    /// <inheritdoc cref="ChocolateyNewSettings.BuildInTemplate"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.BuildInTemplate))]
    public static T SetBuildInTemplate<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.BuildInTemplate, v));
    /// <inheritdoc cref="ChocolateyNewSettings.BuildInTemplate"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.BuildInTemplate))]
    public static T ResetBuildInTemplate<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.BuildInTemplate));
    /// <inheritdoc cref="ChocolateyNewSettings.BuildInTemplate"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.BuildInTemplate))]
    public static T EnableBuildInTemplate<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.BuildInTemplate, true));
    /// <inheritdoc cref="ChocolateyNewSettings.BuildInTemplate"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.BuildInTemplate))]
    public static T DisableBuildInTemplate<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.BuildInTemplate, false));
    /// <inheritdoc cref="ChocolateyNewSettings.BuildInTemplate"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.BuildInTemplate))]
    public static T ToggleBuildInTemplate<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.BuildInTemplate, !o.BuildInTemplate));
    #endregion
    #region LocationOfBinary
    /// <inheritdoc cref="ChocolateyNewSettings.LocationOfBinary"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.LocationOfBinary))]
    public static T SetLocationOfBinary<T>(this T o, string v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.LocationOfBinary, v));
    /// <inheritdoc cref="ChocolateyNewSettings.LocationOfBinary"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.LocationOfBinary))]
    public static T ResetLocationOfBinary<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.LocationOfBinary));
    #endregion
    #region LocationOfBinary64
    /// <inheritdoc cref="ChocolateyNewSettings.LocationOfBinary64"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.LocationOfBinary64))]
    public static T SetLocationOfBinary64<T>(this T o, string v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.LocationOfBinary64, v));
    /// <inheritdoc cref="ChocolateyNewSettings.LocationOfBinary64"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.LocationOfBinary64))]
    public static T ResetLocationOfBinary64<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.LocationOfBinary64));
    #endregion
    #region UseOriginalFilesLocation
    /// <inheritdoc cref="ChocolateyNewSettings.UseOriginalFilesLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.UseOriginalFilesLocation))]
    public static T SetUseOriginalFilesLocation<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.UseOriginalFilesLocation, v));
    /// <inheritdoc cref="ChocolateyNewSettings.UseOriginalFilesLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.UseOriginalFilesLocation))]
    public static T ResetUseOriginalFilesLocation<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.UseOriginalFilesLocation));
    /// <inheritdoc cref="ChocolateyNewSettings.UseOriginalFilesLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.UseOriginalFilesLocation))]
    public static T EnableUseOriginalFilesLocation<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.UseOriginalFilesLocation, true));
    /// <inheritdoc cref="ChocolateyNewSettings.UseOriginalFilesLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.UseOriginalFilesLocation))]
    public static T DisableUseOriginalFilesLocation<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.UseOriginalFilesLocation, false));
    /// <inheritdoc cref="ChocolateyNewSettings.UseOriginalFilesLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.UseOriginalFilesLocation))]
    public static T ToggleUseOriginalFilesLocation<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.UseOriginalFilesLocation, !o.UseOriginalFilesLocation));
    #endregion
    #region Checksum
    /// <inheritdoc cref="ChocolateyNewSettings.Checksum"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Checksum))]
    public static T SetChecksum<T>(this T o, string v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Checksum, v));
    /// <inheritdoc cref="ChocolateyNewSettings.Checksum"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Checksum))]
    public static T ResetChecksum<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.Checksum));
    #endregion
    #region Checksum64
    /// <inheritdoc cref="ChocolateyNewSettings.Checksum64"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Checksum64))]
    public static T SetChecksum64<T>(this T o, string v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Checksum64, v));
    /// <inheritdoc cref="ChocolateyNewSettings.Checksum64"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Checksum64))]
    public static T ResetChecksum64<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.Checksum64));
    #endregion
    #region ChecksumType
    /// <inheritdoc cref="ChocolateyNewSettings.ChecksumType"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ChecksumType))]
    public static T SetChecksumType<T>(this T o, string v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.ChecksumType, v));
    /// <inheritdoc cref="ChocolateyNewSettings.ChecksumType"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ChecksumType))]
    public static T ResetChecksumType<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.ChecksumType));
    #endregion
    #region PauseOnError
    /// <inheritdoc cref="ChocolateyNewSettings.PauseOnError"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.PauseOnError))]
    public static T SetPauseOnError<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.PauseOnError, v));
    /// <inheritdoc cref="ChocolateyNewSettings.PauseOnError"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.PauseOnError))]
    public static T ResetPauseOnError<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.PauseOnError));
    /// <inheritdoc cref="ChocolateyNewSettings.PauseOnError"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.PauseOnError))]
    public static T EnablePauseOnError<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.PauseOnError, true));
    /// <inheritdoc cref="ChocolateyNewSettings.PauseOnError"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.PauseOnError))]
    public static T DisablePauseOnError<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.PauseOnError, false));
    /// <inheritdoc cref="ChocolateyNewSettings.PauseOnError"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.PauseOnError))]
    public static T TogglePauseOnError<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.PauseOnError, !o.PauseOnError));
    #endregion
    #region BuildPackage
    /// <inheritdoc cref="ChocolateyNewSettings.BuildPackage"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.BuildPackage))]
    public static T SetBuildPackage<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.BuildPackage, v));
    /// <inheritdoc cref="ChocolateyNewSettings.BuildPackage"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.BuildPackage))]
    public static T ResetBuildPackage<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.BuildPackage));
    /// <inheritdoc cref="ChocolateyNewSettings.BuildPackage"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.BuildPackage))]
    public static T EnableBuildPackage<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.BuildPackage, true));
    /// <inheritdoc cref="ChocolateyNewSettings.BuildPackage"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.BuildPackage))]
    public static T DisableBuildPackage<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.BuildPackage, false));
    /// <inheritdoc cref="ChocolateyNewSettings.BuildPackage"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.BuildPackage))]
    public static T ToggleBuildPackage<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.BuildPackage, !o.BuildPackage));
    #endregion
    #region GenerateFromInstalledSoftware
    /// <inheritdoc cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.GenerateFromInstalledSoftware))]
    public static T SetGenerateFromInstalledSoftware<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.GenerateFromInstalledSoftware, v));
    /// <inheritdoc cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.GenerateFromInstalledSoftware))]
    public static T ResetGenerateFromInstalledSoftware<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.GenerateFromInstalledSoftware));
    /// <inheritdoc cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.GenerateFromInstalledSoftware))]
    public static T EnableGenerateFromInstalledSoftware<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.GenerateFromInstalledSoftware, true));
    /// <inheritdoc cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.GenerateFromInstalledSoftware))]
    public static T DisableGenerateFromInstalledSoftware<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.GenerateFromInstalledSoftware, false));
    /// <inheritdoc cref="ChocolateyNewSettings.GenerateFromInstalledSoftware"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.GenerateFromInstalledSoftware))]
    public static T ToggleGenerateFromInstalledSoftware<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.GenerateFromInstalledSoftware, !o.GenerateFromInstalledSoftware));
    #endregion
    #region GenerateForCommunity
    /// <inheritdoc cref="ChocolateyNewSettings.GenerateForCommunity"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.GenerateForCommunity))]
    public static T SetGenerateForCommunity<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.GenerateForCommunity, v));
    /// <inheritdoc cref="ChocolateyNewSettings.GenerateForCommunity"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.GenerateForCommunity))]
    public static T ResetGenerateForCommunity<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.GenerateForCommunity));
    /// <inheritdoc cref="ChocolateyNewSettings.GenerateForCommunity"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.GenerateForCommunity))]
    public static T EnableGenerateForCommunity<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.GenerateForCommunity, true));
    /// <inheritdoc cref="ChocolateyNewSettings.GenerateForCommunity"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.GenerateForCommunity))]
    public static T DisableGenerateForCommunity<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.GenerateForCommunity, false));
    /// <inheritdoc cref="ChocolateyNewSettings.GenerateForCommunity"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.GenerateForCommunity))]
    public static T ToggleGenerateForCommunity<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.GenerateForCommunity, !o.GenerateForCommunity));
    #endregion
    #region RemoveArchitectureFromName
    /// <inheritdoc cref="ChocolateyNewSettings.RemoveArchitectureFromName"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.RemoveArchitectureFromName))]
    public static T SetRemoveArchitectureFromName<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.RemoveArchitectureFromName, v));
    /// <inheritdoc cref="ChocolateyNewSettings.RemoveArchitectureFromName"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.RemoveArchitectureFromName))]
    public static T ResetRemoveArchitectureFromName<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.RemoveArchitectureFromName));
    /// <inheritdoc cref="ChocolateyNewSettings.RemoveArchitectureFromName"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.RemoveArchitectureFromName))]
    public static T EnableRemoveArchitectureFromName<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.RemoveArchitectureFromName, true));
    /// <inheritdoc cref="ChocolateyNewSettings.RemoveArchitectureFromName"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.RemoveArchitectureFromName))]
    public static T DisableRemoveArchitectureFromName<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.RemoveArchitectureFromName, false));
    /// <inheritdoc cref="ChocolateyNewSettings.RemoveArchitectureFromName"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.RemoveArchitectureFromName))]
    public static T ToggleRemoveArchitectureFromName<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.RemoveArchitectureFromName, !o.RemoveArchitectureFromName));
    #endregion
    #region IncludeArchitectureInName
    /// <inheritdoc cref="ChocolateyNewSettings.IncludeArchitectureInName"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.IncludeArchitectureInName))]
    public static T SetIncludeArchitectureInName<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.IncludeArchitectureInName, v));
    /// <inheritdoc cref="ChocolateyNewSettings.IncludeArchitectureInName"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.IncludeArchitectureInName))]
    public static T ResetIncludeArchitectureInName<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.IncludeArchitectureInName));
    /// <inheritdoc cref="ChocolateyNewSettings.IncludeArchitectureInName"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.IncludeArchitectureInName))]
    public static T EnableIncludeArchitectureInName<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.IncludeArchitectureInName, true));
    /// <inheritdoc cref="ChocolateyNewSettings.IncludeArchitectureInName"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.IncludeArchitectureInName))]
    public static T DisableIncludeArchitectureInName<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.IncludeArchitectureInName, false));
    /// <inheritdoc cref="ChocolateyNewSettings.IncludeArchitectureInName"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.IncludeArchitectureInName))]
    public static T ToggleIncludeArchitectureInName<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.IncludeArchitectureInName, !o.IncludeArchitectureInName));
    #endregion
    #region Properties
    /// <inheritdoc cref="ChocolateyNewSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Properties))]
    public static T SetProperties<T>(this T o, IDictionary<string, object> v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Properties, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="ChocolateyNewSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Properties))]
    public static T SetProperty<T>(this T o, string k, object v) where T : ChocolateyNewSettings => o.Modify(b => b.SetDictionary(() => o.Properties, k, v));
    /// <inheritdoc cref="ChocolateyNewSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Properties))]
    public static T AddProperty<T>(this T o, string k, object v) where T : ChocolateyNewSettings => o.Modify(b => b.AddDictionary(() => o.Properties, k, v));
    /// <inheritdoc cref="ChocolateyNewSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Properties))]
    public static T RemoveProperty<T>(this T o, string k) where T : ChocolateyNewSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, k));
    /// <inheritdoc cref="ChocolateyNewSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Properties))]
    public static T ClearProperties<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.ClearDictionary(() => o.Properties));
    #endregion
    #region Debug
    /// <inheritdoc cref="ChocolateyNewSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="ChocolateyNewSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="ChocolateyNewSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="ChocolateyNewSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="ChocolateyNewSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region Verbose
    /// <inheritdoc cref="ChocolateyNewSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="ChocolateyNewSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="ChocolateyNewSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="ChocolateyNewSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="ChocolateyNewSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region Trace
    /// <inheritdoc cref="ChocolateyNewSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Trace))]
    public static T SetTrace<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Trace, v));
    /// <inheritdoc cref="ChocolateyNewSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Trace))]
    public static T ResetTrace<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.Trace));
    /// <inheritdoc cref="ChocolateyNewSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Trace))]
    public static T EnableTrace<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Trace, true));
    /// <inheritdoc cref="ChocolateyNewSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Trace))]
    public static T DisableTrace<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Trace, false));
    /// <inheritdoc cref="ChocolateyNewSettings.Trace"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Trace))]
    public static T ToggleTrace<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Trace, !o.Trace));
    #endregion
    #region NoColor
    /// <inheritdoc cref="ChocolateyNewSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.NoColor))]
    public static T SetNoColor<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.NoColor, v));
    /// <inheritdoc cref="ChocolateyNewSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.NoColor))]
    public static T ResetNoColor<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.NoColor));
    /// <inheritdoc cref="ChocolateyNewSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.NoColor))]
    public static T EnableNoColor<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.NoColor, true));
    /// <inheritdoc cref="ChocolateyNewSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.NoColor))]
    public static T DisableNoColor<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.NoColor, false));
    /// <inheritdoc cref="ChocolateyNewSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.NoColor))]
    public static T ToggleNoColor<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.NoColor, !o.NoColor));
    #endregion
    #region AcceptLicense
    /// <inheritdoc cref="ChocolateyNewSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.AcceptLicense))]
    public static T SetAcceptLicense<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.AcceptLicense, v));
    /// <inheritdoc cref="ChocolateyNewSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.AcceptLicense))]
    public static T ResetAcceptLicense<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.AcceptLicense));
    /// <inheritdoc cref="ChocolateyNewSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.AcceptLicense))]
    public static T EnableAcceptLicense<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.AcceptLicense, true));
    /// <inheritdoc cref="ChocolateyNewSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.AcceptLicense))]
    public static T DisableAcceptLicense<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.AcceptLicense, false));
    /// <inheritdoc cref="ChocolateyNewSettings.AcceptLicense"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.AcceptLicense))]
    public static T ToggleAcceptLicense<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.AcceptLicense, !o.AcceptLicense));
    #endregion
    #region Confirm
    /// <inheritdoc cref="ChocolateyNewSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Confirm))]
    public static T SetConfirm<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Confirm, v));
    /// <inheritdoc cref="ChocolateyNewSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Confirm))]
    public static T ResetConfirm<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.Confirm));
    /// <inheritdoc cref="ChocolateyNewSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Confirm))]
    public static T EnableConfirm<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Confirm, true));
    /// <inheritdoc cref="ChocolateyNewSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Confirm))]
    public static T DisableConfirm<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Confirm, false));
    /// <inheritdoc cref="ChocolateyNewSettings.Confirm"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Confirm))]
    public static T ToggleConfirm<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Confirm, !o.Confirm));
    #endregion
    #region Force
    /// <inheritdoc cref="ChocolateyNewSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="ChocolateyNewSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Force))]
    public static T ResetForce<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="ChocolateyNewSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Force))]
    public static T EnableForce<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="ChocolateyNewSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Force))]
    public static T DisableForce<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="ChocolateyNewSettings.Force"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region LimitOutput
    /// <inheritdoc cref="ChocolateyNewSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.LimitOutput))]
    public static T SetLimitOutput<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.LimitOutput, v));
    /// <inheritdoc cref="ChocolateyNewSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.LimitOutput))]
    public static T ResetLimitOutput<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.LimitOutput));
    /// <inheritdoc cref="ChocolateyNewSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.LimitOutput))]
    public static T EnableLimitOutput<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.LimitOutput, true));
    /// <inheritdoc cref="ChocolateyNewSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.LimitOutput))]
    public static T DisableLimitOutput<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.LimitOutput, false));
    /// <inheritdoc cref="ChocolateyNewSettings.LimitOutput"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.LimitOutput))]
    public static T ToggleLimitOutput<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.LimitOutput, !o.LimitOutput));
    #endregion
    #region CommandExecutionTimeout
    /// <inheritdoc cref="ChocolateyNewSettings.CommandExecutionTimeout"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.CommandExecutionTimeout))]
    public static T SetCommandExecutionTimeout<T>(this T o, int? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.CommandExecutionTimeout, v));
    /// <inheritdoc cref="ChocolateyNewSettings.CommandExecutionTimeout"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.CommandExecutionTimeout))]
    public static T ResetCommandExecutionTimeout<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.CommandExecutionTimeout));
    #endregion
    #region CacheLocation
    /// <inheritdoc cref="ChocolateyNewSettings.CacheLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.CacheLocation))]
    public static T SetCacheLocation<T>(this T o, string v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.CacheLocation, v));
    /// <inheritdoc cref="ChocolateyNewSettings.CacheLocation"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.CacheLocation))]
    public static T ResetCacheLocation<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.CacheLocation));
    #endregion
    #region AllowUnofficialBuild
    /// <inheritdoc cref="ChocolateyNewSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.AllowUnofficialBuild))]
    public static T SetAllowUnofficialBuild<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, v));
    /// <inheritdoc cref="ChocolateyNewSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.AllowUnofficialBuild))]
    public static T ResetAllowUnofficialBuild<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.AllowUnofficialBuild));
    /// <inheritdoc cref="ChocolateyNewSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.AllowUnofficialBuild))]
    public static T EnableAllowUnofficialBuild<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, true));
    /// <inheritdoc cref="ChocolateyNewSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.AllowUnofficialBuild))]
    public static T DisableAllowUnofficialBuild<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, false));
    /// <inheritdoc cref="ChocolateyNewSettings.AllowUnofficialBuild"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.AllowUnofficialBuild))]
    public static T ToggleAllowUnofficialBuild<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.AllowUnofficialBuild, !o.AllowUnofficialBuild));
    #endregion
    #region FailOnStandardError
    /// <inheritdoc cref="ChocolateyNewSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.FailOnStandardError))]
    public static T SetFailOnStandardError<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, v));
    /// <inheritdoc cref="ChocolateyNewSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.FailOnStandardError))]
    public static T ResetFailOnStandardError<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.FailOnStandardError));
    /// <inheritdoc cref="ChocolateyNewSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.FailOnStandardError))]
    public static T EnableFailOnStandardError<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, true));
    /// <inheritdoc cref="ChocolateyNewSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.FailOnStandardError))]
    public static T DisableFailOnStandardError<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, false));
    /// <inheritdoc cref="ChocolateyNewSettings.FailOnStandardError"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.FailOnStandardError))]
    public static T ToggleFailOnStandardError<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.FailOnStandardError, !o.FailOnStandardError));
    #endregion
    #region UseSystemPowerShell
    /// <inheritdoc cref="ChocolateyNewSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.UseSystemPowerShell))]
    public static T SetUseSystemPowerShell<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, v));
    /// <inheritdoc cref="ChocolateyNewSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.UseSystemPowerShell))]
    public static T ResetUseSystemPowerShell<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.UseSystemPowerShell));
    /// <inheritdoc cref="ChocolateyNewSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.UseSystemPowerShell))]
    public static T EnableUseSystemPowerShell<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, true));
    /// <inheritdoc cref="ChocolateyNewSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.UseSystemPowerShell))]
    public static T DisableUseSystemPowerShell<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, false));
    /// <inheritdoc cref="ChocolateyNewSettings.UseSystemPowerShell"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.UseSystemPowerShell))]
    public static T ToggleUseSystemPowerShell<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.UseSystemPowerShell, !o.UseSystemPowerShell));
    #endregion
    #region DoNotShowProgress
    /// <inheritdoc cref="ChocolateyNewSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.DoNotShowProgress))]
    public static T SetDoNotShowProgress<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, v));
    /// <inheritdoc cref="ChocolateyNewSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.DoNotShowProgress))]
    public static T ResetDoNotShowProgress<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.DoNotShowProgress));
    /// <inheritdoc cref="ChocolateyNewSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.DoNotShowProgress))]
    public static T EnableDoNotShowProgress<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, true));
    /// <inheritdoc cref="ChocolateyNewSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.DoNotShowProgress))]
    public static T DisableDoNotShowProgress<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, false));
    /// <inheritdoc cref="ChocolateyNewSettings.DoNotShowProgress"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.DoNotShowProgress))]
    public static T ToggleDoNotShowProgress<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.DoNotShowProgress, !o.DoNotShowProgress));
    #endregion
    #region Proxy
    /// <inheritdoc cref="ChocolateyNewSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Proxy))]
    public static T SetProxy<T>(this T o, string v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.Proxy, v));
    /// <inheritdoc cref="ChocolateyNewSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.Proxy))]
    public static T ResetProxy<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.Proxy));
    #endregion
    #region ProxyUserName
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyUserName"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyUserName))]
    public static T SetProxyUserName<T>(this T o, string v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.ProxyUserName, v));
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyUserName"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyUserName))]
    public static T ResetProxyUserName<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.ProxyUserName));
    #endregion
    #region ProxyPassword
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyPassword))]
    public static T SetProxyPassword<T>(this T o, [Secret] string v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.ProxyPassword, v));
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyPassword))]
    public static T ResetProxyPassword<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.ProxyPassword));
    #endregion
    #region ProxyBypassList
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyBypassList))]
    public static T SetProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyBypassList))]
    public static T SetProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyBypassList))]
    public static T AddProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyNewSettings => o.Modify(b => b.AddCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyBypassList))]
    public static T AddProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyNewSettings => o.Modify(b => b.AddCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyBypassList))]
    public static T RemoveProxyBypassList<T>(this T o, params string[] v) where T : ChocolateyNewSettings => o.Modify(b => b.RemoveCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyBypassList))]
    public static T RemoveProxyBypassList<T>(this T o, IEnumerable<string> v) where T : ChocolateyNewSettings => o.Modify(b => b.RemoveCollection(() => o.ProxyBypassList, v));
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyBypassList"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyBypassList))]
    public static T ClearProxyBypassList<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.ClearCollection(() => o.ProxyBypassList));
    #endregion
    #region ProxyBypassOnLocal
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyBypassOnLocal))]
    public static T SetProxyBypassOnLocal<T>(this T o, bool? v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, v));
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyBypassOnLocal))]
    public static T ResetProxyBypassOnLocal<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.ProxyBypassOnLocal));
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyBypassOnLocal))]
    public static T EnableProxyBypassOnLocal<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, true));
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyBypassOnLocal))]
    public static T DisableProxyBypassOnLocal<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, false));
    /// <inheritdoc cref="ChocolateyNewSettings.ProxyBypassOnLocal"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.ProxyBypassOnLocal))]
    public static T ToggleProxyBypassOnLocal<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.ProxyBypassOnLocal, !o.ProxyBypassOnLocal));
    #endregion
    #region LogFile
    /// <inheritdoc cref="ChocolateyNewSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : ChocolateyNewSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="ChocolateyNewSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ChocolateyNewSettings), Property = nameof(ChocolateyNewSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : ChocolateyNewSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
}
#endregion
