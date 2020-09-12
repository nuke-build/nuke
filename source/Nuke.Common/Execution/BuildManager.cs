// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
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

        public static int Execute<T>(Expression<Func<T, Target>>[] defaultTargetExpressions)
            where T : NukeBuild
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.CancelKeyPress += (s, e) => s_cancellationHandlers.ForEach(x => x());

            var build = Create<T>();

            void ExecuteExtension<TExtension>(Expression<Action<TExtension>> action)
                where TExtension : IBuildExtension =>
                build.GetType()
                    .GetCustomAttributes()
                    .OfType<TExtension>()
                    .OrderByDescending(x => x.Priority)
                    .ForEachLazy(x =>
                        Logger.Trace($"[{action.GetMemberInfo().Name}] {x.GetType().Name.TrimEnd(nameof(Attribute))} ({x.Priority})"))
                    .ForEach(action.Compile());

            try
            {
                build.ExecutableTargets = ExecutableTargetFactory.CreateAll(build, defaultTargetExpressions);

                ExecuteExtension<IOnBeforeLogo>(x => x.OnBeforeLogo(build, build.ExecutableTargets));
                build.OnBuildCreated();

                Logger.OutputSink = NukeBuild.Host.OutputSink;

                ToolPathResolver.EmbeddedPackagesDirectory = NukeBuild.BuildProjectFile == null
                    ? Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                    : null;
                ToolPathResolver.NuGetPackagesConfigFile = build.NuGetPackagesConfigFile;
                ToolPathResolver.NuGetAssetsConfigFile = build.NuGetAssetsConfigFile;

                if (!build.NoLogo)
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
                build.OnBuildInitialized();

                CancellationHandler += Finish;
                BuildExecutor.Execute(
                    build,
                    EnvironmentInfo.GetParameter<string[]>(() => build.SkippedTargets));

                return build.ExitCode ?? (build.IsSuccessful ? 0 : ErrorExitCode);
            }
            catch (Exception exception)
            {
                if (!(exception is TargetExecutionException))
                    Logger.Error(exception);

                return build.ExitCode ?? ErrorExitCode;
            }
            finally
            {
                if (build.ExecutionPlan?.Any(x => x.Status != ExecutionStatus.NotRun) ?? false)
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
