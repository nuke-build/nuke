// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using Nuke.Common.Logging;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using ShellProgressBar;

namespace Nuke.Common.Execution
{
    public class ExecutionItem : IDisposable
    {
        public List<ExecutionItem> Dependencies { get; set; }

        public Stack<ExecutableTarget> Targets { get; set; } = new Stack<ExecutableTarget>();

        public bool IsInvoked => Targets.Any(x => x.Invoked);

        public ILogger Logger { get; set; }

        private SemaphoreSlim WorkerSemaphore { get; } = new SemaphoreSlim(1);

        public bool IsCompleted { get; private set; }

        public event ProgressChangedEventHandler ProgressChanged;

        public void StartWatchProgress()
        {
            Targets.ForEach(x =>
            {
                x.StatusChanged += (sender, e) => UpdateProgress(sender as ExecutableTarget);
            });
        }

        private void UpdateProgress(ExecutableTarget target)
        {
            var progress = Targets.Count(x => x.Status.IsCompleted()) / (double)Targets.Count * 100;
            ProgressChanged?.Invoke(this, new ProgressChangedEventArgs((int)progress, target));
        }

        public void WorkFinished()
        {
            ProgressChanged?.Invoke(this, new ProgressChangedEventArgs(100, null));
            IsCompleted = true;
        }

        public IDisposable EnsureSinglethreadedExecution(CancellationToken cancellationToken)
        {
            return DelegateDisposable.CreateBracket(
                () => WorkerSemaphore.Wait(cancellationToken),
                () => WorkerSemaphore.Release()
                );
        }

        public void Dispose()
        {
            WorkerSemaphore.Dispose();
        }

        public override string ToString()
        {
            return string.Join(", ", Targets.Select(x => x.Name));
        }
    }
}
