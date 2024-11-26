// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.Utilities;
using Nuke.Utilities.Text.Yaml;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.ProjectModel.SolutionModelTasks;
using static Nuke.Common.Tools.Git.GitTasks;

partial class Build
{
    [Parameter] readonly bool UseHttps;

    AbsolutePath GlobalSolution => RootDirectory / "nuke-global.sln";
    AbsolutePath ExternalRepositoriesDirectory => RootDirectory / "external";
    AbsolutePath ExternalRepositoriesFile => ExternalRepositoriesDirectory / "repositories.yml";

    IEnumerable<Nuke.Common.ProjectModel.Solution> ExternalSolutions
        => ExternalRepositories
            .Select(x => ExternalRepositoriesDirectory / x.GetGitHubName())
            .Select(x => x.GlobFiles("*.sln").Single())
            .Select(x => x.ReadSolution());

    IEnumerable<GitRepository> ExternalRepositories
        => ExternalRepositoriesFile.ReadYaml<string[]>().Select(x => GitRepository.FromUrl(x));

    Target CheckoutExternalRepositories => _ => _
        .Executes(() =>
        {
            foreach (var repository in ExternalRepositories)
            {
                var repositoryDirectory = ExternalRepositoriesDirectory / repository.GetGitHubName();
                var origin = UseHttps ? repository.HttpsUrl : repository.SshUrl;

                if (!Directory.Exists(repositoryDirectory))
                    Git($"clone {origin} {repositoryDirectory} --progress");
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
            var global = CreateSolution(
                solutionFile: GlobalSolution,
                solutions: new[] { Solution }.Concat(ExternalSolutions),
                folderNameProvider: x => x.Name.TrimStart("nuke-"));
            global.Save();

            if ((RootDirectory / $"{Solution.FileName}.DotSettings").FileExists())
            {
                (RootDirectory / $"{Solution.FileName}.DotSettings").Copy(
                    target: RootDirectory / $"{global.FileName}.DotSettings",
                    policy: ExistsPolicy.FileOverwrite);
            }

            if ((RootDirectory / $"{Solution.FileName}.DotSettings.user").FileExists())
            {
                (RootDirectory / $"{Solution.FileName}.DotSettings.user").Copy(
                    target: RootDirectory / $"{global.FileName}.DotSettings.user",
                    policy: ExistsPolicy.FileOverwrite);
            }
        });
}
