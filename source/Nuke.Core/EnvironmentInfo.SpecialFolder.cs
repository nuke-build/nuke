// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core
{
    [PublicAPI]
    public enum SpecialFolders
    {
        ProgramFiles = Environment.SpecialFolder.ProgramFiles,
        ProgramFilesX86 = Environment.SpecialFolder.ProgramFilesX86,
        LocalApplicationData = Environment.SpecialFolder.LocalApplicationData,
        ApplicationData = Environment.SpecialFolder.ApplicationData,
        CommonApplicationData = Environment.SpecialFolder.CommonApplicationData,
        Windows = Environment.SpecialFolder.Windows,
        System = Environment.SpecialFolder.System,
        UserProfile = Environment.SpecialFolder.UserProfile
    }

    public static partial class EnvironmentInfo
    {
        [CanBeNull]
        public static string SpecialFolder (SpecialFolders folder)
        {
            return Environment.GetFolderPath((Environment.SpecialFolder) folder);
        }
    }
}
