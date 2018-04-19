// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common
{
    public enum HostType
    {
        Console,
        TeamCity,
        TeamServices,
        Bitrise,
        AppVeyor,
        Jenkins,
        Travis,
        GitLab
    }
}
