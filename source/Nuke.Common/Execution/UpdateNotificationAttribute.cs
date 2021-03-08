// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.Execution
{
    internal class UpdateNotificationAttribute : BuildExtensionAttributeBase, IOnBuildCreated
    {
        public void OnBuildCreated(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            if (Directory.Exists(NukeBuild.RootDirectory / ".nuke"))
                return;

            Logger.Error(
                new[]
                {
                    "--- UPDATE REQUIRED FROM 5.1.0 ---",
                    string.Empty,
                    "1. Update your global tool",
                    "   dotnet tool update Nuke.GlobalTool -g",
                    "2. Update your build",
                    "   nuke :update",
                    "3. Confirm on \"Update configuration file\"",
                    "   (Others are be optional)"
                }.JoinNewLine());

            Environment.Exit(1);
        }
    }
}
