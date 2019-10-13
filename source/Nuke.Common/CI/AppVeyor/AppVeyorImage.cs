// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI.AppVeyor
{
    /// <summary>
    /// See <a href="https://www.appveyor.com/docs/build-environment/">Build environment</a>
    /// </summary>
    [PublicAPI]
    public enum AppVeyorImage
    {
        VisualStudio2013,
        VisualStudio2015,
        VisualStudio2017,
        VisualStudio2019,
        VisualStudioLatest,
        Ubuntu1604,
        Ubuntu1804,
        UbuntuLatest
    }

    public static class AppVeyorImageExtensions
    {
        public static string ConvertToString(this AppVeyorImage image)
        {
            return image switch
            {
                AppVeyorImage.VisualStudio2013 => "Visual Studio 2013",
                AppVeyorImage.VisualStudio2015 => "Visual Studio 2015",
                AppVeyorImage.VisualStudio2017 => "Visual Studio 2017",
                AppVeyorImage.VisualStudio2019 => "Visual Studio 2019",
                AppVeyorImage.VisualStudioLatest => ConvertToString(AppVeyorImage.VisualStudio2019),
                AppVeyorImage.Ubuntu1604 => "Ubuntu1604",
                AppVeyorImage.Ubuntu1804 => "Ubuntu1804",
                AppVeyorImage.UbuntuLatest => ConvertToString(AppVeyorImage.Ubuntu1804),
                _ => throw new ArgumentOutOfRangeException(nameof(image), image, message: null)
            };
        }
    }
}
