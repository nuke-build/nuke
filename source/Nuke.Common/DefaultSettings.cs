// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Tools.GitLink2;
using Nuke.Common.Tools.GitLink3;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.InspectCode;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Tools.NuGet;
using Nuke.Common.Tools.OpenCover;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;

[assembly: IconClass(typeof(DefaultSettings), "equalizer")]

namespace Nuke.Common
{
    /// <summary>
    /// Variety of default settings, pre-filled with <see cref="Build.Instance"/> properties
    /// (e.g., <see cref="Build.SolutionFile"/> or <see cref="GitHubBuild.GitVersion"/> and
    /// best-practice values (e.g., excluding test attributes from coverage analysis).
    /// For more details it's recommended to browse the actual source code.
    /// </summary>
    /// <example>
    /// <code>
    /// Target Restore =&gt; _ =&gt; _
    ///         .DependsOn(Clean)
    ///         .Executes(() =&gt; NuGetRestore(s =&gt; DefaultSettings.NuGetRestore));
    /// </code>
    /// <code>
    /// Target Compile =&gt; _ =&gt; _
    ///         .DependsOn(Restore)
    ///         .Executes(() =&gt; MSBuild(s =&gt; DefaultSettings.MSBuildCompile));
    /// </code>
    /// <code>
    /// Target Pack =&gt; _ =&gt; _
    ///         .DependsOn(Compile)
    ///         .Executes(() =&gt; MSBuild(s =&gt; DefaultSettings.MSBuildPack));
    /// </code>
    /// </example>
    [PublicAPI]
    public class DefaultSettings
    {
        public static MSBuildSettings MSBuildCommon
        {
            get
            {
                var toolSettings = new MSBuildSettings()
                        .SetWorkingDirectory(Build.Instance.SolutionDirectory)
                        .SetSolutionFile(Build.Instance.SolutionFile)
                        .SetConfiguration(Build.Instance.Configuration);

                var teamCityLogger = EnvironmentInfo.Variable("TEAMCITY_MSBUILD_LOGGER");
                if (!string.IsNullOrWhiteSpace(teamCityLogger))
                    toolSettings = toolSettings
                            .AddLogger(teamCityLogger, evenIfNull: false)
                            .EnableNoConsoleLogger();

                return toolSettings;
            }
        }

        public static MSBuildSettings MSBuildRestore => MSBuildCommon
                .SetTargets("Restore");

        public static MSBuildSettings MSBuildCompile => MSBuildCommon
                .SetTargets("Rebuild")
                .SetMaxCpuCount(Environment.ProcessorCount);

        public static MSBuildSettings MSBuildCompileWithAssemblyInfo => MSBuildCompile
                .SetProperty("AssemblyVersion", GitHubBuild.Instance.GitVersion.AssemblySemVer)
                .SetProperty("FileVersion", GitHubBuild.Instance.GitVersion.AssemblySemVer)
                .SetProperty("InformationalVersion", GitHubBuild.Instance.GitVersion.InformationalVersion);

        public static MSBuildSettings MSBuildPack => MSBuildCommon
                .SetTargets("Restore", "Pack")
                .SetProperty("PackageOutputPath", Build.Instance.OutputDirectory)
                .SetProperty("IncludeSymbols", "True")
                .SetProperty("PackageVersion", GitHubBuild.Instance?.GitVersion?.NuGetVersionV2);


        public static GitVersionSettings GitVersion => new GitVersionSettings()
                .SetWorkingDirectory(Build.Instance.RootDirectory);

        public static NuGetPackSettings NuGetPack => new NuGetPackSettings()
                .SetWorkingDirectory(Build.Instance.RootDirectory)
                .SetOutputDirectory(Build.Instance.OutputDirectory)
                .SetConfiguration(Build.Instance.Configuration)
                .SetVersion(GitHubBuild.Instance?.GitVersion?.NuGetVersionV2);

        public static NuGetRestoreSettings NuGetRestore => new NuGetRestoreSettings()
                .SetWorkingDirectory(Build.Instance.RootDirectory)
                .SetTargetPath(Build.Instance.SolutionFile);

        public static InspectCodeSettings InspectCode => new InspectCodeSettings()
                .SetWorkingDirectory(Build.Instance.RootDirectory)
                .SetTargetPath(Build.Instance.SolutionFile)
                .SetOutput(Path.Combine(Build.Instance.OutputDirectory, "inspectCode.xml"));

        public static OpenCoverSettings OpenCover => new OpenCoverSettings()
                .SetWorkingDirectory(Build.Instance.RootDirectory)
                .SetRegistration(RegistrationType.User)
                .SetTargetExitCodeOffset(targetExitCodeOffset: 0)
                .SetFilters(
                    "+[*]*",
                    "-[xunit.*]*",
                    "-[NUnit.*]*",
                    "-[FluentAssertions.*]*",
                    "-[Machine.Specifications.*]*")
                .SetExcludeByAttributes(
                    "*.Explicit*",
                    "*.Ignore*",
                    "*. *")
                .SetExcludeByFile(
                    "*/*.Generated.cs",
                    "*/*.Designer.cs",
                    "*/*.g.cs",
                    "*/*.g.i.cs");

        public static GitLink2Settings GitLink2 => new GitLink2Settings()
                .SetWorkingDirectory(Build.Instance.RootDirectory)
                .SetSolutionDirectory(Build.Instance.SolutionDirectory)
                .SetConfiguration(Build.Instance.Configuration)
                .SetBranchName(GitHubBuild.Instance?.GitVersion.BranchName)
                .SetRepositoryUrl(GitHubBuild.Instance?.GitRepository.SvnUrl);

        public static GitLink3Settings GitLink3 => new GitLink3Settings()
                .SetWorkingDirectory(Build.Instance.RootDirectory)
                .SetBaseDirectory(Build.Instance.RootDirectory)
                .SetRepositoryUrl(GitHubBuild.Instance?.GitRepository.SvnUrl);
    }
}
