// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
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
        public static void ValidateRequirements(NukeBuild build)
        {
            foreach (var target in build.ExecutionPlan)
            foreach (var requirement in target.Requirements)
            {
                if (requirement is Expression<Func<bool>> boolExpression)
                {
                    ControlFlow.Assert(boolExpression.Compile().Invoke(), $"Target '{target.Name}' requires '{requirement.Body}'.");
                }
                else
                {
                    var member = requirement.GetMemberInfo();

                    if (NukeBuild.Host == HostType.Console)
                    {
                        InjectValueInteractive(build, member);
                    }
                    else
                    {
                        var value = member.GetValue(build);
                        ControlFlow.Assert(value != null, $"Target '{target.Name}' requires member '{member.Name}' to be not null.");
                    }
                }
            }
        }

        private static void InjectValueInteractive(NukeBuild build, MemberInfo member)
        {
            var memberType = member.GetMemberType();
            var nameOrDescription = ParameterService.Instance.GetParameterDescription(member) ??
                                    ParameterService.Instance.GetParameterName(member);
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
