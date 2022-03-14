// Copyright 2022 Maintainers of NUKE.
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

namespace Nuke.Common.Execution
{
    /// <summary>
    ///     Specifies that NUKE should verify that the build project itself is excluded from the build in the solution
    ///     and logs a warning if it is not.
    /// </summary>
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class)]
    public class CheckBuildProjectConfigurationsAttribute : Attribute, IOnAfterLogo
    {
        public int TimeoutInMilliseconds { get; set; } = 500;

        public void OnAfterLogo(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            ControlFlow.AssertWarn(
                Task.Run(CheckConfiguration).Wait(TimeoutInMilliseconds),
                $"Could not complete build consistency verification within {TimeoutInMilliseconds} milliseconds, consider increasing the timeout "
              + $"of the {nameof(CheckBuildProjectConfigurationsAttribute)} or remove the attribute to turn verification off.");

            Task CheckConfiguration()
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
                    .ForEach(x => Logger.Warn($"Solution {x.Solution} has an active build configuration for {x}."));

                return Task.CompletedTask;
            }
        }
    }
}
