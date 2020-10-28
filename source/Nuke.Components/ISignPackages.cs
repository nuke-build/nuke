// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.IO;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.ValueInjection;
using static Nuke.Common.IO.CompressionTasks;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.SignPath.SignPathTasks;

namespace Nuke.Components
{
    public interface ISignPackages : INukeBuild
    {
        [Parameter] string SignPathApiToken => ValueInjectionUtility.TryGetValue(() => SignPathApiToken);
        [Parameter] string SignPathOrganizationId => ValueInjectionUtility.TryGetValue(() => SignPathOrganizationId);
        [Parameter] string SignPathProjectKey => ValueInjectionUtility.TryGetValue(() => SignPathProjectKey);
        [Parameter] string SignPathPolicyKey => ValueInjectionUtility.TryGetValue(() => SignPathPolicyKey);

        AbsolutePath SignPathTemporaryDirectory => TemporaryDirectory / $"signpath";
        AbsolutePath SignPathRequestDirectory => SignPathTemporaryDirectory / "signing-request";
        AbsolutePath SignPathResponseDirectory => SignPathTemporaryDirectory / "signing-response";
        string SignPathRequestArchive => Path.ChangeExtension(SignPathRequestDirectory, ".zip");
        string SignPathResponseArchive => Path.ChangeExtension(SignPathRequestDirectory, ".zip");

        IEnumerable<AbsolutePath> SignPathPackages { get; }
        bool SignPathReplacePackages => true;

        private AppVeyor AppVeyor => AppVeyor.Instance;

        Target SignPackages => _ => _
            .OnlyWhenStatic(() => AppVeyor != null)
            .Requires(() => SignPathApiToken)
            .Requires(() => SignPathOrganizationId)
            .Requires(() => SignPathProjectKey)
            .Requires(() => SignPathPolicyKey)
            .Executes(async () =>
            {
                EnsureCleanDirectory(SignPathTemporaryDirectory);
                SignPathPackages.ForEach(x => CopyFileToDirectory(x, SignPathRequestDirectory));
                CompressZip(SignPathRequestDirectory, SignPathRequestArchive);

                AppVeyor.PushArtifact(SignPathRequestArchive);

                var signingRequestUrl = await GetSigningRequestUrlViaAppVeyor(
                    SignPathApiToken,
                    SignPathOrganizationId,
                    SignPathProjectKey,
                    SignPathPolicyKey);
                await DownloadSignedArtifactFromUrl(
                    SignPathApiToken,
                    signingRequestUrl,
                    SignPathResponseArchive);

                UncompressZip(SignPathResponseArchive, SignPathResponseDirectory);

                if (SignPathReplacePackages)
                {
                    SignPathResponseDirectory.GlobFiles("*").Join(
                            SignPathPackages,
                            x => Path.GetFileName(x),
                            x => Path.GetFileName(x),
                            (x, y) => (SignedPackage: x, UnsignedPackage: y))
                        .ForEach(x => CopyFile(x.SignedPackage, x.UnsignedPackage, FileExistsPolicy.Overwrite));
                }
            });
    }
}
