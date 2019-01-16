// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using Nuke.Common.Execution;
using Xunit;

namespace Nuke.Common.Tests.Execution
{
    public class ExecutableTargetFactoryTest
    {
        [Fact]
        public void Test()
        {
            var build = new TestBuild();
            var targets = ExecutableTargetFactory.CreateAll(build, x => x.A);
            
            var a = targets.Single(x => x.Name == nameof(TestBuild.A));
            var b = targets.Single(x => x.Name == nameof(TestBuild.B));
            var c = targets.Single(x => x.Name == nameof(TestBuild.C));
            var d = targets.Single(x => x.Name == nameof(TestBuild.D));

            targets.Single(x => x.IsDefault).Should().Be(a);
            
            a.Factory.Should().Be(build.A);
            a.Description.Should().Be(build.Description);
            a.Requirements.Should().Equal(build.Requirement);
            a.Actions.Should().Equal(build.Action);
            a.AllDependencies.Should().BeEmpty();

            b.DependencyBehavior.Should().Be(DependencyBehavior.Execute);
            b.StaticConditions.Should().Equal(build.StaticCondition);
            b.ExecutionDependencies.Should().Equal(d);
            b.TriggerDependencies.Should().Equal(c);
            b.AllDependencies.Should().NotBeEmpty();

            c.Triggers.Should().Equal(b);
            c.TriggerDependencies.Should().Equal(d);
            c.ExecutionDependencies.Should().Equal(b);
            c.OrderDependencies.Should().Equal(d);
            c.AllDependencies.Should().NotBeEmpty();
            
            d.DependencyBehavior.Should().Be(DependencyBehavior.Skip);
            d.DynamicConditions.Should().Equal(build.DynamicCondition);
            d.OrderDependencies.Should().Equal(b);
            d.Triggers.Should().Equal(c);
            d.AllDependencies.Should().NotBeEmpty();
        }

        private class TestBuild : NukeBuild
        {
            public string Description = "description";
            public Action Action = () => { };
            public Expression<Func<bool>> Requirement = () => true;
            public Func<bool> StaticCondition = () => true;
            public Func<bool> DynamicCondition = () => false;

            public Target A => _ => _
                .Description(Description)
                .Requires(Requirement)
                .Executes(Action);

            public Target B => _ => _
                .WhenSkipped(DependencyBehavior.Execute)
                .OnlyWhenStatic(StaticCondition)
                .DependsOn(D)
                .DependentFor(C);

            public Target C => _ => _
                .Triggers(B)
                .TriggeredBy(D);

            public Target D => _ => _
                .WhenSkipped(DependencyBehavior.Skip)
                .OnlyWhenDynamic(DynamicCondition)
                .After(B)
                .Before(C);
        }
    }
}
