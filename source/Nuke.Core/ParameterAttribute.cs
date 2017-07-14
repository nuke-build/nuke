// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace Nuke.Core
{
    /// <summary>
    ///     Marks a field for automatic parameter injection prior to build execution. Fields marked
    ///     with the attribute can be declared as <em>required</em> for any <see cref="Target" />
    ///     definitions and will therefore be subject for validation at execution start.
    ///     <para/>
    ///     Parameters are resolved case-insensitively in the following order:
    ///     <ul>
    ///         <li>From command-line arguments (e.g., <c>--myArgument=value</c>)</li>
    ///         <li>From environment variables (e.g., <c>MyArgument=value</c>)</li>
    ///     </ul>
    ///     <para/>
    ///     For value-types, there is a distinction between pure value-types, and their null-able
    ///     counterparts. For instance, <c>int</c> will have its default value <c>0</c> even if it wasn't
    ///     supplied via command-line or environment variable, and therefore also can't be used in
    ///     <see cref="ITargetDefinition.RequiresParameters{T}(Expression{Func{T}}[])"/>. Declaring
    ///     the field as <c>int?</c> however, will enable validation and setting the requirement.
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
    [AttributeUsage(AttributeTargets.Field)]
    [MeansImplicitUse(ImplicitUseKindFlags.Assign)]
    public class ParameterAttribute : Attribute
    {
        public ParameterAttribute (string description = null)
        {
            Description = description;
        }

        [CanBeNull]
        public string Description { get; }

        [CanBeNull]
        public string Name { get; set; }

        public bool AllowEmptyString { get; set; }
    }
}
