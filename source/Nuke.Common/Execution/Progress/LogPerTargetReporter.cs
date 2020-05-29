using Nuke.Common.Logging;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nuke.Common.Execution.Progress
{
    public class LogPerTargetReporter : IProgressReporter
    {
        public void Dispose()
        {
            LoggerProvider.AutoFlush = true;
        }

        public void WatchAndReport(NukeBuild build)
        {
            LoggerProvider.AutoFlush = false;

            build.ExecutionPlan.ExecutionItems.ForEach(x =>
            {
                x.ProgressChanged += ExecutionItem_ProgressChanged;
            });
        }

        private void ExecutionItem_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            var item = sender as ExecutionItem;

            if (e.UserState is ExecutableTarget target)
            {
                if (target.Status.IsCompleted())
                {
                    item.Logger.Flush();
                }
            }
        }
    }
}
