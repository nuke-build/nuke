// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nuke.Common.Execution;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Serilog;

namespace Nuke.Common
{
    [EventInvoker(Priority = float.MinValue)]
    public abstract partial class NukeBuild
    {
        internal List<IBuildExtension> BuildExtensions { get; }
        internal List<ILogExtension> LogExtensions { get; }

        protected NukeBuild()
        {
            BuildExtensions ??= GetType()
                .GetCustomAttributes<BuildExtensionAttributeBase>()
                .Cast<IBuildExtension>()
                .OrderByDescending(x => x.Priority).ToList();
            LogExtensions ??= GetType()
                .GetCustomAttributes<LogExtensionAttribute>()
                .Cast<ILogExtension>()
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
    }
}
