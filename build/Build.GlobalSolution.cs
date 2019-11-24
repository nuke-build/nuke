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

    AbsolutePath ExternalRepositoriesDirectory => RootDirectory / "external";
    AbsolutePath ExternalRepositoriesFile => ExternalRepositoriesDirectory / "repositories.yml";

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
            var global = CreateSolution();
            global.Configurations = Solution.Configurations;

            SolutionFolder GetParentFolder(PrimitiveProject solutionFolder) =>
                global.AllSolutionFolders.FirstOrDefault(x => x.ProjectId == solutionFolder.SolutionFolder?.ProjectId);

            void AddSolution(Solution solution, SolutionFolder folder = null)
            {
                solution.AllSolutionFolders.ForEach(x => global.AddSolutionFolder(x.Name, x.ProjectId, GetParentFolder(x) ?? folder));
                solution.AllSolutionFolders.ForEach(x => global.GetSolutionFolder(x.ProjectId).Items = x.Items);
                solution.AllProjects.ForEach(x => global.AddProject(x.Name, x.TypeId, x.Path, x.ProjectId, x.Configurations, GetParentFolder(x) ?? folder));
            }

            AddSolution(Solution);

            ExternalRepositoriesDirectory.GlobFiles("*/*.sln")
                .Select(x => ParseSolution(x))
                .ForEach(x => AddSolution(x, global.AddSolutionFolder(x.Name)));

            global.SaveAs(RootDirectory / "nuke-global.sln");

            CopyFile(
                source: RootDirectory / "nuke-common.sln.DotSettings",
                target: RootDirectory / $"{global.FileName}.DotSettings",
                FileExistsPolicy.Overwrite);
            CopyFile(
                source: RootDirectory / "nuke-common.sln.DotSettings.user",
                target: RootDirectory / $"{global.FileName}.DotSettings.user",
                FileExistsPolicy.Overwrite);
        });
}
