// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Unity
{
    public partial class UnityBaseSettings
    {
        public override Action<OutputType, string> CustomLogger => UnityTasks.UnityLogger;

        public string GetToolPath()
        {
            return UnityTasks.GetToolPath(HubVersion);
        }

        public string GetLogFile()
        {
            // TODO SK
            return LogFile ?? NukeBuild.RootDirectory / "unity.log";
        }
    }
}
