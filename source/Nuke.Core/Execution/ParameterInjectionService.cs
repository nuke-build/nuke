// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Core.OutputSinks;

namespace Nuke.Core.Execution
{
    internal class ParameterInjectionService
    {
        public void InjectParameters (Build build)
        {
            foreach (var parameterField in GetParameterFields(build))
            {
                var stringValue = GetStringValue(parameterField);
                try
                {
                    var typedValue = EnvironmentInfo.Convert(stringValue, parameterField.FieldType);
                    parameterField.SetValue(build, typedValue);
                }
                catch (FormatException)
                {
                    throw new ExecutionException(
                        $"Value '{stringValue}' for parameter '{parameterField.Name}' " +
                        $"could not be converted to type '{parameterField.FieldType.FullName}'.");
                }
            }
        }

        [CanBeNull]
        private static string GetStringValue (FieldInfo parameterField)
        {
            var name = parameterField.GetCustomAttribute<ParameterAttribute>().Name ?? parameterField.Name;
            return EnvironmentInfo.Argument(name) ?? EnvironmentInfo.Variable(name) ??
                   (parameterField.FieldType == typeof(bool)
                       ? EnvironmentInfo.ArgumentSwitch(name).ToString()
                       : null);
        }

        public void ValidateParameters (IReadOnlyCollection<TargetDefinition> executionList)
        {
            foreach (var target in executionList)
            foreach (var requiredParameter in target.RequiredParameters)
            {
                var memberExpression = requiredParameter.Body as MemberExpression
                                       ?? (MemberExpression) ((UnaryExpression) requiredParameter.Body).Operand;
                var parameterField = (FieldInfo) memberExpression.Member;

                if (GetStringValue(parameterField) == null)
                    throw new ExecutionException(
                        $"Parameter '{parameterField.Name}' required by " +
                        $"target '{target.Name}' could not be resolved.");
            }
        }

        private IEnumerable<FieldInfo> GetParameterFields (Build build)
        {
            return build.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(x => x.GetCustomAttribute<ParameterAttribute>() != null);
        }
    }
}
