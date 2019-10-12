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
    public enum AppVeyorImages
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

    public static class AppVeyorImagesExtensions
    {
        public static string ConvertToString(this AppVeyorImages image)
        {
            return image switch
            {
                AppVeyorImages.VisualStudio2013 => "Visual Studio 2013",
                AppVeyorImages.VisualStudio2015 => "Visual Studio 2015",
                AppVeyorImages.VisualStudio2017 => "Visual Studio 2017",
                AppVeyorImages.VisualStudio2019 => "Visual Studio 2019",
                AppVeyorImages.VisualStudioLatest => ConvertToString(AppVeyorImages.VisualStudio2019),
                AppVeyorImages.Ubuntu1604 => "Ubuntu1604",
                AppVeyorImages.Ubuntu1804 => "Ubuntu1804",
                AppVeyorImages.UbuntuLatest => ConvertToString(AppVeyorImages.Ubuntu1804),
                _ => throw new ArgumentOutOfRangeException(nameof(image), image, message: null)
            };
        }
    }
}
