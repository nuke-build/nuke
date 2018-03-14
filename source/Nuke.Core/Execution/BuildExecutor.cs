// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nuke.Core.OutputSinks;
using Nuke.Core.Utilities;

namespace Nuke.Core.Execution
{
    internal static class BuildExecutor
    {
        public const string DefaultTarget = "default";

        public static int Execute<T>(Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild
        {
            try
            {
                var executionList = Setup(defaultTargetExpression);
                return new ExecutionListRunner().Run(executionList);
            }
            catch (AggregateException exception)
            {
                foreach (var innerException in exception.Flatten().InnerExceptions)
                    OutputSink.Error(innerException.Message, innerException.StackTrace);
                return -exception.Message.GetHashCode();
            }
            catch (TargetInvocationException exception)
            {
                var innerException = exception.InnerException.NotNull();
                OutputSink.Error(innerException.Message, innerException.StackTrace);
                return -exception.Message.GetHashCode();
            }
            catch (Exception exception)
            {
                OutputSink.Error(exception.Message, exception.StackTrace);
                return -exception.Message.GetHashCode();
            }
        }

        private static IReadOnlyCollection<TargetDefinition> Setup<T>(Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild
        {
            PrintLogo();

            var build = CreateBuildInstance(defaultTargetExpression);

            HandleGraphAndHelp(build);

            var executionList = TargetDefinitionLoader.GetExecutingTargets(build);
            RequirementService.ValidateRequirements(executionList, build);

            return executionList;
        }

        private static void HandleGraphAndHelp<T>(T build)
            where T : NukeBuild
        {
            if (build.Help)
            {
                Logger.Log(HelpTextService.GetTargetsText(build));
                Logger.Log(HelpTextService.GetParametersText(build));
            }

            if (build.Graph)
                GraphService.ShowGraph(build);

            if (build.Help || build.Graph)
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
            NukeBuild.Instance = build;

            InjectionService.InjectValues(build);

            return build;
        }

        private static void PrintLogo()
        {
            Logger.Log(FigletTransform.GetText("NUKE"));
            Logger.Log(typeof(BuildExecutor).GetTypeInfo().Assembly.GetInformationText());
            Logger.Log();
        }
    }
}
