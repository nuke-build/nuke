// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Nuke.Common.Utilities;
using Xunit;

namespace Nuke.Common.Tests
{
    public class StringExtensionsTest
    {
        [Theory]
        [InlineData("a b c", "\"a b c\"")]
        [InlineData("\"a b c\"", "\"a b c\"")]
        public void Test(string input, string output)
        {
            input.DoubleQuoteIfNeeded().Should().Be(output);
        }

        [Theory]
        [InlineData("arg", '\"', "arg")]
        [InlineData("\"arg\"", '\"', "arg")]
        [InlineData("\"\"arg\"\"", '\"', "\"arg\"")]
        [InlineData("\"arg", '\"', "\"arg")]
        [InlineData("arg\"", '\"', "arg\"")]
        public void TestTrimMatchingQuotes(string input, char quote, string expected)
        {
            input.TrimMatchingQuotes(quote).Should().Be(expected);
        }

        [Fact]
        public void TestSplit()
        {
            "msbuild-configuration".Split(x => !char.IsLetter(x))
                .Should().Equal("msbuild", "configuration");

            "MSBuildConfiguration".SplitCamelHumps()
                .Should().Equal("MSBuild", "Configuration");
        }
    }
}
