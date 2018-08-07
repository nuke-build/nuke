// Copyright 2018 Maintainers and Contributors of NUKE.
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
