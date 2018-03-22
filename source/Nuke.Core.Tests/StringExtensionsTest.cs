// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Nuke.Core.Utilities;
using Xunit;

namespace Nuke.Core.Tests
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
        [InlineData("arg",'\"',"arg")]
        [InlineData("\"arg\"", '\"', "arg")]
        [InlineData("\"\"arg\"\"", '\"', "\"arg\"")]
        [InlineData("\"arg", '\"', "\"arg")]
        [InlineData("arg\"", '\"', "arg\"")]
        public void TestTrimMatchingQuotes(string input, char quote, string expected)
        {
            input.TrimMatchingQuotes(quote).Should().Be(expected);
        }
    }
}
