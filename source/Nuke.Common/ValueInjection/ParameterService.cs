// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.Utilities.ReflectionUtility;

namespace Nuke.Common.ValueInjection
{
    internal class ParameterService
    {
        internal static ParameterService Instance = new ParameterService(
            () => EnvironmentInfo.CommandLineArguments.Skip(count: 1),
            () => EnvironmentInfo.Variables);

        internal ParameterService ArgumentsFromFilesService;
        internal ParameterService ArgumentsFromCommitMessageService;

        private readonly Func<IEnumerable<string>> _commandLineArgumentsProvider;
        private readonly Func<IReadOnlyDictionary<string, string>> _environmentVariablesProvider;

        public ParameterService(
            [CanBeNull] Func<IEnumerable<string>> commandLineArgumentsProvider,
            [CanBeNull] Func<IReadOnlyDictionary<string, string>> environmentVariablesProvider)
        {
            _commandLineArgumentsProvider = commandLineArgumentsProvider;
            _environmentVariablesProvider = environmentVariablesProvider;
        }

        private string[] Arguments => _commandLineArgumentsProvider.Invoke().ToArray();
        private IReadOnlyDictionary<string, string> Variables => _environmentVariablesProvider.Invoke();

        public static bool IsParameter(string value)
        {
            return value != null && value.StartsWith("-");
        }

        public static string GetParameterDashedName(MemberInfo member)
        {
            return GetParameterDashedName(GetParameterMemberName(member));
        }

        public static string GetParameterDashedName(string name)
        {
            return name.SplitCamelHumpsWithSeparator("-", Constants.KnownWords).ToLowerInvariant();
        }

        public static string GetParameterMemberName(string name)
        {
            return name.Replace("-", string.Empty);
        }

        public static string GetParameterMemberName<T>(Expression<Func<T>> expression)
        {
            var member = expression.GetMemberInfo();
            return GetParameterMemberName(member);
        }

        public static string GetParameterMemberName(MemberInfo member)
        {
            var attribute = member.GetCustomAttribute<ParameterAttribute>();
            var prefix = member.DeclaringType.NotNull().GetCustomAttribute<ParameterPrefixAttribute>()?.Prefix;
            return prefix + (attribute.Name ?? member.Name);
        }

        [CanBeNull]
        public static string GetParameterDescription(MemberInfo member)
        {
            var attribute = member.GetCustomAttribute<ParameterAttribute>();
            return attribute.Description?.TrimEnd('.');
        }

        [CanBeNull]
        public static IEnumerable<(string Text, object Object)> GetParameterValueSet(MemberInfo member, object instance)
        {
            var attribute = member.GetCustomAttribute<ParameterAttribute>();
            var memberType = member.GetMemberType().GetScalarType();

            IEnumerable<(string Text, object Object)> TryGetFromValueProvider()
            {
                if (attribute.ValueProviderMember == null)
                    return null;

                var valueProviderType = attribute.ValueProviderType ?? instance.GetType();
                var valueProvider = valueProviderType
                    .GetMember(attribute.ValueProviderMember, All)
                    .SingleOrDefault()
                    .NotNull($"No single provider '{valueProviderType.Name}.{member.Name}' found.");
                ControlFlow.Assert(valueProvider.GetMemberType() == typeof(IEnumerable<string>),
                    $"Value provider '{valueProvider.Name}' must be of type '{typeof(IEnumerable<string>).GetDisplayShortName()}'.");

                return valueProvider.GetValue<IEnumerable<string>>(instance).Select(x => (x, (object) x));
            }

            IEnumerable<(string Text, object Object)> TryGetFromEnumerationClass() =>
                memberType.IsSubclassOf(typeof(Enumeration))
                    ? memberType.GetFields(Static).Select(x => (x.Name, x.GetValue()))
                    : null;

            IEnumerable<(string Text, object Object)> TryGetFromEnum()
            {
                var enumType = memberType.IsEnum
                    ? memberType
                    : Nullable.GetUnderlyingType(memberType) is { } underlyingType && underlyingType.IsEnum
                        ? underlyingType
                        : null;
                return enumType != null
                    ? enumType.GetEnumNames().Select(x => (x, Enum.Parse(enumType, x)))
                    : null;
            }

            return (attribute.GetValueSet(member, instance) ??
                    TryGetFromValueProvider() ??
                    TryGetFromEnumerationClass() ??
                    TryGetFromEnum())
                ?.OrderBy(x => x.Item1);
        }

        [CanBeNull]
        public static object GetFromMemberInfo(MemberInfo member, [CanBeNull] Type destinationType, Func<string, Type, char?, object> provider)
        {
            var attribute = member.GetCustomAttribute<ParameterAttribute>();
            var separator = (attribute.Separator ?? string.Empty).SingleOrDefault();
            return provider.Invoke(GetParameterMemberName(member), destinationType ?? member.GetMemberType(), separator);
        }

        [CanBeNull]
        public object GetParameter(string parameterName, Type destinationType, char? separator)
        {
            object TryFromCommandLineArguments() =>
                HasCommandLineArgument(parameterName)
                    ? GetCommandLineArgument(parameterName, destinationType, separator)
                    : null;

            object TryFromCommandLinePositionalArguments() =>
                parameterName == Constants.InvokedTargetsParameterName
                    ? GetPositionalCommandLineArguments(destinationType, separator)
                    : null;

            object TryFromEnvironmentVariables() =>
                GetEnvironmentVariable(parameterName, destinationType, separator);

            // TODO: nuke <target> ?
            object TryFromProfileArguments() =>
                ArgumentsFromFilesService?.GetCommandLineArgument(parameterName, destinationType, separator);

