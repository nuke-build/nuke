// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nuke.Common.IO;
using Nuke.Components;
using Serilog;
using static Nuke.Common.IO.HttpTasks;

partial class Build
{
    AbsolutePath LicensesDirectory => TemporaryDirectory / "licenses";

    IEnumerable<(string Project, string Url)> Licenses
        => new[]
           {
               ("Glob", "https://raw.githubusercontent.com/kthompson/glob/develop/LICENSE"),
               ("ICSharpCode.SharpZipLib", "https://raw.githubusercontent.com/icsharpcode/SharpZipLib/master/LICENSE.txt"),
               ("JetBrains.Annotations", "https://raw.githubusercontent.com/JetBrains/JetBrains.Annotations/main/license.md"),
               ("Microsoft.ApplicationInsights", "https://raw.githubusercontent.com/microsoft/ApplicationInsights-dotnet/main/LICENSE"),
               ("Microsoft.Build", "https://raw.githubusercontent.com/dotnet/msbuild/main/LICENSE"),
               ("Microsoft.CodeAnalysis", "https://raw.githubusercontent.com/dotnet/roslyn/main/License.txt"),
               ("Newtonsoft.Json", "https://raw.githubusercontent.com/JamesNK/Newtonsoft.Json/master/LICENSE.md"),
               ("NuGet", "https://raw.githubusercontent.com/NuGet/NuGet.Client/dev/LICENSE.txt"),
               ("Octokit", "https://raw.githubusercontent.com/octokit/octokit.net/main/LICENSE.txt"),
               ("Serilog", "https://raw.githubusercontent.com/serilog/serilog/dev/LICENSE"),
               ("Spectre.Console", "https://raw.githubusercontent.com/matkoch/spectre.console/main/LICENSE.md"),
               ("YamlDotNet", "https://raw.githubusercontent.com/aaubry/YamlDotNet/master/LICENSE.txt")
           };

    Target DownloadLicenses => _ => _
        .After<ICompile>()
        .DependentFor<IPack>()
        .Executes(() =>
        {
            LicensesDirectory.CreateOrCleanDirectory();

            var downloadTasks = Licenses.Select(async x =>
            {
                await HttpDownloadFileAsync(x.Url, LicensesDirectory / $"{x.Project}.txt");
                Log.Information("Downloaded license for {Project}", x.Project);
            });
            Task.WaitAll(downloadTasks.ToArray());
        });
}
