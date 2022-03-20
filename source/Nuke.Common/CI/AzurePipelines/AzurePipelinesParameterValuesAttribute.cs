// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.AzurePipelines
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Field)]
    public class AzurePipelinesParameterValuesAttribute : Attribute
    {
        public string[] Values { get; set; }

        public AzurePipelinesParameterValuesAttribute(params string[] values)
        {
            Values = values;
        }

        public string[] GetValues(object defaultValue, Type memberType)
        {
            var valuesSet = new HashSet<string>(Values);

            var enumType = memberType.IsArray ? memberType.GetElementType() : memberType;
            if(valuesSet.IsEmpty() && enumType.IsEnum)
            {
                return Enum.GetNames(enumType);
            }

            if (defaultValue == null)
                return valuesSet.ToArray();

            var defaultString = defaultValue?.ToString();
            if (!string.IsNullOrWhiteSpace(defaultString))
            {
                if (memberType.IsArray && defaultValue is IEnumerable enumerable)
                {
                    var defaultStringList = enumerable.Cast<object>().Select(x => x.ToString());
                    defaultStringList.ForEach(x => valuesSet.Add(x));
                }
                else
                {
                    valuesSet.Add(defaultValue.ToString());
                }
            }

            return valuesSet.ToArray();
        }
    }
}
