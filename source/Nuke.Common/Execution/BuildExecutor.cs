// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nuke.Common.BuildServers;
using Nuke.Common.IO;
using Nuke.Common.OutputSinks;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.Execution
{
    internal static class BuildExecutor
    {
        public const string DefaultTarget = "default";

        public static int Execute<T>(Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild
        {
            var executionList = default(IReadOnlyCollection<TargetDefinition>);
            var build = CreateBuildInstance(defaultTargetExpression);

            HandleCompletion(build);

            try
            {
                build.OnBuildCreated();
                
                Logger.OutputSink = build.OutputSink;
                Logger.LogLevel = NukeBuild.LogLevel;
                ToolPathResolver.NuGetPackagesConfigFile = build.NuGetPackagesConfigFile;

                Logger.Log($"NUKE Execution Engine {typeof(BuildExecutor).Assembly.GetInformationalText()}");
                Logger.Log(FigletTransform.GetText("NUKE"));

                ProcessManager.CheckPathEnvironmentVariable();
                InjectionService.InjectValues(build);
                HandleEarlyExits(build);

                executionList = TargetDefinitionLoader.GetExecutingTargets(build, NukeBuild.InvokedTargets, NukeBuild.SkippedTargets);
                RequirementService.ValidateRequirements(executionList, build);

                build.OnBuildInitialized();

                Execute(build, executionList);

                return 0;
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                return -1;
            }
            finally
            {
                if (Logger.OutputSink is SevereMessagesOutputSink outputSink)
                {
                    Logger.Log();
                    WriteWarningsAndErrors(outputSink);
                }

                if (executionList != null)
                {
                    Logger.Log();
                    WriteSummary(executionList);
                }

                build.OnBuildFinished();
            }
        }

        private static void HandleCompletion(NukeBuild build)
        {
            var completionItems = new SortedDictionary<string, string[]>();

            var targetNames = build.TargetDefinitions.Select(x => x.Name).OrderBy(x => x).ToList();
            completionItems[NukeBuild.InvokedTargetsParameterName] = targetNames.ToArray();
            completionItems[NukeBuild.SkippedTargetsParameterName] = targetNames.ToArray();

            string[] GetSubItems(Type type)
            {
                if (type.IsEnum)
                    return type.GetEnumNames();
                if (type.IsSubclassOf(typeof(Enumeration)))
                    return type.GetFields(ReflectionService.Static).Select(x => x.Name).ToArray();
                return null;
            }

            foreach (var parameter in build.GetParameterMembers())
            {
                var parameterName = ParameterService.Instance.GetParameterName(parameter);
                if (completionItems.ContainsKey(parameterName))
                    continue;

                completionItems[parameterName] = GetSubItems(parameter.GetFieldOrPropertyType())?.OrderBy(x => x).ToArray();
            }

            SerializationTasks.YamlSerializeToFile(completionItems, NukeBuild.CompletionFile);

            if (EnvironmentInfo.ParameterSwitch(NukeBuild.CompletionParameterName))
                Environment.Exit(exitCode: 0);
        }

        internal static void Execute(NukeBuild build, IEnumerable<TargetDefinition> executionList)
        {
            foreach (var target in executionList)
            {
                if (target.Factory == null)
                {
                    target.Status = ExecutionStatus.Absent;
                    build.OnTargetAbsent(target.Name);
                    continue;
                }

                if (target.Skip || target.DependencyBehavior == DependencyBehavior.Execute && target.Conditions.Any(x => !x()))
                {
                    target.Status = ExecutionStatus.Skipped;
                    build.OnTargetSkipped(target.Name);
                    continue;
                }

                using (Logger.Block(target.Name))
                {
                    build.OnTargetStart(target.Name);
                    var stopwatch = Stopwatch.StartNew();
                    
                    try
                    {
                        target.Actions.ForEach(x => x());
                        target.Status = ExecutionStatus.Executed;
                        build.OnTargetExecuted(target.Name);
                    }
                    catch
                    {
                        target.Status = ExecutionStatus.Failed;
                        build.OnTargetFailed(target.Name);
                        throw;
                    }
                    finally
                    {
                        target.Duration = stopwatch.Elapsed;
                    }
                }
            }
        }

        private static void HandleEarlyExits<T>(T build)
            where T : NukeBuild
        {
            if (NukeBuild.Help)
            {
                Logger.Log(HelpTextService.GetTargetsText(build));
                Logger.Log(HelpTextService.GetParametersText(build));
            }

            if (NukeBuild.Graph)
                GraphService.ShowGraph(build);

            if (NukeBuild.Help || NukeBuild.Graph)
                Environment.Exit(exitCode: 0);
        }

        private static T CreateBuildInstance<T>(Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild
        {
            var constructors = typeof(T).GetConstructors();
            ControlFlow.Assert(constructors.Length == 1 && constructors.Single().GetParameters().Length == 0,
                $"Type '{typeof(T).Name}' must declare a single parameterless constructor.");

            var build = Activator.CreateInstance<T>();
            build.TargetDefinitions = build.GetTargetDefinitions(defaultTargetExpression);

            return build;
        }
        
        private static void WriteSummary(IReadOnlyCollection<TargetDefinition> executionList)
        {
            var firstColumn = Math.Max(executionList.Max(x => x.Name.Length) + 4, val2: 20);
            var secondColumn = 10;
            var thirdColumn = 10;
            var allColumns = firstColumn + secondColumn + thirdColumn;
            var totalDuration = executionList.Aggregate(TimeSpan.Zero, (t, x) => t.Add(x.Duration));

            string CreateLine(string target, string executionStatus, string duration)
                => target.PadRight(firstColumn, paddingChar: ' ')
                   + executionStatus.PadRight(secondColumn, paddingChar: ' ')
                   + duration.PadLeft(thirdColumn, paddingChar: ' ');

            string ToMinutesAndSeconds(TimeSpan duration)
                => $"{(int) duration.TotalMinutes}:{duration:ss}";

            Logger.Log(new string(c: '=', count: allColumns));
            Logger.Log(CreateLine("Target", "Status", "Duration"));
            Logger.Log(new string(c: '-', count: allColumns));
            foreach (var target in executionList)
            {
                var line = CreateLine(target.Name, target.Status.ToString(), ToMinutesAndSeconds(target.Duration));
                switch (target.Status)
                {
                    case ExecutionStatus.Absent:
                    case ExecutionStatus.Skipped:
                        Logger.Log(line);
                        break;
                    case ExecutionStatus.Executed:
                        Logger.Success(line);
                        break;
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
            if (executionList.All(x => x.Status != ExecutionStatus.Failed && x.Status != ExecutionStatus.NotRun))
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
