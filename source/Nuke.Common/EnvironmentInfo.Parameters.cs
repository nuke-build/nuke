// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;

namespace Nuke.Common
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static partial class EnvironmentInfo
    {
        public static void SetVariable(string name, string value)
        {
            Environment.SetEnvironmentVariable(name, value);
        }

        [CanBeNull]
        public static T GetParameter<T>(string name, char? separator = null)
        {
            return (T) ParameterService.Instance.GetParameter(name, typeof(T), separator);
        }

        [CanBeNull]
        public static T GetParameter<T>(Expression<Func<T>> expression)
        {
            return GetParameter<T>(expression.GetMemberInfo());
        }

        [CanBeNull]
        public static T GetParameter<T>(Expression<Func<object>> expression)
        {
            return GetParameter<T>(expression.GetMemberInfo());
        }

        [CanBeNull]
        public static T GetParameter<T>(MemberInfo member, Type destinationType = null)
        {
            return (T) ParameterService.GetFromMemberInfo(member, destinationType ?? typeof(T), ParameterService.Instance.GetParameter);
        }

        [CanBeNull]
        public static T GetNamedArgument<T>(string parameterName, char? separator = null)
        {
            return (T) ParameterService.Instance.GetCommandLineArgument(parameterName, typeof(T), separator);
        }

        [CanBeNull]
        public static T GetNamedArgument<T>(Expression<Func<T>> expression)
        {
            return GetNamedArgument<T>(expression.GetMemberInfo());
        }

        [CanBeNull]
        public static T GetNamedArgument<T>(Expression<Func<object>> expression)
        {
            return GetNamedArgument<T>(expression.GetMemberInfo());
        }

        [CanBeNull]
        public static T GetNamedArgument<T>(MemberInfo member, Type destinationType = null)
        {
            return (T) ParameterService.GetFromMemberInfo(member, destinationType ?? typeof(T), ParameterService.Instance.GetCommandLineArgument);
        }

        [CanBeNull]
        public static T GetPositionalArgument<T>(int position, char? separator = null)
        {
            return (T) ParameterService.Instance.GetCommandLineArgument(position, typeof(T), separator);
        }

        [CanBeNull]
        public static T[] GetAllPositionalArguments<T>(char? separator = null)
        {
            return (T[]) ParameterService.Instance.GetPositionalCommandLineArguments(typeof(T), separator);
        }

        [CanBeNull]
        public static T GetVariable<T>(Expression<Func<T>> expression)
        {
            return GetVariable<T>(expression.GetMemberInfo());
        }

        [CanBeNull]
        public static T GetVariable<T>(Expression<Func<object>> expression)
        {
            return GetVariable<T>(expression.GetMemberInfo());
        }

        [CanBeNull]
        public static T GetVariable<T>(MemberInfo member, Type destinationType = null)
        {
            return (T) ParameterService.GetFromMemberInfo(member, destinationType ?? typeof(T), ParameterService.Instance.GetEnvironmentVariable);
        }

        [CanBeNull]
        public static T GetVariable<T>(string parameterName, char? separator = null)
        {
            return (T) ParameterService.Instance.GetEnvironmentVariable(parameterName, typeof(T), separator);
        }

        public static bool HasArgument(MemberInfo member)
        {
            return ParameterService.Instance.HasCommandLineArgument(ParameterService.GetParameterMemberName(member));
        }
    }
}
