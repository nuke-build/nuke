// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.TextTasks;
using static Nuke.Common.Tools.Git.GitTasks;

partial class Build
{
    string ContributorsFile => RootDirectory / "CONTRIBUTORS.md";
    string ContributorsCacheFile => TemporaryDirectory / "contributors.dat";

    [UsedImplicitly]
    Target UpdateContributors => _ => _
        .Executes(() =>
        {
            var previousContributors = File.Exists(ContributorsCacheFile) ? ReadAllLines(ContributorsCacheFile) : new string[0];

            var repositoryDirectories = new[] { RootDirectory / ".git" }
                .Concat(ExternalRepositoriesDirectory.GlobDirectories("*/.git"));
            var contributors = repositoryDirectories
                .SelectMany(x => Git(@"log --pretty=""%an|%ae%n%cn|%ce""", workingDirectory: x, logOutput: false))
                .Select(x => x.Text)
                .Distinct().ToList()
                .Select(x => x.Split('|'))
                .ForEachLazy(x => Assert.Count(x, length: 2))
                .Select(x => new { Name = x[0], Email = x[1] }).ToList();

            var newContributors = contributors.Where(x => !previousContributors.Contains(x.Email));

            foreach (var newContributor in newContributors)
            {
                var content = (File.Exists(ContributorsFile) ? File.ReadAllLines(ContributorsFile) : new string[0])
                    .Concat($"- {newContributor.Name}").OrderBy(x => x);
                WriteAllLines(ContributorsFile, content);
                Git($"add {ContributorsFile}");

                var message = $"Add {newContributor.Name} as contributor".DoubleQuote();
                var author = $"{newContributor.Name} <{newContributor.Email}>".DoubleQuote();
                Git($"commit -m {message} --author {author}");
            }

            WriteAllLines(ContributorsCacheFile, contributors.Select(x => x.Email).ToList());
        });
}
