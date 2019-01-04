using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.PathConstruction;

partial class Build
{
    void PrepareSolution(string globalSolutionFile)
    {
        using (var fileStream = File.Create(globalSolutionFile))
        using (var streamWriter = new StreamWriter(fileStream))
        {
            streamWriter.Write(@"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.26124.0
MinimumVisualStudioVersion = 15.0.26124.0

Project(""{9A19103F-16F7-4668-BE54-9A1E7A4F7556}"") = ""_build"", ""build\_build.csproj"", ""{594DB7F8-B1EA-4C9C-BF63-D12A361C513B}""
EndProject
");

            string GetSolutionFolderName(string s)
            {
                var directoryInfo = new FileInfo(s).Directory.NotNull();
                return $"{directoryInfo.Parent.NotNull().Name}/{directoryInfo.Name}";
            }

            var solutions = GlobFiles(RepositoriesDirectory, "*/*/*.sln")
                .Where(x => x != globalSolutionFile)
                .Select(x => new
                             {
                                 File = x,
                                 Directory = GetRelativePath(RootDirectory, new FileInfo(x).Directory.NotNull().FullName),
                                 Name = GetSolutionFolderName(x),
                                 Guid = Guid.NewGuid().ToString("D").ToUpper(),
                                 Content = TextTasks.ReadAllLines(x)
                             })
                .OrderBy(x => x.Name).ToList();
            foreach (var solution in solutions)
            {
                streamWriter.WriteLine(@"Project(""{2150E333-8FDC-42A3-9474-1A3956D46DE8}"") = " +
                                       $@"""{solution.Name}"", ""{solution.Name}"", ""{{{solution.Guid}}}""");
                streamWriter.WriteLine("EndProject");

                string FixLocation(string line)
                {
                    if (line.StartsWith("Project"))
                    {
                        var index = line.Select((x, i) => (x, i)).Where(x => x.Item1 == '"').ElementAt(4).Item2;
                        return line.Insert(index + 1, $"{solution.Directory}\\");
                    }

                    if (line.StartsWith("\t\t"))
                    {
                        var index = line.IndexOf('=');
                        return line.Insert(index + 2, $"{solution.Directory}\\");
                    }

                    return line;
                }

                solution.Content
                    .SkipWhile(x => !x.StartsWith("Project"))
                    .TakeWhile(x => !x.StartsWith("Global"))
                    // ReSharper disable once AccessToDisposedClosure
                    .ForEach(x => streamWriter.WriteLine(FixLocation(x)));
            }

            streamWriter.Write(@"
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Debug|x64 = Debug|x64
		Debug|x86 = Debug|x86
		Release|Any CPU = Release|Any CPU
		Release|x64 = Release|x64
		Release|x86 = Release|x86
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(NestedProjects) = preSolution
");

            var guidDictionary = new Dictionary<string, (string SolutionFile, string Declaration)>();
            foreach (var solution in solutions)
            {
                string GetAndTrackGuid(string declaration)
                {
                    var guid = declaration.Substring(declaration.Length - 38, 36);
                    if (guidDictionary.TryGetValue(guid, out var value))
                    {
                        var solutionFileToFix = solution.Name.Contains("template")
                            ? value.SolutionFile
                            : solution.File;
                        TextTasks.WriteAllText(
                            solutionFileToFix,
                            TextTasks.ReadAllText(solutionFileToFix)
                                .Replace(guid, Guid.NewGuid().ToString("D").ToUpper()));

                        ControlFlow.Fail(new[]
                                         {
                                             $"Guid {guid} is duplicated in:",
                                             $"  {solution.File}",
                                             $"    {declaration}",
                                             $"  {value.SolutionFile}",
                                             $"    {value.Declaration}",
                                             "Guid has been replaced. Restart target."
                                         }.JoinNewLine());
                    }

                    guidDictionary.Add(guid, (solution.File, declaration));
                    return guid;
                }

                solution.Content
                    .Where(x => x.StartsWith("Project"))
                    .Select(GetAndTrackGuid)
                    // ReSharper disable once AccessToDisposedClosure
                    .ForEach(x => streamWriter.WriteLine($"\t\t{{{x}}} = {{{solution.Guid}}}"));
            }

            streamWriter.Write(@"
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{594DB7F8-B1EA-4C9C-BF63-D12A361C513B}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{594DB7F8-B1EA-4C9C-BF63-D12A361C513B}.Release|Any CPU.ActiveCfg = Release|Any CPU
");

            foreach (var solution in solutions)
            {
                solution.Content
                    .SkipWhile(x => !x.Contains("GlobalSection(ProjectConfigurationPlatforms)"))
                    .Skip(1)
                    .TakeWhile(x => !x.Contains("EndGlobalSection"))
                    // ReSharper disable once AccessToDisposedClosure
                    .ForEach(x => streamWriter.WriteLine(x));
            }

            streamWriter.Write(@"
	EndGlobalSection
EndGlobal");
        }
    }
}