// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;

namespace Nuke.Common.Utilities
{
    public static class AssemblyExtensions
    {
        public static string GetVersionText(this Assembly assembly)
        {
            var informationalVersion = assembly.GetAssemblyInformationalVersion();
            var plusIndex = informationalVersion.IndexOf(value: '+');
            if (plusIndex == -1)
                return "Local";

            var version = informationalVersion.Substring(startIndex: 0, length: plusIndex);
            var dotLastIndex = informationalVersion.LastIndexOf(value: '.');
            var commitSha = informationalVersion.Substring(dotLastIndex + 1, length: 8);
            return $"{version} [CommitSha: {commitSha}]";
        }

        private static string GetAssemblyInformationalVersion(this Assembly assembly)
        {
            return assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }
    }
}
