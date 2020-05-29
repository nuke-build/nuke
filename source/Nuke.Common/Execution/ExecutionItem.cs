// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using Nuke.Common.Logging;
using Nuke.Common.Utilities.Collections;
using ShellProgressBar;

namespace Nuke.Common.Execution
{
    public class ExecutionItem : IDisposable
    {
        private readonly object _lockObject = new object();

        public List<ExecutionItem> Dependencies { get; set; }

        public Stack<ExecutableTarget> Targets { get; set; } = new Stack<ExecutableTarget>();

        public bool IsInvoked => Targets.Any(x => x.Invoked);

        public ILogger Logger { get; set; }

        private CountdownEvent CountdownEvent { get; set; } = new CountdownEvent(2);


        public event ProgressChangedEventHandler ProgressChanged;

        public bool WillExecuteWork()
        {
            lock (this)
            {
                var result = CountdownEvent.CurrentCount == CountdownEvent.InitialCount;
                if (result)
                    Signal();

                return result;
            }
        }

        public void StartWork()
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
            Log("Work Finished Begin");
            lock (this)
            {
                Signal();
            }
            Log("Work Finished End");
            ProgressChanged?.Invoke(this, new ProgressChangedEventArgs(100, null));
        }

        public void Join(CancellationToken cancellationToken)
        {
            Log("Wait Begin");
            CountdownEvent?.Wait(cancellationToken);
            Log("Wait End");
        }

        private void Signal()
        {
            if (CountdownEvent != null)
                Log($"Signal {CountdownEvent.CurrentCount} => {CountdownEvent.CurrentCount - 1}");
            CountdownEvent?.Signal();
        }

        public void Dispose()
        {
            CountdownEvent?.Dispose();
        }

        public void Log(string text)
        {
            //Console.WriteLine($"[{ToString()}]: {text}");
        }

        public override string ToString()
        {
            return string.Join(", ", Targets.Select(x => x.Name));
        }
    }
}
