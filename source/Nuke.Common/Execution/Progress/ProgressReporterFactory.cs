using System;
using System.Collections.Generic;
using System.Text;

namespace Nuke.Common.Execution.Progress
{
    public static class ProgressReporterFactory
    {
        public static IProgressReporter Create(bool parallelExecution)
        {
            if (NukeBuild.Host == HostType.Console && !Console.IsOutputRedirected)
                return new ProgressBarReporter();

            return parallelExecution
                ? (IProgressReporter)new LogPerTargetReporter()
                : new ContinuousLogReporter();
        }
    }
}
