// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.Utilities.Collections;

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
    /// [Parameter("API key for NuGet"] string ApiKey;
    /// Target Push => _ => _
    ///     .Requires(() => ApiKey)
    ///     .Executes() =>
    ///     {
    ///         // NuGetPush with ApiKey
    ///     });
    ///     </code>
    /// </example>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Assign)]
    public class ParameterAttribute : InjectionAttributeBase
    {
        public ParameterAttribute(string description = null)
        {
            Description = description ?? "<no description>";
        }

        public string Description { get; }

        [CanBeNull]
        public string Name { get; set; }
        
        [CanBeNull]
        public string Separator { get; set; }

        [CanBeNull]
        public override object GetValue(MemberInfo member, Type buildType)
        {
            return ParameterService.Instance.GetParameter<object>(member);
        }
    }
}
