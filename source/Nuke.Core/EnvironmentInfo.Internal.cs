// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core.BuildServers;
using Nuke.Core.Execution;
using Nuke.Core.Utilities;

namespace Nuke.Core
{
    public static partial class EnvironmentInfo
    {
        internal static HostType HostType
        {
            get
            {
                var hostType = Parameter<HostType?>(nameof(NukeBuild.Host));
                if (hostType.HasValue)
                    return hostType.Value;

                if (AppVeyor.IsRunningAppVeyor)
                    return HostType.AppVeyor;
                if (Jenkins.IsRunningJenkins)
                    return HostType.Jenkins;
                if (TeamCity.IsRunningTeamCity)
                    return HostType.TeamCity;
                if (TeamServices.IsRunningTeamServices)
                    return HostType.TeamServices;
                if (Bitrise.IsRunningBitrise)
                    return HostType.Bitrise;

                return HostType.Console;
            }
        }

        internal static bool IsLocalBuild => HostType == HostType.Console;

        internal static string[] InvokedTargets
        {
            get
            {
                var argument = Environment.GetCommandLineArgs()
                    .Skip(count: 1).Take(count: 1)
                    .SingleOrDefault(x => !x.StartsWith("-"));
                if (argument != null)
                    return argument.Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

                var parameter = ParameterSet<string>("target", separator: '+');
                if (parameter != null)
                {
                    Logger.Warn(new[]
                                {
                                    "The 'Target' parameter is deprecated.",
                                    "Starting with the next version, targets need to be specified positional:",
                                    string.Empty,
                                    "  Usage: build <target1[+target2]> [-parameter value]",
                                    string.Empty
                                }.JoinNewLine());
                    return parameter;
                }

                return new[] { BuildExecutor.DefaultTarget };
            }
        }
        
        internal static string[] SkippedTargets
        {
            get
            {
                if (ParameterSwitch("nodeps"))
                {
                    Logger.Warn(new[]
                                {
                                    "The 'NoDeps' switch is deprecated.",
                                    "Starting with the next version, you can use the 'Skip' parameter to skip all dependencies or only specified ones:",
                                    string.Empty,
                                    "  Usage: build -skip",
                                    "         build -skip Clean+Restore",
                                    string.Empty
                                }.JoinNewLine());
                    return new string[0];
                }

                return null;
            }
        }
    }
}
