// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Execution
{
    internal class EventInvoker : BuildExtensionAttributeBase,
        IOnBuildCreated,
        IOnBuildInitialized,
        IOnTargetRunning,
        IOnTargetSkipped,
        IOnTargetSucceeded,
        IOnTargetFailed,
        IOnBuildFinished
    {
        public void OnBuildCreated(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            build.OnBuildCreated();
        }

        public void OnBuildInitialized(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets, IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            build.OnBuildInitialized();
        }

        public void OnTargetRunning(NukeBuild build, ExecutableTarget target)
        {
            build.OnTargetRunning(target.Name);
        }

        public void OnTargetSkipped(NukeBuild build, ExecutableTarget target)
        {
            build.OnTargetSkipped(target.Name);
        }

        public void OnTargetSucceeded(NukeBuild build, ExecutableTarget target)
        {
            build.OnTargetSucceeded(target.Name);
        }

        public void OnTargetFailed(NukeBuild build, ExecutableTarget target)
        {
            build.OnTargetFailed(target.Name);
        }

        public void OnBuildFinished(NukeBuild build)
        {
            build.OnBuildFinished();
        }
    }
}
