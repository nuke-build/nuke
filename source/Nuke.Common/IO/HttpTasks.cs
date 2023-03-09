// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class HttpTasks
    {
        public static TimeSpan DefaultTimeout = TimeSpan.FromSeconds(5);

        [Pure]
        public static string HttpDownloadString(
            string uri,
            Configure<HttpClient> clientConfigurator = null,
            Action<HttpRequestHeaders> headerConfigurator = null)
        {
            return HttpDownloadStringAsync(uri, clientConfigurator, headerConfigurator).GetAwaiter().GetResult();
        }

        [Pure]
        public static async Task<string> HttpDownloadStringAsync(
            string uri,
            Configure<HttpClient> clientConfigurator = null,
            Action<HttpRequestHeaders> headerConfigurator = null)
        {
            var httpClient = CreateHttpClient(clientConfigurator, headerConfigurator);
            return await httpClient.GetAsync(uri).Result.Content.ReadAsStringAsync();
        }

        public static void HttpDownloadFile(
            string uri,
            string path,
            FileMode mode = FileMode.Create,
            Configure<HttpClient> clientConfigurator = null,
            Action<HttpRequestHeaders> headerConfigurator = null)
        {
            HttpDownloadFileAsync(uri, path, mode, clientConfigurator, headerConfigurator).GetAwaiter().GetResult();
        }

        public static async Task HttpDownloadFileAsync(
            string uri,
            AbsolutePath path,
            FileMode mode = FileMode.Create,
            Configure<HttpClient> clientConfigurator = null,
            Action<HttpRequestHeaders> headerConfigurator = null)
        {
            var httpClient = CreateHttpClient(clientConfigurator, headerConfigurator);
            var response = await httpClient.GetAsync(uri);
            Assert.True(response.IsSuccessStatusCode, $"{response.ReasonPhrase}: {uri}");

            path.Parent.CreateDirectory();
            await using var fileStream = File.Open(path, mode);
            await response.Content.CopyToAsync(fileStream);
        }

        private static HttpClient CreateHttpClient(
            Configure<HttpClient> clientConfigurator = null,
            Action<HttpRequestHeaders> headerConfigurator = null)
        {
            var httpClient = new HttpClient { Timeout = DefaultTimeout };
            clientConfigurator?.Invoke(httpClient);
            headerConfigurator?.Invoke(httpClient.DefaultRequestHeaders);
            return httpClient;
        }
    }
}
