// ReSharper disable All
#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;

namespace Nuke.Core.Utilities
{
    public static class AssemblyExtensions
    {
        public static string GetInformationText(this Assembly assembly)
        {
            var fileVersion = assembly.GetAssemblyFileVersion();
            var informationalVersion = assembly.GetAssemblyInformationalVersion();
            return fileVersion != "1.0.0.0"
                ? $"Version: {fileVersion} [CommitSha: {informationalVersion.Substring(informationalVersion.LastIndexOf(value: '.') + 1, length: 8)}]"
                : "Version: LOCAL";
        }

        public static string GetAssemblyFileVersion(this Assembly assembly)
        {
            return assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
        }

        private static string GetAssemblyInformationalVersion(this Assembly assembly)
        {
            return assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }
    }
}
