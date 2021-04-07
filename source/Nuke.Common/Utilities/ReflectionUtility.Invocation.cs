// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Utilities
{
    public static partial class ReflectionUtility
    {
        public static T CreateInstance<T>(this Type type, params object[] args)
        {
            return (T) Activator.CreateInstance(type, args);
        }

        public static T GetValue<T>(this MemberInfo member, object obj = null, object[] args = null)
        {
            return (T) GetValue(member, obj, args);
        }

        public static object GetValue(this MemberInfo member, object obj = null, object[] args = null)
        {
            return member switch
            {
                FieldInfo fieldInfo => fieldInfo.GetValue(fieldInfo.IsStatic ? null : obj),
                PropertyInfo propertyInfo => propertyInfo.GetValue(propertyInfo.IsStatic() ? null : obj),
                MethodInfo methodInfo => methodInfo.Invoke(methodInfo.IsStatic ? null : obj, args),
                _ => throw new NotSupportedException()
            };
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
