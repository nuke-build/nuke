// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Nuke.Common.Execution;
using Nuke.Common.Utilities.Collections;
using Xunit;

namespace Nuke.Common.Tests.Execution
{
    public class BuildExecutorTest
    {
        private ExecutableTarget A = new() { Name = nameof(A), Status = ExecutionStatus.Scheduled };
        private ExecutableTarget B = new() { Name = nameof(B), Status = ExecutionStatus.Scheduled };
        private ExecutableTarget C = new() { Name = nameof(C), Status = ExecutionStatus.Scheduled };

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
            AssertSucceeded(A, B, C);
        }

        [Fact]
        public void TestParameterSkipped_AllWithoutInvoked()
        {
            ExecuteBuild(skippedTargets: new ExecutableTarget[0]);
            AssertSkipped(A, B, C);
        }

        [Fact]
        public void TestParameterSkipped_AllWithInvoked()
        {
            C.Invoked = true;
            ExecuteBuild(skippedTargets: new ExecutableTarget[0]);
            AssertSucceeded(C);
            AssertSkipped(A, B);
        }

        [Fact]
        public void TestParameterSkipped_Single()
        {
            ExecuteBuild(skippedTargets: new[] { A });
            AssertSucceeded(B, C);
            AssertSkipped(A);
            A.Skipped.Should().Be("via parameter");
        }

        [Fact]
        public void TestParameterSkipped_Multiple()
        {
            ExecuteBuild(skippedTargets: new[] { A, B });
            AssertSucceeded(C);
            AssertSkipped(A, B);
        }

        [Fact]
        public void TestParameterSkipped_DependencyBehavior_Skip()
        {
            B.DependencyBehavior = DependencyBehavior.Skip;
            ExecuteBuild(skippedTargets: new[] { B });
            AssertSucceeded(C);
            AssertSkipped(A, B);
        }

        [Fact]
        public void TestStaticCondition()
        {
            B.StaticConditions.Add(("True", () => true));
            ExecuteBuild();
            AssertSucceeded(A, B, C);
        }

        [Fact]
        public void TestStaticCondition_DependencyBehavior_Execute()
        {
            B.StaticConditions.Add(("() => false", () => false));
            B.DependencyBehavior = DependencyBehavior.Execute;
            ExecuteBuild();
            AssertSucceeded(A, C);
            AssertSkipped(B);
            B.OnlyWhen.Should().Be("false");
        }

        [Fact]
        public void TestStaticCondition_DependencyBehavior_Skip()
        {
            B.StaticConditions.Add(("() => false", () => false));
            B.DependencyBehavior = DependencyBehavior.Skip;
            ExecuteBuild();
            AssertSucceeded(C);
            AssertSkipped(A, B);
            A.Skipped.Should().Be("because of B");
            B.OnlyWhen.Should().Be("false");
        }

        [Fact]
        public void TestStaticCondition_Multiple()
        {
            A.StaticConditions.Add(("A", () => false));
            A.StaticConditions.Add(("B", () => !true));
            ExecuteBuild();
            AssertSkipped(A);
            A.OnlyWhen.Should().Be("A && B");
        }

        [Fact]
        public void TestDynamicCondition_Unchanged()
        {
            var condition = false;
            B.DynamicConditions.Add(("condition", () => condition));

            ExecuteBuild();
            AssertSucceeded(A, C);
            AssertSkipped(B);
        }

        [Fact]
        public void TestDynamicCondition_Changed()
        {
            var condition = false;
            B.DynamicConditions.Add(("condition", () => condition));
            A.Actions.Add(() => condition = true);
            ExecuteBuild();
            AssertSucceeded(A, B, C);
        }

        [Fact]
        public void TestMixedConditions()
        {
            A.StaticConditions.Add(("condition", () => false));
            A.DynamicConditions.Add(("condition", () => throw new Exception()));
            ExecuteBuild();
            AssertSkipped(A);
        }

        [Fact]
        public void TestThrowingCondition()
        {
            A.StaticConditions.Add(("condition", () => throw new Exception()));
            var action = () => ExecuteBuild();

            action.Should().Throw<TargetExecutionException>();
        }

        [Fact]
        public void TestSkipTriggers()
        {
            A.DynamicConditions.Add(("condition", () => false));
            A.Triggers.Add(B);
            B.Triggers.Add(C);
            B.ExecutionDependencies.Clear();
            C.ExecutionDependencies.Clear();

            ExecuteBuild();

            AssertSkipped(A, B, C);
        }

        private void ExecuteBuild(ExecutableTarget[] skippedTargets = null)
        {
            static string[] SelectNames(ExecutableTarget[] targets) => targets?.Select(x => x.Name).ToArray();

            var build = new TestBuild();
            build.ExecutableTargets = new[] { A, B, C };
            build.ExecutionPlan = new[] { A, B, C };
            BuildExecutor.Execute(build, SelectNames(skippedTargets));
        }

        private static void AssertSucceeded(params ExecutableTarget[] targets)
        {
            targets.ForEach(x => x.Status.Should().Be(ExecutionStatus.Succeeded));
            targets.ForEach(x => x.Skipped.Should().BeNull());
        }

        private static void AssertSkipped(params ExecutableTarget[] targets)
        {
            targets.ForEach(x => x.Status.Should().Be(ExecutionStatus.Skipped));
            // targets.ForEach(x => x.Skipped.Should().NotBeNull());
        }

        private class TestBuild : NukeBuild
        {
        }
    }
}
