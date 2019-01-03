// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using Nuke.Common.OutputSinks;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Execution
{
    internal static class BuildManager
    {
        public static int Execute<T>(Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild
        {
            var build = Create<T>();
            NukeBuild.ExecutableTargets = ExecutableTargetFactory.CreateAll(build, defaultTargetExpression);
            
            try
            {
                build.Execute<IPreLogoBuildExtension>();
                build.OnBuildCreated();
                
                Logger.OutputSink = build.OutputSink;
                Logger.LogLevel = NukeBuild.LogLevel;
                ToolPathResolver.NuGetPackagesConfigFile = build.NuGetPackagesConfigFile;

                Logger.Log($"NUKE Execution Engine {typeof(BuildManager).Assembly.GetInformationalText()}");
                Logger.Log(FigletTransform.GetText("NUKE"));
                
                build.Execute<IPostLogoBuildExtension>();
                NukeBuild.ExecutionPlan = ExecutionPlanner.GetExecutionPlan(
                    NukeBuild.ExecutableTargets,
                    ParameterService.Instance.GetParameter(() => NukeBuild.InvokedTargets) ??
                    ParameterService.Instance.GetPositionalCommandLineArguments<string>(separator: Constants.TargetsSeparator.Single()));
                Console.CancelKeyPress += (s, e) => Finish();

                InjectionUtility.InjectValues(build);
                RequirementService.ValidateRequirements(NukeBuild.ExecutionPlan, build);
                
                build.OnBuildInitialized();
                
                BuildExecutor.Execute(
                    build,
                    NukeBuild.ExecutionPlan,
                    ParameterService.Instance.GetParameter(() => NukeBuild.SkippedTargets));
                
                return 0;
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                return -1;
            }
            finally
            {
                Finish();
            }
            
            void Finish()
            {
                NukeBuild.ExecutionPlan
                    .Where(x => x.Status == ExecutionStatus.Executing)
                    .ForEach(x => x.Status = ExecutionStatus.Aborted);
                
                if (Logger.OutputSink is SevereMessagesOutputSink outputSink)
                {
                    Logger.Log();
                    WriteWarningsAndErrors(outputSink);
                }

                if (NukeBuild.ExecutionPlan != null)
                {
                    Logger.Log();
                    WriteSummary(NukeBuild.ExecutionPlan);
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

        private static void WriteSummary(IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            var firstColumn = Math.Max(executionPlan.Max(x => x.Name.Length) + 4, val2: 20);
            var secondColumn = 10;
            var thirdColumn = 10;
            var allColumns = firstColumn + secondColumn + thirdColumn;
            var totalDuration = executionPlan.Aggregate(TimeSpan.Zero, (t, x) => t.Add(x.Duration));

            string CreateLine(string target, string executionStatus, string duration)
                => target.PadRight(firstColumn, paddingChar: ' ')
                   + executionStatus.PadRight(secondColumn, paddingChar: ' ')
                   + duration.PadLeft(thirdColumn, paddingChar: ' ');

            string ToMinutesAndSeconds(TimeSpan duration)
                => $"{(int) duration.TotalMinutes}:{duration:ss}";

            Logger.Log(new string(c: '=', count: allColumns));
            Logger.Log(CreateLine("Target", "Status", "Duration"));
            Logger.Log(new string(c: '-', count: allColumns));
            foreach (var target in executionPlan)
            {
                var line = CreateLine(target.Name, target.Status.ToString(), ToMinutesAndSeconds(target.Duration));
                switch (target.Status)
                {
                    case ExecutionStatus.Skipped:
                        Logger.Log(line);
                        break;
                    case ExecutionStatus.Executed:
                        Logger.Success(line);
                        break;
                    case ExecutionStatus.Aborted:
                    case ExecutionStatus.NotRun:
                    case ExecutionStatus.Failed:
                        Logger.Error(line);
                        break;
                }
            }

            Logger.Log(new string(c: '-', count: allColumns));
            Logger.Log(CreateLine("Total", "", ToMinutesAndSeconds(totalDuration)));
            Logger.Log(new string(c: '=', count: allColumns));
            Logger.Log();

            var buildSucceeded = executionPlan
                .All(x => x.Status != ExecutionStatus.Failed &&
                          x.Status != ExecutionStatus.NotRun &&
                          x.Status != ExecutionStatus.Aborted);
            if (buildSucceeded)
                Logger.Success($"Build succeeded on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}.");
            else
                Logger.Error($"Build failed on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}.");
            Logger.Log();
        }
        
        public static void WriteWarningsAndErrors(SevereMessagesOutputSink outputSink)
        {
            if (outputSink.SevereMessages.Count <= 0)
                return;

            Logger.Log("Repeating warnings and errors:");

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
