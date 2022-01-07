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
            return builder.WithAuthentication("Bearer", bearerToken);
        }

        public static HttpRequestBuilder WithBasicAuthentication(this HttpRequestBuilder builder, string username, string password)
        {
            return builder.WithAuthentication("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));
        }

        public static HttpRequestBuilder WithAuthentication(this HttpRequestBuilder builder, string scheme, string parameter)
        {
            builder.Request.Headers.Authorization = new AuthenticationHeaderValue(scheme, parameter);
            return builder;
        }
    }
}
