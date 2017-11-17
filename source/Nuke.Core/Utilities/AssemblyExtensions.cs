// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;

namespace Nuke.Core.Utilities
{
    public static class AssemblyExtensions
    {
        public static string GetInformationText (this Assembly assembly)
        {
            var fileVersion = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
            var informationalVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            return fileVersion != "1.0.0.0"
                ? $"Version: {fileVersion} [CommitSha: {informationalVersion.Substring(informationalVersion.LastIndexOf(value: '.') + 1, length: 8)}]"
                : "LOCAL VERSION";
        }
    }
}
