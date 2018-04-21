// ReSharper disable All
#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Net;
using JetBrains.Annotations;
using Nuke.Core.Tooling;

namespace Nuke.Core.IO
{
    [PublicAPI]
    [Obsolete("Namespace 'Core' is deprecated. Simply do a text replace from 'Nuke.Core' to 'Nuke.Common' to resolve all warnings.")]
    public static class HttpTasks
    {
        [Pure]
        public static string HttpDownloadString(
            string uri,
            Configure<WebClient> configurator = null,
            Action<WebHeaderCollection> headerConfigurator = null)
        {
            var webClient = new WebClient();
            webClient = configurator.InvokeSafe(webClient);
            headerConfigurator?.Invoke(webClient.Headers);

            return webClient.DownloadString(new Uri(uri));
        }

        public static void HttpDownloadFile(
            string uri,
            string path,
            Configure<WebClient> configurator = null,
            Action<WebHeaderCollection> headerConfigurator = null)
        {
            var webClient = new WebClient();
            webClient = configurator.InvokeSafe(webClient);
            headerConfigurator?.Invoke(webClient.Headers);

            FileSystemTasks.EnsureExistingParentDirectory(path);

            webClient.DownloadFile(new Uri(uri), path);
        }
    }
}
