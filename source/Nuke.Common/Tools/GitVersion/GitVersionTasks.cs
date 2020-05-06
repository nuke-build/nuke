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
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

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
                packageExecutable: "GitVersion.dll|GitVersion.exe|gitversion.dll|gitversion.exe",
                framework: framework);
        }

        [CanBeNull]
        private static GitVersion GetResult(IProcess process, GitVersionSettings toolSettings)
        {
            try
            {
                var output = process.Output.EnsureOnlyStd().Select(x => x.Text).ToList();
                var settings = new JsonSerializerSettings { ContractResolver = new AllWritableContractResolver() };
                return JsonConvert.DeserializeObject<GitVersion>(string.Join("\r\n", output), settings);
            }
            catch (Exception exception)
            {
                throw new Exception($"{nameof(GitVersion)} exited with code {process.ExitCode}, but cannot parse output as JSON:"
                        .Concat(process.Output.Select(x => x.Text)).JoinNewLine(),
                    exception);
            }
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
}
