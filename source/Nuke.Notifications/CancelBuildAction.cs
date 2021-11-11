// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Nuke.Common;
using Nuke.Common.Tooling;

namespace Nuke.Notifications
{
    public static class CancelBuildAction
    {
        public static void Cancel()
        {
            switch (EnvironmentInfo.Platform)
            {
                case PlatformFamily.Windows:
                    GenerateConsoleCtrlEvent(ConsoleCtrlEvent.CTRL_C, Environment.ProcessId);
                    break;
                case PlatformFamily.Linux:
                case PlatformFamily.OSX:
                    ProcessTasks.StartShell($"kill -SIGINT {Environment.ProcessId}", logInvocation: false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [DllImport("kernel32.dll", SetLastError=true)]
        static extern bool GenerateConsoleCtrlEvent(ConsoleCtrlEvent sigevent, int dwProcessGroupId);

        private enum ConsoleCtrlEvent
        {
            CTRL_C = 0,
            CTRL_BREAK = 1,
            CTRL_CLOSE = 2,
            CTRL_LOGOFF = 5,
            CTRL_SHUTDOWN = 6
        }
    }
}
