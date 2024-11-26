// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.IO;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.SignPath.SignPathTasks;

namespace Nuke.Components;

/// <summary>
/// This component allows to easily sign NuGet packages with
/// <a href="https://signpath.io">SignPath</a> and
/// <a href="https://ci.appveyor.com">AppVeyor</a>.
/// </summary>
/// <remarks>
/// <para>
/// To implement this interface, proceed as follows:
/// <ul>
///   <li>Register for an open-source account at <a href="https://sig.fo">sig.fo</a></li>
///   <li>Generate or copy the Bearer token at <a href="https://ci.appveyor.com/api-keys">ci.appveyor.com/api-keys</a></li>
///   <li>Add AppVeyor as a <a href="https://about.signpath.io/documentation/projects#trusted-build-systems">trusted build system</a></li>
///   <li>Provide the Bearer token and set <c>signing-request.zip</c> as the artifact path</li>
///   <li>Create a <a href="https://about.signpath.io/documentation/users">CI user</a> and assign it as <a href="https://about.signpath.io/documentation/projects#signing-policies">submitter for the signing policy</a></li>
///   <li>Encrypt the generated API token at <a href="https://ci.appveyor.com/tools/encrypt">ci.appveyor.com/tools/encrypt</a></li>
///   <li>Provide an <a href="https://about.signpath.io/documentation/artifact-configuration">artifact configuration</a></li>
///   <li>
///     Extend the <c>appveyor.yml</c> with all necessary data
///     <code>
///     environment:
///       SignPathApiToken:
///         secure: &lt;encrypted-api-token&gt;
///       SignPathOrganizationId: &lt;organization-id&gt;
///       SignPathProjectSlug: &lt;project-Slug&gt;
///       SignPathPolicySlug: &lt;policy-Slug&gt;
///     </code>
///   </li>
/// </ul>
/// </para>
/// </remarks>
[PublicAPI]
[ParameterPrefix(SignPath)]
public interface ISignPackages : INukeBuild
{
    public const string SignPath = nameof(SignPath);

    public record SignPathSettings(
        string OrganizationId,
        string ProjectSlug,
        string PolicySlug);

    [Parameter] SignPathSettings Settings => TryGetValue(() => Settings);
    [Parameter] [Secret] string ApiToken => TryGetValue(() => ApiToken);

    AbsolutePath SignPathTemporaryDirectory => TemporaryDirectory / "signpath";
    AbsolutePath SignPathRequestDirectory => SignPathTemporaryDirectory / "signing-request";
    AbsolutePath SignPathResponseDirectory => SignPathTemporaryDirectory / "signing-response";
    AbsolutePath SignPathRequestArchive => SignPathRequestDirectory.WithExtension(".zip");
    AbsolutePath SignPathResponseArchive => SignPathResponseDirectory.WithExtension(".zip");

    IEnumerable<AbsolutePath> SignPathPackages { get; }
    bool SignPathReplacePackages => true;

    private AppVeyor AppVeyor => AppVeyor.Instance;

    Target SignPackages => _ => _
        .TryDependsOn<IPack>()
        .TryDependentFor<IPublish>()
        .OnlyWhenStatic(() => AppVeyor != null)
        .Requires(() => Settings)
        .Requires(() => ApiToken)
        .Executes(async () =>
        {
            SignPathRequestDirectory.CreateOrCleanDirectory();
            SignPathPackages.ForEach(x => x.CopyToDirectory(SignPathRequestDirectory));
            SignPathRequestDirectory.ZipTo(SignPathRequestArchive);

            AppVeyor.PushArtifact(SignPathRequestArchive);

            var signingRequestUrl = await GetSigningRequestUrlViaAppVeyor(
                ApiToken,
                Settings.OrganizationId,
                Settings.ProjectSlug,
                Settings.PolicySlug);

            ReportSummary(_ => _
                .AddPair("Approve/Deny Request", signingRequestUrl.Replace("api/v1", "Web")));

            try
            {
                await DownloadSignedArtifactFromUrl(
                    ApiToken,
                    signingRequestUrl,
                    SignPathResponseArchive);
            }
            finally
            {
                ReportSummary(_ => _);
            }

            SignPathResponseArchive.UnZipTo(SignPathResponseDirectory);

            if (SignPathReplacePackages)
            {
                SignPathResponseDirectory.GlobFiles("*").Join(
                        SignPathPackages,
                        x => Path.GetFileName(x),
                        x => Path.GetFileName(x),
                        (x, y) => (SignedPackage: x, UnsignedPackage: y))
                    .ForEach(x => x.SignedPackage.Copy(x.UnsignedPackage, ExistsPolicy.FileOverwrite));
            }
        });
}
