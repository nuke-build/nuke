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

        [CanBeNull]
        public static T GetVariable<T>(string name)
        {
            return ReflectionUtility.Convert<T>(Environment.GetEnvironmentVariable(name));
        }

        public static void SetVariable(string name, string value)
        {
            Environment.SetEnvironmentVariable(name, value);
        }

        public static void SetVariable<T>(string name, T value)
        {
            SetVariable(name, value.ToString());
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
