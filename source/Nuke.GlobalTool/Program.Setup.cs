// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.GlobalTool
{
    partial class Program
    {
        // ReSharper disable InconsistentNaming
        public const string PLATFORM_NETCORE = "netcore";
        public const string PLATFORM_NETFX = "netfx";
        public const string FRAMEWORK_NET461 = "net461";
        public const string FRAMEWORK_NETCOREAPP2 = "netcoreapp2.0";
        public const string FORMAT_SDK = "sdk";
        public const string FORMAT_LEGACY = "legacy";
        // ReSharper restore InconsistentNaming

        [UsedImplicitly]
        private static void Setup([CanBeNull] string rootDirectory, string[] args)
        {
            #region Basic
            
            var nukeLatestLocalVersion = NuGetPackageResolver.GetGlobalInstalledPackage("Nuke.Common", version: null)?.Version.ToString();
            var nukeLatestReleaseVersion = NuGetPackageResolver.GetLatestPackageVersion("Nuke.Common", includePrereleases: false);
            var nukeLatestPrereleaseVersion = NuGetPackageResolver.GetLatestPackageVersion("Nuke.Common", includePrereleases: true);

            if (rootDirectory == null)
            {
                var rootDirectoryItems = new[] { ".git", ".svn" };
                rootDirectory = FileSystemTasks.FindParentDirectory(
                    EnvironmentInfo.WorkingDirectory,
                    x => rootDirectoryItems.Any(y => x.GetFileSystemInfos(y, SearchOption.TopDirectoryOnly).Any()));
            }
            
            if (rootDirectory == null)
            {
                Logger.Warn("Could not find root directory. Falling back to working directory.");
                rootDirectory = EnvironmentInfo.WorkingDirectory;
            }

            var solutionFile = ConsoleHelper.PromptForChoice(
                "Which solution should be the default?",
                options: new DirectoryInfo(rootDirectory)
                    .EnumerateFiles("*", SearchOption.AllDirectories)
                    .Where(x => x.FullName.EndsWithOrdinalIgnoreCase(".sln"))
                    .NotEmpty("No solution file found.")
                    .OrderByDescending(x => x.FullName)
                    .Select(x => (x, GetRelativePath(rootDirectory, x.FullName))).ToArray()).FullName;
            var solutionDirectory = Path.GetDirectoryName(solutionFile);

            var targetPlatform = ConsoleHelper.PromptForChoice("How should the build project be bootstrapped?",
                (PLATFORM_NETCORE, ".NET Core SDK"),
                (PLATFORM_NETFX, ".NET Framework/Mono"));

            var targetFramework = targetPlatform == PLATFORM_NETFX
                ? FRAMEWORK_NET461
                : ConsoleHelper.PromptForChoice("What target framework should be used?",
                    (FRAMEWORK_NETCOREAPP2, FRAMEWORK_NETCOREAPP2),
                    (FRAMEWORK_NET461, FRAMEWORK_NET461));

            var projectFormat = targetPlatform == PLATFORM_NETCORE
                ? FORMAT_SDK
                : ConsoleHelper.PromptForChoice("What format should the build project use?",
                    (FORMAT_SDK, "SDK-based Format: requires .NET Core SDK"),
                    (FORMAT_LEGACY, "Legacy Format: supported by all MSBuild/Mono versions"));

            var nukeVersion = ConsoleHelper.PromptForChoice("Which NUKE version should be used?",
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

            var buildDirectoryName = ConsoleHelper.PromptForInput("Where should the build project be located?", "./build");
            var buildProjectName = ConsoleHelper.PromptForInput("What should be the name for the build project?", "_build");

            #endregion

            #region Wizard

            var defaultBuildDefinitions = new List<string>();

            if (ConsoleHelper.PromptForChoice("Do you need help getting started with a basic build?",
                (true, "Yes, get me started!"),
                (false, "No, I can do this myself...")))
            {
                defaultBuildDefinitions.Add(
                    ConsoleHelper.PromptForChoice("Restore, compile, pack using ...",
                        ("DOTNET", "dotnet CLI"),
                        ("MSBUILD", "MSBuild/Mono"),
                        (null, "Neither")));

                defaultBuildDefinitions.Add(
                    ConsoleHelper.PromptForChoice("Source files are located in ...",
                        ("SOURCE_DIR", "./source"),
                        ("SRC_DIR", "./src"),
                        (null, "Neither")));

                defaultBuildDefinitions.Add(
                    ConsoleHelper.PromptForChoice("Move packages to ...",
                        ("OUTPUT_DIR", "./output"),
                        ("ARTIFACTS_DIR", "./artifacts"),
                        (null, "Neither")));

                defaultBuildDefinitions.Add(
                    ConsoleHelper.PromptForChoice("Where do test projects go?",
                        ("TESTS_DIR", "./tests"),
                        (null, "Same as source")));

                if (Directory.Exists(Path.Combine(rootDirectory, ".git")))
                    defaultBuildDefinitions.Add("GIT");
                else
                {
                    defaultBuildDefinitions.Add(
                        ConsoleHelper.PromptForChoice("Do you use git?",
                            ("GIT", "Yes, just not setup yet"),
                            (null, "No, something else")));
                }

                if (File.Exists(Path.Combine(rootDirectory, "GitVersion.yml")))
                    defaultBuildDefinitions.Add("GITVERSION");
                else if (defaultBuildDefinitions.Contains("GIT"))
                {
                    defaultBuildDefinitions.Add(
                        ConsoleHelper.PromptForChoice("Do you use GitVersion?",
                            ("GITVERSION", "Yes, just not setup yet"),
                            (null, "No, custom versioning")));
                }
            }

            defaultBuildDefinitions.RemoveAll(x => x == null);

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

            var buildProjectFileRelative = (WinRelativePath) GetRelativePath(solutionDirectory, buildProjectFile);
            
            var solutionFileContent = TextTasks.ReadAllLines(solutionFile).ToList();
            UpdateSolutionFileContent(solutionFileContent, buildProjectFileRelative, buildProjectGuid, buildProjectKind, buildProjectName);
            TextTasks.WriteAllLines(solutionFile, solutionFileContent, Encoding.UTF8);

            TextTasks.WriteAllText(
                Path.Combine(rootDirectory, NukeBuild.ConfigurationFile),
                GetRelativePath(rootDirectory, solutionFile).Replace(oldChar: '\\', newChar: '/'));

            TextTasks.WriteAllText(
                buildProjectFile,
                TemplateEngine.FillOutTemplate(
                    $"_build.{projectFormat}.csproj",
                    definitions: null,
                    replacements:
                    new
                    {
                        solutionDirectory = (WinRelativePath) GetRelativePath(buildDirectory, solutionDirectory),
                        rootDirectory = (WinRelativePath) GetRelativePath(buildDirectory, rootDirectory),
                        scriptDirectory = (WinRelativePath) GetRelativePath(buildDirectory, EnvironmentInfo.WorkingDirectory),
                        buildProjectName,
                        buildProjectGuid,
                        targetFramework,
                        nukeVersion,
                        nukeVersionMajorMinor = nukeVersion.Substring(0, nukeVersion.IndexOf(".", 0, 2, StringComparison.OrdinalIgnoreCase))
                    }));

            if (projectFormat == FORMAT_LEGACY)
            {
                TextTasks.WriteAllText(
                    Path.Combine(buildDirectory, "packages.config"),
                    TemplateEngine.FillOutTemplate(
                        "_build.legacy.packages.config",
                        definitions: null,
                        replacements: new { nukeVersion }));
            }

            TextTasks.WriteAllText(
                $"{buildProjectFile}.DotSettings",
                TemplateEngine.FillOutTemplate(
                    "_build.csproj.DotSettings",
                    definitions: null,
                    replacements: new { }));

            TextTasks.WriteAllText(
                Path.Combine(buildDirectory, "Build.cs"),
                TemplateEngine.FillOutTemplate(
                    "Build.cs",
                    defaultBuildDefinitions,
                    replacements: new { }));

            TextTasks.WriteAllText(
                Path.Combine(EnvironmentInfo.WorkingDirectory, "build.ps1"),
                TemplateEngine.FillOutTemplate(
                    $"build.{targetPlatform}.ps1",
                    definitions: null,
                    replacements:
                    new
                    {
                        rootDirectory = (WinRelativePath) GetRelativePath(EnvironmentInfo.WorkingDirectory, rootDirectory),
                        solutionDirectory = (WinRelativePath) GetRelativePath(EnvironmentInfo.WorkingDirectory, solutionDirectory),
                        scriptDirectory = (WinRelativePath) GetRelativePath(buildDirectory, EnvironmentInfo.WorkingDirectory),
                        buildDirectory = (WinRelativePath) GetRelativePath(EnvironmentInfo.WorkingDirectory, buildDirectory),
                        buildProjectName,
                        nugetVersion = "latest"
                    }));

            TextTasks.WriteAllText(
                Path.Combine(EnvironmentInfo.WorkingDirectory, "build.sh"),
                TemplateEngine.FillOutTemplate(
                    $"build.{targetPlatform}.sh",
                    definitions: null,
                    replacements:
                    new
                    {
                        rootDirectory = (UnixRelativePath) GetRelativePath(EnvironmentInfo.WorkingDirectory, rootDirectory),
                        solutionDirectory = (UnixRelativePath) GetRelativePath(EnvironmentInfo.WorkingDirectory, solutionDirectory),
                        scriptDirectory = (UnixRelativePath) GetRelativePath(buildDirectory, EnvironmentInfo.WorkingDirectory),
                        buildDirectory = (UnixRelativePath) GetRelativePath(EnvironmentInfo.WorkingDirectory, buildDirectory),
                        buildProjectName,
                        nugetVersion = "latest"
                    }));

            #endregion

            #region Wizard+Generation (addon)

            if (new[]{"addon", "addin", "plugin"}.Any(x => x.EqualsOrdinalIgnoreCase(args.FirstOrDefault())))
            {
                ControlFlow.Assert(defaultBuildDefinitions.Contains("SOURCE_DIR"), "definitions.Contains('SOURCE_DIR')");

                var organization = ConsoleHelper.PromptForInput("Organization name:", defaultValue: "nuke-build");
                var addonName = ConsoleHelper.PromptForInput("Organization name:", defaultValue: null);
                var authors = ConsoleHelper.PromptForInput("Author names separated by comma:", defaultValue: "Matthias Koch, Sebastian Karasek");
                var packageName = ConsoleHelper.PromptForInput("Package name on nuget.org:", defaultValue: null);

                TextTasks.WriteAllText(
                    Path.Combine(rootDirectory, "README.md"),
                    TemplateEngine.FillOutTemplate(
                        "README.md",
                        definitions: null,
                        new
                        {
                            organization,
                            addonName,
                            authors,
                            packageName
                        }));
                TextTasks.WriteAllText(
                    Path.Combine(rootDirectory, "LICENSE"),
                    TemplateEngine.FillOutTemplate(
                        "LICENSE",
                        definitions: null,
                        new
                        {
                            year = DateTime.Now.Year,
                            authors
                        }));
                TextTasks.WriteAllText(
                    Path.Combine(rootDirectory, "CHANGELOG.md"),
                    TemplateEngine.FillOutTemplate(
                        "CHANGELOG.md",
                        definitions: null,
                        replacements: new { }));

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
    }
}
