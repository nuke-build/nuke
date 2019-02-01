using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.IO.SerializationTasks;
using static Nuke.Common.IO.TextTasks;
using static Nuke.Common.Tools.Git.GitTasks;
using static Nuke.Common.Utilities.TemplateUtility;
using static TeamCityManager;

partial class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Solution);

    [Parameter] readonly bool Https;

    string GlobalSolutionFile => RootDirectory / "nuke.sln";
    string Organization => "nuke-build";
    
    AbsolutePath RepositoriesDirectory => RootDirectory / "repositories";
    AbsolutePath RepositoriesFile => RootDirectory / "repositories.yml";
    IEnumerable<GitRepository> Repositories =>
        YamlDeserializeFromFile<string[]>(RepositoriesFile)
            .Select(x => x.Split(separator: '#'))
            .Select(x => GitRepository.FromUrl(url: x.First(), branch: x.ElementAtOrDefault(index: 1) ?? "master"));

    Target Solution => _ => _
        .Executes(() =>
        {
            foreach (var repository in Repositories)
            {
                var repositoryDirectory = RepositoriesDirectory / repository.Identifier;
                var origin = Https ? repository.HttpsUrl : repository.SshUrl;
                var branch = repository.Branch;

                if (!Directory.Exists(repositoryDirectory))
                    Git($"clone {origin} {repositoryDirectory} --branch {branch} --progress");
                else
                {
                    SuppressErrors(() => Git($"remote add origin {origin}", repositoryDirectory));
                    Git($"remote set-url origin {origin}", repositoryDirectory);
                }
            }
            
            PrepareSolution(GlobalSolutionFile);
        });

    string ContributorsFile => RootDirectory / "CONTRIBUTORS.md";
    string ContributorsCacheFile => TemporaryDirectory / "contributors.dat";
    
    Target Contributors => _ => _
        .Executes(() =>
        {
            var previousContributors = File.Exists(ContributorsCacheFile) ? ReadAllLines(ContributorsCacheFile) : new string[0];
            
            var repositoryDirectories = GlobDirectories(RepositoriesDirectory, "*/*/.git").ToList();
            var contributors = repositoryDirectories
                .SelectMany(x => Git(@"log --pretty=""%an|%ae%n%cn|%ce""", workingDirectory: x, logOutput: false))
                .Select(x => x.Text)
                .Distinct().ToList()
                .Select(x => x.Split('|'))
                .ForEachLazy(x => Assert(x.Length == 2, "x.Length == 2"))
                .Select(x => new { Name = x[0], Email = x[1] }).ToList();

            var newContributors = contributors.Where(x => !previousContributors.Contains(x.Email));

            foreach (var newContributor in newContributors)
            {
                var content = File.ReadAllLines(ContributorsFile).Concat($"- {newContributor.Name}").OrderBy(x => x);
                File.WriteAllLines(ContributorsFile, content);
                Git($"add {ContributorsFile}");
                
                var message = $"Add {newContributor.Name} as contributor".DoubleQuote();
                var author = $"{newContributor.Name} <{newContributor.Email}>".DoubleQuote();
                Git($"commit -m {message} --author {author}");
            }
            
            File.WriteAllLines(ContributorsCacheFile, contributors.Select(x => x.Email).ToList());
        });

    [Parameter] readonly string ProjectName;
    string ProjectNameDashed => ProjectName.ToLowerInvariant().Replace(".", "-");
    [Parameter] readonly string[] Description;
    [Parameter] readonly string DefaultBranch = "master";
    // [PathExecutable] readonly Tool Hub;
    
    Target Add => _ => _
        .Requires(() => ProjectName)
        .Requires(() => Description)
        .Executes(() =>
        {
            var repositoryDirectory = RepositoriesDirectory / Organization / ProjectNameDashed;
            using (SwitchWorkingDirectory(repositoryDirectory))
            {
                var templateDirectory = RepositoriesDirectory / Organization / "template";
                CopyDirectoryRecursively(
                    templateDirectory,
                    repositoryDirectory,
                    excludeDirectory: IsDotDirectory,
                    directoryPolicy: DirectoryExistsPolicy.Merge);
        
                FillTemplateDirectoryRecursively(
                    repositoryDirectory,
                    replacements: new Dictionary<string, string>
                                  {
                                      { "Template", ProjectName },
                                      { "template", ProjectNameDashed }
                                  },
                    excludeDirectory: IsDotDirectory,
                    excludeFile: x => x.FullName.EndsWithOrdinalIgnoreCase("DotSettings"));
                
                // ExecuteWithRetry(() => PrepareSolution(GlobalSolutionFile), retryAttempts: 5);

                // Git("init");
                // Git($"checkout -b {DefaultBranch}");
                // Git($"commit -m {"Initialize repository".DoubleQuote()} --allow-empty");
                // Git("add .");
                // Git($"commit -m {"Add template files".DoubleQuote()}");
                // Hub($"create {Organization}/{LispName} -d {Description.JoinSpace().DoubleQuoteIfNeeded()} -h https://nuke.build");
            }

            // var updatedRepositories = Repositories
            //     .Concat(GitRepository.FromUrl($"https://github.com/{Organization}/{ProjectNameDashed}", DefaultBranch))
            //     .Select(x => $"{x.HttpsUrl}#{x.Branch}").OrderBy(x => x).ToList();
            // YamlSerializeToFile(updatedRepositories, RepositoriesFile);
            // Git($"add {RepositoriesFile}");
            // Git($"commit -m {$"Add {ProjectNameDashed}".DoubleQuote()}");
        });

    void CopyTemplate(AbsolutePath repositoryDirectory)
    {
        var templateDirectory = RepositoriesDirectory / Organization / "template";
        CopyDirectoryRecursively(templateDirectory, repositoryDirectory, excludeDirectory: IsDotDirectory);
        
        FillTemplateDirectoryRecursively(
            repositoryDirectory,
            replacements: new Dictionary<string, string>
                          {
                              { "Template", ProjectName },
                              { "template", ProjectNameDashed }
                          });
    }

    Target Readme => _ => _
        .Executes(() =>
        {
            ReadmeManager.WriteReadme(RootDirectory / "README.md", RepositoriesDirectory);
        });

    string TeamCityFile => RootDirectory / ".teamcity" / "settings.kts";
    
    Target TeamCity => _ => _
        .Executes(() =>
        {
            WriteTeamCityConfiguration(TeamCityFile, Repositories.ToList());
        });
}