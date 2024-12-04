
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

namespace Nuke.Common.Tools.NuGetKeyVaultSignTool;

/// <summary><p>NuGet Key Vault Sign Tool is similar to <c>nuget sign</c>, with the major difference being that it uses Azure Key Vault for performing the signing process. Similar usage configuration like <c>AzureSignTool</c>, except is used to sign nuget package.</p><p>For more details, visit the <a href="https://github.com/novotnyllc/NuGetKeyVaultSignTool">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class NuGetKeyVaultSignToolTasks : ToolTasks, IRequireNuGetPackage
{
    public static string NuGetKeyVaultSignToolPath => new NuGetKeyVaultSignToolTasks().GetToolPath();
    public const string PackageId = "NuGetKeyVaultSignTool";
    public const string PackageExecutable = "NuGetKeyVaultSignTool.dll";
    /// <summary><p>NuGet Key Vault Sign Tool is similar to <c>nuget sign</c>, with the major difference being that it uses Azure Key Vault for performing the signing process. Similar usage configuration like <c>AzureSignTool</c>, except is used to sign nuget package.</p><p>For more details, visit the <a href="https://github.com/novotnyllc/NuGetKeyVaultSignTool">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> NuGetKeyVaultSignTool(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new NuGetKeyVaultSignToolTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>NuGet Key Vault Sign Tool is similar to <c>nuget sign</c>, with the major difference being that it uses Azure Key Vault for performing the signing process. Similar usage configuration like <c>AzureSignTool</c>, except is used to sign nuget package.</p><p>For more details, visit the <a href="https://github.com/novotnyllc/NuGetKeyVaultSignTool">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;file&gt;</c> via <see cref="NuGetKeyVaultSignToolSettings.File"/></li><li><c>--azure-key-vault-accesstoken</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultAccessToken"/></li><li><c>--azure-key-vault-certificate</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultCertificateName"/></li><li><c>--azure-key-vault-client-id</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultClientId"/></li><li><c>--azure-key-vault-client-secret</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultClientSecret"/></li><li><c>--azure-key-vault-managed-identity</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultManagedIdentity"/></li><li><c>--azure-key-vault-tenant-id</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultTenantId"/></li><li><c>--azure-key-vault-url</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultUrl"/></li><li><c>--file-digest</c> via <see cref="NuGetKeyVaultSignToolSettings.FileDigest"/></li><li><c>--force</c> via <see cref="NuGetKeyVaultSignToolSettings.Force"/></li><li><c>--output</c> via <see cref="NuGetKeyVaultSignToolSettings.Output"/></li><li><c>--timestamp-digest</c> via <see cref="NuGetKeyVaultSignToolSettings.TimestampDigest"/></li><li><c>--timestamp-rfc3161</c> via <see cref="NuGetKeyVaultSignToolSettings.TimestampRfc3161Url"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetKeyVaultSignTool(NuGetKeyVaultSignToolSettings options = null) => new NuGetKeyVaultSignToolTasks().Run(options);
    /// <summary><p>NuGet Key Vault Sign Tool is similar to <c>nuget sign</c>, with the major difference being that it uses Azure Key Vault for performing the signing process. Similar usage configuration like <c>AzureSignTool</c>, except is used to sign nuget package.</p><p>For more details, visit the <a href="https://github.com/novotnyllc/NuGetKeyVaultSignTool">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;file&gt;</c> via <see cref="NuGetKeyVaultSignToolSettings.File"/></li><li><c>--azure-key-vault-accesstoken</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultAccessToken"/></li><li><c>--azure-key-vault-certificate</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultCertificateName"/></li><li><c>--azure-key-vault-client-id</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultClientId"/></li><li><c>--azure-key-vault-client-secret</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultClientSecret"/></li><li><c>--azure-key-vault-managed-identity</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultManagedIdentity"/></li><li><c>--azure-key-vault-tenant-id</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultTenantId"/></li><li><c>--azure-key-vault-url</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultUrl"/></li><li><c>--file-digest</c> via <see cref="NuGetKeyVaultSignToolSettings.FileDigest"/></li><li><c>--force</c> via <see cref="NuGetKeyVaultSignToolSettings.Force"/></li><li><c>--output</c> via <see cref="NuGetKeyVaultSignToolSettings.Output"/></li><li><c>--timestamp-digest</c> via <see cref="NuGetKeyVaultSignToolSettings.TimestampDigest"/></li><li><c>--timestamp-rfc3161</c> via <see cref="NuGetKeyVaultSignToolSettings.TimestampRfc3161Url"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetKeyVaultSignTool(Configure<NuGetKeyVaultSignToolSettings> configurator) => new NuGetKeyVaultSignToolTasks().Run(configurator.Invoke(new NuGetKeyVaultSignToolSettings()));
    /// <summary><p>NuGet Key Vault Sign Tool is similar to <c>nuget sign</c>, with the major difference being that it uses Azure Key Vault for performing the signing process. Similar usage configuration like <c>AzureSignTool</c>, except is used to sign nuget package.</p><p>For more details, visit the <a href="https://github.com/novotnyllc/NuGetKeyVaultSignTool">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;file&gt;</c> via <see cref="NuGetKeyVaultSignToolSettings.File"/></li><li><c>--azure-key-vault-accesstoken</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultAccessToken"/></li><li><c>--azure-key-vault-certificate</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultCertificateName"/></li><li><c>--azure-key-vault-client-id</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultClientId"/></li><li><c>--azure-key-vault-client-secret</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultClientSecret"/></li><li><c>--azure-key-vault-managed-identity</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultManagedIdentity"/></li><li><c>--azure-key-vault-tenant-id</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultTenantId"/></li><li><c>--azure-key-vault-url</c> via <see cref="NuGetKeyVaultSignToolSettings.KeyVaultUrl"/></li><li><c>--file-digest</c> via <see cref="NuGetKeyVaultSignToolSettings.FileDigest"/></li><li><c>--force</c> via <see cref="NuGetKeyVaultSignToolSettings.Force"/></li><li><c>--output</c> via <see cref="NuGetKeyVaultSignToolSettings.Output"/></li><li><c>--timestamp-digest</c> via <see cref="NuGetKeyVaultSignToolSettings.TimestampDigest"/></li><li><c>--timestamp-rfc3161</c> via <see cref="NuGetKeyVaultSignToolSettings.TimestampRfc3161Url"/></li></ul></remarks>
    public static IEnumerable<(NuGetKeyVaultSignToolSettings Settings, IReadOnlyCollection<Output> Output)> NuGetKeyVaultSignTool(CombinatorialConfigure<NuGetKeyVaultSignToolSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NuGetKeyVaultSignTool, degreeOfParallelism, completeOnFailure);
}
#region NuGetKeyVaultSignToolSettings
/// <summary>Used within <see cref="NuGetKeyVaultSignToolTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Command(Type = typeof(NuGetKeyVaultSignToolTasks), Command = nameof(NuGetKeyVaultSignToolTasks.NuGetKeyVaultSignTool), Arguments = "sign")]
public partial class NuGetKeyVaultSignToolSettings : ToolOptions
{
    /// <summary>Package to sign.</summary>
    [Argument(Format = "{value}")] public string File => Get<string>(() => File);
    /// <summary>A fully qualified URL of the key vault with the certificate that will be used for signing. An example value might be <c>https://my-vault.vault.azure.net</c>.</summary>
    [Argument(Format = "--azure-key-vault-url {value}", Secret = false)] public string KeyVaultUrl => Get<string>(() => KeyVaultUrl);
    /// <summary>This is the client ID used to authenticate to Azure, which will be used to generate an access token. This parameter is not required if an access token is supplied directly with the <c>--azure-key-vault-accesstoken</c> option. If this parameter is supplied, <c>--azure-key-vault-client-secret</c> and <c>--azure-key-vault-tenant-id</c> must be supplied as well.</summary>
    [Argument(Format = "--azure-key-vault-client-id {value}", Secret = false)] public string KeyVaultClientId => Get<string>(() => KeyVaultClientId);
    /// <summary>This is the client secret used to authenticate to Azure, which will be used to generate an access token. This parameter is not required if an access token is supplied directly with the <c>--azure-key-vault-accesstoken</c> option or when using managed identities with <c>--azure-key-vault-managed-identity</c>. If this parameter is supplied, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-tenant-id</c> must be supplied as well.</summary>
    [Argument(Format = "--azure-key-vault-client-secret {value}", Secret = true)] public string KeyVaultClientSecret => Get<string>(() => KeyVaultClientSecret);
    /// <summary>This is the tenant id used to authenticate to Azure, which will be used to generate an access token. This parameter is not required if an access token is supplied directly with the <c>--azure-key-vault-accesstoken</c> option or when using managed identities with <c>--azure-key-vault-managed-identity</c>. If this parameter is supplied, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> must be supplied as well.</summary>
    [Argument(Format = "--azure-key-vault-tenant-id {value}", Secret = false)] public string KeyVaultTenantId => Get<string>(() => KeyVaultTenantId);
    /// <summary>The name of the certificate used to perform the signing operation.</summary>
    [Argument(Format = "--azure-key-vault-certificate {value}", Secret = false)] public string KeyVaultCertificateName => Get<string>(() => KeyVaultCertificateName);
    /// <summary>An access token used to authenticate to Azure. This can be used instead of the <c>--azure-key-vault-managed-identity</c>, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> options. This is useful if NuGetKeyVaultSignTool is being used as part of another program that is already authenticated and has an access token to Azure.</summary>
    [Argument(Format = "--azure-key-vault-accesstoken {value}", Secret = true)] public string KeyVaultAccessToken => Get<string>(() => KeyVaultAccessToken);
    /// <summary>Use the ambient Managed Identity to authenticate to Azure. This can be used instead of the <c>--azure-key-vault-accesstoken</c>, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> options. This is useful if NuGetKeyVaultSignTool is being used on a VM/service/CLI that is configured for managed identities to Azure.</summary>
    [Argument(Format = "--azure-key-vault-managed-identity", Secret = false)] public bool? KeyVaultManagedIdentity => Get<bool?>(() => KeyVaultManagedIdentity);
    /// <summary>A URL to an RFC3161 compliant timestamping service. This parameter serves the same purpose as the <c>/tr</c> option in the Windows SDK <c>signtool</c>. This parameter should be used in favor of the <c>--timestamp</c> option. Using this parameter will allow using modern, RFC3161 timestamps which also support timestamp digest algorithms other than SHA1.</summary>
    [Argument(Format = "--timestamp-rfc3161 {value}")] public string TimestampRfc3161Url => Get<string>(() => TimestampRfc3161Url);
    /// <summary>The name of the digest algorithm used for timestamping. This parameter is ignored unless the <c>--timestamp-rfc3161</c> parameter is also supplied. The default value is <c>sha256</c>.</summary>
    [Argument(Format = "--timestamp-digest {value}")] public NuGetKeyVaultSignToolDigestAlgorithm TimestampDigest => Get<NuGetKeyVaultSignToolDigestAlgorithm>(() => TimestampDigest);
    /// <summary>The name of the digest algorithm used for hashing the file being signed. The default value is <c>sha256</c>.</summary>
    [Argument(Format = "--file-digest {value}")] public NuGetKeyVaultSignToolDigestAlgorithm FileDigest => Get<NuGetKeyVaultSignToolDigestAlgorithm>(() => FileDigest);
    /// <summary>Overwrites a signature if it exists.</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>The output file. If omitted, overwrites input.</summary>
    [Argument(Format = "--output {value}")] public string Output => Get<string>(() => Output);
}
#endregion
#region NuGetKeyVaultSignToolSettingsExtensions
/// <summary>Used within <see cref="NuGetKeyVaultSignToolTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NuGetKeyVaultSignToolSettingsExtensions
{
    #region File
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.File"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.File))]
    public static T SetFile<T>(this T o, string v) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.File, v));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.File"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.File))]
    public static T ResetFile<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Remove(() => o.File));
    #endregion
    #region KeyVaultUrl
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultUrl"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultUrl))]
    public static T SetKeyVaultUrl<T>(this T o, string v) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultUrl, v));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultUrl"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultUrl))]
    public static T ResetKeyVaultUrl<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Remove(() => o.KeyVaultUrl));
    #endregion
    #region KeyVaultClientId
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultClientId"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultClientId))]
    public static T SetKeyVaultClientId<T>(this T o, string v) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultClientId, v));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultClientId"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultClientId))]
    public static T ResetKeyVaultClientId<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Remove(() => o.KeyVaultClientId));
    #endregion
    #region KeyVaultClientSecret
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultClientSecret"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultClientSecret))]
    public static T SetKeyVaultClientSecret<T>(this T o, [Secret] string v) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultClientSecret, v));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultClientSecret"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultClientSecret))]
    public static T ResetKeyVaultClientSecret<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Remove(() => o.KeyVaultClientSecret));
    #endregion
    #region KeyVaultTenantId
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultTenantId"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultTenantId))]
    public static T SetKeyVaultTenantId<T>(this T o, string v) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultTenantId, v));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultTenantId"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultTenantId))]
    public static T ResetKeyVaultTenantId<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Remove(() => o.KeyVaultTenantId));
    #endregion
    #region KeyVaultCertificateName
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultCertificateName"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultCertificateName))]
    public static T SetKeyVaultCertificateName<T>(this T o, string v) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultCertificateName, v));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultCertificateName"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultCertificateName))]
    public static T ResetKeyVaultCertificateName<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Remove(() => o.KeyVaultCertificateName));
    #endregion
    #region KeyVaultAccessToken
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultAccessToken"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultAccessToken))]
    public static T SetKeyVaultAccessToken<T>(this T o, [Secret] string v) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultAccessToken, v));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultAccessToken"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultAccessToken))]
    public static T ResetKeyVaultAccessToken<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Remove(() => o.KeyVaultAccessToken));
    #endregion
    #region KeyVaultManagedIdentity
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultManagedIdentity"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultManagedIdentity))]
    public static T SetKeyVaultManagedIdentity<T>(this T o, bool? v) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultManagedIdentity, v));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultManagedIdentity"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultManagedIdentity))]
    public static T ResetKeyVaultManagedIdentity<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Remove(() => o.KeyVaultManagedIdentity));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultManagedIdentity"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultManagedIdentity))]
    public static T EnableKeyVaultManagedIdentity<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultManagedIdentity, true));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultManagedIdentity"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultManagedIdentity))]
    public static T DisableKeyVaultManagedIdentity<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultManagedIdentity, false));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.KeyVaultManagedIdentity"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.KeyVaultManagedIdentity))]
    public static T ToggleKeyVaultManagedIdentity<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultManagedIdentity, !o.KeyVaultManagedIdentity));
    #endregion
    #region TimestampRfc3161Url
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.TimestampRfc3161Url"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.TimestampRfc3161Url))]
    public static T SetTimestampRfc3161Url<T>(this T o, string v) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.TimestampRfc3161Url, v));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.TimestampRfc3161Url"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.TimestampRfc3161Url))]
    public static T ResetTimestampRfc3161Url<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Remove(() => o.TimestampRfc3161Url));
    #endregion
    #region TimestampDigest
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.TimestampDigest"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.TimestampDigest))]
    public static T SetTimestampDigest<T>(this T o, NuGetKeyVaultSignToolDigestAlgorithm v) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.TimestampDigest, v));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.TimestampDigest"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.TimestampDigest))]
    public static T ResetTimestampDigest<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Remove(() => o.TimestampDigest));
    #endregion
    #region FileDigest
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.FileDigest"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.FileDigest))]
    public static T SetFileDigest<T>(this T o, NuGetKeyVaultSignToolDigestAlgorithm v) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.FileDigest, v));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.FileDigest"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.FileDigest))]
    public static T ResetFileDigest<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Remove(() => o.FileDigest));
    #endregion
    #region Force
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.Force"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.Force"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.Force))]
    public static T ResetForce<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.Force"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.Force))]
    public static T EnableForce<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.Force"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.Force))]
    public static T DisableForce<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.Force"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region Output
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.Output"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.Output))]
    public static T SetOutput<T>(this T o, string v) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="NuGetKeyVaultSignToolSettings.Output"/>
    [Pure]
    [Builder(Type = typeof(NuGetKeyVaultSignToolSettings), Property = nameof(NuGetKeyVaultSignToolSettings.Output))]
    public static T ResetOutput<T>(this T o) where T : NuGetKeyVaultSignToolSettings => o.Modify(b => b.Remove(() => o.Output));
    #endregion
}
#endregion
#region NuGetKeyVaultSignToolDigestAlgorithm
/// <summary>Used within <see cref="NuGetKeyVaultSignToolTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NuGetKeyVaultSignToolDigestAlgorithm>))]
public partial class NuGetKeyVaultSignToolDigestAlgorithm : Enumeration
{
    public static NuGetKeyVaultSignToolDigestAlgorithm sha1 = (NuGetKeyVaultSignToolDigestAlgorithm)"sha1";
    public static NuGetKeyVaultSignToolDigestAlgorithm sha256 = (NuGetKeyVaultSignToolDigestAlgorithm)"sha256";
    public static NuGetKeyVaultSignToolDigestAlgorithm sha384 = (NuGetKeyVaultSignToolDigestAlgorithm)"sha384";
    public static NuGetKeyVaultSignToolDigestAlgorithm sha512 = (NuGetKeyVaultSignToolDigestAlgorithm)"sha512";
    public static implicit operator NuGetKeyVaultSignToolDigestAlgorithm(string value)
    {
        return new NuGetKeyVaultSignToolDigestAlgorithm { Value = value };
    }
}
#endregion
