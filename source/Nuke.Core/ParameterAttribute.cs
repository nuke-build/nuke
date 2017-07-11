// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core
{
    // TODO: remarks about parameter type
    /// <summary>
    ///     <p>
    ///         Marks a field for parameter injection with an optional description that is printed when using <c>--help</c> on
    ///         command-line. Fields marked with the attribute can be declared as required for certain <see cref="Target" />
    ///         definitions and will therefore be subject for validation prior to build execution.
    ///     </p>
    ///     <p>
    ///         Parameters are resolved case-insensitively in the following order:
    ///         <ul>
    ///             <li>From command-line arguments (e.g., <c>--myArgument=value</c>)</li>
    ///             <li>From environment variables (e.g., <c>MyArgument=value</c>)</li>
    ///         </ul>
    ///     </p>
    /// </summary>
    /// <example>
    ///     <code>
    /// [Parameter("MyGet API key for 'nukebuild' feed."]
    /// string MyGetApiKey;
    /// 
    /// Target Push => _ => _
    ///         .Requires(() => MyGetApiKey)
    ///         .Executes() => { /* ... */ });
    /// </code>
    /// </example>
    // TODO: strict mode for value-types?
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Field)]
    [MeansImplicitUse(ImplicitUseKindFlags.Assign)]
    public class ParameterAttribute : Attribute
    {
        public ParameterAttribute (string description = null, string name = null)
        {
            Description = description;
            Name = name;
        }

        [CanBeNull]
        public string Description { get; }

        [CanBeNull]
        public string Name { get; }

    }
}
