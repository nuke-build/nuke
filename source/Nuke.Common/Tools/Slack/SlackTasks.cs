// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Slack
{
    [PublicAPI]
    public static class SlackTasks
    {
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
    }
}
