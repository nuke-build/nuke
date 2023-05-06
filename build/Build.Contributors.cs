// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.Tools.Git.GitTasks;

partial class Build
{
    AbsolutePath ContributorsFile => RootDirectory / "CONTRIBUTORS.md";
    AbsolutePath ContributorsCacheFile => TemporaryDirectory / "contributors.dat";

    [UsedImplicitly]
    Target UpdateContributors => _ => _
        .Executes(() =>
        {
            var previousContributors = ContributorsCacheFile.Existing()?.ReadAllLines() ?? new string[0];

            var repositoryDirectories = new[] { RootDirectory / ".git" }
                .Concat(ExternalRepositoriesDirectory.GlobDirectories("*/.git"));
            var contributors = repositoryDirectories
                .SelectMany(x => Git(@$"log --pretty=""%an|%ae%n%cn|%ce""", workingDirectory: x, logOutput: false))
                .Select(x => x.Text)
                .Distinct().ToList()
                .Select(x => x.Split('|'))
                .ForEachLazy(x => Assert.Count(x, length: 2))
                .Select(x => new { Name = x[0], Email = x[1] }).ToList();

            var newContributors = contributors.Where(x => !previousContributors.Contains(x.Email));

            foreach (var newContributor in newContributors)
            {
                var content = (ContributorsFile.Existing()?.ReadAllLines() ?? new string[0])
                    .Concat($"- {newContributor.Name}").OrderBy(x => x);
                ContributorsFile.WriteAllLines(content, Encoding.Default);
                Git($"add {ContributorsFile}");

                var message = $"Add {newContributor.Name} as contributor".DoubleQuote();
                var author = $"{newContributor.Name} <{newContributor.Email}>".DoubleQuote();
                Git($"commit -m {message} --author {author}");
            }

            ContributorsCacheFile.WriteAllLines(contributors.Select(x => x.Email).ToList());
        });
}
