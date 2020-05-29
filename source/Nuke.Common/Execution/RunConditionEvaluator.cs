using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Nuke.Common.Execution
{
    public static class RunConditionEvaluator
    {
        public static void MarkSkippedTargets(NukeBuild build, IReadOnlyCollection<string> skippedTargets)
        {
            void MarkTargetSkipped(ExecutableTarget target)
            {
                if (build.InvokedTargets.Contains(target))
                    return;

                target.Status = ExecutionStatus.Skipped;

                if (target.DependencyBehavior == DependencyBehavior.Execute)
                    return;

                target.ExecutionDependencies.ForEach(TryMarkTargetSkipped);
                target.Triggers.ForEach(TryMarkTargetSkipped);
            }

            void TryMarkTargetSkipped(ExecutableTarget target)
            {
                var executingTargets = build.ExecutionPlan.AllExecutionTargets.Where(x => x.Status == ExecutionStatus.NotRun);
                if (executingTargets.Any(x => x.ExecutionDependencies.Contains(target) || x.Triggers.Contains(target)))
                    return;

                MarkTargetSkipped(target);
            }

            if (skippedTargets != null)
            {
                build.ExecutionPlan.AllExecutionTargets
                    .Where(x => skippedTargets.Count == 0 || skippedTargets.Contains(x.Name, StringComparer.OrdinalIgnoreCase))
                    .ForEachLazy(x => x.SkipReason = "via --skip parameter")
                    .ForEach(MarkTargetSkipped);
            }

            build.ExecutionPlan.AllExecutionTargets
                .Where(x => HasSkippingCondition(x, x.StaticConditions))
                .ForEach(MarkTargetSkipped);
        }

        public static bool HasSkippingCondition(ExecutableTarget target, IEnumerable<Expression<Func<bool>>> conditions)
        {
            // TODO: trim outer parenthesis
            static string GetSkipReason(Expression<Func<bool>> condition) =>
                condition.Body.ToString()
                    .Replace("False", "false")
                    .Replace("True", "true")
                    .Replace("OrElse", "||")
                    .Replace("AndAlso", "&&")
                    // TODO: should get actual build type name
                    .Replace("value(Build).", string.Empty);

            target.SkipReason = null; // solely for testing

            foreach (var condition in conditions)
            {
                if (!condition.Compile().Invoke())
                    target.SkipReason = GetSkipReason(condition);
            }

            return target.SkipReason != null;
        }
    }
}
