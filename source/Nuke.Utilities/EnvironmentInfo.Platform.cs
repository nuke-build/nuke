// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Nuke.Common.Utilities;

namespace Nuke.Common
{
    public enum PlatformFamily
    {
        Unknown,
        Windows,
        Linux,
        OSX
    }

    partial class EnvironmentInfo
    {
        /// <summary>
        /// Indicates whether the operating-system is arm64.
        /// </summary>
        public static bool IsArm64 => RuntimeInformation.OSArchitecture == Architecture.Arm64;

        /// <summary>
        /// Indicates whether the operating-system is 64bit.
        /// </summary>
        public static bool Is64Bit => RuntimeInformation.OSArchitecture == Architecture.X64 ||
                                      RuntimeInformation.OSArchitecture == Architecture.Arm64;

        /// <summary>
        /// Indicates whether the operating-system is 32bit.
        /// </summary>
        public static bool Is32Bit => !Is64Bit;

        /// <summary>
        /// Indicates whether the operating-system is UNIX.
        /// </summary>
        public static bool IsUnix => Platform == PlatformFamily.Linux ||
                                     Platform == PlatformFamily.OSX;

        /// <summary>
        /// Indicates whether the operating-system is Windows.
        /// </summary>
        public static bool IsWin => !IsUnix;

        /// <summary>
        /// Indicates whether the operating-system is Linux.
        /// </summary>
        public static bool IsLinux => Platform == PlatformFamily.Linux;

        /// <summary>
        /// Indicates whether the operating-system is OSX.
        /// </summary>
        public static bool IsOsx => Platform == PlatformFamily.OSX;

        /// <summary>
        /// Indicates whether the current process is running under Windows Subsystem for Linux.
        /// </summary>
        public static bool IsWsl
        {
            get
            {
                if (!IsLinux)
                    return false;

                try
                {
                    var version = File.ReadAllText("/proc/version");
                    return version.ContainsOrdinalIgnoreCase("Microsoft");
                }
                catch (IOException)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Indicates the target framework of the current process.
        /// </summary>
        public static FrameworkName Framework
            => new(Assembly.GetEntryAssembly().NotNull().GetCustomAttribute<TargetFrameworkAttribute>().FrameworkName);

        /// <summary>
        /// Indicates the operating-system platform.
        /// </summary>
        public static PlatformFamily Platform
        {
            get
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    return PlatformFamily.OSX;

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    return PlatformFamily.Linux;

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    return PlatformFamily.Windows;

                return PlatformFamily.Unknown;
            }
        }
    }
}
