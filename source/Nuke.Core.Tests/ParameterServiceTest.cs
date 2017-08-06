// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using JetBrains.Annotations;
using Nuke.Core.Execution;
using Nuke.Core.Utilities;
using Xunit;

namespace Nuke.Core.Tests
{
    public class ParameterServiceTest
    {
        [CanBeNull]
        private static T GetParameter<T> (string parameterName, char? separator = null)
        {
            return (T) ParameterService.GetParameter(parameterName, typeof(T), separator);
        }

        private static IDisposable SetProviders (string[] commandLineArguments = null, IDictionary environmentVariables = null)
        {
            commandLineArguments = commandLineArguments ?? new string[0];
            environmentVariables = environmentVariables ?? new Dictionary<string, string>();

            var fields = typeof(ParameterService).GetFields(BindingFlags.NonPublic | BindingFlags.Static);
            var argumentsField = fields.Single(x => x.FieldType == typeof(Func<string[]>));
            var variablesField = fields.Single(x => x.FieldType == typeof(Func<IDictionary>));

            var oldArgumentsProvider = argumentsField.GetValue(obj: null);
            var oldVariablesProvider = variablesField.GetValue(obj: null);

            return DelegateDisposable.CreateBracket(
                () =>
                {
                    argumentsField.SetValue(obj: null, value: new Func<string[]>(() => commandLineArguments));
                    variablesField.SetValue(obj: null, value: new Func<IDictionary>(() => environmentVariables));
                },
                () =>
                {
                    argumentsField.SetValue(obj: null, value: oldArgumentsProvider);
                    variablesField.SetValue(obj: null, value: oldVariablesProvider);
                });
        }

        [Theory]
        [InlineData("configuration", typeof(string), "release")]
        [InlineData("AMOUNT", typeof(int), 5)]
        [InlineData("noLogo", typeof(bool), true)]
        [InlineData("nodeps", typeof(bool), false)]
        public void TestConversion (string argument, Type destinationType, object expectedValue)
        {
            var commandLineArguments =
                    new[]
                    {
                        "-nologo",
                        "-configuration",
                        "release",
                        "-files",
                        "C:\\new folder\\file.txt",
                        "C:\\file.txt",
                        "-amount",
                        "5",
                        "-nodeps",
                        "false"
                    };

            using (SetProviders(commandLineArguments))
            {
                ParameterService.GetCommandLineArgument(argument, destinationType).Should().Be(expectedValue);
            }
        }

        [Theory]
        [InlineData(typeof(bool), false)]
        [InlineData(typeof(bool?), null)]
        [InlineData(typeof(int), 0)]
        [InlineData(typeof(int?), null)]
        [InlineData(typeof(string), null)]
        public void TestNotSupplied (Type destinationType, object expectedValue)
        {
            using (SetProviders())
            {
                ParameterService.GetCommandLineArgument("notsupplied", destinationType).Should().Be(expectedValue);
            }
        }

        [Fact]
        public void TestNotSuppliedCollection ()
        {
            using (SetProviders())
            {
                GetParameter<string[]>("notsupplied").Should().NotBeNull().And.BeEmpty();
                GetParameter<int[]>("notsupplied").Should().NotBeNull().And.BeEmpty();
            }
        }

        [Theory]
        [InlineData("arg1", typeof(string), "value1")]
        [InlineData("arg2", typeof(string), "value3")]
        [InlineData("switch2", typeof(bool), true)]
        [InlineData("switch3", typeof(bool), false)]
        [InlineData("notsupplied1", typeof(bool), false)]
        [InlineData("notsupplied2", typeof(int?), null)]
        public void TestEnvironmentVariables (string parameter, Type destinationType, object expectedValue)
        {
            var commandLineArguments =
                    new[]
                    {
                        "-arg1",
                        "value1",
                        "-switch1"
                    };
            var environmentVariables =
                    new Dictionary<string, string>
                    {
                        { "arg1", "value2" },
                        { "arg2", "value3" },
                        { "switch2", "true" },
                        { "switch3", "false" }
                    };

            using (SetProviders(commandLineArguments, environmentVariables))
            {
                ParameterService.GetParameter(parameter, destinationType).Should().Be(expectedValue);
            }
        }

        [Fact]
        public void TestConversionSpecial ()
        {
            var dateTime = DateTime.Now;
            var guid = Guid.NewGuid();
            var commandLineArguments =
                    new[]
                    {
                        "-guid",
                        $"{guid}",
                        "-datetime",
                        $"{dateTime.ToString(CultureInfo.CurrentCulture)}"
                    };

            using (SetProviders(commandLineArguments))
            {
                GetParameter<DateTime>("datetime").Should().BeCloseTo(dateTime, precision: 1000);
                GetParameter<Guid>("guid").Should().Be(guid);
            }
        }

        [Fact]
        public void TestConversionCollections ()
        {
            var commandLineArguments =
                    new[]
                    {
                        "-files",
                        "C:\\new folder\\file.txt",
                        "C:\\file.txt",
                        "-amount",
                        "5"
                    };
            var environmentVariables =
                    new Dictionary<string, string>
                    {
                        { "values", "A+B+C" }
                    };

            using (SetProviders(commandLineArguments, environmentVariables))
            {
                GetParameter<string[]>("files").Should().BeEquivalentTo("C:\\new folder\\file.txt", "C:\\file.txt");
                GetParameter<string[]>("values", separator: '+').Should().BeEquivalentTo("A", "B", "C");
            }
        }
    }
}
