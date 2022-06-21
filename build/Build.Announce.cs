// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuke.Common;
using Nuke.Common.ChangeLog;
using Nuke.Common.Git;
using Nuke.Common.Tools.Git;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.Tools.Slack;
using Nuke.Common.Utilities;
using Nuke.Components;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using static Nuke.Common.Gitter.GitterTasks;
using static Nuke.Common.IO.TextTasks;
using static Nuke.Common.Tools.Slack.SlackTasks;

partial class Build
{
    [Parameter] [Secret] readonly string GitterAuthToken;
    [Parameter] [Secret] readonly string SlackWebhook;
    [Parameter] readonly string GitterRoomId;

    IEnumerable<string> ChangelogSectionNotes => ChangelogTasks.ExtractChangelogSectionNotes(From<IHazChangelog>().ChangelogFile);

    Target Announce => _ => _
        .DependsOn(ReleaseImage)
        .WhenSkipped(DependencyBehavior.Skip)
        .TriggeredBy<IPublish>()
        .OnlyWhenStatic(() => IsOriginalRepository && GitRepository.IsOnMasterBranch())
        .Requires(() => TwitterCredentials.ConsumerKey)
        .Requires(() => TwitterCredentials.ConsumerSecret)
        .Requires(() => TwitterCredentials.AccessToken)
        .Requires(() => TwitterCredentials.AccessTokenSecret)
        .Requires(() => SlackWebhook)
        .Requires(() => GitterAuthToken)
        .Executes(async () =>
        {
            var committers = GitTasks.Git($"log {MajorMinorPatchVersion}^..{MajorMinorPatchVersion} --pretty=tformat:%an", logOutput: false);
            var commitsText = $"{committers.Count} {(committers.Count == 1 ? "commit" : "commits")}";
            var comparisonUrl = GitRepository.GetGitHubCompareTagsUrl(MajorMinorPatchVersion, $"{MajorMinorPatchVersion}^");
            var notableCommitters = committers
                .Select(x => x.Text)
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .Where(x => x != "Matthias Koch").ToList();

            var client = new TwitterClient(
                new TwitterCredentials(
                    TwitterCredentials.ConsumerKey,
                    TwitterCredentials.ConsumerSecret,
                    TwitterCredentials.AccessToken,
                    TwitterCredentials.AccessTokenSecret));

            var media = await client.Upload.UploadTweetImageAsync(
                new UploadTweetImageParameters(ReadAllBytes(ReleaseImageFile))
                {
                    MediaCategory = MediaCategory.Image
                });

            await client.Tweets.PublishTweetAsync(
                new PublishTweetParameters
                {
                    Text = new[]
                        {
                            $"🔥 Check out the new {MajorMinorPatchVersion} release! 🏗",
                            string.Empty,
                            $"More information at 👉 {GitRepository.GetGitHubBrowseUrl(From<IHazChangelog>().ChangelogFile)}"
                        }.JoinNewLine(),
                    Medias = new List<IMedia> { media }
                });

            await SendSlackMessageAsync(_ => _
                    .AddAttachment(_ => _
                        .SetFallback($"NUKE {MajorMinorPatchVersion} RELEASED!")
                        .SetAuthorName($"NUKE {MajorMinorPatchVersion} RELEASED!")
                        .SetAuthorLink($"https://nuget.org/packages/Nuke.Common/{MajorMinorPatchVersion}")
                        .SetColor("#00ACC1")
                        .SetThumbUrl(
                            MajorMinorPatchVersion.EndsWith(".0.0")
                                ? "https://emojipedia-us.s3.dualstack.us-west-1.amazonaws.com/thumbs/320/apple/285/rocket_1f680.png"
                                : MajorMinorPatchVersion.EndsWith(".0")
                                    ? "https://emojipedia-us.s3.dualstack.us-west-1.amazonaws.com/thumbs/320/apple/285/wrapped-gift_1f381.png"
                                    : "https://emojipedia-us.s3.dualstack.us-west-1.amazonaws.com/thumbs/320/apple/285/package_1f4e6.png")
                        .SetText(new StringBuilder()
                            .Append($"<!channel>, this release includes *<{comparisonUrl}|{commitsText}>*")
                            .AppendLine(notableCommitters.Count > 0
                                ? $" with notable contributions from {notableCommitters.JoinCommaAnd()}. A round of applause for them! :clap:"
                                : ". No contributions this time. :sweat_smile:")
                            .AppendLine()
                            .AppendLine("Remember that you can call `nuke :update` to update your builds! :bulb:")
                            .AppendLine()
                            .AppendLine("*Release Notes*")
                            .AppendLine("```")
                            .AppendLine(ChangelogSectionNotes.Select(x => x.Replace("- ", "• ").Replace("`", string.Empty)).JoinNewLine())
                            .AppendLine("```").ToString())
                        .SetFooter("Powered by *<https://octopus.com/|Octopus Deploy>* and *<https://virtocommerce.com/|Virto Commerce>*.")),
                SlackWebhook);

            SendGitterMessage(new StringBuilder()
                    .AppendLine($"@/all :mega::shipit: **NUKE {MajorMinorPatchVersion} IS OUT!!!**")
                    .AppendLine()
                    .AppendLine(ChangelogSectionNotes.Select(x => x.Replace("- ", "* ")).JoinNewLine()).ToString(),
                GitterRoomId,
                GitterAuthToken);
        });
}
