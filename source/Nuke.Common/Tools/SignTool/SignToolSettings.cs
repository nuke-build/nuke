// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Linq;
using JetBrains.Annotations;
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

        var windowsKitsRootDirectory = programDirectory / "Windows Kits" / windowsKitLastVersion;

        var signToolPath = windowsKitsRootDirectory.GlobFiles($"bin/{windowsKitLastVersion}.*/{platformIdentifier}/signtool.exe").LastOrDefault();

        return signToolPath ?? windowsKitsRootDirectory.GlobFiles("App Certification Kit/signtool.exe").SingleOrDefault();
    }
}
