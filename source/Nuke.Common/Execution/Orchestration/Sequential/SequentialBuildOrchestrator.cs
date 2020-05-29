using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nuke.Common.Execution.Orchestration.Sequential
{
    public class SequentialBuildOrchestrator : IBuildOrchestrator
    {
        public void PlanBuild(NukeBuild build)
        {
            build.ExecutionPlan = SequentialExecutionPlanner.GetExecutionPlan(
                    build.ExecutableTargets,
                    EnvironmentInfo.GetParameter<string[]>(() => build.InvokedTargets));
        }

        public Task RunBuild(NukeBuild build)
        {
            SequentialBuildExecutor.Execute(build);

            return Task.CompletedTask;
        }
    }
}
