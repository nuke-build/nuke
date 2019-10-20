// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.GitVersion
{
    partial class GitVersionSettings
    {
        private string GetToolPath()
        {
            return GitVersionTasks.GetToolPath(Framework);
        }
    }

    partial class GitVersionTasks
    {
        internal static string GetToolPath(string framework = null)
        {
            return ToolPathResolver.GetPackageExecutable(
                packageId: "GitVersion.Tool|GitVersion.CommandLine",
                packageExecutable: "GitVersion.dll|GitVersion.exe",
                framework: framework);
        }

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
