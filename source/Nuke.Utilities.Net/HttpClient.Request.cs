// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Net.Http;

namespace Nuke.Common.Utilities.Net
{
    public static partial class HttpClientExtensions
    {
        /// <summary>
        /// Creates an HTTP request.
        /// </summary>
        public static HttpRequestBuilder CreateRequest(this HttpClient client, HttpMethod method, string relativeUri)
        {
            return new HttpRequestBuilder(client, new HttpRequestMessage(method, relativeUri));
        }

        /// <summary>
        /// Creates an HTTP request.
        /// </summary>
        public static HttpRequestBuilder CreateRequest(this HttpClient client, HttpMethod method, string baseAddress, string relativeUri)
        {
            return new HttpRequestBuilder(client, new HttpRequestMessage(method, new Uri(new Uri(baseAddress), relativeUri)));
        }
    }

    public class HttpRequestBuilder
    {
        public HttpRequestBuilder(HttpClient client, HttpRequestMessage request)
        {
            Client = client;
            Request = request;
        }

        public HttpClient Client { get; }
        public HttpRequestMessage Request { get; }
    }
}
