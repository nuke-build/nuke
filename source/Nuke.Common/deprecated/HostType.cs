// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Core
{
    [Obsolete("Namespace 'Core' is deprecated. Simply do a text replace from 'Nuke.Core' to 'Nuke.Common' to resolve all warnings.")]
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
