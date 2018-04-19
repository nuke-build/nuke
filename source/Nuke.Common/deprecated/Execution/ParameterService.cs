// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.Utilities;
using Nuke.Core.Utilities.Collections;

namespace Nuke.Core.Execution
{
    public class ParameterService
    {
        private static ParameterService s_instance;

        private readonly string[] _commandLineArguments;
        private readonly Func<IReadOnlyDictionary<string, string>> _environmentVariablesProvider;

        public ParameterService(
            [CanBeNull] string[] commandLineArguments = null,
            [CanBeNull] IReadOnlyDictionary<string, string> environmentVariables = null)
        {
            _environmentVariablesProvider = () => environmentVariables ?? EnvironmentInfo.Variables;
            _commandLineArguments = commandLineArguments ?? EnvironmentInfo.CommandLineArguments;
        }

        public static ParameterService Instance => s_instance ?? (s_instance = new ParameterService());

        [CanBeNull]
        public T GetParameter<T>(string parameterName, char? separator = null)
        {
            return (T) GetParameter(parameterName, typeof(T), separator);
        }

        [CanBeNull]
        public T GetCommandLineArgument<T>(string parameterName, char? separator = null)
        {
            return (T) GetCommandLineArgument(parameterName, typeof(T), separator);
        }

        [CanBeNull]
        public T GetCommandLineArgument<T>(int position, char? separator = null)
        {
            return (T) GetCommandLineArgument(position, typeof(T), separator);
        }

        [CanBeNull]
        public T GetEnvironmentVariable<T>(string parameterName, char? separator = null)
        {
            return (T) GetEnvironmentVariable(parameterName, typeof(T), separator);
        }

        [CanBeNull]
        public object GetParameter(string parameterName, Type destinationType, char? separator = null)
        {
            return HasCommandLineArgument(parameterName)
                ? GetCommandLineArgument(parameterName, destinationType, separator)
                : GetEnvironmentVariable(parameterName, destinationType, separator);
        }

        [CanBeNull]
        public object GetCommandLineArgument(string argumentName, Type destinationType, char? separator = null)
        {
            var index = Array.FindLastIndex(_commandLineArguments, x => x.EqualsOrdinalIgnoreCase($"-{argumentName}"));
            if (index == -1)
                return GetDefaultValue(destinationType);

            var values = _commandLineArguments.Skip(index + 1).TakeWhile(x => !x.StartsWith("-")).ToArray();
            return ConvertCommandLineArguments(argumentName, values, destinationType, _commandLineArguments, separator);
        }

        [CanBeNull]
        public object GetCommandLineArgument(int position, Type destinationType, char? separator = null)
        {
            var positionalParametersCount = _commandLineArguments.TakeWhile(x => !x.StartsWith("-")).Count();

            if (position < 0)
                position = positionalParametersCount - 1;
            
            if (positionalParametersCount <= position)
                return null;

            return ConvertCommandLineArguments(
                $"positional[{position}]",
                new[] { _commandLineArguments[position] },
                destinationType,
                _commandLineArguments,
                separator);
        }

        [CanBeNull]
        public object ConvertCommandLineArguments(
            string argumentName,
            string[] values,
            Type destinationType,
            string[] commandLineArguments,
            char? separator = null)
        {
            ControlFlow.Assert(values.Length == 1 || !separator.HasValue || values.All(x => !x.Contains(separator.Value)),
                $"Command-line argument '{argumentName}' with value [ {values.JoinComma()} ] cannot be split with separator '{separator}'.");
            values = separator.HasValue && values.Any(x => x.Contains(separator.Value))
                ? values.SingleOrDefault()?.Split(separator.Value) ?? new string[0]
                : values;

            try
            {
                return ConvertValues(argumentName, values, destinationType);
            }
            catch (Exception ex)
            {
                ControlFlow.Fail(
                    new[] { ex.Message, "Command-line arguments were:" }
                        .Concat(commandLineArguments.Select((x, i) => $"  [{i}] = {x}"))
                        .JoinNewLine());
                // ReSharper disable once HeuristicUnreachableCode
                return null;
            }
        }

