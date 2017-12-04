// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core.BuildServers;

namespace Nuke.Core
{
    public static partial class EnvironmentInfo
    {
        internal static HostType GetActualHostType()
        {
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
}
