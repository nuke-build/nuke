// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Net;

namespace Nuke.Common.Tools.Slack
{
    [PublicAPI]
    public static class SlackTasks
    {
        private static HttpClient s_client = new();

        public static void SendSlackMessage(Configure<SlackMessage> configurator, string webhook)
        {
            SendSlackMessageAsync(configurator, webhook).Wait();
        }

        public static async Task SendSlackMessageAsync(Configure<SlackMessage> configurator, string webhook)
        {
            var message = configurator(new SlackMessage());
            var payload = JsonConvert.SerializeObject(message);

            var response = await s_client.CreateRequest(HttpMethod.Post, webhook)
                .WithFormUrlEncodedContent(new Dictionary<string, string> { ["payload"] = payload })
                .GetResponseAsync();

            var responseText = await response.GetBodyAsync();
            Assert.True(responseText == "ok");
        }

        public static async Task<string> SendOrUpdateSlackMessage(Configure<SlackMessage> configurator, string accessToken)
        {
            var message = configurator(new SlackMessage());

            var response = await s_client.CreateRequest(
                    HttpMethod.Post,
                    message.Timestamp == null
                        ? "https://slack.com/api/chat.postMessage"
                        : "https://slack.com/api/chat.update")
                .WithBearerAuthentication(accessToken)
                .WithJsonContent(message)
                .GetResponseAsync();

            var jobject = await response.GetBodyAsJson();
            var error = jobject.GetPropertyValueOrNull<string>("error");
            Assert.True(error == null, error);

            return jobject.GetPropertyStringValue("ts");
        }
    }

    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class SlackMessageActionButton : SlackMessageAction
    {
        [JsonProperty("type")]
        public string Type => "button";
    }
}
