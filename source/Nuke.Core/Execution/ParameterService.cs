// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.Utilities;
using Nuke.Core.Utilities.Collections;

namespace Nuke.Core.Execution
{
    public static class ParameterService
    {
        private static readonly Func<string[]> s_commandLineArgumentsProvider = () => Environment.GetCommandLineArgs();
        private static readonly Func<IDictionary> s_environmentVariablesProvider = () => Environment.GetEnvironmentVariables();

        [CanBeNull]
        public static T GetParameter<T> (string parameterName, char? separator = null)
        {
            return (T) GetParameter(parameterName, typeof(T), separator);
        }

        [CanBeNull]
        public static T GetCommandLineArgument<T> (string parameterName, char? separator = null)
        {
            return (T) GetCommandLineArgument(parameterName, typeof(T), separator);
        }

        [CanBeNull]
        public static T GetEnvironmentVariable<T> (string parameterName, char? separator = null)
        {
            return (T) GetEnvironmentVariable(parameterName, typeof(T), separator);
        }

        [CanBeNull]
        public static object GetParameter (string parameterName, Type destinationType, char? separator = null)
        {
            return HasCommandLineArgument(parameterName)
                ? GetCommandLineArgument(parameterName, destinationType, separator)
                : GetEnvironmentVariable(parameterName, destinationType, separator);
        }

        [CanBeNull]
        public static object GetCommandLineArgument (string argumentName, Type destinationType, char? separator = null)
        {
            var args = s_commandLineArgumentsProvider.Invoke();
            var index = Array.FindLastIndex(args, x => x.EqualsOrdinalIgnoreCase($"-{argumentName}"));
            if (index == -1)
                return GetDefaultValue(destinationType);

            var values = args.Skip(index + 1).TakeWhile(x => !x.StartsWith("-")).ToArray();
            ControlFlow.Assert(values.Length == 1 || !separator.HasValue || values.All(x => !x.Contains(separator.Value)),
                $"Command-line argument '{argumentName}' with value [ {values.Join(", ")} ] cannot be split with separator '{separator}'.");
            return ConvertValues(argumentName, separator.HasValue ? values.Single().Split(separator.Value) : values, destinationType);
        }

        private static bool HasCommandLineArgument (string argumentName)
        {
            var args = s_commandLineArgumentsProvider.Invoke();
            return Array.FindLastIndex(args, x => x.EqualsOrdinalIgnoreCase($"-{argumentName}")) != -1;
        }

        [CanBeNull]
        public static object GetEnvironmentVariable (string variableName, Type destinationType, char? separator = null)
        {
            var variables = s_environmentVariablesProvider.Invoke();
            var value = variables.Contains(variableName) ? (string) variables[variableName] : null;
            if (value == null)
                return GetDefaultValue(destinationType);

            return ConvertValues(variableName, separator.HasValue ? value.Split(separator.Value) : new[] { value }, destinationType);
        }

        [CanBeNull]
        private static object GetDefaultValue (Type type)
        {
            if (type.IsArray)
                return Array.CreateInstance(type.GetElementType(), length: 0);

            if (Nullable.GetUnderlyingType(type) == null && type != typeof(string))
                return Activator.CreateInstance(type);

            return null;
        }

        private static object ConvertValues (string parameterName, IReadOnlyCollection<string> values, Type destinationType)
        {
            try
            {
                return ConvertValues(values, destinationType);
            }
            catch
            {
                ControlFlow.Fail(
                    $"Parameter '{parameterName}' with value [ {values.Join(", ")} ] could not be converted to '{destinationType.Name}'.");
                return null;
            }
        }

        public static object ConvertValues (IReadOnlyCollection<string> values, Type destinationType)
        {
            var elementType = destinationType.IsArray ? destinationType.GetElementType() : destinationType;
            ControlFlow.Assert(values.Count < 2 || elementType != null, "values.Count < 2 || elementType != null");

            if (values.Count == 0 && destinationType == typeof(bool))
                return true;

            var convertedValues = values.Select(x => Convert(x, elementType)).ToList();
            if (convertedValues.Count == 1)
                return convertedValues.Single();

            var array = Array.CreateInstance(elementType, convertedValues.Count);
            convertedValues.ForEach((x, i) => array.SetValue(x, i));
            return array;
        }

        [CanBeNull]
        public static object Convert (string value, Type destinationType)
        {
            try
            {
                var typeConverter = TypeDescriptor.GetConverter(destinationType);
                return typeConverter.ConvertFromInvariantString(value);
            }
            catch (FormatException)
            {
                ControlFlow.Fail($"Value '{value}' could not be converted to '{destinationType.Name}'.");
                return null;
            }
        }
    }
}
