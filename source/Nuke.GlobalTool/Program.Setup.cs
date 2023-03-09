// Copyright 2023 Maintainers of NUKE.
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
using Spectre.Console;
using static Nuke.Common.Constants;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.Tooling.ProcessTasks;
using static Nuke.Common.Utilities.TemplateUtility;

namespace Nuke.GlobalTool
{
    partial class Program
    {
        // ReSharper disable InconsistentNaming

        private const string TARGET_FRAMEWORK = "net6.0";
        private const string PROJECT_KIND = "9A19103F-16F7-4668-BE54-9A1E7A4F7556";

        // ReSharper disable once CognitiveComplexity
        [UsedImplicitly]
        public static int Setup(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            PrintInfo();
            Logging.Configure();
            Telemetry.SetupBuild();

            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[bold]Let's setup a new build![/]");
            AnsiConsole.WriteLine();

            #region Basic

            var nukeLatestReleaseVersion = NuGetVersionResolver.GetLatestVersion(NukeCommonPackageId, includePrereleases: false);
            var nukeLatestPrereleaseVersion = NuGetVersionResolver.GetLatestVersion(NukeCommonPackageId, includePrereleases: true);
            var nukeLatestLocalVersion = NuGetPackageResolver.GetGlobalInstalledPackage(NukeCommonPackageId, version: null, packagesConfigFile: null)
                ?.Version.ToString();

            if (rootDirectory == null)
                rootDirectory = WorkingDirectory.FindParentOrSelf(x => x.ContainsDirectory(".git") || x.ContainsDirectory(".svn"));

            if (rootDirectory == null)
            {
                Host.Warning("Could not find root directory. Falling back to working directory ...");
                rootDirectory = WorkingDirectory;
            }
            ShowInput("deciduous_tree", "Root directory", rootDirectory);

            var buildProjectName = PromptForInput("How should the project be named?", "_build");
            ClearPreviousLine();
            ShowInput("bookmark", "Build project name", buildProjectName);

            var buildProjectRelativeDirectory = PromptForInput("Where should the project be located?", "./build");
            ClearPreviousLine();
            ShowInput("round_pushpin", "Build project location", buildProjectRelativeDirectory);

            var nukeVersion = PromptForChoice("Which Nuke.Common version should be used?",
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
            ShowInput("gem_stone", "Nuke.Common version", nukeVersion);

            var solutionFile = (AbsolutePath) PromptForChoice(
                "Which solution should be the default?",
                choices: new DirectoryInfo(rootDirectory)
                    .EnumerateFiles("*", SearchOption.AllDirectories)
                    .Where(x => x.FullName.EndsWithOrdinalIgnoreCase(".sln"))
                    .OrderByDescending(x => x.FullName)
                    .Select(x => (x, rootDirectory.GetRelativePathTo(x.FullName).ToString()))
                    .Concat((null, "None")).ToArray())?.FullName;
            ShowInput("toolbox", "Default solution", solutionFile != null ? rootDirectory.GetRelativePathTo(solutionFile) : "<none>");

            #endregion

            #region Generation

            var buildDirectory = rootDirectory / buildProjectRelativeDirectory;
            var buildProjectFile = rootDirectory / buildProjectRelativeDirectory / buildProjectName + ".csproj";
            var buildProjectGuid = Guid.NewGuid().ToString().ToUpper();

            (rootDirectory / NukeDirectoryName).CreateDirectory();

            WriteBuildScripts(
                scriptDirectory: WorkingDirectory,
                rootDirectory,
                buildDirectory,
                buildProjectName);

            WriteConfigurationFile(rootDirectory, solutionFile);

            if (solutionFile != null)
            {
                var solutionFileContent = solutionFile.ReadAllLines().ToList();
                var buildProjectFileRelative = solutionFile.Parent.GetWinRelativePathTo(buildProjectFile);
                UpdateSolutionFileContent(solutionFileContent, buildProjectFileRelative, buildProjectGuid, buildProjectName);
                solutionFile.WriteAllLines(solutionFileContent, Encoding.UTF8);
            }

            buildProjectFile.WriteAllLines(
                FillTemplate(
                    GetTemplate("_build.csproj"),
                    GetDictionary(
                        new
                        {
                            RootDirectory = buildDirectory.GetWinRelativePathTo(rootDirectory),
                            ScriptDirectory = buildDirectory.GetWinRelativePathTo(WorkingDirectory),
                            TargetFramework = TARGET_FRAMEWORK,
                            TelemetryVersion = Telemetry.CurrentVersion,
                            NukeVersion = nukeVersion,
                        })));

            (buildDirectory / "Directory.Build.props").WriteAllLines(GetTemplate("Directory.Build.props"));
            (buildDirectory / "Directory.Build.targets").WriteAllLines(GetTemplate("Directory.Build.targets"));
            (buildProjectFile + ".DotSettings").WriteAllLines(GetTemplate("_build.csproj.DotSettings"));
            (buildDirectory / ".editorconfig").WriteAllLines(GetTemplate(".editorconfig"));
            (buildDirectory / "Build.cs").WriteAllLines(FillTemplate(GetTemplate("Build.cs")));
            (buildDirectory / "Configuration.cs").WriteAllLines(GetTemplate("Configuration.cs"));

            #endregion

            ShowCompletion("Setup");

            return 0;
        }

        internal static void UpdateSolutionFileContent(
            List<string> content,
            string buildProjectFileRelative,
            string buildProjectGuid,
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
                $"Project(\"{{{PROJECT_KIND}}}\") = \"{buildProjectName}\", \"{buildProjectFileRelative}\", \"{{{buildProjectGuid}}}\"");
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
            AbsolutePath buildDirectory,
            string buildProjectName)
        {
            (scriptDirectory / "build.cmd").WriteAllLines(
                FillTemplate(GetTemplate("build.cmd")),
                platformFamily: PlatformFamily.Linux);

            (scriptDirectory / "build.sh").WriteAllLines(
                FillTemplate(
                    GetTemplate("build.sh"),
                    tokens: GetDictionary(
                        new
                        {
                            RootDirectory = scriptDirectory.GetUnixRelativePathTo(rootDirectory),
                            BuildDirectory = scriptDirectory.GetUnixRelativePathTo(buildDirectory),
                            BuildProjectName = buildProjectName,
                        })),
                platformFamily: PlatformFamily.Linux);

            (scriptDirectory / "build.ps1").WriteAllLines(
                FillTemplate(
                    GetTemplate("build.ps1"),
                    tokens: GetDictionary(
                        new
                        {
                            RootDirectory = scriptDirectory.GetWinRelativePathTo(rootDirectory),
                            BuildDirectory = scriptDirectory.GetWinRelativePathTo(buildDirectory),
                            BuildProjectName = buildProjectName,
                        })),
                platformFamily: PlatformFamily.Windows);

            MakeExecutable(scriptDirectory / "build.cmd");
            MakeExecutable(scriptDirectory / "build.sh");

            void MakeExecutable(AbsolutePath scriptFile)
            {
                if (rootDirectory.ContainsDirectory(".git"))
                    StartProcess("git", $"update-index --add --chmod=+x {scriptFile}", logInvocation: false, logOutput: false);

                if (rootDirectory.ContainsDirectory(".svn"))
                    StartProcess("svn", $"propset svn:executable on {scriptFile}", logInvocation: false, logOutput: false);

                if (IsUnix)
                    StartProcess("chmod", $"+x {scriptFile}", logInvocation: false, logOutput: false);
            }
        }

        private static void WriteConfigurationFile(AbsolutePath rootDirectory, [CanBeNull] AbsolutePath solutionFile)
        {
            var parametersFile = GetDefaultParametersFile(rootDirectory);
            var dictionary = new Dictionary<string, string> { ["$schema"] = $"./{BuildSchemaFileName}" };
            if (solutionFile != null)
                dictionary["Solution"] = rootDirectory.GetUnixRelativePathTo(solutionFile).ToString();
            parametersFile.WriteJson(dictionary);
        }
    }
}
