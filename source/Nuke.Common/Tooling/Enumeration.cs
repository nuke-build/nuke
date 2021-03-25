// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tooling
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumValueAttribute : Attribute
    {
        public EnumValueAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }

    public static class EnumerationExtensions
    {
        public static string GetValue<T>(this T value)
            where T : Enum
        {
            var name = Enum.GetName(typeof(T), value).NotNull($"Enum value {value} is not valid for {typeof(T).Name}");
            var member = typeof(T).GetMember(name).Single();
            var attribute = member.GetCustomAttribute<EnumValueAttribute>();
            return attribute != null
                ? attribute.Value
                : value.ToString();
        }
    }

    [Serializable]
    [PublicAPI]
    public abstract class Enumeration
    {
        protected string Value { get; set; }

        public static implicit operator string([CanBeNull] Enumeration value)
        {
            return value?.Value;
        }

        public static bool operator ==(Enumeration a, Enumeration b)
        {
            return EqualityComparer<Enumeration>.Default.Equals(a, b);
        }

        public static bool operator !=(Enumeration a, Enumeration b)
        {
            return !EqualityComparer<Enumeration>.Default.Equals(a, b);
        }

        protected bool Equals(Enumeration other)
        {
            return string.Equals(Value, other.Value);
        }

        public override bool Equals([CanBeNull] object obj)
        {
            if (ReferenceEquals(objA: null, objB: obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Enumeration) obj);
        }

        public override int GetHashCode()
        {
            // ReSharper disable NonReadonlyMemberInGetHashCode
            return Value != null ? Value.GetHashCode() : 0;
            // ReSharper restore NonReadonlyMemberInGetHashCode
        }

        public override string ToString()
        {
            return Value.NotNull("Value != null");
        }

        public class TypeConverter<T> : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
            }

            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                if (value is string stringValue)
                {
                    var matchingFields = typeof(T).GetFields(ReflectionUtility.Static)
                        .Where(x => x.Name.EqualsOrdinalIgnoreCase(stringValue)).ToList();
                    ControlFlow.Assert(matchingFields.Count == 1, "matchingFields.Count == 1");
                    return matchingFields.Single().GetValue(obj: null);
                }

                return base.ConvertFrom(context, culture, value);
            }
        }
    }
}
