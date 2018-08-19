// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common;

namespace Nuke.NSwag
{
    public static partial class NSwagTasks
    {
        public static string GetToolPath ()
        {
            ControlFlow.Fail("Settings.NSwagRuntime must be defined to detect the proper nswag executable.");
            return null;
        }

        public enum Runtime
        {
            NetCore10,
            NetCore11,
            NetCore20,
            NetCore21,
            Win
        }
    }
}