﻿// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
                where TExtension : IBuildExtension =>
                build.GetType()
                    .GetCustomAttributes()
                    .OfType<TExtension>()
                    .OrderBy(x => x.GetType() == typeof(HandleHelpRequestsAttribute))
                    .ForEach(action);

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

                build.ExecutionPlan = ExecutionPlanner.GetExecutionPlan(
                    build.ExecutableTargets,
                    EnvironmentInfo.GetParameter<string[]>(() => build.InvokedTargets));

                ExecuteExtension<IOnAfterLogo>(x => x.OnAfterLogo(build, build.ExecutableTargets, build.ExecutionPlan));
                CancellationHandler += Finish;

                InjectionUtility.InjectValues(build, x => !x.IsFast);

                build.OnBuildInitialized();

                BuildExecutor.Execute(
                    build,
                    EnvironmentInfo.GetParameter<string[]>(() => build.SkippedTargets));

                return build.IsSuccessful ? 0 : c_errorExitCode;
            }
            catch (Exception exception)
            {
                if (!(exception is TargetExecutionException))
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

                Logger.OutputSink.WriteSummary(build);

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
