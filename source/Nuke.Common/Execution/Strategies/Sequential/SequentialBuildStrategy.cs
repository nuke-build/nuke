using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nuke.Common.Execution.Strategies.Sequential
{
    public class SequentialBuildStrategy : IBuildStrategy
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
