// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using Nuke.Common.Execution;
using Nuke.Common.Execution.Orchestration.Sequential;
using Nuke.Common.Utilities.Collections;
using Xunit;

namespace Nuke.Common.Tests.Execution
{
    public class BuildExecutorTest
    {
        private ExecutableTarget A = new ExecutableTarget { Name = nameof(A) };
        private ExecutableTarget B = new ExecutableTarget { Name = nameof(B) };
        private ExecutableTarget C = new ExecutableTarget { Name = nameof(C) };

        private Expression<Func<bool>> True = () => true;
        private Expression<Func<bool>> False = () => false;

        public BuildExecutorTest()
        {
            C.ExecutionDependencies.Add(B);
            B.ExecutionDependencies.Add(A);

            // otherwise marked as Collective
            A.Actions.Add(() => { });
            B.Actions.Add(() => { });
            C.Actions.Add(() => { });
        }

        [Fact]
        public void TestDefault()
        {
            ExecuteBuild();
            AssertExecuted(A, B, C);
        }

        [Fact]
        public void TestUserSkipped()
        {
            ExecuteBuild(skippedTargets: new ExecutableTarget[0]);
            AssertSkipped(A, B, C);

            ExecuteBuild(skippedTargets: new[] { A });
            AssertExecuted(B, C);
            AssertSkipped(A);

            ExecuteBuild(skippedTargets: new[] { A, B });
            AssertExecuted(C);
            AssertSkipped(A, B);

            B.DependencyBehavior = DependencyBehavior.Skip;
            ExecuteBuild(skippedTargets: new[] { B });
            AssertExecuted(C);
            AssertSkipped(A, B);
        }

        [Fact]
        public void TestStaticCondition()
        {
            B.StaticConditions.Add(True);
            ExecuteBuild();
            AssertExecuted(A, B, C);

            B.StaticConditions.Add(False);

            B.DependencyBehavior = DependencyBehavior.Execute;
            ExecuteBuild();
            AssertExecuted(A, C);
            AssertSkipped(B);

            B.DependencyBehavior = DependencyBehavior.Skip;
            ExecuteBuild();
            AssertExecuted(C);
            AssertSkipped(A, B);
        }

        [Fact]
        public void TestDynamicCondition()
        {
            var condition = false;
            B.DynamicConditions.Add(() => condition);

            ExecuteBuild();
            AssertExecuted(A, C);
            AssertSkipped(B);

            A.Actions.Add(() => condition = true);
            ExecuteBuild();
            AssertExecuted(A, B, C);
        }

        private void ExecuteBuild(ExecutableTarget[] skippedTargets = null)
        {
            static string[] SelectNames(ExecutableTarget[] targets) => targets?.Select(x => x.Name).ToArray();

            var build = new TestBuild();
            build.ExecutableTargets = new[] { A, B, C };
            build.ExecutionPlan = new ExecutionPlan(new[] { A, B, C });
            build.ExecutionPlan.AllExecutionTargets.ForEach(x => x.Status = ExecutionStatus.NotRun);

            RunConditionEvaluator.MarkSkippedTargets(build, SelectNames(skippedTargets));
            RequirementService.ValidateRequirements(build, build.ExecutingTargets.ToList());
            SequentialBuildExecutor.Execute(build);
        }

        private static void AssertExecuted(params ExecutableTarget[] targets)
        {
            targets.ForEach(x => x.Status.Should().Be(ExecutionStatus.Executed));
        }

        private static void AssertSkipped(params ExecutableTarget[] targets)
        {
            targets.ForEach(x => x.Status.Should().Be(ExecutionStatus.Skipped));
        }

        private class TestBuild : NukeBuild
        {
        }
    }
}
