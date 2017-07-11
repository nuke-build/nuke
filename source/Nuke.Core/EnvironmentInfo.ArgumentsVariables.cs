// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core;
using Nuke.Core.Execution;

[assembly: IconClass(typeof(EnvironmentInfo), "chip")]

namespace Nuke.Core
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static partial class EnvironmentInfo
    {
        /// <summary>
        /// Provides access to a command-line argument or environment variable.
        /// </summary>
        [CanBeNull]
        public static string ArgumentOrVariable(string name)
        {
            return Argument(name) ?? Variable(name);
        }

        /// <summary>
        /// Provides access to a command-line argument or environment variable using <see cref="ControlFlow.NotNull{T}"/>.
        /// </summary>
        public static string EnsureArgumentOrVariable(string name)
        {
            return ArgumentOrVariable(name).NotNull($"ArgumentOrVariable({name}) != null");
        }

        /// Provides access to an environment variable.
        [CanBeNull]
        public static string Variable (string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }

        /// Provides access to a converted environment variable.
        [CanBeNull]
        public static T Variable<T> (string name)
        {
            var value = Variable(name);
            return (T) (Convert<T>(value) ?? default(T));
        }

        /// Provides access to an environment variable using <see cref="ControlFlow.NotNull{T}"/>.
        public static string EnsureVariable (string name)
        {
            return Variable(name).NotNull($"Variable({name}) != null");
        }

        /// Provides access to a converted environment variable using <see cref="ControlFlow.NotNull{T}"/>.
        public static T EnsureVariable<T> (string name)
        {
            var value = EnsureVariable(name);
            return (T) Convert<T>(value).NotNull($"Convert<{typeof(T)}>(EnsureVariable({name})) != null");
        }


        /// Provides access to a command-line argument.
        [CanBeNull]
        public static string Argument (string name, bool allowEmptyString = false)
        {
            var argument = Environment.GetCommandLineArgs()
                    .SingleOrDefault(x => x.StartsWith($"--{name}", StringComparison.OrdinalIgnoreCase)
                                          || x.StartsWith($"-{name}", StringComparison.OrdinalIgnoreCase));
            var split = argument?.Split(new[] { '=' }, count: 2);
            return allowEmptyString || !string.IsNullOrWhiteSpace(split?[1]) ? split?[1] : null;
        }

        /// Provides access to a converted command-line argument.
        [CanBeNull]
        public static T Argument<T> (string name)
        {
            var value = Argument(name);
            return (T) (Convert<T>(value) ?? default(T));
        }

        /// Provides access to a command-line argument using <see cref="ControlFlow.NotNull{T}"/>.
        public static string EnsureArgument (string name)
        {
            return Argument(name).NotNull($"Argument({name}) != null");
        }

        /// Checks if the specified command-line switch was passed.
        public static bool ArgumentSwitch (string name)
        {
            return Environment.GetCommandLineArgs()
                    .Any(x => x.Equals($"--{name}", StringComparison.OrdinalIgnoreCase)
                              || x.Equals($"-{name}", StringComparison.OrdinalIgnoreCase));
        }

        /// Provides access to a converted command-line argument using <see cref="ControlFlow.NotNull{T}"/>.
        public static T EnsureArgument<T> (string name)
        {
            var value = EnsureArgument(name);
            return (T) Convert<T>(value).NotNull($"Convert<{typeof(T)}>(EnsureArgument({name})) != null");
        }

        // TODO: move to own class?
        [CanBeNull]
        internal static object Convert<T> ([CanBeNull] string value)
        {
            return Convert(value, typeof(T));
        }

        [CanBeNull]
        internal static object Convert ([CanBeNull] string value, Type component)
        {
            if (value == null)
                return null;

            var typeConverter = TypeDescriptor.GetConverter(component);
            return typeConverter.ConvertFromInvariantString(value);
        }
    }
}
