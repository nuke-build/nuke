// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

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
        public static void SendGitterMessage(string message, string roomId, string token)
        {
            SendGitterMessageAsync(message, roomId, token).Wait();
        }

        public static async Task SendGitterMessageAsync(string message, string roomId, string token)
        {
            var client = new HttpClient(new AuthenticatedHttpClientHandler(token));

            await client.PostAsync(
                $"https://api.gitter.im/v1/rooms/{roomId}/chatMessages",
                new FormUrlEncodedContent(new Dictionary<string, string> { { "text", message } }));
        }

        internal class AuthenticatedHttpClientHandler : HttpClientHandler
        {
            private readonly string _token;

            public AuthenticatedHttpClientHandler(string token)
            {
                _token = token;
            }

            protected override async Task<HttpResponseMessage> SendAsync([NotNull] HttpRequestMessage request, CancellationToken cancellationToken)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                return await base.SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
            }
        }
    }
}
