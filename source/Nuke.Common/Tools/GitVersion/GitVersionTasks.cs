// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nuke.Core;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.GitVersion
{
    partial class GitVersionTasks
    {
        public static GitVersionSettings DefaultGitVersion => new GitVersionSettings()
            .SetWorkingDirectory(NukeBuild.Instance.RootDirectory);

        [CanBeNull]
        private static GitVersion GetResult(IProcess process, GitVersionSettings toolSettings, [CanBeNull] ProcessSettings processSettings)
        {
            if (!(processSettings?.RedirectOutput ?? false))
            {
                Logger.Warn(
                    $"{nameof(GitVersionTasks)}.{nameof(GitVersion)} can only calculate a return value when 'RedirectOutput' is set to true.");
                return null;
            }

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
