// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static partial class EnvironmentInfo
    {
        /// <summary>
        /// Returns a dictionary of environment variables for the current process.
        /// </summary>
        public static IReadOnlyDictionary<string, string> Variables
            => Environment.GetEnvironmentVariables().ToGeneric<string, string>(StringComparer.CurrentCulture);

        /// <summary>
        /// Returns all paths from the <em>PATH</em> environment variable.
        /// </summary>
        public static IReadOnlyCollection<string> Paths
            => GetVariable<string[]>(s_pathVariableName, s_pathVariableSeparator).NotNull()
                .Select(ExpandVariables).ToList();

        private static readonly string s_pathVariableName = Variables.Single(x => x.Key.EqualsOrdinalIgnoreCase("PATH")).Key;
        private static readonly char s_pathVariableSeparator = IsWin ? ';' : ':';

        /// <summary>
        /// Indicates whether the environment variable exists.
        /// </summary>
        public static bool HasVariable(string name, bool allowEmpty = true)
        {
            var value = GetVariable(name);
            return value != null && (!value.IsNullOrEmpty() || allowEmpty);
        }

        /// <summary>
        /// Returns the value from an environment variable.
        /// </summary>
        [CanBeNull]
        public static string GetVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }

        /// <summary>
        /// Returns the converted value from an environment variable.
        /// </summary>
        [CanBeNull]
        public static T GetVariable<T>(string name, char? separator = null)
        {
            var value = GetVariable(name);
            if (value == null)
                return default;

            return (T)ReflectionUtility.Convert(value, typeof(T), separator);
        }

        /// <summary>
        /// Sets the value for an environment variable.
        /// </summary>
        public static void SetVariable(string name, string value)
        {
            Environment.SetEnvironmentVariable(name, value);
        }

        /// <summary>
        /// Sets the value obtained via <see cref="object.ToString"/> for an environment variable.
        /// </summary>
        public static void SetVariable<T>(string name, T value)
        {
            SetVariable(name, value.ToString());
        }

        /// <summary>
        /// Removes an environment variable by setting the value to <c>null</c>.
        /// </summary>
        public static void RemoveVariable(string name)
        {
            SetVariable(name, value: null);
        }

        /// <summary>
        /// Expands environment variables in a string.
        /// </summary>
        public static string ExpandVariables(string value)
        {
            string ExpandUnixEnvironmentVariables()
                => value
                    .ReplaceRegex("^~", _ => Environment.GetEnvironmentVariable("HOME"))
                    .ReplaceRegex(@"\$([a-z_][a-z0-9_]*)", x => Environment.GetEnvironmentVariable(x.Groups[1].Value), RegexOptions.IgnoreCase);

            return IsWin
                ? Environment.ExpandEnvironmentVariables(value)
                : ExpandUnixEnvironmentVariables();
        }
    }
}
