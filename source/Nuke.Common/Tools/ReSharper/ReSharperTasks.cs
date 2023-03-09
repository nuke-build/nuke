// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tools.ReSharper
{
    partial class ReSharperTasks
    {
        public const string ReSharperPluginLatest = "latest";

        private static void PreProcess<T>(ref T toolSettings) where T : ReSharperSettingsBase
        {
            if (toolSettings.Plugins.Count == 0)
                return;

            var wave = GetWave(toolSettings).NotNull("wave != null");
            var shadowDirectory = GetShadowDirectory(toolSettings, wave);

            FileSystemTasks.CopyDirectoryRecursively(
                Path.GetDirectoryName(toolSettings.ProcessToolPath).NotNull(),
                shadowDirectory,
                DirectoryExistsPolicy.Merge,
                FileExistsPolicy.OverwriteIfNewer);

            toolSettings.Plugins
                .Select(x => (Plugin: x.Key, Version: x.Value == ReSharperPluginLatest ? null : x.Value))
                .ForEach(x => HttpTasks.HttpDownloadFile(
                    $"http://resharper-plugins.jetbrains.com/dotnet/api/v2/curated-feeds/Wave_v{wave}.0/Packages(Id='{x.Plugin}',Version='{x.Version}')/Download",
                    Path.Combine(shadowDirectory, $"{x.Plugin}.nupkg")));

            toolSettings = toolSettings.SetProcessToolPath(Path.Combine(shadowDirectory, Path.GetFileName(toolSettings.ProcessToolPath)));
        }

        [CanBeNull]
        private static string GetWave(ReSharperSettingsBase toolSettings)
        {
            return Directory.GetParent(toolSettings.ProcessToolPath)
                .DescendantsAndSelf(x => x.Parent)
                .Select(x => Path.Combine(x.FullName, "jetbrains.resharper.globaltools.nuspec"))
                .Where(File.Exists)
                .Select(x => new FileInfo(x).Directory.NotNull().Name)
                .Select(x => $"{x[2]}{x[3]}{x[5]}")
                .SingleOrDefault();
        }

        [CanBeNull]
        private static IProcess StartProcess(ReSharperSettingsBase toolSettings)
        {
            return ProcessTasks.StartProcess(toolSettings);
        }

        private static void PostProcess(ReSharperInspectCodeSettings toolSettings)
        {
            TeamCity.Instance?.ImportData(TeamCityImportType.ReSharperInspectCode, toolSettings.Output);
        }

        private static string GetShadowDirectory(ReSharperSettingsBase toolSettings, string wave)
        {
            var hashCode = toolSettings.ProcessToolPath.Concat(toolSettings.Plugins.Select(x => x.Key + x.Value)).OrderBy(x => x).JoinCommaSpace().GetMD5Hash();
            return Path.Combine(NukeBuild.TemporaryDirectory, $"ReSharper-{wave}-{hashCode.Substring(startIndex: 0, length: 4)}");
        }
    }

    partial class ReSharperSettingsBase
    {
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? ProcessTasks.DefaultLogger;
    }
}
