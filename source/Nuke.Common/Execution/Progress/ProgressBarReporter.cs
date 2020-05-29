using Nuke.Common.Logging;
using Nuke.Common.Utilities.Collections;
using ShellProgressBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;

namespace Nuke.Common.Execution.Progress
{
    public class ProgressBarExecutionItem : IDisposable
    {
        public ExecutionItem Item { get; set; }

        public ChildProgressBar ProgressBar { get; set; }

        private Timer Timer { get; }

        public ChildProgressBar CurrentMessageTarget { get; set; }

        public string CurrentTarget { get; set; }

        public Dictionary<ExecutableTarget, ChildProgressBar> TargetProgressBars { get; set; }
            = new Dictionary<ExecutableTarget, ChildProgressBar>();

        public ProgressBarExecutionItem()
        {
            Timer = new Timer();
            Timer.Elapsed += Timer_Elapsed;
            Timer.Interval = 200;
        }

        public void Start()
        {
            Timer.Start();
        }

        public void Stop()
        {
            Timer.Stop();
            Timer_Elapsed(null, null);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CurrentMessageTarget.Message = $"{CurrentTarget}: {Item.Logger.PeekLastMessage()}";
        }

        public void Dispose()
        {
            Timer.Stop();
            Timer.Dispose();
            ProgressBar.Dispose();
            TargetProgressBars?.Values.ForEach(x => x.Dispose());
        }
    }

    public class ProgressBarReporter : IProgressReporter
    {
        private ProgressBar ProgressBar;
        private Dictionary<ExecutionItem, ProgressBarExecutionItem> ChildProgressBars = new Dictionary<ExecutionItem, ProgressBarExecutionItem>();
        private IEnumerable<ExecutionItem> AllExecutionItems;
        private ConsoleColor PreviousColor;

        private ProgressBarOptions MainOptions = new ProgressBarOptions
        {
            BackgroundColor = ConsoleColor.DarkGray,
            EnableTaskBarProgress = RuntimeInformation.IsOSPlatform(OSPlatform.Windows),
        };

        private ProgressBarOptions ItemOptions = new ProgressBarOptions
        {
            ForegroundColor = ConsoleColor.Cyan,
            ForegroundColorDone = ConsoleColor.DarkGreen,
            ProgressCharacter = '─',
            BackgroundColor = ConsoleColor.DarkGray
        };

        private ProgressBarOptions TargetOptions = new ProgressBarOptions
        {
            ForegroundColor = ConsoleColor.Yellow,
            ForegroundColorDone = ConsoleColor.DarkYellow,
            ProgressCharacter = '─',
            BackgroundColor = ConsoleColor.DarkGray
        };

        public void WatchAndReport(NukeBuild build)
        {
            PreviousColor = Console.ForegroundColor;

            LoggerProvider.AutoFlush = false;
            AllExecutionItems = build.ExecutionPlan.ExecutionItems;

            InitializeMainProgressBar(build);
            build.ExecutionPlan.ExecutionItems.ForEach(x =>
            {
                x.ProgressChanged += ExecutionItem_ProgressChanged;
            });
        }

        private void ExecutionItem_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            var item = sender as ExecutionItem;
            var target = e.UserState as ExecutableTarget;

            if (!ChildProgressBars.TryGetValue(item, out var progressItem))
            {
                var childBar = ProgressBar.Spawn(100, item.ToString(), ItemOptions);
                progressItem = new ProgressBarExecutionItem
                {
                    Item = item,
                    ProgressBar = childBar,
                    CurrentMessageTarget = childBar,
                    CurrentTarget = item.ToString()
                };
                progressItem.Start();
                ChildProgressBars.Add(item, progressItem);
            }

            if (item.Targets.Count > 1 && target != null)
            {
                if (!progressItem.TargetProgressBars.TryGetValue(target, out var targetProgressBar))
                {
                    progressItem.CurrentTarget = target.Name;

                    targetProgressBar = progressItem.ProgressBar.Spawn(100, target.Name, TargetOptions);
                    progressItem.CurrentMessageTarget = targetProgressBar;
                    progressItem.TargetProgressBars.Add(target, targetProgressBar);
                }

                if (target.Status == ExecutionStatus.Failed)
                    targetProgressBar.ForegroundColor = ConsoleColor.Red;
                else
                    targetProgressBar.Tick(target.Status.IsCompleted() ? 100 : 50);
            }

            if (target?.Status == ExecutionStatus.Failed)
            {
                progressItem.ProgressBar.ForegroundColor = ConsoleColor.Red;
                ProgressBar.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                progressItem.ProgressBar.Tick(e.ProgressPercentage);
                ProgressBar.Tick(ChildProgressBars.Values.Sum(x => x.Item.Targets.Count(y => y.Status.IsCompleted())));

                if (e.ProgressPercentage == 100)
                {
                    progressItem.Stop();
                }
            }
        }

        private void InitializeMainProgressBar(NukeBuild build)
        {
            // Write newline, looks nicer to have an empty line before any input.
            Console.WriteLine();

            var totalSteps = build.ExecutionPlan.ExecutionItems.Sum(x => x.Targets.Count);
            ProgressBar = new ProgressBar(totalSteps, "Progress", MainOptions);
        }

        public void Dispose()
        {
            ProgressBar.Dispose();
            ChildProgressBars.Values.ForEach(x => x.Dispose());

            AllExecutionItems.ForEach(x => x.Logger?.Flush());

            Console.ForegroundColor = PreviousColor;
        }
    }
}
