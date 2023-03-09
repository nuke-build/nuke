// Copyright 2023 Maintainers of NUKE.
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
using Serilog;
using static Nuke.Common.Utilities.ReflectionUtility;

namespace Nuke.Common
{
    internal partial class ParameterService
    {
        internal ArgumentParser ArgumentsFromFilesService;
        internal ArgumentParser ArgumentsFromCommitMessageService;

        private readonly Func<ArgumentParser> _argumentParserProvider;
        private readonly Func<IReadOnlyDictionary<string, string>> _environmentVariablesProvider;

        public ParameterService(
            [CanBeNull] Func<ArgumentParser> argumentParserProvider,
            [CanBeNull] Func<IReadOnlyDictionary<string, string>> environmentVariablesProvider)
        {
            _argumentParserProvider = argumentParserProvider;
            _environmentVariablesProvider = environmentVariablesProvider;
        }

        private ArgumentParser ArgumentsParser => _argumentParserProvider.Invoke();
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
            return name.SplitCamelHumpsWithKnownWords().JoinDash().ToLowerInvariant();
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
                    .NotNull($"No single provider '{valueProviderType.Name}.{member.Name}' found");
                Assert.True(valueProvider.GetMemberType() == typeof(IEnumerable<string>),
                    $"Value provider '{valueProvider.Name}' must be of type '{typeof(IEnumerable<string>).GetDisplayShortName()}'");

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

            try
            {
                return (attribute.GetValueSet(member, instance) ??
                        TryGetFromValueProvider() ??
                        TryGetFromEnumerationClass() ??
                        TryGetFromEnum())
                    ?.OrderBy(x => x.Item1);
            }
            catch (Exception exception)
            {
                Log.Warning(exception.Unwrap(), "Could not resolve value-set for {Parameter}", member.GetDisplayName());
                return null;
            }
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
                ArgumentsFromFilesService?.GetNamedArgument(parameterName, destinationType, separator);

            object TryFromCommitMessageArguments() =>
                ArgumentsFromCommitMessageService?.GetNamedArgument(parameterName, destinationType, separator);

            return TryFromCommitMessageArguments() ??
                   TryFromCommandLineArguments() ??
                   TryFromCommandLinePositionalArguments() ??
                   TryFromEnvironmentVariables() ??
                   TryFromProfileArguments();
        }

        [CanBeNull]
        public object GetCommandLineArgument(string argumentName, Type destinationType, char? separator)
        {
            return ArgumentsParser.GetNamedArgument(argumentName, destinationType, separator);
        }

        [CanBeNull]
        public object GetCommandLineArgument(int position, Type destinationType, char? separator)
        {
            return ArgumentsParser.GetPositionalArgument(position, destinationType, separator);
        }

        [CanBeNull]
        public object GetPositionalCommandLineArguments(Type destinationType, char? separator = null)
        {
            return ArgumentsParser.GetAllPositionalArguments(destinationType, separator);
        }

        public bool HasCommandLineArgument(string argumentName)
        {
            return ArgumentsParser.HasArgument(argumentName);
        }

        [CanBeNull]
        public object GetEnvironmentVariable(string variableName, Type destinationType, char? separator)
        {
            static string GetTrimmedName(string name)
                => new(name.Where(char.IsLetterOrDigit).ToArray());

            if (!Variables.TryGetValue(variableName, out var value))
            {
                var trimmedVariableName = GetTrimmedName(variableName);
                var alternativeValues = Variables
                    .Where(x => GetTrimmedName(x.Key).EqualsOrdinalIgnoreCase(trimmedVariableName) ||
                                GetTrimmedName(x.Key).EqualsOrdinalIgnoreCase($"NUKE{trimmedVariableName}")).ToList();
                if (alternativeValues.Count > 1)
                    Log.Warning("Could not resolve {VariableName} since multiple values are provided", variableName);

                if (alternativeValues.Count == 1)
                    value = alternativeValues.Single().Value;
                else
                    return destinationType.GetDefaultValue();
            }

            try
            {
                return ConvertValues(variableName, separator.HasValue ? value.Split(separator.Value) : new[] { value }, destinationType);
            }
            catch (Exception ex)
            {
                Assert.Fail(new[] { ex.Message, "Environment variable was:", value }.JoinNewLine());
                // ReSharper disable once HeuristicUnreachableCode
                return null;
            }
        }

        [CanBeNull]
        private object ConvertValues(string parameterName, IReadOnlyCollection<string> values, Type destinationType)
        {
            try
            {
                return Convert(values, destinationType);
            }
            catch (Exception ex)
            {
                Assert.Fail(new[] { $"Resolving parameter '{parameterName}' failed.", ex.Message }.JoinNewLine());
                // ReSharper disable once HeuristicUnreachableCode
                return null;
            }
        }
    }
}
