// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.Git;
using Nuke.Common.Utilities;
using Serilog;

#if !NUKE_ENTERPRISE
[RestartWithEnterprise]
#endif
partial class Build
{
    [Parameter] [Secret] readonly string EnterpriseAccessToken;

    public class RestartWithEnterpriseAttribute : BuildExtensionAttributeBase, IOnBuildCreated
    {
        public void OnBuildCreated(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var accessToken = EnvironmentInfo.GetParameter<string>(nameof(EnterpriseAccessToken));
            var enterpriseDirectory = ((Build) build).ExternalRepositoriesDirectory / "enterprise";
            if (accessToken.IsNullOrEmpty())
            {
                var projectFileContent = @"
<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net5.0</TargetFramework>
    <IsPackable>False</IsPackable>
  </PropertyGroup>

</Project>
";

                void WriteProjectFileDummy(string file)
                {
                    FileSystemTasks.EnsureExistingParentDirectory(file);
                    File.WriteAllText(file, projectFileContent);
                }

                WriteProjectFileDummy(enterpriseDirectory / "src" / "Nuke.Enterprise" / "Nuke.Enterprise.csproj");
                WriteProjectFileDummy(enterpriseDirectory / "src" / "Nuke.Enterprise.Tests" / "Nuke.Enterprise.Tests.csproj");

                return;
            }

            var url = $"https://{accessToken}@github.com/nuke-build/enterprise";
            GitTasks.Git($"clone {url} {enterpriseDirectory}", logOutput: false, logInvocation: false);

            Log.Information("Restarting with Nuke.Enterprise integration ...");
            var arguments = Environment.CommandLine.Split(' ').Skip(1).JoinSpace();
            var process = Process.Start(DotNetTasks.DotNetPath, $"run --project {BuildProjectFile} -- {arguments}");
            process.NotNull().WaitForExit();
            Environment.Exit(process.ExitCode);
        }

        public override float Priority => 1337;
    }
}
