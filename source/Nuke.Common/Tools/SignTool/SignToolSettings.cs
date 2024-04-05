// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Linq;
using JetBrains.Annotations;
using NuGet.Configuration;
using Nuke.Common.IO;

namespace Nuke.Common.Tools.SignTool;

partial class SignToolTasks
{
    [CanBeNull]
    private static string GetToolPath()
    {
        var programDirectory = EnvironmentInfo.SpecialFolder(
            EnvironmentInfo.Is64Bit
                ? SpecialFolders.ProgramFilesX86
                : SpecialFolders.ProgramFiles).NotNull();

        var platformIdentifier = EnvironmentInfo.Is64Bit ? "x64" : "x86";
        const string windowsKitLastVersion = "10";
        const string windowsKitVersionWildcard = windowsKitLastVersion + ".*";
        const string signtoolExe = "signtool.exe";
        const string microsoftBuildToolsNugetPackage = "microsoft.windows.sdk.buildtools";

        var windowsKitsRootDirectory = programDirectory / "Windows Kits" / windowsKitLastVersion;

        var signToolPath = windowsKitsRootDirectory.GlobFiles($"bin/{windowsKitVersionWildcard}/{platformIdentifier}/{signtoolExe}").LastOrDefault();

        if(signToolPath == null)
        {
            var nugetPackagesPath = SettingsUtility.GetGlobalPackagesFolder(Settings.LoadDefaultSettings(null));

            signToolPath = AbsolutePath.Create(nugetPackagesPath)
                .GlobFiles($"{microsoftBuildToolsNugetPackage}/{windowsKitVersionWildcard}/bin/{windowsKitVersionWildcard}/{platformIdentifier}/{signtoolExe}")
                .LastOrDefault();

            signToolPath ??= windowsKitsRootDirectory.GlobFiles($"App Certification Kit/{signtoolExe}").SingleOrDefault();
        }

        return signToolPath;
    }
}
