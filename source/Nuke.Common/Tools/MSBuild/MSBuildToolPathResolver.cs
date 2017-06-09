// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Nuke.Core;
#if !LOCATOR

#else
using Nuke.MSBuildLocator;
#endif

namespace Nuke.Common.Tools.MSBuild
{
    public static class MSBuildToolPathResolver
    {
        private static readonly MSBuildPlatform[] s_platforms = { MSBuildPlatform.x86, MSBuildPlatform.x64 };

        public static string Resolve (MSBuildVersion? msBuildVersion = null, MSBuildPlatform? msBuildPlatform = null)
        {
            if (EnvironmentInfo.IsUnix)
            {
                ControlFlow.Assert(msBuildVersion == null, "MSBuildVersion cannot be specified on UNIX systems.");
                ControlFlow.Assert(msBuildPlatform == null, "MSBuildPlatform cannot be specified on UNIX systems.");

                // TODO: if not?
                return new[]
                       {
                           "/usr/bin/msbuild",
                           "/Library/Frameworks/Mono.framework/Versions/Current/Commands/msbuild"
                       }.First(File.Exists);
            }

            var instances = new List<Instance>();

            instances.AddRange(
                from vs2017Edition in new[] { "Enterprise", "Professional", "Community", "BuildTools" }
                from platform1 in s_platforms
                select GetVs2017Instance(platform1, vs2017Edition));

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

            ControlFlow.Assert(filteredInstances.Count > 0, "No suitable MSBuild instances found.");
            return filteredInstances.First().ToolPath;
        }

        private static Instance GetVs2017Instance (MSBuildPlatform platform, string vs2017Edition)
        {
            var basePath = Path.Combine(
                EnvironmentInfo.SpecialFolder(SpecialFolders.ProgramFilesX86).AssertNotNull("path1 != null"),
                $@"Microsoft Visual Studio\2017\{vs2017Edition}\MSBuild\{GetVersionFolder(MSBuildVersion.VS2017)}\Bin");

            return new Instance(
                MSBuildVersion.VS2017,
                platform,
                platform == MSBuildPlatform.x64
                    ? Path.Combine(basePath, "amd64")
                    : basePath);
        }

        private static Instance GetVs2013To2015Instance (MSBuildPlatform platform, MSBuildVersion version)
        {
            var basePath = Path.Combine(
                EnvironmentInfo.SpecialFolder(SpecialFolders.ProgramFilesX86).AssertNotNull("path1 != null"),
                $@"MSBuild\{GetVersionFolder(version)}\Bin");

            return new Instance(
                version,
                platform,
                platform == MSBuildPlatform.x64
                    ? Path.Combine(basePath, "amd64")
                    : basePath);
        }

        private static string GetVersionFolder (MSBuildVersion version)
        {
            switch (version)
            {
                case MSBuildVersion.VS2017: return "15.0";
                case MSBuildVersion.VS2015: return "14.0";
                case MSBuildVersion.VS2013: return "12.0";
                default: throw new Exception();
            }
        }

        [DebuggerDisplay("{" + nameof(ToolPath) + "}")]
        private class Instance
        {
            public Instance (MSBuildVersion version, MSBuildPlatform platform, string directory)
            {
                Platform = platform;
                Version = version;
                ToolPath = Path.Combine(directory, "msbuild.exe");
            }

            public MSBuildPlatform Platform { get; }
            public MSBuildVersion Version { get; }
            public string ToolPath { get; }
        }
    }
}
