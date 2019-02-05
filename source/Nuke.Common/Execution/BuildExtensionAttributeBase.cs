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
        void Execute(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets);
    }

    public interface IPreLogoBuildExtension : IBuildExtension
    {
    }
    
    public interface IPostLogoBuildExtension : IBuildExtension
    {
    }


    public class Pipeline
    {
        public static Pipeline Create()
        {
            return new Pipeline();
        }

        internal List<Target> Targets { get; } = new List<Target>();

        public Pipeline AddTarget(Target target)
        {
            Targets.Add(target);
            return this;
        }
    }

    public class SupportPipelinesAttribute : Attribute, IPreLogoBuildExtension
    {
        public void Execute(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var pipelines = build.GetType().GetProperties(ReflectionService.All)
                .Where(x => x.PropertyType == typeof(Pipeline))
                .Select(x => x.GetValue(obj: build)).Cast<Pipeline>();

            foreach (var pipeline in pipelines)
            {
                var targets = pipeline.Targets.Select(x => executableTargets.Single(y => y.Factory == x)).ToList();
                for (var i = 0; i < targets.Count - 1; i++)
                    targets[i + 1].ExecutionDependencies.Add(targets[i]);
            }
        }
    }
}
