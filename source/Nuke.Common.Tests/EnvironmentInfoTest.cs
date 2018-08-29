// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Nuke.Common.Tests
{
    public class EnvironmentInfoTest
    {
        [Theory]
        [InlineData("arg0 arg1 arg2", new[] { "arg0", "arg1", "arg2" })]
        [InlineData("\"arg0 arg1\" arg2", new[] { "arg0 arg1", "arg2" })]
        [InlineData("'arg0 arg1' arg2", new[] { "arg0 arg1", "arg2" })]
        [InlineData("'arg0 \"arg1' arg2", new[] { "arg0 \"arg1", "arg2" })]
        [InlineData("'arg0 \"arg1\"' arg2", new[] { "arg0 \"arg1\"", "arg2" })]
        [InlineData("\"arg0 'arg1\" arg2", new[] { "arg0 'arg1", "arg2" })]
        [InlineData("\"arg0 'arg1'\" arg2", new[] { "arg0 'arg1'", "arg2" })]
        [InlineData("\"arg0 \\\"arg1\\\"\" arg2", new[] { "arg0 \"arg1\"", "arg2" })]
        [InlineData("'arg0 \\'arg1\\'' arg2", new[] { "arg0 'arg1'", "arg2" })]
        [InlineData("\\\\ \\ \\\\", new[] { "\\\\", "\\", "\\\\" })]
        public void TestParseCommandLineArguments(string commandLine, string[] expected)
        {
            var arguments = EnvironmentInfo.ParseCommandLineArguments(commandLine);

            arguments.Should().BeEquivalentTo(expected);
        }
    }
}
