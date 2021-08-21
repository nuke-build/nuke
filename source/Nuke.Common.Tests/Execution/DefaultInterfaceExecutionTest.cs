using System;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using Nuke.Common.Execution;
using Nuke.Common.ValueInjection;
using Xunit;

namespace Nuke.Common.Tests.Execution
{
    public class DefaultInterfaceExecutionTest
    {
        public static string Description = "description";
        public static Action Action = () => { };
        public static Expression<Func<bool>> Requirement = () => true;
        public static Expression<Func<bool>> StaticCondition = () => true;
        public static Expression<Func<bool>> DynamicCondition = () => false;

        [Fact]
        public void Test()
        {
            var build = new TestBuild();
            var targets = ExecutableTargetFactory.CreateAll(build, x => x.E);

            var a = targets.Single(x => x.Name == nameof(ITestBuild.A));
            var b = targets.Single(x => x.Name == nameof(ITestBuild.B));
            var c = targets.Single(x => x.Name == nameof(ITestBuild.C));
            var d = targets.Single(x => x.Name == nameof(ITestBuild.D));
            var e = targets.Single(x => x.Name == nameof(TestBuild.E));

            targets.Single(x => x.IsDefault).Should().Be(e);

            a.Description.Should().Be(Description);
            a.Requirements.Should().Equal(Requirement);
            a.Actions.Should().Equal(Action);
            a.AllDependencies.Should().BeEmpty();

            b.DependencyBehavior.Should().Be(DependencyBehavior.Execute);
            b.StaticConditions.Should().Equal(StaticCondition);
            b.ExecutionDependencies.Should().Equal(d);
            b.TriggerDependencies.Should().Equal(c);
            b.AllDependencies.Should().NotBeEmpty();

            c.Triggers.Should().Equal(b);
            c.TriggerDependencies.Should().Equal(d);
            c.ExecutionDependencies.Should().Equal(b);
            c.OrderDependencies.Should().Equal(d);
            c.AllDependencies.Should().NotBeEmpty();

            d.DependencyBehavior.Should().Be(DependencyBehavior.Skip);
            d.DynamicConditions.Should().Equal(DynamicCondition);
            d.OrderDependencies.Should().Equal(b);
            d.Triggers.Should().Equal(c);
            d.AllDependencies.Should().NotBeEmpty();

            e.ExecutionDependencies.Should().Equal(a);
        }

        [Fact]
        public void TestMultipleInheritance()
        {
            var build = new MultipleInheritanceTestBuild();
            var targets = ExecutableTargetFactory.CreateAll(build, x => x.Default);

            var a = targets.Single(x => x.Name == nameof(ITestBuild.A));
            var b = targets.Single(x => x.Name == nameof(ITestBuild.B));
            var c = targets.Single(x => x.Name == nameof(ITestBuild.C));
            var d = targets.Single(x => x.Name == nameof(ITestBuild.D));
            var f = targets.Single(x => x.Name == nameof(IInheritedTestBuild.F));

            f.Triggers.Should().Equal(a);

            b.DependencyBehavior.Should().Be(DependencyBehavior.Execute);
            b.StaticConditions.Should().Equal(StaticCondition);
            b.ExecutionDependencies.Should().Equal(d);
            b.TriggerDependencies.Should().Equal(c);
            b.AllDependencies.Should().NotBeEmpty();
        }

        [Fact]
        public void TestRequirementValidation()
        {
            EnvironmentInfo.SetVariable("StringParameter", "hello");
            var build = new ParameterBuild();
            var targets = ExecutableTargetFactory.CreateAll(build, x => ((IParameterInterface)x).HelloWorld);

            // must not throw
            RequirementService.ValidateRequirements(build, targets);
        }

        [Fact]
        public void TestInvalidDependencyType()
        {
            var build = new InvalidDependencyTypeTestBuild();
            Assert.Throws<InvalidCastException>(() => ExecutableTargetFactory.CreateAll(build, x => x.E));
        }

