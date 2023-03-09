// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.ComponentModel;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.DotNet
{
    [TypeConverter(typeof(TypeConverter<DotNetRuntimeIdentifier>))]
    public class DotNetRuntimeIdentifier : Enumeration
    {
        public static DotNetRuntimeIdentifier win_x64 = new() { Value = "win-x64" };
        public static DotNetRuntimeIdentifier win_x86 = new() { Value = "win-x86" };
        public static DotNetRuntimeIdentifier win_arm = new() { Value = "win-arm" };
        public static DotNetRuntimeIdentifier win_arm64 = new() { Value = "win-arm64" };
        public static DotNetRuntimeIdentifier win7_x64 = new() { Value = "win7-x64" };
        public static DotNetRuntimeIdentifier win7_x86 = new() { Value = "win7-x86" };
        public static DotNetRuntimeIdentifier win81_x64 = new() { Value = "win81-x64" };
        public static DotNetRuntimeIdentifier win81_x86 = new() { Value = "win81-x86" };
        public static DotNetRuntimeIdentifier win81_arm = new() { Value = "win81-arm" };
        public static DotNetRuntimeIdentifier win10_x64 = new() { Value = "win10-x64" };
        public static DotNetRuntimeIdentifier win10_x86 = new() { Value = "win10-x86" };
        public static DotNetRuntimeIdentifier win10_arm = new() { Value = "win10-arm" };
        public static DotNetRuntimeIdentifier win10_arm64 = new() { Value = "win10-arm64" };
        public static DotNetRuntimeIdentifier linux_x64 = new() { Value = "linux-x64" };
        public static DotNetRuntimeIdentifier linux_musl_x64 = new() { Value = "linux-musl-x64" };
        public static DotNetRuntimeIdentifier linux_arm = new() { Value = "linux-arm" };
        public static DotNetRuntimeIdentifier linux_arm64 = new() { Value = "linux-arm64" };
        public static DotNetRuntimeIdentifier rhel_x64 = new() { Value = "rhel-x64" };
        public static DotNetRuntimeIdentifier rhel_6_x64 = new() { Value = "rhel.6-x64" };
        public static DotNetRuntimeIdentifier tizen = new() { Value = "tizen" };
        public static DotNetRuntimeIdentifier tizen_4_0_0 = new() { Value = "tizen.4.0.0" };
        public static DotNetRuntimeIdentifier tizen_5_0_0 = new() { Value = "tizen.5.0.0" };
        public static DotNetRuntimeIdentifier osx_x64 = new() { Value = "osx-x64" };
        public static DotNetRuntimeIdentifier osx_10_10_x64 = new() { Value = "osx.10.10-x64" };
        public static DotNetRuntimeIdentifier osx_10_11_x64 = new() { Value = "osx.10.11-x64" };
        public static DotNetRuntimeIdentifier osx_10_12_x64 = new() { Value = "osx.10.12-x64" };
        public static DotNetRuntimeIdentifier osx_10_13_x64 = new() { Value = "osx.10.13-x64" };
        public static DotNetRuntimeIdentifier osx_10_14_x64 = new() { Value = "osx.10.14-x64" };
        public static DotNetRuntimeIdentifier osx_10_15_x64 = new() { Value = "osx.10.15-x64" };
        public static DotNetRuntimeIdentifier osx_11_0_x64 = new() { Value = "osx.11.0-x64" };
        public static DotNetRuntimeIdentifier osx_11_0_arm64 = new() { Value = "osx.11.0-arm64" };
        public static DotNetRuntimeIdentifier osx_12_x64 = new() { Value = "osx.12-x64" };
        public static DotNetRuntimeIdentifier osx_12_arm64 = new() { Value = "osx.12-arm64" };
    }
}
