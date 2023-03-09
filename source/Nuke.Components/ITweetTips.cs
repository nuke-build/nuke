// Copyright 2023 Maintainers of NUKE.
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
using Serilog;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

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
                var sortedTweets = tweetDirectory.GlobFiles("*.md").OrderBy(x => (string) x);
                foreach (var tweetFile in sortedTweets)
                {
                    var part = Path.GetFileNameWithoutExtension(tweetFile);
                    var text = tweetFile.ReadAllText();
                    var media = tweetDirectory.GlobFiles($"{part}*.png", $"{part}*.jpeg", $"{part}*.jpg", $"{part}*.gif")
                        .Select(async x => await client.Upload.UploadTweetImageAsync(
                            new UploadTweetImageParameters(x.ReadAllBytes())
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

                Log.Information("Sent tweet {Url}", sentTweets.First().Url);
            });
    }
}
