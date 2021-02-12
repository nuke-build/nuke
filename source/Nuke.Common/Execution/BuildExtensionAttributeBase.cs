// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Execution
{
    public interface IBuildExtension
    {
        float Priority { get; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public abstract class BuildExtensionAttributeBase : Attribute, IBuildExtension
    {
        public virtual float Priority { get; set; }
    }

    public interface IOnBeforeLogo : IBuildExtension
    {
        void OnBeforeLogo(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets);
    }

    public interface IOnAfterLogo : IBuildExtension
    {
        void OnAfterLogo(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan);
    }

    public interface IOnTargetSkipped : IBuildExtension
    {
        void OnTargetSkipped(NukeBuild build, ExecutableTarget target);
    }

    public interface IOnTargetStart : IBuildExtension
    {
        void OnTargetStart(NukeBuild build, ExecutableTarget target);
    }

    public interface IOnTargetExecuted : IBuildExtension
    {
        void OnTargetExecuted(NukeBuild build, ExecutableTarget target);
    }

    public interface IOnTargetFailed : IBuildExtension
    {
        void OnTargetFailed(NukeBuild build, ExecutableTarget target);
    }

    public interface IOnBuildFinished : IBuildExtension
    {
        void OnBuildFinished(NukeBuild build);
    }
}
