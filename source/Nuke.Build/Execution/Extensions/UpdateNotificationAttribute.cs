// Copyright 2023 Maintainers of NUKE.
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
    internal class UpdateNotificationAttribute : BuildExtensionAttributeBase, IOnBuildCreated, IOnBuildFinished
    {
        public void OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            if (Build.IsLocalBuild && ShouldNotify)
            {
                Notify();
                Host.Information("Press any key to continue without update ...");
                Console.ReadKey();
            }
        }

        public void OnBuildFinished()
        {
            if (Build.IsServerBuild && ShouldNotify)
                Notify();
        }

        private bool ShouldNotify => !Directory.Exists(GetNukeDirectory(Build.RootDirectory)) &&
                                     !Build.IsInterceptorExecution;

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
