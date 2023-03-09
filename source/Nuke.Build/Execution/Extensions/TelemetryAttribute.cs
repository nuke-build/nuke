// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Execution
{
    internal class TelemetryAttribute : BuildExtensionAttributeBase, IOnBuildInitialized, IOnTargetSucceeded
    {
        public void OnBuildInitialized(
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            if (Build.IsInterceptorExecution)
                return;

            Telemetry.BuildStarted(Build);
        }

        public void OnTargetSucceeded(ExecutableTarget target)
        {
            if (Build.IsInterceptorExecution)
                return;

            Telemetry.TargetSucceeded(target, Build);
        }
    }
}
