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
    /// <inheritdoc/>
    /// <summary>
    ///     <inheritdoc/><para/>
    ///     Parameters are resolved case-insensitively in the following order:
    ///     <ul>
    ///         <li>From command-line arguments (e.g., <c>--myArgument=value</c>)</li>
    ///         <li>From environment variables (e.g., <c>MyArgument=value</c>)</li>
    ///     </ul>
    ///     <para/>
    ///     For value-types, there is a distinction between pure value-types, and their <em>nullable</em>
    ///     counterparts. For instance, <c>int</c> will have its default value <c>0</c> even if it wasn't
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
        public ParameterAttribute (string description = null)
        {
        }

        public string Name { get; set; }
        public bool AllowEmptyString { get; set; }
        public string Separator { get; set; }

        public override Type InjectionType => null;

        [CanBeNull]
        public override object GetValue (string memberName, Type memberType, NukeBuild build)
        {
            var stringValue = GetStringValue(memberName, memberType);
            if (stringValue == null)
                return null;

            if (memberType == typeof(string[]))
            {
                ControlFlow.Assert(Separator != null, "Separator != null");
                return stringValue.Split(new[] { Separator },
                    AllowEmptyString ? StringSplitOptions.None : StringSplitOptions.RemoveEmptyEntries);
            }

            var conversionType = GetConversionType(memberType);
            try
            {
                return EnvironmentInfo.Convert(stringValue, conversionType);
            }
            catch
            {
                ControlFlow.Fail(
                    $"Value '{stringValue}' for parameter '{memberName}' could not be converted to type '{conversionType.FullName}'.");
                return null;
            }
        }

        [CanBeNull]
        private string GetStringValue (string memberName, Type memberType)
        {
            var name = Name ?? memberName;
            return EnvironmentInfo.Argument(name, AllowEmptyString)
                   ?? EnvironmentInfo.Variable(name)
                   ?? (memberType == typeof(bool)
                       ? EnvironmentInfo.ArgumentSwitch(name).ToString()
                       : null);
        }

        private static Type GetConversionType (Type memberType)
        {
            if (memberType != typeof(string) && !memberType.IsArray && Nullable.GetUnderlyingType(memberType) == null)
                return typeof(Nullable<>).MakeGenericType(memberType);

            return memberType;
        }
    }
}
