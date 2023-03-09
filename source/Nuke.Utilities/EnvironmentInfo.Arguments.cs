// Copyright 2023 Maintainers of NUKE.
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
        internal static ArgumentParser ArgumentParser = new(Environment.GetCommandLineArgs().Skip(1));

        /// <summary>
        /// Returns a collection of arguments passed to the current process.
        /// </summary>
        public static IReadOnlyCollection<string> CommandLineArguments => ArgumentParser.Arguments;

        /// <summary>
        /// Indicates whether an argument was passed.
        /// </summary>
        [Pure]
        public static bool HasArgument(string name)
        {
            return ArgumentParser.HasArgument(name);
        }

        /// <summary>
        /// Indicates whether an argument was passed. The argument name is resolved from the member name.
        /// </summary>
        [Pure]
        public static bool HasArgument<T>(Expression<Func<T>> expression)
        {
            return HasArgument(expression.GetMemberInfo().Name);
        }

        /// <summary>
        /// Returns the converted value for a named argument.
        /// </summary>
        [Pure]
        [CanBeNull]
        public static T GetNamedArgument<T>(string parameterName, char? separator = null)
        {
            return (T)ArgumentParser.GetNamedArgument(parameterName, typeof(T), separator);
        }

        /// <summary>
        /// Returns the converted value for a named argument. The argument name is resolved from the member name.
        /// </summary>
        [Pure]
        [CanBeNull]
        public static T GetNamedArgument<T>(Expression<Func<T>> expression, char? separator = null)
        {
            return GetNamedArgument<T>(expression.GetMemberInfo().Name, separator);
        }

        /// <summary>
        /// Returns the converted value for a named argument. The argument name is resolved from the member name.
        /// </summary>
        [Pure]
        [CanBeNull]
        public static T GetNamedArgument<T>(Expression<Func<object>> expression, char? separator = null)
        {
            return GetNamedArgument<T>(expression.GetMemberInfo().Name, separator);
        }

        /// <summary>
        /// Returns the converted value for a positional argument.
        /// </summary>
        [Pure]
        [CanBeNull]
        public static T GetPositionalArgument<T>(int position, char? separator = null)
        {
            return (T)ArgumentParser.GetPositionalArgument(position, typeof(T), separator);
        }

        /// <summary>
        /// Returns the converted values for all positional arguments.
        /// </summary>
        [Pure]
        [CanBeNull]
        public static T[] GetAllPositionalArguments<T>(char? separator = null)
        {
            return (T[])ArgumentParser.GetAllPositionalArguments(typeof(T), separator);
        }
    }
}
