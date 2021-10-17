// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.Constants;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.IO.TextTasks;
using static Nuke.Common.Tooling.ProcessTasks;
using static Nuke.Common.Utilities.ConsoleUtility;
using static Nuke.Common.Utilities.TemplateUtility;

namespace Nuke.GlobalTool
{
    partial class Program
    {
        // ReSharper disable InconsistentNaming

        private const string PLATFORM_NETCORE = "netcore";
        private const string PLATFORM_NETFX = "netfx";
        private const string FRAMEWORK_NETFX = "net472";
#if NET5_0_OR_GREATER
        private const string FRAMEWORK_NETCORE = "net5.0";
#elif NETCOREAPP3_1_OR_GREATER
        private const string FRAMEWORK_NETCORE = "netcoreapp3.1";
#else
        private const string FRAMEWORK_NETCORE = "netcoreapp2.1";
#endif
        private const string FORMAT_SDK = "sdk";
        private const string FORMAT_LEGACY = "legacy";

        private const string DotNet = "DOTNET";
        private const string MSBuild = "MSBUILD";
        private const string SourceDir = "SOURCE_DIR";
        private const string SrcDir = "SRC_DIR";
        private const string OutputDir = "OUTPUT_DIR";
        private const string ArtifactsDir = "ARTIFACTS_DIR";
        private const string TestsDir = "TESTS_DIR";
        private const string Git = "GIT";
        private const string GitVersion = "GITVERSION";
        private const string SolutionFile = "SOLUTION_FILE";

