using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nuke.Common.Execution.Orchestration.Parallel
{
    public class ParallelBuildOrchestrator : IBuildOrchestrator
    {
        public void PlanBuild(NukeBuild build)
        {
            build.ExecutionPlan = ParallelExecutionPlanner.GetParallelExecutionPlan(
                build.ExecutableTargets,
                EnvironmentInfo.GetParameter<string[]>(() => build.InvokedTargets));
        }

        public async Task RunBuild(NukeBuild build)
        {
            await ParallelBuildExecutor.Execute(build);
        }
    }
}
