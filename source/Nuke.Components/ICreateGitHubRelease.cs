// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// using System.Linq;
//
// using Nuke.Common;
// using Nuke.Common.Tools.GitHub;
// using Nuke.GitHub;
//
// using static Nuke.Common.ValueInjection.ValueInjectionUtility;
// using static Nuke.GitHub.GitHubTasks;
//
// public interface ICreateGitHubRelease : INukeBuild
// {
//     [Parameter]
//     string GitHubToken => TryGetValue(() => GitHubToken);
//
//     Target CreateGitHubRelease => _ => _
//         .Requires(() => GitHubToken)
//         .Executes(async () =>
//         {
//             await PublishRelease(_ => _
//                 .SetToken(GitHubToken)
//                 .WhenNotNull((this as IHazGitRepository)?.GitRepository, (_, repository) => _
//                     .SetRepositoryOwner(repository.GetGitHubOwner())
//                     .SetRepositoryName(repository.GetGitHubName())
//                     .WhenNotNull(repository.Tags.FirstOrDefault(), (_, tag) => _
//                         .SetName($"v{tag}")
//                         .SetTag(tag)))
//                 .WhenNotNull(this as IHazChangelog, (_, o) => _
//                     .SetReleaseNotes(o.ReleaseNotes))
//                 .SetArtifactPaths(new string[0]));
//         });
// }