        // ReSharper disable once CognitiveComplexity
        [UsedImplicitly]
        public static int Setup(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            PrintInfo();
            Telemetry.SetupBuild();

            #region Basic

            var nukeLatestReleaseVersion = NuGetPackageResolver.GetLatestPackageVersion(NukeCommonPackageId, includePrereleases: false);
            var nukeLatestPrereleaseVersion = NuGetPackageResolver.GetLatestPackageVersion(NukeCommonPackageId, includePrereleases: true);
            var nukeLatestLocalVersion = NuGetPackageResolver.GetGlobalInstalledPackage(NukeCommonPackageId, version: null, packagesConfigFile: null)
                ?.Version.ToString();

            if (rootDirectory == null)
            {
                var rootDirectoryItems = new[] { ".git", ".svn" };
                rootDirectory = (AbsolutePath) FileSystemTasks.FindParentDirectory(
                    WorkingDirectory,
                    x => rootDirectoryItems.Any(y => x.GetFileSystemInfos(y, SearchOption.TopDirectoryOnly).Any()));
            }

            if (rootDirectory == null)
            {
                Host.Warning("Could not find root directory. Falling back to working directory ...");
                rootDirectory = WorkingDirectory;
            }

            var buildProjectName = PromptForInput("How should the build project be named?", "_build");
            var buildDirectoryName = PromptForInput("Where should the build project be located?", "./build");

            var targetPlatform = !GetParameter<bool>("boot")
                ? PLATFORM_NETCORE
                : PromptForChoice("What bootstrapping method should be used?",
                    (PLATFORM_NETCORE, ".NET Core SDK"),
                    (PLATFORM_NETFX, ".NET Framework/Mono"));

            var targetFramework = targetPlatform == PLATFORM_NETFX
                ? FRAMEWORK_NETFX
                : FRAMEWORK_NETCORE;

            var projectFormat = targetPlatform == PLATFORM_NETCORE
                ? FORMAT_SDK
                : PromptForChoice("What project format should be used?",
                    (FORMAT_SDK, "SDK-based Format: requires .NET Core SDK"),
                    (FORMAT_LEGACY, "Legacy Format: supported by all MSBuild/Mono versions"));

            var nukeVersion = PromptForChoice("Which NUKE version should be used?",
                new[]
                    {
                        ("latest release", nukeLatestReleaseVersion.GetAwaiter().GetResult()),
                        ("latest prerelease", nukeLatestPrereleaseVersion.GetAwaiter().GetResult()),
                        ("latest local", nukeLatestLocalVersion),
                        ("same as global tool", typeof(Program).GetTypeInfo().Assembly.GetVersionText())
                    }
                    .Where(x => x.Item2 != null)
                    .Distinct(x => x.Item2)
                    .Select(x => (x.Item2, $"{x.Item2} ({x.Item1})")).ToArray());

            var solutionFile = (AbsolutePath) PromptForChoice(
                "Which solution should be the default?",
                options: new DirectoryInfo(rootDirectory)
                    .EnumerateFiles("*", SearchOption.AllDirectories)
                    .Where(x => x.FullName.EndsWithOrdinalIgnoreCase(".sln"))
                    .OrderByDescending(x => x.FullName)
                    .Select(x => (x, GetRelativePath(rootDirectory, x.FullName)))
                    .Concat((null, "None")).ToArray())?.FullName;
            var solutionDirectory = solutionFile?.Parent;

            #endregion

            #region Additional

            var tokens = new Dictionary<string, string>();

            if (solutionFile != null &&
                projectFormat == FORMAT_SDK &&
                PromptForChoice(
                    "Do you need help getting started with a basic build?",
                    (true, "Yes, get me started!"),
                    (false, "No, I can do this myself...")))
            {
                tokens.AddPairWhenKeyNotNull(
                    PromptForChoice("Restore, compile, pack using ...",
                        (DotNet, "dotnet CLI"),
                        (MSBuild, "MSBuild/Mono"),
                        (null, "Neither")));

                tokens.AddPairWhenKeyNotNull(
                    PromptForChoice("Source files are located in ...",
                        (SourceDir, "./source"),
                        (SrcDir, "./src"),
                        (null, "Neither")));

                tokens.AddPairWhenKeyNotNull(
                    PromptForChoice("Move packages to ...",
                        (OutputDir, "./output"),
                        (ArtifactsDir, "./artifacts"),
                        (null, "Neither")));

                tokens.AddPairWhenKeyNotNull(
                    PromptForChoice("Where do test projects go?",
                        (TestsDir, "./tests"),
                        (null, "Same as source")));

                if (Directory.Exists(rootDirectory / ".git"))
                    tokens.AddPairWhenKeyNotNull(Git);
                else
                {
                    tokens.AddPairWhenKeyNotNull(
                        PromptForChoice("Do you use git?",
                            (Git, "Yes, just not setup yet"),
                            (null, "No, something else")));
                }

                if (File.Exists(rootDirectory / "GitVersion.yml"))
                    tokens.AddPairWhenKeyNotNull(GitVersion);
                else if (tokens.ContainsKey(Git))
                {
                    tokens.AddPairWhenKeyNotNull(
                        PromptForChoice("Do you use GitVersion?",
                            (GitVersion, "Yes, just not setup yet"),
                            (null, "No, custom versioning")));
                }
            }

            #endregion

            #region Generation

            var buildDirectory = rootDirectory / buildDirectoryName;
            var buildProjectFile = rootDirectory / buildDirectoryName / buildProjectName + ".csproj";
            var buildProjectGuid = Guid.NewGuid().ToString().ToUpper();
            var buildProjectKind = new Dictionary<string, string>
                                   {
                                       [FORMAT_LEGACY] = "FAE04EC0-301F-11D3-BF4B-00C04F79EFBC",
                                       [FORMAT_SDK] = "9A19103F-16F7-4668-BE54-9A1E7A4F7556"
                                   }[projectFormat];

            FileSystemTasks.EnsureExistingDirectory(rootDirectory / NukeDirectoryName);

            WriteBuildScripts(
                scriptDirectory: WorkingDirectory,
                rootDirectory,
                solutionDirectory,
                buildDirectory,
                buildProjectName,
                targetPlatform);

            WriteConfigurationFile(rootDirectory, solutionFile);

            if (solutionFile != null)
            {
                tokens.AddPair(SolutionFile);

                var solutionFileContent = ReadAllLines(solutionFile).ToList();
                var buildProjectFileRelative = solutionDirectory.GetWinRelativePathTo(buildProjectFile);
                UpdateSolutionFileContent(solutionFileContent, buildProjectFileRelative, buildProjectGuid, buildProjectKind, buildProjectName);
                WriteAllLines(solutionFile, solutionFileContent, Encoding.UTF8);
            }

            WriteAllLines(
                buildProjectFile,
                FillTemplate(
                    GetTemplate($"_build.{projectFormat}.csproj"),
                    tokens
                        .ToDictionary(x => x.Key, x => x.Value)
                        .AddDictionary(GetDictionary(
                            new
                            {
                                SolutionDirectory = buildDirectory.GetWinRelativePathTo(solutionDirectory ?? rootDirectory),
                                RootDirectory = buildDirectory.GetWinRelativePathTo(rootDirectory),
                                ScriptDirectory = buildDirectory.GetWinRelativePathTo(WorkingDirectory),
                                BuildProjectName = buildProjectName,
                                BuildProjectGuid = buildProjectGuid,
                                TargetFramework = targetFramework,
                                TelemetryVersion = Telemetry.CurrentVersion,
                                NukeVersion = nukeVersion,
                                NukeVersionMajorMinor = nukeVersion.Split(".").Take(2).Join(".")
                            }))));

            if (projectFormat == FORMAT_LEGACY)
            {
                WriteAllLines(
                    buildDirectory / "packages.config",
                    FillTemplate(
                        GetTemplate("_build.legacy.packages.config"),
                        tokens: GetDictionary(new { NukeVersion = nukeVersion })));
            }

            WriteAllLines(
                buildDirectory / "Directory.Build.props",
                GetTemplate("Directory.Build.props"));

            WriteAllLines(
                buildDirectory / "Directory.Build.targets",
                GetTemplate("Directory.Build.targets"));

            WriteAllLines(
                $"{buildProjectFile}.DotSettings",
                GetTemplate("_build.csproj.DotSettings"));

            WriteAllLines(
                buildDirectory / ".editorconfig",
                GetTemplate(".editorconfig"));

            WriteAllLines(
                buildDirectory / "Build.cs",
                FillTemplate(GetTemplate("Build.cs"), tokens));

            WriteAllLines(
                buildDirectory / "Configuration.cs",
                GetTemplate("Configuration.cs"));

            #endregion

            return 0;
        }

