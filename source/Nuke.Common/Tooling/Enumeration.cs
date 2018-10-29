// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tooling
{
    [Serializable]
    [PublicAPI]
    public abstract class Enumeration
    {
        protected string Value { get; set; }

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
                    var matchingFields = typeof(T).GetFields(ReflectionService.Static)
                        .Where(x => x.Name.EqualsOrdinalIgnoreCase(stringValue)).ToList();
                    ControlFlow.Assert(matchingFields.Count == 1, "matchingFields.Count == 1");
                    return matchingFields.Single().GetValue(obj: null);
                }

                return base.ConvertFrom(context, culture, value);
            }
        }
    }
}
