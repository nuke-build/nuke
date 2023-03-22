// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.ChangeLog;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.IO;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.Utilities;
using Octokit;

namespace Nuke.Components
{
    [PublicAPI]
    public interface ICreateGitHubRelease : IHazGitRepository, IHazChangelog
    {
        public const string GitHubRelease = nameof(GitHubRelease);

        [Parameter] [Secret] string GitHubToken => TryGetValue(() => GitHubToken) ?? GitHubActions.Instance.Token;

        string Name { get; }
        IEnumerable<AbsolutePath> AssetFiles { get; }

        Target CreateGitHubRelease => _ => _
            .Executes(async () =>
            {
                GitHubTasks.GitHubClient.Credentials ??= new Credentials(GitHubToken);

                var release = await GitHubTasks.GitHubClient.Repository.Release.Create(
                    GitRepository.GetGitHubOwner(),
                    GitRepository.GetGitHubName(),
                    new NewRelease(Name)
                    {
                        Name = Name,
                        Body = ChangelogTasks.ExtractChangelogSectionNotes(ChangelogFile).JoinNewLine()
                    });

                var uploadTasks = AssetFiles.Select(async x =>
                {
                    await using var assetFile = File.OpenRead(x);
                    var asset = new ReleaseAssetUpload
                                {
                                    FileName = x.Name,
                                    ContentType = "application/octet-stream",
                                    RawData = assetFile
                                };
                    await GitHubTasks.GitHubClient.Repository.Release.UploadAsset(release, asset);
                }).ToArray();

                Task.WaitAll(uploadTasks);
            });
    }
}
