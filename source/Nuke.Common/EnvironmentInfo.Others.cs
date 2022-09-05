// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.Common
{
    public static partial class EnvironmentInfo
    {
        public static string NewLine => Environment.NewLine;
        public static string MachineName => Environment.MachineName;

        public static AbsolutePath WorkingDirectory
        {
#if NETCORE
            get => Directory.GetCurrentDirectory();
            set => Directory.SetCurrentDirectory(value);
#else
            get => Environment.CurrentDirectory;
            set => Environment.CurrentDirectory = value;
#endif
        }

        public static IDisposable SwitchWorkingDirectory(string workingDirectory, bool allowCreate = true)
        {
            if (allowCreate)
                FileSystemTasks.EnsureExistingDirectory(workingDirectory);

            var previousWorkingDirectory = WorkingDirectory;
            return DelegateDisposable.CreateBracket(
                () => WorkingDirectory = workingDirectory,
                () => WorkingDirectory = previousWorkingDirectory);
        }
    }
}
