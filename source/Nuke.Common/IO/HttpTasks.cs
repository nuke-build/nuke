// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

#if !NETCORE
using System;
using System.Linq;
using System.Net;
using JetBrains.Annotations;
using Nuke.Core.Tooling;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class HttpTasks
    {
        [Pure]
        public static string HttpDownloadString (
            string uri,
            Configure<WebClient> configurator = null,
            Action<WebHeaderCollection> headerConfigurator = null)
        {
            var webClient = new WebClient();
            webClient = configurator.InvokeSafe(webClient);
            headerConfigurator?.Invoke(webClient.Headers);

            return webClient.DownloadString(new Uri(uri));
        }

        public static void HttpDownloadFile (
            string uri,
            string path,
            Configure<WebClient> configurator = null,
            Action<WebHeaderCollection> headerConfigurator = null)
        {
            var webClient = new WebClient();
            webClient = configurator.InvokeSafe(webClient);
            headerConfigurator?.Invoke(webClient.Headers);

            webClient.DownloadFile(new Uri(uri), path);
        }
    }
}
#endif
