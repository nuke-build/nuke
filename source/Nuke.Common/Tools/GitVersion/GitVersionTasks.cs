// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tools.GitVersion
{
    partial class GitVersionSettings
    {
        private string GetProcessToolPath()
        {
            return GitVersionTasks.GetToolPath(Framework);
        }
    }

    partial class GitVersionTasks
    {
        internal static string GetToolPath(string framework = null)
        {
            return NuGetToolPathResolver.GetPackageExecutable(
                packageId: "GitVersion.Tool|GitVersion.CommandLine",
                packageExecutable: "GitVersion.dll|GitVersion.exe",
                framework: framework);
        }

        [CanBeNull]
        private static GitVersion GetResult(IProcess process, GitVersionSettings toolSettings)
        {
            var output = process.Output.EnsureOnlyStd().Select(x => x.Text).JoinNewLine();
            try
            {
                return output.GetJson<GitVersion>(new JsonSerializerSettings { ContractResolver = new AllWritableContractResolver() });
            }
            catch (Exception exception)
            {
                throw new Exception($"Cannot parse {nameof(GitVersion)} output:".Concat(new[] { output }).JoinNewLine(), exception);
            }
        }
    }
}
