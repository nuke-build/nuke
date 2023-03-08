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

namespace Nuke.Common.Tools.SignTool
{
    /// <summary>
    ///   <p>Sign Tool is a command-line tool that digitally signs files, verifies signatures in files, and time-stamps files.</p>
    ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/signtool-exe">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public partial class SignToolTasks
    {
        /// <summary>
        ///   Path to the SignTool executable.
        /// </summary>
        public static string SignToolPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("SIGNTOOL_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> SignToolLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Sign Tool is a command-line tool that digitally signs files, verifies signatures in files, and time-stamps files.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/signtool-exe">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> SignTool(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(SignToolPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? SignToolLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Use the <c>sign</c> command to sign files using embedded signatures. Signing protects a file from tampering, and allows users to verify the signer (you) based on a signing certificate. The options below allow you to specify signing parameters and to select the signing certificate you wish to use.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/signtool-exe">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;files&gt;</c> via <see cref="SignToolSettings.Files"/></li>
        ///     <li><c>/a</c> via <see cref="SignToolSettings.AutomaticSelection"/></li>
        ///     <li><c>/ac</c> via <see cref="SignToolSettings.AdditionalCertificate"/></li>
        ///     <li><c>/as</c> via <see cref="SignToolSettings.AppendSignature"/></li>
        ///     <li><c>/c</c> via <see cref="SignToolSettings.CertificateTemplateName"/></li>
        ///     <li><c>/csp</c> via <see cref="SignToolSettings.Csp"/></li>
        ///     <li><c>/d</c> via <see cref="SignToolSettings.Description"/></li>
        ///     <li><c>/debug</c> via <see cref="SignToolSettings.Debug"/></li>
        ///     <li><c>/dg</c> via <see cref="SignToolSettings.SignedDigestAndUnsignedPkcs7Path"/></li>
        ///     <li><c>/di</c> via <see cref="SignToolSettings.GenerateSignature"/></li>
        ///     <li><c>/dlib</c> via <see cref="SignToolSettings.AuthenticodeDigestSignLibDll"/></li>
        ///     <li><c>/dmdf</c> via <see cref="SignToolSettings.AuthenticodeDigestSignPassUnmodified"/></li>
        ///     <li><c>/ds</c> via <see cref="SignToolSettings.SignDigestOnly"/></li>
        ///     <li><c>/du</c> via <see cref="SignToolSettings.Url"/></li>
        ///     <li><c>/dxml</c> via <see cref="SignToolSettings.XmlFile"/></li>
        ///     <li><c>/f</c> via <see cref="SignToolSettings.File"/></li>
        ///     <li><c>/fd</c> via <see cref="SignToolSettings.FileDigestAlgorithm"/></li>
        ///     <li><c>/force</c> via <see cref="SignToolSettings.Force"/></li>
        ///     <li><c>/i</c> via <see cref="SignToolSettings.Issuer"/></li>
        ///     <li><c>/itos</c> via <see cref="SignToolSettings.IntentToSealAttribute"/></li>
        ///     <li><c>/kc</c> via <see cref="SignToolSettings.KeyContainer"/></li>
        ///     <li><c>/n</c> via <see cref="SignToolSettings.SigningSubjectName"/></li>
        ///     <li><c>/nosealwarn</c> via <see cref="SignToolSettings.NoSealWarn"/></li>
        ///     <li><c>/nph</c> via <see cref="SignToolSettings.SuppressPageHashes"/></li>
        ///     <li><c>/p</c> via <see cref="SignToolSettings.Password"/></li>
        ///     <li><c>/p7</c> via <see cref="SignToolSettings.ContentFileToPkcs7"/></li>
        ///     <li><c>/p7ce</c> via <see cref="SignToolSettings.SignedContentMethod"/></li>
        ///     <li><c>/p7co</c> via <see cref="SignToolSettings.SignedContentIdentifier"/></li>
        ///     <li><c>/ph</c> via <see cref="SignToolSettings.PageHashes"/></li>
        ///     <li><c>/q</c> via <see cref="SignToolSettings.Quiet"/></li>
        ///     <li><c>/r</c> via <see cref="SignToolSettings.RootSubjectName"/></li>
        ///     <li><c>/rmc</c> via <see cref="SignToolSettings.RelaxedMarkerCheck"/></li>
        ///     <li><c>/s</c> via <see cref="SignToolSettings.Store"/></li>
        ///     <li><c>/sa</c> via <see cref="SignToolSettings.AuthenticatedAttributes"/></li>
        ///     <li><c>/seal</c> via <see cref="SignToolSettings.SealingSignature"/></li>
        ///     <li><c>/sha1</c> via <see cref="SignToolSettings.Sha1Thumbprint"/></li>
        ///     <li><c>/sm</c> via <see cref="SignToolSettings.MachineStore"/></li>
        ///     <li><c>/t</c> via <see cref="SignToolSettings.TimestampServerUrl"/></li>
        ///     <li><c>/td</c> via <see cref="SignToolSettings.TimestampServerDigestAlgorithm"/></li>
        ///     <li><c>/tr</c> via <see cref="SignToolSettings.Rfc3161TimestampServerUrl"/></li>
        ///     <li><c>/tseal</c> via <see cref="SignToolSettings.Rfc3161TimestampServerUrlSealed"/></li>
        ///     <li><c>/u</c> via <see cref="SignToolSettings.EnhancedKeyUsage"/></li>
        ///     <li><c>/uw</c> via <see cref="SignToolSettings.WindowsSystemComponentVerification"/></li>
        ///     <li><c>/v</c> via <see cref="SignToolSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> SignTool(SignToolSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new SignToolSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Use the <c>sign</c> command to sign files using embedded signatures. Signing protects a file from tampering, and allows users to verify the signer (you) based on a signing certificate. The options below allow you to specify signing parameters and to select the signing certificate you wish to use.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/signtool-exe">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;files&gt;</c> via <see cref="SignToolSettings.Files"/></li>
        ///     <li><c>/a</c> via <see cref="SignToolSettings.AutomaticSelection"/></li>
        ///     <li><c>/ac</c> via <see cref="SignToolSettings.AdditionalCertificate"/></li>
        ///     <li><c>/as</c> via <see cref="SignToolSettings.AppendSignature"/></li>
        ///     <li><c>/c</c> via <see cref="SignToolSettings.CertificateTemplateName"/></li>
        ///     <li><c>/csp</c> via <see cref="SignToolSettings.Csp"/></li>
        ///     <li><c>/d</c> via <see cref="SignToolSettings.Description"/></li>
        ///     <li><c>/debug</c> via <see cref="SignToolSettings.Debug"/></li>
        ///     <li><c>/dg</c> via <see cref="SignToolSettings.SignedDigestAndUnsignedPkcs7Path"/></li>
        ///     <li><c>/di</c> via <see cref="SignToolSettings.GenerateSignature"/></li>
        ///     <li><c>/dlib</c> via <see cref="SignToolSettings.AuthenticodeDigestSignLibDll"/></li>
        ///     <li><c>/dmdf</c> via <see cref="SignToolSettings.AuthenticodeDigestSignPassUnmodified"/></li>
        ///     <li><c>/ds</c> via <see cref="SignToolSettings.SignDigestOnly"/></li>
        ///     <li><c>/du</c> via <see cref="SignToolSettings.Url"/></li>
        ///     <li><c>/dxml</c> via <see cref="SignToolSettings.XmlFile"/></li>
        ///     <li><c>/f</c> via <see cref="SignToolSettings.File"/></li>
        ///     <li><c>/fd</c> via <see cref="SignToolSettings.FileDigestAlgorithm"/></li>
        ///     <li><c>/force</c> via <see cref="SignToolSettings.Force"/></li>
        ///     <li><c>/i</c> via <see cref="SignToolSettings.Issuer"/></li>
        ///     <li><c>/itos</c> via <see cref="SignToolSettings.IntentToSealAttribute"/></li>
        ///     <li><c>/kc</c> via <see cref="SignToolSettings.KeyContainer"/></li>
        ///     <li><c>/n</c> via <see cref="SignToolSettings.SigningSubjectName"/></li>
        ///     <li><c>/nosealwarn</c> via <see cref="SignToolSettings.NoSealWarn"/></li>
        ///     <li><c>/nph</c> via <see cref="SignToolSettings.SuppressPageHashes"/></li>
        ///     <li><c>/p</c> via <see cref="SignToolSettings.Password"/></li>
        ///     <li><c>/p7</c> via <see cref="SignToolSettings.ContentFileToPkcs7"/></li>
        ///     <li><c>/p7ce</c> via <see cref="SignToolSettings.SignedContentMethod"/></li>
        ///     <li><c>/p7co</c> via <see cref="SignToolSettings.SignedContentIdentifier"/></li>
        ///     <li><c>/ph</c> via <see cref="SignToolSettings.PageHashes"/></li>
        ///     <li><c>/q</c> via <see cref="SignToolSettings.Quiet"/></li>
        ///     <li><c>/r</c> via <see cref="SignToolSettings.RootSubjectName"/></li>
        ///     <li><c>/rmc</c> via <see cref="SignToolSettings.RelaxedMarkerCheck"/></li>
        ///     <li><c>/s</c> via <see cref="SignToolSettings.Store"/></li>
        ///     <li><c>/sa</c> via <see cref="SignToolSettings.AuthenticatedAttributes"/></li>
        ///     <li><c>/seal</c> via <see cref="SignToolSettings.SealingSignature"/></li>
        ///     <li><c>/sha1</c> via <see cref="SignToolSettings.Sha1Thumbprint"/></li>
        ///     <li><c>/sm</c> via <see cref="SignToolSettings.MachineStore"/></li>
        ///     <li><c>/t</c> via <see cref="SignToolSettings.TimestampServerUrl"/></li>
        ///     <li><c>/td</c> via <see cref="SignToolSettings.TimestampServerDigestAlgorithm"/></li>
        ///     <li><c>/tr</c> via <see cref="SignToolSettings.Rfc3161TimestampServerUrl"/></li>
        ///     <li><c>/tseal</c> via <see cref="SignToolSettings.Rfc3161TimestampServerUrlSealed"/></li>
        ///     <li><c>/u</c> via <see cref="SignToolSettings.EnhancedKeyUsage"/></li>
        ///     <li><c>/uw</c> via <see cref="SignToolSettings.WindowsSystemComponentVerification"/></li>
        ///     <li><c>/v</c> via <see cref="SignToolSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> SignTool(Configure<SignToolSettings> configurator)
        {
            return SignTool(configurator(new SignToolSettings()));
        }
        /// <summary>
        ///   <p>Use the <c>sign</c> command to sign files using embedded signatures. Signing protects a file from tampering, and allows users to verify the signer (you) based on a signing certificate. The options below allow you to specify signing parameters and to select the signing certificate you wish to use.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/signtool-exe">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;files&gt;</c> via <see cref="SignToolSettings.Files"/></li>
        ///     <li><c>/a</c> via <see cref="SignToolSettings.AutomaticSelection"/></li>
        ///     <li><c>/ac</c> via <see cref="SignToolSettings.AdditionalCertificate"/></li>
        ///     <li><c>/as</c> via <see cref="SignToolSettings.AppendSignature"/></li>
        ///     <li><c>/c</c> via <see cref="SignToolSettings.CertificateTemplateName"/></li>
        ///     <li><c>/csp</c> via <see cref="SignToolSettings.Csp"/></li>
        ///     <li><c>/d</c> via <see cref="SignToolSettings.Description"/></li>
        ///     <li><c>/debug</c> via <see cref="SignToolSettings.Debug"/></li>
        ///     <li><c>/dg</c> via <see cref="SignToolSettings.SignedDigestAndUnsignedPkcs7Path"/></li>
        ///     <li><c>/di</c> via <see cref="SignToolSettings.GenerateSignature"/></li>
        ///     <li><c>/dlib</c> via <see cref="SignToolSettings.AuthenticodeDigestSignLibDll"/></li>
        ///     <li><c>/dmdf</c> via <see cref="SignToolSettings.AuthenticodeDigestSignPassUnmodified"/></li>
        ///     <li><c>/ds</c> via <see cref="SignToolSettings.SignDigestOnly"/></li>
        ///     <li><c>/du</c> via <see cref="SignToolSettings.Url"/></li>
        ///     <li><c>/dxml</c> via <see cref="SignToolSettings.XmlFile"/></li>
        ///     <li><c>/f</c> via <see cref="SignToolSettings.File"/></li>
        ///     <li><c>/fd</c> via <see cref="SignToolSettings.FileDigestAlgorithm"/></li>
        ///     <li><c>/force</c> via <see cref="SignToolSettings.Force"/></li>
        ///     <li><c>/i</c> via <see cref="SignToolSettings.Issuer"/></li>
        ///     <li><c>/itos</c> via <see cref="SignToolSettings.IntentToSealAttribute"/></li>
        ///     <li><c>/kc</c> via <see cref="SignToolSettings.KeyContainer"/></li>
        ///     <li><c>/n</c> via <see cref="SignToolSettings.SigningSubjectName"/></li>
        ///     <li><c>/nosealwarn</c> via <see cref="SignToolSettings.NoSealWarn"/></li>
        ///     <li><c>/nph</c> via <see cref="SignToolSettings.SuppressPageHashes"/></li>
        ///     <li><c>/p</c> via <see cref="SignToolSettings.Password"/></li>
        ///     <li><c>/p7</c> via <see cref="SignToolSettings.ContentFileToPkcs7"/></li>
        ///     <li><c>/p7ce</c> via <see cref="SignToolSettings.SignedContentMethod"/></li>
        ///     <li><c>/p7co</c> via <see cref="SignToolSettings.SignedContentIdentifier"/></li>
        ///     <li><c>/ph</c> via <see cref="SignToolSettings.PageHashes"/></li>
        ///     <li><c>/q</c> via <see cref="SignToolSettings.Quiet"/></li>
        ///     <li><c>/r</c> via <see cref="SignToolSettings.RootSubjectName"/></li>
        ///     <li><c>/rmc</c> via <see cref="SignToolSettings.RelaxedMarkerCheck"/></li>
        ///     <li><c>/s</c> via <see cref="SignToolSettings.Store"/></li>
        ///     <li><c>/sa</c> via <see cref="SignToolSettings.AuthenticatedAttributes"/></li>
        ///     <li><c>/seal</c> via <see cref="SignToolSettings.SealingSignature"/></li>
        ///     <li><c>/sha1</c> via <see cref="SignToolSettings.Sha1Thumbprint"/></li>
        ///     <li><c>/sm</c> via <see cref="SignToolSettings.MachineStore"/></li>
        ///     <li><c>/t</c> via <see cref="SignToolSettings.TimestampServerUrl"/></li>
        ///     <li><c>/td</c> via <see cref="SignToolSettings.TimestampServerDigestAlgorithm"/></li>
        ///     <li><c>/tr</c> via <see cref="SignToolSettings.Rfc3161TimestampServerUrl"/></li>
        ///     <li><c>/tseal</c> via <see cref="SignToolSettings.Rfc3161TimestampServerUrlSealed"/></li>
        ///     <li><c>/u</c> via <see cref="SignToolSettings.EnhancedKeyUsage"/></li>
        ///     <li><c>/uw</c> via <see cref="SignToolSettings.WindowsSystemComponentVerification"/></li>
        ///     <li><c>/v</c> via <see cref="SignToolSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(SignToolSettings Settings, IReadOnlyCollection<Output> Output)> SignTool(CombinatorialConfigure<SignToolSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(SignTool, SignToolLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region SignToolSettings
    /// <summary>
    ///   Used within <see cref="SignToolTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SignToolSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the SignTool executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? SignToolTasks.SignToolPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? SignToolTasks.SignToolLogger;
        /// <summary>
        ///   Select the best signing cert automatically. SignTool will find all valid certs that satisfy all specified conditions and select the one that is valid for the longest. If this option is not present, SignTool will expect to find only one valid signing cert.
        /// </summary>
        public virtual bool? AutomaticSelection { get; internal set; }
        /// <summary>
        ///   Add an additional certificate to the signature block.
        /// </summary>
        public virtual string AdditionalCertificate { get; internal set; }
        /// <summary>
        ///   Specify the Certificate Template Name (Microsoft extension) of the signing cert.
        /// </summary>
        public virtual string CertificateTemplateName { get; internal set; }
        /// <summary>
        ///   Specify the signing cert in a file. If this file is a PFX with a password, the password may be supplied with the <c>/p</c> option. If the file does not contain private keys, use the <c>/csp</c> and <c>/kc</c> options to specify the CSP and container name of the private key.
        /// </summary>
        public virtual string File { get; internal set; }
        /// <summary>
        ///   Specify the Issuer of the signing cert, or a substring.
        /// </summary>
        public virtual string Issuer { get; internal set; }
        /// <summary>
        ///   Specify the Subject Name of the signing cert, or a substring.
        /// </summary>
        public virtual string SigningSubjectName { get; internal set; }
        /// <summary>
        ///   Specify a password to use when opening the PFX file.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Specify the Subject Name of a Root cert that the signing cert must chain to.
        /// </summary>
        public virtual string RootSubjectName { get; internal set; }
        /// <summary>
        ///   Specify the Store to open when searching for the cert. The default is the <c>MY</c> Store.
        /// </summary>
        public virtual string Store { get; internal set; }
        /// <summary>
        ///   Open a Machine store instead of a User store.
        /// </summary>
        public virtual bool? MachineStore { get; internal set; }
        /// <summary>
        ///   Specify the SHA1 thumbprint of the signing cert.
        /// </summary>
        public virtual string Sha1Thumbprint { get; internal set; }
        /// <summary>
        ///   Specifies the file digest algorithm to use for creating file signatures. (Default is <c>SHA1</c>)
        /// </summary>
        public virtual SignToolDigestAlgorithm FileDigestAlgorithm { get; internal set; }
        /// <summary>
        ///   Specify the Enhanced Key Usage that must be present in the cert.<para/>The parameter may be specified by OID or by string. The default usage is <em>Code Signing</em> (1.3.6.1.5.5.7.3.3).
        /// </summary>
        public virtual string EnhancedKeyUsage { get; internal set; }
        /// <summary>
        ///   Specify usage of <em>Windows System Component Verification</em> (1.3.6.1.4.1.311.10.3.6).
        /// </summary>
        public virtual bool? WindowsSystemComponentVerification { get; internal set; }
        /// <summary>
        ///   Specify the CSP containing the Private Key Container.
        /// </summary>
        public virtual string Csp { get; internal set; }
        /// <summary>
        ///   Specify the Key Container Name of the Private Key.
        /// </summary>
        public virtual string KeyContainer { get; internal set; }
        /// <summary>
        ///   Append this signature. If no primary signature is present, this signature will be made the primary signature instead.
        /// </summary>
        public virtual bool? AppendSignature { get; internal set; }
        /// <summary>
        ///   Provide a description of the signed content.
        /// </summary>
        public virtual string Description { get; internal set; }
        /// <summary>
        ///   Provide a URL with more information about the signed content.
        /// </summary>
        public virtual string Url { get; internal set; }
        /// <summary>
        ///   Specify the timestamp server's URL. If this option is not present, the signed file will not be timestamped. A warning is generated if timestamping fails.
        /// </summary>
        public virtual string TimestampServerUrl { get; internal set; }
        /// <summary>
        ///   Specifies the RFC 3161 timestamp server's URL. If this option (or <c>/t</c>) is not specified, the signed file will not be timestamped. A warning is generated if timestamping fails. This switch cannot be used with the <c>/t</c> switch.
        /// </summary>
        public virtual string Rfc3161TimestampServerUrl { get; internal set; }
        /// <summary>
        ///   Specifies the RFC 3161 timestamp server's URL for timestamping a sealed file.
        /// </summary>
        public virtual string Rfc3161TimestampServerUrlSealed { get; internal set; }
        /// <summary>
        ///   Used with the <c>/tr</c> or <c>/tseal</c> switch to request a digest algorithm used by the RFC 3161 timestamp server.
        /// </summary>
        public virtual SignToolDigestAlgorithm TimestampServerDigestAlgorithm { get; internal set; }
        /// <summary>
        ///   Specify an OID and value to be included as an authenticated attribute in the signature. The value will be encoded as an ASN1 UTF8 string. This option may be given multiple times.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> AuthenticatedAttributes => AuthenticatedAttributesInternal.AsReadOnly();
        internal Dictionary<string, string> AuthenticatedAttributesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Add a sealing signature if the file format supports it.
        /// </summary>
        public virtual bool? SealingSignature { get; internal set; }
        /// <summary>
        ///   Create a primary signature with the intent-to-seal attribute.
        /// </summary>
        public virtual bool? IntentToSealAttribute { get; internal set; }
        /// <summary>
        ///   Continue to seal or sign in situations where the existing signature or sealing signature needs to be removed to support sealing.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Sealing-related warnings do not affect SignTool's return code.
        /// </summary>
        public virtual bool? NoSealWarn { get; internal set; }
        /// <summary>
        ///   Generates the to be signed digest and the unsigned PKCS7 files. The output digest and PKCS7 files will be: <c>&lt;path&gt;\&lt;file&gt;.dig</c> and <c>&lt;path&gt;\&lt;file&gt;.p7u</c>. To output an additional XML file, see <c>/dxml</c>.
        /// </summary>
        public virtual string SignedDigestAndUnsignedPkcs7Path { get; internal set; }
        /// <summary>
        ///   Signs the digest only. The input file should be the digest generated by the <c>/dg</c> option. The output file will be: <c>&lt;file&gt;.signed</c>.
        /// </summary>
        public virtual bool? SignDigestOnly { get; internal set; }
        /// <summary>
        ///   Creates the signature by ingesting the signed digest to the unsigned PKCS7 file. The input signed digest and unsigned PKCS7 files should be: <c>&lt;path&gt;\&lt;file&gt;.dig.signed</c> and <c>&lt;path&gt;\&lt;file&gt;.p7u</c>.
        /// </summary>
        public virtual string GenerateSignature { get; internal set; }
        /// <summary>
        ///   When used with the <c>/dg</c> option, produces an XML file. The output file will be: <c>&lt;path&gt;\&lt;file&gt;.dig.xml</c>.
        /// </summary>
        public virtual bool? XmlFile { get; internal set; }
        /// <summary>
        ///   Specifies the DLL implementing the AuthenticodeDigestSign function to sign the digest with. This option is equivalent to using SignTool separately with the <c>/dg</c>, <c>/ds</c>, and <c>/di</c> switches, except this option invokes all three as one atomic operation.
        /// </summary>
        public virtual string AuthenticodeDigestSignLibDll { get; internal set; }
        /// <summary>
        ///   When used with the <c>/dlib</c> option, passes the file's contents to the AuthenticodeDigestSign function without modification.
        /// </summary>
        public virtual string AuthenticodeDigestSignPassUnmodified { get; internal set; }
        /// <summary>
        ///   Specifies that for each specified content file a PKCS7 file is produced. The PKCS7 file will be named: <c>&lt;path&gt;\&lt;file&gt;.p7</c>
        /// </summary>
        public virtual string ContentFileToPkcs7 { get; internal set; }
        /// <summary>
        ///   Specifies the <c>&lt;OID&gt;</c> that identifies the signed content.
        /// </summary>
        public virtual string SignedContentIdentifier { get; internal set; }
        /// <summary>
        ///   efined values:<ul><li><b>Embedded:</b> Embeds the signed content in the PKCS7.</li><li><b>DetachedSignedData:</b> Produces the signed data part of a detached PKCS7.</li></ul>The default is <c>Embedded</c>.
        /// </summary>
        public virtual SignToolContentMethod SignedContentMethod { get; internal set; }
        /// <summary>
        ///   Generate page hashes for executable files if supported.
        /// </summary>
        public virtual bool? PageHashes { get; internal set; }
        /// <summary>
        ///   Suppress page hashes for executable files if supported. The default is determined by the <c>SIGNTOOL_PAGE_HASHES</c> environment variable and by the <em>wintrust.dll</em> version.
        /// </summary>
        public virtual bool? SuppressPageHashes { get; internal set; }
        /// <summary>
        ///   Specifies signing a PE file with the relaxed marker check semantic. The flag is ignored for non-PE files. During verification, certain authenticated sections of the signature will bypass invalid PE markers check. This option should only be used after careful consideration and reviewing the details of MSRC case MS12-024 to ensure that no vulnerabilities are introduced.
        /// </summary>
        public virtual bool? RelaxedMarkerCheck { get; internal set; }
        /// <summary>
        ///   No output on success and minimal output on failure.
        /// </summary>
        public virtual bool? Quiet { get; internal set; }
        /// <summary>
        ///   Print verbose success and status messages. This may also provide slightly more information on error.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Display additional debug information.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Files to sign.
        /// </summary>
        public virtual IReadOnlyList<string> Files => FilesInternal.AsReadOnly();
        internal List<string> FilesInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
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
              .Add("/dmdf {value}", AuthenticodeDigestSignPassUnmodified)
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
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region SignToolSettingsExtensions
    /// <summary>
    ///   Used within <see cref="SignToolTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SignToolSettingsExtensions
    {
        #region AutomaticSelection
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.AutomaticSelection"/></em></p>
        ///   <p>Select the best signing cert automatically. SignTool will find all valid certs that satisfy all specified conditions and select the one that is valid for the longest. If this option is not present, SignTool will expect to find only one valid signing cert.</p>
        /// </summary>
        [Pure]
        public static T SetAutomaticSelection<T>(this T toolSettings, bool? automaticSelection) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutomaticSelection = automaticSelection;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.AutomaticSelection"/></em></p>
        ///   <p>Select the best signing cert automatically. SignTool will find all valid certs that satisfy all specified conditions and select the one that is valid for the longest. If this option is not present, SignTool will expect to find only one valid signing cert.</p>
        /// </summary>
        [Pure]
        public static T ResetAutomaticSelection<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutomaticSelection = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.AutomaticSelection"/></em></p>
        ///   <p>Select the best signing cert automatically. SignTool will find all valid certs that satisfy all specified conditions and select the one that is valid for the longest. If this option is not present, SignTool will expect to find only one valid signing cert.</p>
        /// </summary>
        [Pure]
        public static T EnableAutomaticSelection<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutomaticSelection = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.AutomaticSelection"/></em></p>
        ///   <p>Select the best signing cert automatically. SignTool will find all valid certs that satisfy all specified conditions and select the one that is valid for the longest. If this option is not present, SignTool will expect to find only one valid signing cert.</p>
        /// </summary>
        [Pure]
        public static T DisableAutomaticSelection<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutomaticSelection = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.AutomaticSelection"/></em></p>
        ///   <p>Select the best signing cert automatically. SignTool will find all valid certs that satisfy all specified conditions and select the one that is valid for the longest. If this option is not present, SignTool will expect to find only one valid signing cert.</p>
        /// </summary>
        [Pure]
        public static T ToggleAutomaticSelection<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutomaticSelection = !toolSettings.AutomaticSelection;
            return toolSettings;
        }
        #endregion
        #region AdditionalCertificate
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.AdditionalCertificate"/></em></p>
        ///   <p>Add an additional certificate to the signature block.</p>
        /// </summary>
        [Pure]
        public static T SetAdditionalCertificate<T>(this T toolSettings, string additionalCertificate) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalCertificate = additionalCertificate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.AdditionalCertificate"/></em></p>
        ///   <p>Add an additional certificate to the signature block.</p>
        /// </summary>
        [Pure]
        public static T ResetAdditionalCertificate<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalCertificate = null;
            return toolSettings;
        }
        #endregion
        #region CertificateTemplateName
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.CertificateTemplateName"/></em></p>
        ///   <p>Specify the Certificate Template Name (Microsoft extension) of the signing cert.</p>
        /// </summary>
        [Pure]
        public static T SetCertificateTemplateName<T>(this T toolSettings, string certificateTemplateName) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertificateTemplateName = certificateTemplateName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.CertificateTemplateName"/></em></p>
        ///   <p>Specify the Certificate Template Name (Microsoft extension) of the signing cert.</p>
        /// </summary>
        [Pure]
        public static T ResetCertificateTemplateName<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertificateTemplateName = null;
            return toolSettings;
        }
        #endregion
        #region File
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.File"/></em></p>
        ///   <p>Specify the signing cert in a file. If this file is a PFX with a password, the password may be supplied with the <c>/p</c> option. If the file does not contain private keys, use the <c>/csp</c> and <c>/kc</c> options to specify the CSP and container name of the private key.</p>
        /// </summary>
        [Pure]
        public static T SetFile<T>(this T toolSettings, string file) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = file;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.File"/></em></p>
        ///   <p>Specify the signing cert in a file. If this file is a PFX with a password, the password may be supplied with the <c>/p</c> option. If the file does not contain private keys, use the <c>/csp</c> and <c>/kc</c> options to specify the CSP and container name of the private key.</p>
        /// </summary>
        [Pure]
        public static T ResetFile<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = null;
            return toolSettings;
        }
        #endregion
        #region Issuer
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.Issuer"/></em></p>
        ///   <p>Specify the Issuer of the signing cert, or a substring.</p>
        /// </summary>
        [Pure]
        public static T SetIssuer<T>(this T toolSettings, string issuer) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Issuer = issuer;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.Issuer"/></em></p>
        ///   <p>Specify the Issuer of the signing cert, or a substring.</p>
        /// </summary>
        [Pure]
        public static T ResetIssuer<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Issuer = null;
            return toolSettings;
        }
        #endregion
        #region SigningSubjectName
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.SigningSubjectName"/></em></p>
        ///   <p>Specify the Subject Name of the signing cert, or a substring.</p>
        /// </summary>
        [Pure]
        public static T SetSigningSubjectName<T>(this T toolSettings, string signingSubjectName) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SigningSubjectName = signingSubjectName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.SigningSubjectName"/></em></p>
        ///   <p>Specify the Subject Name of the signing cert, or a substring.</p>
        /// </summary>
        [Pure]
        public static T ResetSigningSubjectName<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SigningSubjectName = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.Password"/></em></p>
        ///   <p>Specify a password to use when opening the PFX file.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.Password"/></em></p>
        ///   <p>Specify a password to use when opening the PFX file.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region RootSubjectName
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.RootSubjectName"/></em></p>
        ///   <p>Specify the Subject Name of a Root cert that the signing cert must chain to.</p>
        /// </summary>
        [Pure]
        public static T SetRootSubjectName<T>(this T toolSettings, string rootSubjectName) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RootSubjectName = rootSubjectName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.RootSubjectName"/></em></p>
        ///   <p>Specify the Subject Name of a Root cert that the signing cert must chain to.</p>
        /// </summary>
        [Pure]
        public static T ResetRootSubjectName<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RootSubjectName = null;
            return toolSettings;
        }
        #endregion
        #region Store
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.Store"/></em></p>
        ///   <p>Specify the Store to open when searching for the cert. The default is the <c>MY</c> Store.</p>
        /// </summary>
        [Pure]
        public static T SetStore<T>(this T toolSettings, string store) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Store = store;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.Store"/></em></p>
        ///   <p>Specify the Store to open when searching for the cert. The default is the <c>MY</c> Store.</p>
        /// </summary>
        [Pure]
        public static T ResetStore<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Store = null;
            return toolSettings;
        }
        #endregion
        #region MachineStore
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.MachineStore"/></em></p>
        ///   <p>Open a Machine store instead of a User store.</p>
        /// </summary>
        [Pure]
        public static T SetMachineStore<T>(this T toolSettings, bool? machineStore) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MachineStore = machineStore;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.MachineStore"/></em></p>
        ///   <p>Open a Machine store instead of a User store.</p>
        /// </summary>
        [Pure]
        public static T ResetMachineStore<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MachineStore = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.MachineStore"/></em></p>
        ///   <p>Open a Machine store instead of a User store.</p>
        /// </summary>
        [Pure]
        public static T EnableMachineStore<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MachineStore = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.MachineStore"/></em></p>
        ///   <p>Open a Machine store instead of a User store.</p>
        /// </summary>
        [Pure]
        public static T DisableMachineStore<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MachineStore = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.MachineStore"/></em></p>
        ///   <p>Open a Machine store instead of a User store.</p>
        /// </summary>
        [Pure]
        public static T ToggleMachineStore<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MachineStore = !toolSettings.MachineStore;
            return toolSettings;
        }
        #endregion
        #region Sha1Thumbprint
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.Sha1Thumbprint"/></em></p>
        ///   <p>Specify the SHA1 thumbprint of the signing cert.</p>
        /// </summary>
        [Pure]
        public static T SetSha1Thumbprint<T>(this T toolSettings, [Secret] string sha1Thumbprint) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Sha1Thumbprint = sha1Thumbprint;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.Sha1Thumbprint"/></em></p>
        ///   <p>Specify the SHA1 thumbprint of the signing cert.</p>
        /// </summary>
        [Pure]
        public static T ResetSha1Thumbprint<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Sha1Thumbprint = null;
            return toolSettings;
        }
        #endregion
        #region FileDigestAlgorithm
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.FileDigestAlgorithm"/></em></p>
        ///   <p>Specifies the file digest algorithm to use for creating file signatures. (Default is <c>SHA1</c>)</p>
        /// </summary>
        [Pure]
        public static T SetFileDigestAlgorithm<T>(this T toolSettings, SignToolDigestAlgorithm fileDigestAlgorithm) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileDigestAlgorithm = fileDigestAlgorithm;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.FileDigestAlgorithm"/></em></p>
        ///   <p>Specifies the file digest algorithm to use for creating file signatures. (Default is <c>SHA1</c>)</p>
        /// </summary>
        [Pure]
        public static T ResetFileDigestAlgorithm<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileDigestAlgorithm = null;
            return toolSettings;
        }
        #endregion
        #region EnhancedKeyUsage
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.EnhancedKeyUsage"/></em></p>
        ///   <p>Specify the Enhanced Key Usage that must be present in the cert.<para/>The parameter may be specified by OID or by string. The default usage is <em>Code Signing</em> (1.3.6.1.5.5.7.3.3).</p>
        /// </summary>
        [Pure]
        public static T SetEnhancedKeyUsage<T>(this T toolSettings, string enhancedKeyUsage) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnhancedKeyUsage = enhancedKeyUsage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.EnhancedKeyUsage"/></em></p>
        ///   <p>Specify the Enhanced Key Usage that must be present in the cert.<para/>The parameter may be specified by OID or by string. The default usage is <em>Code Signing</em> (1.3.6.1.5.5.7.3.3).</p>
        /// </summary>
        [Pure]
        public static T ResetEnhancedKeyUsage<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnhancedKeyUsage = null;
            return toolSettings;
        }
        #endregion
        #region WindowsSystemComponentVerification
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.WindowsSystemComponentVerification"/></em></p>
        ///   <p>Specify usage of <em>Windows System Component Verification</em> (1.3.6.1.4.1.311.10.3.6).</p>
        /// </summary>
        [Pure]
        public static T SetWindowsSystemComponentVerification<T>(this T toolSettings, bool? windowsSystemComponentVerification) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WindowsSystemComponentVerification = windowsSystemComponentVerification;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.WindowsSystemComponentVerification"/></em></p>
        ///   <p>Specify usage of <em>Windows System Component Verification</em> (1.3.6.1.4.1.311.10.3.6).</p>
        /// </summary>
        [Pure]
        public static T ResetWindowsSystemComponentVerification<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WindowsSystemComponentVerification = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.WindowsSystemComponentVerification"/></em></p>
        ///   <p>Specify usage of <em>Windows System Component Verification</em> (1.3.6.1.4.1.311.10.3.6).</p>
        /// </summary>
        [Pure]
        public static T EnableWindowsSystemComponentVerification<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WindowsSystemComponentVerification = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.WindowsSystemComponentVerification"/></em></p>
        ///   <p>Specify usage of <em>Windows System Component Verification</em> (1.3.6.1.4.1.311.10.3.6).</p>
        /// </summary>
        [Pure]
        public static T DisableWindowsSystemComponentVerification<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WindowsSystemComponentVerification = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.WindowsSystemComponentVerification"/></em></p>
        ///   <p>Specify usage of <em>Windows System Component Verification</em> (1.3.6.1.4.1.311.10.3.6).</p>
        /// </summary>
        [Pure]
        public static T ToggleWindowsSystemComponentVerification<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WindowsSystemComponentVerification = !toolSettings.WindowsSystemComponentVerification;
            return toolSettings;
        }
        #endregion
        #region Csp
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.Csp"/></em></p>
        ///   <p>Specify the CSP containing the Private Key Container.</p>
        /// </summary>
        [Pure]
        public static T SetCsp<T>(this T toolSettings, string csp) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Csp = csp;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.Csp"/></em></p>
        ///   <p>Specify the CSP containing the Private Key Container.</p>
        /// </summary>
        [Pure]
        public static T ResetCsp<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Csp = null;
            return toolSettings;
        }
        #endregion
        #region KeyContainer
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.KeyContainer"/></em></p>
        ///   <p>Specify the Key Container Name of the Private Key.</p>
        /// </summary>
        [Pure]
        public static T SetKeyContainer<T>(this T toolSettings, string keyContainer) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyContainer = keyContainer;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.KeyContainer"/></em></p>
        ///   <p>Specify the Key Container Name of the Private Key.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyContainer<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyContainer = null;
            return toolSettings;
        }
        #endregion
        #region AppendSignature
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.AppendSignature"/></em></p>
        ///   <p>Append this signature. If no primary signature is present, this signature will be made the primary signature instead.</p>
        /// </summary>
        [Pure]
        public static T SetAppendSignature<T>(this T toolSettings, bool? appendSignature) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppendSignature = appendSignature;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.AppendSignature"/></em></p>
        ///   <p>Append this signature. If no primary signature is present, this signature will be made the primary signature instead.</p>
        /// </summary>
        [Pure]
        public static T ResetAppendSignature<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppendSignature = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.AppendSignature"/></em></p>
        ///   <p>Append this signature. If no primary signature is present, this signature will be made the primary signature instead.</p>
        /// </summary>
        [Pure]
        public static T EnableAppendSignature<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppendSignature = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.AppendSignature"/></em></p>
        ///   <p>Append this signature. If no primary signature is present, this signature will be made the primary signature instead.</p>
        /// </summary>
        [Pure]
        public static T DisableAppendSignature<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppendSignature = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.AppendSignature"/></em></p>
        ///   <p>Append this signature. If no primary signature is present, this signature will be made the primary signature instead.</p>
        /// </summary>
        [Pure]
        public static T ToggleAppendSignature<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppendSignature = !toolSettings.AppendSignature;
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.Description"/></em></p>
        ///   <p>Provide a description of the signed content.</p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.Description"/></em></p>
        ///   <p>Provide a description of the signed content.</p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = null;
            return toolSettings;
        }
        #endregion
        #region Url
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.Url"/></em></p>
        ///   <p>Provide a URL with more information about the signed content.</p>
        /// </summary>
        [Pure]
        public static T SetUrl<T>(this T toolSettings, string url) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = url;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.Url"/></em></p>
        ///   <p>Provide a URL with more information about the signed content.</p>
        /// </summary>
        [Pure]
        public static T ResetUrl<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = null;
            return toolSettings;
        }
        #endregion
        #region TimestampServerUrl
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.TimestampServerUrl"/></em></p>
        ///   <p>Specify the timestamp server's URL. If this option is not present, the signed file will not be timestamped. A warning is generated if timestamping fails.</p>
        /// </summary>
        [Pure]
        public static T SetTimestampServerUrl<T>(this T toolSettings, string timestampServerUrl) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimestampServerUrl = timestampServerUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.TimestampServerUrl"/></em></p>
        ///   <p>Specify the timestamp server's URL. If this option is not present, the signed file will not be timestamped. A warning is generated if timestamping fails.</p>
        /// </summary>
        [Pure]
        public static T ResetTimestampServerUrl<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimestampServerUrl = null;
            return toolSettings;
        }
        #endregion
        #region Rfc3161TimestampServerUrl
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.Rfc3161TimestampServerUrl"/></em></p>
        ///   <p>Specifies the RFC 3161 timestamp server's URL. If this option (or <c>/t</c>) is not specified, the signed file will not be timestamped. A warning is generated if timestamping fails. This switch cannot be used with the <c>/t</c> switch.</p>
        /// </summary>
        [Pure]
        public static T SetRfc3161TimestampServerUrl<T>(this T toolSettings, string rfc3161TimestampServerUrl) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Rfc3161TimestampServerUrl = rfc3161TimestampServerUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.Rfc3161TimestampServerUrl"/></em></p>
        ///   <p>Specifies the RFC 3161 timestamp server's URL. If this option (or <c>/t</c>) is not specified, the signed file will not be timestamped. A warning is generated if timestamping fails. This switch cannot be used with the <c>/t</c> switch.</p>
        /// </summary>
        [Pure]
        public static T ResetRfc3161TimestampServerUrl<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Rfc3161TimestampServerUrl = null;
            return toolSettings;
        }
        #endregion
        #region Rfc3161TimestampServerUrlSealed
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.Rfc3161TimestampServerUrlSealed"/></em></p>
        ///   <p>Specifies the RFC 3161 timestamp server's URL for timestamping a sealed file.</p>
        /// </summary>
        [Pure]
        public static T SetRfc3161TimestampServerUrlSealed<T>(this T toolSettings, string rfc3161TimestampServerUrlSealed) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Rfc3161TimestampServerUrlSealed = rfc3161TimestampServerUrlSealed;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.Rfc3161TimestampServerUrlSealed"/></em></p>
        ///   <p>Specifies the RFC 3161 timestamp server's URL for timestamping a sealed file.</p>
        /// </summary>
        [Pure]
        public static T ResetRfc3161TimestampServerUrlSealed<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Rfc3161TimestampServerUrlSealed = null;
            return toolSettings;
        }
        #endregion
        #region TimestampServerDigestAlgorithm
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.TimestampServerDigestAlgorithm"/></em></p>
        ///   <p>Used with the <c>/tr</c> or <c>/tseal</c> switch to request a digest algorithm used by the RFC 3161 timestamp server.</p>
        /// </summary>
        [Pure]
        public static T SetTimestampServerDigestAlgorithm<T>(this T toolSettings, SignToolDigestAlgorithm timestampServerDigestAlgorithm) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimestampServerDigestAlgorithm = timestampServerDigestAlgorithm;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.TimestampServerDigestAlgorithm"/></em></p>
        ///   <p>Used with the <c>/tr</c> or <c>/tseal</c> switch to request a digest algorithm used by the RFC 3161 timestamp server.</p>
        /// </summary>
        [Pure]
        public static T ResetTimestampServerDigestAlgorithm<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimestampServerDigestAlgorithm = null;
            return toolSettings;
        }
        #endregion
        #region AuthenticatedAttributes
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.AuthenticatedAttributes"/> to a new dictionary</em></p>
        ///   <p>Specify an OID and value to be included as an authenticated attribute in the signature. The value will be encoded as an ASN1 UTF8 string. This option may be given multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetAuthenticatedAttributes<T>(this T toolSettings, IDictionary<string, string> authenticatedAttributes) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticatedAttributesInternal = authenticatedAttributes.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SignToolSettings.AuthenticatedAttributes"/></em></p>
        ///   <p>Specify an OID and value to be included as an authenticated attribute in the signature. The value will be encoded as an ASN1 UTF8 string. This option may be given multiple times.</p>
        /// </summary>
        [Pure]
        public static T ClearAuthenticatedAttributes<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticatedAttributesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="SignToolSettings.AuthenticatedAttributes"/></em></p>
        ///   <p>Specify an OID and value to be included as an authenticated attribute in the signature. The value will be encoded as an ASN1 UTF8 string. This option may be given multiple times.</p>
        /// </summary>
        [Pure]
        public static T AddAuthenticatedAttribute<T>(this T toolSettings, string authenticatedAttributeKey, string authenticatedAttributeValue) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticatedAttributesInternal.Add(authenticatedAttributeKey, authenticatedAttributeValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="SignToolSettings.AuthenticatedAttributes"/></em></p>
        ///   <p>Specify an OID and value to be included as an authenticated attribute in the signature. The value will be encoded as an ASN1 UTF8 string. This option may be given multiple times.</p>
        /// </summary>
        [Pure]
        public static T RemoveAuthenticatedAttribute<T>(this T toolSettings, string authenticatedAttributeKey) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticatedAttributesInternal.Remove(authenticatedAttributeKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="SignToolSettings.AuthenticatedAttributes"/></em></p>
        ///   <p>Specify an OID and value to be included as an authenticated attribute in the signature. The value will be encoded as an ASN1 UTF8 string. This option may be given multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetAuthenticatedAttribute<T>(this T toolSettings, string authenticatedAttributeKey, string authenticatedAttributeValue) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticatedAttributesInternal[authenticatedAttributeKey] = authenticatedAttributeValue;
            return toolSettings;
        }
        #endregion
        #region SealingSignature
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.SealingSignature"/></em></p>
        ///   <p>Add a sealing signature if the file format supports it.</p>
        /// </summary>
        [Pure]
        public static T SetSealingSignature<T>(this T toolSettings, bool? sealingSignature) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SealingSignature = sealingSignature;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.SealingSignature"/></em></p>
        ///   <p>Add a sealing signature if the file format supports it.</p>
        /// </summary>
        [Pure]
        public static T ResetSealingSignature<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SealingSignature = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.SealingSignature"/></em></p>
        ///   <p>Add a sealing signature if the file format supports it.</p>
        /// </summary>
        [Pure]
        public static T EnableSealingSignature<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SealingSignature = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.SealingSignature"/></em></p>
        ///   <p>Add a sealing signature if the file format supports it.</p>
        /// </summary>
        [Pure]
        public static T DisableSealingSignature<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SealingSignature = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.SealingSignature"/></em></p>
        ///   <p>Add a sealing signature if the file format supports it.</p>
        /// </summary>
        [Pure]
        public static T ToggleSealingSignature<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SealingSignature = !toolSettings.SealingSignature;
            return toolSettings;
        }
        #endregion
        #region IntentToSealAttribute
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.IntentToSealAttribute"/></em></p>
        ///   <p>Create a primary signature with the intent-to-seal attribute.</p>
        /// </summary>
        [Pure]
        public static T SetIntentToSealAttribute<T>(this T toolSettings, bool? intentToSealAttribute) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntentToSealAttribute = intentToSealAttribute;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.IntentToSealAttribute"/></em></p>
        ///   <p>Create a primary signature with the intent-to-seal attribute.</p>
        /// </summary>
        [Pure]
        public static T ResetIntentToSealAttribute<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntentToSealAttribute = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.IntentToSealAttribute"/></em></p>
        ///   <p>Create a primary signature with the intent-to-seal attribute.</p>
        /// </summary>
        [Pure]
        public static T EnableIntentToSealAttribute<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntentToSealAttribute = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.IntentToSealAttribute"/></em></p>
        ///   <p>Create a primary signature with the intent-to-seal attribute.</p>
        /// </summary>
        [Pure]
        public static T DisableIntentToSealAttribute<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntentToSealAttribute = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.IntentToSealAttribute"/></em></p>
        ///   <p>Create a primary signature with the intent-to-seal attribute.</p>
        /// </summary>
        [Pure]
        public static T ToggleIntentToSealAttribute<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntentToSealAttribute = !toolSettings.IntentToSealAttribute;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.Force"/></em></p>
        ///   <p>Continue to seal or sign in situations where the existing signature or sealing signature needs to be removed to support sealing.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.Force"/></em></p>
        ///   <p>Continue to seal or sign in situations where the existing signature or sealing signature needs to be removed to support sealing.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.Force"/></em></p>
        ///   <p>Continue to seal or sign in situations where the existing signature or sealing signature needs to be removed to support sealing.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.Force"/></em></p>
        ///   <p>Continue to seal or sign in situations where the existing signature or sealing signature needs to be removed to support sealing.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.Force"/></em></p>
        ///   <p>Continue to seal or sign in situations where the existing signature or sealing signature needs to be removed to support sealing.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region NoSealWarn
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.NoSealWarn"/></em></p>
        ///   <p>Sealing-related warnings do not affect SignTool's return code.</p>
        /// </summary>
        [Pure]
        public static T SetNoSealWarn<T>(this T toolSettings, bool? noSealWarn) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSealWarn = noSealWarn;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.NoSealWarn"/></em></p>
        ///   <p>Sealing-related warnings do not affect SignTool's return code.</p>
        /// </summary>
        [Pure]
        public static T ResetNoSealWarn<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSealWarn = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.NoSealWarn"/></em></p>
        ///   <p>Sealing-related warnings do not affect SignTool's return code.</p>
        /// </summary>
        [Pure]
        public static T EnableNoSealWarn<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSealWarn = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.NoSealWarn"/></em></p>
        ///   <p>Sealing-related warnings do not affect SignTool's return code.</p>
        /// </summary>
        [Pure]
        public static T DisableNoSealWarn<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSealWarn = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.NoSealWarn"/></em></p>
        ///   <p>Sealing-related warnings do not affect SignTool's return code.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoSealWarn<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSealWarn = !toolSettings.NoSealWarn;
            return toolSettings;
        }
        #endregion
        #region SignedDigestAndUnsignedPkcs7Path
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.SignedDigestAndUnsignedPkcs7Path"/></em></p>
        ///   <p>Generates the to be signed digest and the unsigned PKCS7 files. The output digest and PKCS7 files will be: <c>&lt;path&gt;\&lt;file&gt;.dig</c> and <c>&lt;path&gt;\&lt;file&gt;.p7u</c>. To output an additional XML file, see <c>/dxml</c>.</p>
        /// </summary>
        [Pure]
        public static T SetSignedDigestAndUnsignedPkcs7Path<T>(this T toolSettings, string signedDigestAndUnsignedPkcs7Path) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignedDigestAndUnsignedPkcs7Path = signedDigestAndUnsignedPkcs7Path;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.SignedDigestAndUnsignedPkcs7Path"/></em></p>
        ///   <p>Generates the to be signed digest and the unsigned PKCS7 files. The output digest and PKCS7 files will be: <c>&lt;path&gt;\&lt;file&gt;.dig</c> and <c>&lt;path&gt;\&lt;file&gt;.p7u</c>. To output an additional XML file, see <c>/dxml</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetSignedDigestAndUnsignedPkcs7Path<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignedDigestAndUnsignedPkcs7Path = null;
            return toolSettings;
        }
        #endregion
        #region SignDigestOnly
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.SignDigestOnly"/></em></p>
        ///   <p>Signs the digest only. The input file should be the digest generated by the <c>/dg</c> option. The output file will be: <c>&lt;file&gt;.signed</c>.</p>
        /// </summary>
        [Pure]
        public static T SetSignDigestOnly<T>(this T toolSettings, bool? signDigestOnly) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignDigestOnly = signDigestOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.SignDigestOnly"/></em></p>
        ///   <p>Signs the digest only. The input file should be the digest generated by the <c>/dg</c> option. The output file will be: <c>&lt;file&gt;.signed</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetSignDigestOnly<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignDigestOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.SignDigestOnly"/></em></p>
        ///   <p>Signs the digest only. The input file should be the digest generated by the <c>/dg</c> option. The output file will be: <c>&lt;file&gt;.signed</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableSignDigestOnly<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignDigestOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.SignDigestOnly"/></em></p>
        ///   <p>Signs the digest only. The input file should be the digest generated by the <c>/dg</c> option. The output file will be: <c>&lt;file&gt;.signed</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableSignDigestOnly<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignDigestOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.SignDigestOnly"/></em></p>
        ///   <p>Signs the digest only. The input file should be the digest generated by the <c>/dg</c> option. The output file will be: <c>&lt;file&gt;.signed</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleSignDigestOnly<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignDigestOnly = !toolSettings.SignDigestOnly;
            return toolSettings;
        }
        #endregion
        #region GenerateSignature
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.GenerateSignature"/></em></p>
        ///   <p>Creates the signature by ingesting the signed digest to the unsigned PKCS7 file. The input signed digest and unsigned PKCS7 files should be: <c>&lt;path&gt;\&lt;file&gt;.dig.signed</c> and <c>&lt;path&gt;\&lt;file&gt;.p7u</c>.</p>
        /// </summary>
        [Pure]
        public static T SetGenerateSignature<T>(this T toolSettings, string generateSignature) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateSignature = generateSignature;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.GenerateSignature"/></em></p>
        ///   <p>Creates the signature by ingesting the signed digest to the unsigned PKCS7 file. The input signed digest and unsigned PKCS7 files should be: <c>&lt;path&gt;\&lt;file&gt;.dig.signed</c> and <c>&lt;path&gt;\&lt;file&gt;.p7u</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetGenerateSignature<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateSignature = null;
            return toolSettings;
        }
        #endregion
        #region XmlFile
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.XmlFile"/></em></p>
        ///   <p>When used with the <c>/dg</c> option, produces an XML file. The output file will be: <c>&lt;path&gt;\&lt;file&gt;.dig.xml</c>.</p>
        /// </summary>
        [Pure]
        public static T SetXmlFile<T>(this T toolSettings, bool? xmlFile) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlFile = xmlFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.XmlFile"/></em></p>
        ///   <p>When used with the <c>/dg</c> option, produces an XML file. The output file will be: <c>&lt;path&gt;\&lt;file&gt;.dig.xml</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetXmlFile<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlFile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.XmlFile"/></em></p>
        ///   <p>When used with the <c>/dg</c> option, produces an XML file. The output file will be: <c>&lt;path&gt;\&lt;file&gt;.dig.xml</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableXmlFile<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlFile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.XmlFile"/></em></p>
        ///   <p>When used with the <c>/dg</c> option, produces an XML file. The output file will be: <c>&lt;path&gt;\&lt;file&gt;.dig.xml</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableXmlFile<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlFile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.XmlFile"/></em></p>
        ///   <p>When used with the <c>/dg</c> option, produces an XML file. The output file will be: <c>&lt;path&gt;\&lt;file&gt;.dig.xml</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleXmlFile<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlFile = !toolSettings.XmlFile;
            return toolSettings;
        }
        #endregion
        #region AuthenticodeDigestSignLibDll
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.AuthenticodeDigestSignLibDll"/></em></p>
        ///   <p>Specifies the DLL implementing the AuthenticodeDigestSign function to sign the digest with. This option is equivalent to using SignTool separately with the <c>/dg</c>, <c>/ds</c>, and <c>/di</c> switches, except this option invokes all three as one atomic operation.</p>
        /// </summary>
        [Pure]
        public static T SetAuthenticodeDigestSignLibDll<T>(this T toolSettings, string authenticodeDigestSignLibDll) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticodeDigestSignLibDll = authenticodeDigestSignLibDll;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.AuthenticodeDigestSignLibDll"/></em></p>
        ///   <p>Specifies the DLL implementing the AuthenticodeDigestSign function to sign the digest with. This option is equivalent to using SignTool separately with the <c>/dg</c>, <c>/ds</c>, and <c>/di</c> switches, except this option invokes all three as one atomic operation.</p>
        /// </summary>
        [Pure]
        public static T ResetAuthenticodeDigestSignLibDll<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticodeDigestSignLibDll = null;
            return toolSettings;
        }
        #endregion
        #region AuthenticodeDigestSignPassUnmodified
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.AuthenticodeDigestSignPassUnmodified"/></em></p>
        ///   <p>When used with the <c>/dlib</c> option, passes the file's contents to the AuthenticodeDigestSign function without modification.</p>
        /// </summary>
        [Pure]
        public static T SetAuthenticodeDigestSignPassUnmodified<T>(this T toolSettings, string authenticodeDigestSignPassUnmodified) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticodeDigestSignPassUnmodified = authenticodeDigestSignPassUnmodified;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.AuthenticodeDigestSignPassUnmodified"/></em></p>
        ///   <p>When used with the <c>/dlib</c> option, passes the file's contents to the AuthenticodeDigestSign function without modification.</p>
        /// </summary>
        [Pure]
        public static T ResetAuthenticodeDigestSignPassUnmodified<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthenticodeDigestSignPassUnmodified = null;
            return toolSettings;
        }
        #endregion
        #region ContentFileToPkcs7
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.ContentFileToPkcs7"/></em></p>
        ///   <p>Specifies that for each specified content file a PKCS7 file is produced. The PKCS7 file will be named: <c>&lt;path&gt;\&lt;file&gt;.p7</c></p>
        /// </summary>
        [Pure]
        public static T SetContentFileToPkcs7<T>(this T toolSettings, string contentFileToPkcs7) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentFileToPkcs7 = contentFileToPkcs7;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.ContentFileToPkcs7"/></em></p>
        ///   <p>Specifies that for each specified content file a PKCS7 file is produced. The PKCS7 file will be named: <c>&lt;path&gt;\&lt;file&gt;.p7</c></p>
        /// </summary>
        [Pure]
        public static T ResetContentFileToPkcs7<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentFileToPkcs7 = null;
            return toolSettings;
        }
        #endregion
        #region SignedContentIdentifier
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.SignedContentIdentifier"/></em></p>
        ///   <p>Specifies the <c>&lt;OID&gt;</c> that identifies the signed content.</p>
        /// </summary>
        [Pure]
        public static T SetSignedContentIdentifier<T>(this T toolSettings, string signedContentIdentifier) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignedContentIdentifier = signedContentIdentifier;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.SignedContentIdentifier"/></em></p>
        ///   <p>Specifies the <c>&lt;OID&gt;</c> that identifies the signed content.</p>
        /// </summary>
        [Pure]
        public static T ResetSignedContentIdentifier<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignedContentIdentifier = null;
            return toolSettings;
        }
        #endregion
        #region SignedContentMethod
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.SignedContentMethod"/></em></p>
        ///   <p>efined values:<ul><li><b>Embedded:</b> Embeds the signed content in the PKCS7.</li><li><b>DetachedSignedData:</b> Produces the signed data part of a detached PKCS7.</li></ul>The default is <c>Embedded</c>.</p>
        /// </summary>
        [Pure]
        public static T SetSignedContentMethod<T>(this T toolSettings, SignToolContentMethod signedContentMethod) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignedContentMethod = signedContentMethod;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.SignedContentMethod"/></em></p>
        ///   <p>efined values:<ul><li><b>Embedded:</b> Embeds the signed content in the PKCS7.</li><li><b>DetachedSignedData:</b> Produces the signed data part of a detached PKCS7.</li></ul>The default is <c>Embedded</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetSignedContentMethod<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignedContentMethod = null;
            return toolSettings;
        }
        #endregion
        #region PageHashes
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.PageHashes"/></em></p>
        ///   <p>Generate page hashes for executable files if supported.</p>
        /// </summary>
        [Pure]
        public static T SetPageHashes<T>(this T toolSettings, bool? pageHashes) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageHashes = pageHashes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.PageHashes"/></em></p>
        ///   <p>Generate page hashes for executable files if supported.</p>
        /// </summary>
        [Pure]
        public static T ResetPageHashes<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageHashes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.PageHashes"/></em></p>
        ///   <p>Generate page hashes for executable files if supported.</p>
        /// </summary>
        [Pure]
        public static T EnablePageHashes<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageHashes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.PageHashes"/></em></p>
        ///   <p>Generate page hashes for executable files if supported.</p>
        /// </summary>
        [Pure]
        public static T DisablePageHashes<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageHashes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.PageHashes"/></em></p>
        ///   <p>Generate page hashes for executable files if supported.</p>
        /// </summary>
        [Pure]
        public static T TogglePageHashes<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PageHashes = !toolSettings.PageHashes;
            return toolSettings;
        }
        #endregion
        #region SuppressPageHashes
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.SuppressPageHashes"/></em></p>
        ///   <p>Suppress page hashes for executable files if supported. The default is determined by the <c>SIGNTOOL_PAGE_HASHES</c> environment variable and by the <em>wintrust.dll</em> version.</p>
        /// </summary>
        [Pure]
        public static T SetSuppressPageHashes<T>(this T toolSettings, bool? suppressPageHashes) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressPageHashes = suppressPageHashes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.SuppressPageHashes"/></em></p>
        ///   <p>Suppress page hashes for executable files if supported. The default is determined by the <c>SIGNTOOL_PAGE_HASHES</c> environment variable and by the <em>wintrust.dll</em> version.</p>
        /// </summary>
        [Pure]
        public static T ResetSuppressPageHashes<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressPageHashes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.SuppressPageHashes"/></em></p>
        ///   <p>Suppress page hashes for executable files if supported. The default is determined by the <c>SIGNTOOL_PAGE_HASHES</c> environment variable and by the <em>wintrust.dll</em> version.</p>
        /// </summary>
        [Pure]
        public static T EnableSuppressPageHashes<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressPageHashes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.SuppressPageHashes"/></em></p>
        ///   <p>Suppress page hashes for executable files if supported. The default is determined by the <c>SIGNTOOL_PAGE_HASHES</c> environment variable and by the <em>wintrust.dll</em> version.</p>
        /// </summary>
        [Pure]
        public static T DisableSuppressPageHashes<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressPageHashes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.SuppressPageHashes"/></em></p>
        ///   <p>Suppress page hashes for executable files if supported. The default is determined by the <c>SIGNTOOL_PAGE_HASHES</c> environment variable and by the <em>wintrust.dll</em> version.</p>
        /// </summary>
        [Pure]
        public static T ToggleSuppressPageHashes<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressPageHashes = !toolSettings.SuppressPageHashes;
            return toolSettings;
        }
        #endregion
        #region RelaxedMarkerCheck
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.RelaxedMarkerCheck"/></em></p>
        ///   <p>Specifies signing a PE file with the relaxed marker check semantic. The flag is ignored for non-PE files. During verification, certain authenticated sections of the signature will bypass invalid PE markers check. This option should only be used after careful consideration and reviewing the details of MSRC case MS12-024 to ensure that no vulnerabilities are introduced.</p>
        /// </summary>
        [Pure]
        public static T SetRelaxedMarkerCheck<T>(this T toolSettings, bool? relaxedMarkerCheck) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RelaxedMarkerCheck = relaxedMarkerCheck;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.RelaxedMarkerCheck"/></em></p>
        ///   <p>Specifies signing a PE file with the relaxed marker check semantic. The flag is ignored for non-PE files. During verification, certain authenticated sections of the signature will bypass invalid PE markers check. This option should only be used after careful consideration and reviewing the details of MSRC case MS12-024 to ensure that no vulnerabilities are introduced.</p>
        /// </summary>
        [Pure]
        public static T ResetRelaxedMarkerCheck<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RelaxedMarkerCheck = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.RelaxedMarkerCheck"/></em></p>
        ///   <p>Specifies signing a PE file with the relaxed marker check semantic. The flag is ignored for non-PE files. During verification, certain authenticated sections of the signature will bypass invalid PE markers check. This option should only be used after careful consideration and reviewing the details of MSRC case MS12-024 to ensure that no vulnerabilities are introduced.</p>
        /// </summary>
        [Pure]
        public static T EnableRelaxedMarkerCheck<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RelaxedMarkerCheck = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.RelaxedMarkerCheck"/></em></p>
        ///   <p>Specifies signing a PE file with the relaxed marker check semantic. The flag is ignored for non-PE files. During verification, certain authenticated sections of the signature will bypass invalid PE markers check. This option should only be used after careful consideration and reviewing the details of MSRC case MS12-024 to ensure that no vulnerabilities are introduced.</p>
        /// </summary>
        [Pure]
        public static T DisableRelaxedMarkerCheck<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RelaxedMarkerCheck = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.RelaxedMarkerCheck"/></em></p>
        ///   <p>Specifies signing a PE file with the relaxed marker check semantic. The flag is ignored for non-PE files. During verification, certain authenticated sections of the signature will bypass invalid PE markers check. This option should only be used after careful consideration and reviewing the details of MSRC case MS12-024 to ensure that no vulnerabilities are introduced.</p>
        /// </summary>
        [Pure]
        public static T ToggleRelaxedMarkerCheck<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RelaxedMarkerCheck = !toolSettings.RelaxedMarkerCheck;
            return toolSettings;
        }
        #endregion
        #region Quiet
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.Quiet"/></em></p>
        ///   <p>No output on success and minimal output on failure.</p>
        /// </summary>
        [Pure]
        public static T SetQuiet<T>(this T toolSettings, bool? quiet) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = quiet;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.Quiet"/></em></p>
        ///   <p>No output on success and minimal output on failure.</p>
        /// </summary>
        [Pure]
        public static T ResetQuiet<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.Quiet"/></em></p>
        ///   <p>No output on success and minimal output on failure.</p>
        /// </summary>
        [Pure]
        public static T EnableQuiet<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.Quiet"/></em></p>
        ///   <p>No output on success and minimal output on failure.</p>
        /// </summary>
        [Pure]
        public static T DisableQuiet<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.Quiet"/></em></p>
        ///   <p>No output on success and minimal output on failure.</p>
        /// </summary>
        [Pure]
        public static T ToggleQuiet<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = !toolSettings.Quiet;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.Verbose"/></em></p>
        ///   <p>Print verbose success and status messages. This may also provide slightly more information on error.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.Verbose"/></em></p>
        ///   <p>Print verbose success and status messages. This may also provide slightly more information on error.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.Verbose"/></em></p>
        ///   <p>Print verbose success and status messages. This may also provide slightly more information on error.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.Verbose"/></em></p>
        ///   <p>Print verbose success and status messages. This may also provide slightly more information on error.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.Verbose"/></em></p>
        ///   <p>Print verbose success and status messages. This may also provide slightly more information on error.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.Debug"/></em></p>
        ///   <p>Display additional debug information.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignToolSettings.Debug"/></em></p>
        ///   <p>Display additional debug information.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SignToolSettings.Debug"/></em></p>
        ///   <p>Display additional debug information.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SignToolSettings.Debug"/></em></p>
        ///   <p>Display additional debug information.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SignToolSettings.Debug"/></em></p>
        ///   <p>Display additional debug information.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region Files
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.Files"/> to a new list</em></p>
        ///   <p>Files to sign.</p>
        /// </summary>
        [Pure]
        public static T SetFiles<T>(this T toolSettings, params string[] files) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal = files.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SignToolSettings.Files"/> to a new list</em></p>
        ///   <p>Files to sign.</p>
        /// </summary>
        [Pure]
        public static T SetFiles<T>(this T toolSettings, IEnumerable<string> files) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal = files.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SignToolSettings.Files"/></em></p>
        ///   <p>Files to sign.</p>
        /// </summary>
        [Pure]
        public static T AddFiles<T>(this T toolSettings, params string[] files) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal.AddRange(files);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SignToolSettings.Files"/></em></p>
        ///   <p>Files to sign.</p>
        /// </summary>
        [Pure]
        public static T AddFiles<T>(this T toolSettings, IEnumerable<string> files) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal.AddRange(files);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SignToolSettings.Files"/></em></p>
        ///   <p>Files to sign.</p>
        /// </summary>
        [Pure]
        public static T ClearFiles<T>(this T toolSettings) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SignToolSettings.Files"/></em></p>
        ///   <p>Files to sign.</p>
        /// </summary>
        [Pure]
        public static T RemoveFiles<T>(this T toolSettings, params string[] files) where T : SignToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(files);
            toolSettings.FilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SignToolSettings.Files"/></em></p>
        ///   <p>Files to sign.</p>
        /// </summary>
        [Pure]
        public static T RemoveFiles<T>(this T toolSettings, IEnumerable<string> files) where T : SignToolSettings
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
    /// <summary>
    ///   Used within <see cref="SignToolTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="SignToolTasks"/>.
    /// </summary>
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
}
