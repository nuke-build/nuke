﻿// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;

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
                       Path.Combine(programDirectory, "Windows Kits", "10", "bin", "10.0.15063.0"),
                       Path.Combine(programDirectory, "Windows Kits", "10", "App Certification Kit"),
                       Path.Combine(programDirectory, "Windows Kits", "10", "bin", platformIdentifier),
                       Path.Combine(programDirectory, "Windows Kits", "8.1", "bin", platformIdentifier),
                       Path.Combine(programDirectory, "Windows Kits", "8.0", "bin", platformIdentifier),
                       Path.Combine(programDirectory, "Microsoft SDKs", "Windows", "v7.1A", "Bin")
                   }
                .Select(x => Path.Combine(x, "signtool.exe"))
                .FirstOrDefault(File.Exists);
        }
    }
}
