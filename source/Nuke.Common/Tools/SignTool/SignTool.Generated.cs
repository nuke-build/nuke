// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/SignTool.json
// Generated with Nuke.CodeGeneration version LOCAL (OSX, .NETStandard,Version=v2.0)

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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.SignTool
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SignToolTasks
    {
        /// <summary><p>Path to the SignTool executable.</p></summary>
        public static string SignToolPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("SIGNTOOL_EXE") ??
            GetToolPath();
        /// <summary><p>Sign Tool is a command-line tool that digitally signs files, verifies signatures in files, and time-stamps files.</p></summary>
        public static IReadOnlyCollection<Output> SignTool(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(SignToolPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, null, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Use the <c>sign</c> command to sign files using embedded signatures. Signing protects a file from tampering, and allows users to verify the signer (you) based on a signing certificate. The options below allow you to specify signing parameters and to select the signing certificate you wish to use.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/signtool-exe">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> SignTool(Configure<SignToolSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new SignToolSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
    }
    #region SignToolSettings
    /// <summary><p>Used within <see cref="SignToolTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SignToolSettings : ToolSettings
    {
        /// <summary><p>Path to the SignTool executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? SignToolTasks.SignToolPath;
        /// <summary><p>Select the best signing cert automatically. SignTool will find all valid certs that satisfy all specified conditions and select the one that is valid for the longest. If this option is not present, SignTool will expect to find only one valid signing cert.</p></summary>
        public virtual bool? AutomaticSelection { get; internal set; }
        /// <summary><p>Add an additional certificate to the signature block.</p></summary>
        public virtual string AdditionalCertificate { get; internal set; }
        /// <summary><p>Specify the Certificate Template Name (Microsoft extension) of the signing cert.</p></summary>
        public virtual string CertificateTemplateName { get; internal set; }
        /// <summary><p>Specify the signing cert in a file. If this file is a PFX with a password, the password may be supplied with the <c>/p</c> option. If the file does not contain private keys, use the <c>/csp</c> and <c>/kc</c> options to specify the CSP and container name of the private key.</p></summary>
        public virtual string File { get; internal set; }
        /// <summary><p>Specify the Issuer of the signing cert, or a substring.</p></summary>
        public virtual string Issuer { get; internal set; }
        /// <summary><p>Specify the Subject Name of the signing cert, or a substring.</p></summary>
        public virtual string SigningSubjectName { get; internal set; }
        /// <summary><p>Specify a password to use when opening the PFX file.</p></summary>
        public virtual string Password { get; internal set; }
        /// <summary><p>Specify the Subject Name of a Root cert that the signing cert must chain to.</p></summary>
        public virtual string RootSubjectName { get; internal set; }
        /// <summary><p>Specify the Store to open when searching for the cert. The default is the <c>MY</c> Store.</p></summary>
        public virtual string Store { get; internal set; }
        /// <summary><p>Open a Machine store instead of a User store.</p></summary>
        public virtual bool? MachineStore { get; internal set; }
        /// <summary><p>Specify the SHA1 thumbprint of the signing cert.</p></summary>
        public virtual string Sha1Thumbprint { get; internal set; }
        /// <summary><p>Specifies the file digest algorithm to use for creating file signatures. (Default is <c>SHA1</c>)</p></summary>
        public virtual string FileDigestAlgorithm { get; internal set; }
        /// <summary><p>Specify the Enhanced Key Usage that must be present in the cert.<para/>The parameter may be specified by OID or by string. The default usage is <em>Code Signing</em> (1.3.6.1.5.5.7.3.3).</p></summary>
        public virtual string EnhancedKeyUsage { get; internal set; }
        /// <summary><p>Specify usage of <em>Windows System Component Verification</em> (1.3.6.1.4.1.311.10.3.6).</p></summary>
        public virtual bool? WindowsSystemComponentVerification { get; internal set; }
        /// <summary><p>Specify the CSP containing the Private Key Container.</p></summary>
        public virtual string Csp { get; internal set; }
        /// <summary><p>Specify the Key Container Name of the Private Key.</p></summary>
        public virtual string KeyContainer { get; internal set; }
        /// <summary><p>Append this signature. If no primary signature is present, this signature will be made the primary signature instead.</p></summary>
        public virtual bool? AppendSignature { get; internal set; }
        /// <summary><p>Provide a description of the signed content.</p></summary>
        public virtual string Description { get; internal set; }
        /// <summary><p>Provide a URL with more information about the signed content.</p></summary>
        public virtual string Url { get; internal set; }
        /// <summary><p>Specify the timestamp server's URL. If this option is not present, the signed file will not be timestamped. A warning is generated if timestamping fails.</p></summary>
        public virtual string TimestampServerUrl { get; internal set; }
        /// <summary><p>Specifies the RFC 3161 timestamp server's URL. If this option (or <c>/t</c>) is not specified, the signed file will not be timestamped. A warning is generated if timestamping fails. This switch cannot be used with the <c>/t</c> switch.</p></summary>
        public virtual string Rfc3161TimestampServerUrl { get; internal set; }
        /// <summary><p>Specifies the RFC 3161 timestamp server's URL for timestamping a sealed file.</p></summary>
        public virtual string Rfc3161TimestampServerUrlSealed { get; internal set; }
        /// <summary><p>Used with the <c>/tr</c> or <c>/tseal</c> switch to request a digest algorithm used by the RFC 3161 timestamp server.</p></summary>
        public virtual string TimestampServerDigestAlgorithm { get; internal set; }
        /// <summary><p>Specify an OID and value to be included as an authenticated attribute in the signature. The value will be encoded as an ASN1 UTF8 string. This option may be given multiple times.</p></summary>
        public virtual IReadOnlyDictionary<string, string> AuthenticatedAttributes => AuthenticatedAttributesInternal.AsReadOnly();
        internal Dictionary<string, string> AuthenticatedAttributesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Add a sealing signature if the file format supports it.</p></summary>
        public virtual bool? SealingSignature { get; internal set; }
        /// <summary><p>Create a primary signature with the intent-to-seal attribute.</p></summary>
        public virtual bool? IntentToSealAttribute { get; internal set; }
        /// <summary><p>Continue to seal or sign in situations where the existing signature or sealing signature needs to be removed to support sealing.</p></summary>
        public virtual bool? Force { get; internal set; }
        /// <summary><p>Sealing-related warnings do not affect SignTool's return code.</p></summary>
        public virtual bool? NoSealWarn { get; internal set; }
        /// <summary><p>Generates the to be signed digest and the unsigned PKCS7 files. The output digest and PKCS7 files will be: <c>&lt;path&gt;\&lt;file&gt;.dig</c> and <c>&lt;path&gt;\&lt;file&gt;.p7u</c>. To output an additional XML file, see <c>/dxml</c>.</p></summary>
        public virtual string SignedDigestAndUnsignedPkcs7Path { get; internal set; }
        /// <summary><p>Signs the digest only. The input file should be the digest generated by the <c>/dg</c> option. The output file will be: <c>&lt;file&gt;.signed</c>.</p></summary>
        public virtual bool? SignDigestOnly { get; internal set; }
        /// <summary><p>Creates the signature by ingesting the signed digest to the unsigned PKCS7 file. The input signed digest and unsigned PKCS7 files should be: <c>&lt;path&gt;\&lt;file&gt;.dig.signed</c> and <c>&lt;path&gt;\&lt;file&gt;.p7u</c>.</p></summary>
        public virtual string GenerateSignature { get; internal set; }
        /// <summary><p>When used with the <c>/dg</c> option, produces an XML file. The output file will be: <c>&lt;path&gt;\&lt;file&gt;.dig.xml</c>.</p></summary>
        public virtual bool? XmlFile { get; internal set; }
        /// <summary><p>Specifies the DLL implementing the AuthenticodeDigestSign function to sign the digest with. This option is equivalent to using SignTool separately with the <c>/dg</c>, <c>/ds</c>, and <c>/di</c> switches, except this option invokes all three as one atomic operation.</p></summary>
        public virtual string AuthenticodeDigestSignLibDll { get; internal set; }
        /// <summary><p>When used with the <c>/dlib</c> option, passes the file's contents to the AuthenticodeDigestSign function without modification.</p></summary>
        public virtual string AuthenticodeDigestSignPassUnmodified { get; internal set; }
        /// <summary><p>Specifies that for each specified content file a PKCS7 file is produced. The PKCS7 file will be named: <c>&lt;path&gt;\&lt;file&gt;.p7</c></p></summary>
        public virtual string ContentFileToPkcs7 { get; internal set; }
        /// <summary><p>Specifies the <c>&lt;OID&gt;</c> that identifies the signed content.</p></summary>
        public virtual string SignedContentIdentifier { get; internal set; }
        /// <summary><p>efined values:<ul><li><b>Embedded:</b> Embeds the signed content in the PKCS7.</li><li><b>DetachedSignedData:</b> Produces the signed data part of a detached PKCS7.</li></ul>The default is <c>Embedded</c>.</p></summary>
        public virtual SignToolContentMethod SignedContentMethod { get; internal set; }
        /// <summary><p>Generate page hashes for executable files if supported.</p></summary>
        public virtual bool? PageHashes { get; internal set; }
        /// <summary><p>Suppress page hashes for executable files if supported. The default is determined by the <c>SIGNTOOL_PAGE_HASHES</c> environment variable and by the <em>wintrust.dll</em> version.</p></summary>
        public virtual bool? SuppressPageHashes { get; internal set; }
        /// <summary><p>Specifies signing a PE file with the relaxed marker check semantic. The flag is ignored for non-PE files. During verification, certain authenticated sections of the signature will bypass invalid PE markers check. This option should only be used after careful consideration and reviewing the details of MSRC case MS12-024 to ensure that no vulnerabilities are introduced.</p></summary>
        public virtual bool? RelaxedMarkerCheck { get; internal set; }
        /// <summary><p>No output on success and minimal output on failure.</p></summary>
        public virtual bool? Quiet { get; internal set; }
        /// <summary><p>Print verbose success and status messages. This may also provide slightly more information on error.</p></summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary><p>Display additional debug information.</p></summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary><p>Files to sign.</p></summary>
        public virtual IReadOnlyList<string> Files => FilesInternal.AsReadOnly();
        internal List<string> FilesInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("sign")
              .Add("/a", AutomaticSelection)
              .Add("/ac {value}", AdditionalCertificate)
              .Add("/c {value}", CertificateTemplateName)
              .Add("/f {value}", File)
              .Add("/i {value}", Issuer)
              .Add("/n {value}", SigningSubjectName)
              .Add("/p {value}", Password, secret: true)
              .Add("/r {value}", RootSubjectName)
              .Add("/s {value}", Store)
              .Add("/sm", MachineStore)
              .Add("/sha1 {value}", Sha1Thumbprint, secret: true)
              .Add("/fd {value}", FileDigestAlgorithm)
              .Add("/u {value}", EnhancedKeyUsage)
              .Add("/uw", WindowsSystemComponentVerification)
              .Add("/csp {value}", Csp)
              .Add("/kc {value}", KeyContainer)
              .Add("/as", AppendSignature)
              .Add("/d {value}", Description)
              .Add("/du {value}", Url)
              .Add("/t {value}", TimestampServerUrl)
              .Add("/tr {value}", Rfc3161TimestampServerUrl)
              .Add("/tseal {value}", Rfc3161TimestampServerUrlSealed)
              .Add("/td {value}", TimestampServerDigestAlgorithm)
              .Add("/sa {value}", AuthenticatedAttributes, "{key} {value}")
              .Add("/seal", SealingSignature)
              .Add("/itos", IntentToSealAttribute)
              .Add("/force", Force)
              .Add("/nosealwarn", NoSealWarn)
              .Add("/dg {value}", SignedDigestAndUnsignedPkcs7Path)
              .Add("/ds", SignDigestOnly)
              .Add("/di {value}", GenerateSignature)
              .Add("/dxml", XmlFile)
              .Add("/dlib {value}", AuthenticodeDigestSignLibDll)
              .Add("dmdf {value}", AuthenticodeDigestSignPassUnmodified)
              .Add("/p7 {value}", ContentFileToPkcs7)
              .Add("/p7co {value}", SignedContentIdentifier)
              .Add("/p7ce {value}", SignedContentMethod)
              .Add("/ph", PageHashes)
              .Add("/nph", SuppressPageHashes)
              .Add("/rmc", RelaxedMarkerCheck)
              .Add("/q", Quiet)
              .Add("/v", Verbose)
              .Add("/debug", Debug)
              .Add("{value}", Files);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region SignToolSettingsExtensions
    /// <summary><p>Used within <see cref="SignToolTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SignToolSettingsExtensions
    {
        #region AutomaticSelection
        /// <summary><p><em>Sets <see cref="SignToolSettings.AutomaticSelection"/>.</em></p><p>Select the best signing cert automatically. SignTool will find all valid certs that satisfy all specified conditions and select the one that is valid for the longest. If this option is not present, SignTool will expect to find only one valid signing cert.</p></summary>
        [Pure]
        public static SignToolSettings SetAutomaticSelection(this SignToolSettings toolSettings, bool? automaticSelection)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutomaticSelection = automaticSelection;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.AutomaticSelection"/>.</em></p><p>Select the best signing cert automatically. SignTool will find all valid certs that satisfy all specified conditions and select the one that is valid for the longest. If this option is not present, SignTool will expect to find only one valid signing cert.</p></summary>
        [Pure]
        public static SignToolSettings ResetAutomaticSelection(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutomaticSelection = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.AutomaticSelection"/>.</em></p><p>Select the best signing cert automatically. SignTool will find all valid certs that satisfy all specified conditions and select the one that is valid for the longest. If this option is not present, SignTool will expect to find only one valid signing cert.</p></summary>
        [Pure]
        public static SignToolSettings EnableAutomaticSelection(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutomaticSelection = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.AutomaticSelection"/>.</em></p><p>Select the best signing cert automatically. SignTool will find all valid certs that satisfy all specified conditions and select the one that is valid for the longest. If this option is not present, SignTool will expect to find only one valid signing cert.</p></summary>
        [Pure]
        public static SignToolSettings DisableAutomaticSelection(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutomaticSelection = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.AutomaticSelection"/>.</em></p><p>Select the best signing cert automatically. SignTool will find all valid certs that satisfy all specified conditions and select the one that is valid for the longest. If this option is not present, SignTool will expect to find only one valid signing cert.</p></summary>
        [Pure]
        public static SignToolSettings ToggleAutomaticSelection(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutomaticSelection = !toolSettings.AutomaticSelection;
            return toolSettings;
        }
        #endregion
        #region AdditionalCertificate
        /// <summary><p><em>Sets <see cref="SignToolSettings.AdditionalCertificate"/>.</em></p><p>Add an additional certificate to the signature block.</p></summary>
        [Pure]
        public static SignToolSettings SetAdditionalCertificate(this SignToolSettings toolSettings, string additionalCertificate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalCertificate = additionalCertificate;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.AdditionalCertificate"/>.</em></p><p>Add an additional certificate to the signature block.</p></summary>
        [Pure]
        public static SignToolSettings ResetAdditionalCertificate(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalCertificate = null;
            return toolSettings;
        }
        #endregion
        #region CertificateTemplateName
        /// <summary><p><em>Sets <see cref="SignToolSettings.CertificateTemplateName"/>.</em></p><p>Specify the Certificate Template Name (Microsoft extension) of the signing cert.</p></summary>
        [Pure]
        public static SignToolSettings SetCertificateTemplateName(this SignToolSettings toolSettings, string certificateTemplateName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertificateTemplateName = certificateTemplateName;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.CertificateTemplateName"/>.</em></p><p>Specify the Certificate Template Name (Microsoft extension) of the signing cert.</p></summary>
        [Pure]
        public static SignToolSettings ResetCertificateTemplateName(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertificateTemplateName = null;
            return toolSettings;
        }
        #endregion
        #region File
        /// <summary><p><em>Sets <see cref="SignToolSettings.File"/>.</em></p><p>Specify the signing cert in a file. If this file is a PFX with a password, the password may be supplied with the <c>/p</c> option. If the file does not contain private keys, use the <c>/csp</c> and <c>/kc</c> options to specify the CSP and container name of the private key.</p></summary>
        [Pure]
        public static SignToolSettings SetFile(this SignToolSettings toolSettings, string file)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = file;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.File"/>.</em></p><p>Specify the signing cert in a file. If this file is a PFX with a password, the password may be supplied with the <c>/p</c> option. If the file does not contain private keys, use the <c>/csp</c> and <c>/kc</c> options to specify the CSP and container name of the private key.</p></summary>
        [Pure]
        public static SignToolSettings ResetFile(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = null;
            return toolSettings;
        }
        #endregion
        #region Issuer
        /// <summary><p><em>Sets <see cref="SignToolSettings.Issuer"/>.</em></p><p>Specify the Issuer of the signing cert, or a substring.</p></summary>
        [Pure]
        public static SignToolSettings SetIssuer(this SignToolSettings toolSettings, string issuer)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Issuer = issuer;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.Issuer"/>.</em></p><p>Specify the Issuer of the signing cert, or a substring.</p></summary>
        [Pure]
        public static SignToolSettings ResetIssuer(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Issuer = null;
            return toolSettings;
        }
        #endregion
        #region SigningSubjectName
        /// <summary><p><em>Sets <see cref="SignToolSettings.SigningSubjectName"/>.</em></p><p>Specify the Subject Name of the signing cert, or a substring.</p></summary>
        [Pure]
        public static SignToolSettings SetSigningSubjectName(this SignToolSettings toolSettings, string signingSubjectName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SigningSubjectName = signingSubjectName;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.SigningSubjectName"/>.</em></p><p>Specify the Subject Name of the signing cert, or a substring.</p></summary>
        [Pure]
        public static SignToolSettings ResetSigningSubjectName(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SigningSubjectName = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary><p><em>Sets <see cref="SignToolSettings.Password"/>.</em></p><p>Specify a password to use when opening the PFX file.</p></summary>
        [Pure]
        public static SignToolSettings SetPassword(this SignToolSettings toolSettings, string password)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.Password"/>.</em></p><p>Specify a password to use when opening the PFX file.</p></summary>
        [Pure]
        public static SignToolSettings ResetPassword(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region RootSubjectName
        /// <summary><p><em>Sets <see cref="SignToolSettings.RootSubjectName"/>.</em></p><p>Specify the Subject Name of a Root cert that the signing cert must chain to.</p></summary>
        [Pure]
        public static SignToolSettings SetRootSubjectName(this SignToolSettings toolSettings, string rootSubjectName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RootSubjectName = rootSubjectName;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.RootSubjectName"/>.</em></p><p>Specify the Subject Name of a Root cert that the signing cert must chain to.</p></summary>
        [Pure]
        public static SignToolSettings ResetRootSubjectName(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RootSubjectName = null;
            return toolSettings;
        }
        #endregion
        #region Store
        /// <summary><p><em>Sets <see cref="SignToolSettings.Store"/>.</em></p><p>Specify the Store to open when searching for the cert. The default is the <c>MY</c> Store.</p></summary>
        [Pure]
        public static SignToolSettings SetStore(this SignToolSettings toolSettings, string store)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Store = store;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.Store"/>.</em></p><p>Specify the Store to open when searching for the cert. The default is the <c>MY</c> Store.</p></summary>
        [Pure]
        public static SignToolSettings ResetStore(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Store = null;
            return toolSettings;
        }
        #endregion
        #region MachineStore
        /// <summary><p><em>Sets <see cref="SignToolSettings.MachineStore"/>.</em></p><p>Open a Machine store instead of a User store.</p></summary>
        [Pure]
        public static SignToolSettings SetMachineStore(this SignToolSettings toolSettings, bool? machineStore)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MachineStore = machineStore;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.MachineStore"/>.</em></p><p>Open a Machine store instead of a User store.</p></summary>
        [Pure]
        public static SignToolSettings ResetMachineStore(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MachineStore = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.MachineStore"/>.</em></p><p>Open a Machine store instead of a User store.</p></summary>
        [Pure]
        public static SignToolSettings EnableMachineStore(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MachineStore = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.MachineStore"/>.</em></p><p>Open a Machine store instead of a User store.</p></summary>
        [Pure]
        public static SignToolSettings DisableMachineStore(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MachineStore = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.MachineStore"/>.</em></p><p>Open a Machine store instead of a User store.</p></summary>
        [Pure]
        public static SignToolSettings ToggleMachineStore(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MachineStore = !toolSettings.MachineStore;
            return toolSettings;
        }
        #endregion
        #region Sha1Thumbprint
        /// <summary><p><em>Sets <see cref="SignToolSettings.Sha1Thumbprint"/>.</em></p><p>Specify the SHA1 thumbprint of the signing cert.</p></summary>
        [Pure]
        public static SignToolSettings SetSha1Thumbprint(this SignToolSettings toolSettings, string sha1Thumbprint)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Sha1Thumbprint = sha1Thumbprint;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.Sha1Thumbprint"/>.</em></p><p>Specify the SHA1 thumbprint of the signing cert.</p></summary>
        [Pure]
        public static SignToolSettings ResetSha1Thumbprint(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Sha1Thumbprint = null;
            return toolSettings;
        }
        #endregion
        #region FileDigestAlgorithm
        /// <summary><p><em>Sets <see cref="SignToolSettings.FileDigestAlgorithm"/>.</em></p><p>Specifies the file digest algorithm to use for creating file signatures. (Default is <c>SHA1</c>)</p></summary>
        [Pure]
        public static SignToolSettings SetFileDigestAlgorithm(this SignToolSettings toolSettings, string fileDigestAlgorithm)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileDigestAlgorithm = fileDigestAlgorithm;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.FileDigestAlgorithm"/>.</em></p><p>Specifies the file digest algorithm to use for creating file signatures. (Default is <c>SHA1</c>)</p></summary>
        [Pure]
        public static SignToolSettings ResetFileDigestAlgorithm(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileDigestAlgorithm = null;
            return toolSettings;
        }
        #endregion
        #region EnhancedKeyUsage
        /// <summary><p><em>Sets <see cref="SignToolSettings.EnhancedKeyUsage"/>.</em></p><p>Specify the Enhanced Key Usage that must be present in the cert.<para/>The parameter may be specified by OID or by string. The default usage is <em>Code Signing</em> (1.3.6.1.5.5.7.3.3).</p></summary>
        [Pure]
        public static SignToolSettings SetEnhancedKeyUsage(this SignToolSettings toolSettings, string enhancedKeyUsage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnhancedKeyUsage = enhancedKeyUsage;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.EnhancedKeyUsage"/>.</em></p><p>Specify the Enhanced Key Usage that must be present in the cert.<para/>The parameter may be specified by OID or by string. The default usage is <em>Code Signing</em> (1.3.6.1.5.5.7.3.3).</p></summary>
        [Pure]
        public static SignToolSettings ResetEnhancedKeyUsage(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnhancedKeyUsage = null;
            return toolSettings;
        }
        #endregion
        #region WindowsSystemComponentVerification
        /// <summary><p><em>Sets <see cref="SignToolSettings.WindowsSystemComponentVerification"/>.</em></p><p>Specify usage of <em>Windows System Component Verification</em> (1.3.6.1.4.1.311.10.3.6).</p></summary>
        [Pure]
        public static SignToolSettings SetWindowsSystemComponentVerification(this SignToolSettings toolSettings, bool? windowsSystemComponentVerification)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WindowsSystemComponentVerification = windowsSystemComponentVerification;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.WindowsSystemComponentVerification"/>.</em></p><p>Specify usage of <em>Windows System Component Verification</em> (1.3.6.1.4.1.311.10.3.6).</p></summary>
        [Pure]
        public static SignToolSettings ResetWindowsSystemComponentVerification(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WindowsSystemComponentVerification = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.WindowsSystemComponentVerification"/>.</em></p><p>Specify usage of <em>Windows System Component Verification</em> (1.3.6.1.4.1.311.10.3.6).</p></summary>
        [Pure]
        public static SignToolSettings EnableWindowsSystemComponentVerification(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WindowsSystemComponentVerification = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.WindowsSystemComponentVerification"/>.</em></p><p>Specify usage of <em>Windows System Component Verification</em> (1.3.6.1.4.1.311.10.3.6).</p></summary>
        [Pure]
        public static SignToolSettings DisableWindowsSystemComponentVerification(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WindowsSystemComponentVerification = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.WindowsSystemComponentVerification"/>.</em></p><p>Specify usage of <em>Windows System Component Verification</em> (1.3.6.1.4.1.311.10.3.6).</p></summary>
        [Pure]
        public static SignToolSettings ToggleWindowsSystemComponentVerification(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WindowsSystemComponentVerification = !toolSettings.WindowsSystemComponentVerification;
            return toolSettings;
        }
        #endregion
        #region Csp
        /// <summary><p><em>Sets <see cref="SignToolSettings.Csp"/>.</em></p><p>Specify the CSP containing the Private Key Container.</p></summary>
        [Pure]
        public static SignToolSettings SetCsp(this SignToolSettings toolSettings, string csp)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Csp = csp;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.Csp"/>.</em></p><p>Specify the CSP containing the Private Key Container.</p></summary>
        [Pure]
        public static SignToolSettings ResetCsp(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Csp = null;
            return toolSettings;
        }
        #endregion
        #region KeyContainer
        /// <summary><p><em>Sets <see cref="SignToolSettings.KeyContainer"/>.</em></p><p>Specify the Key Container Name of the Private Key.</p></summary>
        [Pure]
        public static SignToolSettings SetKeyContainer(this SignToolSettings toolSettings, string keyContainer)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyContainer = keyContainer;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.KeyContainer"/>.</em></p><p>Specify the Key Container Name of the Private Key.</p></summary>
        [Pure]
        public static SignToolSettings ResetKeyContainer(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyContainer = null;
            return toolSettings;
        }
        #endregion
        #region AppendSignature
        /// <summary><p><em>Sets <see cref="SignToolSettings.AppendSignature"/>.</em></p><p>Append this signature. If no primary signature is present, this signature will be made the primary signature instead.</p></summary>
        [Pure]
        public static SignToolSettings SetAppendSignature(this SignToolSettings toolSettings, bool? appendSignature)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppendSignature = appendSignature;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.AppendSignature"/>.</em></p><p>Append this signature. If no primary signature is present, this signature will be made the primary signature instead.</p></summary>
        [Pure]
        public static SignToolSettings ResetAppendSignature(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppendSignature = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.AppendSignature"/>.</em></p><p>Append this signature. If no primary signature is present, this signature will be made the primary signature instead.</p></summary>
        [Pure]
        public static SignToolSettings EnableAppendSignature(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppendSignature = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.AppendSignature"/>.</em></p><p>Append this signature. If no primary signature is present, this signature will be made the primary signature instead.</p></summary>
        [Pure]
        public static SignToolSettings DisableAppendSignature(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppendSignature = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.AppendSignature"/>.</em></p><p>Append this signature. If no primary signature is present, this signature will be made the primary signature instead.</p></summary>
        [Pure]
        public static SignToolSettings ToggleAppendSignature(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppendSignature = !toolSettings.AppendSignature;
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary><p><em>Sets <see cref="SignToolSettings.Description"/>.</em></p><p>Provide a description of the signed content.</p></summary>
        [Pure]
        public static SignToolSettings SetDescription(this SignToolSettings toolSettings, string description)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = description;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.Description"/>.</em></p><p>Provide a description of the signed content.</p></summary>
        [Pure]
        public static SignToolSettings ResetDescription(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = null;
            return toolSettings;
        }
        #endregion
        #region Url
        /// <summary><p><em>Sets <see cref="SignToolSettings.Url"/>.</em></p><p>Provide a URL with more information about the signed content.</p></summary>
        [Pure]
        public static SignToolSettings SetUrl(this SignToolSettings toolSettings, string url)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = url;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.Url"/>.</em></p><p>Provide a URL with more information about the signed content.</p></summary>
        [Pure]
        public static SignToolSettings ResetUrl(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = null;
            return toolSettings;
        }
        #endregion
        #region TimestampServerUrl
        /// <summary><p><em>Sets <see cref="SignToolSettings.TimestampServerUrl"/>.</em></p><p>Specify the timestamp server's URL. If this option is not present, the signed file will not be timestamped. A warning is generated if timestamping fails.</p></summary>
        [Pure]
        public static SignToolSettings SetTimestampServerUrl(this SignToolSettings toolSettings, string timestampServerUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimestampServerUrl = timestampServerUrl;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.TimestampServerUrl"/>.</em></p><p>Specify the timestamp server's URL. If this option is not present, the signed file will not be timestamped. A warning is generated if timestamping fails.</p></summary>
        [Pure]
        public static SignToolSettings ResetTimestampServerUrl(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimestampServerUrl = null;
            return toolSettings;
        }
        #endregion
        #region Rfc3161TimestampServerUrl
        /// <summary><p><em>Sets <see cref="SignToolSettings.Rfc3161TimestampServerUrl"/>.</em></p><p>Specifies the RFC 3161 timestamp server's URL. If this option (or <c>/t</c>) is not specified, the signed file will not be timestamped. A warning is generated if timestamping fails. This switch cannot be used with the <c>/t</c> switch.</p></summary>
        [Pure]
        public static SignToolSettings SetRfc3161TimestampServerUrl(this SignToolSettings toolSettings, string rfc3161TimestampServerUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Rfc3161TimestampServerUrl = rfc3161TimestampServerUrl;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.Rfc3161TimestampServerUrl"/>.</em></p><p>Specifies the RFC 3161 timestamp server's URL. If this option (or <c>/t</c>) is not specified, the signed file will not be timestamped. A warning is generated if timestamping fails. This switch cannot be used with the <c>/t</c> switch.</p></summary>
        [Pure]
        public static SignToolSettings ResetRfc3161TimestampServerUrl(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Rfc3161TimestampServerUrl = null;
            return toolSettings;
        }
        #endregion
        #region Rfc3161TimestampServerUrlSealed
        /// <summary><p><em>Sets <see cref="SignToolSettings.Rfc3161TimestampServerUrlSealed"/>.</em></p><p>Specifies the RFC 3161 timestamp server's URL for timestamping a sealed file.</p></summary>
        [Pure]
        public static SignToolSettings SetRfc3161TimestampServerUrlSealed(this SignToolSettings toolSettings, string rfc3161TimestampServerUrlSealed)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Rfc3161TimestampServerUrlSealed = rfc3161TimestampServerUrlSealed;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.Rfc3161TimestampServerUrlSealed"/>.</em></p><p>Specifies the RFC 3161 timestamp server's URL for timestamping a sealed file.</p></summary>
        [Pure]
        public static SignToolSettings ResetRfc3161TimestampServerUrlSealed(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Rfc3161TimestampServerUrlSealed = null;
            return toolSettings;
        }
        #endregion
        #region TimestampServerDigestAlgorithm
        /// <summary><p><em>Sets <see cref="SignToolSettings.TimestampServerDigestAlgorithm"/>.</em></p><p>Used with the <c>/tr</c> or <c>/tseal</c> switch to request a digest algorithm used by the RFC 3161 timestamp server.</p></summary>
        [Pure]
        public static SignToolSettings SetTimestampServerDigestAlgorithm(this SignToolSettings toolSettings, string timestampServerDigestAlgorithm)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimestampServerDigestAlgorithm = timestampServerDigestAlgorithm;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.TimestampServerDigestAlgorithm"/>.</em></p><p>Used with the <c>/tr</c> or <c>/tseal</c> switch to request a digest algorithm used by the RFC 3161 timestamp server.</p></summary>
        [Pure]
        public static SignToolSettings ResetTimestampServerDigestAlgorithm(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimestampServerDigestAlgorithm = null;
            return toolSettings;
        }
        #endregion
        #region AuthenticatedAttributes
        /// <summary><p><em>Sets <see cref="SignToolSettings.AuthenticatedAttributes"/> to a new dictionary.</em></p><p>Specify an OID and value to be included as an authenticated attribute in the signature. The value will be encoded as an ASN1 UTF8 string. This option may be given multiple times.</p></summary>
        [Pure]
        public static SignToolSettings SetAuthenticatedAttributes(this SignToolSettings toolSettings, IDictionary<string, string> authenticatedAttributes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticatedAttributesInternal = authenticatedAttributes.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="SignToolSettings.AuthenticatedAttributes"/>.</em></p><p>Specify an OID and value to be included as an authenticated attribute in the signature. The value will be encoded as an ASN1 UTF8 string. This option may be given multiple times.</p></summary>
        [Pure]
        public static SignToolSettings ClearAuthenticatedAttributes(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticatedAttributesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="SignToolSettings.AuthenticatedAttributes"/>.</em></p><p>Specify an OID and value to be included as an authenticated attribute in the signature. The value will be encoded as an ASN1 UTF8 string. This option may be given multiple times.</p></summary>
        [Pure]
        public static SignToolSettings AddAuthenticatedAttribute(this SignToolSettings toolSettings, string authenticatedAttributeKey, string authenticatedAttributeValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticatedAttributesInternal.Add(authenticatedAttributeKey, authenticatedAttributeValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="SignToolSettings.AuthenticatedAttributes"/>.</em></p><p>Specify an OID and value to be included as an authenticated attribute in the signature. The value will be encoded as an ASN1 UTF8 string. This option may be given multiple times.</p></summary>
        [Pure]
        public static SignToolSettings RemoveAuthenticatedAttribute(this SignToolSettings toolSettings, string authenticatedAttributeKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticatedAttributesInternal.Remove(authenticatedAttributeKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="SignToolSettings.AuthenticatedAttributes"/>.</em></p><p>Specify an OID and value to be included as an authenticated attribute in the signature. The value will be encoded as an ASN1 UTF8 string. This option may be given multiple times.</p></summary>
        [Pure]
        public static SignToolSettings SetAuthenticatedAttribute(this SignToolSettings toolSettings, string authenticatedAttributeKey, string authenticatedAttributeValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticatedAttributesInternal[authenticatedAttributeKey] = authenticatedAttributeValue;
            return toolSettings;
        }
        #endregion
        #region SealingSignature
        /// <summary><p><em>Sets <see cref="SignToolSettings.SealingSignature"/>.</em></p><p>Add a sealing signature if the file format supports it.</p></summary>
        [Pure]
        public static SignToolSettings SetSealingSignature(this SignToolSettings toolSettings, bool? sealingSignature)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SealingSignature = sealingSignature;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.SealingSignature"/>.</em></p><p>Add a sealing signature if the file format supports it.</p></summary>
        [Pure]
        public static SignToolSettings ResetSealingSignature(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SealingSignature = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.SealingSignature"/>.</em></p><p>Add a sealing signature if the file format supports it.</p></summary>
        [Pure]
        public static SignToolSettings EnableSealingSignature(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SealingSignature = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.SealingSignature"/>.</em></p><p>Add a sealing signature if the file format supports it.</p></summary>
        [Pure]
        public static SignToolSettings DisableSealingSignature(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SealingSignature = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.SealingSignature"/>.</em></p><p>Add a sealing signature if the file format supports it.</p></summary>
        [Pure]
        public static SignToolSettings ToggleSealingSignature(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SealingSignature = !toolSettings.SealingSignature;
            return toolSettings;
        }
        #endregion
        #region IntentToSealAttribute
        /// <summary><p><em>Sets <see cref="SignToolSettings.IntentToSealAttribute"/>.</em></p><p>Create a primary signature with the intent-to-seal attribute.</p></summary>
        [Pure]
        public static SignToolSettings SetIntentToSealAttribute(this SignToolSettings toolSettings, bool? intentToSealAttribute)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntentToSealAttribute = intentToSealAttribute;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.IntentToSealAttribute"/>.</em></p><p>Create a primary signature with the intent-to-seal attribute.</p></summary>
        [Pure]
        public static SignToolSettings ResetIntentToSealAttribute(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntentToSealAttribute = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.IntentToSealAttribute"/>.</em></p><p>Create a primary signature with the intent-to-seal attribute.</p></summary>
        [Pure]
        public static SignToolSettings EnableIntentToSealAttribute(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntentToSealAttribute = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.IntentToSealAttribute"/>.</em></p><p>Create a primary signature with the intent-to-seal attribute.</p></summary>
        [Pure]
        public static SignToolSettings DisableIntentToSealAttribute(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntentToSealAttribute = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.IntentToSealAttribute"/>.</em></p><p>Create a primary signature with the intent-to-seal attribute.</p></summary>
        [Pure]
        public static SignToolSettings ToggleIntentToSealAttribute(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntentToSealAttribute = !toolSettings.IntentToSealAttribute;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary><p><em>Sets <see cref="SignToolSettings.Force"/>.</em></p><p>Continue to seal or sign in situations where the existing signature or sealing signature needs to be removed to support sealing.</p></summary>
        [Pure]
        public static SignToolSettings SetForce(this SignToolSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.Force"/>.</em></p><p>Continue to seal or sign in situations where the existing signature or sealing signature needs to be removed to support sealing.</p></summary>
        [Pure]
        public static SignToolSettings ResetForce(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.Force"/>.</em></p><p>Continue to seal or sign in situations where the existing signature or sealing signature needs to be removed to support sealing.</p></summary>
        [Pure]
        public static SignToolSettings EnableForce(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.Force"/>.</em></p><p>Continue to seal or sign in situations where the existing signature or sealing signature needs to be removed to support sealing.</p></summary>
        [Pure]
        public static SignToolSettings DisableForce(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.Force"/>.</em></p><p>Continue to seal or sign in situations where the existing signature or sealing signature needs to be removed to support sealing.</p></summary>
        [Pure]
        public static SignToolSettings ToggleForce(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region NoSealWarn
        /// <summary><p><em>Sets <see cref="SignToolSettings.NoSealWarn"/>.</em></p><p>Sealing-related warnings do not affect SignTool's return code.</p></summary>
        [Pure]
        public static SignToolSettings SetNoSealWarn(this SignToolSettings toolSettings, bool? noSealWarn)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSealWarn = noSealWarn;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.NoSealWarn"/>.</em></p><p>Sealing-related warnings do not affect SignTool's return code.</p></summary>
        [Pure]
        public static SignToolSettings ResetNoSealWarn(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSealWarn = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.NoSealWarn"/>.</em></p><p>Sealing-related warnings do not affect SignTool's return code.</p></summary>
        [Pure]
        public static SignToolSettings EnableNoSealWarn(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSealWarn = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.NoSealWarn"/>.</em></p><p>Sealing-related warnings do not affect SignTool's return code.</p></summary>
        [Pure]
        public static SignToolSettings DisableNoSealWarn(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSealWarn = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.NoSealWarn"/>.</em></p><p>Sealing-related warnings do not affect SignTool's return code.</p></summary>
        [Pure]
        public static SignToolSettings ToggleNoSealWarn(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSealWarn = !toolSettings.NoSealWarn;
            return toolSettings;
        }
        #endregion
        #region SignedDigestAndUnsignedPkcs7Path
        /// <summary><p><em>Sets <see cref="SignToolSettings.SignedDigestAndUnsignedPkcs7Path"/>.</em></p><p>Generates the to be signed digest and the unsigned PKCS7 files. The output digest and PKCS7 files will be: <c>&lt;path&gt;\&lt;file&gt;.dig</c> and <c>&lt;path&gt;\&lt;file&gt;.p7u</c>. To output an additional XML file, see <c>/dxml</c>.</p></summary>
        [Pure]
        public static SignToolSettings SetSignedDigestAndUnsignedPkcs7Path(this SignToolSettings toolSettings, string signedDigestAndUnsignedPkcs7Path)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignedDigestAndUnsignedPkcs7Path = signedDigestAndUnsignedPkcs7Path;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.SignedDigestAndUnsignedPkcs7Path"/>.</em></p><p>Generates the to be signed digest and the unsigned PKCS7 files. The output digest and PKCS7 files will be: <c>&lt;path&gt;\&lt;file&gt;.dig</c> and <c>&lt;path&gt;\&lt;file&gt;.p7u</c>. To output an additional XML file, see <c>/dxml</c>.</p></summary>
        [Pure]
        public static SignToolSettings ResetSignedDigestAndUnsignedPkcs7Path(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignedDigestAndUnsignedPkcs7Path = null;
            return toolSettings;
        }
        #endregion
        #region SignDigestOnly
        /// <summary><p><em>Sets <see cref="SignToolSettings.SignDigestOnly"/>.</em></p><p>Signs the digest only. The input file should be the digest generated by the <c>/dg</c> option. The output file will be: <c>&lt;file&gt;.signed</c>.</p></summary>
        [Pure]
        public static SignToolSettings SetSignDigestOnly(this SignToolSettings toolSettings, bool? signDigestOnly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignDigestOnly = signDigestOnly;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.SignDigestOnly"/>.</em></p><p>Signs the digest only. The input file should be the digest generated by the <c>/dg</c> option. The output file will be: <c>&lt;file&gt;.signed</c>.</p></summary>
        [Pure]
        public static SignToolSettings ResetSignDigestOnly(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignDigestOnly = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.SignDigestOnly"/>.</em></p><p>Signs the digest only. The input file should be the digest generated by the <c>/dg</c> option. The output file will be: <c>&lt;file&gt;.signed</c>.</p></summary>
        [Pure]
        public static SignToolSettings EnableSignDigestOnly(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignDigestOnly = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.SignDigestOnly"/>.</em></p><p>Signs the digest only. The input file should be the digest generated by the <c>/dg</c> option. The output file will be: <c>&lt;file&gt;.signed</c>.</p></summary>
        [Pure]
        public static SignToolSettings DisableSignDigestOnly(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignDigestOnly = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.SignDigestOnly"/>.</em></p><p>Signs the digest only. The input file should be the digest generated by the <c>/dg</c> option. The output file will be: <c>&lt;file&gt;.signed</c>.</p></summary>
        [Pure]
        public static SignToolSettings ToggleSignDigestOnly(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignDigestOnly = !toolSettings.SignDigestOnly;
            return toolSettings;
        }
        #endregion
        #region GenerateSignature
        /// <summary><p><em>Sets <see cref="SignToolSettings.GenerateSignature"/>.</em></p><p>Creates the signature by ingesting the signed digest to the unsigned PKCS7 file. The input signed digest and unsigned PKCS7 files should be: <c>&lt;path&gt;\&lt;file&gt;.dig.signed</c> and <c>&lt;path&gt;\&lt;file&gt;.p7u</c>.</p></summary>
        [Pure]
        public static SignToolSettings SetGenerateSignature(this SignToolSettings toolSettings, string generateSignature)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateSignature = generateSignature;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.GenerateSignature"/>.</em></p><p>Creates the signature by ingesting the signed digest to the unsigned PKCS7 file. The input signed digest and unsigned PKCS7 files should be: <c>&lt;path&gt;\&lt;file&gt;.dig.signed</c> and <c>&lt;path&gt;\&lt;file&gt;.p7u</c>.</p></summary>
        [Pure]
        public static SignToolSettings ResetGenerateSignature(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateSignature = null;
            return toolSettings;
        }
        #endregion
        #region XmlFile
        /// <summary><p><em>Sets <see cref="SignToolSettings.XmlFile"/>.</em></p><p>When used with the <c>/dg</c> option, produces an XML file. The output file will be: <c>&lt;path&gt;\&lt;file&gt;.dig.xml</c>.</p></summary>
        [Pure]
        public static SignToolSettings SetXmlFile(this SignToolSettings toolSettings, bool? xmlFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlFile = xmlFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.XmlFile"/>.</em></p><p>When used with the <c>/dg</c> option, produces an XML file. The output file will be: <c>&lt;path&gt;\&lt;file&gt;.dig.xml</c>.</p></summary>
        [Pure]
        public static SignToolSettings ResetXmlFile(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlFile = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.XmlFile"/>.</em></p><p>When used with the <c>/dg</c> option, produces an XML file. The output file will be: <c>&lt;path&gt;\&lt;file&gt;.dig.xml</c>.</p></summary>
        [Pure]
        public static SignToolSettings EnableXmlFile(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlFile = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.XmlFile"/>.</em></p><p>When used with the <c>/dg</c> option, produces an XML file. The output file will be: <c>&lt;path&gt;\&lt;file&gt;.dig.xml</c>.</p></summary>
        [Pure]
        public static SignToolSettings DisableXmlFile(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlFile = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.XmlFile"/>.</em></p><p>When used with the <c>/dg</c> option, produces an XML file. The output file will be: <c>&lt;path&gt;\&lt;file&gt;.dig.xml</c>.</p></summary>
        [Pure]
        public static SignToolSettings ToggleXmlFile(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlFile = !toolSettings.XmlFile;
            return toolSettings;
        }
        #endregion
        #region AuthenticodeDigestSignLibDll
        /// <summary><p><em>Sets <see cref="SignToolSettings.AuthenticodeDigestSignLibDll"/>.</em></p><p>Specifies the DLL implementing the AuthenticodeDigestSign function to sign the digest with. This option is equivalent to using SignTool separately with the <c>/dg</c>, <c>/ds</c>, and <c>/di</c> switches, except this option invokes all three as one atomic operation.</p></summary>
        [Pure]
        public static SignToolSettings SetAuthenticodeDigestSignLibDll(this SignToolSettings toolSettings, string authenticodeDigestSignLibDll)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticodeDigestSignLibDll = authenticodeDigestSignLibDll;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.AuthenticodeDigestSignLibDll"/>.</em></p><p>Specifies the DLL implementing the AuthenticodeDigestSign function to sign the digest with. This option is equivalent to using SignTool separately with the <c>/dg</c>, <c>/ds</c>, and <c>/di</c> switches, except this option invokes all three as one atomic operation.</p></summary>
        [Pure]
        public static SignToolSettings ResetAuthenticodeDigestSignLibDll(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticodeDigestSignLibDll = null;
            return toolSettings;
        }
        #endregion
        #region AuthenticodeDigestSignPassUnmodified
        /// <summary><p><em>Sets <see cref="SignToolSettings.AuthenticodeDigestSignPassUnmodified"/>.</em></p><p>When used with the <c>/dlib</c> option, passes the file's contents to the AuthenticodeDigestSign function without modification.</p></summary>
        [Pure]
        public static SignToolSettings SetAuthenticodeDigestSignPassUnmodified(this SignToolSettings toolSettings, string authenticodeDigestSignPassUnmodified)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticodeDigestSignPassUnmodified = authenticodeDigestSignPassUnmodified;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.AuthenticodeDigestSignPassUnmodified"/>.</em></p><p>When used with the <c>/dlib</c> option, passes the file's contents to the AuthenticodeDigestSign function without modification.</p></summary>
        [Pure]
        public static SignToolSettings ResetAuthenticodeDigestSignPassUnmodified(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticodeDigestSignPassUnmodified = null;
            return toolSettings;
        }
        #endregion
        #region ContentFileToPkcs7
        /// <summary><p><em>Sets <see cref="SignToolSettings.ContentFileToPkcs7"/>.</em></p><p>Specifies that for each specified content file a PKCS7 file is produced. The PKCS7 file will be named: <c>&lt;path&gt;\&lt;file&gt;.p7</c></p></summary>
        [Pure]
        public static SignToolSettings SetContentFileToPkcs7(this SignToolSettings toolSettings, string contentFileToPkcs7)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentFileToPkcs7 = contentFileToPkcs7;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.ContentFileToPkcs7"/>.</em></p><p>Specifies that for each specified content file a PKCS7 file is produced. The PKCS7 file will be named: <c>&lt;path&gt;\&lt;file&gt;.p7</c></p></summary>
        [Pure]
        public static SignToolSettings ResetContentFileToPkcs7(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentFileToPkcs7 = null;
            return toolSettings;
        }
        #endregion
        #region SignedContentIdentifier
        /// <summary><p><em>Sets <see cref="SignToolSettings.SignedContentIdentifier"/>.</em></p><p>Specifies the <c>&lt;OID&gt;</c> that identifies the signed content.</p></summary>
        [Pure]
        public static SignToolSettings SetSignedContentIdentifier(this SignToolSettings toolSettings, string signedContentIdentifier)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignedContentIdentifier = signedContentIdentifier;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.SignedContentIdentifier"/>.</em></p><p>Specifies the <c>&lt;OID&gt;</c> that identifies the signed content.</p></summary>
        [Pure]
        public static SignToolSettings ResetSignedContentIdentifier(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignedContentIdentifier = null;
            return toolSettings;
        }
        #endregion
        #region SignedContentMethod
        /// <summary><p><em>Sets <see cref="SignToolSettings.SignedContentMethod"/>.</em></p><p>efined values:<ul><li><b>Embedded:</b> Embeds the signed content in the PKCS7.</li><li><b>DetachedSignedData:</b> Produces the signed data part of a detached PKCS7.</li></ul>The default is <c>Embedded</c>.</p></summary>
        [Pure]
        public static SignToolSettings SetSignedContentMethod(this SignToolSettings toolSettings, SignToolContentMethod signedContentMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignedContentMethod = signedContentMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.SignedContentMethod"/>.</em></p><p>efined values:<ul><li><b>Embedded:</b> Embeds the signed content in the PKCS7.</li><li><b>DetachedSignedData:</b> Produces the signed data part of a detached PKCS7.</li></ul>The default is <c>Embedded</c>.</p></summary>
        [Pure]
        public static SignToolSettings ResetSignedContentMethod(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignedContentMethod = null;
            return toolSettings;
        }
        #endregion
        #region PageHashes
        /// <summary><p><em>Sets <see cref="SignToolSettings.PageHashes"/>.</em></p><p>Generate page hashes for executable files if supported.</p></summary>
        [Pure]
        public static SignToolSettings SetPageHashes(this SignToolSettings toolSettings, bool? pageHashes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageHashes = pageHashes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.PageHashes"/>.</em></p><p>Generate page hashes for executable files if supported.</p></summary>
        [Pure]
        public static SignToolSettings ResetPageHashes(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageHashes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.PageHashes"/>.</em></p><p>Generate page hashes for executable files if supported.</p></summary>
        [Pure]
        public static SignToolSettings EnablePageHashes(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageHashes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.PageHashes"/>.</em></p><p>Generate page hashes for executable files if supported.</p></summary>
        [Pure]
        public static SignToolSettings DisablePageHashes(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageHashes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.PageHashes"/>.</em></p><p>Generate page hashes for executable files if supported.</p></summary>
        [Pure]
        public static SignToolSettings TogglePageHashes(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageHashes = !toolSettings.PageHashes;
            return toolSettings;
        }
        #endregion
        #region SuppressPageHashes
        /// <summary><p><em>Sets <see cref="SignToolSettings.SuppressPageHashes"/>.</em></p><p>Suppress page hashes for executable files if supported. The default is determined by the <c>SIGNTOOL_PAGE_HASHES</c> environment variable and by the <em>wintrust.dll</em> version.</p></summary>
        [Pure]
        public static SignToolSettings SetSuppressPageHashes(this SignToolSettings toolSettings, bool? suppressPageHashes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressPageHashes = suppressPageHashes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.SuppressPageHashes"/>.</em></p><p>Suppress page hashes for executable files if supported. The default is determined by the <c>SIGNTOOL_PAGE_HASHES</c> environment variable and by the <em>wintrust.dll</em> version.</p></summary>
        [Pure]
        public static SignToolSettings ResetSuppressPageHashes(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressPageHashes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.SuppressPageHashes"/>.</em></p><p>Suppress page hashes for executable files if supported. The default is determined by the <c>SIGNTOOL_PAGE_HASHES</c> environment variable and by the <em>wintrust.dll</em> version.</p></summary>
        [Pure]
        public static SignToolSettings EnableSuppressPageHashes(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressPageHashes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.SuppressPageHashes"/>.</em></p><p>Suppress page hashes for executable files if supported. The default is determined by the <c>SIGNTOOL_PAGE_HASHES</c> environment variable and by the <em>wintrust.dll</em> version.</p></summary>
        [Pure]
        public static SignToolSettings DisableSuppressPageHashes(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressPageHashes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.SuppressPageHashes"/>.</em></p><p>Suppress page hashes for executable files if supported. The default is determined by the <c>SIGNTOOL_PAGE_HASHES</c> environment variable and by the <em>wintrust.dll</em> version.</p></summary>
        [Pure]
        public static SignToolSettings ToggleSuppressPageHashes(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressPageHashes = !toolSettings.SuppressPageHashes;
            return toolSettings;
        }
        #endregion
        #region RelaxedMarkerCheck
        /// <summary><p><em>Sets <see cref="SignToolSettings.RelaxedMarkerCheck"/>.</em></p><p>Specifies signing a PE file with the relaxed marker check semantic. The flag is ignored for non-PE files. During verification, certain authenticated sections of the signature will bypass invalid PE markers check. This option should only be used after careful consideration and reviewing the details of MSRC case MS12-024 to ensure that no vulnerabilities are introduced.</p></summary>
        [Pure]
        public static SignToolSettings SetRelaxedMarkerCheck(this SignToolSettings toolSettings, bool? relaxedMarkerCheck)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RelaxedMarkerCheck = relaxedMarkerCheck;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.RelaxedMarkerCheck"/>.</em></p><p>Specifies signing a PE file with the relaxed marker check semantic. The flag is ignored for non-PE files. During verification, certain authenticated sections of the signature will bypass invalid PE markers check. This option should only be used after careful consideration and reviewing the details of MSRC case MS12-024 to ensure that no vulnerabilities are introduced.</p></summary>
        [Pure]
        public static SignToolSettings ResetRelaxedMarkerCheck(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RelaxedMarkerCheck = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.RelaxedMarkerCheck"/>.</em></p><p>Specifies signing a PE file with the relaxed marker check semantic. The flag is ignored for non-PE files. During verification, certain authenticated sections of the signature will bypass invalid PE markers check. This option should only be used after careful consideration and reviewing the details of MSRC case MS12-024 to ensure that no vulnerabilities are introduced.</p></summary>
        [Pure]
        public static SignToolSettings EnableRelaxedMarkerCheck(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RelaxedMarkerCheck = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.RelaxedMarkerCheck"/>.</em></p><p>Specifies signing a PE file with the relaxed marker check semantic. The flag is ignored for non-PE files. During verification, certain authenticated sections of the signature will bypass invalid PE markers check. This option should only be used after careful consideration and reviewing the details of MSRC case MS12-024 to ensure that no vulnerabilities are introduced.</p></summary>
        [Pure]
        public static SignToolSettings DisableRelaxedMarkerCheck(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RelaxedMarkerCheck = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.RelaxedMarkerCheck"/>.</em></p><p>Specifies signing a PE file with the relaxed marker check semantic. The flag is ignored for non-PE files. During verification, certain authenticated sections of the signature will bypass invalid PE markers check. This option should only be used after careful consideration and reviewing the details of MSRC case MS12-024 to ensure that no vulnerabilities are introduced.</p></summary>
        [Pure]
        public static SignToolSettings ToggleRelaxedMarkerCheck(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RelaxedMarkerCheck = !toolSettings.RelaxedMarkerCheck;
            return toolSettings;
        }
        #endregion
        #region Quiet
        /// <summary><p><em>Sets <see cref="SignToolSettings.Quiet"/>.</em></p><p>No output on success and minimal output on failure.</p></summary>
        [Pure]
        public static SignToolSettings SetQuiet(this SignToolSettings toolSettings, bool? quiet)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = quiet;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.Quiet"/>.</em></p><p>No output on success and minimal output on failure.</p></summary>
        [Pure]
        public static SignToolSettings ResetQuiet(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.Quiet"/>.</em></p><p>No output on success and minimal output on failure.</p></summary>
        [Pure]
        public static SignToolSettings EnableQuiet(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.Quiet"/>.</em></p><p>No output on success and minimal output on failure.</p></summary>
        [Pure]
        public static SignToolSettings DisableQuiet(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.Quiet"/>.</em></p><p>No output on success and minimal output on failure.</p></summary>
        [Pure]
        public static SignToolSettings ToggleQuiet(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = !toolSettings.Quiet;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary><p><em>Sets <see cref="SignToolSettings.Verbose"/>.</em></p><p>Print verbose success and status messages. This may also provide slightly more information on error.</p></summary>
        [Pure]
        public static SignToolSettings SetVerbose(this SignToolSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.Verbose"/>.</em></p><p>Print verbose success and status messages. This may also provide slightly more information on error.</p></summary>
        [Pure]
        public static SignToolSettings ResetVerbose(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.Verbose"/>.</em></p><p>Print verbose success and status messages. This may also provide slightly more information on error.</p></summary>
        [Pure]
        public static SignToolSettings EnableVerbose(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.Verbose"/>.</em></p><p>Print verbose success and status messages. This may also provide slightly more information on error.</p></summary>
        [Pure]
        public static SignToolSettings DisableVerbose(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.Verbose"/>.</em></p><p>Print verbose success and status messages. This may also provide slightly more information on error.</p></summary>
        [Pure]
        public static SignToolSettings ToggleVerbose(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary><p><em>Sets <see cref="SignToolSettings.Debug"/>.</em></p><p>Display additional debug information.</p></summary>
        [Pure]
        public static SignToolSettings SetDebug(this SignToolSettings toolSettings, bool? debug)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SignToolSettings.Debug"/>.</em></p><p>Display additional debug information.</p></summary>
        [Pure]
        public static SignToolSettings ResetDebug(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SignToolSettings.Debug"/>.</em></p><p>Display additional debug information.</p></summary>
        [Pure]
        public static SignToolSettings EnableDebug(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SignToolSettings.Debug"/>.</em></p><p>Display additional debug information.</p></summary>
        [Pure]
        public static SignToolSettings DisableDebug(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SignToolSettings.Debug"/>.</em></p><p>Display additional debug information.</p></summary>
        [Pure]
        public static SignToolSettings ToggleDebug(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region Files
        /// <summary><p><em>Sets <see cref="SignToolSettings.Files"/> to a new list.</em></p><p>Files to sign.</p></summary>
        [Pure]
        public static SignToolSettings SetFiles(this SignToolSettings toolSettings, params string[] files)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal = files.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="SignToolSettings.Files"/> to a new list.</em></p><p>Files to sign.</p></summary>
        [Pure]
        public static SignToolSettings SetFiles(this SignToolSettings toolSettings, IEnumerable<string> files)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal = files.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="SignToolSettings.Files"/>.</em></p><p>Files to sign.</p></summary>
        [Pure]
        public static SignToolSettings AddFiles(this SignToolSettings toolSettings, params string[] files)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal.AddRange(files);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="SignToolSettings.Files"/>.</em></p><p>Files to sign.</p></summary>
        [Pure]
        public static SignToolSettings AddFiles(this SignToolSettings toolSettings, IEnumerable<string> files)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal.AddRange(files);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="SignToolSettings.Files"/>.</em></p><p>Files to sign.</p></summary>
        [Pure]
        public static SignToolSettings ClearFiles(this SignToolSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="SignToolSettings.Files"/>.</em></p><p>Files to sign.</p></summary>
        [Pure]
        public static SignToolSettings RemoveFiles(this SignToolSettings toolSettings, params string[] files)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(files);
            toolSettings.FilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="SignToolSettings.Files"/>.</em></p><p>Files to sign.</p></summary>
        [Pure]
        public static SignToolSettings RemoveFiles(this SignToolSettings toolSettings, IEnumerable<string> files)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(files);
            toolSettings.FilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region SignToolContentMethod
    /// <summary><p>Used within <see cref="SignToolTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<SignToolContentMethod>))]
    public partial class SignToolContentMethod : Enumeration
    {
        public static SignToolContentMethod Embedded = new SignToolContentMethod { Value = "Embedded" };
        public static SignToolContentMethod DetachedSignedData = new SignToolContentMethod { Value = "DetachedSignedData" };
    }
    #endregion
}
