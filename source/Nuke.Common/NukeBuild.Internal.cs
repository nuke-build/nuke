// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.BuildServers;
using Nuke.Common.Execution;
using Nuke.Common.Utilities;

namespace Nuke.Common
{
    public abstract partial class NukeBuild
    {
        private static HostType GetHostType()
        {
            var hostType = EnvironmentInfo.Argument<HostType?>(nameof(Host));
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
        }

        private static string[] GetInvokedTargets()
        {
            var argument = ParameterService.Instance.GetCommandLineArgument<string>(position: 1);
            argument = argument == null || argument.StartsWith("-") ? null : argument;

            if (argument != null)
                return argument.Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

            var parameter = EnvironmentInfo.ParameterSet<string>("target", separator: '+');
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

        private static string[] GetSkippedTargets()
        {
            if (EnvironmentInfo.ParameterSwitch("nodeps"))
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
