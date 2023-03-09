// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuke.Common;
using Nuke.Common.ChangeLog;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.Tools.Discord;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.Tools.Mastodon;
using Nuke.Common.Tools.Slack;
using Nuke.Common.Utilities;
using Nuke.Components;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using static Nuke.Common.Gitter.GitterTasks;
using static Nuke.Common.Tools.Discord.DiscordTasks;
using static Nuke.Common.Tools.Git.GitTasks;
using static Nuke.Common.Tools.Mastodon.MastodonTasks;
using static Nuke.Common.Tools.Slack.SlackTasks;

partial class Build
{
    Target Announce => _ => _
        .DependsOn(ReleaseImage)
        .WhenSkipped(DependencyBehavior.Skip)
        .TriggeredBy<IPublish>()
        .OnlyWhenStatic(() => GitRepository.IsOnMasterBranch());

    IEnumerable<string> ChangelogSectionNotes => ChangelogTasks.ExtractChangelogSectionNotes(From<IHazChangelog>().ChangelogFile);

    string AnnouncementTitle => $"NUKE {MajorMinorPatchVersion} RELEASED!";
    string AnnouncementLink => $"https://nuget.org/packages/Nuke.Common/{MajorMinorPatchVersion}";
    int AnnouncementColor => 0x00ACC1;

    string AnnouncementThumbnailUrl =>
        (GitVersion.Major, GitVersion.Minor, GitVersion.Patch) switch
        {
            (_, 0, 0) => "https://em-content.zobj.net/thumbs/320/apple/325/rocket_1f680.png",
            (_, _, 0) => "https://em-content.zobj.net/thumbs/320/apple/325/wrapped-gift_1f381.png",
            (_, _, _) => "https://em-content.zobj.net/thumbs/320/apple/325/package_1f4e6.png"
        };

    string AnnouncementComparisonUrl => GitRepository.GetGitHubCompareTagsUrl(MajorMinorPatchVersion, $"{MajorMinorPatchVersion}^");

    string AnnouncementReleaseNotes =>
        new StringBuilder()
            .AppendLine("*Release Notes*")
            .AppendLine("```")
            .AppendLine(ChangelogSectionNotes.Select(x => x.Replace("- ", "• ").Replace("`", string.Empty)).JoinNewLine())
            .AppendLine("```").ToString();

    (string CommitsText, IReadOnlyCollection<string> NotableCommmitters) AnnouncementGitInfo
    {
        get
        {
            var committers = Git($"log {MajorMinorPatchVersion}^..{MajorMinorPatchVersion} --pretty=tformat:%an", logInvocation: false, logOutput: false);
            var commitsText = $"{committers.Count} {(committers.Count == 1 ? "commit" : "commits")}";
            var notableCommitters = committers
                .Select(x => x.Text)
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .Where(x => x != "Matthias Koch").ToList();
            return (commitsText, notableCommitters);
        }
    }

    IEnumerable<(string Text, string Url)> AnnouncementSponsors =>
        new (string Text, string Url)[]
        {
            ("Octopus Deploy", "https://octopus.com/"),
        };

    [Parameter] [Secret] readonly string SlackWebhook;

    Target AnnounceSlack => _ => _
        .TriggeredBy(Announce)
        .Requires(() => SlackWebhook)
        .Executes(async () =>
        {
            await SendSlackMessageAsync(_ => _
                    .AddAttachment(_ => _
                        .SetFallback(AnnouncementTitle)
                        .SetAuthorName(AnnouncementTitle)
                        .SetAuthorLink(AnnouncementLink)
                        .SetColor($"#{AnnouncementColor:x8}")
                        .SetThumbUrl(AnnouncementThumbnailUrl)
                        .SetText(new StringBuilder()
                            .Append($"<!channel>, this release includes *<{AnnouncementComparisonUrl}|{AnnouncementGitInfo.CommitsText}>*")
                            .AppendLine(AnnouncementGitInfo.NotableCommmitters.Count > 0
                                ? $" with notable contributions from {AnnouncementGitInfo.NotableCommmitters.JoinCommaAnd()}. A round of applause for them! :clap:"
                                : ". No contributions this time. :sweat_smile:")
                            .AppendLine()
                            .AppendLine("Remember that you can call `nuke :update` to update your builds! :bulb:")
                            .AppendLine()
                            .AppendLine(AnnouncementReleaseNotes).ToString())
                        .SetFooter($"Powered by {AnnouncementSponsors.Select(x => $"*<{x.Url}|{x.Text}>*").JoinCommaAnd()}.")),
                SlackWebhook);
        });

