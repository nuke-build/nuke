// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuke.Common;
using Nuke.Common.ChangeLog;
using Nuke.Common.Git;
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
    [Parameter] [Secret] readonly string GitHubToken;
    [Parameter] [Secret] readonly string GitterAuthToken;
    [Parameter] [Secret] readonly string SlackWebhook;

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
                    Text = "🔥 Check out the new release! 🏗",
                    Medias = new List<IMedia> { media }
                });

            await SendSlackMessageAsync(_ => _
                    .SetText(new StringBuilder()
                        .AppendLine($"<!here> :mega::shipit: *NUKE {GitVersion.SemVer} IS OUT!!!*")
                        .AppendLine()
                        .AppendLine(ChangelogSectionNotes.Select(x => x.Replace("- ", "• ")).JoinNewLine()).ToString()),
                SlackWebhook);

            SendGitterMessage(new StringBuilder()
                    .AppendLine($"@/all :mega::shipit: **NUKE {GitVersion.SemVer} IS OUT!!!**")
                    .AppendLine()
                    .AppendLine(ChangelogSectionNotes.Select(x => x.Replace("- ", "* ")).JoinNewLine()).ToString(),
                "593f3dadd73408ce4f66db89",
                GitterAuthToken);
        });
}
