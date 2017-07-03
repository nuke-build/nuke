// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

#if NETCORE
using System.Runtime.InteropServices;
using System.Text;
#endif

namespace Nuke.Core
{
    public enum SpecialFolders
    {
        ProgramFiles,
        ProgramFilesX86,
        LocalApplicationData,
        ApplicationData,
        CommonApplicationData,
        Windows,
        System,
        UserProfile
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////
    // This code was taken and adapted from the MSBuild project.
    // https://github.com/Microsoft/msbuild/blob/xplat/src/Shared/FileUtilities.GetFolderPath.cs
    //
    // Copyright (c) Microsoft. All rights reserved.
    // Licensed under the MIT license. See LICENSE file in the project root for full license information.
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    public static partial class EnvironmentInfo
    {
#if !NETCORE

        private static readonly Dictionary<SpecialFolders, Environment.SpecialFolder> s_lookup
                = new Dictionary<SpecialFolders, Environment.SpecialFolder>
                  {
                      { SpecialFolders.ApplicationData, Environment.SpecialFolder.ApplicationData },
                      { SpecialFolders.CommonApplicationData, Environment.SpecialFolder.CommonApplicationData },
                      { SpecialFolders.LocalApplicationData, Environment.SpecialFolder.LocalApplicationData },
                      { SpecialFolders.ProgramFiles, Environment.SpecialFolder.ProgramFiles },
                      { SpecialFolders.ProgramFilesX86, Environment.SpecialFolder.ProgramFilesX86 },
                      { SpecialFolders.Windows, Environment.SpecialFolder.Windows },
                      { SpecialFolders.System, Environment.SpecialFolder.System },
                      { SpecialFolders.UserProfile, Environment.SpecialFolder.UserProfile }
                  };

#endif

        [CanBeNull]
        public static string SpecialFolder (SpecialFolders folder)
        {
#if NETCORE
            if (Platform == PlatformFamily.Windows)
                return Windows.GetFolder(folder);
            if (IsUnix)
                return Unix.GetFolder(folder);

            throw new NotSupportedException($"Not supported for platform '{Platform}'.");
#else
            return Environment.GetFolderPath(s_lookup[folder]);
#endif
        }

#if NETCORE

        private static class Windows
        {
            private static readonly Dictionary<SpecialFolders, int> s_lookup =
                    new Dictionary<SpecialFolders, int>
                    {
                        { SpecialFolders.ApplicationData, 0x001a },
                        { SpecialFolders.CommonApplicationData, 0x0023 },
                        { SpecialFolders.LocalApplicationData, 0x001c },
                        { SpecialFolders.ProgramFiles, 0x0026 },
                        { SpecialFolders.ProgramFilesX86, 0x002a },
                        { SpecialFolders.Windows, 0x0024 },
                        { SpecialFolders.System, 0x0025 },
                        { SpecialFolders.UserProfile, 0x0028 }
                    };

            [DllImport("shell32.dll", CharSet = CharSet.Unicode, BestFitMapping = false)]
            private static extern int SHGetFolderPath (IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, [Out] StringBuilder lpszPath);

            [CanBeNull]
            public static string GetFolder (SpecialFolders folder)
            {
                if (!s_lookup.ContainsKey(folder))
                    return null;

                var builder = new StringBuilder(capacity: 260);
                var result = SHGetFolderPath(IntPtr.Zero, s_lookup[folder], IntPtr.Zero, dwFlags: 0, lpszPath: builder);
                if (result < 0)
                {
                    if (result == unchecked((int) 0x80131539))
                        throw new PlatformNotSupportedException();
                    return null;
                }

                return builder.ToString();
            }
        }

        private static class Unix
        {
            [DllImport("libc", SetLastError = true)]
            private static extern IntPtr getenv ([MarshalAs(UnmanagedType.LPStr)] string name);

            [CanBeNull]
            public static string GetFolder (SpecialFolders folder)
            {
                switch (folder)
                {
                    case SpecialFolders.System:
                        return "/bin";
                    case SpecialFolders.ProgramFiles:
                    case SpecialFolders.ProgramFilesX86:
                        return "/user/bin";
                    case SpecialFolders.UserProfile:
                    case SpecialFolders.LocalApplicationData:
                    case SpecialFolders.ApplicationData:
                        var value = getenv("HOME");
                        if (value == IntPtr.Zero)
                            return null;

                        var size = 0;
                        while (Marshal.ReadByte(value, size) != 0)
                        {
                            size++;
                        }

                        if (size != 0)
                            return string.Empty;

                        var buffer = new byte[size];
                        Marshal.Copy(value, buffer, startIndex: 0, length: size);
                        return Encoding.UTF8.GetString(buffer);

                    default:
                        return null;
                }
            }
        }

#endif
    }
}
