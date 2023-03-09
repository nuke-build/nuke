// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;

namespace Nuke.Common.Tools.SignTool
{
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

            return new[]
                   {
                       programDirectory / "Windows Kits" / "10" / "bin" / "10.0.15063.0",
                       programDirectory / "Windows Kits" / "10" / "App Certification Kit",
                       programDirectory / "Windows Kits" / "10" / "bin" / platformIdentifier,
                       programDirectory / "Windows Kits" / "8.1" / "bin" / platformIdentifier,
                       programDirectory / "Windows Kits" / "8.0" / "bin" / platformIdentifier,
                       programDirectory / "Microsoft SDKs" / "Windows" / "v7.1A" / "Bin"
                   }
                .Select(x => x / "signtool.exe")
                .WhereFileExists()
                .FirstOrDefault();
        }
    }
}
