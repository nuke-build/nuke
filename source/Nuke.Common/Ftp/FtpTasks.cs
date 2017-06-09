// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

#if !NETCORE
using System;
using System.IO;
using System.Linq;
using System.Net;
using JetBrains.Annotations;
using Nuke.Common.FileSystem;
using Nuke.Common.Ftp;
using Nuke.Core;
using Nuke.Core.Execution;

[assembly: IconClass(typeof(FtpTasks), "earth")]

namespace Nuke.Common.Ftp
{
    [PublicAPI]
    public static class FtpTasks
    {
        public static void FtpUploadDirectoryRecursively (string directory, string hostRoot, NetworkCredential networkCredential)
        {
            Logger.Info($"Uploading directory '{directory}' to '{hostRoot}'...");
            
            var files = FileSystemTasks.GlobFiles(directory, "**/*").ToList();
            for (var index = 0; index < files.Count; index++)
            {
                var file = files[index];
                var relativePath = FileSystemTasks.GetRelativePath(directory, file);
                var hostPath = $"{hostRoot}/{relativePath}";

                FtpUploadFileInternal(networkCredential, file, hostPath, info: false, prefix: $"[{index + 1}/{files.Count}] ");
            }
        }

        public static void FtpUploadFile (NetworkCredential credentials, string file, string hostDestination)
        {
            FtpUploadFileInternal(credentials, file, hostDestination, info: true);
        }

        private static void FtpUploadFileInternal (NetworkCredential credentials, string file, string hostDestination, bool info, string prefix = null)
        {
            if (info)
                Logger.Info($"{prefix}Uploading to '{hostDestination}'...");
            else
                Logger.Trace($"{prefix}Uploading to '{hostDestination}'...");

            FtpMakeDirectory(credentials, GetParentPath(hostDestination));

            var request = (FtpWebRequest) WebRequest.Create(hostDestination);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = credentials;

            var content = File.ReadAllBytes(file);
            request.ContentLength = content.Length;

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(content, offset: 0, count: content.Length);
                requestStream.Close();
                // TODO: check response
                //var response = (FtpWebResponse) request.GetResponse ();
                //response.Close ();
            }
        }

        public static void FtpMakeDirectory (NetworkCredential credentials, string path)
        {
            var parentPath = GetParentPath(path);
            if (parentPath != path)
                FtpMakeDirectory(credentials, parentPath);

            var request = WebRequest.Create(path);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = credentials;
            try
            {
                request.GetResponse().Dispose();
            }
            catch
            {
                // ignored
            }
        }

        private static string GetParentPath (string path)
        {
            var uri = new Uri(path);
            return uri.AbsoluteUri.Remove(uri.AbsoluteUri.Length - uri.Segments.Last().Length);
        }
    }
}

#endif