        internal static void UpdateSolutionFileContent(
            List<string> content,
            string buildProjectFileRelative,
            string buildProjectGuid,
            string buildProjectKind,
            string buildProjectName)
        {
            if (content.Any(x => x.Contains(buildProjectFileRelative)))
                return;

            var globalIndex = content.IndexOf("Global");
            Assert.True(globalIndex != -1, "Could not find a 'Global' section in solution file");

            var projectConfigurationIndex = content.FindIndex(x => x.Contains("GlobalSection(ProjectConfigurationPlatforms)"));
            if (projectConfigurationIndex == -1)
            {
                var solutionConfigurationIndex = content.FindIndex(x => x.Contains("GlobalSection(SolutionConfigurationPlatforms)"));
                if (solutionConfigurationIndex == -1)
                {
                    content.Insert(globalIndex + 1, "\tGlobalSection(SolutionConfigurationPlatforms) = preSolution");
                    content.Insert(globalIndex + 2, "\t\tDebug|Any CPU = Debug|Any CPU");
                    content.Insert(globalIndex + 3, "\t\tRelease|Any CPU = Release|Any CPU");
                    content.Insert(globalIndex + 4, "\tEndGlobalSection");

                    solutionConfigurationIndex = globalIndex + 1;
                }

                var endGlobalSectionIndex = content.FindIndex(solutionConfigurationIndex, x => x.Contains("EndGlobalSection"));

                content.Insert(endGlobalSectionIndex + 1, "\tGlobalSection(ProjectConfigurationPlatforms) = postSolution");
                content.Insert(endGlobalSectionIndex + 2, "\tEndGlobalSection");

                projectConfigurationIndex = endGlobalSectionIndex + 1;
            }

            content.Insert(projectConfigurationIndex + 1, $"\t\t{{{buildProjectGuid}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU");
            content.Insert(projectConfigurationIndex + 2, $"\t\t{{{buildProjectGuid}}}.Release|Any CPU.ActiveCfg = Release|Any CPU");

            content.Insert(globalIndex,
                $"Project(\"{{{buildProjectKind}}}\") = \"{buildProjectName}\", \"{buildProjectFileRelative}\", \"{{{buildProjectGuid}}}\"");
            content.Insert(globalIndex + 1,
                "EndProject");
        }

