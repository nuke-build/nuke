// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common
{
    internal partial class ParameterService
    {
        internal static ParameterService Instance = new(
            () => EnvironmentInfo.ArgumentParser,
            () => EnvironmentInfo.Variables);

        [CanBeNull]
        public static T GetParameter<T>(string name, char? separator = null)
        {
            return (T) Instance.GetParameter(name, typeof(T), separator);
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
            return (T) GetFromMemberInfo(member, destinationType ?? typeof(T), Instance.GetParameter);
        }

        [CanBeNull]
        public static T GetNamedArgument<T>(string parameterName, char? separator = null)
        {
            return (T) Instance.GetCommandLineArgument(parameterName, typeof(T), separator);
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
            return (T) GetFromMemberInfo(member, destinationType ?? typeof(T), Instance.GetCommandLineArgument);
        }

        [CanBeNull]
        public static T GetPositionalArgument<T>(int position, char? separator = null)
        {
            return (T) Instance.GetCommandLineArgument(position, typeof(T), separator);
        }

        [CanBeNull]
        public static T[] GetAllPositionalArguments<T>(char? separator = null)
        {
            return (T[]) Instance.GetPositionalCommandLineArguments(typeof(T), separator);
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
            return (T) GetFromMemberInfo(member, destinationType ?? typeof(T), Instance.GetEnvironmentVariable);
        }

        [CanBeNull]
        public static T GetVariable<T>(string parameterName, char? separator = null)
        {
            return (T) Instance.GetEnvironmentVariable(parameterName, typeof(T), separator);
        }

        public static bool HasArgument(MemberInfo member)
        {
            return Instance.HasCommandLineArgument(GetParameterMemberName(member));
        }
    }
}
