// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tools.Unity
{
    public partial class UnityBaseSettings
    {
        public string GetToolPath()
        {
            return UnityTasks.GetToolPath();
        }

        public string GetLogFile()
        {
            return LogFile ?? NukeBuild.Instance.OutputDirectory / "unity.log";
        }
    }
}
