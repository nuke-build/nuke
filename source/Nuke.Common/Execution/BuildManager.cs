// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nuke.Common.OutputSinks;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Execution
{
    internal static class BuildManager
    {
        private const int c_errorExitCode = -1;

        private static readonly LinkedList<Action> s_cancellationHandlers = new LinkedList<Action>();

        public static event Action CancellationHandler
        {
            add => s_cancellationHandlers.AddFirst(value);
            remove => s_cancellationHandlers.Remove(value);
        }

        public static int Execute<T>(Expression<Func<T, Target>>[] defaultTargetExpressions)
            where T : NukeBuild
        {
            Console.CancelKeyPress += (s, e) => s_cancellationHandlers.ForEach(x => x());

            var build = Create<T>();
            build.ExecutableTargets = ExecutableTargetFactory.CreateAll(build, defaultTargetExpressions);

            void ExecuteExtension<TExtension>(Action<TExtension> action)
                where TExtension : IBuildExtension
                => build.GetType().GetCustomAttributes()
                    .OfType<TExtension>().ForEach(action);

            try
            {
                InjectionUtility.InjectValues(build, x => x.IsFast);

                ExecuteExtension<IPreLogoBuildExtension>(x => x.PreLogo(build, build.ExecutableTargets));
                build.OnBuildCreated();

                Logger.OutputSink = build.OutputSink;
                Logger.LogLevel = NukeBuild.LogLevel;
                ToolPathResolver.NuGetPackagesConfigFile = build.NuGetPackagesConfigFile;

                if (!NukeBuild.NoLogo)
                {
                    Logger.Normal();
                    Logger.Normal("███╗   ██╗██╗   ██╗██╗  ██╗███████╗");
                    Logger.Normal("████╗  ██║██║   ██║██║ ██╔╝██╔════╝");
                    Logger.Normal("██╔██╗ ██║██║   ██║█████╔╝ █████╗  ");
                    Logger.Normal("██║╚██╗██║██║   ██║██╔═██╗ ██╔══╝  ");
                    Logger.Normal("██║ ╚████║╚██████╔╝██║  ██╗███████╗");
                    Logger.Normal("╚═╝  ╚═══╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝");
                    Logger.Normal();
                }

                Logger.Info($"NUKE Execution Engine {typeof(BuildManager).Assembly.GetInformationalText()}");
                Logger.Normal();

                build.ExecutionPlan = ExecutionPlanner.GetExecutionPlan(
                    build.ExecutableTargets,
                    ParameterService.Instance.GetParameter<string[]>(() => build.InvokedTargets) ??
                    ParameterService.Instance.GetPositionalCommandLineArguments<string>(separator: Constants.TargetsSeparator.Single()));

                ExecuteExtension<IPostLogoBuildExtension>(x => x.PostLogo(build, build.ExecutableTargets, build.ExecutionPlan));
                CancellationHandler += Finish;

                InjectionUtility.InjectValues(build, x => !x.IsFast);

                build.OnBuildInitialized();

                BuildExecutor.Execute(
                    build,
                    ParameterService.Instance.GetParameter<string[]>(() => build.SkippedTargets));

                return build.IsSuccessful ? 0 : c_errorExitCode;
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                return c_errorExitCode;
            }
            finally
            {
                if (build.ExecutionPlan != null)
                    Finish();
            }

            void Finish()
            {
                build.ExecutionPlan
                    .Where(x => x.Status == ExecutionStatus.Executing)
                    .ForEach(x => x.Status = ExecutionStatus.Aborted);

                if (Logger.OutputSink is SevereMessagesOutputSink outputSink)
                {
                    Logger.Normal();
                    WriteWarningsAndErrors(outputSink);
                }

                if (build.ExecutionPlan != null)
                {
                    Logger.Normal();
                    WriteSummary(build);
                }

                build.OnBuildFinished();
            }
        }

        public static T Create<T>()
            where T : NukeBuild
        {
            var constructors = typeof(T).GetConstructors();
            ControlFlow.Assert(constructors.Length == 1 && constructors.Single().GetParameters().Length == 0,
                $"Type '{typeof(T).Name}' must declare a single parameterless constructor.");

            return Activator.CreateInstance<T>();
        }

        private static void WriteSummary(NukeBuild build)
        {
            Logger.LogLevel = LogLevel.Trace;
            var firstColumn = Math.Max(build.ExecutionPlan.Max(x => x.Name.Length) + 4, val2: 19);
            var secondColumn = 10;
            var thirdColumn = 10;
            var allColumns = firstColumn + secondColumn + thirdColumn;
            var totalDuration = build.ExecutionPlan.Aggregate(TimeSpan.Zero, (t, x) => t.Add(x.Duration));

            string CreateLine(string target, string executionStatus, string duration, string appendix = null)
                => target.PadRight(firstColumn, paddingChar: ' ')
                   + executionStatus.PadRight(secondColumn, paddingChar: ' ')
                   + duration.PadLeft(thirdColumn, paddingChar: ' ')
                   + (appendix != null ? $"   // {appendix}" : string.Empty);

            string ToMinutesAndSeconds(TimeSpan duration)
                => $"{(int) duration.TotalMinutes}:{duration:ss}";

            Logger.Normal(new string(c: '═', count: allColumns));
            Logger.Info(CreateLine("Target", "Status", "Duration"));
            Logger.Normal(new string(c: '─', count: allColumns));
            foreach (var target in build.ExecutionPlan)
            {
                var line = CreateLine(target.Name, target.Status.ToString(), ToMinutesAndSeconds(target.Duration), target.SkipReason);
                switch (target.Status)
                {
                    case ExecutionStatus.Skipped:
                        Logger.Normal(line);
                        break;
                    case ExecutionStatus.Executed:
                        Logger.Success(line);
                        break;
                    case ExecutionStatus.Aborted:
                    case ExecutionStatus.NotRun:
                        Logger.Warn(line);
                        break;
                    case ExecutionStatus.Failed:
                        Logger.Error(line);
                        break;
                }
            }

            Logger.Normal(new string(c: '─', count: allColumns));
            Logger.Info(CreateLine("Total", "", ToMinutesAndSeconds(totalDuration)));
            Logger.Normal(new string(c: '═', count: allColumns));
            Logger.Normal();

            if (build.IsSuccessful)
                Logger.Success($"Build succeeded on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}.");
            else
                Logger.Error($"Build failed on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}.");
            Logger.Normal();
        }

        public static void WriteWarningsAndErrors(SevereMessagesOutputSink outputSink)
        {
            if (outputSink.SevereMessages.Count <= 0)
                return;

            Logger.Normal("Repeating warnings and errors:");

            foreach (var severeMessage in outputSink.SevereMessages.ToList())
            {
                switch (severeMessage.Item1)
                {
                    case LogLevel.Warning:
                        Logger.Warn(severeMessage.Item2);
                        break;
                    case LogLevel.Error:
                        Logger.Error(severeMessage.Item2);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
