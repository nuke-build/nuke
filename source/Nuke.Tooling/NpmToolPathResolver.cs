// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public static class NpmToolPathResolver
    {
        public static AbsolutePath NpmPackageJsonFile;

        public static string GetNpmExecutable(string npmExecutable)
        {
            Assert.FileExists(NpmPackageJsonFile);

            return ProcessTasks.StartProcess(
                    toolPath: ToolPathResolver.GetPathExecutable("npx"),
                    arguments: $"which {npmExecutable}",
                    workingDirectory: NpmPackageJsonFile.Parent / "node_modules",
                    logInvocation: false,
                    logOutput: false)
                .AssertZeroExitCode()
                .Output.StdToText();
        }
    }
}
