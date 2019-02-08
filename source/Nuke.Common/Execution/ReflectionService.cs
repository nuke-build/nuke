// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Execution
{
    public static class ReflectionService
    {
        public const BindingFlags All = Static | Instance | BindingFlags.FlattenHierarchy;

        public const BindingFlags Instance = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        public const BindingFlags Static = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        public static void SetValue(object instance, string memberName, object value)
        {
            var member = instance.GetType().GetMember(memberName, All)
                .SingleOrDefault()
                .NotNull($"Could not find member '{memberName}' on type '{instance.GetType()}'.");
            SetValue(instance, member, value);
        }
        
        public static void SetValue(Type type, string memberName, object value)
        {
            var member = type.GetMember(memberName, All)
                .SingleOrDefault()
                .NotNull($"Could not find member '{memberName}' on type '{type}'.");
            SetValue(instance: null, member, value);
        }

        public static void SetValue(object instance, MemberInfo member, object value)
        {
            if (member is FieldInfo field)
            {
                field.SetValue(field.IsStatic ? null : instance, value);
            }
            else if (member is PropertyInfo property)
            {
                var backingField = member.DeclaringType.DescendantsAndSelf(x => x.GetTypeInfo().BaseType)
                    .SelectMany(x => x.GetFields(All))
                    .FirstOrDefault(x => x.Name.StartsWith($"<{member.Name}>"));

                if (backingField != null)
                {
                    backingField.SetValue(backingField.IsStatic ? null : instance, value);
                }
                else
                {
                    ControlFlow.Assert(property.SetMethod != null, $"Property '{member.Name}' is not settable.");
                    property.SetValue(property.GetMethod.IsStatic ? null : instance, value);
                }
            }
        }

        public static MemberInfo GetMemberInfo(this LambdaExpression expression)
        {
            var memberExpression = !(expression.Body is UnaryExpression unaryExpression)
                ? (MemberExpression) expression.Body
                : (MemberExpression) unaryExpression.Operand;
            return memberExpression.Member;
        }

        public static Type GetFieldOrPropertyType(this MemberInfo member)
        {
            switch (member)
            {
                case FieldInfo fieldInfo:
                    return fieldInfo.FieldType;
                case PropertyInfo propertyInfo:
                    return propertyInfo.PropertyType;
                default:
                    throw new NotSupportedException();
            }
        }

        public static T Convert<T>(string value)
        {
            return (T) Convert(value, typeof(T));
        }

        [CanBeNull]
        public static object Convert(object value, Type destinationType)
        {
            if (destinationType.IsInstanceOfType(value))
                return value;

            if (destinationType == typeof(string) && value == null)
                return null;
            
            try
            {
                var typeConverter = TypeDescriptor.GetConverter(destinationType);
                return typeConverter.ConvertFromInvariantString(value?.ToString());
            }
            catch
            {
                ControlFlow.Fail($"Value '{value}' could not be converted to '{GetPresentableName(destinationType)}'.");
                // ReSharper disable once HeuristicUnreachableCode
                return null;
            }
        }

        public static string GetPresentableName(Type type)
        {
            if (type.IsArray)
                return $"{type.GetElementType().NotNull().Name}[]";

            var underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
                return underlyingType.Name + "?";

            return type.Name;
        }
    }
}
