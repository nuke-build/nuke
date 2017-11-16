// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Core.Utilities;

namespace Nuke.Core.Injection
{
    [PublicAPI]
    public static class InjectedValueProvider
    {
        private const BindingFlags c_bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        [CanBeNull]
        public static T GetStaticValue<T> ()
        {
            var fieldsWithAttributes = (
                from field in NukeBuild.Instance.GetType().GetFields(c_bindingFlags)
                from attribute in field.GetCustomAttributes<StaticInjectionAttributeBase>()
                where attribute.InjectionType == typeof(T)
                select new { Field = field, Attribute = attribute }).ToList();

            if (fieldsWithAttributes.Count == 0)
                return default(T);
            ControlFlow.Assert(fieldsWithAttributes.Count == 1,
                new[] { $"Requested value of type '{typeof(T).Name}' has multiple matching fields:" }
                        .Concat(fieldsWithAttributes.Select(x => $"  - {x.Field.Name} ({x.Attribute.GetType().Name})"))
                        .JoinNewLine());

            var fieldWithAttribute = fieldsWithAttributes.Single();
            return (T) fieldWithAttribute.Attribute.GetStaticValue();
        }
    }
}
