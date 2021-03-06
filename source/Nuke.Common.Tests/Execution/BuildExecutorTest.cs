// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using Nuke.Common.Execution;
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
            A.SkipReason.Should().Be("via --skip parameter");
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
            B.StaticConditions.Add(True);
            ExecuteBuild();
            AssertSucceeded(A, B, C);
        }

        [Fact]
        public void TestStaticCondition_DependencyBehavior_Execute()
        {
            B.StaticConditions.Add(False);
            B.DependencyBehavior = DependencyBehavior.Execute;
            ExecuteBuild();
            AssertSucceeded(A, C);
            AssertSkipped(B);
            B.SkipReason.Should().Be("false");
        }

        [Fact]
        public void TestStaticCondition_DependencyBehavior_Skip()
        {
            B.StaticConditions.Add(False);
            B.DependencyBehavior = DependencyBehavior.Skip;
            ExecuteBuild();
            AssertSucceeded(C);
            AssertSkipped(A, B);
            A.SkipReason.Should().Be("skipping B");
            B.SkipReason.Should().Be("false");
        }

        [Fact]
        public void TestDynamicCondition_Unchanged()
        {
            var condition = false;
            B.DynamicConditions.Add(() => condition);

            ExecuteBuild();
            AssertSucceeded(A, C);
            AssertSkipped(B);
        }

        [Fact]
        public void TestDynamicCondition_Changed()
        {
            var condition = false;
            B.DynamicConditions.Add(() => condition);
            A.Actions.Add(() => condition = true);
            ExecuteBuild();
            AssertSucceeded(A, B, C);
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
            targets.ForEach(x => x.SkipReason.Should().BeNull());
        }

        private static void AssertSkipped(params ExecutableTarget[] targets)
        {
            targets.ForEach(x => x.Status.Should().Be(ExecutionStatus.Skipped));
            targets.ForEach(x => x.SkipReason.Should().NotBeNull());
        }

        private class TestBuild : NukeBuild
        {
        }
    }
}
