// Copyright 2023 Maintainers of NUKE.
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
        /// <summary>
        /// Sets the bearer token for authentication.
        /// </summary>
        public static HttpRequestBuilder WithBearerAuthentication(this HttpRequestBuilder builder, string bearerToken)
        {
            return builder.WithAuthentication("Bearer", bearerToken);
        }

        /// <summary>
        /// Sets the username and password for authentication.
        /// </summary>
        public static HttpRequestBuilder WithBasicAuthentication(this HttpRequestBuilder builder, string username, string password)
        {
            return builder.WithAuthentication("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));
        }

        /// <summary>
        /// Sets the scheme and parameter for authentication.
        /// </summary>
        public static HttpRequestBuilder WithAuthentication(this HttpRequestBuilder builder, string scheme, string parameter)
        {
            builder.Request.Headers.Authorization = new AuthenticationHeaderValue(scheme, parameter);
            return builder;
        }
    }
}
