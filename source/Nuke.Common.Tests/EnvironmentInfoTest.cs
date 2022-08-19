// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Nuke.Common.IO;
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

        [Fact]
        public void TestPaths()
        {
            var paths = EnvironmentInfo.Paths;
            paths.Should().HaveCountGreaterThan(1);
            paths.Should().OnlyContain(x => PathConstruction.HasPathRoot(x));
        }
    }
}
