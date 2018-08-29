// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Nuke.Common.Execution;

namespace Nuke.Common.Tests.Execution
{
    internal class NukeBuildAssertions : ReferenceTypeAssertions<NukeBuild, NukeBuildAssertions>
    {
        public NukeBuildAssertions(NukeBuild subject)
        {
            Subject = subject;
        }

        [CustomAssertion]
        public AndConstraint<NukeBuildAssertions> HaveTargetWithExecutionStatus<T>(
            Expression<Func<T, Target>> targetSelector,
            ExecutionStatus status,
            string because = null,
            params object[] becauseArgs)
            where T : NukeBuild
        {
            var member = targetSelector.Body as MemberExpression;
            var prop = member?.Member as PropertyInfo;
            var name = prop?.Name;

            return HaveTargetWithExecutionStatus(name, status, because, becauseArgs);
        }

        [CustomAssertion]
        public AndConstraint<NukeBuildAssertions> HaveTargetWithExecutionStatus(
            string targetName,
            ExecutionStatus expectedStatus,
            string because = null,
            params object[] becauseArgs)
        {
            var target = Subject.TargetDefinitions.SingleOrDefault(x => x.Name == targetName);

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(target != null)
                .FailWith("Expected {context:build} to have a target with the name {0}{reason}, but found {1}.",
                    targetName,
                    Subject.TargetDefinitions.Select(x => x.Name))
                .Then
                .ForCondition(target.Status == expectedStatus)
                .FailWith("Expected {context:build} to have a target with the name {0} and status {1}{reason}, but found status {2}.",
                    targetName,
                    expectedStatus,
                    target.Status);

            return new AndConstraint<NukeBuildAssertions>(this);
        }

        protected override string Identifier => "nukeBuild";
    }

    internal static class NukeBuildAssertionExtensions
    {
        public static NukeBuildAssertions Should(this NukeBuild build)
        {
            return new NukeBuildAssertions(build);
        }
    }
}
