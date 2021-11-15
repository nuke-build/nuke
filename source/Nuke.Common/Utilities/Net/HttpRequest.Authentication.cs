// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Nuke.Common.Utilities.Net
{
    public static partial class HttpRequestExtensions
    {
        public static HttpRequestBuilder WithBearerAuthentication(this HttpRequestBuilder builder, string bearerToken)
        {
            builder.Request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            return builder;
        }

        public static HttpRequestBuilder WithBasicAuthentication(this HttpRequestBuilder builder, string username, string password)
        {
            builder.Request.Headers.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));
            return builder;
        }
    }
}
