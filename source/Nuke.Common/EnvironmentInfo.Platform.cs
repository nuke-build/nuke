// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Nuke.Common
{
    public enum PlatformFamily
    {
        Unknown,
        Windows,
        Linux,
        OSX
    }

    public static partial class EnvironmentInfo
    {
        /// <summary>
        /// Returns whether the operating system is x64 or not.
        /// </summary>
        public static bool Is64Bit
#if NETCORE
            => RuntimeInformation.OSArchitecture == Architecture.X64 || RuntimeInformation.OSArchitecture == Architecture.Arm64;
#else
            => Environment.Is64BitOperatingSystem;
#endif

        /// <summary>
        /// Returns whether the operating system is x86 or not.
        /// </summary>
        public static bool Is32Bit => !Is64Bit;

        /// <summary>
        /// Returns whether the operating system is a UNIX system.
        /// </summary>
        public static bool IsUnix => Platform == PlatformFamily.Linux || Platform == PlatformFamily.OSX;

        /// <summary>
        /// Returns whether the operating system is a Windows system.
        /// </summary>
        public static bool IsWin => !IsUnix;

        /// <summary>
        /// Returns whether the operating system is a Linux system.
        /// </summary>
        public static bool IsLinux => Platform == PlatformFamily.Linux;

        /// <summary>
        /// Returns whether the operating system is a OSX system.
        /// </summary>
        public static bool IsOsx => Platform == PlatformFamily.OSX;

        /// <summary>
        /// Returns the framework the build is running on.
        /// </summary>
        public static FrameworkName Framework
#if NETCORE
            => new FrameworkName(".NETStandard,Version=v2.0");
#else
            => new FrameworkName(".NETFramework,Version=v4.6.1");
#endif

        /// <summary>
        /// Returns the platform the build is running on.
        /// </summary>
        public static PlatformFamily Platform
        {
            // ReSharper disable once CyclomaticComplexity
            get
            {
#if NETCORE
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    return PlatformFamily.OSX;

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    return PlatformFamily.Linux;

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    return PlatformFamily.Windows;
#else
                var platform = (int) Environment.OSVersion.Platform;

                if (platform <= 3 || platform == 5)
                    return PlatformFamily.Windows;

                if (platform == (int) PlatformID.MacOSX || MacOSX.IsRunningOnMac())
                    return PlatformFamily.OSX;

                if (platform == 4 || platform == 6 || platform == 128)
                    return PlatformFamily.Linux;
#endif

                return PlatformFamily.Unknown;
            }
        }

#if !NETCORE
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        // This code was taken and adapted from the MonoDevelop project.
        // https://github.com/mono/monodevelop/blob/master/main/src/core/Mono.Texteditor/Mono.TextEditor/Platform.cs
        // Copyright (c) 2009 Novell, Inc. (http://www.novell.com)
        // Licensed under the MIT license. See LICENSE file in the project root for full license information.
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        private static class MacOSX
        {
            [DllImport("libc")]
            private static extern int uname(IntPtr buf);

            // ReSharper disable once CyclomaticComplexity
            public static bool IsRunningOnMac()
            {
                try
                {
                    var buf = IntPtr.Zero;
                    try
                    {
                        buf = Marshal.AllocHGlobal(cb: 8192);
                        if (uname(buf) == 0)
                        {
                            var os = Marshal.PtrToStringAnsi(buf);
                            if (os == "Darwin")
                                return true;
                        }
                    }
                    finally
                    {
                        if (buf != IntPtr.Zero)
                            Marshal.FreeHGlobal(buf);
                    }
                }
                catch
                {
                    // Ignore any other possible failures on non-OSX platforms
                }

                return false;
            }
        }
#endif
    }
}
