// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Nuke.Common.Utilities.Net
{
    public static partial class HttpRequestExtensions
    {
        public static HttpRequestBuilder WithJsonContent<T>(this HttpRequestBuilder builder, T obj)
        {
            return builder.WithStringContent(JsonConvert.SerializeObject(obj), "application/json");
        }

        public static HttpRequestBuilder WithStringContent(this HttpRequestBuilder builder, string content, string mediaType)
        {
            builder.Request.Content = new StringContent(content, Encoding.UTF8, mediaType);
            return builder;
        }

        public static HttpRequestBuilder WithFormUrlEncodedContent(this HttpRequestBuilder builder, IDictionary<string, string> dictionary)
        {
            builder.Request.Content = new FormUrlEncodedContent(dictionary);
            return builder;
        }

        public static HttpRequestBuilder WithMultipartFormDataContent(
            this HttpRequestBuilder builder,
            Func<MultipartFormDataContent, MultipartFormDataContent> configurator)
        {
            builder.Request.Content = configurator.Invoke(new MultipartFormDataContent());
            return builder;
        }

        public static MultipartFormDataContent AddStringContent(this MultipartFormDataContent data, string name, string content)
        {
            data.Add(new StringContent(content), name);
            return data;
        }

        public static MultipartFormDataContent AddStreamContent(
            this MultipartFormDataContent data,
            string name,
            Stream content,
            string filename,
            string mediaType = null)
        {
            var streamContent = new StreamContent(content);
            if (mediaType != null)
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(mediaType);

            data.Add(streamContent, name, filename);
            return data;
        }
    }
}
