// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Utilities
{
    public static partial class ReflectionUtility
    {
        public static T Convert<T>(string value)
        {
            return (T)Convert(value, typeof(T));
        }

        [CanBeNull]
        public static object Convert(object value, Type destinationType)
        {
            if (destinationType.IsInstanceOfType(value))
                return value;

            if (destinationType == typeof(string) && value == null)
                return null;

            try
            {
                var typeConverter = TypeDescriptor.GetConverter(destinationType);
                return typeConverter.ConvertFromInvariantString(value?.ToString());
            }
            catch
            {
                Assert.Fail($"Value '{value}' could not be converted to '{destinationType.GetDisplayShortName()}'");
                // ReSharper disable once HeuristicUnreachableCode
                return null;
            }
        }

        // TODO: rename overloads?
        [CanBeNull]
        public static object Convert(string value, Type destinationType, char? separator)
        {
            return Convert(separator.HasValue ? value.Split(separator.Value) : new[] { value }, destinationType);
        }

        [CanBeNull]
        public static object Convert(IReadOnlyCollection<string> values, Type destinationType)
        {
            Assert.True(!destinationType.IsArray || destinationType.GetArrayRank() == 1, "Arrays must have a rank of 1");
            var elementType = (destinationType.IsArray ? destinationType.GetElementType() : destinationType).NotNull();
            Assert.True(values.Count < 2 || elementType != null, "values.Count < 2 || elementType != null");

            if (values.Count == 0)
            {
                if (destinationType.IsArray)
                    return Array.CreateInstance(elementType, length: 0);

                if (destinationType == typeof(bool) || destinationType == typeof(bool?))
                    return true;

                return null;
            }

            var convertedValues = values.Select(x => Convert(x, elementType)).ToList();
            if (!destinationType.IsArray)
            {
                Assert.HasSingleItem(convertedValues,
                    $"Value [ {values.JoinCommaSpace()} ] cannot be assigned to '{destinationType.GetDisplayShortName()}'");
                return convertedValues.Single();
            }

            var array = Array.CreateInstance(elementType, convertedValues.Count);
            convertedValues.ForEach((x, i) => array.SetValue(x, i));
            Assert.True(destinationType.IsInstanceOfType(array),
                $"Type '{array.GetType().GetDisplayShortName()}' is not an instance of '{destinationType.GetDisplayShortName()}'.");

            return array;
        }
    }
}
