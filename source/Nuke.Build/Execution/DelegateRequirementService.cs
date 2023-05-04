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
        var failedAssertions = new List<string>();
        var requiredMembers = new List<(MemberInfo, ExecutableTarget)>();

        foreach (var target in scheduledTargets)
        foreach (var requirement in target.DelegateRequirements)
        {
            if (requirement is Expression<Func<bool>> boolExpression)
            {
                // TODO: same as HasSkippingCondition.GetSkipReason
                if (!boolExpression.Compile().Invoke())
                    failedAssertions.Add($"Target '{target.Name}' requires '{requirement.Body}'");
            }
            else
                requiredMembers.Add((requirement.GetMemberInfo(), target));
        }

        requiredMembers.AddRange(
            ValueInjectionUtility.GetInjectionMembers(build.GetType())
                .Select(x => x.Member)
                .Where(x => x.HasCustomAttribute<RequiredAttribute>())
                .Select(x => (x, (ExecutableTarget)null)));

        foreach (var (member, target) in requiredMembers)
        {
            var buildMember = GetMemberInBuildType(member, build);

            if (!buildMember.HasCustomAttribute<ValueInjectionAttributeBase>())
            {
                var from = target != null ? $"from target '{target.Name}' " : string.Empty;
                failedAssertions.Add($"Member '{GetMemberName(buildMember)}' is required {from}but not marked with an injection attribute.");
            }

            if (CanInjectValueInteractive(buildMember, build) &&
                IsMemberNull(buildMember, build))
            {
                // If we already have errors, there is no point asking the user for input. Print the errors so far and exit.
                if (failedAssertions.Any())
                    break;
                InjectValueInteractive(buildMember, build);
            }

            if (IsMemberNull(buildMember, build))
                failedAssertions.Add($"Member '{GetMemberName(member)}' is required to be not null");
        }

        if (failedAssertions.Any())
            Assert.Fail(string.Join(Environment.NewLine, failedAssertions));
    }

    private static bool IsMemberNull(MemberInfo member, INukeBuild build)
    {
        return member.GetValue(build) == null;
    }

    private static MemberInfo GetMemberInBuildType(MemberInfo member, INukeBuild build)
    {
        return member.DeclaringType != build.GetType()
            ? build.GetType().GetMember(member.Name).SingleOrDefault() ?? member
            : member;
    }

    private static bool CanInjectValueInteractive(MemberInfo member, INukeBuild build)
    {
        if (build.Host is not Terminal)
            return false;

        if (!member.HasCustomAttribute<ParameterAttribute>())
            return false;

        if (member is PropertyInfo property && !property.CanWrite)
            return false;

        return true;
    }

    private static void InjectValueInteractive(MemberInfo member, INukeBuild build)
    {
        var memberType = member.GetMemberType();
        var nameOrDescription = ParameterService.GetParameterDescription(member) ??
                                ParameterService.GetParameterMemberName(member);
        var text = $"{nameOrDescription.TrimEnd('.')}:";

        while (IsMemberNull(member, build))
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
