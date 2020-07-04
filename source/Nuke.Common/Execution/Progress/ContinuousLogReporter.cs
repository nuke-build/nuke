using Nuke.Common.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nuke.Common.Execution.Progress
{
    public class ContinuousLogReporter : IProgressReporter
    {
        public void Dispose()
        {
        }

        public void WatchAndReport(NukeBuild build)
        {
            LoggerProvider.AutoFlush = true;
        }
    }
}
