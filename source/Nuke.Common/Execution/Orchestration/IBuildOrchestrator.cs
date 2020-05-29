using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nuke.Common.Execution.Orchestration
{
    public interface IBuildOrchestrator
    {
        void PlanBuild(NukeBuild build);

        Task RunBuild(NukeBuild build);
    }
}
