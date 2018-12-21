// Copyright 2018 Maintainers of NUKE.
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
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.ProjectModel
{
    internal static class SolutionSerializer
    {
        public static Solution Deserialize(string solutionFile)
        {
            return Deserialize(solutionFile, File.ReadAllLines(solutionFile));
        }

        public static Solution Deserialize(string solutionFile, string[] content)
        {
            var solution = new Solution
                           {
                               Path = (PathConstruction.AbsolutePath) solutionFile,
                               Header = content.TakeWhile(x => !x.StartsWith("Project")).ToArray(),
                               Properties = content.GetGlobalSection("SolutionProperties"),
                               ExtensibilityGlobals = content.GetGlobalSection("ExtensibilityGlobals"),
                               Configurations = content.GetGlobalSection("SolutionConfigurationPlatforms")
                           };
            
            var primitiveProjects = GetPrimitiveProjects(solution, content).ToList();
            foreach (var primitiveProject in primitiveProjects)
                solution.AddPrimitiveProject(primitiveProject);

            var projectToSolutionFolder = GetProjectToSolutionFolder(content);
            if (projectToSolutionFolder != null)
            {
                var solutionFolders = primitiveProjects.OfType<SolutionFolder>().ToList();
                foreach (var (projectGuid, solutionFolderGuid) in projectToSolutionFolder)
                {
                    var project = primitiveProjects.SingleOrDefault(x => x.ProjectId == projectGuid).NotNull("project != null");
                    var solutionFolder = solutionFolders.SingleOrDefault(x => x.ProjectId == solutionFolderGuid).NotNull("solutionFolder != null");
                    solution.SetSolutionFolder(solutionFolder, project);
                }
            }

            return solution;
        }

        [CanBeNull]
        private static Dictionary<Guid, Guid> GetProjectToSolutionFolder(this string[] lines)
        {
            return lines
                .GetGlobalSection("NestedProjects")
                ?.ToDictionary(x => Guid.Parse(x.Key.Trim('{', '}')), x => Guid.Parse(x.Value.Trim('{', '}')));
        }

        [CanBeNull]
        private static IDictionary<string, string> GetGlobalSection(this string[] lines, string name)
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
                    .ToDictionary(x => x[0].Trim(), x => x[1].Trim());
        }

        private static IEnumerable<PrimitiveProject> GetPrimitiveProjects(Solution solution, string[] content)
        {   
            string GuidPattern(string text)
                => $@"\{{(?<{Regex.Escape(text)}>[0-9a-fA-F]{{8}}-[0-9a-fA-F]{{4}}-[0-9a-fA-F]{{4}}-[0-9a-fA-F]{{4}}-[0-9a-fA-F]{{12}})\}}";

            string TextPattern(string name)
                => $@"""(?<{Regex.Escape(name)}>[^""]*)""";

            var projectRegex = new Regex(
                $@"^Project\(""{GuidPattern("typeId")}""\)\s*=\s*{TextPattern("name")},\s*{TextPattern("path")},\s*""{GuidPattern("projectId")}""$");

            var configurations = content
                .GetGlobalSection("ProjectConfigurationPlatforms").NotNull()
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
                    var path = Path.GetFullPath(Path.Combine(solution.Directory.NotNull(), match.Groups["path"].Value));

                    yield return new Project(
                        solution,
                        projectId,
                        name,
                        path,
                        typeId,
                        configurations.TryGetValue(projectId, out var projectConfigurations)
                            ? projectConfigurations
                            : new Dictionary<string, string>());
                }
                else
                {
                    var items = content
                        .Skip(i)
                        .TakeWhile(x => !x.StartsWith("EndProject"))
                        .Where(x => x.StartsWith("\t\t"))
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
            using (var fileStream = File.Create(solution.Path.NotNull("solution.Path != null")))
            {
                Serialize(solution, fileStream);
            }
        }

        public static void Serialize(Solution solution, Stream stream)
        {
            ControlFlow.Assert(solution.Path != null, "solution.Path != null");
            
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                void Write(string text) => writer.WriteLine(text);

                void WriteSection(string start, IDictionary<string, string> dictionary, string end)
                {
                    if (dictionary == null)
                        return;

                    Write($"\t{start}");
                    dictionary.ForEach(x => Write($"\t\t{x.Key} = {x.Value}"));
                    Write($"\t{end}");
                }

                string Format(Guid guid) => $"{{{guid.ToString("D").ToUpper()}}}";

                solution.Header.ForEach(x => writer.WriteLine(x));

                foreach (var project in solution.PrimitiveProjects)
                {
                    var path = (PathConstruction.WinRelativePath) project.RelativePath;
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
}
