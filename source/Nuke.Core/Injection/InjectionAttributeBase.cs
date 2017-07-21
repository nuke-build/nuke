// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Nuke.Core.Injection
{
    /// <summary>
    ///     Marks a field for automatic value injection prior to build execution. Fields marked
    ///     with the attribute can be declared as <em>requirement</em> for any <see cref="Target" />
    ///     definitions using <see cref="ITargetDefinition.Requires"/>,
    ///     <see cref="ITargetDefinition.Requires{T}(System.Linq.Expressions.Expression{System.Func{T}}[])" />, or
    ///     <see cref="ITargetDefinition.Requires{T}(System.Linq.Expressions.Expression{System.Func{T?}}[])" />
    ///     and will therefore be subject for validation at execution start.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    [MeansImplicitUse(ImplicitUseKindFlags.Default)]
    public abstract class InjectionAttributeBase : Attribute
    {
        [CanBeNull]
        public abstract Type InjectionType { get; }

        [CanBeNull]
        protected abstract object GetValue (FieldInfo field, NukeBuild buildInstance);

        internal void InjectValue (FieldInfo field, NukeBuild buildInstance)
        {
            var value = GetValue(field, buildInstance);
            if (value == null)
                return;

            if (InjectionType != null)
            {
                var valueType = value.GetType();
                ControlFlow.Assert(valueType == InjectionType,
                    $"Value returned from '{GetType().Name}' must be of type '{InjectionType.Name}' but '{valueType.Name}'.");
            }

            field.SetValue(NukeBuild.Instance, value);
        }
    }
}
