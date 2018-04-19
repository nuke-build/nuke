// Copyright Matthias Koch, Sebastian Karasek 2018.
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
        private static Lazy<HostType> s_hostType = new Lazy<HostType>(() =>
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
            if (GitLab.IsRunningGitLab)
                return HostType.GitLab;
            if (Travis.IsRunningTravis)
                return HostType.Travis;

            return HostType.Console;
        });

        internal static HostType HostType => s_hostType.Value;

        internal static bool IsLocalBuild => HostType == HostType.Console;

        internal static string[] InvokedTargets
        {
            get
            {
                var argument = ParameterService.Instance.GetCommandLineArgument<string>(position: 1);
                argument = argument == null || argument.StartsWith("-") ? null : argument;

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
