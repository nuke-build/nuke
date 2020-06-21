// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Nuke.Common.Execution.Orchestration;
using Nuke.Common.Execution.Orchestration.Parallel;
using Nuke.Common.Execution.Orchestration.Sequential;
using Nuke.Common.Execution.Progress;
using Nuke.Common.Logging;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Execution
{
    internal static class BuildManager
    {
        private const int ErrorExitCode = -1;

        private static readonly LinkedList<Action> s_cancellationHandlers = new LinkedList<Action>();

        public static event Action CancellationHandler
        {
            add => s_cancellationHandlers.AddFirst(value);
            remove => s_cancellationHandlers.Remove(value);
        }

        public static async Task<int> Execute<T>(Expression<Func<T, Target>>[] defaultTargetExpressions, bool parallelExecution)
            where T : NukeBuild
        {
            Console.CancelKeyPress += (s, e) => s_cancellationHandlers.ForEach(x => x());

            var build = Create<T>();
            build.ExecutableTargets = ExecutableTargetFactory.CreateAll(build, defaultTargetExpressions);

            void ExecuteExtension<TExtension>(Action<TExtension> action)
                where TExtension : IBuildExtension =>
                build.GetType()
                    .GetCustomAttributes()
                    .OfType<TExtension>()
                    .OrderBy(x => x.GetType() == typeof(HandleHelpRequestsAttribute))
                    .ForEach(action);

            var stopwatch = new System.Diagnostics.Stopwatch();

            try
            {
                InjectionUtility.InjectValues(build, x => x.IsFast);

                ExecuteExtension<IOnBeforeLogo>(x => x.OnBeforeLogo(build, build.ExecutableTargets));
                build.OnBuildCreated();

                Logger.OutputSink = build.OutputSink;
                Logger.LogLevel = NukeBuild.LogLevel;

                if (NukeBuild.BuildProjectDirectory != null)
                    ToolPathResolver.ExecutingAssemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                ToolPathResolver.NuGetPackagesConfigFile = build.NuGetPackagesConfigFile;
                ToolPathResolver.NuGetAssetsConfigFile = build.NuGetAssetsConfigFile;

                if (!NukeBuild.NoLogo)
                {
                    Logger.Normal();
                    Logger.OutputSink.WriteLogo();
                    Logger.Normal();
                }

                Logger.Info($"NUKE Execution Engine {typeof(BuildManager).Assembly.GetInformationalText()}");
                Logger.Normal();

                var buildOrchestrator = parallelExecution
                    ? (IBuildOrchestrator)new ParallelBuildOrchestrator()
                    : new SequentialBuildOrchestrator();

                buildOrchestrator.PlanBuild(build);

                RunConditionEvaluator.MarkSkippedTargets(build, EnvironmentInfo.GetParameter<string[]>(() => build.InvokedTargets));
                RequirementService.ValidateRequirements(build, build.ExecutingTargets.ToList());

                ExecuteExtension<IOnAfterLogo>(x => x.OnAfterLogo(build, build.ExecutableTargets, build.ExecutionPlan));
                CancellationHandler += Finish;

                InjectionUtility.InjectValues(build, x => !x.IsFast);

                build.OnBuildInitialized();

                // Remove main thread logger so that they are recreated and use current AutoFlush setting
                // (which might change depending on which progress reporter is used)
                LoggerProvider.RemoveCurrentLogger();

                using (var progressReporter = ProgressReporterFactory.Create(parallelExecution))
                {
                    progressReporter.WatchAndReport(build);
                    stopwatch.Start();
                    await buildOrchestrator.RunBuild(build);
                }

                return build.IsSuccessful ? 0 : ErrorExitCode;
            }
            catch (Exception exception)
            {
                if (!(exception is TargetExecutionException))
                    Logger.Error(exception);

                return ErrorExitCode;
            }
            finally
            {
                if (build.ExecutionPlan != null)
                    Finish();
            }

            void Finish()
            {
                stopwatch.Stop();

                build.ExecutionPlan.AllExecutionTargets
                    .Where(x => x.Status == ExecutionStatus.Executing)
                    .ForEach(x => x.Status = ExecutionStatus.Aborted);

                Logger.OutputSink.WriteSummary(build, stopwatch.Elapsed);

                build.OnBuildFinished();
                ExecuteExtension<IOnBuildFinished>(x => x.OnBuildFinished(build));
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
    }
}
