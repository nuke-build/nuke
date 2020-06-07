// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI.AppVeyor
{
    [PublicAPI]
    public enum AppVeyorMessageCategory
    {
        Information,
        Warning,
        Error
    }
}
