// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nuke.Common.Gitter;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tools.Slack
{
    [PublicAPI]
    public static class SlackTasks
    {
#if NETCORE
        public static void SendSlackMessage(Configure<SlackMessage> configurator, string webhook)
        {
            SendSlackMessageAsync(configurator, webhook).Wait();
        }

        public static async Task SendSlackMessageAsync(Configure<SlackMessage> configurator, string webhook)
        {
            var message = configurator(new SlackMessage());
            var payload = JsonConvert.SerializeObject(message);
            var data = new NameValueCollection { ["payload"] = payload };

            using var client = new WebClient();

            client.Headers["Content-Type"] = "application/x-www-form-urlencoded";

            var stringBuilder = new StringBuilder();
            var str = string.Empty;
            foreach (var key in data.AllKeys)
            {
                stringBuilder
                    .Append(str)
                    .Append(HttpUtility.UrlEncode(key))
                    .Append(value: '=')
                    .Append(HttpUtility.UrlEncode(data[key]));

                str = "&";
            }

            var bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());

            var response = await client.UploadDataTaskAsync(webhook, "POST", bytes);
            var responseText = Encoding.UTF8.GetString(response);
            ControlFlow.Assert(responseText == "ok", $"'{responseText}' == 'ok'");
        }
#endif

        public static async Task<string> SendOrUpdateSlackMessage(Configure<SlackMessage> configurator, string accessToken)
        {
            var message = configurator(new SlackMessage());
            var response = await PostMessage(
                message.Timestamp == null
                    ? "https://slack.com/api/chat.postMessage"
                    : "https://slack.com/api/chat.update",
                message,
                accessToken);
            return response.GetPropertyStringValue("ts");
        }

        private static async Task<JObject> PostMessage(string url, object message, string accessToken)
        {
            var httpHandler = new GitterTasks.AuthenticatedHttpClientHandler(accessToken);
            using var client = new HttpClient(httpHandler);

            var payload = JsonConvert.SerializeObject(message, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var response = await client.PostAsync(url, new StringContent(payload, Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();
            ControlFlow.Assert(response.StatusCode == HttpStatusCode.OK, responseContent);

            var jobject = SerializationTasks.JsonDeserialize<JObject>(responseContent);
            var error = jobject.GetPropertyValueOrNull<string>("error");
            ControlFlow.Assert(error == null, error);
            return jobject;
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
