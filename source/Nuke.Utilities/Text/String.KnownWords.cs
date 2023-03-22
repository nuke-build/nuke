// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

namespace Nuke.Common.Utilities
{
    public static partial class StringExtensions
    {
        private static readonly string[] KnownWords =
        {
            "DotNet",
            "GitHub",
            "GitVersion",
            "MSBuild",
            "NuGet",
            "ReSharper",
            "AppVeyor",
            "TeamCity",
            "GitLab",
            "SignPath",
            "JetBrains"
        };
    }
}
