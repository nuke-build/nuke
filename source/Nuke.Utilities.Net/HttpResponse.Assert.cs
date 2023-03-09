// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;

namespace Nuke.Common.Utilities.Net
{
    public static partial class HttpResponseExtensions
    {
        /// <summary>
        /// Asserts the status code of an HTTP response.
        /// </summary>
        public static HttpResponseInspector AssertStatusCode(
            this HttpResponseInspector inspector,
            HttpStatusCode status,
            Func<HttpResponseMessage, string> errorSelector = null)
        {
            var response = inspector.Response;
            if (response.StatusCode != status)
            {
                throw new HttpResponseException(
                    errorSelector == null
                        ? $"Expected status code {status} but found {response.StatusCode}"
                        : errorSelector.Invoke(response));
            }

            return inspector;
        }

        /// <summary>
        /// Asserts the status code of an HTTP response.
        /// </summary>
        public static HttpResponseInspector AssertStatusCode(this HttpResponseInspector inspector, Func<HttpStatusCode, string> errorSelector)
        {
            var response = inspector.Response;
            if (errorSelector.Invoke(response.StatusCode) is { } error)
                throw new HttpResponseException(error);

            return inspector;
        }

        /// <summary>
        /// Asserts a successful status code for an HTTP response.
        /// </summary>
        public static HttpResponseInspector AssertSuccessfulStatusCode(this HttpResponseInspector inspector)
        {
            inspector.Response.EnsureSuccessStatusCode();
            return inspector;
        }

        /// <summary>
        /// Asserts an HTTP response.
        /// </summary>
        public static HttpResponseInspector AssertResponse(this HttpResponseInspector inspector, Func<HttpResponseMessage, string> errorSelector)
        {
            var response = inspector.Response;
            if (errorSelector.Invoke(response) is { } error)
                throw new HttpResponseException(error);

            return inspector;
        }
    }

    [Serializable]
    public class HttpResponseException : Exception
    {
        public HttpResponseException()
        {
        }

        public HttpResponseException(string message)
            : base(message)
        {
        }

        public HttpResponseException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected HttpResponseException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
