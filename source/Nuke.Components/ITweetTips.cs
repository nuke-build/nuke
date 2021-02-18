// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using static Nuke.Common.IO.TextTasks;
using static Nuke.Common.Logger;

namespace Nuke.Components
{
    [PublicAPI]
    public interface ITweetTips : IHazTwitterCredentials
    {
        AbsolutePath TweetDirectory { get; }

        Target Tweet => _ => _
            .Requires(() => ConsumerKey)
            .Requires(() => ConsumerSecret)
            .Requires(() => AccessToken)
            .Requires(() => AccessTokenSecret)
            .Executes(async () =>
            {
                var client = new TwitterClient(
                    new TwitterCredentials(
                        ConsumerKey,
                        ConsumerSecret,
                        AccessToken,
                        AccessTokenSecret));

                var tweetDirectories = TweetDirectory.GlobDirectories("*").OrderBy(x => (string) x).ToList();
                var index = (int) (DateTime.Now.Ticks / TimeSpan.FromDays(7).Ticks) %  tweetDirectories.Count;
                var tweetDirectory = tweetDirectories.Last();

                var sentTweets = new List<ITweet>();
                var sortedTweets = tweetDirectory.GlobFiles("*.md").Select(x => x.ToString()).OrderBy(x => x);
                foreach (var tweetFile in sortedTweets)
                {
                    var part = Path.GetFileNameWithoutExtension(tweetFile);
                    var text = ReadAllText(tweetFile);
                    var media = tweetDirectory.GlobFiles($"{part}*.png", $"{part}*.jpeg", $"{part}*.jpg", $"{part}*.gif")
                        .Select(async x => await client.Upload.UploadTweetImageAsync(
                            new UploadTweetImageParameters(ReadAllBytes(x))
                            {
                                MediaCategory = x.ToString().EndsWithOrdinalIgnoreCase("gif")
                                    ? MediaCategory.Gif
                                    : MediaCategory.Image
                            }))
                        .Select(x => x.Result).ToList();

                    var tweetParameters = new PublishTweetParameters
                                          {
                                              InReplyToTweetId = sentTweets.LastOrDefault()?.Id,
                                              Text = text,
                                              Medias = media
                                          };

                    var tweet = await client.Tweets.PublishTweetAsync(tweetParameters);
                    sentTweets.Add(tweet);
                }

                Info($"Sent tweet: {sentTweets.First().Url}");
            });
    }
}
