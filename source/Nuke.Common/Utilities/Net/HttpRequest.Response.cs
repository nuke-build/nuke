// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Nuke.Common.Utilities.Net
{
    public static partial class HttpRequestExtensions
    {
        public static async Task<HttpResponseInspector> GetResponseAsync(
            this HttpRequestBuilder builder,
            CancellationToken cancellationToken = default)
        {
            var response = await builder.Client.SendAsync(builder.Request, cancellationToken);
            return new HttpResponseInspector(response);
        }

        public static HttpResponseInspector GetResponse(this HttpRequestBuilder builder)
        {
            return builder.GetResponseAsync().GetAwaiter().GetResult();
        }
    }

    public class HttpResponseInspector
    {
        private string _body;

        public HttpResponseInspector(HttpResponseMessage response)
        {
            Response = response;
        }

        public HttpResponseMessage Response { get; }

        public async Task<string> GetBodyAsync()
        {
            _body ??= await Response.Content.ReadAsStringAsync();
            return _body;
        }
    }
}
