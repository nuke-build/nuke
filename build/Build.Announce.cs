// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.Tools.Slack;
using Nuke.Common.Utilities;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using static Nuke.Common.Gitter.GitterTasks;
using static Nuke.Common.IO.TextTasks;
using static Nuke.Common.Tools.Slack.SlackTasks;

partial class Build
{
    [Parameter] readonly string GitHubToken;
    [Parameter] readonly string GitterAuthToken;
    [Parameter] readonly string SlackWebhook;

    [Parameter] readonly string TwitterConsumerKey;
    [Parameter] readonly string TwitterConsumerSecret;
    [Parameter] readonly string TwitterAccessToken;
    [Parameter] readonly string TwitterAccessTokenSecret;

    Target Announce => _ => _
        .DependsOn(ReleaseImage)
        .TriggeredBy(Publish)
        .OnlyWhenStatic(() => GitRepository.IsOnMasterBranch())
        .Requires(() => TwitterConsumerKey)
        .Requires(() => TwitterConsumerSecret)
        .Requires(() => TwitterAccessToken)
        .Requires(() => TwitterAccessTokenSecret)
        .Requires(() => SlackWebhook)
        .Requires(() => GitterAuthToken)
        .Executes(async () =>
        {
            var client = new TwitterClient(
                new TwitterCredentials(
                    TwitterConsumerKey,
                    TwitterConsumerSecret,
                    TwitterAccessToken,
                    TwitterAccessTokenSecret));

            var media = await client.Upload.UploadTweetImageAsync(
                new UploadTweetImageParameters(ReadAllBytes(ReleaseImageFile))
                {
                    MediaCategory = MediaCategory.Image
                });

            await client.Tweets.PublishTweetAsync(
                new PublishTweetParameters
                {
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
