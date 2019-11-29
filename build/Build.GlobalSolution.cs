// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.IO.SerializationTasks;
using static Nuke.Common.ProjectModel.ProjectModelTasks;
using static Nuke.Common.Tools.Git.GitTasks;

partial class Build
{
    [Parameter] readonly bool UseSSH;

    AbsolutePath GlobalSolution => RootDirectory / "nuke-global.sln";
    AbsolutePath ExternalRepositoriesDirectory => RootDirectory / "external";
    AbsolutePath ExternalRepositoriesFile => ExternalRepositoriesDirectory / "repositories.yml";
    IEnumerable<Solution> ExternalSolutions => ExternalRepositoriesDirectory.GlobFiles("*/*.sln").Select(x => ParseSolution(x));

    IEnumerable<GitRepository> ExternalRepositories =>
        YamlDeserializeFromFile<string[]>(ExternalRepositoriesFile).Select(x => GitRepository.FromUrl(x));

    Target CheckoutExternalRepositories => _ => _
        .Executes(async () =>
        {
            foreach (var repository in ExternalRepositories)
            {
                var repositoryDirectory = ExternalRepositoriesDirectory / repository.GetGitHubName();
                var origin = UseSSH ? repository.SshUrl : repository.HttpsUrl;

                if (!Directory.Exists(repositoryDirectory))
                    Git($"clone {origin} {repositoryDirectory} --branch {await repository.GetDefaultBranch()} --progress");
                else
                {
                    SuppressErrors(() => Git($"remote add origin {origin}", repositoryDirectory));
                    Git($"remote set-url origin {origin}", repositoryDirectory);
                }
            }
        });

    [UsedImplicitly]
    Target GenerateGlobalSolution => _ => _
        .DependsOn(CheckoutExternalRepositories)
        .Executes(() =>
        {
            var global = CreateSolution(GlobalSolution);
            global.Configurations =
                Solution?.Configurations ??
                new Dictionary<string, string>
                {
                    { "Debug|Any CPU", "Debug|Any CPU" },
                    { "Release|Any CPU", "Release|Any CPU" }
                };

            SolutionFolder GetParentFolder(PrimitiveProject solutionFolder) =>
                global.AllSolutionFolders.FirstOrDefault(x => x.ProjectId == solutionFolder.SolutionFolder?.ProjectId);

            void AddSolution(Solution solution, SolutionFolder folder = null)
            {
                IDictionary<string, string> GetItems(SolutionFolder solutionFolder)
                    => solutionFolder.Items.Keys
                        .Select(x => (string) (WinRelativePath) GetRelativePath(global.Directory, solution.Directory / x))
                        .ToDictionary(x => x, x => x);

                solution.AllSolutionFolders.ForEach(x => global.AddSolutionFolder(x.Name, x.ProjectId, GetParentFolder(x) ?? folder));
                solution.AllSolutionFolders.ForEach(x => global.GetSolutionFolder(x.ProjectId).Items = GetItems(x));
                solution.AllProjects.ForEach(x =>
                    global.AddProject(x.Name, x.TypeId, x.Path, x.ProjectId, x.Configurations, GetParentFolder(x) ?? folder));
            }

            AddSolution(Solution);
            ExternalSolutions.ForEach(x => AddSolution(x, global.AddSolutionFolder(x.Name)));

            global.Save();

            if (File.Exists(RootDirectory / $"{Solution.FileName}.DotSettings"))
            {
                CopyFile(
                    source: RootDirectory / $"{Solution.FileName}.DotSettings",
                    target: RootDirectory / $"{global.FileName}.DotSettings",
                    FileExistsPolicy.Overwrite);
            }

            if (File.Exists(RootDirectory / $"{Solution.FileName}.DotSettings.user"))
            {
                CopyFile(
                    source: RootDirectory / $"{Solution.FileName}.DotSettings.user",
                    target: RootDirectory / $"{global.FileName}.DotSettings.user",
                    FileExistsPolicy.Overwrite);
            }
        });
}
