// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI.GitHubActions
{
    /// <summary>
    /// See <a href="https://help.github.com/en/articles/virtual-environments-for-github-actions#about-virtual-environments">Virtual environments for GitHub Actions</a>
    /// </summary>
    [PublicAPI]
    public enum GitHubActionsImage
    {
        WindowsServer2019,
        WindowsServer2016R2,
        Ubuntu1804,
        Ubuntu1604,
        MacOs1014,
        WindowsLatest,
        UbuntuLatest,
        MacOsLatest
    }

    public static class GitHubActionsImageExtensions
    {
        public static string ConvertToString(this GitHubActionsImage image)
        {
            return image switch
            {
                GitHubActionsImage.WindowsServer2019 => "windows-2019",
                GitHubActionsImage.WindowsLatest => "windows-latest",
                GitHubActionsImage.WindowsServer2016R2 => "windows-2016",
                GitHubActionsImage.Ubuntu1804 => "ubuntu-18.04",
                GitHubActionsImage.UbuntuLatest => "ubuntu-latest",
                GitHubActionsImage.Ubuntu1604 => "ubuntu-16.04",
                GitHubActionsImage.MacOs1014 => "macOS-10.14",
                GitHubActionsImage.MacOsLatest => "macOS-latest",
                _ => throw new ArgumentOutOfRangeException(nameof(image), image, message: null)
            };
        }
    }
}
