// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.Tools.GitLink2;
using Nuke.Common.Tools.GitLink3;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.InspectCode;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Tools.NuGet;
using Nuke.Common.Tools.OpenCover;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Injection;
using Nuke.Core.Tooling;

[assembly: IconClass(typeof(DefaultSettings), "equalizer")]

namespace Nuke.Common
{
    /// <summary>
    /// Variety of default settings, pre-filled with <see cref="NukeBuild.Instance"/> properties
    /// (e.g., <see cref="NukeBuild.SolutionFile"/> and inject values (e.g., <see cref="GitRepository"/> and
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
        private static InjectionKey<GitVersion, GitVersionAttribute> GitVersionKey { get; }
        private static InjectionKey<GitRepository, GitRepositoryAttribute> GitRepositoryKey { get; }

        public static MSBuildSettings MSBuildCommon
        {
            get
            {
                var toolSettings = new MSBuildSettings()
                        .SetWorkingDirectory(NukeBuild.Instance.SolutionDirectory)
                        .SetSolutionFile(NukeBuild.Instance.SolutionFile)
                        .SetConfiguration(NukeBuild.Instance.Configuration);

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

        public static MSBuildSettings MSBuildCompileWithGitVersion
        {
            get
            {
                var gitVersion = InjectedValueProvider.GetNonNullValue(GitVersionKey);
                return MSBuildCompile
                        .SetProperty("AssemblyVersion", gitVersion.AssemblySemVer)
                        .SetProperty("FileVersion", gitVersion.AssemblySemVer)
                        .SetProperty("InformationalVersion", gitVersion.InformationalVersion);
            }
        }

        public static MSBuildSettings MSBuildPack => MSBuildCommon
                .SetTargets("Restore", "Pack")
                .SetProperty("PackageOutputPath", NukeBuild.Instance.OutputDirectory)
                .SetProperty("IncludeSymbols", "True")
            // TODO: evenIfNull for dictionary
                .SetProperty("PackageVersion", InjectedValueProvider.GetValue(GitVersionKey)?.NuGetVersionV2);


        public static GitVersionSettings GitVersion => new GitVersionSettings()
                .SetWorkingDirectory(NukeBuild.Instance.RootDirectory);

        public static NuGetPackSettings NuGetPack => new NuGetPackSettings()
                .SetWorkingDirectory(NukeBuild.Instance.RootDirectory)
                .SetOutputDirectory(NukeBuild.Instance.OutputDirectory)
                .SetConfiguration(NukeBuild.Instance.Configuration)
                .SetVersion(InjectedValueProvider.GetValue(GitVersionKey)?.NuGetVersionV2);

        public static NuGetRestoreSettings NuGetRestore => new NuGetRestoreSettings()
                .SetWorkingDirectory(NukeBuild.Instance.RootDirectory)
                .SetTargetPath(NukeBuild.Instance.SolutionFile);

        public static InspectCodeSettings InspectCode => new InspectCodeSettings()
                .SetWorkingDirectory(NukeBuild.Instance.RootDirectory)
                .SetTargetPath(NukeBuild.Instance.SolutionFile)
                .SetOutput(Path.Combine(NukeBuild.Instance.OutputDirectory, "inspectCode.xml"));

        public static OpenCoverSettings OpenCover => new OpenCoverSettings()
                .SetWorkingDirectory(NukeBuild.Instance.RootDirectory)
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
                .SetWorkingDirectory(NukeBuild.Instance.RootDirectory)
                .SetSolutionDirectory(NukeBuild.Instance.SolutionDirectory)
                .SetConfiguration(NukeBuild.Instance.Configuration)
                .SetBranchName(InjectedValueProvider.GetValue(GitVersionKey)?.BranchName)
                .SetRepositoryUrl(InjectedValueProvider.GetValue(GitRepositoryKey)?.SvnUrl);

        public static GitLink3Settings GitLink3 => new GitLink3Settings()
                .SetWorkingDirectory(NukeBuild.Instance.RootDirectory)
                .SetBaseDirectory(NukeBuild.Instance.RootDirectory)
                .SetRepositoryUrl(InjectedValueProvider.GetValue(GitRepositoryKey)?.SvnUrl);
    }
}
