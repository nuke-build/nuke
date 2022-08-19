// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Serilog;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    public class InstallNpmToolsAttribute : BuildExtensionAttributeBase, IOnBuildInitialized
    {
        public void OnBuildInitialized(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets, IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            if (NukeBuild.BuildProjectFile == null)
                return;

            var packageJsonFile = NukeBuild.BuildProjectDirectory / "package.json";
            if (!packageJsonFile.FileExists())
                return;

            Log.Information("Installing npm tools...");
            var npmExecutable = ToolPathResolver.GetPathExecutable("npm");
            // Use NPM_CONFIG_PREFIX environment variable instead?
            ProcessTasks.StartProcess(npmExecutable, "install", workingDirectory: packageJsonFile.Parent, logInvocation: false, logOutput: false)
                .AssertZeroExitCode();
        }
    }
}
