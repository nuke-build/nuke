// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Core.Injection;

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
    ///     <see cref="ITargetDefinition.RequiresParameters{T}(System.Linq.Expressions.Expression{System.Func{T}}[])"/>.
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
    public class ParameterAttribute : InjectionAttributeBase
    {
        public ParameterAttribute (string description = null)
        {
        }

        public string Name { get; set; }
        public bool AllowEmptyString { get; set; }

        public override Type InjectionType => null;

        [CanBeNull]
        protected override object GetValue (FieldInfo field, NukeBuild buildInstance)
        {
            var attribute = field.GetCustomAttribute<ParameterAttribute>().NotNull("attribute != null");
            var stringValue = GetStringValue(field, attribute);
            if (stringValue == null)
                return null;

            try
            {
                return EnvironmentInfo.Convert(stringValue, field.FieldType);
            }
            catch
            {
                ControlFlow.Fail(
                    $"Value '{stringValue}' for parameter '{field.Name}' could not be converted to type '{field.FieldType.FullName}'.");
                return null;
            }
        }

        [CanBeNull]
        private static string GetStringValue (FieldInfo field, ParameterAttribute attribute)
        {
            var name = attribute.Name ?? field.Name;
            return EnvironmentInfo.Argument(name, attribute.AllowEmptyString)
                   ?? EnvironmentInfo.Variable(name)
                   ?? (field.FieldType == typeof(bool)
                       ? EnvironmentInfo.ArgumentSwitch(name).ToString()
                       : null);
        }
    }
}
