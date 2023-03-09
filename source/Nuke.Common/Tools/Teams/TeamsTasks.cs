// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Net;

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

            using var client = new HttpClient();

            var response = await client.CreateRequest(HttpMethod.Post, webhook)
                .WithJsonContent(messageJson)
                .GetResponseAsync();

            var responseText = await response.GetBodyAsync();
            Assert.True(responseText == "1", $"'{responseText}' == '1'");
        }
    }
}
