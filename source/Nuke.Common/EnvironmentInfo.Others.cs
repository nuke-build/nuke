// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Serilog;

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
