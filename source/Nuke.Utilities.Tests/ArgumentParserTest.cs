// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Nuke.Common.Tests
{
    public class ArgumentParserTest
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
        public void TestParse(string commandLine, string[] expected)
        {
            var parser = new ArgumentParser(commandLine);

            parser.Arguments.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void TestNamed()
        {
            var parser = new ArgumentParser(new[] { "--string", "foobar" });

            parser.HasArgument("string").Should().BeTrue();

            parser.GetNamedArgument("string", typeof(string)).Should().Be("foobar");
            parser.GetNamedArgument("STRING", typeof(string)).Should().Be("foobar");
            parser.GetNamedArgument("STR-ING", typeof(string)).Should().Be("foobar");
        }

        [Fact]
        public void TestBoolean()
        {
            var parser = new ArgumentParser("--switch --true-bool true --false-bool false");

            parser.GetNamedArgument("switch", typeof(bool))
                .Should().BeOfType<bool>().Which
                .Should().BeTrue();
            parser.GetNamedArgument("true-bool", typeof(bool))
                .Should().BeOfType<bool>().Which
                .Should().BeTrue();
            parser.GetNamedArgument("false-bool", typeof(bool))
                .Should().BeOfType<bool>().Which
                .Should().BeFalse();
            parser.GetNamedArgument("non-existent-bool", typeof(bool?))
                .Should().BeNull();
        }

        [Fact]
        public void TestCollections()
        {
            var parser = new ArgumentParser("--empty-collection --space-collection 1 2 --plus-collection 1+2");

            parser.GetNamedArgument("empty-collection", typeof(string[]))
                .Should().BeOfType<string[]>().Which
                .Should().BeEmpty();
            parser.GetNamedArgument("non-existent-collection", typeof(string[]))
                .Should().BeNull();

            parser.GetNamedArgument("space-collection", typeof(int[]), separator: ' ')
                .Should().BeOfType<int[]>().Which
                .Should().HaveCount(2);
            parser.GetNamedArgument("plus-collection", typeof(int[]), separator: '+')
                .Should().BeOfType<int[]>().Which
                .Should().HaveCount(2);
        }

        [Theory]
        [InlineData(new[] { "1", "2", "3" }, new[] { 1, 2, 3 })]
        [InlineData(new[] { "1", "2", "--named", "3" }, new[] { 1, 2 })]
        [InlineData(new[] { "--named", "3" }, null)]
        public void TestAllPositional(string[] arguments, int[] expected)
        {
            var parser = new ArgumentParser(arguments);
            parser.GetAllPositionalArguments(typeof(int[])).Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(new[] { "arg1" }, 0, typeof(string), "arg1")]
        [InlineData(new[] { "true" }, 0, typeof(bool), true)]
        [InlineData(new[] { "arg1" }, 1, typeof(string), null)]
        [InlineData(new[] { "arg1", "arg2" }, 1, typeof(string), "arg2")]
        [InlineData(new[] { "posArg", "--named", "value" }, 0, typeof(string), "posArg")]
        [InlineData(new[] { "posArg", "--named", "value" }, 1, typeof(string), null)]
        [InlineData(new[] { "posArg", "--named", "value" }, 2, typeof(string), null)]
        // From end
        [InlineData(new[] { "arg1", "arg2", "arg3" }, -1, typeof(string), "arg3")]
        [InlineData(new[] { "arg1", "arg2", "arg3" }, -2, typeof(string), "arg2")]
        public void TestPositional(string[] arguments, int position, Type destinationType, object expected)
        {
            var parser = new ArgumentParser(arguments);
            parser.GetPositionalArgument(position, destinationType).Should().Be(expected);
        }
    }
}
