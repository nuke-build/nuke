// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Build.Framework;
using Microsoft.Build.Tasks;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.Utilities;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.MSBuildTasks
{
    [UsedImplicitly]
    public class ExternalFilesTask : ContextAwareTask
    {
        private static readonly string[] s_predefined =
        {
            "Visible",
            "FullPath",
            "RootDir",
            "Filename",
            "Extension",
            "RelativeDir",
            "Directory",
            "RecursiveDir",
            "Identity",
            "ModifiedTime",
            "CreatedTime",
            "AccessedTime",
            "DefiningProjectFullPath",
            "DefiningProjectDirectory",
            "DefiningProjectName",
            "DefiningProjectExtension"
        };

        [Microsoft.Build.Framework.Required]
        public ITaskItem[] ExternalFiles { get; set; }

        public int Timeout { get; set; }

        protected override bool ExecuteInner()
        {
            return ExternalFiles
                .SelectMany(GetExternalFilesInfo)
                .Select(DownloadExternalFile)
                .ToList()
                .All(x => x.Result);
        }

        private IEnumerable<ExternalFilesData> GetExternalFilesInfo(ITaskItem item)
        {
            var externalFileIdentity = item.GetMetadata("Identity");
            var externalFileBasePath = NormalizePath(Combine(EnvironmentInfo.WorkingDirectory, item.GetMetadataOrNull("BasePath")));

            var tokens = item
                .MetadataNames.Cast<string>()
                .Except(s_predefined)
                .ToDictionary(TemplateUtility.GetTokenName, item.GetMetadata);

            Uri GetUri(string uriString)
            {
                Assert(Uri.TryCreate(uriString, UriKind.RelativeOrAbsolute, out var uri), $"Could not parse URI from '{uriString}'.");
                return uri;
            }

            return GetExternalFilePairs(externalFileIdentity)
                .Select(x => new ExternalFilesData
                             {
                                 Identity = externalFileIdentity,
                                 Uri = GetUri(x.UriString),
                                 Tokens = tokens,
                                 OutputPath = Path.Combine(externalFileBasePath, x.RelativePath)
                             });
        }

        private async Task<bool> DownloadExternalFile(ExternalFilesData data)
        {
            try
            {
                var previousHash = File.Exists(data.OutputPath) ? FileSystemTasks.GetFileHash(data.OutputPath) : null;

                var template = (await HttpTasks.HttpDownloadStringAsync(data.Uri.OriginalString)).SplitLineBreaks();
                TextTasks.WriteAllLines(data.OutputPath, TemplateUtility.FillTemplate(template, data.Tokens));

                var newHash = FileSystemTasks.GetFileHash(data.OutputPath);
                if (newHash != previousHash)
                    LogWarning(message: $"External file '{data.OutputPath}' has been updated.", file: data.Identity);

                return true;
            }
            catch (Exception exception)
            {
                LogError(message: exception.Message, file: data.Identity);
                return false;
            }
        }

        // https://github.com/nuke-build/common/tree/develop/source/Nuke.GlobalTool/templates
        // https://github.com/nuke-build/common/blob/develop/source/Nuke.GlobalTool/templates/_build.sdk.csproj
        // https://raw.githubusercontent.com/nuke-build/common/develop/source/Nuke.GlobalTool/templates/_build.sdk.csproj
        private IEnumerable<(string UriString, string RelativePath)> GetExternalFilePairs(string externalFileIdentity)
        {
            var regex = new Regex(@"^https://github.com/(?'owner'[\w-]+)/(?'name'[\w-]+)/(?'method'(blob|tree)+)/(?'branch'[\w-]+)/(?'path'.+)$");
            var match = regex.Match(externalFileIdentity);

            if (!match.Success)
                // TODO: ReSharper: rename introduces explicit name
                return new[] { (externalFileIdentity, string.Empty) };

            var identifier = $"{match.Groups["owner"].Value}/{match.Groups["name"].Value}";
            var branch = match.Groups["branch"].Value;
            var path = match.Groups["path"].Value;
            var method = match.Groups["method"].Value;

            return method switch
            {
                "blob" => new[] { ($"https://raw.githubusercontent.com/{identifier}/{method}/{branch}/{path}", string.Empty) },
                "tree" => GitRepository.FromUrl($"https://github.com/{identifier}").GetGitHubDownloadUrls(path).Result,
                _ => throw new NotSupportedException($"External URL '{externalFileIdentity}' is not supported.")
            };
        }

        private class ExternalFilesData
        {
            public string Identity { get; set; }
            public Uri Uri { get; set; }
            public Dictionary<string, string> Tokens { get; set; }
            public string OutputPath { get; set; }
        }
    }
}
