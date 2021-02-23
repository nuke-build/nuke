// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    public interface IBuildExtension
    {
        float Priority { get; }
    }

    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class BuildExtensionAttributeBase : Attribute, IBuildExtension
    {
        public virtual float Priority { get; set; }
    }

    [PublicAPI]
    public interface IOnBeforeLogo : IBuildExtension
    {
        void OnBeforeLogo(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets);
    }

    [PublicAPI]
    public interface IOnAfterLogo : IBuildExtension
    {
        void OnAfterLogo(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan);
    }

    [PublicAPI]
    public interface IOnTargetSummaryUpdated : IBuildExtension
    {
        void OnTargetSummaryUpdated(NukeBuild build, ExecutableTarget target);
    }

    [PublicAPI]
    public interface IOnTargetSkipped : IBuildExtension
    {
        void OnTargetSkipped(NukeBuild build, ExecutableTarget target);
    }

    [PublicAPI]
    public interface IOnTargetStart : IBuildExtension
    {
        void OnTargetStart(NukeBuild build, ExecutableTarget target);
    }

    [PublicAPI]
    public interface IOnTargetExecuted : IBuildExtension
    {
        void OnTargetExecuted(NukeBuild build, ExecutableTarget target);
    }

    [PublicAPI]
    public interface IOnTargetFailed : IBuildExtension
    {
        void OnTargetFailed(NukeBuild build, ExecutableTarget target);
    }

    [PublicAPI]
    public interface IOnBuildFinished : IBuildExtension
    {
        void OnBuildFinished(NukeBuild build);
    }
}
