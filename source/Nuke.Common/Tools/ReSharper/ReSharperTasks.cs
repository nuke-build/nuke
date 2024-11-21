// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tools.ReSharper;

partial class ReSharperTasks
{
    public const string ReSharperPluginLatest = "latest";

    protected override ToolOptions PreProcess(ToolOptions options)
    {
        var resharperOptions = ((ReSharperSettingsBase)options)
            .SetProcessToolPath(GetToolPath());
        if (resharperOptions.Plugins.Count == 0)
            return resharperOptions;

        var wave = GetWave(resharperOptions).NotNull("wave != null");
        var shadowDirectory = NukeBuild.TemporaryDirectory / $"ReSharper-{wave}-{GetHash()}";

        ((AbsolutePath)resharperOptions.ProcessToolPath).Parent.Copy(
            target: shadowDirectory,
            policy: ExistsPolicy.MergeAndOverwriteIfNewer);

        DownloadPlugins();

        return resharperOptions
            .SetProcessToolPath(shadowDirectory / Path.GetFileName(resharperOptions.ProcessToolPath));

        string GetWave(ReSharperSettingsBase toolSettings) =>
            Directory.GetParent(toolSettings.ProcessToolPath)
                .DescendantsAndSelf(x => x.Parent)
                .Select(x => Path.Combine(x.FullName, "jetbrains.resharper.globaltools.nuspec"))
                .Where(File.Exists)
                .Select(x => new FileInfo(x).Directory.NotNull().Name)
                .Select(x => $"{x[2]}{x[3]}{x[5]}")
                .SingleOrDefault();

        string GetHash() =>
            resharperOptions.ProcessToolPath
                .Concat(resharperOptions.Plugins.Select(x => x.Key + x.Value))
                .OrderBy(x => x).JoinComma()
                .GetMD5Hash()[..4];

        void DownloadPlugins() =>
            resharperOptions.Plugins
                .Select(x => (Plugin: x.Key, Version: x.Value == ReSharperPluginLatest ? null : x.Value))
                .ForEach(x => HttpTasks.HttpDownloadFile(
                    $"http://resharper-plugins.jetbrains.com/dotnet/api/v2/curated-feeds/Wave_v{wave}.0/Packages(Id='{x.Plugin}',Version='{x.Version}')/Download",
                    shadowDirectory / $"{x.Plugin}.nupkg"));
    }

    protected override void PostProcess(ToolOptions options)
    {
        if (options is ReSharperInspectCodeSettings inspectCodeOptions)
            TeamCity.Instance?.ImportData(TeamCityImportType.ReSharperInspectCode, inspectCodeOptions.Output);
    }
}
