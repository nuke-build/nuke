// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tools.MSBuild;

public static class MSBuildToolPathResolver
{
    private static readonly MSBuildPlatform[] s_platforms = { MSBuildPlatform.x86, MSBuildPlatform.x64 };

    public static string Resolve(MSBuildVersion? msBuildVersion = null, MSBuildPlatform? msBuildPlatform = null)
    {
        return ResolveInternal(msBuildVersion, msBuildPlatform).FirstOrDefault()
            .NotNull("Could not find a suitable MSBuild instance.");
    }

    private static IEnumerable<string> ResolveInternal(MSBuildVersion? msBuildVersion = null, MSBuildPlatform? msBuildPlatform = null)
    {
        Assert.True(!EnvironmentInfo.IsUnix || msBuildVersion == null);
        Assert.True(!EnvironmentInfo.IsUnix || msBuildPlatform == null);

        if (EnvironmentInfo.IsUnix)
        {
            return new[]
                   {
                       "/usr/bin/msbuild",
                       "/usr/local/bin/msbuild",
                       "/Library/Frameworks/Mono.framework/Versions/Current/Commands/msbuild"
                   }.Where(File.Exists);
        }

        var instances = new List<Instance>();

        instances.AddRange(
            from version in new[] { MSBuildVersion.VS2026, MSBuildVersion.VS2022, MSBuildVersion.VS2019, MSBuildVersion.VS2017 }
            from platform in s_platforms
            from edition in typeof(VisualStudioEdition).GetEnumValues<VisualStudioEdition>()
            let folder = GetProgramFilesFolder(version, edition)
            select GetFromVs2017Instance(version, platform, edition, folder));

        instances.AddRange(
            from version in new[] { MSBuildVersion.VS2015, MSBuildVersion.VS2013 }
            from platform in s_platforms
            select GetVs2013To2015Instance(platform, version));

        var preferedPlatform = EnvironmentInfo.Is64Bit ? MSBuildPlatform.x64 : MSBuildPlatform.x86;
        var filteredInstances = instances
            .Where(x => File.Exists(x.ToolPath))
            .Where(x => !msBuildVersion.HasValue || x.Version == msBuildVersion)
            .Where(x => !msBuildPlatform.HasValue || x.Platform == msBuildPlatform)
            .OrderBy(x => x.Version)
            .ThenByDescending(x => x.Platform == preferedPlatform)
            .ToList();

        return filteredInstances.Select(x => x.ToolPath);
    }

    private static Instance GetFromVs2017Instance(
        MSBuildVersion version,
        MSBuildPlatform platform,
        VisualStudioEdition edition,
        SpecialFolders specialFolder)
    {
        var versionDirectoryName = version.ToString().TrimStart("VS");
        var basePath = Path.Combine(
            EnvironmentInfo.SpecialFolder(specialFolder).NotNull(),
            $@"Microsoft Visual Studio\{versionDirectoryName}\{edition}\MSBuild\{GetVersionFolder(version)}\Bin");

        return new Instance(
            version,
            platform,
            platform == MSBuildPlatform.x64
                ? Path.Combine(basePath, "amd64")
                : basePath);
    }

    private static Instance GetVs2013To2015Instance(MSBuildPlatform platform, MSBuildVersion version)
    {
        var basePath = Path.Combine(
            EnvironmentInfo.SpecialFolder(SpecialFolders.ProgramFilesX86).NotNull("path1 != null"),
            $@"MSBuild\{GetVersionFolder(version)}\Bin");

        return new Instance(
            version,
            platform,
            platform == MSBuildPlatform.x64
                ? Path.Combine(basePath, "amd64")
                : basePath);
    }

    private static SpecialFolders GetProgramFilesFolder(MSBuildVersion version, VisualStudioEdition edition)
    {
        if (edition == VisualStudioEdition.BuildTools)
        {
            return SpecialFolders.ProgramFilesX86;
        }

        return version switch
        {
            MSBuildVersion.VS2013 => SpecialFolders.ProgramFilesX86,
            MSBuildVersion.VS2015 => SpecialFolders.ProgramFilesX86,
            MSBuildVersion.VS2017 => SpecialFolders.ProgramFilesX86,
            MSBuildVersion.VS2019 => SpecialFolders.ProgramFilesX86,
            // Versions VS2022+ are 64-bit
            _ => SpecialFolders.ProgramFiles
        };
    }

    private static string GetVersionFolder(MSBuildVersion version)
    {
        return version switch
        {
            MSBuildVersion.VS2013 => "12.0",
            MSBuildVersion.VS2015 => "14.0",
            MSBuildVersion.VS2017 => "15.0",
            _ => "Current"
        };
    }

    [DebuggerDisplay("{" + nameof(ToolPath) + "}")]
    private class Instance
    {
        public Instance(MSBuildVersion version, MSBuildPlatform platform, string directory)
        {
            Platform = platform;
            Version = version;
            ToolPath = Path.Combine(directory, "msbuild.exe");
        }

        public MSBuildPlatform Platform { get; }
        public MSBuildVersion Version { get; }
        public string ToolPath { get; }
    }

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    private enum VisualStudioEdition
    {
        Enterprise,
        Professional,
        Community,
        BuildTools,
        Preview
    }
}
