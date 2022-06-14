---
title: Chats & Social Media
---

import Tabs from '@theme/Tabs';
import TabItem from '@theme/TabItem';

As a final step of your build automation process, you may want to report errors or announce a new version through different chats and social media channels. NUKE comes with basic support for the most common platforms.

<Tabs>
  <TabItem value="slack" label="Slack" default>

You can send a [Slack](https://slack.com/) messages as follows:

```csharp
// using static Nuke.Common.Tools.Slack.SlackTasks;

[Parameter] [Secret] readonly string SlackWebhook;

Target Send => _ => _
    .Executes(async () =>
    {
        await SendSlackMessageAsync(_ => _
                .SetText("Hello from NUKE!"),
            SlackWebhook);
    });
```

:::note
For more advanced scenarios, check out the [SlackAPI](https://github.com/Inumedia/SlackAPI) or [SlackNet](https://github.com/soxtoby/SlackNet) project.
:::

  </TabItem>
  <TabItem value="teams" label="Microsoft Teams">

You can send a [Microsoft Teams](https://www.microsoft.com/en/microsoft-teams/group-chat-software) messages as follows:

```csharp
// using static Nuke.Common.Tools.Teams.TeamsTasks;

[Parameter] [Secret] readonly string TeamsWebhook;

Target Send => _ => _
    .Executes(async () =>
    {
        await SendTeamsMessageAsync(_ => _
                .SetText("Hello from NUKE!"),
            TeamsWebhook)
    });
```

  </TabItem>
  <TabItem value="twitter" label="Twitter">

You can send a [Twitter](https://twitter.com/) messages as follows:

```csharp
// using static Nuke.Common.Tools.Twitter.TwitterTasks;

[Parameter] [Secret] readonly string TwitterConsumerKey;
[Parameter] [Secret] readonly string TwitterConsumerSecret;
[Parameter] [Secret] readonly string TwitterAccessToken;
[Parameter] [Secret] readonly string TwitterAccessTokenSecret;

Target Send => _ => _
    .Executes(async () =>
    {
        await SendTweetAsync(
            message: "Hello from NUKE",
            TwitterConsumerKey,
            TwitterConsumerSecret,
            TwitterAccessToken,
            TwitterAccessTokenSecret);
    });
```

:::note
For more advanced scenarios, check out the [Tweetinvi](https://github.com/linvi/tweetinvi) project.
:::

  </TabItem>
  <TabItem value="gitter" label="Gitter">

You can send a [Gitter](https://gitter.im/) messages as follows:

```csharp
// using static Nuke.Common.Tools.Gitter.GitterTasks;

[Parameter] readonly string GitterRoomId;
[Parameter] [Secret] readonly string GitterAuthToken;

Target Send => _ => _
    .Executes(() =>
    {
        SendGitterMessage(
            message: "Hello from NUKE",
            GitterRoomId,
            GitterAuthToken);
    });
```

:::note
For more advanced scenarios, check out the [gitter-api-pcl](https://github.com/uwp-squad/gitter-api-pcl) project.
:::

  </TabItem>
</Tabs>
