// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tools.Unity
{
    public partial class UnityBaseSettings
    {
        public override Action<OutputType, string> ProcessCustomLogger => UnityTasks.UnityLogger;

        public string GetProcessToolPath()
        {
            return UnityTasks.GetToolPath(HubVersion);
        }

        public string GetLogFile()
        {
            return (LogFile ?? NukeBuild.RootDirectory / "unity.log").DoubleQuoteIfNeeded();
        }
    }
}
