// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using Nuke.Common.Tooling;
using static Nuke.Common.IO.HttpTasks;
using static Nuke.Common.IO.FileSystemTasks;

namespace Nuke.Common.Tools.CloudFoundry
{
    public static partial class CloudFoundryTasks
    {
        public static string GetToolPath()
        {
            return ToolPathResolver.GetPackageExecutable(
                $"CloudFoundry.CommandLine.{CurrentOsRid}",
                IsWindows ? "cf.exe" : "cf");
        }

        private static bool IsWindows => Environment.OSVersion.Platform == PlatformID.Win32NT;

        private static string CurrentOsRid
        {
            get
            {
                switch (Environment.OSVersion.Platform)
                {
                    case PlatformID.Win32NT:
                        return Environment.Is64BitOperatingSystem ? "win-x64" : "win-x32";
                    case PlatformID.Unix:
                        return Environment.Is64BitOperatingSystem ? "linux-x64" : "linux-x32";
                    case PlatformID.MacOSX:
                        return "osx-x64";
                    default:
                        throw new PlatformNotSupportedException();
                }
            }
        }

        public static async Task CloudFoundryEnsureServiceReady(string serviceInstance)
        {
            bool IsCreating()
            {
                var commandResult = CloudFoundryGetServiceInfo(c => c
                        .SetServiceInstance(serviceInstance))
                    .First(x => x.Text.StartsWith("status:"))
                    .Text;
                var result = Regex.Match(commandResult, @"(?<=^status:\s+)[a-z].+", RegexOptions.Multiline).Value;
                return result == "create in progress";
            }

            while (IsCreating())
            {
                await Task.Delay(5000);
            }
        }
    }
}
