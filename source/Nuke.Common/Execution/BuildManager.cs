// Copyright 2021 Maintainers of NUKE.
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
using Serilog;

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
            Console.CancelKeyPress += (_, _) => s_cancellationHandlers.ForEach(x => x());

            var build = Create<T>();

            try
            {
                Logging.Configure(build);

                build.ExecutableTargets = ExecutableTargetFactory.CreateAll(build, defaultTargetExpressions);
                build.ExecuteExtension<IOnBuildCreated>(x => x.OnBuildCreated(build, build.ExecutableTargets));

                ToolPathResolver.EmbeddedPackagesDirectory = build.EmbeddedPackagesDirectory;
                ToolPathResolver.NuGetPackagesConfigFile = build.NuGetPackagesConfigFile;
                ToolPathResolver.NuGetAssetsConfigFile = build.NuGetAssetsConfigFile;

                if (!build.NoLogo)
                    build.WriteLogo();

                build.ExecutionPlan = ExecutionPlanner.GetExecutionPlan(
                    build.ExecutableTargets,
                    EnvironmentInfo.GetParameter<string[]>(() => build.InvokedTargets));

                build.ExecuteExtension<IOnBuildInitialized>(x => x.OnBuildInitialized(build, build.ExecutableTargets, build.ExecutionPlan));

                CancellationHandler += Finish;
                BuildExecutor.Execute(
                    build,
                    EnvironmentInfo.GetParameter<string[]>(() => build.SkippedTargets));

                return build.ExitCode ??= build.IsSuccessful ? 0 : ErrorExitCode;
            }
            catch (Exception exception)
            {
                exception = exception.Unwrap();
                if (exception is not TargetExecutionException)
                {
                    Log.Verbose(exception, "Target-unrelated exception was thrown");
                    Host.Error(exception.Message);
                }

                return build.ExitCode ??= ErrorExitCode;
            }
            finally
            {
                Finish();
            }

            void Finish()
            {
                if (build.ExecutionPlan == null)
                    return;

                foreach (var target in build.ExecutionPlan)
                {
                    target.Stopwatch.Stop();
                    target.Status = target.Status switch
                    {
                        ExecutionStatus.Running => ExecutionStatus.Aborted,
                        ExecutionStatus.Scheduled => ExecutionStatus.NotRun,
                        _ => target.Status
                    };
                }

                build.WriteSummary();
                build.ExecuteExtension<IOnBuildFinished>(x => x.OnBuildFinished(build));
            }
        }

        public static T Create<T>()
            where T : NukeBuild
        {
            var constructors = typeof(T).GetConstructors();
            Assert.True(constructors.Length == 1 && constructors.Single().GetParameters().Length == 0,
                $"Type '{typeof(T).Name}' must declare a single parameterless constructor");

            return Activator.CreateInstance<T>();
        }
    }
}
