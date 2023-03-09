// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI
{
    [PublicAPI]
    [TypeConverter(typeof(TypeConverter))]
    public class Partition
    {
        public static Partition Single { get; } = new() { Part = 1, Total = 1 };

        public int Part { get; set; }
        public int Total { get; set; }

        public class TypeConverter : System.ComponentModel.TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
            }

            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                if (value is string stringValue)
                {
                    var values = stringValue.Split('/');
                    return new Partition
                           {
                               Part = int.Parse(values[0]),
                               Total = int.Parse(values[1])
                           };
                }

                return base.ConvertFrom(context, culture, value);
            }
        }

        public bool IsIn(int part)
        {
            return Total == 1 || part == Part;
        }

        public IEnumerable<T> GetCurrent<T>(IEnumerable<T> enumerable)
        {
            var i = 0;
            foreach (var item in enumerable)
            {
                if (i == Part - 1)
                    yield return item;
                i = (i + 1) % Total;
            }
        }

        public override string ToString()
        {
            return $"{Part}/{Total}";
        }
    }
}
