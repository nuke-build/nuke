// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using Nuke.Common.Execution;
using Xunit;

namespace Nuke.Common.Tests.Execution
{
    public class BuildExecutorTest
    {
        [Fact]
        public void SkipAllTargetsWhenConditionFalseAndBehaviorSkip()
        {
            var build = ExecutionTestUtility.CreateBuildAndExecuteDefaultTarget<TestBuild>(x => x.Execute,
                x =>
                {
                    x.OnlyWhenCondition = false;
                    x.SwitchConditionInDependency = false;
                    x.DependencyBehavior = DependencyBehavior.Skip;
                });

            AssertExecutionStatus(build, ExecutionStatus.Skipped, ExecutionStatus.Skipped);
        }

        [Fact]
        public void SkipAllTargetsWhenConditionFalseAndBehaviorSkip_SwitchCondition()
        {
            var build = ExecutionTestUtility.CreateBuildAndExecuteDefaultTarget<TestBuild>(x => x.Execute,
                x =>
                {
                    x.OnlyWhenCondition = false;
                    x.SwitchConditionInDependency = true;
                    x.DependencyBehavior = DependencyBehavior.Skip;
                });

            AssertExecutionStatus(build, ExecutionStatus.Skipped, ExecutionStatus.Skipped);
        }

        [Fact]
        public void ExecuteAllTargetsWhenConditionTrueAndBehaviorSkip()
        {
            var build = ExecutionTestUtility.CreateBuildAndExecuteDefaultTarget<TestBuild>(x => x.Execute,
                x =>
                {
                    x.OnlyWhenCondition = true;
                    x.SwitchConditionInDependency = false;
                    x.DependencyBehavior = DependencyBehavior.Skip;
                });

            AssertExecutionStatus(build, ExecutionStatus.Executed, ExecutionStatus.Executed);
        }

        [Fact]
        public void ExecuteAllTargetsWhenConditionTrueAndBehaviorSkip_SwitchCondition()
        {
            var build = ExecutionTestUtility.CreateBuildAndExecuteDefaultTarget<TestBuild>(x => x.Execute,
                x =>
                {
                    x.OnlyWhenCondition = true;
                    x.SwitchConditionInDependency = true;
                    x.DependencyBehavior = DependencyBehavior.Skip;
                });

            AssertExecutionStatus(build, ExecutionStatus.Executed, ExecutionStatus.Executed);
        }

        [Fact]
        public void SkipExecuteTargetWhenConditionTrueAndBehaviorExecute_SwitchCondition()
        {
            var build = ExecutionTestUtility.CreateBuildAndExecuteDefaultTarget<TestBuild>(x => x.Execute,
                x =>
                {
                    x.OnlyWhenCondition = true;
                    x.SwitchConditionInDependency = true;
                    x.DependencyBehavior = DependencyBehavior.Execute;
                });

            AssertExecutionStatus(build, ExecutionStatus.Executed, ExecutionStatus.Skipped);
        }

        [Fact]
        public void ExecuteAllTargetsWhenConditionTrueAndBehaviorExecute()
        {
            var build = ExecutionTestUtility.CreateBuildAndExecuteDefaultTarget<TestBuild>(x => x.Execute,
                x =>
                {
                    x.OnlyWhenCondition = true;
                    x.SwitchConditionInDependency = false;
                    x.DependencyBehavior = DependencyBehavior.Execute;
                });

            AssertExecutionStatus(build, ExecutionStatus.Executed, ExecutionStatus.Executed);
        }

        [Fact]
        public void ExecuteDependencyTargetWhenConditionFalseAndBehaviorExecute()
        {
            var build = ExecutionTestUtility.CreateBuildAndExecuteDefaultTarget<TestBuild>(x => x.Execute,
                x =>
                {
                    x.OnlyWhenCondition = false;
                    x.SwitchConditionInDependency = false;
                    x.DependencyBehavior = DependencyBehavior.Execute;
                });

            AssertExecutionStatus(build, ExecutionStatus.Executed, ExecutionStatus.Skipped);
        }

        [Fact]
        public void ExecuteAllTargetsWhenConditionFalseAndBehaviorExecute_SwitchCondition()
        {
            var build = ExecutionTestUtility.CreateBuildAndExecuteDefaultTarget<TestBuild>(x => x.Execute,
                x =>
                {
                    x.OnlyWhenCondition = false;
                    x.SwitchConditionInDependency = true;
                    x.DependencyBehavior = DependencyBehavior.Execute;
                });

            AssertExecutionStatus(build, ExecutionStatus.Executed, ExecutionStatus.Executed);
        }

        [CustomAssertion]
        private void AssertExecutionStatus(TestBuild build, ExecutionStatus dependencyTargetStatus, ExecutionStatus executeTargetStatus)
        {
            using (new AssertionScope())
            {
                build.Should().HaveTargetWithExecutionStatus<TestBuild>(x => x.Dependency, dependencyTargetStatus);
                build.Should().HaveTargetWithExecutionStatus<TestBuild>(x => x.Execute, executeTargetStatus);
            }
        }

        private class TestBuild : NukeBuild
        {
            public bool OnlyWhenCondition;
            public bool SwitchConditionInDependency;
            public DependencyBehavior DependencyBehavior = DependencyBehavior.Execute;

            public Target Dependency => _ => _
                .Executes(() =>
                {
                    if (SwitchConditionInDependency)
                        OnlyWhenCondition = !OnlyWhenCondition;
                });

            public Target Execute => _ => _
                .DependsOn(Dependency)
                .OnlyWhen(() => OnlyWhenCondition)
                .WhenSkipped(DependencyBehavior)
                .Executes(() => { });
        }
    }
}
