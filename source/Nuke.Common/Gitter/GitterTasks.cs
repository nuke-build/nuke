// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Nuke.Common.Utilities.Net;

namespace Nuke.Common.Gitter
{
    //[PublicAPI]
    //[Headers("Accept: application/json")]
    //public interface IGitterRestClient
    //{
    //    [Post("/rooms/{roomId}/chatMessages")]
    //    Task SendMessage (string roomId, [Body(BodySerializationMethod.UrlEncoded)] [AliasAs("text")] string message);
    //}

    public static class GitterTasks
    {
        private static HttpClient s_client = new();

        public static void SendGitterMessage(string message, string roomId, string token)
        {
            SendGitterMessageAsync(message, roomId, token).Wait();
        }

        public static async Task SendGitterMessageAsync(string message, string roomId, string token)
        {
            var response = await s_client.CreateRequest(HttpMethod.Post, $"https://api.gitter.im/v1/rooms/{roomId}/chatMessages")
                .WithBearerAuthentication(token)
                .GetResponseAsync();

            response.AssertSuccessfulStatusCode();
        }
    }
}
