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

namespace Nuke.Common.Tools.AzureSignTool
{
    /// <summary>
    ///   <p>Azure Sign Tool is similar to <c>signtool</c> in the Windows SDK, with the major difference being that it uses Azure Key Vault for performing the signing process. The usage is like <c>signtool</c>, except with a limited set of options for signing and options for authenticating to Azure Key Vault.</p>
    ///   <p>For more details, visit the <a href="https://github.com/vcsjones/AzureSignTool">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(AzureSignToolPackageId)]
    public partial class AzureSignToolTasks
        : IRequireNuGetPackage
    {
        public const string AzureSignToolPackageId = "AzureSignTool";
        /// <summary>
        ///   Path to the AzureSignTool executable.
        /// </summary>
        public static string AzureSignToolPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("AZURESIGNTOOL_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("AzureSignTool", "AzureSignTool.dll");
        public static Action<OutputType, string> AzureSignToolLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Azure Sign Tool is similar to <c>signtool</c> in the Windows SDK, with the major difference being that it uses Azure Key Vault for performing the signing process. The usage is like <c>signtool</c>, except with a limited set of options for signing and options for authenticating to Azure Key Vault.</p>
        ///   <p>For more details, visit the <a href="https://github.com/vcsjones/AzureSignTool">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> AzureSignTool(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(AzureSignToolPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? AzureSignToolLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Azure Sign Tool is similar to <c>signtool</c> in the Windows SDK, with the major difference being that it uses Azure Key Vault for performing the signing process. The usage is like <c>signtool</c>, except with a limited set of options for signing and options for authenticating to Azure Key Vault.</p>
        ///   <p>For more details, visit the <a href="https://github.com/vcsjones/AzureSignTool">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;files&gt;</c> via <see cref="AzureSignToolSettings.Files"/></li>
        ///     <li><c>--additional-certificates</c> via <see cref="AzureSignToolSettings.AdditionalCertificates"/></li>
        ///     <li><c>--azure-key-vault-accesstoken</c> via <see cref="AzureSignToolSettings.KeyVaultAccessToken"/></li>
        ///     <li><c>--azure-key-vault-certificate</c> via <see cref="AzureSignToolSettings.KeyVaultCertificateName"/></li>
        ///     <li><c>--azure-key-vault-client-id</c> via <see cref="AzureSignToolSettings.KeyVaultClientId"/></li>
        ///     <li><c>--azure-key-vault-client-secret</c> via <see cref="AzureSignToolSettings.KeyVaultClientSecret"/></li>
        ///     <li><c>--azure-key-vault-managed-identity</c> via <see cref="AzureSignToolSettings.KeyVaultManagedIdentity"/></li>
        ///     <li><c>--azure-key-vault-tenant-id</c> via <see cref="AzureSignToolSettings.KeyVaultTenantId"/></li>
        ///     <li><c>--azure-key-vault-url</c> via <see cref="AzureSignToolSettings.KeyVaultUrl"/></li>
        ///     <li><c>--continue-on-error</c> via <see cref="AzureSignToolSettings.ContinueOnError"/></li>
        ///     <li><c>--description</c> via <see cref="AzureSignToolSettings.Description"/></li>
        ///     <li><c>--description-url</c> via <see cref="AzureSignToolSettings.DescriptionUrl"/></li>
        ///     <li><c>--file-digest</c> via <see cref="AzureSignToolSettings.FileDigest"/></li>
        ///     <li><c>--input-file-list</c> via <see cref="AzureSignToolSettings.InputFileList"/></li>
        ///     <li><c>--max-degree-of-parallelism</c> via <see cref="AzureSignToolSettings.MaxDegreeOfParallelism"/></li>
        ///     <li><c>--no-page-hashing</c> via <see cref="AzureSignToolSettings.NoPageHashing"/></li>
        ///     <li><c>--page-hashing</c> via <see cref="AzureSignToolSettings.PageHashing"/></li>
        ///     <li><c>--quiet</c> via <see cref="AzureSignToolSettings.Quiet"/></li>
        ///     <li><c>--skip-signed</c> via <see cref="AzureSignToolSettings.SkipSigned"/></li>
        ///     <li><c>--timestamp-authenticode</c> via <see cref="AzureSignToolSettings.TimestampAuthenticodeUrl"/></li>
        ///     <li><c>--timestamp-digest</c> via <see cref="AzureSignToolSettings.TimestampDigest"/></li>
        ///     <li><c>--timestamp-rfc3161</c> via <see cref="AzureSignToolSettings.TimestampRfc3161Url"/></li>
        ///     <li><c>--verbose</c> via <see cref="AzureSignToolSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> AzureSignTool(AzureSignToolSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new AzureSignToolSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Azure Sign Tool is similar to <c>signtool</c> in the Windows SDK, with the major difference being that it uses Azure Key Vault for performing the signing process. The usage is like <c>signtool</c>, except with a limited set of options for signing and options for authenticating to Azure Key Vault.</p>
        ///   <p>For more details, visit the <a href="https://github.com/vcsjones/AzureSignTool">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;files&gt;</c> via <see cref="AzureSignToolSettings.Files"/></li>
        ///     <li><c>--additional-certificates</c> via <see cref="AzureSignToolSettings.AdditionalCertificates"/></li>
        ///     <li><c>--azure-key-vault-accesstoken</c> via <see cref="AzureSignToolSettings.KeyVaultAccessToken"/></li>
        ///     <li><c>--azure-key-vault-certificate</c> via <see cref="AzureSignToolSettings.KeyVaultCertificateName"/></li>
        ///     <li><c>--azure-key-vault-client-id</c> via <see cref="AzureSignToolSettings.KeyVaultClientId"/></li>
        ///     <li><c>--azure-key-vault-client-secret</c> via <see cref="AzureSignToolSettings.KeyVaultClientSecret"/></li>
        ///     <li><c>--azure-key-vault-managed-identity</c> via <see cref="AzureSignToolSettings.KeyVaultManagedIdentity"/></li>
        ///     <li><c>--azure-key-vault-tenant-id</c> via <see cref="AzureSignToolSettings.KeyVaultTenantId"/></li>
        ///     <li><c>--azure-key-vault-url</c> via <see cref="AzureSignToolSettings.KeyVaultUrl"/></li>
        ///     <li><c>--continue-on-error</c> via <see cref="AzureSignToolSettings.ContinueOnError"/></li>
        ///     <li><c>--description</c> via <see cref="AzureSignToolSettings.Description"/></li>
        ///     <li><c>--description-url</c> via <see cref="AzureSignToolSettings.DescriptionUrl"/></li>
        ///     <li><c>--file-digest</c> via <see cref="AzureSignToolSettings.FileDigest"/></li>
        ///     <li><c>--input-file-list</c> via <see cref="AzureSignToolSettings.InputFileList"/></li>
        ///     <li><c>--max-degree-of-parallelism</c> via <see cref="AzureSignToolSettings.MaxDegreeOfParallelism"/></li>
        ///     <li><c>--no-page-hashing</c> via <see cref="AzureSignToolSettings.NoPageHashing"/></li>
        ///     <li><c>--page-hashing</c> via <see cref="AzureSignToolSettings.PageHashing"/></li>
        ///     <li><c>--quiet</c> via <see cref="AzureSignToolSettings.Quiet"/></li>
        ///     <li><c>--skip-signed</c> via <see cref="AzureSignToolSettings.SkipSigned"/></li>
        ///     <li><c>--timestamp-authenticode</c> via <see cref="AzureSignToolSettings.TimestampAuthenticodeUrl"/></li>
        ///     <li><c>--timestamp-digest</c> via <see cref="AzureSignToolSettings.TimestampDigest"/></li>
        ///     <li><c>--timestamp-rfc3161</c> via <see cref="AzureSignToolSettings.TimestampRfc3161Url"/></li>
        ///     <li><c>--verbose</c> via <see cref="AzureSignToolSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> AzureSignTool(Configure<AzureSignToolSettings> configurator)
        {
            return AzureSignTool(configurator(new AzureSignToolSettings()));
        }
        /// <summary>
        ///   <p>Azure Sign Tool is similar to <c>signtool</c> in the Windows SDK, with the major difference being that it uses Azure Key Vault for performing the signing process. The usage is like <c>signtool</c>, except with a limited set of options for signing and options for authenticating to Azure Key Vault.</p>
        ///   <p>For more details, visit the <a href="https://github.com/vcsjones/AzureSignTool">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;files&gt;</c> via <see cref="AzureSignToolSettings.Files"/></li>
        ///     <li><c>--additional-certificates</c> via <see cref="AzureSignToolSettings.AdditionalCertificates"/></li>
        ///     <li><c>--azure-key-vault-accesstoken</c> via <see cref="AzureSignToolSettings.KeyVaultAccessToken"/></li>
        ///     <li><c>--azure-key-vault-certificate</c> via <see cref="AzureSignToolSettings.KeyVaultCertificateName"/></li>
        ///     <li><c>--azure-key-vault-client-id</c> via <see cref="AzureSignToolSettings.KeyVaultClientId"/></li>
        ///     <li><c>--azure-key-vault-client-secret</c> via <see cref="AzureSignToolSettings.KeyVaultClientSecret"/></li>
        ///     <li><c>--azure-key-vault-managed-identity</c> via <see cref="AzureSignToolSettings.KeyVaultManagedIdentity"/></li>
        ///     <li><c>--azure-key-vault-tenant-id</c> via <see cref="AzureSignToolSettings.KeyVaultTenantId"/></li>
        ///     <li><c>--azure-key-vault-url</c> via <see cref="AzureSignToolSettings.KeyVaultUrl"/></li>
        ///     <li><c>--continue-on-error</c> via <see cref="AzureSignToolSettings.ContinueOnError"/></li>
        ///     <li><c>--description</c> via <see cref="AzureSignToolSettings.Description"/></li>
        ///     <li><c>--description-url</c> via <see cref="AzureSignToolSettings.DescriptionUrl"/></li>
        ///     <li><c>--file-digest</c> via <see cref="AzureSignToolSettings.FileDigest"/></li>
        ///     <li><c>--input-file-list</c> via <see cref="AzureSignToolSettings.InputFileList"/></li>
        ///     <li><c>--max-degree-of-parallelism</c> via <see cref="AzureSignToolSettings.MaxDegreeOfParallelism"/></li>
        ///     <li><c>--no-page-hashing</c> via <see cref="AzureSignToolSettings.NoPageHashing"/></li>
        ///     <li><c>--page-hashing</c> via <see cref="AzureSignToolSettings.PageHashing"/></li>
        ///     <li><c>--quiet</c> via <see cref="AzureSignToolSettings.Quiet"/></li>
        ///     <li><c>--skip-signed</c> via <see cref="AzureSignToolSettings.SkipSigned"/></li>
        ///     <li><c>--timestamp-authenticode</c> via <see cref="AzureSignToolSettings.TimestampAuthenticodeUrl"/></li>
        ///     <li><c>--timestamp-digest</c> via <see cref="AzureSignToolSettings.TimestampDigest"/></li>
        ///     <li><c>--timestamp-rfc3161</c> via <see cref="AzureSignToolSettings.TimestampRfc3161Url"/></li>
        ///     <li><c>--verbose</c> via <see cref="AzureSignToolSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(AzureSignToolSettings Settings, IReadOnlyCollection<Output> Output)> AzureSignTool(CombinatorialConfigure<AzureSignToolSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(AzureSignTool, AzureSignToolLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region AzureSignToolSettings
    /// <summary>
    ///   Used within <see cref="AzureSignToolTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class AzureSignToolSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the AzureSignTool executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? AzureSignToolTasks.AzureSignToolPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? AzureSignToolTasks.AzureSignToolLogger;
        /// <summary>
        ///   A fully qualified URL of the key vault with the certificate that will be used for signing. An example value might be <c>https://my-vault.vault.azure.net</c>.
        /// </summary>
        public virtual string KeyVaultUrl { get; internal set; }
        /// <summary>
        ///   This is the client ID used to authenticate to Azure, which will be used to generate an access token. This parameter is not required if an access token is supplied directly with the <c>--azure-key-vault-accesstoken</c> option. If this parameter is supplied, <c>--azure-key-vault-client-secret</c> and <c>--azure-key-vault-tenant-id</c> must be supplied as well.
        /// </summary>
        public virtual string KeyVaultClientId { get; internal set; }
        /// <summary>
        ///   This is the client secret used to authenticate to Azure, which will be used to generate an access token. This parameter is not required if an access token is supplied directly with the <c>--azure-key-vault-accesstoken</c> option or when using managed identities with <c>--azure-key-vault-managed-identity</c>. If this parameter is supplied, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-tenant-id</c> must be supplied as well.
        /// </summary>
        public virtual string KeyVaultClientSecret { get; internal set; }
        /// <summary>
        ///   This is the tenant id used to authenticate to Azure, which will be used to generate an access token. This parameter is not required if an access token is supplied directly with the <c>--azure-key-vault-accesstoken</c> option or when using managed identities with <c>--azure-key-vault-managed-identity</c>. If this parameter is supplied, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> must be supplied as well.
        /// </summary>
        public virtual string KeyVaultTenantId { get; internal set; }
        /// <summary>
        ///   The name of the certificate used to perform the signing operation.
        /// </summary>
        public virtual string KeyVaultCertificateName { get; internal set; }
        /// <summary>
        ///   An access token used to authenticate to Azure. This can be used instead of the <c>--azure-key-vault-managed-identity</c>, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> options. This is useful if AzureSignTool is being used as part of another program that is already authenticated and has an access token to Azure.
        /// </summary>
        public virtual string KeyVaultAccessToken { get; internal set; }
        /// <summary>
        ///   Use the ambient Managed Identity to authenticate to Azure. This can be used instead of the <c>--azure-key-vault-accesstoken</c>, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> options. This is useful if AzureSignTool is being used on a VM/service/CLI that is configured for managed identities to Azure.
        /// </summary>
        public virtual bool? KeyVaultManagedIdentity { get; internal set; }
        /// <summary>
        ///   A description of the signed content. This parameter serves the same purpose as the <c>/d</c> option in the Windows SDK <c>signtool</c>. If this parameter is not supplied, the signature will not contain a description.
        /// </summary>
        public virtual string Description { get; internal set; }
        /// <summary>
        ///   A URL with more information of the signed content. This parameter serves the same purpose as the <c>/du</c> option in the Windows SDK <c>signtool</c>. If this parameter is not supplied, the signature will not contain a URL description.
        /// </summary>
        public virtual string DescriptionUrl { get; internal set; }
        /// <summary>
        ///   A URL to an RFC3161 compliant timestamping service. This parameter serves the same purpose as the <c>/tr</c> option in the Windows SDK <c>signtool</c>. This parameter should be used in favor of the <c>--timestamp</c> option. Using this parameter will allow using modern, RFC3161 timestamps which also support timestamp digest algorithms other than SHA1.
        /// </summary>
        public virtual string TimestampRfc3161Url { get; internal set; }
        /// <summary>
        ///   A URL to a legacy Authenticode timestamping service. This parameter serves the same purpose as the <c>/t</c> option in the Windows SDK <c>signtool</c>. Using a Authenicode timestamping service is deprecated. Instead, use the <c>--timestamp-rfc3161</c> option.
        /// </summary>
        public virtual string TimestampAuthenticodeUrl { get; internal set; }
        /// <summary>
        ///   The name of the digest algorithm used for timestamping. This parameter is ignored unless the <c>--timestamp-rfc3161</c> parameter is also supplied. The default value is <c>sha256</c>.
        /// </summary>
        public virtual AzureSignToolDigestAlgorithm TimestampDigest { get; internal set; }
        /// <summary>
        ///   The name of the digest algorithm used for hashing the file being signed. The default value is <c>sha256</c>.
        /// </summary>
        public virtual AzureSignToolDigestAlgorithm FileDigest { get; internal set; }
        /// <summary>
        ///   A list of paths to additional certificates to aide in building a full chain for the signing certificate. Azure SignTool will build a chain, either as deep as it can or to a trusted root. This will also use the Windows certificate store, in addition to any certificates specified with this option. Specifying this option does not guarantee the inclusion of the certificate, only if it is part of the chain. The files specified must be public certificates only. They cannot be PFX, PKCS12 or PFX files.
        /// </summary>
        public virtual IReadOnlyList<string> AdditionalCertificates => AdditionalCertificatesInternal.AsReadOnly();
        internal List<string> AdditionalCertificatesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Include additional output in the log. This parameter does not accept a value and cannot be combine with the <c>--quiet</c> option.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Do not print output to the log. This parameter does not accept a value and cannot be combine with the <c>--verbose</c> option. The exit code of the process can be used to determine success or failure of the sign operation.
        /// </summary>
        public virtual bool? Quiet { get; internal set; }
        /// <summary>
        ///   If multiple files to sign are specified, this flag will cause the signing process to move on to the next file when signing fails. This flag modifies the exit code of the program. See the <a href="https://github.com/vcsjones/AzureSignTool#exit-codes">Exit Codes section</a> for more information.
        /// </summary>
        public virtual bool? ContinueOnError { get; internal set; }
        /// <summary>
        ///   Specifies a path to a text file which contains a list of files to sign, with one file per-line in the text file. If this parameter is specified, it is combined with files directly specified on the command line. The distinct result of the two options is signed.
        /// </summary>
        public virtual string InputFileList { get; internal set; }
        /// <summary>
        ///   If a file is already signed it will be skipped, rather than replacing the existing signature.
        /// </summary>
        public virtual bool? SkipSigned { get; internal set; }
        /// <summary>
        ///   Causes the Authenticode signing process to generate hashes of pages for verifying when the application is paged in to memory. If this flag is omitted, the default configuration for the operating system will be used. This flag will not affect non-PE file formats.
        /// </summary>
        public virtual bool? PageHashing { get; internal set; }
        /// <summary>
        ///   Causes the Authenticode signing process to exclude hashes of pages for verifying when the application is paged in to memory. If this flag is omitted, the default configuration for the operating system will be used. This flag will not affect non-PE file formats.
        /// </summary>
        public virtual bool? NoPageHashing { get; internal set; }
        /// <summary>
        ///   When signing multiple files, specifies the maximum number of concurrent operations. Setting this value does not guarentee that number of concurrent operations will be performed. If this value is unspecified, the system will use the default based on the number of available processor threads. Setting this value to <c>1</c> disable concurrent signing.
        /// </summary>
        public virtual int? MaxDegreeOfParallelism { get; internal set; }
        /// <summary>
        ///   Files to sign.
        /// </summary>
        public virtual IReadOnlyList<string> Files => FilesInternal.AsReadOnly();
        internal List<string> FilesInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("sign")
              .Add("--azure-key-vault-url {value}", KeyVaultUrl)
              .Add("--azure-key-vault-client-id {value}", KeyVaultClientId)
              .Add("--azure-key-vault-client-secret {value}", KeyVaultClientSecret, secret: true)
              .Add("--azure-key-vault-tenant-id {value}", KeyVaultTenantId)
              .Add("--azure-key-vault-certificate {value}", KeyVaultCertificateName)
              .Add("--azure-key-vault-accesstoken {value}", KeyVaultAccessToken, secret: true)
              .Add("--azure-key-vault-managed-identity", KeyVaultManagedIdentity)
              .Add("--description {value}", Description)
              .Add("--description-url {value}", DescriptionUrl)
              .Add("--timestamp-rfc3161 {value}", TimestampRfc3161Url)
              .Add("--timestamp-authenticode {value}", TimestampAuthenticodeUrl)
              .Add("--timestamp-digest {value}", TimestampDigest)
              .Add("--file-digest {value}", FileDigest)
              .Add("--additional-certificates {value}", AdditionalCertificates)
              .Add("--verbose", Verbose)
              .Add("--quiet", Quiet)
              .Add("--continue-on-error", ContinueOnError)
              .Add("--input-file-list {value}", InputFileList)
              .Add("--skip-signed", SkipSigned)
              .Add("--page-hashing", PageHashing)
              .Add("--no-page-hashing", NoPageHashing)
              .Add("--max-degree-of-parallelism {value}", MaxDegreeOfParallelism)
              .Add("{value}", Files);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region AzureSignToolSettingsExtensions
    /// <summary>
    ///   Used within <see cref="AzureSignToolTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class AzureSignToolSettingsExtensions
    {
        #region KeyVaultUrl
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.KeyVaultUrl"/></em></p>
        ///   <p>A fully qualified URL of the key vault with the certificate that will be used for signing. An example value might be <c>https://my-vault.vault.azure.net</c>.</p>
        /// </summary>
        [Pure]
        public static T SetKeyVaultUrl<T>(this T toolSettings, string keyVaultUrl) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultUrl = keyVaultUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.KeyVaultUrl"/></em></p>
        ///   <p>A fully qualified URL of the key vault with the certificate that will be used for signing. An example value might be <c>https://my-vault.vault.azure.net</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyVaultUrl<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultUrl = null;
            return toolSettings;
        }
        #endregion
        #region KeyVaultClientId
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.KeyVaultClientId"/></em></p>
        ///   <p>This is the client ID used to authenticate to Azure, which will be used to generate an access token. This parameter is not required if an access token is supplied directly with the <c>--azure-key-vault-accesstoken</c> option. If this parameter is supplied, <c>--azure-key-vault-client-secret</c> and <c>--azure-key-vault-tenant-id</c> must be supplied as well.</p>
        /// </summary>
        [Pure]
        public static T SetKeyVaultClientId<T>(this T toolSettings, string keyVaultClientId) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultClientId = keyVaultClientId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.KeyVaultClientId"/></em></p>
        ///   <p>This is the client ID used to authenticate to Azure, which will be used to generate an access token. This parameter is not required if an access token is supplied directly with the <c>--azure-key-vault-accesstoken</c> option. If this parameter is supplied, <c>--azure-key-vault-client-secret</c> and <c>--azure-key-vault-tenant-id</c> must be supplied as well.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyVaultClientId<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultClientId = null;
            return toolSettings;
        }
        #endregion
        #region KeyVaultClientSecret
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.KeyVaultClientSecret"/></em></p>
        ///   <p>This is the client secret used to authenticate to Azure, which will be used to generate an access token. This parameter is not required if an access token is supplied directly with the <c>--azure-key-vault-accesstoken</c> option or when using managed identities with <c>--azure-key-vault-managed-identity</c>. If this parameter is supplied, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-tenant-id</c> must be supplied as well.</p>
        /// </summary>
        [Pure]
        public static T SetKeyVaultClientSecret<T>(this T toolSettings, [Secret] string keyVaultClientSecret) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultClientSecret = keyVaultClientSecret;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.KeyVaultClientSecret"/></em></p>
        ///   <p>This is the client secret used to authenticate to Azure, which will be used to generate an access token. This parameter is not required if an access token is supplied directly with the <c>--azure-key-vault-accesstoken</c> option or when using managed identities with <c>--azure-key-vault-managed-identity</c>. If this parameter is supplied, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-tenant-id</c> must be supplied as well.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyVaultClientSecret<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultClientSecret = null;
            return toolSettings;
        }
        #endregion
        #region KeyVaultTenantId
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.KeyVaultTenantId"/></em></p>
        ///   <p>This is the tenant id used to authenticate to Azure, which will be used to generate an access token. This parameter is not required if an access token is supplied directly with the <c>--azure-key-vault-accesstoken</c> option or when using managed identities with <c>--azure-key-vault-managed-identity</c>. If this parameter is supplied, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> must be supplied as well.</p>
        /// </summary>
        [Pure]
        public static T SetKeyVaultTenantId<T>(this T toolSettings, string keyVaultTenantId) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultTenantId = keyVaultTenantId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.KeyVaultTenantId"/></em></p>
        ///   <p>This is the tenant id used to authenticate to Azure, which will be used to generate an access token. This parameter is not required if an access token is supplied directly with the <c>--azure-key-vault-accesstoken</c> option or when using managed identities with <c>--azure-key-vault-managed-identity</c>. If this parameter is supplied, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> must be supplied as well.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyVaultTenantId<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultTenantId = null;
            return toolSettings;
        }
        #endregion
        #region KeyVaultCertificateName
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.KeyVaultCertificateName"/></em></p>
        ///   <p>The name of the certificate used to perform the signing operation.</p>
        /// </summary>
        [Pure]
        public static T SetKeyVaultCertificateName<T>(this T toolSettings, string keyVaultCertificateName) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultCertificateName = keyVaultCertificateName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.KeyVaultCertificateName"/></em></p>
        ///   <p>The name of the certificate used to perform the signing operation.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyVaultCertificateName<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultCertificateName = null;
            return toolSettings;
        }
        #endregion
        #region KeyVaultAccessToken
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.KeyVaultAccessToken"/></em></p>
        ///   <p>An access token used to authenticate to Azure. This can be used instead of the <c>--azure-key-vault-managed-identity</c>, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> options. This is useful if AzureSignTool is being used as part of another program that is already authenticated and has an access token to Azure.</p>
        /// </summary>
        [Pure]
        public static T SetKeyVaultAccessToken<T>(this T toolSettings, [Secret] string keyVaultAccessToken) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultAccessToken = keyVaultAccessToken;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.KeyVaultAccessToken"/></em></p>
        ///   <p>An access token used to authenticate to Azure. This can be used instead of the <c>--azure-key-vault-managed-identity</c>, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> options. This is useful if AzureSignTool is being used as part of another program that is already authenticated and has an access token to Azure.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyVaultAccessToken<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultAccessToken = null;
            return toolSettings;
        }
        #endregion
        #region KeyVaultManagedIdentity
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.KeyVaultManagedIdentity"/></em></p>
        ///   <p>Use the ambient Managed Identity to authenticate to Azure. This can be used instead of the <c>--azure-key-vault-accesstoken</c>, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> options. This is useful if AzureSignTool is being used on a VM/service/CLI that is configured for managed identities to Azure.</p>
        /// </summary>
        [Pure]
        public static T SetKeyVaultManagedIdentity<T>(this T toolSettings, bool? keyVaultManagedIdentity) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultManagedIdentity = keyVaultManagedIdentity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.KeyVaultManagedIdentity"/></em></p>
        ///   <p>Use the ambient Managed Identity to authenticate to Azure. This can be used instead of the <c>--azure-key-vault-accesstoken</c>, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> options. This is useful if AzureSignTool is being used on a VM/service/CLI that is configured for managed identities to Azure.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyVaultManagedIdentity<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultManagedIdentity = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="AzureSignToolSettings.KeyVaultManagedIdentity"/></em></p>
        ///   <p>Use the ambient Managed Identity to authenticate to Azure. This can be used instead of the <c>--azure-key-vault-accesstoken</c>, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> options. This is useful if AzureSignTool is being used on a VM/service/CLI that is configured for managed identities to Azure.</p>
        /// </summary>
        [Pure]
        public static T EnableKeyVaultManagedIdentity<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultManagedIdentity = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="AzureSignToolSettings.KeyVaultManagedIdentity"/></em></p>
        ///   <p>Use the ambient Managed Identity to authenticate to Azure. This can be used instead of the <c>--azure-key-vault-accesstoken</c>, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> options. This is useful if AzureSignTool is being used on a VM/service/CLI that is configured for managed identities to Azure.</p>
        /// </summary>
        [Pure]
        public static T DisableKeyVaultManagedIdentity<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultManagedIdentity = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="AzureSignToolSettings.KeyVaultManagedIdentity"/></em></p>
        ///   <p>Use the ambient Managed Identity to authenticate to Azure. This can be used instead of the <c>--azure-key-vault-accesstoken</c>, <c>--azure-key-vault-client-id</c> and <c>--azure-key-vault-client-secret</c> options. This is useful if AzureSignTool is being used on a VM/service/CLI that is configured for managed identities to Azure.</p>
        /// </summary>
        [Pure]
        public static T ToggleKeyVaultManagedIdentity<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyVaultManagedIdentity = !toolSettings.KeyVaultManagedIdentity;
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.Description"/></em></p>
        ///   <p>A description of the signed content. This parameter serves the same purpose as the <c>/d</c> option in the Windows SDK <c>signtool</c>. If this parameter is not supplied, the signature will not contain a description.</p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.Description"/></em></p>
        ///   <p>A description of the signed content. This parameter serves the same purpose as the <c>/d</c> option in the Windows SDK <c>signtool</c>. If this parameter is not supplied, the signature will not contain a description.</p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = null;
            return toolSettings;
        }
        #endregion
        #region DescriptionUrl
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.DescriptionUrl"/></em></p>
        ///   <p>A URL with more information of the signed content. This parameter serves the same purpose as the <c>/du</c> option in the Windows SDK <c>signtool</c>. If this parameter is not supplied, the signature will not contain a URL description.</p>
        /// </summary>
        [Pure]
        public static T SetDescriptionUrl<T>(this T toolSettings, string descriptionUrl) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DescriptionUrl = descriptionUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.DescriptionUrl"/></em></p>
        ///   <p>A URL with more information of the signed content. This parameter serves the same purpose as the <c>/du</c> option in the Windows SDK <c>signtool</c>. If this parameter is not supplied, the signature will not contain a URL description.</p>
        /// </summary>
        [Pure]
        public static T ResetDescriptionUrl<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DescriptionUrl = null;
            return toolSettings;
        }
        #endregion
        #region TimestampRfc3161Url
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.TimestampRfc3161Url"/></em></p>
        ///   <p>A URL to an RFC3161 compliant timestamping service. This parameter serves the same purpose as the <c>/tr</c> option in the Windows SDK <c>signtool</c>. This parameter should be used in favor of the <c>--timestamp</c> option. Using this parameter will allow using modern, RFC3161 timestamps which also support timestamp digest algorithms other than SHA1.</p>
        /// </summary>
        [Pure]
        public static T SetTimestampRfc3161Url<T>(this T toolSettings, string timestampRfc3161Url) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimestampRfc3161Url = timestampRfc3161Url;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.TimestampRfc3161Url"/></em></p>
        ///   <p>A URL to an RFC3161 compliant timestamping service. This parameter serves the same purpose as the <c>/tr</c> option in the Windows SDK <c>signtool</c>. This parameter should be used in favor of the <c>--timestamp</c> option. Using this parameter will allow using modern, RFC3161 timestamps which also support timestamp digest algorithms other than SHA1.</p>
        /// </summary>
        [Pure]
        public static T ResetTimestampRfc3161Url<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimestampRfc3161Url = null;
            return toolSettings;
        }
        #endregion
        #region TimestampAuthenticodeUrl
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.TimestampAuthenticodeUrl"/></em></p>
        ///   <p>A URL to a legacy Authenticode timestamping service. This parameter serves the same purpose as the <c>/t</c> option in the Windows SDK <c>signtool</c>. Using a Authenicode timestamping service is deprecated. Instead, use the <c>--timestamp-rfc3161</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetTimestampAuthenticodeUrl<T>(this T toolSettings, string timestampAuthenticodeUrl) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimestampAuthenticodeUrl = timestampAuthenticodeUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.TimestampAuthenticodeUrl"/></em></p>
        ///   <p>A URL to a legacy Authenticode timestamping service. This parameter serves the same purpose as the <c>/t</c> option in the Windows SDK <c>signtool</c>. Using a Authenicode timestamping service is deprecated. Instead, use the <c>--timestamp-rfc3161</c> option.</p>
        /// </summary>
        [Pure]
        public static T ResetTimestampAuthenticodeUrl<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimestampAuthenticodeUrl = null;
            return toolSettings;
        }
        #endregion
        #region TimestampDigest
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.TimestampDigest"/></em></p>
        ///   <p>The name of the digest algorithm used for timestamping. This parameter is ignored unless the <c>--timestamp-rfc3161</c> parameter is also supplied. The default value is <c>sha256</c>.</p>
        /// </summary>
        [Pure]
        public static T SetTimestampDigest<T>(this T toolSettings, AzureSignToolDigestAlgorithm timestampDigest) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimestampDigest = timestampDigest;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.TimestampDigest"/></em></p>
        ///   <p>The name of the digest algorithm used for timestamping. This parameter is ignored unless the <c>--timestamp-rfc3161</c> parameter is also supplied. The default value is <c>sha256</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetTimestampDigest<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimestampDigest = null;
            return toolSettings;
        }
        #endregion
        #region FileDigest
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.FileDigest"/></em></p>
        ///   <p>The name of the digest algorithm used for hashing the file being signed. The default value is <c>sha256</c>.</p>
        /// </summary>
        [Pure]
        public static T SetFileDigest<T>(this T toolSettings, AzureSignToolDigestAlgorithm fileDigest) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileDigest = fileDigest;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.FileDigest"/></em></p>
        ///   <p>The name of the digest algorithm used for hashing the file being signed. The default value is <c>sha256</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetFileDigest<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileDigest = null;
            return toolSettings;
        }
        #endregion
        #region AdditionalCertificates
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.AdditionalCertificates"/> to a new list</em></p>
        ///   <p>A list of paths to additional certificates to aide in building a full chain for the signing certificate. Azure SignTool will build a chain, either as deep as it can or to a trusted root. This will also use the Windows certificate store, in addition to any certificates specified with this option. Specifying this option does not guarantee the inclusion of the certificate, only if it is part of the chain. The files specified must be public certificates only. They cannot be PFX, PKCS12 or PFX files.</p>
        /// </summary>
        [Pure]
        public static T SetAdditionalCertificates<T>(this T toolSettings, params string[] additionalCertificates) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalCertificatesInternal = additionalCertificates.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.AdditionalCertificates"/> to a new list</em></p>
        ///   <p>A list of paths to additional certificates to aide in building a full chain for the signing certificate. Azure SignTool will build a chain, either as deep as it can or to a trusted root. This will also use the Windows certificate store, in addition to any certificates specified with this option. Specifying this option does not guarantee the inclusion of the certificate, only if it is part of the chain. The files specified must be public certificates only. They cannot be PFX, PKCS12 or PFX files.</p>
        /// </summary>
        [Pure]
        public static T SetAdditionalCertificates<T>(this T toolSettings, IEnumerable<string> additionalCertificates) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalCertificatesInternal = additionalCertificates.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="AzureSignToolSettings.AdditionalCertificates"/></em></p>
        ///   <p>A list of paths to additional certificates to aide in building a full chain for the signing certificate. Azure SignTool will build a chain, either as deep as it can or to a trusted root. This will also use the Windows certificate store, in addition to any certificates specified with this option. Specifying this option does not guarantee the inclusion of the certificate, only if it is part of the chain. The files specified must be public certificates only. They cannot be PFX, PKCS12 or PFX files.</p>
        /// </summary>
        [Pure]
        public static T AddAdditionalCertificates<T>(this T toolSettings, params string[] additionalCertificates) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalCertificatesInternal.AddRange(additionalCertificates);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="AzureSignToolSettings.AdditionalCertificates"/></em></p>
        ///   <p>A list of paths to additional certificates to aide in building a full chain for the signing certificate. Azure SignTool will build a chain, either as deep as it can or to a trusted root. This will also use the Windows certificate store, in addition to any certificates specified with this option. Specifying this option does not guarantee the inclusion of the certificate, only if it is part of the chain. The files specified must be public certificates only. They cannot be PFX, PKCS12 or PFX files.</p>
        /// </summary>
        [Pure]
        public static T AddAdditionalCertificates<T>(this T toolSettings, IEnumerable<string> additionalCertificates) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalCertificatesInternal.AddRange(additionalCertificates);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="AzureSignToolSettings.AdditionalCertificates"/></em></p>
        ///   <p>A list of paths to additional certificates to aide in building a full chain for the signing certificate. Azure SignTool will build a chain, either as deep as it can or to a trusted root. This will also use the Windows certificate store, in addition to any certificates specified with this option. Specifying this option does not guarantee the inclusion of the certificate, only if it is part of the chain. The files specified must be public certificates only. They cannot be PFX, PKCS12 or PFX files.</p>
        /// </summary>
        [Pure]
        public static T ClearAdditionalCertificates<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalCertificatesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="AzureSignToolSettings.AdditionalCertificates"/></em></p>
        ///   <p>A list of paths to additional certificates to aide in building a full chain for the signing certificate. Azure SignTool will build a chain, either as deep as it can or to a trusted root. This will also use the Windows certificate store, in addition to any certificates specified with this option. Specifying this option does not guarantee the inclusion of the certificate, only if it is part of the chain. The files specified must be public certificates only. They cannot be PFX, PKCS12 or PFX files.</p>
        /// </summary>
        [Pure]
        public static T RemoveAdditionalCertificates<T>(this T toolSettings, params string[] additionalCertificates) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(additionalCertificates);
            toolSettings.AdditionalCertificatesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="AzureSignToolSettings.AdditionalCertificates"/></em></p>
        ///   <p>A list of paths to additional certificates to aide in building a full chain for the signing certificate. Azure SignTool will build a chain, either as deep as it can or to a trusted root. This will also use the Windows certificate store, in addition to any certificates specified with this option. Specifying this option does not guarantee the inclusion of the certificate, only if it is part of the chain. The files specified must be public certificates only. They cannot be PFX, PKCS12 or PFX files.</p>
        /// </summary>
        [Pure]
        public static T RemoveAdditionalCertificates<T>(this T toolSettings, IEnumerable<string> additionalCertificates) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(additionalCertificates);
            toolSettings.AdditionalCertificatesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.Verbose"/></em></p>
        ///   <p>Include additional output in the log. This parameter does not accept a value and cannot be combine with the <c>--quiet</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.Verbose"/></em></p>
        ///   <p>Include additional output in the log. This parameter does not accept a value and cannot be combine with the <c>--quiet</c> option.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="AzureSignToolSettings.Verbose"/></em></p>
        ///   <p>Include additional output in the log. This parameter does not accept a value and cannot be combine with the <c>--quiet</c> option.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="AzureSignToolSettings.Verbose"/></em></p>
        ///   <p>Include additional output in the log. This parameter does not accept a value and cannot be combine with the <c>--quiet</c> option.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="AzureSignToolSettings.Verbose"/></em></p>
        ///   <p>Include additional output in the log. This parameter does not accept a value and cannot be combine with the <c>--quiet</c> option.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Quiet
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.Quiet"/></em></p>
        ///   <p>Do not print output to the log. This parameter does not accept a value and cannot be combine with the <c>--verbose</c> option. The exit code of the process can be used to determine success or failure of the sign operation.</p>
        /// </summary>
        [Pure]
        public static T SetQuiet<T>(this T toolSettings, bool? quiet) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = quiet;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.Quiet"/></em></p>
        ///   <p>Do not print output to the log. This parameter does not accept a value and cannot be combine with the <c>--verbose</c> option. The exit code of the process can be used to determine success or failure of the sign operation.</p>
        /// </summary>
        [Pure]
        public static T ResetQuiet<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="AzureSignToolSettings.Quiet"/></em></p>
        ///   <p>Do not print output to the log. This parameter does not accept a value and cannot be combine with the <c>--verbose</c> option. The exit code of the process can be used to determine success or failure of the sign operation.</p>
        /// </summary>
        [Pure]
        public static T EnableQuiet<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="AzureSignToolSettings.Quiet"/></em></p>
        ///   <p>Do not print output to the log. This parameter does not accept a value and cannot be combine with the <c>--verbose</c> option. The exit code of the process can be used to determine success or failure of the sign operation.</p>
        /// </summary>
        [Pure]
        public static T DisableQuiet<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="AzureSignToolSettings.Quiet"/></em></p>
        ///   <p>Do not print output to the log. This parameter does not accept a value and cannot be combine with the <c>--verbose</c> option. The exit code of the process can be used to determine success or failure of the sign operation.</p>
        /// </summary>
        [Pure]
        public static T ToggleQuiet<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = !toolSettings.Quiet;
            return toolSettings;
        }
        #endregion
        #region ContinueOnError
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.ContinueOnError"/></em></p>
        ///   <p>If multiple files to sign are specified, this flag will cause the signing process to move on to the next file when signing fails. This flag modifies the exit code of the program. See the <a href="https://github.com/vcsjones/AzureSignTool#exit-codes">Exit Codes section</a> for more information.</p>
        /// </summary>
        [Pure]
        public static T SetContinueOnError<T>(this T toolSettings, bool? continueOnError) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContinueOnError = continueOnError;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.ContinueOnError"/></em></p>
        ///   <p>If multiple files to sign are specified, this flag will cause the signing process to move on to the next file when signing fails. This flag modifies the exit code of the program. See the <a href="https://github.com/vcsjones/AzureSignTool#exit-codes">Exit Codes section</a> for more information.</p>
        /// </summary>
        [Pure]
        public static T ResetContinueOnError<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContinueOnError = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="AzureSignToolSettings.ContinueOnError"/></em></p>
        ///   <p>If multiple files to sign are specified, this flag will cause the signing process to move on to the next file when signing fails. This flag modifies the exit code of the program. See the <a href="https://github.com/vcsjones/AzureSignTool#exit-codes">Exit Codes section</a> for more information.</p>
        /// </summary>
        [Pure]
        public static T EnableContinueOnError<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContinueOnError = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="AzureSignToolSettings.ContinueOnError"/></em></p>
        ///   <p>If multiple files to sign are specified, this flag will cause the signing process to move on to the next file when signing fails. This flag modifies the exit code of the program. See the <a href="https://github.com/vcsjones/AzureSignTool#exit-codes">Exit Codes section</a> for more information.</p>
        /// </summary>
        [Pure]
        public static T DisableContinueOnError<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContinueOnError = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="AzureSignToolSettings.ContinueOnError"/></em></p>
        ///   <p>If multiple files to sign are specified, this flag will cause the signing process to move on to the next file when signing fails. This flag modifies the exit code of the program. See the <a href="https://github.com/vcsjones/AzureSignTool#exit-codes">Exit Codes section</a> for more information.</p>
        /// </summary>
        [Pure]
        public static T ToggleContinueOnError<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContinueOnError = !toolSettings.ContinueOnError;
            return toolSettings;
        }
        #endregion
        #region InputFileList
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.InputFileList"/></em></p>
        ///   <p>Specifies a path to a text file which contains a list of files to sign, with one file per-line in the text file. If this parameter is specified, it is combined with files directly specified on the command line. The distinct result of the two options is signed.</p>
        /// </summary>
        [Pure]
        public static T SetInputFileList<T>(this T toolSettings, string inputFileList) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFileList = inputFileList;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.InputFileList"/></em></p>
        ///   <p>Specifies a path to a text file which contains a list of files to sign, with one file per-line in the text file. If this parameter is specified, it is combined with files directly specified on the command line. The distinct result of the two options is signed.</p>
        /// </summary>
        [Pure]
        public static T ResetInputFileList<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFileList = null;
            return toolSettings;
        }
        #endregion
        #region SkipSigned
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.SkipSigned"/></em></p>
        ///   <p>If a file is already signed it will be skipped, rather than replacing the existing signature.</p>
        /// </summary>
        [Pure]
        public static T SetSkipSigned<T>(this T toolSettings, bool? skipSigned) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipSigned = skipSigned;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.SkipSigned"/></em></p>
        ///   <p>If a file is already signed it will be skipped, rather than replacing the existing signature.</p>
        /// </summary>
        [Pure]
        public static T ResetSkipSigned<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipSigned = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="AzureSignToolSettings.SkipSigned"/></em></p>
        ///   <p>If a file is already signed it will be skipped, rather than replacing the existing signature.</p>
        /// </summary>
        [Pure]
        public static T EnableSkipSigned<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipSigned = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="AzureSignToolSettings.SkipSigned"/></em></p>
        ///   <p>If a file is already signed it will be skipped, rather than replacing the existing signature.</p>
        /// </summary>
        [Pure]
        public static T DisableSkipSigned<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipSigned = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="AzureSignToolSettings.SkipSigned"/></em></p>
        ///   <p>If a file is already signed it will be skipped, rather than replacing the existing signature.</p>
        /// </summary>
        [Pure]
        public static T ToggleSkipSigned<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipSigned = !toolSettings.SkipSigned;
            return toolSettings;
        }
        #endregion
        #region PageHashing
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.PageHashing"/></em></p>
        ///   <p>Causes the Authenticode signing process to generate hashes of pages for verifying when the application is paged in to memory. If this flag is omitted, the default configuration for the operating system will be used. This flag will not affect non-PE file formats.</p>
        /// </summary>
        [Pure]
        public static T SetPageHashing<T>(this T toolSettings, bool? pageHashing) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageHashing = pageHashing;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.PageHashing"/></em></p>
        ///   <p>Causes the Authenticode signing process to generate hashes of pages for verifying when the application is paged in to memory. If this flag is omitted, the default configuration for the operating system will be used. This flag will not affect non-PE file formats.</p>
        /// </summary>
        [Pure]
        public static T ResetPageHashing<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageHashing = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="AzureSignToolSettings.PageHashing"/></em></p>
        ///   <p>Causes the Authenticode signing process to generate hashes of pages for verifying when the application is paged in to memory. If this flag is omitted, the default configuration for the operating system will be used. This flag will not affect non-PE file formats.</p>
        /// </summary>
        [Pure]
        public static T EnablePageHashing<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageHashing = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="AzureSignToolSettings.PageHashing"/></em></p>
        ///   <p>Causes the Authenticode signing process to generate hashes of pages for verifying when the application is paged in to memory. If this flag is omitted, the default configuration for the operating system will be used. This flag will not affect non-PE file formats.</p>
        /// </summary>
        [Pure]
        public static T DisablePageHashing<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageHashing = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="AzureSignToolSettings.PageHashing"/></em></p>
        ///   <p>Causes the Authenticode signing process to generate hashes of pages for verifying when the application is paged in to memory. If this flag is omitted, the default configuration for the operating system will be used. This flag will not affect non-PE file formats.</p>
        /// </summary>
        [Pure]
        public static T TogglePageHashing<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageHashing = !toolSettings.PageHashing;
            return toolSettings;
        }
        #endregion
        #region NoPageHashing
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.NoPageHashing"/></em></p>
        ///   <p>Causes the Authenticode signing process to exclude hashes of pages for verifying when the application is paged in to memory. If this flag is omitted, the default configuration for the operating system will be used. This flag will not affect non-PE file formats.</p>
        /// </summary>
        [Pure]
        public static T SetNoPageHashing<T>(this T toolSettings, bool? noPageHashing) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPageHashing = noPageHashing;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.NoPageHashing"/></em></p>
        ///   <p>Causes the Authenticode signing process to exclude hashes of pages for verifying when the application is paged in to memory. If this flag is omitted, the default configuration for the operating system will be used. This flag will not affect non-PE file formats.</p>
        /// </summary>
        [Pure]
        public static T ResetNoPageHashing<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPageHashing = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="AzureSignToolSettings.NoPageHashing"/></em></p>
        ///   <p>Causes the Authenticode signing process to exclude hashes of pages for verifying when the application is paged in to memory. If this flag is omitted, the default configuration for the operating system will be used. This flag will not affect non-PE file formats.</p>
        /// </summary>
        [Pure]
        public static T EnableNoPageHashing<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPageHashing = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="AzureSignToolSettings.NoPageHashing"/></em></p>
        ///   <p>Causes the Authenticode signing process to exclude hashes of pages for verifying when the application is paged in to memory. If this flag is omitted, the default configuration for the operating system will be used. This flag will not affect non-PE file formats.</p>
        /// </summary>
        [Pure]
        public static T DisableNoPageHashing<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPageHashing = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="AzureSignToolSettings.NoPageHashing"/></em></p>
        ///   <p>Causes the Authenticode signing process to exclude hashes of pages for verifying when the application is paged in to memory. If this flag is omitted, the default configuration for the operating system will be used. This flag will not affect non-PE file formats.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoPageHashing<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPageHashing = !toolSettings.NoPageHashing;
            return toolSettings;
        }
        #endregion
        #region MaxDegreeOfParallelism
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.MaxDegreeOfParallelism"/></em></p>
        ///   <p>When signing multiple files, specifies the maximum number of concurrent operations. Setting this value does not guarentee that number of concurrent operations will be performed. If this value is unspecified, the system will use the default based on the number of available processor threads. Setting this value to <c>1</c> disable concurrent signing.</p>
        /// </summary>
        [Pure]
        public static T SetMaxDegreeOfParallelism<T>(this T toolSettings, int? maxDegreeOfParallelism) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxDegreeOfParallelism = maxDegreeOfParallelism;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureSignToolSettings.MaxDegreeOfParallelism"/></em></p>
        ///   <p>When signing multiple files, specifies the maximum number of concurrent operations. Setting this value does not guarentee that number of concurrent operations will be performed. If this value is unspecified, the system will use the default based on the number of available processor threads. Setting this value to <c>1</c> disable concurrent signing.</p>
        /// </summary>
        [Pure]
        public static T ResetMaxDegreeOfParallelism<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxDegreeOfParallelism = null;
            return toolSettings;
        }
        #endregion
        #region Files
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.Files"/> to a new list</em></p>
        ///   <p>Files to sign.</p>
        /// </summary>
        [Pure]
        public static T SetFiles<T>(this T toolSettings, params string[] files) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal = files.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="AzureSignToolSettings.Files"/> to a new list</em></p>
        ///   <p>Files to sign.</p>
        /// </summary>
        [Pure]
        public static T SetFiles<T>(this T toolSettings, IEnumerable<string> files) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal = files.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="AzureSignToolSettings.Files"/></em></p>
        ///   <p>Files to sign.</p>
        /// </summary>
        [Pure]
        public static T AddFiles<T>(this T toolSettings, params string[] files) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal.AddRange(files);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="AzureSignToolSettings.Files"/></em></p>
        ///   <p>Files to sign.</p>
        /// </summary>
        [Pure]
        public static T AddFiles<T>(this T toolSettings, IEnumerable<string> files) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal.AddRange(files);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="AzureSignToolSettings.Files"/></em></p>
        ///   <p>Files to sign.</p>
        /// </summary>
        [Pure]
        public static T ClearFiles<T>(this T toolSettings) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="AzureSignToolSettings.Files"/></em></p>
        ///   <p>Files to sign.</p>
        /// </summary>
        [Pure]
        public static T RemoveFiles<T>(this T toolSettings, params string[] files) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(files);
            toolSettings.FilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="AzureSignToolSettings.Files"/></em></p>
        ///   <p>Files to sign.</p>
        /// </summary>
        [Pure]
        public static T RemoveFiles<T>(this T toolSettings, IEnumerable<string> files) where T : AzureSignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(files);
            toolSettings.FilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region AzureSignToolDigestAlgorithm
    /// <summary>
    ///   Used within <see cref="AzureSignToolTasks"/>.
    /// </summary>
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
}
