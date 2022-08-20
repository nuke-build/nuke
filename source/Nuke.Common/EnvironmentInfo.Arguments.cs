// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common
{
    public static partial class EnvironmentInfo
    {
        internal static ArgumentParser ArgumentParser = new ArgumentParser(Environment.GetCommandLineArgs().Skip(1));

        public static IReadOnlyCollection<string> CommandLineArguments => ArgumentParser.Arguments;

        public static bool HasArgument(string name)
        {
            return ArgumentParser.HasArgument(name);
        }

        public static bool HasArgument<T>(Expression<Func<T>> expression)
        {
            return HasArgument(expression.GetMemberInfo().Name);
        }

        [CanBeNull]
        public static T GetNamedArgument<T>(string parameterName, char? separator = null)
        {
            return (T)ArgumentParser.GetNamedArgument(parameterName, typeof(T), separator);
        }

        [CanBeNull]
        public static T GetNamedArgument<T>(Expression<Func<T>> expression, char? separator = null)
        {
            return GetNamedArgument<T>(expression.GetMemberInfo().Name, separator);
        }

        [CanBeNull]
        public static T GetNamedArgument<T>(Expression<Func<object>> expression, char? separator = null)
        {
            return GetNamedArgument<T>(expression.GetMemberInfo().Name, separator);
        }

        [CanBeNull]
        public static T GetPositionalArgument<T>(int position, char? separator = null)
        {
            return (T)ArgumentParser.GetPositionalArgument(position, typeof(T), separator);
        }

        [CanBeNull]
        public static T[] GetAllPositionalArguments<T>(char? separator = null)
        {
            return (T[])ArgumentParser.GetAllPositionalArguments(typeof(T), separator);
        }
    }
}
