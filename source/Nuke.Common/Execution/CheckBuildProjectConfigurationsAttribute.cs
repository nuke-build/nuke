// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nuke.Common.ProjectModel;
using Nuke.Common.Utilities.Collections;
using Serilog;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    public class CheckBuildProjectConfigurationsAttribute : BuildExtensionAttributeBase, IOnBuildInitialized
    {
        public int TimeoutInMilliseconds { get; set; } = 500;

        public void OnBuildInitialized(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            if (!Task.Run(CheckConfiguration).Wait(TimeoutInMilliseconds))
                Log.Warning("Could not complete checking build configurations within {Timeout} milliseconds", TimeoutInMilliseconds);

            static Task CheckConfiguration()
            {
                var rootDirectory = new DirectoryInfo(NukeBuild.RootDirectory);
                new[] { rootDirectory }
                    .Concat(rootDirectory.EnumerateDirectories("*", SearchOption.AllDirectories).Where(x => !x.Name.StartsWith(".")))
                    .SelectMany(x => x.GetFiles("*.sln", SearchOption.TopDirectoryOnly))
                    .Select(x => x.FullName)
                    .Select(ProjectModelTasks.ParseSolution)
                    .SelectMany(x => x.Projects)
                    .Where(x => x.Directory.Equals(NukeBuild.BuildProjectDirectory))
                    .Where(x => x.Configurations.Any(y => y.Key.Contains("Build")))
                    .ForEach(x => Log.Warning("Solution {Solution} has an active build configuration for {Project}", x.Solution, x));

                return Task.CompletedTask;
            }
        }
    }
}
