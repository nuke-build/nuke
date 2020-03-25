// Copyright 2019 Maintainers of NUKE.
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
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.PathConstruction;
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
        private const string FRAMEWORK_NETCORE = "netcoreapp3.0";
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

        // ReSharper restore InconsistentNaming

        [UsedImplicitly]
        private static int Setup(string[] args, [CanBeNull] string rootDirectory, [CanBeNull] string buildScript)
        {
            #region Basic

            var nukeLatestReleaseVersion = NuGetPackageResolver.GetLatestPackageVersion("Nuke.Common", includePrereleases: false);
            var nukeLatestPrereleaseVersion = NuGetPackageResolver.GetLatestPackageVersion("Nuke.Common", includePrereleases: true);
            var nukeLatestLocalVersion = NuGetPackageResolver.GetGlobalInstalledPackage("Nuke.Common", version: null, packagesConfigFile: null)
                ?.Version.ToString();

            if (rootDirectory == null)
            {
                var rootDirectoryItems = new[] { ".git", ".svn" };
                rootDirectory = FileSystemTasks.FindParentDirectory(
                    WorkingDirectory,
                    x => rootDirectoryItems.Any(y => x.GetFileSystemInfos(y, SearchOption.TopDirectoryOnly).Any()));
            }

            if (rootDirectory == null)
            {
                Logger.Warn("Could not find root directory. Falling back to working directory.");
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

            var solutionFile = PromptForChoice(
                "Which solution should be the default?",
                options: new DirectoryInfo(rootDirectory)
                    .EnumerateFiles("*", SearchOption.AllDirectories)
                    .Where(x => x.FullName.EndsWithOrdinalIgnoreCase(".sln"))
                    .OrderByDescending(x => x.FullName)
                    .Select(x => (x, GetRelativePath(rootDirectory, x.FullName)))
                    .Concat((null, "None")).ToArray())?.FullName;
            var solutionDirectory = solutionFile != null ? Path.GetDirectoryName(solutionFile) : null;

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

                if (Directory.Exists(Path.Combine(rootDirectory, ".git")))
                    tokens.AddPairWhenKeyNotNull(Git);
                else
                {
                    tokens.AddPairWhenKeyNotNull(
                        PromptForChoice("Do you use git?",
                            (Git, "Yes, just not setup yet"),
                            (null, "No, something else")));
                }

                if (File.Exists(Path.Combine(rootDirectory, "GitVersion.yml")))
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

            var buildDirectory = Path.Combine(rootDirectory, buildDirectoryName);
            var buildProjectFile = Path.Combine(rootDirectory, buildDirectoryName, buildProjectName + ".csproj");
            var buildProjectGuid = Guid.NewGuid().ToString().ToUpper();
            var buildProjectKind = new Dictionary<string, string>
                                   {
                                       [FORMAT_LEGACY] = "FAE04EC0-301F-11D3-BF4B-00C04F79EFBC",
                                       [FORMAT_SDK] = "9A19103F-16F7-4668-BE54-9A1E7A4F7556"
                                   }[projectFormat];

            if (solutionFile == null)
            {
                FileSystemTasks.Touch(Path.Combine(rootDirectory, Constants.ConfigurationFileName));
            }
            else
            {
                TextTasks.WriteAllText(
                    Path.Combine(rootDirectory, Constants.ConfigurationFileName),
                    GetUnixRelativePath(rootDirectory, solutionFile));

                tokens.AddPair(SolutionFile);

                var solutionFileContent = TextTasks.ReadAllLines(solutionFile).ToList();
                var buildProjectFileRelative = GetWinRelativePath(solutionDirectory, buildProjectFile);
                UpdateSolutionFileContent(solutionFileContent, buildProjectFileRelative, buildProjectGuid, buildProjectKind, buildProjectName);
                TextTasks.WriteAllLines(solutionFile, solutionFileContent, Encoding.UTF8);
            }

            TextTasks.WriteAllLines(
                buildProjectFile,
                FillTemplate(
                    GetTemplate($"_build.{projectFormat}.csproj"),
                    tokens
                        .ToDictionary(x => x.Key, x => x.Value)
                        .AddDictionary(GetDictionary(
                            new
                            {
                                SolutionDirectory = GetWinRelativePath(buildDirectory, solutionDirectory ?? rootDirectory),
                                RootDirectory = GetWinRelativePath(buildDirectory, rootDirectory),
                                ScriptDirectory = GetWinRelativePath(buildDirectory, WorkingDirectory),
                                BuildProjectName = buildProjectName,
                                BuildProjectGuid = buildProjectGuid,
                                TargetFramework = targetFramework,
                                NukeVersion = nukeVersion,
                                NukeVersionMajorMinor = nukeVersion.Split(".").Take(2).Join(".")
                            }))));

            if (projectFormat == FORMAT_LEGACY)
            {
                TextTasks.WriteAllLines(
                    Path.Combine(buildDirectory, "packages.config"),
                    FillTemplate(
                        GetTemplate("_build.legacy.packages.config"),
                        tokens: GetDictionary(new { NukeVersion = nukeVersion })));
            }

            TextTasks.WriteAllLines(
                $"{buildProjectFile}.DotSettings",
                GetTemplate("_build.csproj.DotSettings"));

            TextTasks.WriteAllLines(
                Path.Combine(buildDirectory, ".editorconfig"),
                GetTemplate(".editorconfig"));

            TextTasks.WriteAllLines(
                Path.Combine(buildDirectory, "Build.cs"),
                FillTemplate(GetTemplate("Build.cs"), tokens));

            void MakeExecutable(string scriptPath)
            {
                if (Directory.Exists(Path.Combine(rootDirectory, ".git")))
                    ProcessTasks.StartProcess("git", $"update-index --add --chmod=+x {scriptPath}", logInvocation: false, logOutput: false);

                if (Directory.Exists(Path.Combine(rootDirectory, ".svn")))
                    ProcessTasks.StartProcess("svn", $"propset svn:executable on {scriptPath}", logInvocation: false, logOutput: false);

                if (IsUnix)
                    ProcessTasks.StartProcess("chmod", $"+x {scriptPath}", logInvocation: false, logOutput: false);
            }

            var cmdScript = Path.Combine(WorkingDirectory, "build.cmd");
            TextTasks.WriteAllLines(
                cmdScript,
                FillTemplate(GetTemplate("build.cmd")));
            MakeExecutable(cmdScript);

            TextTasks.WriteAllLines(
                Path.Combine(WorkingDirectory, "build.ps1"),
                FillTemplate(
                    GetTemplate($"build.{targetPlatform}.ps1"),
                    tokens: GetDictionary(
                        new
                        {
                            RootDirectory = GetWinRelativePath(WorkingDirectory, rootDirectory),
                            SolutionDirectory = GetWinRelativePath(WorkingDirectory, solutionDirectory ?? rootDirectory),
                            ScriptDirectory = GetWinRelativePath(buildDirectory, WorkingDirectory),
                            BuildDirectory = GetWinRelativePath(WorkingDirectory, buildDirectory),
                            BuildProjectName = buildProjectName,
                            NuGetVersion = "latest"
                        })));

            var bashScript = Path.Combine(WorkingDirectory, "build.sh");
            TextTasks.WriteAllLines(
                bashScript,
                FillTemplate(
                    GetTemplate($"build.{targetPlatform}.sh"),
                    tokens: GetDictionary(
                        new
                        {
                            RootDirectory = GetUnixRelativePath(WorkingDirectory, rootDirectory),
                            SolutionDirectory = GetUnixRelativePath(WorkingDirectory, solutionDirectory ?? rootDirectory),
                            ScriptDirectory = GetUnixRelativePath(buildDirectory, WorkingDirectory),
                            BuildDirectory = GetUnixRelativePath(WorkingDirectory, buildDirectory),
                            BuildProjectName = buildProjectName,
                            NuGetVersion = "latest"
                        })));
            MakeExecutable(bashScript);

            // if (Directory.Exists(Path.Combine(rootDirectory, ".git")))
            //     ProcessTasks.StartProcess($"git update-index --chmod=+x {bashScript}", logOutput: false);
            // if (Directory.Exists(Path.Combine(rootDirectory, ".svn")))
            //     ProcessTasks.StartProcess($"svn propset svn:executable on {bashScript}", logOutput: false);

            if (tokens.ContainsKey(SrcDir))
                FileSystemTasks.EnsureExistingDirectory(Path.Combine(rootDirectory, "src"));
            if (tokens.ContainsKey(SourceDir))
                FileSystemTasks.EnsureExistingDirectory(Path.Combine(rootDirectory, "source"));
            if (tokens.ContainsKey(TestsDir))
                FileSystemTasks.EnsureExistingDirectory(Path.Combine(rootDirectory, "tests"));

            #endregion

            #region Wizard+Generation (addon)

            if (new[] { "addon", "addin", "plugin" }.Any(x => x.EqualsOrdinalIgnoreCase(args.FirstOrDefault())))
            {
                ControlFlow.Assert(tokens.ContainsKey(SourceDir), "tokens.ContainsKey('SOURCE_DIR')");

                var organization = PromptForInput("Organization name:", defaultValue: "nuke-build");
                var addonName = PromptForInput("Organization name:", defaultValue: null);
                var authors = PromptForInput("Author names separated by comma:", defaultValue: "Matthias Koch, Sebastian Karasek");
                var packageName = PromptForInput("Package name on nuget.org:", defaultValue: null);

                TextTasks.WriteAllLines(
                    Path.Combine(rootDirectory, "README.md"),
                    FillTemplate(
                        GetTemplate("README.md"),
                        tokens: GetDictionary(
                            new
                            {
                                Organization = organization,
                                AddonName = addonName,
                                Authors = authors,
                                PackageName = packageName
                            })));

                TextTasks.WriteAllLines(
                    Path.Combine(rootDirectory, "LICENSE"),
                    FillTemplate(
                        GetTemplate("LICENSE"),
                        tokens: GetDictionary(
                            new
                            {
                                DateTime.Now.Year,
                                Authors = authors
                            })));

                TextTasks.WriteAllLines(
                    Path.Combine(rootDirectory, "CHANGELOG.md"),
                    GetTemplate("CHANGELOG.md"));

                TextTasks.WriteAllText(
                    $"{solutionFile}.DotSettings.ext",
                    "https://raw.githubusercontent.com/nuke-build/nuke/develop/nuke-common.sln.DotSettings");
                TextTasks.WriteAllText(
                    Path.Combine(solutionDirectory, "source", "Inspections.DotSettings.ext"),
                    "https://raw.githubusercontent.com/nuke-build/nuke/develop/source/Inspections.DotSettings");
                TextTasks.WriteAllText(
                    Path.Combine(solutionDirectory, "source", "CodeStyle.DotSettings.ext"),
                    "https://raw.githubusercontent.com/nuke-build/nuke/develop/source/CodeStyle.DotSettings");
                TextTasks.WriteAllText(
                    Path.Combine(solutionDirectory, "source", "Configuration.props.ext"),
                    "https://raw.githubusercontent.com/nuke-build/nuke/develop/source/Configuration.props");
            }

            #endregion

            return 0;
        }

        public static void UpdateSolutionFileContent(
            List<string> content,
            string buildProjectFileRelative,
            string buildProjectGuid,
            string buildProjectKind,
            string buildProjectName)
        {
            if (content.Any(x => x.Contains(buildProjectFileRelative)))
                return;

            var globalIndex = content.IndexOf("Global");
            ControlFlow.Assert(globalIndex != -1, "Could not find a 'Global' section in solution file.");

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
    }
}
