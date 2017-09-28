// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.Execution;
using Nuke.Core.Utilities;

namespace Nuke.Core
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static partial class EnvironmentInfo
    {
        private static readonly ParameterService s_parameterService = new ParameterService();

        public static void SetVariable(string name, string value)
        {
            Environment.SetEnvironmentVariable(name, value);
        }

        public static void SetVariable<T>(string name, IEnumerable<T> values, char separator)
        {
            SetVariable(name, values.Select(x => x.ToString()).Join(separator));
        }

        #region Parameter

        /// <summary>
        /// Provides access to a command-line argument or environment variable switch.
        /// </summary>
        public static bool ParameterSwitch(string name)
        {
            return s_parameterService.GetParameter<bool>(name);
        }

        /// <summary>
        /// Provides access to a command-line argument or environment variable.
        /// </summary>
        [CanBeNull]
        public static string Parameter(string name)
        {
            return s_parameterService.GetParameter<string>(name);
        }

        /// <summary>
        /// Provides access to a converted command-line argument or environment variable.
        /// </summary>
        [CanBeNull]
        public static T Parameter<T>(string name)
        {
            return s_parameterService.GetParameter<T>(name);
        }

        /// <summary>
        /// Provides ensured access to a command-line argument or environment variable.
        /// </summary>
        public static string EnsureParameter(string name)
        {
            return Parameter(name).NotNull($"Parameter('{name}') != null");
        }

        /// <summary>
        /// Provides ensured access to a converted command-line argument or environment variable.
        /// </summary>
        [CanBeNull]
        public static T EnsureParameter<T> (string name)
        {
            return Parameter<T>(name).NotNull($"Parameter<{typeof(T).Name}>('{name}') != null");
        }

        /// <summary>
        /// Provides access to a command-line argument or environment variable set.
        /// </summary>
        public static T[] ParameterSet<T>(string name, char? separator = null)
        {
            return s_parameterService.GetParameter<T[]>(name, separator).NotNull();
        }

        #endregion

        #region Variable

        /// <summary>
        /// Provides access to an environment variable switch.
        /// </summary>
        public static bool VariableSwitch (string name)
        {
            return s_parameterService.GetEnvironmentVariable<bool>(name);
        }

        /// <summary>
        /// Provides access to an environment variable.
        /// </summary>
        [CanBeNull]
        public static string Variable (string name)
        {
            return s_parameterService.GetEnvironmentVariable<string>(name);
        }

        /// <summary>
        /// Provides access to a converted environment variable.
        /// </summary>
        [CanBeNull]
        public static T Variable<T> (string name)
        {
            return s_parameterService.GetEnvironmentVariable<T>(name);
        }

        /// <summary>
        /// Provides ensured access to an environment variable.
        /// </summary>
        public static string EnsureVariable (string name)
        {
            return Variable(name).NotNull($"Variable('{name}') != null");
        }

        /// <summary>
        /// Provides ensured access to a converted environment variable.
        /// </summary>
        public static T EnsureVariable<T> (string name)
        {
            return Variable<T>(name).NotNull($"Variable<{typeof(T).Name}>('{name}') != null");
        }

        /// <summary>
        /// Provides access to an environment variable set.
        /// </summary>
        public static T[] VariableSet<T>(string name, char? separator = null)
        {
            return s_parameterService.GetEnvironmentVariable<T[]>(name, separator).NotNull();
        }

        #endregion

        #region Argument

        /// <summary>
        /// Provides access to a command-line argument switch.
        /// </summary>
        public static bool ArgumentSwitch (string name)
        {
            return s_parameterService.GetCommandLineArgument<bool>(name);
        }

        /// <summary>
        /// Provides access to a command-line argument.
        /// </summary>
        [CanBeNull]
        public static string Argument (string name)
        {
            return s_parameterService.GetCommandLineArgument<string>(name);
        }

        /// <summary>
        /// Provides access to a converted command-line argument.
        /// </summary>
        [CanBeNull]
        public static T Argument<T> (string name)
        {
            return s_parameterService.GetCommandLineArgument<T>(name);
        }

        /// <summary>
        /// Provides ensured access to a command-line argument.
        /// </summary>
        public static string EnsureArgument (string name)
        {
            return Argument(name).NotNull($"Argument('{name}') != null");
        }

        /// <summary>
        /// Provides ensured access to a converted command-line argument.
        /// </summary>
        public static T EnsureArgument<T> (string name)
        {
            return Argument<T>(name).NotNull($"Argument<{typeof(T).Name}>('{name}') != null");
        }

        /// <summary>
        /// Provides access to a command-line argument set.
        /// </summary>
        public static T[] ArgumentSet<T>(string name, char? separator = null)
        {
            return s_parameterService.GetCommandLineArgument<T[]>(name, separator).NotNull();
        }

        #endregion
    }
}
