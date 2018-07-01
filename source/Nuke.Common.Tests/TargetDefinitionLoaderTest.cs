// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using FluentAssertions;
using Nuke.Common.Execution;
using Xunit;

namespace Nuke.Common.Tests
{
    public class TargetDefinitionLoaderTest
    {
        [Theory]
        [InlineData(
            new[] { nameof(TestBuild.Execute) },
            new[] { nameof(TestBuild.Dependency), nameof(TestBuild.Execute) })]
        [InlineData(
            new[] { nameof(TestBuild.ExecuteSkipDependencies) },
            new string[0])]
        [InlineData(
            new[] { nameof(TestBuild.ExecuteImplicitExecuteDependencies) },
            new[] { nameof(TestBuild.Dependency) })]
        [InlineData(
            new[] { nameof(TestBuild.ExecuteExplicitExecuteDependencies) },
            new[] { nameof(TestBuild.Dependency) })]
        [InlineData(
            new[] { nameof(TestBuild.ExecuteSkipDependencies), nameof(TestBuild.ExecuteImplicitExecuteDependencies) },
            new[] { nameof(TestBuild.Dependency) })]
        [InlineData(
            new[] { nameof(TestBuild.Execute), nameof(TestBuild.ExecuteDependency1SkipDependencies) },
            new[] { nameof(TestBuild.Dependency), nameof(TestBuild.Execute) })]
        [InlineData(
            new[] { nameof(TestBuild.ExecuteSkipDependencies), nameof(TestBuild.Dependency) },
            new[] { nameof(TestBuild.Dependency) })]
        public void Test(string[] invokedTargets, string[] expectedTargets)
        {
            TargetDefinitionLoader.GetExecutingTargets(CreateBuild<TestBuild>(), invokedTargets)
                .Where(x => !x.Skip && x.Conditions.All(y => y()))
                .Select(x => x.Name)
                .Should().BeEquivalentTo(expectedTargets);
        }

        private static NukeBuild CreateBuild<T>()
            where T : NukeBuild
        {
            var instance = Activator.CreateInstance<T>();
            var firstTarget = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .First(x => x.PropertyType == typeof(Target)).Name;

            var targetExpression = CreateTargetExpressionByTargetName<T>(firstTarget);
            instance.TargetDefinitions = instance.GetTargetDefinitions(targetExpression);
            return instance;
        }

        private static Expression<Func<TIn, Target>> CreateTargetExpressionByTargetName<TIn>(string target)
            where TIn : NukeBuild
        {
            var param = Expression.Parameter(typeof(TIn));
            var body = Expression.PropertyOrField(param, target);
            return Expression.Lambda<Func<TIn, Target>>(body, param);
        }

        internal class TestBuild : NukeBuild
        {
            public Target Dependency => _ => _
                .Executes(() => { });

            public Target Dependency1 => _ => _
                .DependsOn(Dependency)
                .Executes(() => { });

            public Target ExecuteSkipDependencies => _ => _
                .DependsOn(Dependency)
                .OnlyWhen(() => false)
                .WhenSkipped(DependencyBehavior.Skip)
                .Executes(() => { });

            public Target ExecuteImplicitExecuteDependencies => _ => _
                .DependsOn(Dependency)
                .OnlyWhen(() => false)
                .Executes(() => { });

            public Target ExecuteExplicitExecuteDependencies => _ => _
                .DependsOn(Dependency)
                .OnlyWhen(() => false)
                .WhenSkipped(DependencyBehavior.Execute)
                .Executes(() => { });

            public Target Execute => _ => _
                .DependsOn(Dependency)
                .Executes(() => { });

            public Target ExecuteDependency1SkipDependencies => _ => _
                .DependsOn(Dependency1)
                .OnlyWhen(() => false)
                .WhenSkipped(DependencyBehavior.Skip)
                .Executes(() => { });
        }
    }
}
