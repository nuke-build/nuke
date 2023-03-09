// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Serilog;

namespace Nuke.Common.Execution
{
    internal static class ToolRequirementService
    {
        public static void EnsureToolRequirements(INukeBuild build, IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            var requirements = build.GetType().GetCustomAttributes<RequiresAttribute>().Select(x => x.GetRequirement())
                .Concat(executionPlan.SelectMany(x => x.ToolRequirements)).ToList();
            var directory = build.TemporaryDirectory;

            InstallNuGetPackages(requirements.OfType<NuGetPackageRequirement>().ToList(), directory);
            InstallNpmPackages(requirements.OfType<NpmPackageRequirement>().ToList(), directory);
            InstallAptGetPackages(requirements.OfType<AptGetPackageRequirement>().ToList(), directory);
        }

        private static void InstallNuGetPackages(IReadOnlyCollection<NuGetPackageRequirement> requirements, AbsolutePath directory)
        {
            if (requirements.Count == 0)
                return;

            var projectFile = directory / "nuget.csproj";
            NuGetToolPathResolver.NuGetPackagesConfigFile = projectFile;
            NuGetToolPathResolver.NuGetAssetsConfigFile = projectFile.Parent / "obj" / "project.assets.json";

            var packages = requirements.OrderBy(x => x.PackageId).ThenBy(x => x.Version).ToList();
            var groupedPackages = packages.GroupBy(x => x.PackageId, x => $"[{x.Version}]");

            var content = $"""
                <Project Sdk="Microsoft.NET.Sdk">

                  <PropertyGroup>
                    <TargetFramework>net6.0</TargetFramework>
                  </PropertyGroup>

                  <ItemGroup>
                {groupedPackages.Select(x => $"""    <PackageDownload Include="{x.Key}" Version="{x.JoinSemicolon()}" />""").JoinNewLine()}
                  </ItemGroup>

                </Project>
                """;

            if (projectFile.Exists() && projectFile.ReadAllText().StartsWith(content))
                return;

            Log.Information("Installing NuGet packages...");
            packages.ForEach(x => Log.Verbose("Installing {Id} ({Version})...", x.PackageId, x.Version));

            projectFile.WriteAllText(content);
            var dotnet = ToolResolver.GetEnvironmentOrPathTool("dotnet");
            dotnet.Invoke($"restore", workingDirectory: projectFile.Parent, logInvocation: false, logOutput: false);
        }

        private static void InstallNpmPackages(IReadOnlyCollection<NpmPackageRequirement> requirements, AbsolutePath directory)
        {
            if (requirements.Count == 0)
                return;

            var packageJsonFile = directory / "package.json";
            NpmToolPathResolver.NpmPackageJsonFile = packageJsonFile;

            var packages = requirements.OrderBy(x => x.PackageId).ToList();

            var content = $$"""
                {
                  "dependencies": {
                {{packages.Select(x => $"""    "{x.PackageId}": "{x.Version}",""").JoinNewLine().TrimEnd(',')}}
                  }
                }
                """;

            if (packageJsonFile.Exists() && packageJsonFile.ReadAllText().StartsWith(content))
                return;

            Log.Information("Installing NPM packages...");
            packages.ForEach(x => Log.Verbose("Installing {Id} ({Version})...", x.PackageId, x.Version));

            packageJsonFile.WriteAllText(content);
            var npm = ToolResolver.GetEnvironmentOrPathTool("npm");
            npm.Invoke($"install", workingDirectory: packageJsonFile.Parent, logInvocation: false, logOutput: false);
        }

        private static void InstallAptGetPackages(IReadOnlyCollection<AptGetPackageRequirement> requirements, AbsolutePath directory)
        {
            if (requirements.Count == 0)
                return;

            var packages = requirements.OrderBy(x => x.PackageId).ToList();
            Assert.True(EnvironmentInfo.IsLinux, "AptGet is only available on Linux");

            var installScript = directory / "apt-get.sh";

            var content = $"""
                apt-get update
                apt-get install -y \
                {packages.Select(x => $"  {x.PackageId} \\").JoinNewLine().TrimEnd("\\")}
                """;

            if (installScript.Exists() && installScript.ReadAllText().StartsWith(content))
                return;

            Log.Information("Installing AptGet packages...");
            packages.ForEach(x => Log.Verbose("Installing {Id}...", x.PackageId));

            installScript.WriteAllText(content);
            ProcessTasks.StartShell($"sudo {installScript}", logInvocation: false, logOutput: false).AssertZeroExitCode();
        }
    }
}
