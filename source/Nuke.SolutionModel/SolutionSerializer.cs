// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.ProjectModel
{
    internal static class SolutionSerializer
    {
        public static T DeserializeFromFile<T>(AbsolutePath solutionFile)
            where T : Solution, new()
        {
            Assert.FileExists(solutionFile);
            return DeserializeFromContent<T>(File.ReadAllLines(solutionFile), solutionFile);
        }

        public static T DeserializeFromContent<T>(string[] content, AbsolutePath solutionFile = null)
            where T : Solution, new()
        {
            var trimmedContent = content.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToArray();

            var solution = new T
                           {
                               Path = solutionFile,
                               Header = trimmedContent.TakeWhile(x => !x.StartsWith("Project")).ToArray(),
                               Properties = trimmedContent.GetGlobalSection("SolutionProperties", solutionFile),
                               ExtensibilityGlobals = trimmedContent.GetGlobalSection("ExtensibilityGlobals", solutionFile),
                               Configurations = trimmedContent.GetGlobalSection("SolutionConfigurationPlatforms", solutionFile)
                           };

            var configurations = (trimmedContent.GetGlobalSection("ProjectConfigurationPlatforms", solutionFile) ??
                                  trimmedContent.GetGlobalSection("ProjectConfiguration", solutionFile) ??
                                  new Dictionary<string, string>())
                .Select(x => new
                             {
                                 ProjectId = Guid.Parse(x.Key.Substring(startIndex: 1, length: 36)),
                                 ProjectConfiguration = x.Key.Substring(startIndex: 39),
                                 SolutionConfiguration = x.Value
                             })
                .GroupBy(x => x.ProjectId)
                .ToDictionary(
                    x => x.Key,
                    x => x.ToDictionary(
                        y => y.ProjectConfiguration,
                        y => y.SolutionConfiguration));
            var primitiveProjects = GetPrimitiveProjects(solution, trimmedContent, configurations)
                .ToDictionarySafe(
                    x => x.ProjectId,
                    x => x,
                    duplicationMessage: $"Solution {solutionFile?.ToString("s")} contains duplicated project ids".TrimToOne(" "));
            foreach (var primitiveProject in primitiveProjects.Values)
                solution.AddPrimitiveProject(primitiveProject);

            var projectToSolutionFolder = trimmedContent
                .GetGlobalSection("NestedProjects", solutionFile)
                ?.ToDictionary(x => Guid.Parse(x.Key.Trim('{', '}')), x => Guid.Parse(x.Value.Trim('{', '}')));
            if (projectToSolutionFolder != null)
            {
                var solutionFolders = primitiveProjects.Values.OfType<SolutionFolder>().ToList();
                foreach (var (projectGuid, solutionFolderGuid) in projectToSolutionFolder)
                {
                    var project = primitiveProjects.GetValueOrDefault(projectGuid)
                        .NotNull($"Project with guid '{projectGuid}' not found.");
                    var solutionFolder = solutionFolders.SingleOrDefault(x => x.ProjectId == solutionFolderGuid)
                        .NotNull($"Solution folder with guid '{solutionFolderGuid}' not found.");

                    solution.SetSolutionFolder(solutionFolder, project);
                }
            }

            return solution;
        }

        [CanBeNull]
        private static Dictionary<string, string> GetGlobalSection(this string[] lines, string name, [CanBeNull] string solutionFile)
        {
            var sectionLines = lines
                .SkipWhile(x => !Regex.IsMatch(x, $@"^\s*GlobalSection\({name}\) = \w+$"))
                .Skip(count: 1)
                .TakeWhile(x => !Regex.IsMatch(x, @"^\s*EndGlobalSection$"))
                .ToList();

            return sectionLines.Count == 0
                ? null
                : sectionLines
                    .Select(x => x.Split('='))
                    .ToDictionarySafe(
                        x => x[0].Trim(),
                        x => x[1].Trim(),
                        duplicationMessage: $"Solution {solutionFile?.SingleQuote()} contains duplicated {name} entries".TrimToOne(" "));
        }

        private static IEnumerable<PrimitiveProject> GetPrimitiveProjects(
            Solution solution,
            string[] content,
            IReadOnlyDictionary<Guid, Dictionary<string, string>> configurations)
        {
            static string GuidPattern(string text)
                => $@"\{{(?<{Regex.Escape(text)}>[0-9a-fA-F]{{8}}-[0-9a-fA-F]{{4}}-[0-9a-fA-F]{{4}}-[0-9a-fA-F]{{4}}-[0-9a-fA-F]{{12}})\}}";

            static string TextPattern(string name)
                => $@"""(?<{Regex.Escape(name)}>[^""]*)""";

            var projectRegex = new Regex(
                $@"^Project\(""{GuidPattern("typeId")}""\)\s*=\s*{TextPattern("name")},\s*{TextPattern("path")},\s*""{GuidPattern("projectId")}""$");

            for (var i = 0; i < content.Length; i++)
            {
                var match = projectRegex.Match(content[i]);
                if (!match.Success)
                    continue;

                var projectId = Guid.Parse(match.Groups["projectId"].Value);
                var typeId = Guid.Parse(match.Groups["typeId"].Value);
                var name = match.Groups["name"].Value;

                if (!typeId.Equals(SolutionFolder.Guid))
                {
                    var path = match.Groups["path"].Value;
                    yield return new Project(
                        solution,
                        projectId,
                        name,
                        () => Path.GetFullPath(Path.Combine(solution.Directory.NotNull(), path)),
                        typeId,
                        configurations.GetValueOrDefault(projectId) ?? new Dictionary<string, string>());
                }
                else
                {
                    var items = content
                        .Skip(i)
                        .TakeWhile(x => !x.StartsWith("EndProjectSection") && !x.StartsWith("EndProject"))
                        .Skip(2)
                        .Select(x => x.Split('='))
                        .ToDictionary(x => x[0].Trim(), x => x[1].Trim());

                    yield return new SolutionFolder(
                        solution: solution,
                        projectId: projectId,
                        name: name,
                        items: items);
                }
            }
        }

        public static void Serialize(Solution solution)
        {
            using var fileStream = File.Create(solution.Path.NotNull("solution.Path != null"));
            Serialize(solution, fileStream);
        }

        public static void Serialize(Solution solution, Stream stream)
        {
            Assert.NotNull(solution.Path);

            using var writer = new StreamWriter(stream, Encoding.UTF8);

            void Write(string text) => writer.WriteLine(text);

            void WriteSection(string start, IDictionary<string, string> dictionary, string end)
            {
                if (dictionary == null)
                    return;

                Write($"\t{start}");
                dictionary.ForEach(x => Write($"\t\t{x.Key} = {x.Value}"));
                Write($"\t{end}");
            }

            static string Format(Guid guid) => $"{{{guid.ToString("D").ToUpper()}}}";

            solution.Header.ForEach(x => writer.WriteLine(x));

            foreach (var project in solution.PrimitiveProjects)
            {
                var path = (WinRelativePath) project.RelativePath;
                Write($@"Project(""{Format(project.TypeId)}"") = ""{project.Name}"", ""{path}"", ""{Format(project.ProjectId)}""");
                WriteSection(
                    "ProjectSection(SolutionItems) = preProject",
                    (project as SolutionFolder)?.Items,
                    "EndProjectSection");
                Write("EndProject");
            }

            Write("Global");

            WriteSection(
                "GlobalSection(SolutionConfigurationPlatforms) = preSolution",
                solution.Configurations,
                "EndGlobalSection");

            WriteSection(
                "GlobalSection(ProjectConfigurationPlatforms) = postSolution",
                solution.PrimitiveProjects
                    .OfType<Project>()
                    .Where(x => x.Configurations != null)
                    .SelectMany(
                        x => x.Configurations,
                        (x, p) => new { Key = $"{Format(x.ProjectId)}.{p.Key}", p.Value })
                    .ToDictionary(x => x.Key, x => x.Value),
                "EndGlobalSection");

            WriteSection(
                "GlobalSection(SolutionProperties) = preSolution",
                solution.Properties,
                "EndGlobalSection");

            WriteSection(
                "GlobalSection(NestedProjects) = preSolution",
                solution.PrimitiveProjects
                    .Where(x => x.SolutionFolder != null)
                    .ToDictionary(x => $"{Format(x.ProjectId)}", x => $"{Format(x.SolutionFolder.NotNull().ProjectId)}"),
                "EndGlobalSection");

            WriteSection(
                "GlobalSection(ExtensibilityGlobals) = postSolution",
                solution.ExtensibilityGlobals,
                "EndGlobalSection");

            Write("EndGlobal");
        }
    }
}
