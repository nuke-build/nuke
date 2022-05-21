// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuke.Common.Utilities;
using static Nuke.Common.Constants;

namespace Nuke.Common.Execution
{
    internal class UpdateNotificationAttribute : BuildExtensionAttributeBase,
        IOnBuildCreated,
        IOnBuildFinished
    {
        public void OnBuildCreated(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            if (NukeBuild.IsLocalAndEntryExecution && ShouldNotify)
            {
                Notify();
                Host.Information("Press any key to continue without update ...");
                Console.ReadKey();
            }
        }

        public void OnBuildFinished(NukeBuild build)
        {
            if (NukeBuild.IsServerBuild && ShouldNotify)
                Notify();
        }

        private bool ShouldNotify => !Directory.Exists(GetNukeDirectory(NukeBuild.RootDirectory));

        private static void Notify()
        {
            Host.Warning(
                new[]
                {
                    "--- UPDATE RECOMMENDED FROM 5.1.0 ---",
                    "1. Update your global tool",
                    "   dotnet tool update Nuke.GlobalTool -g",
                    "2. Update your build",
                    "   nuke :update",
                    "3. Confirm on update for configuration file and build scripts",
                    "   (Others are be optional)",
                    string.Empty
                }.JoinNewLine());
        }
    }
}
