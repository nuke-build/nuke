// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

#if NETCORE
using System.IO;
#endif

namespace Nuke.Core
{
    public static partial class EnvironmentInfo
    {
        public static string NewLine => Environment.NewLine;
        public static string MachineName => Environment.MachineName;

        public static string WorkingDirectory
#if NETCORE
            => Directory.GetCurrentDirectory();
#else
            => Environment.CurrentDirectory;
#endif

        public static IReadOnlyDictionary<string, string> Variables
        {
            get
            {
                var environmentVariables = Environment.GetEnvironmentVariables();
                return Environment.GetEnvironmentVariables().Keys.Cast<string>()
                    .ToDictionary(x => x, x => (string) environmentVariables[x], StringComparer.OrdinalIgnoreCase);
            }
        }
    }
}
