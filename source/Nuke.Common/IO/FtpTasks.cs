// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Net;
using JetBrains.Annotations;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class FtpTasks
    {
        [CanBeNull]
        public static NetworkCredential FtpCredentials { get; set; }

        public static void FtpUploadDirectoryRecursively(string directory, string hostRoot)
        {
            Logger.Info($"Uploading directory '{directory}' to '{hostRoot}'...");

            var files = PathConstruction.GlobFiles(directory, "**/*").ToList();
            for (var index = 0; index < files.Count; index++)
            {
                var file = files[index];
                var relativePath = PathConstruction.GetRelativePath(directory, file);
                var hostPath = $"{hostRoot}/{relativePath}";

                FtpUploadFileInternal(file, hostPath, $"[{index + 1}/{files.Count}] ");
            }
        }

        public static void FtpUploadFile(string file, string hostDestination)
        {
            FtpUploadFileInternal(file, hostDestination);
        }

        private static void FtpUploadFileInternal(string file, string hostDestination, string prefix = null)
        {
            Logger.Info($"{prefix}Uploading to '{hostDestination}'...");

            ControlFlow.ExecuteWithRetry(() =>
            {
                FtpMakeDirectory(GetParentPath(hostDestination));

                var request = WebRequest.Create(hostDestination);
                request.Credentials = FtpCredentials;
                request.Method = WebRequestMethods.Ftp.UploadFile;

                var content = File.ReadAllBytes(file);
                request.ContentLength = content.Length;

                using var requestStream = request.GetRequestStream();
                requestStream.Write(content, offset: 0, count: content.Length);
                requestStream.Close();

                // TODO: check response
                //var response = (FtpWebResponse) request.GetResponse ();
                //response.Close ();
            });
        }

        public static void FtpMakeDirectory(string path)
        {
            var parentPath = GetParentPath(path);
            if (parentPath != path)
                FtpMakeDirectory(parentPath);

            var request = WebRequest.Create(path);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = FtpCredentials;
            try
            {
                request.GetResponse().Dispose();
            }
            catch
            {
                // ignored
            }
        }

        private static string GetParentPath(string path)
        {
            var uri = new Uri(path);
            return uri.AbsoluteUri.Remove(uri.AbsoluteUri.Length - uri.Segments.Last().Length);
        }
    }
}
