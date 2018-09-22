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
            // TODO SK
#pragma warning disable 618
            return LogFile ?? NukeBuild.Instance.OutputDirectory / "unity.log";
#pragma warning restore 618
        }
    }
}
