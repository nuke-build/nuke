// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.Execution
{
    public class Terminal : Host
    {
        public static bool IsRunningTerminal => true;
    }

    public class Rider : Terminal
    {
        internal static bool IsRunningRider
            => !Environment.GetEnvironmentVariable("IDEA_INITIAL_DIRECTORY").IsNullOrEmpty() ||
               (Environment.GetEnvironmentVariable("XPC_SERVICE_NAME")?.ContainsOrdinalIgnoreCase("com.jetbrains.rider") ?? false) ||
               (Environment.GetEnvironmentVariable("TERMINAL_EMULATOR")?.ContainsOrdinalIgnoreCase("JetBrains-JediTerm") ?? false);
    }

    public class VSCode : Terminal
    {
        internal static bool IsRunningVSCode
            => !Environment.GetEnvironmentVariable("VSCODE_GIT_IPC_HANDLE").IsNullOrEmpty() ||
               !Environment.GetEnvironmentVariable("VSCODE_PID").IsNullOrEmpty();
    }

    public class VisualStudio : Terminal
    {
        internal static bool IsRunningVisualStudio
            => !Environment.GetEnvironmentVariable("VisualStudioVersion").IsNullOrEmpty();
    }
}
