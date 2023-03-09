// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;
using Xunit;

namespace Nuke.Common.Tests
{
    public class ArgumentsTest
    {
        private void Assert(Func<Arguments, Arguments> transform, string expected)
        {
            Assert(x => transform(x).ToString(), expected);
        }

        private void Assert(Func<Arguments, string> transform, string expected)
        {
            transform(new Arguments()).Should().Be(expected);
        }

        [Fact]
        public void TestBoolean()
        {
            Assert(x => x.Add("-unconditional"), "-unconditional");
            Assert(x => x.Add("-do-not-add", condition: false), "");
        }

        [Fact]
        public void TestValues()
        {
            Assert(x => x.Add("-arg {value}", "custom-value"), "-arg custom-value");
            Assert(x => x.Add("-arg {value}", (int?) null), "");
            Assert(x => x.Add("-arg {value}", value: 1), "-arg 1");
        }

        [Fact]
        public void TestSecret()
        {
            Assert(x => x.Add("-arg {value}", "secret", secret: true).RenderForOutput(), "-arg [REDACTED]");
            Assert(x => x.Add("-arg {value}", "secret", secret: true).RenderForExecution(), "-arg secret");
        }

        [Fact]
        public void TestList()
        {
            var files =
                new[]
                {
                    @"C:\new folder\file.txt",
                    @"C:\temp\file.txt"
                };

            Assert(x => x.Add(
                    "/files {value}",
                    files,
                    separator: ';'),
                @"/files ""C:\new folder\file.txt"";C:\temp\file.txt");

            Assert(x => x.Add(
                    "/files:{value}",
                    files,
                    disallowed: ' '),
                @"/files:""C:\new folder\file.txt"" /files:C:\temp\file.txt");

            Assert(x => x.Add(
                    "/filters:{value}",
                    new[] { "+[*]*", "-[xunit.*]*", "-[NUnit.*]*" },
                    separator: ' ',
                    quoteMultiple: true),
                @"/filters:""+[*]* -[xunit.*]* -[NUnit.*]*""");
        }

        [Fact]
        public void TestDictionary()
        {
            var dictionary =
                new Dictionary<string, string>
                {
                    { "a", @"C:\new folder\file.txt" },
                    { "b", "value" },
                    { "c", null },
                    { "d", "1;2;3" },
                    { "e", "x=z" }
                };

            Assert(x => x.Add(
                    "/p:{value}",
                    dictionary,
                    "{key}={value}",
                    separator: ';'),
                @"/p:a=""C:\new folder\file.txt"";b=value;d=""1;2;3"";e=""x=z""");

            Assert(x => x.Add(
                    "/p:{value}",
                    dictionary,
                    "{key}={value}",
                    disallowed: ';'),
                @"/p:a=""C:\new folder\file.txt"" /p:b=value /p:d=""1;2;3"" /p:e=""x=z""");
        }

        [Fact]
        public void TestLookup()
        {
            var lookup =
                new LookupTable<string, string>(
                    new Dictionary<string, List<string>>
                    {
                        { "category", new List<string> { "integration test", "web tests" } },
                        { "kind", new List<string> { "performance", "smoke" } }
                    });

            Assert(x => x.Add(
                    "-trait {value}",
                    lookup,
                    "{key}={value}",
                    separator: ';'),
                @"-trait category=""integration test"";""web tests"" -trait kind=performance;smoke");

            Assert(x => x.Add(
                    "-trait {value}",
                    lookup,
                    "{key}={value}",
                    disallowed: ';'),
                @"-trait category=""integration test"" -trait category=""web tests"" -trait kind=performance -trait kind=smoke");
        }

        [Fact]
        public void TestFilter()
        {
            Assert(x => x.Add("-arg {value}", "secret", secret: true).FilterSecrets("foosecretbar"), "foo[REDACTED]bar");
        }

        [Fact]
        public void TestConcatenate()
        {
            var args = new Arguments();
            args.Add("-arg {value}", "config2")
                .Add("definite");

            Assert(x => x.Add("-arg {value}", "config1")
                    .Add("-other-arg")
                    .Concatenate(args),
                "-arg config1 -other-arg -arg config2 definite");

            Assert(x => x.Add("-arg {value}", "config1")
                    .Add("-other-arg")
                    .Concatenate(args)
                    .Add("-arg {value}", "config3"),
                "-arg config1 -other-arg -arg config2 -arg config3 definite");
        }
    }
}
