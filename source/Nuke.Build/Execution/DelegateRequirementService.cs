// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Execution;

/// <summary>
/// Validates all requirements for targets that are part of the execution plan.
/// </summary>
internal static class DelegateRequirementService
{
    public static void ValidateRequirements(INukeBuild build, IReadOnlyCollection<ExecutableTarget> scheduledTargets)
    {
        foreach (var target in scheduledTargets)
        foreach (var requirement in target.DelegateRequirements)
        {
            if (requirement is Expression<Func<bool>> boolExpression)
                // TODO: same as HasSkippingCondition.GetSkipReason
                Assert.True(boolExpression.Compile().Invoke(), $"Target '{target.Name}' requires '{requirement.Body}'");
            else if (IsMemberNullOrEmpty(requirement.GetMemberInfo(), build, target))
                Assert.Fail($"Target '{target.Name}' requires member '{GetMemberName(requirement.GetMemberInfo())}' to be not null or empty");
        }

        var requiredMembers = ValueInjectionUtility.GetInjectionMembers(build.GetType())
            .Select(x => x.Member)
            .Where(x => x.HasCustomAttribute<RequiredAttribute>());
        foreach (var member in requiredMembers)
        {
            if (IsMemberNullOrEmpty(member, build))
                Assert.Fail($"Member '{GetMemberName(member)}' is required to be not null or empty");
        }
    }

    private static bool IsMemberNullOrEmpty(MemberInfo member, INukeBuild build, ExecutableTarget target = null)
    {
        member = member.DeclaringType != build.GetType()
            ? build.GetType().GetMember(member.Name).SingleOrDefault() ?? member
            : member;

        var from = target != null ? $"from target '{target.Name}' " : string.Empty;
        Assert.True(member.HasCustomAttribute<ValueInjectionAttributeBase>(),
            $"Member '{GetMemberName(member)}' is required {from}but not marked with an injection attribute.");

        if (build.Host is Terminal)
            TryInjectValueInteractive(member, build);

        return member.GetMemberType() != typeof(string)
            ? member.GetValue(build) == null
            : member.GetValue<string>(build).IsNullOrWhiteSpace();
    }

    private static void TryInjectValueInteractive(MemberInfo member, INukeBuild build)
    {
        if (!member.HasCustomAttribute<ParameterAttribute>())
            return;

        if (member is PropertyInfo property && !property.CanWrite)
            return;

        var memberType = member.GetMemberType();
        var nameOrDescription = ParameterService.GetParameterDescription(member) ??
                                ParameterService.GetParameterMemberName(member);
        var text = $"{nameOrDescription.TrimEnd('.')}:";

        while (member.GetValue(build) == null)
        {
            var valueSet = ParameterService.GetParameterValueSet(member, build);
            var value = valueSet == null
                ? ConsoleUtility.PromptForInput(text, defaultValue: null)
                : ConsoleUtility.PromptForChoice(text, valueSet.Select(x => (x.Object, x.Text)).ToArray());

            member.SetValue(build, ReflectionUtility.Convert(value, memberType));
        }
    }

    private static string GetMemberName(MemberInfo member)
    {
        return member.HasCustomAttribute<ParameterAttribute>()
            ? ParameterService.GetParameterMemberName(member)
            : member.Name;
    }
}
