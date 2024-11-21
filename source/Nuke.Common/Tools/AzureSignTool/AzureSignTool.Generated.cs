// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/AzureSignTool/AzureSignTool.json

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

namespace Nuke.Common.Tools.AzureSignTool;

/// <summary><p>Azure Sign Tool is similar to <c>signtool</c> in the Windows SDK, with the major difference being that it uses Azure Key Vault for performing the signing process. The usage is like <c>signtool</c>, except with a limited set of options for signing and options for authenticating to Azure Key Vault.</p><p>For more details, visit the <a href="https://github.com/vcsjones/AzureSignTool">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class AzureSignToolTasks : ToolTasks, IRequireNuGetPackage
{
    public static string AzureSignToolPath => new AzureSignToolTasks().GetToolPath();
    public const string PackageId = "AzureSignTool";
    public const string PackageExecutable = "AzureSignTool.dll";
    /// <summary><p>Azure Sign Tool is similar to <c>signtool</c> in the Windows SDK, with the major difference being that it uses Azure Key Vault for performing the signing process. The usage is like <c>signtool</c>, except with a limited set of options for signing and options for authenticating to Azure Key Vault.</p><p>For more details, visit the <a href="https://github.com/vcsjones/AzureSignTool">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> AzureSignTool(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new AzureSignToolTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Azure Sign Tool is similar to <c>signtool</c> in the Windows SDK, with the major difference being that it uses Azure Key Vault for performing the signing process. The usage is like <c>signtool</c>, except with a limited set of options for signing and options for authenticating to Azure Key Vault.</p><p>For more details, visit the <a href="https://github.com/vcsjones/AzureSignTool">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;files&gt;</c> via <see cref="AzureSignToolSettings.Files"/></li><li><c>--additional-certificates</c> via <see cref="AzureSignToolSettings.AdditionalCertificates"/></li><li><c>--azure-key-vault-accesstoken</c> via <see cref="AzureSignToolSettings.KeyVaultAccessToken"/></li><li><c>--azure-key-vault-certificate</c> via <see cref="AzureSignToolSettings.KeyVaultCertificateName"/></li><li><c>--azure-key-vault-client-id</c> via <see cref="AzureSignToolSettings.KeyVaultClientId"/></li><li><c>--azure-key-vault-client-secret</c> via <see cref="AzureSignToolSettings.KeyVaultClientSecret"/></li><li><c>--azure-key-vault-managed-identity</c> via <see cref="AzureSignToolSettings.KeyVaultManagedIdentity"/></li><li><c>--azure-key-vault-tenant-id</c> via <see cref="AzureSignToolSettings.KeyVaultTenantId"/></li><li><c>--azure-key-vault-url</c> via <see cref="AzureSignToolSettings.KeyVaultUrl"/></li><li><c>--continue-on-error</c> via <see cref="AzureSignToolSettings.ContinueOnError"/></li><li><c>--description</c> via <see cref="AzureSignToolSettings.Description"/></li><li><c>--description-url</c> via <see cref="AzureSignToolSettings.DescriptionUrl"/></li><li><c>--file-digest</c> via <see cref="AzureSignToolSettings.FileDigest"/></li><li><c>--input-file-list</c> via <see cref="AzureSignToolSettings.InputFileList"/></li><li><c>--max-degree-of-parallelism</c> via <see cref="AzureSignToolSettings.MaxDegreeOfParallelism"/></li><li><c>--no-page-hashing</c> via <see cref="AzureSignToolSettings.NoPageHashing"/></li><li><c>--page-hashing</c> via <see cref="AzureSignToolSettings.PageHashing"/></li><li><c>--quiet</c> via <see cref="AzureSignToolSettings.Quiet"/></li><li><c>--skip-signed</c> via <see cref="AzureSignToolSettings.SkipSigned"/></li><li><c>--timestamp-authenticode</c> via <see cref="AzureSignToolSettings.TimestampAuthenticodeUrl"/></li><li><c>--timestamp-digest</c> via <see cref="AzureSignToolSettings.TimestampDigest"/></li><li><c>--timestamp-rfc3161</c> via <see cref="AzureSignToolSettings.TimestampRfc3161Url"/></li><li><c>--verbose</c> via <see cref="AzureSignToolSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> AzureSignTool(AzureSignToolSettings options = null) => new AzureSignToolTasks().Run(options);
    /// <summary><p>Azure Sign Tool is similar to <c>signtool</c> in the Windows SDK, with the major difference being that it uses Azure Key Vault for performing the signing process. The usage is like <c>signtool</c>, except with a limited set of options for signing and options for authenticating to Azure Key Vault.</p><p>For more details, visit the <a href="https://github.com/vcsjones/AzureSignTool">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;files&gt;</c> via <see cref="AzureSignToolSettings.Files"/></li><li><c>--additional-certificates</c> via <see cref="AzureSignToolSettings.AdditionalCertificates"/></li><li><c>--azure-key-vault-accesstoken</c> via <see cref="AzureSignToolSettings.KeyVaultAccessToken"/></li><li><c>--azure-key-vault-certificate</c> via <see cref="AzureSignToolSettings.KeyVaultCertificateName"/></li><li><c>--azure-key-vault-client-id</c> via <see cref="AzureSignToolSettings.KeyVaultClientId"/></li><li><c>--azure-key-vault-client-secret</c> via <see cref="AzureSignToolSettings.KeyVaultClientSecret"/></li><li><c>--azure-key-vault-managed-identity</c> via <see cref="AzureSignToolSettings.KeyVaultManagedIdentity"/></li><li><c>--azure-key-vault-tenant-id</c> via <see cref="AzureSignToolSettings.KeyVaultTenantId"/></li><li><c>--azure-key-vault-url</c> via <see cref="AzureSignToolSettings.KeyVaultUrl"/></li><li><c>--continue-on-error</c> via <see cref="AzureSignToolSettings.ContinueOnError"/></li><li><c>--description</c> via <see cref="AzureSignToolSettings.Description"/></li><li><c>--description-url</c> via <see cref="AzureSignToolSettings.DescriptionUrl"/></li><li><c>--file-digest</c> via <see cref="AzureSignToolSettings.FileDigest"/></li><li><c>--input-file-list</c> via <see cref="AzureSignToolSettings.InputFileList"/></li><li><c>--max-degree-of-parallelism</c> via <see cref="AzureSignToolSettings.MaxDegreeOfParallelism"/></li><li><c>--no-page-hashing</c> via <see cref="AzureSignToolSettings.NoPageHashing"/></li><li><c>--page-hashing</c> via <see cref="AzureSignToolSettings.PageHashing"/></li><li><c>--quiet</c> via <see cref="AzureSignToolSettings.Quiet"/></li><li><c>--skip-signed</c> via <see cref="AzureSignToolSettings.SkipSigned"/></li><li><c>--timestamp-authenticode</c> via <see cref="AzureSignToolSettings.TimestampAuthenticodeUrl"/></li><li><c>--timestamp-digest</c> via <see cref="AzureSignToolSettings.TimestampDigest"/></li><li><c>--timestamp-rfc3161</c> via <see cref="AzureSignToolSettings.TimestampRfc3161Url"/></li><li><c>--verbose</c> via <see cref="AzureSignToolSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> AzureSignTool(Configure<AzureSignToolSettings> configurator) => new AzureSignToolTasks().Run(configurator.Invoke(new AzureSignToolSettings()));
    /// <summary><p>Azure Sign Tool is similar to <c>signtool</c> in the Windows SDK, with the major difference being that it uses Azure Key Vault for performing the signing process. The usage is like <c>signtool</c>, except with a limited set of options for signing and options for authenticating to Azure Key Vault.</p><p>For more details, visit the <a href="https://github.com/vcsjones/AzureSignTool">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;files&gt;</c> via <see cref="AzureSignToolSettings.Files"/></li><li><c>--additional-certificates</c> via <see cref="AzureSignToolSettings.AdditionalCertificates"/></li><li><c>--azure-key-vault-accesstoken</c> via <see cref="AzureSignToolSettings.KeyVaultAccessToken"/></li><li><c>--azure-key-vault-certificate</c> via <see cref="AzureSignToolSettings.KeyVaultCertificateName"/></li><li><c>--azure-key-vault-client-id</c> via <see cref="AzureSignToolSettings.KeyVaultClientId"/></li><li><c>--azure-key-vault-client-secret</c> via <see cref="AzureSignToolSettings.KeyVaultClientSecret"/></li><li><c>--azure-key-vault-managed-identity</c> via <see cref="AzureSignToolSettings.KeyVaultManagedIdentity"/></li><li><c>--azure-key-vault-tenant-id</c> via <see cref="AzureSignToolSettings.KeyVaultTenantId"/></li><li><c>--azure-key-vault-url</c> via <see cref="AzureSignToolSettings.KeyVaultUrl"/></li><li><c>--continue-on-error</c> via <see cref="AzureSignToolSettings.ContinueOnError"/></li><li><c>--description</c> via <see cref="AzureSignToolSettings.Description"/></li><li><c>--description-url</c> via <see cref="AzureSignToolSettings.DescriptionUrl"/></li><li><c>--file-digest</c> via <see cref="AzureSignToolSettings.FileDigest"/></li><li><c>--input-file-list</c> via <see cref="AzureSignToolSettings.InputFileList"/></li><li><c>--max-degree-of-parallelism</c> via <see cref="AzureSignToolSettings.MaxDegreeOfParallelism"/></li><li><c>--no-page-hashing</c> via <see cref="AzureSignToolSettings.NoPageHashing"/></li><li><c>--page-hashing</c> via <see cref="AzureSignToolSettings.PageHashing"/></li><li><c>--quiet</c> via <see cref="AzureSignToolSettings.Quiet"/></li><li><c>--skip-signed</c> via <see cref="AzureSignToolSettings.SkipSigned"/></li><li><c>--timestamp-authenticode</c> via <see cref="AzureSignToolSettings.TimestampAuthenticodeUrl"/></li><li><c>--timestamp-digest</c> via <see cref="AzureSignToolSettings.TimestampDigest"/></li><li><c>--timestamp-rfc3161</c> via <see cref="AzureSignToolSettings.TimestampRfc3161Url"/></li><li><c>--verbose</c> via <see cref="AzureSignToolSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(AzureSignToolSettings Settings, IReadOnlyCollection<Output> Output)> AzureSignTool(CombinatorialConfigure<AzureSignToolSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(AzureSignTool, degreeOfParallelism, completeOnFailure);
}
#region AzureSignToolSettings
/// <summary>Used within <see cref="AzureSignToolTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<AzureSignToolSettings>))]
[Command(Type = typeof(AzureSignToolTasks), Command = nameof(AzureSignToolTasks.AzureSignTool), Arguments = "sign")]
public partial class AzureSignToolSettings : ToolOptions
{
    /// <summary>A fully qualified URL of the key vault with the certificate that will be used for signing. An example value might be <c>https://my-vault.vault.azure.net</c>.</summary>
    [Argument(Format = "--azure-key-vault-url {value}")] public string KeyVaultUrl => Get<string>(() => KeyVaultUrl);
    /// <summary>This is the client ID used to authenticate to Azure, which will be used to generate an access token. This parameter is not required if an access token is supplied directly with the <c>--azure-key-vault-accesstoken</c> option. If this parameter is supplied, <c>--azure-key-vault-client-secret</c> and <c>--azure-key-vault-tenant-id</c> must be supplied as well.</summary>
    [Argument(Format = "--azure-key-vault-client-id {value}")] public string KeyVaultClientId => Get<string>(() => KeyVaultClientId);
    /// <summary>This is the client secret used to authenticate to Azure, which will be used to generate an access token. This parameter is not required if an access token is supplied directly with the <c>--azure-key-vault-accesstoken</c> option or when using managed identities with <c>--azure-key-vault-managed-identity</c>. If this parameter is supplied, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-tenant-id</c> must be supplied as well.</summary>
    [Argument(Format = "--azure-key-vault-client-secret {value}", Secret = true)] public string KeyVaultClientSecret => Get<string>(() => KeyVaultClientSecret);
    /// <summary>This is the tenant id used to authenticate to Azure, which will be used to generate an access token. This parameter is not required if an access token is supplied directly with the <c>--azure-key-vault-accesstoken</c> option or when using managed identities with <c>--azure-key-vault-managed-identity</c>. If this parameter is supplied, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> must be supplied as well.</summary>
    [Argument(Format = "--azure-key-vault-tenant-id {value}")] public string KeyVaultTenantId => Get<string>(() => KeyVaultTenantId);
    /// <summary>The name of the certificate used to perform the signing operation.</summary>
    [Argument(Format = "--azure-key-vault-certificate {value}")] public string KeyVaultCertificateName => Get<string>(() => KeyVaultCertificateName);
    /// <summary>An access token used to authenticate to Azure. This can be used instead of the <c>--azure-key-vault-managed-identity</c>, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> options. This is useful if AzureSignTool is being used as part of another program that is already authenticated and has an access token to Azure.</summary>
    [Argument(Format = "--azure-key-vault-accesstoken {value}", Secret = true)] public string KeyVaultAccessToken => Get<string>(() => KeyVaultAccessToken);
    /// <summary>Use the ambient Managed Identity to authenticate to Azure. This can be used instead of the <c>--azure-key-vault-accesstoken</c>, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> options. This is useful if AzureSignTool is being used on a VM/service/CLI that is configured for managed identities to Azure.</summary>
    [Argument(Format = "--azure-key-vault-managed-identity")] public bool? KeyVaultManagedIdentity => Get<bool?>(() => KeyVaultManagedIdentity);
    /// <summary>A description of the signed content. This parameter serves the same purpose as the <c>/d</c> option in the Windows SDK <c>signtool</c>. If this parameter is not supplied, the signature will not contain a description.</summary>
    [Argument(Format = "--description {value}")] public string Description => Get<string>(() => Description);
    /// <summary>A URL with more information of the signed content. This parameter serves the same purpose as the <c>/du</c> option in the Windows SDK <c>signtool</c>. If this parameter is not supplied, the signature will not contain a URL description.</summary>
    [Argument(Format = "--description-url {value}")] public string DescriptionUrl => Get<string>(() => DescriptionUrl);
    /// <summary>A URL to an RFC3161 compliant timestamping service. This parameter serves the same purpose as the <c>/tr</c> option in the Windows SDK <c>signtool</c>. This parameter should be used in favor of the <c>--timestamp</c> option. Using this parameter will allow using modern, RFC3161 timestamps which also support timestamp digest algorithms other than SHA1.</summary>
    [Argument(Format = "--timestamp-rfc3161 {value}")] public string TimestampRfc3161Url => Get<string>(() => TimestampRfc3161Url);
    /// <summary>A URL to a legacy Authenticode timestamping service. This parameter serves the same purpose as the <c>/t</c> option in the Windows SDK <c>signtool</c>. Using a Authenicode timestamping service is deprecated. Instead, use the <c>--timestamp-rfc3161</c> option.</summary>
    [Argument(Format = "--timestamp-authenticode {value}")] public string TimestampAuthenticodeUrl => Get<string>(() => TimestampAuthenticodeUrl);
    /// <summary>The name of the digest algorithm used for timestamping. This parameter is ignored unless the <c>--timestamp-rfc3161</c> parameter is also supplied. The default value is <c>sha256</c>.</summary>
    [Argument(Format = "--timestamp-digest {value}")] public AzureSignToolDigestAlgorithm TimestampDigest => Get<AzureSignToolDigestAlgorithm>(() => TimestampDigest);
    /// <summary>The name of the digest algorithm used for hashing the file being signed. The default value is <c>sha256</c>.</summary>
    [Argument(Format = "--file-digest {value}")] public AzureSignToolDigestAlgorithm FileDigest => Get<AzureSignToolDigestAlgorithm>(() => FileDigest);
    /// <summary>A list of paths to additional certificates to aide in building a full chain for the signing certificate. Azure SignTool will build a chain, either as deep as it can or to a trusted root. This will also use the Windows certificate store, in addition to any certificates specified with this option. Specifying this option does not guarantee the inclusion of the certificate, only if it is part of the chain. The files specified must be public certificates only. They cannot be PFX, PKCS12 or PFX files.</summary>
    [Argument(Format = "--additional-certificates {value}")] public IReadOnlyList<string> AdditionalCertificates => Get<List<string>>(() => AdditionalCertificates);
    /// <summary>Include additional output in the log. This parameter does not accept a value and cannot be combine with the <c>--quiet</c> option.</summary>
    [Argument(Format = "--verbose")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Do not print output to the log. This parameter does not accept a value and cannot be combine with the <c>--verbose</c> option. The exit code of the process can be used to determine success or failure of the sign operation.</summary>
    [Argument(Format = "--quiet")] public bool? Quiet => Get<bool?>(() => Quiet);
    /// <summary>If multiple files to sign are specified, this flag will cause the signing process to move on to the next file when signing fails. This flag modifies the exit code of the program. See the <a href="https://github.com/vcsjones/AzureSignTool#exit-codes">Exit Codes section</a> for more information.</summary>
    [Argument(Format = "--continue-on-error")] public bool? ContinueOnError => Get<bool?>(() => ContinueOnError);
    /// <summary>Specifies a path to a text file which contains a list of files to sign, with one file per-line in the text file. If this parameter is specified, it is combined with files directly specified on the command line. The distinct result of the two options is signed.</summary>
    [Argument(Format = "--input-file-list {value}")] public string InputFileList => Get<string>(() => InputFileList);
    /// <summary>If a file is already signed it will be skipped, rather than replacing the existing signature.</summary>
    [Argument(Format = "--skip-signed")] public bool? SkipSigned => Get<bool?>(() => SkipSigned);
    /// <summary>Causes the Authenticode signing process to generate hashes of pages for verifying when the application is paged in to memory. If this flag is omitted, the default configuration for the operating system will be used. This flag will not affect non-PE file formats.</summary>
    [Argument(Format = "--page-hashing")] public bool? PageHashing => Get<bool?>(() => PageHashing);
    /// <summary>Causes the Authenticode signing process to exclude hashes of pages for verifying when the application is paged in to memory. If this flag is omitted, the default configuration for the operating system will be used. This flag will not affect non-PE file formats.</summary>
    [Argument(Format = "--no-page-hashing")] public bool? NoPageHashing => Get<bool?>(() => NoPageHashing);
    /// <summary>When signing multiple files, specifies the maximum number of concurrent operations. Setting this value does not guarentee that number of concurrent operations will be performed. If this value is unspecified, the system will use the default based on the number of available processor threads. Setting this value to <c>1</c> disable concurrent signing.</summary>
    [Argument(Format = "--max-degree-of-parallelism {value}")] public int? MaxDegreeOfParallelism => Get<int?>(() => MaxDegreeOfParallelism);
    /// <summary>Files to sign.</summary>
    [Argument(Format = "{value}", Position = -1)] public IReadOnlyList<string> Files => Get<List<string>>(() => Files);
}
#endregion
#region AzureSignToolSettingsExtensions
/// <summary>Used within <see cref="AzureSignToolTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class AzureSignToolSettingsExtensions
{
    #region KeyVaultUrl
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultUrl"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultUrl))]
    public static T SetKeyVaultUrl<T>(this T o, string v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultUrl, v));
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultUrl"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultUrl))]
    public static T ResetKeyVaultUrl<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.KeyVaultUrl));
    #endregion
    #region KeyVaultClientId
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultClientId"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultClientId))]
    public static T SetKeyVaultClientId<T>(this T o, string v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultClientId, v));
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultClientId"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultClientId))]
    public static T ResetKeyVaultClientId<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.KeyVaultClientId));
    #endregion
    #region KeyVaultClientSecret
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultClientSecret"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultClientSecret))]
    public static T SetKeyVaultClientSecret<T>(this T o, [Secret] string v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultClientSecret, v));
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultClientSecret"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultClientSecret))]
    public static T ResetKeyVaultClientSecret<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.KeyVaultClientSecret));
    #endregion
    #region KeyVaultTenantId
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultTenantId"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultTenantId))]
    public static T SetKeyVaultTenantId<T>(this T o, string v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultTenantId, v));
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultTenantId"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultTenantId))]
    public static T ResetKeyVaultTenantId<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.KeyVaultTenantId));
    #endregion
    #region KeyVaultCertificateName
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultCertificateName"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultCertificateName))]
    public static T SetKeyVaultCertificateName<T>(this T o, string v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultCertificateName, v));
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultCertificateName"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultCertificateName))]
    public static T ResetKeyVaultCertificateName<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.KeyVaultCertificateName));
    #endregion
    #region KeyVaultAccessToken
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultAccessToken"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultAccessToken))]
    public static T SetKeyVaultAccessToken<T>(this T o, [Secret] string v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultAccessToken, v));
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultAccessToken"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultAccessToken))]
    public static T ResetKeyVaultAccessToken<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.KeyVaultAccessToken));
    #endregion
    #region KeyVaultManagedIdentity
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultManagedIdentity"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultManagedIdentity))]
    public static T SetKeyVaultManagedIdentity<T>(this T o, bool? v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultManagedIdentity, v));
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultManagedIdentity"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultManagedIdentity))]
    public static T ResetKeyVaultManagedIdentity<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.KeyVaultManagedIdentity));
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultManagedIdentity"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultManagedIdentity))]
    public static T EnableKeyVaultManagedIdentity<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultManagedIdentity, true));
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultManagedIdentity"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultManagedIdentity))]
    public static T DisableKeyVaultManagedIdentity<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultManagedIdentity, false));
    /// <inheritdoc cref="AzureSignToolSettings.KeyVaultManagedIdentity"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.KeyVaultManagedIdentity))]
    public static T ToggleKeyVaultManagedIdentity<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.KeyVaultManagedIdentity, !o.KeyVaultManagedIdentity));
    #endregion
    #region Description
    /// <inheritdoc cref="AzureSignToolSettings.Description"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Description))]
    public static T SetDescription<T>(this T o, string v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.Description, v));
    /// <inheritdoc cref="AzureSignToolSettings.Description"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Description))]
    public static T ResetDescription<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.Description));
    #endregion
    #region DescriptionUrl
    /// <inheritdoc cref="AzureSignToolSettings.DescriptionUrl"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.DescriptionUrl))]
    public static T SetDescriptionUrl<T>(this T o, string v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.DescriptionUrl, v));
    /// <inheritdoc cref="AzureSignToolSettings.DescriptionUrl"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.DescriptionUrl))]
    public static T ResetDescriptionUrl<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.DescriptionUrl));
    #endregion
    #region TimestampRfc3161Url
    /// <inheritdoc cref="AzureSignToolSettings.TimestampRfc3161Url"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.TimestampRfc3161Url))]
    public static T SetTimestampRfc3161Url<T>(this T o, string v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.TimestampRfc3161Url, v));
    /// <inheritdoc cref="AzureSignToolSettings.TimestampRfc3161Url"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.TimestampRfc3161Url))]
    public static T ResetTimestampRfc3161Url<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.TimestampRfc3161Url));
    #endregion
    #region TimestampAuthenticodeUrl
    /// <inheritdoc cref="AzureSignToolSettings.TimestampAuthenticodeUrl"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.TimestampAuthenticodeUrl))]
    public static T SetTimestampAuthenticodeUrl<T>(this T o, string v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.TimestampAuthenticodeUrl, v));
    /// <inheritdoc cref="AzureSignToolSettings.TimestampAuthenticodeUrl"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.TimestampAuthenticodeUrl))]
    public static T ResetTimestampAuthenticodeUrl<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.TimestampAuthenticodeUrl));
    #endregion
    #region TimestampDigest
    /// <inheritdoc cref="AzureSignToolSettings.TimestampDigest"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.TimestampDigest))]
    public static T SetTimestampDigest<T>(this T o, AzureSignToolDigestAlgorithm v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.TimestampDigest, v));
    /// <inheritdoc cref="AzureSignToolSettings.TimestampDigest"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.TimestampDigest))]
    public static T ResetTimestampDigest<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.TimestampDigest));
    #endregion
    #region FileDigest
    /// <inheritdoc cref="AzureSignToolSettings.FileDigest"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.FileDigest))]
    public static T SetFileDigest<T>(this T o, AzureSignToolDigestAlgorithm v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.FileDigest, v));
    /// <inheritdoc cref="AzureSignToolSettings.FileDigest"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.FileDigest))]
    public static T ResetFileDigest<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.FileDigest));
    #endregion
    #region AdditionalCertificates
    /// <inheritdoc cref="AzureSignToolSettings.AdditionalCertificates"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.AdditionalCertificates))]
    public static T SetAdditionalCertificates<T>(this T o, params string[] v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.AdditionalCertificates, v));
    /// <inheritdoc cref="AzureSignToolSettings.AdditionalCertificates"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.AdditionalCertificates))]
    public static T SetAdditionalCertificates<T>(this T o, IEnumerable<string> v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.AdditionalCertificates, v));
    /// <inheritdoc cref="AzureSignToolSettings.AdditionalCertificates"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.AdditionalCertificates))]
    public static T AddAdditionalCertificates<T>(this T o, params string[] v) where T : AzureSignToolSettings => o.Modify(b => b.AddCollection(() => o.AdditionalCertificates, v));
    /// <inheritdoc cref="AzureSignToolSettings.AdditionalCertificates"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.AdditionalCertificates))]
    public static T AddAdditionalCertificates<T>(this T o, IEnumerable<string> v) where T : AzureSignToolSettings => o.Modify(b => b.AddCollection(() => o.AdditionalCertificates, v));
    /// <inheritdoc cref="AzureSignToolSettings.AdditionalCertificates"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.AdditionalCertificates))]
    public static T RemoveAdditionalCertificates<T>(this T o, params string[] v) where T : AzureSignToolSettings => o.Modify(b => b.RemoveCollection(() => o.AdditionalCertificates, v));
    /// <inheritdoc cref="AzureSignToolSettings.AdditionalCertificates"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.AdditionalCertificates))]
    public static T RemoveAdditionalCertificates<T>(this T o, IEnumerable<string> v) where T : AzureSignToolSettings => o.Modify(b => b.RemoveCollection(() => o.AdditionalCertificates, v));
    /// <inheritdoc cref="AzureSignToolSettings.AdditionalCertificates"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.AdditionalCertificates))]
    public static T ClearAdditionalCertificates<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.ClearCollection(() => o.AdditionalCertificates));
    #endregion
    #region Verbose
    /// <inheritdoc cref="AzureSignToolSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="AzureSignToolSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="AzureSignToolSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="AzureSignToolSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="AzureSignToolSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region Quiet
    /// <inheritdoc cref="AzureSignToolSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Quiet))]
    public static T SetQuiet<T>(this T o, bool? v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.Quiet, v));
    /// <inheritdoc cref="AzureSignToolSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Quiet))]
    public static T ResetQuiet<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.Quiet));
    /// <inheritdoc cref="AzureSignToolSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Quiet))]
    public static T EnableQuiet<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.Quiet, true));
    /// <inheritdoc cref="AzureSignToolSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Quiet))]
    public static T DisableQuiet<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.Quiet, false));
    /// <inheritdoc cref="AzureSignToolSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Quiet))]
    public static T ToggleQuiet<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.Quiet, !o.Quiet));
    #endregion
    #region ContinueOnError
    /// <inheritdoc cref="AzureSignToolSettings.ContinueOnError"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.ContinueOnError))]
    public static T SetContinueOnError<T>(this T o, bool? v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.ContinueOnError, v));
    /// <inheritdoc cref="AzureSignToolSettings.ContinueOnError"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.ContinueOnError))]
    public static T ResetContinueOnError<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.ContinueOnError));
    /// <inheritdoc cref="AzureSignToolSettings.ContinueOnError"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.ContinueOnError))]
    public static T EnableContinueOnError<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.ContinueOnError, true));
    /// <inheritdoc cref="AzureSignToolSettings.ContinueOnError"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.ContinueOnError))]
    public static T DisableContinueOnError<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.ContinueOnError, false));
    /// <inheritdoc cref="AzureSignToolSettings.ContinueOnError"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.ContinueOnError))]
    public static T ToggleContinueOnError<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.ContinueOnError, !o.ContinueOnError));
    #endregion
    #region InputFileList
    /// <inheritdoc cref="AzureSignToolSettings.InputFileList"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.InputFileList))]
    public static T SetInputFileList<T>(this T o, string v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.InputFileList, v));
    /// <inheritdoc cref="AzureSignToolSettings.InputFileList"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.InputFileList))]
    public static T ResetInputFileList<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.InputFileList));
    #endregion
    #region SkipSigned
    /// <inheritdoc cref="AzureSignToolSettings.SkipSigned"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.SkipSigned))]
    public static T SetSkipSigned<T>(this T o, bool? v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.SkipSigned, v));
    /// <inheritdoc cref="AzureSignToolSettings.SkipSigned"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.SkipSigned))]
    public static T ResetSkipSigned<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.SkipSigned));
    /// <inheritdoc cref="AzureSignToolSettings.SkipSigned"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.SkipSigned))]
    public static T EnableSkipSigned<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.SkipSigned, true));
    /// <inheritdoc cref="AzureSignToolSettings.SkipSigned"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.SkipSigned))]
    public static T DisableSkipSigned<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.SkipSigned, false));
    /// <inheritdoc cref="AzureSignToolSettings.SkipSigned"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.SkipSigned))]
    public static T ToggleSkipSigned<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.SkipSigned, !o.SkipSigned));
    #endregion
    #region PageHashing
    /// <inheritdoc cref="AzureSignToolSettings.PageHashing"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.PageHashing))]
    public static T SetPageHashing<T>(this T o, bool? v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.PageHashing, v));
    /// <inheritdoc cref="AzureSignToolSettings.PageHashing"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.PageHashing))]
    public static T ResetPageHashing<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.PageHashing));
    /// <inheritdoc cref="AzureSignToolSettings.PageHashing"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.PageHashing))]
    public static T EnablePageHashing<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.PageHashing, true));
    /// <inheritdoc cref="AzureSignToolSettings.PageHashing"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.PageHashing))]
    public static T DisablePageHashing<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.PageHashing, false));
    /// <inheritdoc cref="AzureSignToolSettings.PageHashing"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.PageHashing))]
    public static T TogglePageHashing<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.PageHashing, !o.PageHashing));
    #endregion
    #region NoPageHashing
    /// <inheritdoc cref="AzureSignToolSettings.NoPageHashing"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.NoPageHashing))]
    public static T SetNoPageHashing<T>(this T o, bool? v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.NoPageHashing, v));
    /// <inheritdoc cref="AzureSignToolSettings.NoPageHashing"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.NoPageHashing))]
    public static T ResetNoPageHashing<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.NoPageHashing));
    /// <inheritdoc cref="AzureSignToolSettings.NoPageHashing"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.NoPageHashing))]
    public static T EnableNoPageHashing<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.NoPageHashing, true));
    /// <inheritdoc cref="AzureSignToolSettings.NoPageHashing"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.NoPageHashing))]
    public static T DisableNoPageHashing<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.NoPageHashing, false));
    /// <inheritdoc cref="AzureSignToolSettings.NoPageHashing"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.NoPageHashing))]
    public static T ToggleNoPageHashing<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.NoPageHashing, !o.NoPageHashing));
    #endregion
    #region MaxDegreeOfParallelism
    /// <inheritdoc cref="AzureSignToolSettings.MaxDegreeOfParallelism"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.MaxDegreeOfParallelism))]
    public static T SetMaxDegreeOfParallelism<T>(this T o, int? v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.MaxDegreeOfParallelism, v));
    /// <inheritdoc cref="AzureSignToolSettings.MaxDegreeOfParallelism"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.MaxDegreeOfParallelism))]
    public static T ResetMaxDegreeOfParallelism<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.Remove(() => o.MaxDegreeOfParallelism));
    #endregion
    #region Files
    /// <inheritdoc cref="AzureSignToolSettings.Files"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Files))]
    public static T SetFiles<T>(this T o, params string[] v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.Files, v));
    /// <inheritdoc cref="AzureSignToolSettings.Files"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Files))]
    public static T SetFiles<T>(this T o, IEnumerable<string> v) where T : AzureSignToolSettings => o.Modify(b => b.Set(() => o.Files, v));
    /// <inheritdoc cref="AzureSignToolSettings.Files"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Files))]
    public static T AddFiles<T>(this T o, params string[] v) where T : AzureSignToolSettings => o.Modify(b => b.AddCollection(() => o.Files, v));
    /// <inheritdoc cref="AzureSignToolSettings.Files"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Files))]
    public static T AddFiles<T>(this T o, IEnumerable<string> v) where T : AzureSignToolSettings => o.Modify(b => b.AddCollection(() => o.Files, v));
    /// <inheritdoc cref="AzureSignToolSettings.Files"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Files))]
    public static T RemoveFiles<T>(this T o, params string[] v) where T : AzureSignToolSettings => o.Modify(b => b.RemoveCollection(() => o.Files, v));
    /// <inheritdoc cref="AzureSignToolSettings.Files"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Files))]
    public static T RemoveFiles<T>(this T o, IEnumerable<string> v) where T : AzureSignToolSettings => o.Modify(b => b.RemoveCollection(() => o.Files, v));
    /// <inheritdoc cref="AzureSignToolSettings.Files"/>
    [Pure] [Builder(Type = typeof(AzureSignToolSettings), Property = nameof(AzureSignToolSettings.Files))]
    public static T ClearFiles<T>(this T o) where T : AzureSignToolSettings => o.Modify(b => b.ClearCollection(() => o.Files));
    #endregion
}
#endregion
#region AzureSignToolDigestAlgorithm
/// <summary>Used within <see cref="AzureSignToolTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<AzureSignToolDigestAlgorithm>))]
public partial class AzureSignToolDigestAlgorithm : Enumeration
{
    public static AzureSignToolDigestAlgorithm sha1 = (AzureSignToolDigestAlgorithm) "sha1";
    public static AzureSignToolDigestAlgorithm sha256 = (AzureSignToolDigestAlgorithm) "sha256";
    public static AzureSignToolDigestAlgorithm sha384 = (AzureSignToolDigestAlgorithm) "sha384";
    public static AzureSignToolDigestAlgorithm sha512 = (AzureSignToolDigestAlgorithm) "sha512";
    public static implicit operator AzureSignToolDigestAlgorithm(string value)
    {
        return new AzureSignToolDigestAlgorithm { Value = value };
    }
}
#endregion
