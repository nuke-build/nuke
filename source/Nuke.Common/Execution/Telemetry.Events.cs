// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Execution
{
    internal partial class Telemetry
    {
        public static void BuildStarted(NukeBuild build)
        {
            TrackEvent(
                eventName: nameof(BuildStarted),
                properties: GetCommonProperties(build)
                    .AddDictionary(GetBuildProperties(build))
                    .AddDictionary(GetRepositoryProperties(NukeBuild.RootDirectory)));
        }

        public static void TargetSucceeded(ExecutableTarget target, NukeBuild build)
        {
            if (target.Name.EqualsAnyOrdinalIgnoreCase(s_knownTargets) &&
                target.Status == ExecutionStatus.Succeeded)
            {
                TrackEvent(
                    eventName: nameof(TargetSucceeded),
                    properties: GetCommonProperties(build)
                        .AddDictionary(GetTargetProperties(build, target))
                        .AddDictionary(GetBuildProperties(build))
                        .AddDictionary(GetRepositoryProperties(NukeBuild.RootDirectory)));
            }
        }

        public static void ConfigurationGenerated(Type hostType, string generatorId, NukeBuild build)
        {
            TrackEvent(
                eventName: nameof(ConfigurationGenerated),
                properties: GetCommonProperties(build)
                    .AddDictionary(GetGeneratorProperties(hostType, generatorId))
                    .AddDictionary(GetBuildProperties(build))
                    .AddDictionary(GetRepositoryProperties(EnvironmentInfo.WorkingDirectory)));
        }

        public static void SetupBuild()
        {
            TrackEvent(
                eventName: nameof(SetupBuild),
                properties: GetCommonProperties()
                    .AddDictionary(GetRepositoryProperties(EnvironmentInfo.WorkingDirectory)));
        }

        public static void ConvertCake()
        {
            TrackEvent(
                eventName: nameof(ConvertCake),
                properties: GetCommonProperties()
                    .AddDictionary(GetRepositoryProperties(EnvironmentInfo.WorkingDirectory)));
        }

        public static void AddPackage()
        {
            TrackEvent(
                eventName: nameof(AddPackage),
                properties: GetCommonProperties()
                    .AddDictionary(GetRepositoryProperties(EnvironmentInfo.WorkingDirectory)));
        }

        private static void TrackEvent(
            string eventName,
            IDictionary<string, string> properties = null,
            IDictionary<string, double> metrics = null)
        {
            Logger.Trace($"Sending '{eventName}' telemetry event...");
            var longestPropertyName = properties?.Keys.Max(x => x.Length);
            properties?.OrderBy(x => x.Key).ForEach(x => Logger.Trace($"  {x.Key.PadRight(longestPropertyName.Value)} = {x.Value ?? "<null>"}"));

            s_client?.TrackEvent(eventName, properties, metrics);
            s_client?.Flush();
        }
    }
}
