﻿// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Execution;

namespace Nuke.Common
{
    /// <inheritdoc/>
    /// <summary>
    ///     Injected parameters are resolved case-insensitively in the following order:
    ///     <ul>
    ///         <li>From command-line arguments (e.g., <c>-arg value</c>)</li>
    ///         <li>From environment variables (e.g., <c>Arg=value</c>)</li>
    ///     </ul>
    ///     <para/>
    ///     For value-types, there is a distinction between pure value-types, and their <em>nullable</em>
    ///     counterparts. For instance, <c>int</c> will have its default value <c>0</c> even when it's not
    ///     supplied via command-line or environment variable.
    ///     <para/>
    ///     <inheritdoc/>
    /// </summary>
    /// <example>
    ///     <code>
    /// [Parameter("MyGet API key for private feed."] string MyGetApiKey;
    /// Target Push => _ => _
    ///         .Requires(() => MyGetApiKey)
    ///         .Executes() => { /* ... */ });
    ///     </code>
    /// </example>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Assign)]
    public class ParameterAttribute : InjectionAttributeBase
    {
        public ParameterAttribute(string description = null)
        {
            Description = description;
        }

        [CanBeNull]
        public string Description { get; }

        public string Name { get; set; }
        public string Separator { get; set; }

        [CanBeNull]
        public override object GetValue(string memberName, Type memberType, Type buildType)
        {
            if (Nullable.GetUnderlyingType(memberType) == null &&
                memberType != typeof(string) &&
                !memberType.IsClass &&
                !memberType.IsArray)
                memberType = typeof(Nullable<>).MakeGenericType(memberType);
            
            return ParameterService.Instance.GetParameter(
                parameterName: Name ?? memberName,
                destinationType: memberType,
                separator: (Separator ?? string.Empty).SingleOrDefault(),
                checkNames: true);
        }
    }
}
