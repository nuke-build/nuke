// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Nuke.Common.IO;
using Nuke.Common.Utilities.Collections;
using Xunit;
using static Nuke.Common.Utilities.ReflectionUtility;

namespace Nuke.Common.Tests
{
    public class ParameterServiceTest
    {
        private ParameterService GetService(string[] commandLineArguments = null, IDictionary<string, string> environmentVariables = null)
        {
            commandLineArguments ??= new string[0];
            environmentVariables ??= new Dictionary<string, string>();

            return new ParameterService(
                () => new ArgumentParser(commandLineArguments),
                () => environmentVariables.AsReadOnly());
        }

        [Theory]
        [InlineData(typeof(bool), false)]
        [InlineData(typeof(bool?), null)]
        [InlineData(typeof(int), 0)]
        [InlineData(typeof(int?), null)]
        [InlineData(typeof(string), null)]
        [InlineData(typeof(string[]), null)]
        [InlineData(typeof(AbsolutePath), null)]
        public void TestNotSupplied(Type destinationType, object expectedValue)
        {
            GetService().GetParameter("notsupplied", destinationType, separator: null).Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("arg1", typeof(string), "value1")]
        [InlineData("arg2", typeof(string), "value3")]
        [InlineData("switch2", typeof(bool), true)]
        [InlineData("switch3", typeof(bool), false)]
        [InlineData("notsupplied1", typeof(bool), false)]
        [InlineData("notsupplied2", typeof(int?), null)]
        public void TestEnvironmentVariables(string parameter, Type destinationType, object expectedValue)
        {
            var service = GetService(
                new[]
                {
                    "-arg1",
                    "value1",
                    "-switch1"
                },
                new Dictionary<string, string>
                {
                    { "arg1", "value2" },
                    { "arg2", "value3" },
                    { "switch2", "true" },
                    { "switch3", "false" }
                });
            service.GetParameter(parameter, destinationType, separator: null).Should().Be(expectedValue);
        }

        [Fact]
        public void TestExpression()
        {
            var service = GetService(
                new[]
                {
                    "--string",
                    "--set",
                    "1",
                    "2",
                    "3",
                    "--interface-param"
                });

            var build = new TestBuild();

            ParameterService.GetFromMemberInfo(GetMemberInfo(() => build.String), typeof(AbsolutePath), service.GetParameter)
                .Should().BeNull();

            ParameterService.GetFromMemberInfo(GetMemberInfo(() => build.String), typeof(bool), service.GetParameter)
                .Should().BeOfType<bool>().Subject.Should().BeTrue();

            ParameterService.GetFromMemberInfo(GetMemberInfo(() => build.Set), destinationType: null, service.GetParameter)
                .Should().BeOfType<int[]>().Subject.Should().BeEquivalentTo(new[] { 1, 2, 3 });

            ParameterService.GetFromMemberInfo(GetMemberInfo(() => ((ITestComponent)build).Param), destinationType: null, service.GetParameter)
                .Should().BeOfType<bool>().Subject.Should().BeTrue();
        }

        [Fact]
        public void TestValueSet()
        {
            var build = new TestBuild();
            var verbosities = new[]
                              {
                                  (nameof(Verbosity.Minimal), Verbosity.Minimal),
                                  (nameof(Verbosity.Normal), Verbosity.Normal),
                                  (nameof(Verbosity.Quiet), Verbosity.Quiet),
                                  (nameof(Verbosity.Verbose), Verbosity.Verbose),
                              };
            ParameterService.GetParameterValueSet(GetMemberInfo(() => NukeBuild.Verbosity), instance: null)
                .Should().BeEquivalentTo(verbosities);
            ParameterService.GetParameterValueSet(GetMemberInfo(() => build.Verbosities), instance: null)
                .Should().BeEquivalentTo(verbosities);
        }

        [Fact]
        public void TestPrecedence()
        {
            var emptyArguments = new ArgumentParser(string.Empty);
            var emptyEnvironmentVariables = new Dictionary<string, string>();

            var environmentVariables = new Dictionary<string, string> { ["string"] = "environmentVariables" };
            var commandLineArguments = new ArgumentParser("--string commandLine");
            var parameterFileArguments = new ArgumentParser("--string parameterFile");
            var commitMessageArguments = new ArgumentParser("--string commitMessage");

            var service = new ParameterService(() => emptyArguments, () => emptyEnvironmentVariables)
                          {
                              ArgumentsFromFilesService = parameterFileArguments
                          };
            service.GetParameter("string", typeof(string), separator: null).Should().Be("parameterFile");

            service = new ParameterService(() => emptyArguments, () => environmentVariables) { ArgumentsFromFilesService = parameterFileArguments };
            service.GetParameter("string", typeof(string), separator: null).Should().Be("environmentVariables");

            service = new ParameterService(() => commandLineArguments, () => environmentVariables);
            service.GetParameter("string", typeof(string), separator: null).Should().Be("commandLine");

            service = new ParameterService(() => emptyArguments, () => emptyEnvironmentVariables)
                      {
                          ArgumentsFromFilesService = parameterFileArguments,
                          ArgumentsFromCommitMessageService = commitMessageArguments
                      };
            service.GetParameter("string", typeof(string), separator: null).Should().Be("commitMessage");
        }

#pragma warning disable CS0649
        private class TestBuild : NukeBuild, ITestComponent
        {
            [Parameter] public string String;
            [Parameter] public int[] Set;
            [Parameter] public Verbosity[] Verbosities;
        }

        [ParameterPrefix("Interface")]
        private interface ITestComponent : INukeBuild
        {
            [Parameter] bool Param => TryGetValue<bool?>(() => Param) ?? false;
        }
#pragma warning restore CS0649
    }
}