    [Parameter] [Secret] readonly string DiscordWebhook;

    Target AnnounceDiscord => _ => _
        .TriggeredBy(Announce)
        .Requires(() => DiscordWebhook)
        .Executes(async () =>
        {
            await SendDiscordMessageAsync(_ => _
                    .SetContent("@everyone")
                    .AddEmbed(_ => _
                        .SetTitle(AnnouncementTitle)
                        .SetColor(AnnouncementColor)
                        .SetThumbnail(new DiscordEmbedThumbnail()
                            .SetUrl(AnnouncementThumbnailUrl))
                        .SetDescription(new StringBuilder()
                            .Append($"This [release]({AnnouncementLink}) includes *[{AnnouncementGitInfo.CommitsText}]({AnnouncementComparisonUrl})*")
                            .AppendLine(AnnouncementGitInfo.NotableCommmitters.Count > 0
                                ? $" with notable contributions from {AnnouncementGitInfo.NotableCommmitters.JoinCommaAnd()}. A round of applause for them! 👏"
                                : ". No contributions this time. 😅")
                            .AppendLine()
                            .AppendLine("Remember that you can call `nuke :update` to update your builds! 💡")
                            .AppendLine()
                            .AppendLine(AnnouncementReleaseNotes).ToString()
                            .Replace("*", "**"))
                        .SetFooter(new DiscordEmbedFooter()
                            .SetText($"Powered by {AnnouncementSponsors.Select(x => x.Text).JoinCommaAnd()}.")
                            .SetIconUrl("https://cdn.discordapp.com/emojis/674275938757771306.webp?size=240&quality=lossless"))),
                DiscordWebhook);
        });

    string AnnouncementTweetText =>
        new StringBuilder()
            .AppendLine($"🔥 Check out the new {MajorMinorPatchVersion} release! 🏗")
            .AppendLine()
            .AppendLine($"More information at 👉 {GitRepository.GetGitHubBrowseUrl(From<IHazChangelog>().ChangelogFile)}").ToString();

    Target AnnounceTwitter => _ => _
        .TriggeredBy(Announce)
        .Requires(() => TwitterCredentials.ConsumerKey)
        .Requires(() => TwitterCredentials.ConsumerSecret)
        .Requires(() => TwitterCredentials.AccessToken)
        .Requires(() => TwitterCredentials.AccessTokenSecret)
        .Executes(async () =>
        {
            var client = new TwitterClient(
                new TwitterCredentials(
                    TwitterCredentials.ConsumerKey,
                    TwitterCredentials.ConsumerSecret,
                    TwitterCredentials.AccessToken,
                    TwitterCredentials.AccessTokenSecret));

            var media = await client.Upload.UploadTweetImageAsync(
                new UploadTweetImageParameters(ReleaseImageFile.ReadAllBytes())
                {
                    MediaCategory = MediaCategory.Image
                });

            await client.Tweets.PublishTweetAsync(
                new PublishTweetParameters
                {
                    Text = AnnouncementTweetText,
                    Medias = new List<IMedia> { media }
                });
        });

    string AnnouncementTootText => AnnouncementTweetText;
    [Parameter] [Secret] readonly string MastodonAccessToken;

    Target AnnounceMastodon => _ => _
        .TriggeredBy(Announce)
        .Requires(() => MastodonAccessToken)
        .Executes(async () =>
        {
            await SendMastodonMessageAsync(_ => _
                    .SetText(AnnouncementTootText)
                    .AddMediaFiles(ReleaseImageFile),
                "https://dotnet.social",
                MastodonAccessToken);
        });

    [Parameter] readonly string GitterRoomId;
    [Parameter] [Secret] readonly string GitterAuthToken;

    Target AnnounceGitter => _ => _
        .TriggeredBy(Announce)
        .Requires(() => GitterAuthToken)
        .Executes(() =>
        {
            SendGitterMessage(new StringBuilder()
                    .AppendLine($"@/all :mega::shipit: **{AnnouncementTitle}**")
                    .AppendLine()
                    .AppendLine(ChangelogSectionNotes.Select(x => x.Replace("- ", "* ")).JoinNewLine()).ToString(),
                GitterRoomId,
                GitterAuthToken);
        });
}
