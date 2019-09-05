// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nuke.Common.Utilities;

namespace Nuke.Common.Execution
{
    /// <summary>
    /// Validates all requirements for targets that are part of the execution plan.
    /// </summary>
    internal static class RequirementService
    {
        public static void ValidateRequirements(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executingTargets)
        {
            foreach (var target in executingTargets)
            foreach (var requirement in target.Requirements)
            {
                if (requirement is Expression<Func<bool>> boolExpression)
                    ControlFlow.Assert(boolExpression.Compile().Invoke(), $"Target '{target.Name}' requires '{requirement.Body}'.");
                else if (IsMemberNull(requirement.GetMemberInfo(), build, target))
                    ControlFlow.Fail($"Target '{target.Name}' requires member '{requirement.GetMemberInfo().Name}' to be not null.");
            }

            var requiredMembers = InjectionUtility.GetParameterMembers(build.GetType(), includeUnlisted: true)
                .Where(x => x.HasCustomAttribute<RequiredAttribute>());
            foreach (var member in requiredMembers)
            {
                if (IsMemberNull(member, build))
                    ControlFlow.Fail($"Member '{member.Name}' is required to be not null.");
            }
        }

        private static bool IsMemberNull(MemberInfo member, NukeBuild build, ExecutableTarget target = null)
        {
            var from = target != null ? $"from target '{target.Name}' " : string.Empty;
            ControlFlow.Assert(member.HasCustomAttribute<InjectionAttributeBase>(),
                $"Member '{member.Name}' is required {from}but not marked with an injection attribute.");

            if (NukeBuild.Host == HostType.Console)
                InjectValueInteractive(build, member);

            return member.GetValue(build) == null;
        }

        private static void InjectValueInteractive(NukeBuild build, MemberInfo member)
        {
            var memberType = member.GetMemberType();
            var nameOrDescription = ParameterService.GetParameterDescription(member) ??
                                    ParameterService.GetParameterMemberName(member);
            var text = $"{nameOrDescription.TrimEnd('.')}:";

            while (member.GetValue(build) == null)
            {
                var valueSet = ParameterService.Instance.GetParameterValueSet(member, build);
                var value = valueSet == null
                    ? ConsoleUtility.PromptForInput(text, defaultValue: null)
                    : ConsoleUtility.PromptForChoice(text, valueSet.Select(x => (x.Object, x.Text)).ToArray());

                member.SetValue(build, ReflectionService.Convert(value, memberType));
            }
        }
    }
}
