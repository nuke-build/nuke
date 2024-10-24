// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Serilog;
using Spectre.Console;

namespace Nuke.Common;

[EventInvoker(Priority = float.MinValue)]
public abstract partial class NukeBuild
{
    private IReadOnlyCollection<IBuildExtension> BuildExtensions { get; }
    IReadOnlyCollection<IBuildExtension> INukeBuild.BuildExtensions => BuildExtensions;

    protected NukeBuild()
    {
        BuildExtensions ??= GetType()
            .GetCustomAttributes<BuildExtensionAttributeBase>()
            .ForEachLazy(x => x.Build = this)
            .Cast<IBuildExtension>()
            .OrderByDescending(x => x.Priority).ToList();
    }

    internal void ExecuteExtension<TExtension>(Expression<Action<TExtension>> action)
        where TExtension : IBuildExtension
    {
        BuildExtensions
            .OfType<TExtension>()
            .ForEachLazy(x => Log.Verbose("{Type}.{Method} ({Priority})", x.GetType().Name.TrimEnd(nameof(Attribute)), action.GetMemberInfo().Name, x.Priority))
            .ForEach(action.Compile());
    }

    /// <summary>
    /// Method that is invoked after the instance of the build was created.
    /// </summary>
    protected internal virtual void OnBuildCreated()
    {
    }

    /// <summary>
    /// Method that is invoked after build instance is initialized. I.e., value injection and requirement validation has finished.
    /// </summary>
    protected internal virtual void OnBuildInitialized()
    {
    }

    /// <summary>
    /// Method that is invoked after the build has finished (succeeded or failed).
    /// </summary>
    protected internal virtual void OnBuildFinished()
    {
    }

    /// <summary>
    /// Method that is invoked before a target is about to start.
    /// </summary>
    protected internal virtual void OnTargetRunning(string target)
    {
    }

    /// <summary>
    /// Method that is invoked when a target is skipped.
    /// </summary>
    protected internal virtual void OnTargetSkipped(string target)
    {
    }

    /// <summary>
    /// Method that is invoked when a target has been executed successfully.
    /// </summary>
    protected internal virtual void OnTargetSucceeded(string target)
    {
    }

    /// <summary>
    /// Method that is invoked when a target has failed.
    /// </summary>
    protected internal virtual void OnTargetFailed(string target)
    {
    }

    /// <summary>
    /// Method that is invoked when the user did not specify any targets and.
    /// </summary>
    /// <returns>The list of fallback targets which should be executed or <see langword="null" /> if no automatic target selection should happen</returns>> 
    [CanBeNull]
    public virtual IReadOnlyCollection<ExecutableTarget> OnNoTargetsSpecified()
    {
        if (Help || !Interactive || Host is not Terminal)
        {
            return null;
        }
        
        // this output is aligned with the help output formatting.
        
        var longestTargetName = ExecutableTargets.Select(x => x.Name.Length).OrderByDescending(x => x).First();
        var padRightTargets = Math.Max(longestTargetName, val2: 20);

        var availableTargets = ExecutableTargets
            .Where(t => t.Listed)
            .OrderBy(x => x.IsDefault ? 0 : 1)
            .ThenBy(x => x.Name)
            .ToArray();
        
        var targets = AnsiConsole.Prompt(
            new MultiSelectionPrompt<ExecutableTarget>()
                .Title("No target specified. Choose the targets you want execute:")
                .AddChoices(availableTargets)
                .UseConverter(target =>
                {
                    var builder = new StringBuilder();
                    // > [ ] Compile                                                        
                    //       Compiles the project
                    // ______ <- 6 characters indent
                    HandleHelpRequestsAttribute.AppendTargetText(builder, target, "", "      ", padRightTargets);
                    return builder.ToString().TrimEnd();
                })
                .InstructionsText(
                    "[grey](Press [blue]<space>[/] to toggle a target, [green]<enter>[/] to accept)[/]")
        );
        
        Host.Information($"Selected targets: {targets.Select(x => x.Name).JoinCommaSpace()}");

        return targets.AsReadOnly();
    }
}
