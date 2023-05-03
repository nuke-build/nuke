// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.IO;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tooling;

public static class ToolingExtensions
{
    public static AbsolutePath SetExecutable(this AbsolutePath path, bool updateVcsIndex = false)
    {
        if (updateVcsIndex)
        {
            if (path.Descendants(x => x.Parent).Any(x => x.ContainsDirectory(".git")))
                ProcessTasks.StartProcess("git", $"update-index --add --chmod=+x {path}", logInvocation: false, logOutput: false);
            else if (path.Descendants(x => x.Parent).Any(x => x.ContainsDirectory(".svn")))
                ProcessTasks.StartProcess("svn", $"propset svn:executable on {path}", logInvocation: false, logOutput: false);
        }

        if (EnvironmentInfo.IsUnix)
            ProcessTasks.StartProcess("chmod", $"+x {path}", logInvocation: false, logOutput: false);

        return path;
    }

    public static AbsolutePath SetUnixPermissions(this AbsolutePath path, string permissions)
    {
        if (EnvironmentInfo.IsUnix)
            ProcessTasks.StartProcess("chmod", $"{permissions} {path}", logInvocation: false, logOutput: false);

        return path;
    }

    public static AbsolutePath SetUnixPermissions(this AbsolutePath path, int permissions)
    {
        return path.SetUnixPermissions(permissions.ToString());
    }

    public static AbsolutePath Run(this AbsolutePath path, string prefix = null, Action<AbsolutePath> cleanup = null)
    {
        try
        {
            ProcessTasks.StartShell($"{prefix} {path}".Trim()).AssertZeroExitCode();
        }
        finally
        {
            cleanup?.Invoke(path);
        }

        return path;
    }

    /// <summary>
    /// Opens a file or directory with the associated application.
    /// </summary>
    public static void Open(this AbsolutePath path)
    {
        Assert.True(path.DirectoryExists() || path.FileExists());
        var verb = EnvironmentInfo.IsUnix ? "open" : path.DirectoryExists() ? "explorer.exe" : "call";
        ProcessTasks.StartShell($"{verb} {path}");
    }
}