        private bool HasCommandLineArgument(string argumentName)
        {
            return Array.FindLastIndex(_commandLineArguments, x => x.EqualsOrdinalIgnoreCase($"-{argumentName}")) != -1;
        }

        [CanBeNull]
        public object GetEnvironmentVariable(string variableName, Type destinationType, char? separator = null)
        {
            var variables = _environmentVariablesProvider.Invoke();

            if (!variables.TryGetValue(variableName, out var value))
                return GetDefaultValue(destinationType);

            try
            {
                return ConvertValues(variableName, separator.HasValue ? value.Split(separator.Value) : new[] { value }, destinationType);
            }
            catch (Exception ex)
            {
                ControlFlow.Fail(new[] { ex.Message, "Environment variable was:", value }.JoinNewLine());
                // ReSharper disable once HeuristicUnreachableCode
                return null;
            }
        }

        [CanBeNull]
        private object GetDefaultValue(Type type)
        {
            if (Nullable.GetUnderlyingType(type) == null && type != typeof(string) && !type.IsArray)
                return Activator.CreateInstance(type);
            return null;
        }

        [CanBeNull]
        private object ConvertValues(string parameterName, IReadOnlyCollection<string> values, Type destinationType)
        {
            try
            {
                return ConvertValues(values, destinationType);
            }
            catch (Exception ex)
            {
                ControlFlow.Fail(new[] { $"Resolving parameter '{parameterName}' failed.", ex.Message }.JoinNewLine());
                // ReSharper disable once HeuristicUnreachableCode
                return null;
            }
        }

        [CanBeNull]
        private object ConvertValues(IReadOnlyCollection<string> values, Type destinationType)
        {
            ControlFlow.Assert(!destinationType.IsArray || destinationType.GetArrayRank() == 1, "Arrays must have a rank of 1.");
            var elementType = (destinationType.IsArray ? destinationType.GetElementType() : destinationType).NotNull();
            ControlFlow.Assert(values.Count < 2 || elementType != null, "values.Count < 2 || elementType != null");

            if (values.Count == 0)
            {
                if (destinationType.IsArray)
                    return Array.CreateInstance(elementType, length: 0);

                if (destinationType == typeof(bool) || destinationType == typeof(bool?))
                    return true;

                if (elementType == typeof(string) || Nullable.GetUnderlyingType(elementType) != null)
                    return null;
            }

            var convertedValues = values.Select(x => Convert(x, elementType)).ToList();
            if (!destinationType.IsArray)
            {
                ControlFlow.Assert(convertedValues.Count == 1, $"Value [ {values.JoinComma()} ] cannot be assigned to '{GetName(destinationType)}'.");
                return convertedValues.Single();
            }

            var array = Array.CreateInstance(elementType, convertedValues.Count);
            convertedValues.ForEach((x, i) => array.SetValue(x, i));
            ControlFlow.Assert(destinationType.IsInstanceOfType(array),
                $"Type '{GetName(array.GetType())}' is not an instance of '{GetName(destinationType)}'.");

            return array;
        }

        [CanBeNull]
        private object Convert(string value, Type destinationType)
        {
            try
            {
                var typeConverter = TypeDescriptor.GetConverter(destinationType);
                return typeConverter.ConvertFromInvariantString(value);
            }
            catch
            {
                ControlFlow.Fail($"Value '{value}' could not be converted to '{GetName(destinationType)}'.");
                // ReSharper disable once HeuristicUnreachableCode
                return null;
            }
        }

        private string GetName(Type type)
        {
            if (type.IsArray)
                return $"{type.GetElementType().NotNull().Name}[]";

            var underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
                return underlyingType.Name + "?";

            return type.Name;
        }
    }
}
