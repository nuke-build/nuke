// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class HttpTasks
    {
        [Pure]
        public static string HttpDownloadString(
            string uri,
            Configure<WebClient> clientConfigurator = null,
            Action<WebHeaderCollection> headerConfigurator = null,
            Action<WebRequest> requestConfigurator = null)
        {
            return HttpDownloadStringAsync(uri, clientConfigurator, headerConfigurator, requestConfigurator).GetAwaiter().GetResult();
        }

        [Pure]
        public static async Task<string> HttpDownloadStringAsync(
            string uri,
            Configure<WebClient> clientConfigurator = null,
            Action<WebHeaderCollection> headerConfigurator = null,
            Action<WebRequest> requestConfigurator = null)
        {
            WebClient webClient = new CustomWebClient(requestConfigurator);
            webClient = clientConfigurator.InvokeSafe(webClient);
            headerConfigurator?.Invoke(webClient.Headers);

            return await webClient.DownloadStringTaskAsync(new Uri(uri));
        }

        public static void HttpDownloadFile(
            string uri,
            string path,
            Configure<WebClient> clientConfigurator = null,
            Action<WebHeaderCollection> headerConfigurator = null,
            Action<WebRequest> requestConfigurator = null)
        {
            HttpDownloadFileAsync(uri, path, clientConfigurator, headerConfigurator, requestConfigurator).GetAwaiter().GetResult();
        }

        public static async Task HttpDownloadFileAsync(
            string uri,
            string path,
            Configure<WebClient> clientConfigurator = null,
            Action<WebHeaderCollection> headerConfigurator = null,
            Action<WebRequest> requestConfigurator = null)
        {
            WebClient webClient = new CustomWebClient(requestConfigurator);
            webClient = clientConfigurator.InvokeSafe(webClient);
            headerConfigurator?.Invoke(webClient.Headers);

            FileSystemTasks.EnsureExistingParentDirectory(path);

            await webClient.DownloadFileTaskAsync(new Uri(uri), path);
        }

        private class CustomWebClient : WebClient
        {
            private readonly Action<WebRequest> _requestConfigurator;

            public CustomWebClient(Action<WebRequest> requestConfigurator)
            {
                _requestConfigurator = requestConfigurator;
            }

            protected override WebRequest GetWebRequest(Uri address)
            {
                var webRequest = base.GetWebRequest(address);
                _requestConfigurator?.Invoke(webRequest);
                return webRequest;
            }
        }
    }
}
