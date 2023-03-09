// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI.TeamCity
{
    [PublicAPI]
    public enum TeamCityNoDataPublishedAction
    {
        info,
        nothing,
        warning,
        error
    }
}
