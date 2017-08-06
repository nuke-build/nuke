// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Git;
using Nuke.Common.Tools.GitLink2;
using Nuke.Common.Tools.GitLink3;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.InspectCode;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Tools.NuGet;
using Nuke.Common.Tools.OpenCover;
using Nuke.Core;
using Nuke.Core.Injection;
using Nuke.Core.Tooling;

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
        private static NukeBuild Build => NukeBuild.Instance;

        [CanBeNull]
        private static GitVersion GitVersionValue => InjectedValueProvider.GetStaticValue<GitVersion>();

        [CanBeNull]
        private static GitRepository GitRepositoryValue => InjectedValueProvider.GetStaticValue<GitRepository>();

        [CanBeNull]
        private static string VersionParameter => EnvironmentInfo.Parameter("version");

        [CanBeNull]
        public static string Version => VersionParameter ?? GitVersionValue?.AssemblySemVer;

        public static MSBuildSettings MSBuildCommon
        {
            get
            {
                var toolSettings = new MSBuildSettings()
                        .SetWorkingDirectory(Build.SolutionDirectory)
                        .SetSolutionFile(Build.SolutionFile)
                        .SetMaxCpuCount(Environment.ProcessorCount)
                        .SetConfiguration(Build.Configuration);

                var teamCityLogger = EnvironmentInfo.Variable("TEAMCITY_MSBUILD_LOGGER");
                if (!string.IsNullOrWhiteSpace(teamCityLogger))
                    toolSettings = toolSettings
                            .AddLoggers(teamCityLogger)
                            .EnableNoConsoleLogger();

                return toolSettings;
            }
        }


        public static MSBuildSettings MSBuildRestore => MSBuildCommon
                .SetTargets("Restore");

        public static MSBuildSettings MSBuildCompile => MSBuildCommon
                .SetTargets("Rebuild");

        public static MSBuildSettings MSBuildCompileWithVersion => MSBuildCompile
                .SetAssemblyVersion(GitVersionValue?.AssemblySemVer)
                .SetFileVersion(GitVersionValue?.AssemblySemVer)
                .SetInformationalVersion(GitVersionValue?.InformationalVersion);

        // TODO: evenIfNull for dictionary ?
        public static MSBuildSettings MSBuildPack => MSBuildCommon
                .SetTargets("Restore", "Pack")
                .EnableIncludeSymbols()
                .SetPackageOutputPath(Build.OutputDirectory)
                .SetPackageVersion(VersionParameter ?? GitVersionValue?.NuGetVersionV2);


        public static GitVersionSettings GitVersion => new GitVersionSettings()
                .SetWorkingDirectory(Build.RootDirectory);

        public static NuGetPackSettings NuGetPack => new NuGetPackSettings()
                .SetWorkingDirectory(Build.RootDirectory)
                .SetOutputDirectory(Build.OutputDirectory)
                .SetConfiguration(Build.Configuration)
                .SetVersion(GitVersionValue?.NuGetVersionV2);

        public static NuGetRestoreSettings NuGetRestore => new NuGetRestoreSettings()
                .SetWorkingDirectory(Build.RootDirectory)
                .SetTargetPath(Build.SolutionFile);

        public static InspectCodeSettings InspectCode => new InspectCodeSettings()
                .SetWorkingDirectory(Build.RootDirectory)
                .SetTargetPath(Build.SolutionFile)
                .SetOutput(Path.Combine(Build.OutputDirectory, "inspectCode.xml"));

        public static OpenCoverSettings OpenCover => new OpenCoverSettings()
                .SetWorkingDirectory(Build.RootDirectory)
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
                    "System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute")
                .SetExcludeByFile(
                    "*/*.Generated.cs",
                    "*/*.Designer.cs",
                    "*/*.g.cs",
                    "*/*.g.i.cs");

        public static GitLink2Settings GitLink2 => new GitLink2Settings()
                .SetWorkingDirectory(Build.RootDirectory)
                .SetSolutionDirectory(Build.SolutionDirectory)
                .SetConfiguration(Build.Configuration)
                .SetBranchName(GitVersionValue?.BranchName)
                .SetRepositoryUrl(GitRepositoryValue?.SvnUrl);

        public static GitLink3Settings GitLink3 => new GitLink3Settings()
                .SetWorkingDirectory(Build.RootDirectory)
                .SetBaseDirectory(Build.RootDirectory)
                .SetRepositoryUrl(GitRepositoryValue?.SvnUrl);
    }
}
