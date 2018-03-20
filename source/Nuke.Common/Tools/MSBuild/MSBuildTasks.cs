// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.Tools.GitVersion;
using Nuke.Core;
using Nuke.Core.BuildServers;
using Nuke.Core.IO;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.MSBuild
{
    partial class MSBuildTasks
    {
        private static string GetToolPath()
        {
            return MSBuildToolPathResolver.Resolve();
        }

        public static MSBuildSettings DefaultMSBuild
        {
            get
            {
                var toolSettings = new MSBuildSettings()
                    .SetWorkingDirectory(NukeBuild.Instance.SolutionDirectory)
                    .SetSolutionFile(NukeBuild.Instance.SolutionFile)
                    .SetMaxCpuCount(Environment.ProcessorCount)
                    .SetConfiguration(NukeBuild.Instance.Configuration)
                    .SetNodeReuse(NukeBuild.Instance.IsLocalBuild);

                var teamCityLogger = TeamCity.Instance?.ConfigurationProperties["TEAMCITY_DOTNET_MSBUILD_EXTENSIONS4_0"];
                if (teamCityLogger != null)
                {
                    toolSettings = toolSettings
                        .AddLoggers($"JetBrains.BuildServer.MSBuildLoggers.MSBuildLogger,{teamCityLogger}")
                        .EnableNoConsoleLogger();
                }

                return toolSettings;
            }
        }

        public static MSBuildSettings DefaultMSBuildRestore => DefaultMSBuild
            .SetTargets("Restore");

        public static MSBuildSettings DefaultMSBuildCompile => DefaultMSBuild
            .SetTargets("Rebuild")
            .SetAssemblyVersion(GitVersionAttribute.Value?.GetNormalizedAssemblyVersion())
            .SetFileVersion(GitVersionAttribute.Value?.GetNormalizedFileVersion())
            .SetInformationalVersion(GitVersionAttribute.Value?.InformationalVersion);

        public static MSBuildSettings DefaultMSBuildPack => DefaultMSBuild
            .SetTargets("Restore", "Pack")
            .EnableIncludeSymbols()
            .SetPackageOutputPath(NukeBuild.Instance.OutputDirectory)
            .SetPackageVersion(GitVersionAttribute.Value?.NuGetVersionV2);

        /// <summary>
        /// Parses MSBuild project file.
        /// </summary>
        public static MSBuildProject MSBuildParseProject(string projectFile, Configure<MSBuildSettings> configurator = null)
        {
            Logger.Trace($"Parsing project file '{projectFile}'...");

            var content = TextTasks.ReadAllText(projectFile);
            var isSdkProject = content.Contains("Sdk=\"Microsoft.NET.Sdk\"");
            var isLegacyProject = content.Contains("http://schemas.microsoft.com/developer/msbuild/2003");
            ControlFlow.Assert((isSdkProject || isLegacyProject) && (!isSdkProject || !isLegacyProject), "Unknown format.");

            var toolSettings = configurator.InvokeSafe(new MSBuildSettings())
                .SetProjectFile(projectFile)
                .SetVerbosity(MSBuildVerbosity.Diagnostic)
                .SetTargets(Guid.NewGuid().ToString());
            var processSettings = new ProcessSettings()
                .SetRedirectOutput(redirectOutput: true);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertWaitForExit();

            var lines = process.Output.Select(x => x.Text).ToArray();
            var properties = ParseProperties(lines);
            var itemGroups = ParseItemGroups(lines);

            return new MSBuildProject(isSdkProject, properties, itemGroups);
        }

        private static Dictionary<string, string> ParseProperties(string[] lines)
        {
            var propertyLines = lines
                .SkipWhile(x => x != "Initial Properties:").Skip(count: 1)
                .TakeWhile(x => x != "Initial Items:").ToList();

            var dictionary = new Dictionary<string, string>();
            for (var i = 0; i < propertyLines.Count - 1; i++)
            {
                var line = propertyLines[i];
                var equalIndex = line.IndexOf(value: '=');
                if (equalIndex <= 1)
                {
                    Logger.Warn($"Could not parse line '{line}'.");
                    continue;
                }

                var property = line.Substring(startIndex: 0, length: equalIndex - 1);
                var value = line.Substring(equalIndex + 2);

                while (i < propertyLines.Count - 2)
                {
                    if (propertyLines[i + 1].IndexOf(value: '=') > 1)
                        break;

                    if (!string.IsNullOrWhiteSpace(propertyLines[i + 1]))
                        value += propertyLines[i + 1].Trim();

                    i++;
                }

                dictionary.Add(property, value);
            }

            return dictionary;
        }

        private static ILookup<string, string> ParseItemGroups(string[] lines)
        {
            var itemGroupLines = lines
                .SkipWhile(x => x != "Initial Items:").Skip(count: 1)
                .TakeWhile(x => !string.IsNullOrWhiteSpace(x)).ToList();

            var lookup = new LookupTable<string, string>(EqualityComparer<string>.Default);
            for (var i = 0; i < itemGroupLines.Count; i++)
            {
                var group = itemGroupLines[i];

                while (i < itemGroupLines.Count - 1 &&
                       char.IsWhiteSpace(itemGroupLines[i + 1][index: 0]))
                {
                    if (char.IsLetter(itemGroupLines[i + 1], index: 4))
                        lookup.Add(group, itemGroupLines[i + 1].Trim());

                    i++;
                }
            }

            return lookup;
        }
    }
}
