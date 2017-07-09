// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
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
    }
}
