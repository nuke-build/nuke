// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tools.GitVersion
{
    partial class GitVersionTasks
    {
        [CanBeNull]
        private static GitVersion GetResult(IProcess process, GitVersionSettings toolSettings)
        {
            var output = process.Output.EnsureOnlyStd().Select(x => x.Text).ToList();
            var settings = new JsonSerializerSettings { ContractResolver = new AllWritableContractResolver() };
            return JsonConvert.DeserializeObject<GitVersion>(string.Join("\r\n", output), settings);
        }

        private class AllWritableContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty([NotNull] MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);
                property.Writable = true;
                return property;
            }
        }

        private static string GetToolPath()
        {
            var package = new[]
                          {
                              "GitVersion.CommandLine.DotNetCore",
                              "GitVersion.CommandLine"
                          }
                .Select(x => NuGetPackageResolver.TryGetLocalInstalledPackage(x, ToolPathResolver.NuGetPackagesConfigFile))
                .WhereNotNull()
                .FirstOrDefault().NotNull("package != null");
            return Directory.GetFiles(package.Directory, "GitVersion.*", SearchOption.AllDirectories)
                .FirstOrDefault(x => x.EndsWithOrdinalIgnoreCase(".dll") || x.EndsWithOrdinalIgnoreCase(".exe"))
                .NotNull("executable != null");
        }
    }

    [PublicAPI]
    public static class GitVersionExtensions
    {
        public static string GetNormalizedAssemblyVersion(this GitVersion gitVersion)
        {
            return $"{gitVersion.Major}.{gitVersion.Minor}.0";
        }

        public static string GetNormalizedFileVersion(this GitVersion gitVersion)
        {
            return gitVersion.MajorMinorPatch;
        }
    }
}
