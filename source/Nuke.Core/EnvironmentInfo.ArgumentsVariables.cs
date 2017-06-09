// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.Execution;

namespace Nuke.Core
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    [IconClass("chip")]
    public static partial class EnvironmentInfo
    {
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

        /// Provides access to an environment variable using <see cref="ControlFlow.AssertNotNull{T}"/>.
        public static string EnsureVariable (string name)
        {
            return Variable(name).AssertNotNull($"Variable({name}) != null");
        }

        /// Provides access to a converted variable using <see cref="ControlFlow.AssertNotNull{T}"/>.
        public static T EnsureVariable<T> (string name)
        {
            var value = EnsureVariable(name);
            return (T) Convert<T>(value).AssertNotNull($"Convert<{typeof (T)}>(EnsureVariable({name})) != null");
        }


        /// Provides access to a command line argument.
        [CanBeNull]
        public static string Argument (string name)
        {
            var argument = Environment.GetCommandLineArgs()
                    .SingleOrDefault(x => x.StartsWith($"--{name}", StringComparison.OrdinalIgnoreCase)
                                          || x.StartsWith($"-{name}", StringComparison.OrdinalIgnoreCase));
            var split = argument?.Split(new[] { '=' }, count: 2);
            return !string.IsNullOrWhiteSpace(split?[1]) ? split[1] : null;
        }

        /// Provides access to a converted command line argument.
        [CanBeNull]
        public static T Argument<T> (string name)
        {
            var value = Argument(name);
            return (T) (Convert<T>(value) ?? default(T));
        }

        /// Provides access to a command line argument using <see cref="ControlFlow.AssertNotNull{T}"/>.
        public static string EnsureArgument (string name)
        {
            return Argument(name).AssertNotNull($"Argument({name}) != null");
        }

        /// Checks if the specified switch was passed.
        public static bool ArgumentSwitch (string name)
        {
            return Environment.GetCommandLineArgs()
                    .Any(x => x.Equals($"--{name}", StringComparison.OrdinalIgnoreCase)
                              || x.Equals($"-{name}", StringComparison.OrdinalIgnoreCase));
        }

        /// Provides access to a converted command line argument using <see cref="ControlFlow.AssertNotNull{T}"/>.
        public static T EnsureArgument<T> (string name)
        {
            var value = EnsureArgument(name);
            return (T) Convert<T>(value).AssertNotNull($"Convert<{typeof(T)}>(EnsureArgument({name})) != null");
        }


        [CanBeNull]
        private static object Convert<T> ([CanBeNull] string value)
        {
            if (value == null)
                return null;

            var typeConverter = TypeDescriptor.GetConverter(typeof(T));
            return typeConverter.ConvertFromInvariantString(value);
        }
    }
}
