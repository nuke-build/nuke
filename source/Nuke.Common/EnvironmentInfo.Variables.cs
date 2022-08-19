// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.ValueInjection;

namespace Nuke.Common
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static partial class EnvironmentInfo
    {
        public static IReadOnlyDictionary<string, string> Variables
            => Environment.GetEnvironmentVariables().ToGeneric<string, string>(StringComparer.CurrentCulture);

        public static IReadOnlyCollection<string> Paths
            => GetVariable<string[]>(s_pathVariableName, s_pathVariableSeparator).NotNull()
                .Select(ExpandVariables).ToList();

        private static readonly string s_pathVariableName = Variables.Single(x => x.Key.EqualsOrdinalIgnoreCase("PATH")).Key;
        private static readonly char s_pathVariableSeparator = IsWin ? ';' : ':';

        [CanBeNull]
        public static string GetVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }

        [CanBeNull]
        public static T GetVariable<T>(string name, char? separator = null)
        {
            return (T)ReflectionUtility.Convert(GetVariable(name), typeof(T), separator);
        }

        public static void SetVariable(string name, string value)
        {
            Environment.SetEnvironmentVariable(name, value);
        }

        public static void SetVariable<T>(string name, T value)
        {
            SetVariable(name, value.ToString());
        }

        public static void RemoveVariable(string name)
        {
            SetVariable(name, value: null);
        }

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
