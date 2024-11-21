// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/SignTool/SignTool.json

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

namespace Nuke.Common.Tools.SignTool;

/// <summary><p>Sign Tool is a command-line tool that digitally signs files, verifies signatures in files, and time-stamps files.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/signtool-exe">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public partial class SignToolTasks : ToolTasks
{
    public static string SignToolPath => new SignToolTasks().GetToolPath();
    /// <summary><p>Sign Tool is a command-line tool that digitally signs files, verifies signatures in files, and time-stamps files.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/signtool-exe">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> SignTool(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new SignToolTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Use the <c>sign</c> command to sign files using embedded signatures. Signing protects a file from tampering, and allows users to verify the signer (you) based on a signing certificate. The options below allow you to specify signing parameters and to select the signing certificate you wish to use.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/signtool-exe">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;files&gt;</c> via <see cref="SignToolSettings.Files"/></li><li><c>/a</c> via <see cref="SignToolSettings.AutomaticSelection"/></li><li><c>/ac</c> via <see cref="SignToolSettings.AdditionalCertificate"/></li><li><c>/as</c> via <see cref="SignToolSettings.AppendSignature"/></li><li><c>/c</c> via <see cref="SignToolSettings.CertificateTemplateName"/></li><li><c>/csp</c> via <see cref="SignToolSettings.Csp"/></li><li><c>/d</c> via <see cref="SignToolSettings.Description"/></li><li><c>/debug</c> via <see cref="SignToolSettings.Debug"/></li><li><c>/dg</c> via <see cref="SignToolSettings.SignedDigestAndUnsignedPkcs7Path"/></li><li><c>/di</c> via <see cref="SignToolSettings.GenerateSignature"/></li><li><c>/dlib</c> via <see cref="SignToolSettings.AuthenticodeDigestSignLibDll"/></li><li><c>/dmdf</c> via <see cref="SignToolSettings.AuthenticodeDigestSignPassUnmodified"/></li><li><c>/ds</c> via <see cref="SignToolSettings.SignDigestOnly"/></li><li><c>/du</c> via <see cref="SignToolSettings.Url"/></li><li><c>/dxml</c> via <see cref="SignToolSettings.XmlFile"/></li><li><c>/f</c> via <see cref="SignToolSettings.File"/></li><li><c>/fd</c> via <see cref="SignToolSettings.FileDigestAlgorithm"/></li><li><c>/force</c> via <see cref="SignToolSettings.Force"/></li><li><c>/i</c> via <see cref="SignToolSettings.Issuer"/></li><li><c>/itos</c> via <see cref="SignToolSettings.IntentToSealAttribute"/></li><li><c>/kc</c> via <see cref="SignToolSettings.KeyContainer"/></li><li><c>/n</c> via <see cref="SignToolSettings.SigningSubjectName"/></li><li><c>/nosealwarn</c> via <see cref="SignToolSettings.NoSealWarn"/></li><li><c>/nph</c> via <see cref="SignToolSettings.SuppressPageHashes"/></li><li><c>/p</c> via <see cref="SignToolSettings.Password"/></li><li><c>/p7</c> via <see cref="SignToolSettings.ContentFileToPkcs7"/></li><li><c>/p7ce</c> via <see cref="SignToolSettings.SignedContentMethod"/></li><li><c>/p7co</c> via <see cref="SignToolSettings.SignedContentIdentifier"/></li><li><c>/ph</c> via <see cref="SignToolSettings.PageHashes"/></li><li><c>/q</c> via <see cref="SignToolSettings.Quiet"/></li><li><c>/r</c> via <see cref="SignToolSettings.RootSubjectName"/></li><li><c>/rmc</c> via <see cref="SignToolSettings.RelaxedMarkerCheck"/></li><li><c>/s</c> via <see cref="SignToolSettings.Store"/></li><li><c>/sa</c> via <see cref="SignToolSettings.AuthenticatedAttributes"/></li><li><c>/seal</c> via <see cref="SignToolSettings.SealingSignature"/></li><li><c>/sha1</c> via <see cref="SignToolSettings.Sha1Thumbprint"/></li><li><c>/sm</c> via <see cref="SignToolSettings.MachineStore"/></li><li><c>/t</c> via <see cref="SignToolSettings.TimestampServerUrl"/></li><li><c>/td</c> via <see cref="SignToolSettings.TimestampServerDigestAlgorithm"/></li><li><c>/tr</c> via <see cref="SignToolSettings.Rfc3161TimestampServerUrl"/></li><li><c>/tseal</c> via <see cref="SignToolSettings.Rfc3161TimestampServerUrlSealed"/></li><li><c>/u</c> via <see cref="SignToolSettings.EnhancedKeyUsage"/></li><li><c>/uw</c> via <see cref="SignToolSettings.WindowsSystemComponentVerification"/></li><li><c>/v</c> via <see cref="SignToolSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SignTool(SignToolSettings options = null) => new SignToolTasks().Run(options);
    /// <summary><p>Use the <c>sign</c> command to sign files using embedded signatures. Signing protects a file from tampering, and allows users to verify the signer (you) based on a signing certificate. The options below allow you to specify signing parameters and to select the signing certificate you wish to use.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/signtool-exe">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;files&gt;</c> via <see cref="SignToolSettings.Files"/></li><li><c>/a</c> via <see cref="SignToolSettings.AutomaticSelection"/></li><li><c>/ac</c> via <see cref="SignToolSettings.AdditionalCertificate"/></li><li><c>/as</c> via <see cref="SignToolSettings.AppendSignature"/></li><li><c>/c</c> via <see cref="SignToolSettings.CertificateTemplateName"/></li><li><c>/csp</c> via <see cref="SignToolSettings.Csp"/></li><li><c>/d</c> via <see cref="SignToolSettings.Description"/></li><li><c>/debug</c> via <see cref="SignToolSettings.Debug"/></li><li><c>/dg</c> via <see cref="SignToolSettings.SignedDigestAndUnsignedPkcs7Path"/></li><li><c>/di</c> via <see cref="SignToolSettings.GenerateSignature"/></li><li><c>/dlib</c> via <see cref="SignToolSettings.AuthenticodeDigestSignLibDll"/></li><li><c>/dmdf</c> via <see cref="SignToolSettings.AuthenticodeDigestSignPassUnmodified"/></li><li><c>/ds</c> via <see cref="SignToolSettings.SignDigestOnly"/></li><li><c>/du</c> via <see cref="SignToolSettings.Url"/></li><li><c>/dxml</c> via <see cref="SignToolSettings.XmlFile"/></li><li><c>/f</c> via <see cref="SignToolSettings.File"/></li><li><c>/fd</c> via <see cref="SignToolSettings.FileDigestAlgorithm"/></li><li><c>/force</c> via <see cref="SignToolSettings.Force"/></li><li><c>/i</c> via <see cref="SignToolSettings.Issuer"/></li><li><c>/itos</c> via <see cref="SignToolSettings.IntentToSealAttribute"/></li><li><c>/kc</c> via <see cref="SignToolSettings.KeyContainer"/></li><li><c>/n</c> via <see cref="SignToolSettings.SigningSubjectName"/></li><li><c>/nosealwarn</c> via <see cref="SignToolSettings.NoSealWarn"/></li><li><c>/nph</c> via <see cref="SignToolSettings.SuppressPageHashes"/></li><li><c>/p</c> via <see cref="SignToolSettings.Password"/></li><li><c>/p7</c> via <see cref="SignToolSettings.ContentFileToPkcs7"/></li><li><c>/p7ce</c> via <see cref="SignToolSettings.SignedContentMethod"/></li><li><c>/p7co</c> via <see cref="SignToolSettings.SignedContentIdentifier"/></li><li><c>/ph</c> via <see cref="SignToolSettings.PageHashes"/></li><li><c>/q</c> via <see cref="SignToolSettings.Quiet"/></li><li><c>/r</c> via <see cref="SignToolSettings.RootSubjectName"/></li><li><c>/rmc</c> via <see cref="SignToolSettings.RelaxedMarkerCheck"/></li><li><c>/s</c> via <see cref="SignToolSettings.Store"/></li><li><c>/sa</c> via <see cref="SignToolSettings.AuthenticatedAttributes"/></li><li><c>/seal</c> via <see cref="SignToolSettings.SealingSignature"/></li><li><c>/sha1</c> via <see cref="SignToolSettings.Sha1Thumbprint"/></li><li><c>/sm</c> via <see cref="SignToolSettings.MachineStore"/></li><li><c>/t</c> via <see cref="SignToolSettings.TimestampServerUrl"/></li><li><c>/td</c> via <see cref="SignToolSettings.TimestampServerDigestAlgorithm"/></li><li><c>/tr</c> via <see cref="SignToolSettings.Rfc3161TimestampServerUrl"/></li><li><c>/tseal</c> via <see cref="SignToolSettings.Rfc3161TimestampServerUrlSealed"/></li><li><c>/u</c> via <see cref="SignToolSettings.EnhancedKeyUsage"/></li><li><c>/uw</c> via <see cref="SignToolSettings.WindowsSystemComponentVerification"/></li><li><c>/v</c> via <see cref="SignToolSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SignTool(Configure<SignToolSettings> configurator) => new SignToolTasks().Run(configurator.Invoke(new SignToolSettings()));
    /// <summary><p>Use the <c>sign</c> command to sign files using embedded signatures. Signing protects a file from tampering, and allows users to verify the signer (you) based on a signing certificate. The options below allow you to specify signing parameters and to select the signing certificate you wish to use.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/signtool-exe">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;files&gt;</c> via <see cref="SignToolSettings.Files"/></li><li><c>/a</c> via <see cref="SignToolSettings.AutomaticSelection"/></li><li><c>/ac</c> via <see cref="SignToolSettings.AdditionalCertificate"/></li><li><c>/as</c> via <see cref="SignToolSettings.AppendSignature"/></li><li><c>/c</c> via <see cref="SignToolSettings.CertificateTemplateName"/></li><li><c>/csp</c> via <see cref="SignToolSettings.Csp"/></li><li><c>/d</c> via <see cref="SignToolSettings.Description"/></li><li><c>/debug</c> via <see cref="SignToolSettings.Debug"/></li><li><c>/dg</c> via <see cref="SignToolSettings.SignedDigestAndUnsignedPkcs7Path"/></li><li><c>/di</c> via <see cref="SignToolSettings.GenerateSignature"/></li><li><c>/dlib</c> via <see cref="SignToolSettings.AuthenticodeDigestSignLibDll"/></li><li><c>/dmdf</c> via <see cref="SignToolSettings.AuthenticodeDigestSignPassUnmodified"/></li><li><c>/ds</c> via <see cref="SignToolSettings.SignDigestOnly"/></li><li><c>/du</c> via <see cref="SignToolSettings.Url"/></li><li><c>/dxml</c> via <see cref="SignToolSettings.XmlFile"/></li><li><c>/f</c> via <see cref="SignToolSettings.File"/></li><li><c>/fd</c> via <see cref="SignToolSettings.FileDigestAlgorithm"/></li><li><c>/force</c> via <see cref="SignToolSettings.Force"/></li><li><c>/i</c> via <see cref="SignToolSettings.Issuer"/></li><li><c>/itos</c> via <see cref="SignToolSettings.IntentToSealAttribute"/></li><li><c>/kc</c> via <see cref="SignToolSettings.KeyContainer"/></li><li><c>/n</c> via <see cref="SignToolSettings.SigningSubjectName"/></li><li><c>/nosealwarn</c> via <see cref="SignToolSettings.NoSealWarn"/></li><li><c>/nph</c> via <see cref="SignToolSettings.SuppressPageHashes"/></li><li><c>/p</c> via <see cref="SignToolSettings.Password"/></li><li><c>/p7</c> via <see cref="SignToolSettings.ContentFileToPkcs7"/></li><li><c>/p7ce</c> via <see cref="SignToolSettings.SignedContentMethod"/></li><li><c>/p7co</c> via <see cref="SignToolSettings.SignedContentIdentifier"/></li><li><c>/ph</c> via <see cref="SignToolSettings.PageHashes"/></li><li><c>/q</c> via <see cref="SignToolSettings.Quiet"/></li><li><c>/r</c> via <see cref="SignToolSettings.RootSubjectName"/></li><li><c>/rmc</c> via <see cref="SignToolSettings.RelaxedMarkerCheck"/></li><li><c>/s</c> via <see cref="SignToolSettings.Store"/></li><li><c>/sa</c> via <see cref="SignToolSettings.AuthenticatedAttributes"/></li><li><c>/seal</c> via <see cref="SignToolSettings.SealingSignature"/></li><li><c>/sha1</c> via <see cref="SignToolSettings.Sha1Thumbprint"/></li><li><c>/sm</c> via <see cref="SignToolSettings.MachineStore"/></li><li><c>/t</c> via <see cref="SignToolSettings.TimestampServerUrl"/></li><li><c>/td</c> via <see cref="SignToolSettings.TimestampServerDigestAlgorithm"/></li><li><c>/tr</c> via <see cref="SignToolSettings.Rfc3161TimestampServerUrl"/></li><li><c>/tseal</c> via <see cref="SignToolSettings.Rfc3161TimestampServerUrlSealed"/></li><li><c>/u</c> via <see cref="SignToolSettings.EnhancedKeyUsage"/></li><li><c>/uw</c> via <see cref="SignToolSettings.WindowsSystemComponentVerification"/></li><li><c>/v</c> via <see cref="SignToolSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(SignToolSettings Settings, IReadOnlyCollection<Output> Output)> SignTool(CombinatorialConfigure<SignToolSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(SignTool, degreeOfParallelism, completeOnFailure);
}
#region SignToolSettings
/// <summary>Used within <see cref="SignToolTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SignToolSettings>))]
[Command(Type = typeof(SignToolTasks), Command = nameof(SignToolTasks.SignTool), Arguments = "sign")]
public partial class SignToolSettings : ToolOptions
{
    /// <summary>Select the best signing cert automatically. SignTool will find all valid certs that satisfy all specified conditions and select the one that is valid for the longest. If this option is not present, SignTool will expect to find only one valid signing cert.</summary>
    [Argument(Format = "/a")] public bool? AutomaticSelection => Get<bool?>(() => AutomaticSelection);
    /// <summary>Add an additional certificate to the signature block.</summary>
    [Argument(Format = "/ac {value}")] public string AdditionalCertificate => Get<string>(() => AdditionalCertificate);
    /// <summary>Specify the Certificate Template Name (Microsoft extension) of the signing cert.</summary>
    [Argument(Format = "/c {value}")] public string CertificateTemplateName => Get<string>(() => CertificateTemplateName);
    /// <summary>Specify the signing cert in a file. If this file is a PFX with a password, the password may be supplied with the <c>/p</c> option. If the file does not contain private keys, use the <c>/csp</c> and <c>/kc</c> options to specify the CSP and container name of the private key.</summary>
    [Argument(Format = "/f {value}")] public string File => Get<string>(() => File);
    /// <summary>Specify the Issuer of the signing cert, or a substring.</summary>
    [Argument(Format = "/i {value}")] public string Issuer => Get<string>(() => Issuer);
    /// <summary>Specify the Subject Name of the signing cert, or a substring.</summary>
    [Argument(Format = "/n {value}")] public string SigningSubjectName => Get<string>(() => SigningSubjectName);
    /// <summary>Specify a password to use when opening the PFX file.</summary>
    [Argument(Format = "/p {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Specify the Subject Name of a Root cert that the signing cert must chain to.</summary>
    [Argument(Format = "/r {value}")] public string RootSubjectName => Get<string>(() => RootSubjectName);
    /// <summary>Specify the Store to open when searching for the cert. The default is the <c>MY</c> Store.</summary>
    [Argument(Format = "/s {value}")] public string Store => Get<string>(() => Store);
    /// <summary>Open a Machine store instead of a User store.</summary>
    [Argument(Format = "/sm")] public bool? MachineStore => Get<bool?>(() => MachineStore);
    /// <summary>Specify the SHA1 thumbprint of the signing cert.</summary>
    [Argument(Format = "/sha1 {value}", Secret = true)] public string Sha1Thumbprint => Get<string>(() => Sha1Thumbprint);
    /// <summary>Specifies the file digest algorithm to use for creating file signatures. (Default is <c>SHA1</c>)</summary>
    [Argument(Format = "/fd {value}")] public SignToolDigestAlgorithm FileDigestAlgorithm => Get<SignToolDigestAlgorithm>(() => FileDigestAlgorithm);
    /// <summary>Specify the Enhanced Key Usage that must be present in the cert.<para/>The parameter may be specified by OID or by string. The default usage is <em>Code Signing</em> (1.3.6.1.5.5.7.3.3).</summary>
    [Argument(Format = "/u {value}", Secret = false)] public string EnhancedKeyUsage => Get<string>(() => EnhancedKeyUsage);
    /// <summary>Specify usage of <em>Windows System Component Verification</em> (1.3.6.1.4.1.311.10.3.6).</summary>
    [Argument(Format = "/uw")] public bool? WindowsSystemComponentVerification => Get<bool?>(() => WindowsSystemComponentVerification);
    /// <summary>Specify the CSP containing the Private Key Container.</summary>
    [Argument(Format = "/csp {value}")] public string Csp => Get<string>(() => Csp);
    /// <summary>Specify the Key Container Name of the Private Key.</summary>
    [Argument(Format = "/kc {value}", Secret = false)] public string KeyContainer => Get<string>(() => KeyContainer);
    /// <summary>Append this signature. If no primary signature is present, this signature will be made the primary signature instead.</summary>
    [Argument(Format = "/as")] public bool? AppendSignature => Get<bool?>(() => AppendSignature);
    /// <summary>Provide a description of the signed content.</summary>
    [Argument(Format = "/d {value}")] public string Description => Get<string>(() => Description);
    /// <summary>Provide a URL with more information about the signed content.</summary>
    [Argument(Format = "/du {value}")] public string Url => Get<string>(() => Url);
    /// <summary>Specify the timestamp server's URL. If this option is not present, the signed file will not be timestamped. A warning is generated if timestamping fails.</summary>
    [Argument(Format = "/t {value}")] public string TimestampServerUrl => Get<string>(() => TimestampServerUrl);
    /// <summary>Specifies the RFC 3161 timestamp server's URL. If this option (or <c>/t</c>) is not specified, the signed file will not be timestamped. A warning is generated if timestamping fails. This switch cannot be used with the <c>/t</c> switch.</summary>
    [Argument(Format = "/tr {value}")] public string Rfc3161TimestampServerUrl => Get<string>(() => Rfc3161TimestampServerUrl);
    /// <summary>Specifies the RFC 3161 timestamp server's URL for timestamping a sealed file.</summary>
    [Argument(Format = "/tseal {value}")] public string Rfc3161TimestampServerUrlSealed => Get<string>(() => Rfc3161TimestampServerUrlSealed);
    /// <summary>Used with the <c>/tr</c> or <c>/tseal</c> switch to request a digest algorithm used by the RFC 3161 timestamp server.</summary>
    [Argument(Format = "/td {value}")] public SignToolDigestAlgorithm TimestampServerDigestAlgorithm => Get<SignToolDigestAlgorithm>(() => TimestampServerDigestAlgorithm);
    /// <summary>Specify an OID and value to be included as an authenticated attribute in the signature. The value will be encoded as an ASN1 UTF8 string. This option may be given multiple times.</summary>
    [Argument(Format = "/sa {key} {value}")] public IReadOnlyDictionary<string, string> AuthenticatedAttributes => Get<Dictionary<string, string>>(() => AuthenticatedAttributes);
    /// <summary>Add a sealing signature if the file format supports it.</summary>
    [Argument(Format = "/seal")] public bool? SealingSignature => Get<bool?>(() => SealingSignature);
    /// <summary>Create a primary signature with the intent-to-seal attribute.</summary>
    [Argument(Format = "/itos")] public bool? IntentToSealAttribute => Get<bool?>(() => IntentToSealAttribute);
    /// <summary>Continue to seal or sign in situations where the existing signature or sealing signature needs to be removed to support sealing.</summary>
    [Argument(Format = "/force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Sealing-related warnings do not affect SignTool's return code.</summary>
    [Argument(Format = "/nosealwarn")] public bool? NoSealWarn => Get<bool?>(() => NoSealWarn);
    /// <summary>Generates the to be signed digest and the unsigned PKCS7 files. The output digest and PKCS7 files will be: <c>&lt;path&gt;\&lt;file&gt;.dig</c> and <c>&lt;path&gt;\&lt;file&gt;.p7u</c>. To output an additional XML file, see <c>/dxml</c>.</summary>
    [Argument(Format = "/dg {value}")] public string SignedDigestAndUnsignedPkcs7Path => Get<string>(() => SignedDigestAndUnsignedPkcs7Path);
    /// <summary>Signs the digest only. The input file should be the digest generated by the <c>/dg</c> option. The output file will be: <c>&lt;file&gt;.signed</c>.</summary>
    [Argument(Format = "/ds")] public bool? SignDigestOnly => Get<bool?>(() => SignDigestOnly);
    /// <summary>Creates the signature by ingesting the signed digest to the unsigned PKCS7 file. The input signed digest and unsigned PKCS7 files should be: <c>&lt;path&gt;\&lt;file&gt;.dig.signed</c> and <c>&lt;path&gt;\&lt;file&gt;.p7u</c>.</summary>
    [Argument(Format = "/di {value}")] public string GenerateSignature => Get<string>(() => GenerateSignature);
    /// <summary>When used with the <c>/dg</c> option, produces an XML file. The output file will be: <c>&lt;path&gt;\&lt;file&gt;.dig.xml</c>.</summary>
    [Argument(Format = "/dxml")] public bool? XmlFile => Get<bool?>(() => XmlFile);
    /// <summary>Specifies the DLL implementing the AuthenticodeDigestSign function to sign the digest with. This option is equivalent to using SignTool separately with the <c>/dg</c>, <c>/ds</c>, and <c>/di</c> switches, except this option invokes all three as one atomic operation.</summary>
    [Argument(Format = "/dlib {value}")] public string AuthenticodeDigestSignLibDll => Get<string>(() => AuthenticodeDigestSignLibDll);
    /// <summary>When used with the <c>/dlib</c> option, passes the file's contents to the AuthenticodeDigestSign function without modification.</summary>
    [Argument(Format = "/dmdf {value}")] public string AuthenticodeDigestSignPassUnmodified => Get<string>(() => AuthenticodeDigestSignPassUnmodified);
    /// <summary>Specifies that for each specified content file a PKCS7 file is produced. The PKCS7 file will be named: <c>&lt;path&gt;\&lt;file&gt;.p7</c></summary>
    [Argument(Format = "/p7 {value}")] public string ContentFileToPkcs7 => Get<string>(() => ContentFileToPkcs7);
    /// <summary>Specifies the <c>&lt;OID&gt;</c> that identifies the signed content.</summary>
    [Argument(Format = "/p7co {value}")] public string SignedContentIdentifier => Get<string>(() => SignedContentIdentifier);
    /// <summary>efined values:<ul><li><b>Embedded:</b> Embeds the signed content in the PKCS7.</li><li><b>DetachedSignedData:</b> Produces the signed data part of a detached PKCS7.</li></ul>The default is <c>Embedded</c>.</summary>
    [Argument(Format = "/p7ce {value}")] public SignToolContentMethod SignedContentMethod => Get<SignToolContentMethod>(() => SignedContentMethod);
    /// <summary>Generate page hashes for executable files if supported.</summary>
    [Argument(Format = "/ph")] public bool? PageHashes => Get<bool?>(() => PageHashes);
    /// <summary>Suppress page hashes for executable files if supported. The default is determined by the <c>SIGNTOOL_PAGE_HASHES</c> environment variable and by the <em>wintrust.dll</em> version.</summary>
    [Argument(Format = "/nph")] public bool? SuppressPageHashes => Get<bool?>(() => SuppressPageHashes);
    /// <summary>Specifies signing a PE file with the relaxed marker check semantic. The flag is ignored for non-PE files. During verification, certain authenticated sections of the signature will bypass invalid PE markers check. This option should only be used after careful consideration and reviewing the details of MSRC case MS12-024 to ensure that no vulnerabilities are introduced.</summary>
    [Argument(Format = "/rmc")] public bool? RelaxedMarkerCheck => Get<bool?>(() => RelaxedMarkerCheck);
    /// <summary>No output on success and minimal output on failure.</summary>
    [Argument(Format = "/q")] public bool? Quiet => Get<bool?>(() => Quiet);
    /// <summary>Print verbose success and status messages. This may also provide slightly more information on error.</summary>
    [Argument(Format = "/v")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Display additional debug information.</summary>
    [Argument(Format = "/debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Files to sign.</summary>
    [Argument(Format = "{value}", Position = -1)] public IReadOnlyList<string> Files => Get<List<string>>(() => Files);
}
#endregion
#region SignToolSettingsExtensions
/// <summary>Used within <see cref="SignToolTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SignToolSettingsExtensions
{
    #region AutomaticSelection
    /// <inheritdoc cref="SignToolSettings.AutomaticSelection"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AutomaticSelection))]
    public static T SetAutomaticSelection<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.AutomaticSelection, v));
    /// <inheritdoc cref="SignToolSettings.AutomaticSelection"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AutomaticSelection))]
    public static T ResetAutomaticSelection<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.AutomaticSelection));
    /// <inheritdoc cref="SignToolSettings.AutomaticSelection"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AutomaticSelection))]
    public static T EnableAutomaticSelection<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.AutomaticSelection, true));
    /// <inheritdoc cref="SignToolSettings.AutomaticSelection"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AutomaticSelection))]
    public static T DisableAutomaticSelection<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.AutomaticSelection, false));
    /// <inheritdoc cref="SignToolSettings.AutomaticSelection"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AutomaticSelection))]
    public static T ToggleAutomaticSelection<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.AutomaticSelection, !o.AutomaticSelection));
    #endregion
    #region AdditionalCertificate
    /// <inheritdoc cref="SignToolSettings.AdditionalCertificate"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AdditionalCertificate))]
    public static T SetAdditionalCertificate<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.AdditionalCertificate, v));
    /// <inheritdoc cref="SignToolSettings.AdditionalCertificate"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AdditionalCertificate))]
    public static T ResetAdditionalCertificate<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.AdditionalCertificate));
    #endregion
    #region CertificateTemplateName
    /// <inheritdoc cref="SignToolSettings.CertificateTemplateName"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.CertificateTemplateName))]
    public static T SetCertificateTemplateName<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.CertificateTemplateName, v));
    /// <inheritdoc cref="SignToolSettings.CertificateTemplateName"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.CertificateTemplateName))]
    public static T ResetCertificateTemplateName<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.CertificateTemplateName));
    #endregion
    #region File
    /// <inheritdoc cref="SignToolSettings.File"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.File))]
    public static T SetFile<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.File, v));
    /// <inheritdoc cref="SignToolSettings.File"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.File))]
    public static T ResetFile<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.File));
    #endregion
    #region Issuer
    /// <inheritdoc cref="SignToolSettings.Issuer"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Issuer))]
    public static T SetIssuer<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Issuer, v));
    /// <inheritdoc cref="SignToolSettings.Issuer"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Issuer))]
    public static T ResetIssuer<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.Issuer));
    #endregion
    #region SigningSubjectName
    /// <inheritdoc cref="SignToolSettings.SigningSubjectName"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SigningSubjectName))]
    public static T SetSigningSubjectName<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SigningSubjectName, v));
    /// <inheritdoc cref="SignToolSettings.SigningSubjectName"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SigningSubjectName))]
    public static T ResetSigningSubjectName<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.SigningSubjectName));
    #endregion
    #region Password
    /// <inheritdoc cref="SignToolSettings.Password"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="SignToolSettings.Password"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region RootSubjectName
    /// <inheritdoc cref="SignToolSettings.RootSubjectName"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.RootSubjectName))]
    public static T SetRootSubjectName<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.RootSubjectName, v));
    /// <inheritdoc cref="SignToolSettings.RootSubjectName"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.RootSubjectName))]
    public static T ResetRootSubjectName<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.RootSubjectName));
    #endregion
    #region Store
    /// <inheritdoc cref="SignToolSettings.Store"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Store))]
    public static T SetStore<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Store, v));
    /// <inheritdoc cref="SignToolSettings.Store"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Store))]
    public static T ResetStore<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.Store));
    #endregion
    #region MachineStore
    /// <inheritdoc cref="SignToolSettings.MachineStore"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.MachineStore))]
    public static T SetMachineStore<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.MachineStore, v));
    /// <inheritdoc cref="SignToolSettings.MachineStore"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.MachineStore))]
    public static T ResetMachineStore<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.MachineStore));
    /// <inheritdoc cref="SignToolSettings.MachineStore"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.MachineStore))]
    public static T EnableMachineStore<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.MachineStore, true));
    /// <inheritdoc cref="SignToolSettings.MachineStore"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.MachineStore))]
    public static T DisableMachineStore<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.MachineStore, false));
    /// <inheritdoc cref="SignToolSettings.MachineStore"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.MachineStore))]
    public static T ToggleMachineStore<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.MachineStore, !o.MachineStore));
    #endregion
    #region Sha1Thumbprint
    /// <inheritdoc cref="SignToolSettings.Sha1Thumbprint"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Sha1Thumbprint))]
    public static T SetSha1Thumbprint<T>(this T o, [Secret] string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Sha1Thumbprint, v));
    /// <inheritdoc cref="SignToolSettings.Sha1Thumbprint"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Sha1Thumbprint))]
    public static T ResetSha1Thumbprint<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.Sha1Thumbprint));
    #endregion
    #region FileDigestAlgorithm
    /// <inheritdoc cref="SignToolSettings.FileDigestAlgorithm"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.FileDigestAlgorithm))]
    public static T SetFileDigestAlgorithm<T>(this T o, SignToolDigestAlgorithm v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.FileDigestAlgorithm, v));
    /// <inheritdoc cref="SignToolSettings.FileDigestAlgorithm"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.FileDigestAlgorithm))]
    public static T ResetFileDigestAlgorithm<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.FileDigestAlgorithm));
    #endregion
    #region EnhancedKeyUsage
    /// <inheritdoc cref="SignToolSettings.EnhancedKeyUsage"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.EnhancedKeyUsage))]
    public static T SetEnhancedKeyUsage<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.EnhancedKeyUsage, v));
    /// <inheritdoc cref="SignToolSettings.EnhancedKeyUsage"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.EnhancedKeyUsage))]
    public static T ResetEnhancedKeyUsage<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.EnhancedKeyUsage));
    #endregion
    #region WindowsSystemComponentVerification
    /// <inheritdoc cref="SignToolSettings.WindowsSystemComponentVerification"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.WindowsSystemComponentVerification))]
    public static T SetWindowsSystemComponentVerification<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.WindowsSystemComponentVerification, v));
    /// <inheritdoc cref="SignToolSettings.WindowsSystemComponentVerification"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.WindowsSystemComponentVerification))]
    public static T ResetWindowsSystemComponentVerification<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.WindowsSystemComponentVerification));
    /// <inheritdoc cref="SignToolSettings.WindowsSystemComponentVerification"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.WindowsSystemComponentVerification))]
    public static T EnableWindowsSystemComponentVerification<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.WindowsSystemComponentVerification, true));
    /// <inheritdoc cref="SignToolSettings.WindowsSystemComponentVerification"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.WindowsSystemComponentVerification))]
    public static T DisableWindowsSystemComponentVerification<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.WindowsSystemComponentVerification, false));
    /// <inheritdoc cref="SignToolSettings.WindowsSystemComponentVerification"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.WindowsSystemComponentVerification))]
    public static T ToggleWindowsSystemComponentVerification<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.WindowsSystemComponentVerification, !o.WindowsSystemComponentVerification));
    #endregion
    #region Csp
    /// <inheritdoc cref="SignToolSettings.Csp"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Csp))]
    public static T SetCsp<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Csp, v));
    /// <inheritdoc cref="SignToolSettings.Csp"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Csp))]
    public static T ResetCsp<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.Csp));
    #endregion
    #region KeyContainer
    /// <inheritdoc cref="SignToolSettings.KeyContainer"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.KeyContainer))]
    public static T SetKeyContainer<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.KeyContainer, v));
    /// <inheritdoc cref="SignToolSettings.KeyContainer"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.KeyContainer))]
    public static T ResetKeyContainer<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.KeyContainer));
    #endregion
    #region AppendSignature
    /// <inheritdoc cref="SignToolSettings.AppendSignature"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AppendSignature))]
    public static T SetAppendSignature<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.AppendSignature, v));
    /// <inheritdoc cref="SignToolSettings.AppendSignature"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AppendSignature))]
    public static T ResetAppendSignature<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.AppendSignature));
    /// <inheritdoc cref="SignToolSettings.AppendSignature"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AppendSignature))]
    public static T EnableAppendSignature<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.AppendSignature, true));
    /// <inheritdoc cref="SignToolSettings.AppendSignature"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AppendSignature))]
    public static T DisableAppendSignature<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.AppendSignature, false));
    /// <inheritdoc cref="SignToolSettings.AppendSignature"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AppendSignature))]
    public static T ToggleAppendSignature<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.AppendSignature, !o.AppendSignature));
    #endregion
    #region Description
    /// <inheritdoc cref="SignToolSettings.Description"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Description))]
    public static T SetDescription<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Description, v));
    /// <inheritdoc cref="SignToolSettings.Description"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Description))]
    public static T ResetDescription<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.Description));
    #endregion
    #region Url
    /// <inheritdoc cref="SignToolSettings.Url"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Url))]
    public static T SetUrl<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Url, v));
    /// <inheritdoc cref="SignToolSettings.Url"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Url))]
    public static T ResetUrl<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.Url));
    #endregion
    #region TimestampServerUrl
    /// <inheritdoc cref="SignToolSettings.TimestampServerUrl"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.TimestampServerUrl))]
    public static T SetTimestampServerUrl<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.TimestampServerUrl, v));
    /// <inheritdoc cref="SignToolSettings.TimestampServerUrl"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.TimestampServerUrl))]
    public static T ResetTimestampServerUrl<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.TimestampServerUrl));
    #endregion
    #region Rfc3161TimestampServerUrl
    /// <inheritdoc cref="SignToolSettings.Rfc3161TimestampServerUrl"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Rfc3161TimestampServerUrl))]
    public static T SetRfc3161TimestampServerUrl<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Rfc3161TimestampServerUrl, v));
    /// <inheritdoc cref="SignToolSettings.Rfc3161TimestampServerUrl"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Rfc3161TimestampServerUrl))]
    public static T ResetRfc3161TimestampServerUrl<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.Rfc3161TimestampServerUrl));
    #endregion
    #region Rfc3161TimestampServerUrlSealed
    /// <inheritdoc cref="SignToolSettings.Rfc3161TimestampServerUrlSealed"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Rfc3161TimestampServerUrlSealed))]
    public static T SetRfc3161TimestampServerUrlSealed<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Rfc3161TimestampServerUrlSealed, v));
    /// <inheritdoc cref="SignToolSettings.Rfc3161TimestampServerUrlSealed"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Rfc3161TimestampServerUrlSealed))]
    public static T ResetRfc3161TimestampServerUrlSealed<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.Rfc3161TimestampServerUrlSealed));
    #endregion
    #region TimestampServerDigestAlgorithm
    /// <inheritdoc cref="SignToolSettings.TimestampServerDigestAlgorithm"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.TimestampServerDigestAlgorithm))]
    public static T SetTimestampServerDigestAlgorithm<T>(this T o, SignToolDigestAlgorithm v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.TimestampServerDigestAlgorithm, v));
    /// <inheritdoc cref="SignToolSettings.TimestampServerDigestAlgorithm"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.TimestampServerDigestAlgorithm))]
    public static T ResetTimestampServerDigestAlgorithm<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.TimestampServerDigestAlgorithm));
    #endregion
    #region AuthenticatedAttributes
    /// <inheritdoc cref="SignToolSettings.AuthenticatedAttributes"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AuthenticatedAttributes))]
    public static T SetAuthenticatedAttributes<T>(this T o, IDictionary<string, string> v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.AuthenticatedAttributes, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="SignToolSettings.AuthenticatedAttributes"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AuthenticatedAttributes))]
    public static T SetAuthenticatedAttribute<T>(this T o, string k, string v) where T : SignToolSettings => o.Modify(b => b.SetDictionary(() => o.AuthenticatedAttributes, k, v));
    /// <inheritdoc cref="SignToolSettings.AuthenticatedAttributes"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AuthenticatedAttributes))]
    public static T AddAuthenticatedAttribute<T>(this T o, string k, string v) where T : SignToolSettings => o.Modify(b => b.AddDictionary(() => o.AuthenticatedAttributes, k, v));
    /// <inheritdoc cref="SignToolSettings.AuthenticatedAttributes"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AuthenticatedAttributes))]
    public static T RemoveAuthenticatedAttribute<T>(this T o, string k) where T : SignToolSettings => o.Modify(b => b.RemoveDictionary(() => o.AuthenticatedAttributes, k));
    /// <inheritdoc cref="SignToolSettings.AuthenticatedAttributes"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AuthenticatedAttributes))]
    public static T ClearAuthenticatedAttributes<T>(this T o) where T : SignToolSettings => o.Modify(b => b.ClearDictionary(() => o.AuthenticatedAttributes));
    #endregion
    #region SealingSignature
    /// <inheritdoc cref="SignToolSettings.SealingSignature"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SealingSignature))]
    public static T SetSealingSignature<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SealingSignature, v));
    /// <inheritdoc cref="SignToolSettings.SealingSignature"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SealingSignature))]
    public static T ResetSealingSignature<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.SealingSignature));
    /// <inheritdoc cref="SignToolSettings.SealingSignature"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SealingSignature))]
    public static T EnableSealingSignature<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SealingSignature, true));
    /// <inheritdoc cref="SignToolSettings.SealingSignature"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SealingSignature))]
    public static T DisableSealingSignature<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SealingSignature, false));
    /// <inheritdoc cref="SignToolSettings.SealingSignature"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SealingSignature))]
    public static T ToggleSealingSignature<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SealingSignature, !o.SealingSignature));
    #endregion
    #region IntentToSealAttribute
    /// <inheritdoc cref="SignToolSettings.IntentToSealAttribute"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.IntentToSealAttribute))]
    public static T SetIntentToSealAttribute<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.IntentToSealAttribute, v));
    /// <inheritdoc cref="SignToolSettings.IntentToSealAttribute"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.IntentToSealAttribute))]
    public static T ResetIntentToSealAttribute<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.IntentToSealAttribute));
    /// <inheritdoc cref="SignToolSettings.IntentToSealAttribute"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.IntentToSealAttribute))]
    public static T EnableIntentToSealAttribute<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.IntentToSealAttribute, true));
    /// <inheritdoc cref="SignToolSettings.IntentToSealAttribute"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.IntentToSealAttribute))]
    public static T DisableIntentToSealAttribute<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.IntentToSealAttribute, false));
    /// <inheritdoc cref="SignToolSettings.IntentToSealAttribute"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.IntentToSealAttribute))]
    public static T ToggleIntentToSealAttribute<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.IntentToSealAttribute, !o.IntentToSealAttribute));
    #endregion
    #region Force
    /// <inheritdoc cref="SignToolSettings.Force"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="SignToolSettings.Force"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Force))]
    public static T ResetForce<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="SignToolSettings.Force"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Force))]
    public static T EnableForce<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="SignToolSettings.Force"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Force))]
    public static T DisableForce<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="SignToolSettings.Force"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region NoSealWarn
    /// <inheritdoc cref="SignToolSettings.NoSealWarn"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.NoSealWarn))]
    public static T SetNoSealWarn<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.NoSealWarn, v));
    /// <inheritdoc cref="SignToolSettings.NoSealWarn"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.NoSealWarn))]
    public static T ResetNoSealWarn<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.NoSealWarn));
    /// <inheritdoc cref="SignToolSettings.NoSealWarn"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.NoSealWarn))]
    public static T EnableNoSealWarn<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.NoSealWarn, true));
    /// <inheritdoc cref="SignToolSettings.NoSealWarn"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.NoSealWarn))]
    public static T DisableNoSealWarn<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.NoSealWarn, false));
    /// <inheritdoc cref="SignToolSettings.NoSealWarn"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.NoSealWarn))]
    public static T ToggleNoSealWarn<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.NoSealWarn, !o.NoSealWarn));
    #endregion
    #region SignedDigestAndUnsignedPkcs7Path
    /// <inheritdoc cref="SignToolSettings.SignedDigestAndUnsignedPkcs7Path"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SignedDigestAndUnsignedPkcs7Path))]
    public static T SetSignedDigestAndUnsignedPkcs7Path<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SignedDigestAndUnsignedPkcs7Path, v));
    /// <inheritdoc cref="SignToolSettings.SignedDigestAndUnsignedPkcs7Path"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SignedDigestAndUnsignedPkcs7Path))]
    public static T ResetSignedDigestAndUnsignedPkcs7Path<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.SignedDigestAndUnsignedPkcs7Path));
    #endregion
    #region SignDigestOnly
    /// <inheritdoc cref="SignToolSettings.SignDigestOnly"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SignDigestOnly))]
    public static T SetSignDigestOnly<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SignDigestOnly, v));
    /// <inheritdoc cref="SignToolSettings.SignDigestOnly"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SignDigestOnly))]
    public static T ResetSignDigestOnly<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.SignDigestOnly));
    /// <inheritdoc cref="SignToolSettings.SignDigestOnly"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SignDigestOnly))]
    public static T EnableSignDigestOnly<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SignDigestOnly, true));
    /// <inheritdoc cref="SignToolSettings.SignDigestOnly"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SignDigestOnly))]
    public static T DisableSignDigestOnly<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SignDigestOnly, false));
    /// <inheritdoc cref="SignToolSettings.SignDigestOnly"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SignDigestOnly))]
    public static T ToggleSignDigestOnly<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SignDigestOnly, !o.SignDigestOnly));
    #endregion
    #region GenerateSignature
    /// <inheritdoc cref="SignToolSettings.GenerateSignature"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.GenerateSignature))]
    public static T SetGenerateSignature<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.GenerateSignature, v));
    /// <inheritdoc cref="SignToolSettings.GenerateSignature"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.GenerateSignature))]
    public static T ResetGenerateSignature<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.GenerateSignature));
    #endregion
    #region XmlFile
    /// <inheritdoc cref="SignToolSettings.XmlFile"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.XmlFile))]
    public static T SetXmlFile<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.XmlFile, v));
    /// <inheritdoc cref="SignToolSettings.XmlFile"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.XmlFile))]
    public static T ResetXmlFile<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.XmlFile));
    /// <inheritdoc cref="SignToolSettings.XmlFile"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.XmlFile))]
    public static T EnableXmlFile<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.XmlFile, true));
    /// <inheritdoc cref="SignToolSettings.XmlFile"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.XmlFile))]
    public static T DisableXmlFile<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.XmlFile, false));
    /// <inheritdoc cref="SignToolSettings.XmlFile"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.XmlFile))]
    public static T ToggleXmlFile<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.XmlFile, !o.XmlFile));
    #endregion
    #region AuthenticodeDigestSignLibDll
    /// <inheritdoc cref="SignToolSettings.AuthenticodeDigestSignLibDll"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AuthenticodeDigestSignLibDll))]
    public static T SetAuthenticodeDigestSignLibDll<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.AuthenticodeDigestSignLibDll, v));
    /// <inheritdoc cref="SignToolSettings.AuthenticodeDigestSignLibDll"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AuthenticodeDigestSignLibDll))]
    public static T ResetAuthenticodeDigestSignLibDll<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.AuthenticodeDigestSignLibDll));
    #endregion
    #region AuthenticodeDigestSignPassUnmodified
    /// <inheritdoc cref="SignToolSettings.AuthenticodeDigestSignPassUnmodified"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AuthenticodeDigestSignPassUnmodified))]
    public static T SetAuthenticodeDigestSignPassUnmodified<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.AuthenticodeDigestSignPassUnmodified, v));
    /// <inheritdoc cref="SignToolSettings.AuthenticodeDigestSignPassUnmodified"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.AuthenticodeDigestSignPassUnmodified))]
    public static T ResetAuthenticodeDigestSignPassUnmodified<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.AuthenticodeDigestSignPassUnmodified));
    #endregion
    #region ContentFileToPkcs7
    /// <inheritdoc cref="SignToolSettings.ContentFileToPkcs7"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.ContentFileToPkcs7))]
    public static T SetContentFileToPkcs7<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.ContentFileToPkcs7, v));
    /// <inheritdoc cref="SignToolSettings.ContentFileToPkcs7"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.ContentFileToPkcs7))]
    public static T ResetContentFileToPkcs7<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.ContentFileToPkcs7));
    #endregion
    #region SignedContentIdentifier
    /// <inheritdoc cref="SignToolSettings.SignedContentIdentifier"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SignedContentIdentifier))]
    public static T SetSignedContentIdentifier<T>(this T o, string v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SignedContentIdentifier, v));
    /// <inheritdoc cref="SignToolSettings.SignedContentIdentifier"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SignedContentIdentifier))]
    public static T ResetSignedContentIdentifier<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.SignedContentIdentifier));
    #endregion
    #region SignedContentMethod
    /// <inheritdoc cref="SignToolSettings.SignedContentMethod"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SignedContentMethod))]
    public static T SetSignedContentMethod<T>(this T o, SignToolContentMethod v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SignedContentMethod, v));
    /// <inheritdoc cref="SignToolSettings.SignedContentMethod"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SignedContentMethod))]
    public static T ResetSignedContentMethod<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.SignedContentMethod));
    #endregion
    #region PageHashes
    /// <inheritdoc cref="SignToolSettings.PageHashes"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.PageHashes))]
    public static T SetPageHashes<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.PageHashes, v));
    /// <inheritdoc cref="SignToolSettings.PageHashes"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.PageHashes))]
    public static T ResetPageHashes<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.PageHashes));
    /// <inheritdoc cref="SignToolSettings.PageHashes"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.PageHashes))]
    public static T EnablePageHashes<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.PageHashes, true));
    /// <inheritdoc cref="SignToolSettings.PageHashes"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.PageHashes))]
    public static T DisablePageHashes<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.PageHashes, false));
    /// <inheritdoc cref="SignToolSettings.PageHashes"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.PageHashes))]
    public static T TogglePageHashes<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.PageHashes, !o.PageHashes));
    #endregion
    #region SuppressPageHashes
    /// <inheritdoc cref="SignToolSettings.SuppressPageHashes"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SuppressPageHashes))]
    public static T SetSuppressPageHashes<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SuppressPageHashes, v));
    /// <inheritdoc cref="SignToolSettings.SuppressPageHashes"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SuppressPageHashes))]
    public static T ResetSuppressPageHashes<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.SuppressPageHashes));
    /// <inheritdoc cref="SignToolSettings.SuppressPageHashes"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SuppressPageHashes))]
    public static T EnableSuppressPageHashes<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SuppressPageHashes, true));
    /// <inheritdoc cref="SignToolSettings.SuppressPageHashes"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SuppressPageHashes))]
    public static T DisableSuppressPageHashes<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SuppressPageHashes, false));
    /// <inheritdoc cref="SignToolSettings.SuppressPageHashes"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.SuppressPageHashes))]
    public static T ToggleSuppressPageHashes<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.SuppressPageHashes, !o.SuppressPageHashes));
    #endregion
    #region RelaxedMarkerCheck
    /// <inheritdoc cref="SignToolSettings.RelaxedMarkerCheck"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.RelaxedMarkerCheck))]
    public static T SetRelaxedMarkerCheck<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.RelaxedMarkerCheck, v));
    /// <inheritdoc cref="SignToolSettings.RelaxedMarkerCheck"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.RelaxedMarkerCheck))]
    public static T ResetRelaxedMarkerCheck<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.RelaxedMarkerCheck));
    /// <inheritdoc cref="SignToolSettings.RelaxedMarkerCheck"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.RelaxedMarkerCheck))]
    public static T EnableRelaxedMarkerCheck<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.RelaxedMarkerCheck, true));
    /// <inheritdoc cref="SignToolSettings.RelaxedMarkerCheck"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.RelaxedMarkerCheck))]
    public static T DisableRelaxedMarkerCheck<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.RelaxedMarkerCheck, false));
    /// <inheritdoc cref="SignToolSettings.RelaxedMarkerCheck"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.RelaxedMarkerCheck))]
    public static T ToggleRelaxedMarkerCheck<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.RelaxedMarkerCheck, !o.RelaxedMarkerCheck));
    #endregion
    #region Quiet
    /// <inheritdoc cref="SignToolSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Quiet))]
    public static T SetQuiet<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Quiet, v));
    /// <inheritdoc cref="SignToolSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Quiet))]
    public static T ResetQuiet<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.Quiet));
    /// <inheritdoc cref="SignToolSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Quiet))]
    public static T EnableQuiet<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Quiet, true));
    /// <inheritdoc cref="SignToolSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Quiet))]
    public static T DisableQuiet<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Quiet, false));
    /// <inheritdoc cref="SignToolSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Quiet))]
    public static T ToggleQuiet<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Quiet, !o.Quiet));
    #endregion
    #region Verbose
    /// <inheritdoc cref="SignToolSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="SignToolSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="SignToolSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="SignToolSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="SignToolSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region Debug
    /// <inheritdoc cref="SignToolSettings.Debug"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="SignToolSettings.Debug"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="SignToolSettings.Debug"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="SignToolSettings.Debug"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="SignToolSettings.Debug"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region Files
    /// <inheritdoc cref="SignToolSettings.Files"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Files))]
    public static T SetFiles<T>(this T o, params string[] v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Files, v));
    /// <inheritdoc cref="SignToolSettings.Files"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Files))]
    public static T SetFiles<T>(this T o, IEnumerable<string> v) where T : SignToolSettings => o.Modify(b => b.Set(() => o.Files, v));
    /// <inheritdoc cref="SignToolSettings.Files"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Files))]
    public static T AddFiles<T>(this T o, params string[] v) where T : SignToolSettings => o.Modify(b => b.AddCollection(() => o.Files, v));
    /// <inheritdoc cref="SignToolSettings.Files"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Files))]
    public static T AddFiles<T>(this T o, IEnumerable<string> v) where T : SignToolSettings => o.Modify(b => b.AddCollection(() => o.Files, v));
    /// <inheritdoc cref="SignToolSettings.Files"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Files))]
    public static T RemoveFiles<T>(this T o, params string[] v) where T : SignToolSettings => o.Modify(b => b.RemoveCollection(() => o.Files, v));
    /// <inheritdoc cref="SignToolSettings.Files"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Files))]
    public static T RemoveFiles<T>(this T o, IEnumerable<string> v) where T : SignToolSettings => o.Modify(b => b.RemoveCollection(() => o.Files, v));
    /// <inheritdoc cref="SignToolSettings.Files"/>
    [Pure] [Builder(Type = typeof(SignToolSettings), Property = nameof(SignToolSettings.Files))]
    public static T ClearFiles<T>(this T o) where T : SignToolSettings => o.Modify(b => b.ClearCollection(() => o.Files));
    #endregion
}
#endregion
#region SignToolContentMethod
/// <summary>Used within <see cref="SignToolTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SignToolContentMethod>))]
public partial class SignToolContentMethod : Enumeration
{
    public static SignToolContentMethod Embedded = (SignToolContentMethod) "Embedded";
    public static SignToolContentMethod DetachedSignedData = (SignToolContentMethod) "DetachedSignedData";
    public static implicit operator SignToolContentMethod(string value)
    {
        return new SignToolContentMethod { Value = value };
    }
}
#endregion
#region SignToolDigestAlgorithm
/// <summary>Used within <see cref="SignToolTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SignToolDigestAlgorithm>))]
public partial class SignToolDigestAlgorithm : Enumeration
{
    public static SignToolDigestAlgorithm SHA1 = (SignToolDigestAlgorithm) "SHA1";
    public static SignToolDigestAlgorithm SHA256 = (SignToolDigestAlgorithm) "SHA256";
    public static implicit operator SignToolDigestAlgorithm(string value)
    {
        return new SignToolDigestAlgorithm { Value = value };
    }
}
#endregion
