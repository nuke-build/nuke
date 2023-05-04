// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using FluentAssertions;
using Nuke.Common.Execution;
using System;
using Xunit;

namespace Nuke.Common.Tests;

public class DelegateRequirementServiceTests
{
    public DelegateRequirementServiceTests()
    {
        // Arguments cannot change across tests due to ValueInjectionUtility.s_valueCache. Use parameters with preset values.
        EnvironmentInfo.SetVariable("NullParameter1", "");
        EnvironmentInfo.SetVariable("NullParameter2", "");
        EnvironmentInfo.SetVariable("StringParameter", "hello");
    }

    [Fact]
    public void TestPassingValidation()
    {
        var build = new StringParameterBuild();
        var targets = ExecutableTargetFactory.CreateAll(build, x => ((IStringParameterInterface)x).PassingRequirement);

        // must not throw
        DelegateRequirementService.ValidateRequirements(build, targets);
    }

    [Fact]
    public void TestRequiredMember()
    {
        var build = new RequiredParameterBuild();
        var targets = ExecutableTargetFactory.CreateAll(build, x => ((IRequiredParameterInterface)x).FailingRequirement);

        var act = () => DelegateRequirementService.ValidateRequirements(build, targets);

        act.Should().Throw<Exception>()
            .WithMessage("Member 'NullParameter1' is required to be not null");
    }

    [Fact]
    public void TestBooleanExpressionRequirement()
    {
        var build = new BooleanExpressionRequirementParameterBuild();
        var targets = ExecutableTargetFactory.CreateAll(build, x => ((IBooleanExpressionRequirementParameterInterface)x).FailingExpressionRequirement);

        var act = () => DelegateRequirementService.ValidateRequirements(build, targets);

        act.Should().Throw<Exception>()
            .WithMessage("Target 'FailingExpressionRequirement' requires '(value(*).NullParameter1 != null)'");
    }

    [Fact]
    public void TestMultipleFailingRequirements()
    {
        var build = new MultipleParameters();
        var targets = ExecutableTargetFactory.CreateAll(build, x => ((IMultipleParametersInterface)x).MultipleFailingRequirements);

        var act = () => DelegateRequirementService.ValidateRequirements(build, targets);

        act.Should().Throw<Exception>()
            .WithMessage("Target 'MultipleFailingRequirements' requires '(value(*).NullParameter1 != null)'*" +
                         "Member 'NullParameter2' is required to be not null");
    }

    private interface IRequiredParameterInterface : INukeBuild
    {
        [Parameter] string NullParameter1 => TryGetValue(() => NullParameter1);

        public Target FailingRequirement => _ => _
            .Requires(() => NullParameter1)
            .Executes(() => { });
    }

    private class RequiredParameterBuild : NukeBuild, IRequiredParameterInterface
    {
    }

    private interface IBooleanExpressionRequirementParameterInterface : INukeBuild
    {
        [Parameter] string NullParameter1 => TryGetValue(() => NullParameter1);

        public Target FailingExpressionRequirement => _ => _
            .Requires(() => NullParameter1 != null)
            .Executes(() => { });
    }

    private class BooleanExpressionRequirementParameterBuild : NukeBuild, IBooleanExpressionRequirementParameterInterface
    {
    }

    private interface IMultipleParametersInterface : INukeBuild
    {
        [Parameter] string NullParameter1 => TryGetValue(() => NullParameter1);
        [Parameter] string NullParameter2 => TryGetValue(() => NullParameter2);

        public Target MultipleFailingRequirements => _ => _
            .Requires(() => NullParameter1 != null)
            .Requires(() => NullParameter2)
            .Executes(() => { });
    }

    private class MultipleParameters : NukeBuild, IMultipleParametersInterface
    {
    }

    private interface IStringParameterInterface : INukeBuild
    {
        [Parameter] string StringParameter => TryGetValue(() => StringParameter);

        public Target PassingRequirement => _ => _
            .Requires(() => StringParameter)
            .Executes(() => { });

    }

    private class StringParameterBuild : NukeBuild, IStringParameterInterface
    {
    }
}
