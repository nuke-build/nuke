// Copyright 2023 Maintainers of NUKE.
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
        public void OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            ((NukeBuild)Build).OnBuildCreated();
        }

        public void OnBuildInitialized(
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            ((NukeBuild)Build).OnBuildInitialized();
        }

        public void OnTargetRunning(ExecutableTarget target)
        {
            ((NukeBuild)Build).OnTargetRunning(target.Name);
        }

        public void OnTargetSkipped(ExecutableTarget target)
        {
            ((NukeBuild)Build).OnTargetSkipped(target.Name);
        }

        public void OnTargetSucceeded(ExecutableTarget target)
        {
            ((NukeBuild)Build).OnTargetSucceeded(target.Name);
        }

        public void OnTargetFailed(ExecutableTarget target)
        {
            ((NukeBuild)Build).OnTargetFailed(target.Name);
        }

        public void OnBuildFinished()
        {
            ((NukeBuild)Build).OnBuildFinished();
        }
    }
}
