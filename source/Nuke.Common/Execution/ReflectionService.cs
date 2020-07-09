// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Execution
{
    public static class ReflectionService
    {
        public const BindingFlags All = Static | Instance | BindingFlags.FlattenHierarchy;

        public const BindingFlags Instance = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        public const BindingFlags Static = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        public static T GetValue<T>(this MemberInfo member, object obj = null, object[] args = null)
        {
            return (T) GetValue(member, obj, args);
        }

        public static object GetValue(this MemberInfo member, object obj = null, object[] args = null)
        {
            return member switch
            {
                FieldInfo fieldInfo => fieldInfo.GetValue(obj),
                PropertyInfo propertyInfo => propertyInfo.GetValue(obj),
                MethodInfo methodInfo => methodInfo.Invoke(obj, args),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object> GetArguments(this MethodCallExpression methodCall)
        {
            return methodCall.Arguments.Cast<ConstantExpression>().Select(x => x.Value);
        }

        public static TResult GetValueNonVirtual<TResult>(this MemberInfo member, object obj, params object[] arguments)
        {
            ControlFlow.Assert(member is PropertyInfo || member is MethodInfo, "member is PropertyInfo || member is MethodInfo");
            var method = member is PropertyInfo property
                ? property.GetMethod
                : (MethodInfo) member;

            var funcType = Expression.GetFuncType(method.GetParameters().Select(x => x.ParameterType)
                .Concat(method.ReturnType).ToArray());
            var functionPointer = method.NotNull("method != null").MethodHandle.GetFunctionPointer();
            var nonVirtualDelegate = (Delegate) Activator.CreateInstance(funcType, obj, functionPointer)
                .NotNull("nonVirtualDelegate != null");

            return (TResult) nonVirtualDelegate.DynamicInvoke(arguments);

            // var method = (MethodInfo) func.GetMemberInfo();
            //
            // var dynamicMethod = new DynamicMethod(
            //     name: $"Own{method.Name}",
            //     returnType: typeof(TResult),
            //     parameterTypes: new[] { typeof(TObject) }.Concat(method.GetParameters().Select(x => x.ParameterType)).ToArray(),
            //     owner: typeof(TObject));
            //
            // var generator = dynamicMethod.GetILGenerator();
            // dynamicMethod.GetParameters().ForEach((x, i) => generator.Emit(OpCodes.Ldarg_S, i));
            // generator.Emit(OpCodes.Call, method);
            // generator.Emit(OpCodes.Ret);
            //
            // var methodCallExpression = (MethodCallExpression) func.Body;
            // var arguments = obj.Concat(methodCallExpression.Arguments.Cast<ConstantExpression>().Select(x => x.Value)).ToArray();
            //
            // return (TResult) dynamicMethod.Invoke(obj: null, arguments);
        }

        public static void SetValue(this MemberInfo member, object instance, object value)
        {
            // TODO: check if member is not (static && readonly)
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

        public static bool IsNullableType(this Type type)
        {
            return Nullable.GetUnderlyingType(type) != null ||
                   type == typeof(string) ||
                   type.IsClass ||
                   type.IsArray;
        }

        public static Type GetNullableType(this Type type)
        {
            return type.IsNullableType() ? type : typeof(Nullable<>).MakeGenericType(type);
        }

        public static bool HasCustomAttribute<T>(this MemberInfo member)
            where T : Attribute
        {
            return member.GetCustomAttribute<T>() != null;
        }

        public static bool HasCustomAttribute<T>(this ParameterInfo parameter)
            where T : Attribute
        {
            return parameter.GetCustomAttribute<T>() != null;
        }

        public static MemberInfo GetMemberInfo(this LambdaExpression expression)
        {
            if (expression.Body is MethodCallExpression methodCallExpression)
                return methodCallExpression.Method;

            var memberExpression = !(expression.Body is UnaryExpression unaryExpression)
                ? (MemberExpression) expression.Body
                : (MemberExpression) unaryExpression.Operand;
            return memberExpression.Member;
        }

        public static Type GetMemberType(this MemberInfo member)
        {
            return member switch
            {
                FieldInfo fieldInfo => fieldInfo.FieldType,
                PropertyInfo propertyInfo => propertyInfo.PropertyType,
                MethodInfo methodInfo => methodInfo.ReturnType,
                _ => throw new NotSupportedException(member.ToString())
            };
        }

        public static bool IsPublic(this MemberInfo member)
        {
            return member switch
            {
                Type type => type.IsPublic,
                ConstructorInfo constructor => constructor.IsPublic,
                FieldInfo field => field.IsPublic,
                MethodInfo method => method.IsPublic,
                _ => throw new NotSupportedException(member.ToString())
            };
        }

        public static bool IsFamily(this MemberInfo member)
        {
            return member switch
            {
                ConstructorInfo constructor => constructor.IsFamily,
                FieldInfo field => field.IsFamily,
                MethodInfo method => method.IsFamily,
                _ => throw new NotSupportedException(member.ToString())
            };
        }

        public static bool IsAssembly(this MemberInfo member)
        {
            return member switch
            {
                ConstructorInfo constructor => constructor.IsAssembly,
                FieldInfo field => field.IsAssembly,
                MethodInfo method => method.IsAssembly,
                _ => throw new NotSupportedException(member.ToString())
            };
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
                ControlFlow.Fail($"Value '{value}' could not be converted to '{GetDisplayShortName(destinationType)}'.");
                // ReSharper disable once HeuristicUnreachableCode
                return null;
            }
        }

        public static bool IsExtensionParameter(this ParameterInfo parameter)
        {
            return parameter.Member is MethodInfo method &&
                   method.HasCustomAttribute<ExtensionAttribute>() &&
                   method.GetParameters().First() == parameter;
        }

        public static string GetDisplayName(this Type type)
        {
            return type.DescendantsAndSelf(x => x.DeclaringType).Reverse().Select(x => x.GetDisplayShortName()).Join(".");
        }

        public static string GetDisplayShortName(this Type type)
        {
            return type.GetDisplayShortName(tupleNames: null);
        }

        internal static string GetDisplayShortName(this Type type, IList<string> tupleNames)
        {
            var aliases = new Dictionary<Type, string>
                          {
                              { typeof(byte), "byte" },
                              { typeof(sbyte), "sbyte" },
                              { typeof(short), "short" },
                              { typeof(ushort), "ushort" },
                              { typeof(int), "int" },
                              { typeof(uint), "uint" },
                              { typeof(long), "long" },
                              { typeof(ulong), "ulong" },
                              { typeof(float), "float" },
                              { typeof(double), "double" },
                              { typeof(decimal), "decimal" },
                              { typeof(object), "object" },
                              { typeof(bool), "bool" },
                              { typeof(char), "char" },
                              { typeof(string), "string" },
                              { typeof(void), "void" }
                          };

            if (aliases.TryGetValue(type, out var alias))
                return alias;

            var underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
                return $"{underlyingType.GetDisplayShortName(tupleNames)}?";

            if (type.IsGenericType)
            {
                string PopName()
                {
                    try
                    {
                        var name = tupleNames.First();
                        return name != null ? $"{name} " : string.Empty;
                    }
                    finally
                    {
                        tupleNames.RemoveAt(0);
                    }
                }

                var typeName = type.Name.Substring(startIndex: 0, type.Name.IndexOf('`'));
                return typeName != nameof(ValueTuple) || tupleNames == null
                    ? $"{typeName}<{type.GetGenericArguments().Select(x => x.GetDisplayShortName(tupleNames)).JoinComma()}>"
                    : $"({type.GetGenericArguments().Select(x => $"{PopName()}{x.GetDisplayShortName(tupleNames)}").JoinComma()})";
            }

            if (type.IsArray)
                return $"{type.GetElementType().GetDisplayShortName(tupleNames)}[{new string(c: ',', type.GetArrayRank() - 1)}]";

            return type.Name;
        }

        public static string GetDisplayText(this ParameterInfo parameter)
        {
            var tupleNames = parameter.GetCustomAttribute<TupleElementNamesAttribute>()?.TransformNames.ToList();
            var parameterType = !(parameter.IsOut || parameter.ParameterType.IsByRef)
                ? parameter.ParameterType.GetDisplayShortName(tupleNames)
                : parameter.ParameterType.GetElementType().GetDisplayShortName(tupleNames);

            var modifier = parameter.IsExtensionParameter()
                ? "this "
                : parameter.IsOut
                    ? "out "
                    : parameter.IsIn
                        ? "in "
                        : parameter.ParameterType.IsByRef
                            ? "ref "
                            : string.Empty;
            var defaultValue = parameter.HasDefaultValue ? $" = {parameter.DefaultValue ?? "null"}" : string.Empty;

            return $"{modifier}{parameterType} {parameter.Name}{defaultValue}";
        }

        public static string GetDisplayText(this MemberInfo member)
        {
            if (member is Type type)
                return type.GetDisplayShortName();

            var parameterList = member is MethodBase methodBase
                ? $"({methodBase.GetParameters().Select(x => x.GetDisplayText()).JoinComma()})"
                : string.Empty;

            var tupleNamesAttribute = member is MethodInfo method
                ? method.ReturnTypeCustomAttributes
                    .GetCustomAttributes(typeof(TupleElementNamesAttribute), inherit: true)
                    .Cast<TupleElementNamesAttribute>()
                    .FirstOrDefault()
                : member.GetCustomAttribute<TupleElementNamesAttribute>();
            var memberType = !(member is ConstructorInfo)
                ? $" : {member.GetMemberType().GetDisplayShortName(tupleNamesAttribute?.TransformNames.ToList())}"
                : string.Empty;

            return $"{member.Name}{parameterList}{memberType}";
        }

        public static object InvokeMember(
            this Type type,
            string memberName,
            object target,
            BindingFlags? bindingFlags = null,
            params object[] args)
        {
            return type.InvokeMember(
                memberName,
                (bindingFlags ?? (target != null ? Instance : Static)) | BindingFlags.InvokeMethod,
                binder: null,
                target,
                args);
        }

        public static T InvokeMember<T>(
            this Type type,
            string memberName,
            object target,
            BindingFlags? bindingFlags = null,
            params object[] args)
        {
            return (T) type.InvokeMember(memberName, target, bindingFlags, args);
        }
    }
}
