// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.Execution;
using Nuke.Core.Injection;

namespace Nuke.Core
{
    /// <inheritdoc/>
    /// <summary>
    ///     <inheritdoc/><para/>
    ///     Parameters are resolved case-insensitively in the following order:
    ///     <ul>
    ///         <li>From command-line arguments (e.g., <c>-arg value</c>)</li>
    ///         <li>From environment variables (e.g., <c>Arg=value</c>)</li>
    ///     </ul>
    ///     <para/>
    ///     For value-types, there is a distinction between pure value-types, and their <em>nullable</em>
    ///     counterparts. For instance, <c>int</c> will have its default value <c>0</c> even when it's not
    ///     supplied via command-line or environment variable, and therefore also can't be used as requirements.
    ///     Declaring the field as <c>int?</c> however, will enable validation and setting the requirement.
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
        private static readonly ParameterService s_parameterService = new ParameterService();

        public ParameterAttribute(string description = null)
        {
            Description = description;
        }

        [CanBeNull]
        public string Description { get; }

        public string Name { get; set; }
        public string Separator { get; set; }

        [CanBeNull]
        public override object GetValue(string memberName, Type memberType)
        {
            memberType = Nullable.GetUnderlyingType(memberType) == null
                         && memberType != typeof(string)
                         && !memberType.IsArray
                ? typeof(Nullable<>).MakeGenericType(memberType)
                : memberType;
            return s_parameterService.GetParameter(Name ?? memberName, memberType, (Separator ?? string.Empty).SingleOrDefault());
        }
    }
}