        [Fact]
        public void TestNonPublicTarget()
        {
            var build = new NonPublicTargetTestBuild();
            var exception = Assert.Throws<Exception>(() => ExecutableTargetFactory.CreateAll(build));
            exception.Message.Should()
                .StartWith("Assertion failed: Property 'D' must be marked public to override inherited member from:");
        }

        [Fact]
        public void TestDuplicatedTarget()
        {
            var build = new DuplicatedTargetTestBuild();
            var exception = Assert.Throws<Exception>(() => ExecutableTargetFactory.CreateAll(build));
            exception.Message.Should()
                .StartWith("Assertion failed: Property 'D' must be implemented explicitly because it is inherited from multiple interfaces");
        }

        [Fact]
        public void TestOverriddenDuplicatedTarget()
        {
            var build = new OverriddenDuplicatedTargetTestBuild();
            var targets = ExecutableTargetFactory.CreateAll(build);

            targets.Count(x => x.Name == nameof(ITestBuild.D)).Should().Be(1);
        }

        [Fact]
        public void TestDeclaringAndImplementingComponent()
        {
            var build = new TestBuildWithDeclaringAndImplementingComponent();
            var targets = ExecutableTargetFactory.CreateAll(build);

            targets.Should().HaveCount(1);
            targets.Single().Member.DeclaringType.Should().Be(typeof(IImplementingComponent));
        }

        private interface IParameterInterface
            : INukeBuild
        {
            [Parameter] string StringParameter => TryGetValue(() => StringParameter);

            public Target HelloWorld => _ => _
                .Requires(() => StringParameter)
                .Executes(() =>
                {
                    Logger.Info(StringParameter);
                });
        }

        private class ParameterBuild : NukeBuild, IParameterInterface { }

        private class TestBuild : NukeBuild, ITestBuild
        {
            public Target E => _ => _
                .DependsOn<ITestBuild>(x => x.A)
                .Executes(() => { });
        }

        private class MultipleInheritanceTestBuild : NukeBuild, IInheritedTestBuild
        {
            public Target Default => _ => _
                .DependsOn<ITestBuild>(x => x.A)
                .Executes(() => { });
        }

        private class InvalidDependencyTypeTestBuild : NukeBuild
        {
            public Target E => _ => _
                .DependsOn<ITestBuild>(x => x.A)
                .Executes(() => { });
        }

        private class NonPublicTargetTestBuild : NukeBuild, ITestBuild
        {
            private Target D => _ => _
                .Executes(() => { });
        }

        private class DuplicatedTargetTestBuild : NukeBuild, ITestBuild, IDuplicatedTargetBuild
        {
        }

        private class OverriddenDuplicatedTargetTestBuild : NukeBuild, ITestBuild, IDuplicatedTargetBuild
        {
            public Target D => _ => _
                .Executes(() => { });
        }

        private interface ITestBuild
        {
            public string Description => DefaultInterfaceExecutionTest.Description;
            public Action Action => DefaultInterfaceExecutionTest.Action;
            public Expression<Func<bool>> Requirement => DefaultInterfaceExecutionTest.Requirement;
            public Expression<Func<bool>> StaticCondition => DefaultInterfaceExecutionTest.StaticCondition;
            public Expression<Func<bool>> DynamicCondition => DefaultInterfaceExecutionTest.DynamicCondition;

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

        private interface IInheritedTestBuild : ITestBuild
        {
            public Target F => _ => _
                .Triggers<ITestBuild>(x => x.A);
        }

        private interface IDuplicatedTargetBuild
        {
            public Target D => _ => _
                .Executes(() => { });
        }

        private class TestBuildWithDeclaringAndImplementingComponent : NukeBuild, IImplementingComponent
        {
        }

        private interface IDeclaringComponent : INukeBuild
        {
            Target Foo { get; }
        }

        private interface IImplementingComponent : IDeclaringComponent
        {
            Target IDeclaringComponent.Foo => _ => _;
        }
    }
}
