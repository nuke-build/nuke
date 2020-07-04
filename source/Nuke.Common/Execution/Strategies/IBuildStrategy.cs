using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nuke.Common.Execution.Strategies
{
    public interface IBuildStrategy
    {
        void PlanBuild(NukeBuild build);

        Task RunBuild(NukeBuild build);
    }
}
