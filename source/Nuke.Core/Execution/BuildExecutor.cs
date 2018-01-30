// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using Nuke.Core.OutputSinks;
using Nuke.Core.Utilities;

namespace Nuke.Core.Execution
{
    internal static class BuildExecutor
    {
        public static int Execute<T> (Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild
        {
            try
            {
                var executionList = Setup(defaultTargetExpression);
                return new ExecutionListRunner().Run(executionList);
            }
            catch (Exception exception)
            {
                OutputSink.Error(exception.Message, exception.StackTrace);
                return -exception.Message.GetHashCode();
            }
        }

        private static IReadOnlyCollection<TargetDefinition> Setup<T> (Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild
        {
            PrintLogo();

            var build = CreateBuildInstance<T>();

            InjectionService.InjectValues(build);
            OutputSink.Instance = OutputSink.GetOutputSink(build.Host);

            var defaultTargetFactory = defaultTargetExpression.Compile().Invoke(build);
            
            HandleGraphAndHelp(build, defaultTargetFactory);

            var executionList = TargetDefinitionLoader.GetExecutionList(build, defaultTargetFactory);
            RequirementService.ValidateRequirements(executionList, build);
            return executionList;
        }

        private static void HandleGraphAndHelp<T> (T build, Target defaultTargetFactory)
                where T : NukeBuild
        {
            if (build.Help == null)
                return;

            if (build.Help.Length == 0 || build.Help.Any(x => "targets".StartsWithOrdinalIgnoreCase(x)))
                Logger.Log(HelpTextService.GetTargetsText(build, defaultTargetFactory));

            if (build.Help.Length == 0 || build.Help.Any(x => "parameters".StartsWithOrdinalIgnoreCase(x)))
                Logger.Log(HelpTextService.GetParametersText(build, defaultTargetFactory));

            if (build.Graph)
                GraphService.ShowGraph(build, defaultTargetFactory);

            if (build.Help != null || build.Graph)
                Environment.Exit(exitCode: 0);
        }

        private static T CreateBuildInstance<T> ()
                where T : NukeBuild
        {
            var build = (T) FormatterServices.GetUninitializedObject(typeof(T));
            NukeBuild.Instance = build;

            var constructors = typeof(T).GetConstructors();
            ControlFlow.Assert(constructors.Length == 1 && constructors.Single().GetParameters().Length == 0,
                    $"Type '{typeof(T).Name}' must declare a single parameterless constructor.");
            constructors.Single().Invoke(build, new object[0]);

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