        private static string[] GetTemplate(string templateName)
        {
            return ResourceUtility.GetResourceAllLines<Program>($"templates.{templateName}");
        }


        private static void WriteBuildScripts(
            AbsolutePath scriptDirectory,
            AbsolutePath rootDirectory,
            [CanBeNull] AbsolutePath solutionDirectory,
            AbsolutePath buildDirectory,
            string buildProjectName,
            string targetPlatform)
        {
            WriteAllLines(
                scriptDirectory / "build.cmd",
                FillTemplate(GetTemplate("build.cmd")));

            WriteAllLines(
                scriptDirectory / "build.sh",
                FillTemplate(
                    GetTemplate($"build.{targetPlatform}.sh"),
                    tokens: GetDictionary(
                        new
                        {
                            RootDirectory = scriptDirectory.GetUnixRelativePathTo(rootDirectory),
                            SolutionDirectory = scriptDirectory.GetUnixRelativePathTo(solutionDirectory ?? rootDirectory),
                            BuildDirectory = scriptDirectory.GetUnixRelativePathTo(buildDirectory),
                            BuildProjectName = buildProjectName,
                            NuGetVersion = "latest"
                        })));

            WriteAllLines(
                scriptDirectory / "build.ps1",
                FillTemplate(
                    GetTemplate($"build.{targetPlatform}.ps1"),
                    tokens: GetDictionary(
                        new
                        {
                            RootDirectory = scriptDirectory.GetWinRelativePathTo(rootDirectory),
                            SolutionDirectory = scriptDirectory.GetWinRelativePathTo(solutionDirectory ?? rootDirectory),
                            BuildDirectory = scriptDirectory.GetWinRelativePathTo(buildDirectory),
                            BuildProjectName = buildProjectName,
                            NuGetVersion = "latest"
                        })));

            MakeExecutable(scriptDirectory / "build.cmd");
            MakeExecutable(scriptDirectory / "build.sh");

            void MakeExecutable(string scriptPath)
            {
                if (Directory.Exists(rootDirectory / ".git"))
                    StartProcess("git", $"update-index --add --chmod=+x {scriptPath}", logInvocation: false, logOutput: false);

                if (Directory.Exists(rootDirectory / ".svn"))
                    StartProcess("svn", $"propset svn:executable on {scriptPath}", logInvocation: false, logOutput: false);

                if (IsUnix)
                    StartProcess("chmod", $"+x {scriptPath}", logInvocation: false, logOutput: false);
            }
        }

        private static void WriteConfigurationFile(AbsolutePath rootDirectory, [CanBeNull] AbsolutePath solutionFile)
        {
            var parametersFile = GetDefaultParametersFile(rootDirectory);
            var dictionary = new Dictionary<string, string> { ["$schema"] = $"./{BuildSchemaFileName}" };
            if (solutionFile != null)
                dictionary["Solution"] = rootDirectory.GetUnixRelativePathTo(solutionFile).ToString();
            SerializationTasks.JsonSerializeToFile(dictionary, parametersFile);
        }
    }
}
