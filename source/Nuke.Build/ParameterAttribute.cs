﻿// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;

namespace Nuke.Common;

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
/// </summary>
/// <example>
///     <code>
/// [Parameter("Configuration to build")] readonly Configuration Configuration;
/// [Parameter("API key for NuGet")] readonly string ApiKey;
/// [Parameter("Custom items")] readonly string[] Items;
///     </code>
/// </example>
[PublicAPI]
public class ParameterAttribute : ValueInjectionAttributeBase
{
    public ParameterAttribute(string description = null)
    {
        Description = description;
    }

    public virtual string Description { get; }

    [CanBeNull]
    public string Name { get; set; }

    [CanBeNull]
    public string Separator { get; set; }

    public virtual bool List { get; set; } = true;

    [CanBeNull]
    public Type ValueProviderType { get; set; }

    [CanBeNull]
    public string ValueProviderMember { get; set; }

    [CanBeNull]
    public override object GetValue(MemberInfo member, object instance)
    {
        return ParameterService.GetParameter<object>(member, member.GetMemberType().GetNullableType());
    }

    public virtual IEnumerable<(string, object)> GetValueSet(MemberInfo member, object instance)
    {
        return null;
    }
}

/// <summary>
/// Marks a member as being required for the whole build.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class RequiredAttribute : Attribute;

/// <summary>
/// Suppresses warning logging if value injection throws an exception.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class OptionalAttribute : Attribute;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class SecretAttribute : Attribute;

/// <summary>
/// Enables on-demand value injection, where non-parameter members are only injected if required by a target.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class OnDemandValueInjectionAttribute : Attribute;

/// <summary>
/// Marks a member to be injected only if required by a target.
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class OnDemandAttribute : Attribute;

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
public class ParameterPrefixAttribute : Attribute
{
    public ParameterPrefixAttribute(string prefix)
    {
        Prefix = prefix.TrimEnd("Prefix");
    }

    public string Prefix { get; }
}
