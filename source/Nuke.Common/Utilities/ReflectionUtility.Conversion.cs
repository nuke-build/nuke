// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.ComponentModel;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities
{
    public static partial class ReflectionUtility
    {
        public static T Convert<T>(string value)
        {
            return (T) Convert(value, typeof(T));
        }

        [CanBeNull]
        public static object Convert(object value, System.Type destinationType)
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
                var errorMessage = $"Value '{value}' could not be converted to '{GetDisplayShortName(destinationType)}'.";

                // Check if we have an enum type, if so list the possible values in the error message.
                var enumType = Nullable.GetUnderlyingType(destinationType) ?? destinationType;
                if (enumType.IsEnum)
                    errorMessage += $" Accepted values are: {string.Join(", ", Enum.GetNames(enumType))}";

                Assert.Fail(errorMessage);
                // ReSharper disable once HeuristicUnreachableCode
                return null;
            }
        }
    }
}
