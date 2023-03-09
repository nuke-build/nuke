// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.CI.AppVeyor
{
    /// <summary>
    /// See <a href="https://www.appveyor.com/docs/build-environment/">Build environment</a>
    /// </summary>
    [PublicAPI]
    public enum AppVeyorImage
    {
        [EnumValue("Visual Studio 2013")] VisualStudio2013,
        [EnumValue("Visual Studio 2015")] VisualStudio2015,
        [EnumValue("Visual Studio 2017")] VisualStudio2017,
        [EnumValue("Visual Studio 2019")] VisualStudio2019,
        [EnumValue("Visual Studio 2022")] VisualStudio2022,
        [EnumValue("Visual Studio 2022")] VisualStudioLatest,
        [EnumValue("Ubuntu1604")] Ubuntu1604,
        [EnumValue("Ubuntu1804")] Ubuntu1804,
        [EnumValue("Ubuntu")] UbuntuLatest,
        [EnumValue("MacOs-Mojave")] MacOsMojave,
        [EnumValue("MacOs")] MacOsLatest
    }
}
