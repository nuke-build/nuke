using Nuke.Common.Logging;
using Nuke.Common.Utilities;
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
            CurrentMessageTarget.EstimatedDuration = default;
            Timer_Elapsed(null, null);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CurrentMessageTarget.Message = $"{CurrentTarget}: {Item.Logger.PeekLastMessage()}";

            if (CurrentMessageTarget.EstimatedDuration != default)
            {
                var endTime = CurrentMessageTarget.StartDate + CurrentMessageTarget.EstimatedDuration;
                var diff = endTime - DateTime.Now;
                var ticks = 100 - (diff.TotalMilliseconds / CurrentMessageTarget.EstimatedDuration.TotalMilliseconds * 100);
                CurrentMessageTarget.Tick((int)Math.Min(ticks, 98));
            }
        }

        public void Dispose()
        {
            Timer.Stop();
            Timer.Dispose();
            ProgressBar?.Dispose();
            TargetProgressBars?.Values.ForEach(x => x?.Dispose());
        }
    }

    public class ProgressBarReporter : IProgressReporter
    {
        private ProgressBar ProgressBar;
        private Dictionary<ExecutionItem, ProgressBarExecutionItem> ChildProgressBars = new Dictionary<ExecutionItem, ProgressBarExecutionItem>();
        private IEnumerable<ExecutionItem> AllExecutionItems;
        private ConsoleColor PreviousColor;
        private Timer UpdateTimer;

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

        public ProgressBarReporter()
        {
            UpdateTimer = new Timer(600);
            UpdateTimer.Elapsed += UpdateTimer_Elapsed;
        }

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

            UpdateTimer.Start();
        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var progressItem in ChildProgressBars.Values.Where(x => x.CurrentMessageTarget.EndTime == null))
            {
                var intermediateTicks = Math.Min(progressItem.CurrentMessageTarget.CurrentTick, 100) / 100d * (100d / progressItem.Item.Targets.Count);
                progressItem.ProgressBar.Tick(progressItem.Item.Progress + (int)intermediateTicks);
            }

            ProgressBar.Tick(ChildProgressBars.Values.Sum(x => x.ProgressBar.CurrentTick));
        }

        private ChildProgressBar Spawn(ProgressBarBase parent, string targetName, ProgressBarOptions options)
        {
            var estimatedTime = BuildTimeEstimator.GetEstimateForTarget(targetName);

            var bar = parent.Spawn(100, targetName, options);
            bar.EstimatedDuration = estimatedTime.GetValueOrDefault();

            if (!estimatedTime.HasValue)
                bar.Tick(50);

            return bar;
        }

        // TODO: pretty "hacky" hard-to-understand code. should be rethought and refactored sometime.
        private void ExecutionItem_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            var item = sender as ExecutionItem;
            var target = e.UserState as ExecutableTarget;

            if (!ChildProgressBars.TryGetValue(item, out var progressItem))
            {
                var childBar = Spawn(ProgressBar, item.ToString(), ItemOptions);
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

            // PER TARGET BARS
            if (item.Targets.Count > 1 && target != null)
            {
                progressItem.TargetProgressBars
                    .Where(x => x.Key.Status.IsSuccessful())
                    .ForEach(x => x.Value.Tick(100));

                if (!progressItem.TargetProgressBars.TryGetValue(target, out var targetProgressBar))
                {
                    progressItem.CurrentTarget = target.Name;
                    targetProgressBar = Spawn(progressItem.ProgressBar, target.Name, TargetOptions);

                    progressItem.CurrentMessageTarget = targetProgressBar;
                    progressItem.TargetProgressBars.Add(target, targetProgressBar);
                }

                if (target.Status == ExecutionStatus.Failed)
                    targetProgressBar.ForegroundColor = ConsoleColor.Red;
                else if (target.Status.IsSuccessful())
                    targetProgressBar.Tick(100);
            }

            if (target?.Status == ExecutionStatus.Failed)
            {
                progressItem.Stop();

                progressItem.ProgressBar.ForegroundColor = ConsoleColor.Red;
                ProgressBar.ForegroundColor = ConsoleColor.Red;
                ProgressBar.Tick(ProgressBar.CurrentTick);

                if (progressItem.TargetProgressBars.TryGetValue(target, out var targetProgressBar))
                    progressItem.TargetProgressBars.Remove(target);
            }
            else
            {
                progressItem.ProgressBar.Tick(e.ProgressPercentage);

                if (e.ProgressPercentage == 100)
                {
                    progressItem.Stop();
                    progressItem.TargetProgressBars.Values.ForEach(x => x.Tick(100));
                }
            }
        }

        private void InitializeMainProgressBar(NukeBuild build)
        {
            // Write newline, looks nicer to have an empty line before any input.
            Console.WriteLine();

            var totalSteps = build.ExecutionPlan.ExecutionItems.Count * 100;
            ProgressBar = new ProgressBar(totalSteps, "Progress", MainOptions);
        }

        public void Dispose()
        {
            UpdateTimer.Stop();
            UpdateTimer.Dispose();

            ProgressBar.Dispose();
            ChildProgressBars.Values.ForEach(x => x.Dispose());

            AllExecutionItems.ForEach(x => x.Logger?.Flush());

            Console.ForegroundColor = PreviousColor;
        }
    }
}