            object TryFromCommitMessageArguments() =>
                ArgumentsFromCommitMessageService?.GetCommandLineArgument(parameterName, destinationType, separator);

            return TryFromCommitMessageArguments() ??
                   TryFromCommandLineArguments() ??
                   TryFromCommandLinePositionalArguments() ??
                   TryFromEnvironmentVariables() ??
                   TryFromProfileArguments();
        }

        [CanBeNull]
        public object GetCommandLineArgument(string argumentName, Type destinationType, char? separator)
        {
            var index = GetCommandLineArgumentIndex(argumentName);
            if (index == -1)
                return GetDefaultValue(destinationType);

            var values = Arguments.Skip(index + 1).TakeUntil(IsParameter).ToArray();
            return ConvertCommandLineArguments(argumentName, values, destinationType, Arguments, separator);
        }

        [CanBeNull]
        public object GetCommandLineArgument(int position, Type destinationType, char? separator)
        {
            var positionalParametersCount = Arguments.TakeUntil(IsParameter).Count();
            if (position < 0)
                position = positionalParametersCount + position % positionalParametersCount;

            if (positionalParametersCount <= position)
                return null;

            return ConvertCommandLineArguments(
                $"$positional[{position}]",
                new[] { Arguments[position] },
                destinationType,
                Arguments,
                separator);
        }

        [CanBeNull]
        public object GetPositionalCommandLineArguments(Type destinationType, char? separator = null)
        {
            var positionalArguments = Arguments.TakeUntil(IsParameter).ToArray();
            if (positionalArguments.Length == 0)
                return GetDefaultValue(destinationType);

            return ConvertCommandLineArguments(
                "$all-positional",
                positionalArguments,
                destinationType,
                Arguments,
                separator);
        }

        [CanBeNull]
        private object ConvertCommandLineArguments(
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

        public bool HasCommandLineArgument(string argumentName)
        {
            return GetCommandLineArgumentIndex(argumentName) != -1;
        }

        private int GetCommandLineArgumentIndex(string argumentName)
        {
            var index = Array.FindLastIndex(Arguments,
                x => IsParameter(x) && GetParameterMemberName(x).EqualsOrdinalIgnoreCase(GetParameterMemberName(argumentName)));

            // if (index == -1 && checkNames)
            // {
            //     var candidates = Arguments.Where(x => x.StartsWith("-")).Select(x => x.Replace("-", string.Empty));
            //     CheckNames(argumentName, candidates);
            // }

            return index;
        }

        [CanBeNull]
        public object GetEnvironmentVariable(string variableName, Type destinationType, char? separator)
        {
            static string GetTrimmedName(string name)
                => new string(name.Where(char.IsLetterOrDigit).ToArray());

            if (!Variables.TryGetValue(variableName, out var value))
            {
                var trimmedVariableName = GetTrimmedName(variableName);
                var alternativeValues = Variables
                    .Where(x => GetTrimmedName(x.Key).EqualsOrdinalIgnoreCase(trimmedVariableName) ||
                                GetTrimmedName(x.Key).EqualsOrdinalIgnoreCase($"NUKE{trimmedVariableName}")).ToList();
                ControlFlow.AssertWarn(alternativeValues.Count <= 1,
                    $"Could not resolve '{variableName}' since multiple possible sources exist:"
                        .Concat(alternativeValues.Select(x => $" - {x.Key} = {x.Value}")).JoinNewLine());
                if (alternativeValues.Count == 1)
                    value = alternativeValues.Single().Value;
                else
                    return GetDefaultValue(destinationType);
            }

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
            return type.IsNullableType() ? null : Activator.CreateInstance(type);
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

                return null;
            }

            var convertedValues = values.Select(x => Convert(x, elementType)).ToList();
            if (!destinationType.IsArray)
            {
                ControlFlow.Assert(convertedValues.Count == 1,
                    $"Value [ {values.JoinComma()} ] cannot be assigned to '{destinationType.GetDisplayShortName()}'.");
                return convertedValues.Single();
            }

            var array = Array.CreateInstance(elementType, convertedValues.Count);
            convertedValues.ForEach((x, i) => array.SetValue(x, i));
            ControlFlow.Assert(destinationType.IsInstanceOfType(array),
                $"Type '{array.GetType().GetDisplayShortName()}' is not an instance of '{destinationType.GetDisplayShortName()}'.");

            return array;
        }

        private void CheckNames(string name, IEnumerable<string> candidates)
        {
            const double similarityThreshold = 0.5;

            name = name.ToLower();
            foreach (var candidate in candidates.Select(x => x.ToLower()))
            {
                var levenshteinDistance = (float) GetLevenshteinDistance(name, candidate);
                if (levenshteinDistance / name.Length < similarityThreshold)
                {
                    Logger.Warn($"Requested parameter '{name}' was not found. Is there a typo with '{candidate}' which was passed?");
                    return;
                }
            }
        }

        private int GetLevenshteinDistance(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
                return 0;

            var lengthA = a.Length;
            var lengthB = b.Length;
            var distances = new int[lengthA + 1, lengthB + 1];

            for (var i = 0; i <= lengthA; distances[i, 0] = i++)
            {
            }

            for (var j = 0; j <= lengthB; distances[0, j] = j++)
            {
            }

            for (var i = 1; i <= lengthA; i++)
            for (var j = 1; j <= lengthB; j++)
            {
                var cost = b[j - 1] == a[i - 1] ? 0 : 1;
                distances[i, j] = Math.Min(
                    Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
                    distances[i - 1, j - 1] + cost
                );
            }

            return distances[lengthA, lengthB];
        }
    }
}
