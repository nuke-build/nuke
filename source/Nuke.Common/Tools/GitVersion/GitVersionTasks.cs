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
