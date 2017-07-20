// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Nuke.Core.Injection
{
    [AttributeUsage(AttributeTargets.Field)]
    [MeansImplicitUse(ImplicitUseKindFlags.Default)]
    public abstract class InjectionAttributeBase : Attribute
    {
        [CanBeNull]
        public abstract Type InjectionType { get; }

        [CanBeNull]
        protected abstract object GetValue (FieldInfo field, Build buildInstance);

        internal void InjectValue (FieldInfo field, Build buildInstance)
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

            field.SetValue(Build.Instance, value);
        }
    }
}
