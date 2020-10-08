// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Teams
{
    [PublicAPI]
    public static class TeamsTasks
    {
        public static void SendTeamsMessage(Configure<TeamsMessage> configurator, string webhook)
        {
            SendTeamsMessageAsync(configurator, webhook).Wait();
        }

        public static async Task SendTeamsMessageAsync(Configure<TeamsMessage> configurator, string webhook)
        {
            var message = configurator(new TeamsMessage());
            var messageJson = JsonConvert.SerializeObject(message);

            using var client = new WebClient();

            client.Headers["Content-Type"] = "application/json";

            var response = await client.UploadDataTaskAsync(webhook, "POST", Encoding.UTF8.GetBytes(messageJson) );
            var responseText = Encoding.UTF8.GetString(response);
            ControlFlow.Assert(responseText == "1", $"'{responseText}' == '1'");
        }
    }
}
