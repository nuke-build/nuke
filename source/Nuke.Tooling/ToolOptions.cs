﻿// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tooling;

// TODO: rename to TaskOptions / CommandOptions ?
[PublicAPI]
public abstract partial class ToolOptions : Options
{
    internal static event EventHandler Created;

    private readonly Dictionary<string, PropertyInfo> _allProperties;

    protected ToolOptions()
    {
        _allProperties = GetType().GetAllMembers(x => x is PropertyInfo, ReflectionUtility.Instance, allowAmbiguity: true)
            .Cast<PropertyInfo>().ToDictionary(x => x.Name, x => x);

        Set(() => ProcessEnvironmentVariables, EnvironmentInfo.Variables);
        Created?.Invoke(this, EventArgs.Empty);
    }

    internal partial IEnumerable<string> GetArguments();
    internal partial IEnumerable<string> GetSecrets();
    internal partial Action<OutputType, string> GetLogger();
}
