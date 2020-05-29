using System;

namespace Nuke.Common.Execution.Progress
{
    public interface IProgressReporter : IDisposable
    {
        void WatchAndReport(NukeBuild build);
    }
}
