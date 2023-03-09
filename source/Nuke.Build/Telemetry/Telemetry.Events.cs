// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Serilog;

namespace Nuke.Common.Execution
{
    internal partial class Telemetry
    {
        public static void BuildStarted(INukeBuild build)
        {
            TrackEvent(
                eventName: nameof(BuildStarted),
                propertiesProvider: () =>
                    GetCommonProperties(build)
                        .AddDictionary(GetBuildProperties(build))
                        .AddDictionary(GetRepositoryProperties(build.RootDirectory)));
        }

        public static void TargetSucceeded(ExecutableTarget target, INukeBuild build)
        {
            if (!target.Name.EqualsAnyOrdinalIgnoreCase(s_knownTargets) ||
                target.Status != ExecutionStatus.Succeeded)
                return;

            TrackEvent(
                eventName: nameof(TargetSucceeded),
                propertiesProvider: () =>
                    GetCommonProperties(build)
                        .AddDictionary(GetTargetProperties(build, target))
                        .AddDictionary(GetBuildProperties(build))
                        .AddDictionary(GetRepositoryProperties(build.RootDirectory)));
        }

        public static void ConfigurationGenerated(Type hostType, string generatorId, INukeBuild build)
        {
            TrackEvent(
                eventName: nameof(ConfigurationGenerated),
                propertiesProvider: () =>
                    GetCommonProperties(build)
                        .AddDictionary(GetGeneratorProperties(hostType, generatorId))
                        .AddDictionary(GetBuildProperties(build))
                        .AddDictionary(GetRepositoryProperties(EnvironmentInfo.WorkingDirectory)));
        }

        public static void SetupBuild()
        {
            TrackEvent(
                eventName: nameof(SetupBuild),
                propertiesProvider: () =>
                    GetCommonProperties()
                        .AddDictionary(GetRepositoryProperties(EnvironmentInfo.WorkingDirectory)));
        }

        public static void ConvertCake()
        {
            TrackEvent(
                eventName: nameof(ConvertCake),
                propertiesProvider: () =>
                    GetCommonProperties()
                        .AddDictionary(GetRepositoryProperties(EnvironmentInfo.WorkingDirectory)));
        }

        public static void AddPackage()
        {
            TrackEvent(
                eventName: nameof(AddPackage),
                propertiesProvider: () =>
                    GetCommonProperties()
                        .AddDictionary(GetRepositoryProperties(EnvironmentInfo.WorkingDirectory)));
        }

        private static void TrackEvent(string eventName, Func<IDictionary<string, string>> propertiesProvider)
        {
            if (s_client == null)
                return;

            try
            {
                var properties = propertiesProvider.Invoke();
                // TODO: logging additional
                Log.Verbose("Sending {EventName} telemetry event ...", eventName);
                var longestPropertyName = properties.Keys.Max(x => x.Length);
                properties.OrderBy(x => x.Key).ForEach(x => Log.Verbose("  {Key} = {Value}", x.Key.PadRight(longestPropertyName), x.Value ?? "<null>"));

                s_client.TrackEvent(eventName, properties);
                s_client.Flush();
            }
            catch (Exception exception)
            {
                Log.Verbose(exception, "Failed to sent {EventName} telemetry event", eventName);
            }
        }
    }
}
