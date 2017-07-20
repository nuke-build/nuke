// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nuke.Core.Injection;

namespace Nuke.Core.Execution
{
    internal class InjectionService
    {
        public void InjectParameters (NukeBuild build)
        {
            foreach (var field in build.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var attributes = field.GetCustomAttributes().OfType<InjectionAttributeBase>().ToList();
                if (attributes.Count == 0)
                    continue;
                ControlFlow.Assert(attributes.Count == 1, $"Field '{field.Name}' has multiple injection attributes applied.");

                var attribute = attributes.Single();
                attribute.InjectValue(field, build);
            }
        }

        public void ValidateParameters (IReadOnlyCollection<TargetDefinition> executionList, NukeBuild buildInstance)
        {
            foreach (var target in executionList)
            foreach (var requiredParameter in target.RequiredParameters)
            {
                var memberExpression = requiredParameter.Body as MemberExpression
                                       ?? (MemberExpression) ((UnaryExpression) requiredParameter.Body).Operand;
                var field = (FieldInfo) memberExpression.Member;

                ControlFlow.Assert(field.GetValue(buildInstance) != null,
                    $"Field '{field.Name}' required by target '{target.Name}' could not be injected.");
            }
        }
    }
}
