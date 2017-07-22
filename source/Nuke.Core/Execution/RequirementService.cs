// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Nuke.Core.Execution
{
    internal static class RequirementService
    {
        public static void ValidateRequirements (IReadOnlyCollection<TargetDefinition> executionList, NukeBuild buildInstance)
        {
            foreach (var target in executionList)
            foreach (var requirement in target.Requirements)
            {
                if (requirement is Expression<Func<bool>> boolExpression)
                {
                    ControlFlow.Assert(boolExpression.Compile().Invoke(),
                        $"Assertion failed: {requirement.Body}");
                }
                else
                {
                    var memberExpression = requirement.Body is MemberExpression
                        ? (MemberExpression) requirement.Body
                        : (MemberExpression) ((UnaryExpression) requirement.Body).Operand;
                    var field = (FieldInfo) memberExpression.Member;

                    ControlFlow.Assert(field.GetValue(buildInstance) != null,
                        $"Field '{field.Name}' was 'null' but is required for target '{target.Name}'.");
                }
            }
        }
    }
}
