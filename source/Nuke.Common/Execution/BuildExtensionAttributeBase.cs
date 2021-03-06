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
    public interface IOnBuildCreated : IBuildExtension
    {
        void OnBuildCreated(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets);
    }

    [PublicAPI]
    public interface IOnBuildInitialized : IBuildExtension
    {
        void OnBuildInitialized(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan);
    }

    [PublicAPI]
    public interface IOnTargetSkipped : IBuildExtension
    {
        void OnTargetSkipped(NukeBuild build, ExecutableTarget target);
    }

    [PublicAPI]
    public interface IOnTargetRunning : IBuildExtension
    {
        void OnTargetRunning(NukeBuild build, ExecutableTarget target);
    }

    [PublicAPI]
    public interface IOnTargetSucceeded : IBuildExtension
    {
        void OnTargetSucceeded(NukeBuild build, ExecutableTarget target);
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
