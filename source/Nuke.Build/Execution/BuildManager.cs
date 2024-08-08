// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.DependencyModel;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Serilog;
#pragma warning disable CA2255

namespace Nuke.Common.Execution;

internal static class BuildManager
{
    private const int ErrorExitCode = -1;

    private static readonly LinkedList<Action> s_cancellationHandlers = new();

    public static event Action CancellationHandler
    {
        add => s_cancellationHandlers.AddFirst(value);
        remove => s_cancellationHandlers.Remove(value);
    }

    [ModuleInitializer]
    public static void Initialize()
    {
        DependencyContext.Default?.GetRuntimeAssemblyNames(string.Empty)
            .Where(x => x.FullName.StartsWith("Nuke."))
            .ForEach(x => AppDomain.CurrentDomain.Load(x));
    }

    /// <summary>
    /// Executes the specified build type with the specified default target expressions.
    /// </summary>
    /// <typeparam name="T">The build type</typeparam>
    /// <param name="defaultTargetExpressions">The default target expressions</param>
    /// <returns>Build exit code</returns>
    public static int Execute<T>(Expression<Func<T, Target>>[] defaultTargetExpressions)
        where T : NukeBuild, new()
    {
        return ExecuteWithOptions<T>(null, defaultTargetExpressions);
    }

    /// <summary>
    /// Executes the specified build type with the specified execute options and default target expressions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="executeOptions"></param>
    /// <param name="defaultTargetExpressions"></param>
    /// <returns>Build exit code</returns>
    public static int ExecuteWithOptions<T>(ExecuteOptions executeOptions, Expression<Func<T, Target>>[] defaultTargetExpressions)
        where T : NukeBuild, new()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        Console.CancelKeyPress += (_, _) => s_cancellationHandlers.ForEach(x => x());
        ToolSettings.Created += (settings, _) => VerbosityMapping.Apply(settings);

        var build = new T();

        try
        {
            // Should we execute the default log configuration?
            if (executeOptions?.DisableDefaultLogConfiguration != true)
                Logging.Configure(build);

            build.ExecutableTargets = ExecutableTargetFactory.CreateAll(build, defaultTargetExpressions);
            build.ExecuteExtension<IOnBuildCreated>(x => x.OnBuildCreated(build.ExecutableTargets));

            NuGetToolPathResolver.EmbeddedPackagesDirectory = build.EmbeddedPackagesDirectory;
            NuGetToolPathResolver.NuGetPackagesConfigFile = build.NuGetPackagesConfigFile;
            NuGetToolPathResolver.NuGetAssetsConfigFile = build.NuGetAssetsConfigFile;
            NpmToolPathResolver.NpmPackageJsonFile = build.NpmPackageJsonFile;

            if (!build.NoLogo)
                build.WriteLogo();

            build.ExecutionPlan = ExecutionPlanner.GetExecutionPlan(
                build.ExecutableTargets,
                ParameterService.GetParameter<string[]>(() => build.InvokedTargets));

            ToolRequirementService.EnsureToolRequirements(build, build.ExecutionPlan);
            build.ExecuteExtension<IOnBuildInitialized>(x => x.OnBuildInitialized(build.ExecutableTargets, build.ExecutionPlan));

            CancellationHandler += Finish;
            BuildExecutor.Execute(
                build,
                ParameterService.GetParameter<string[]>(() => build.SkippedTargets));

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

            // Should we close and flush the log?
            if (executeOptions?.DisableDefaultLogConfiguration != true)
                Log.CloseAndFlush();
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

            build.WriteErrorsAndWarnings();
            build.WriteTargetOutcome();
            build.WriteBuildOutcome();
            build.ExecuteExtension<IOnBuildFinished>(x => x.OnBuildFinished());
        }
    }
}
