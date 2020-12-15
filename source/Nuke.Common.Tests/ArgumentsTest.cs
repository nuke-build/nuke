// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities;
using Xunit;

namespace Nuke.Common.Tests
{
    public class ArgumentParserTest
    {
        [Theory]
        [InlineData("build", nameof(DotNetTasks.DotNetBuild), 0)]
        [InlineData("build Solution.sln --no-restore", nameof(DotNetTasks.DotNetBuild), 2)]
        [InlineData("nuget push Package.nupkg", nameof(DotNetTasks.DotNetNuGetPush), 1)]
        [InlineData("nuget add source https://nuget.org", nameof(DotNetTasks.DotNetNuGetAddSource), 1)]
        public void TestMethodMatcher(string arguments, string methodName, int argumentsLeft)
        {
            var parsedArguments = EnvironmentInfo.ParseCommandLineArguments(arguments);
            var (method, trimmedArguments) = MatchMethod(
                parsedArguments,
                typeof(DotNetTasks).GetMethods(BindingFlags.Static | BindingFlags.Public),
                x => x.GetCustomAttribute<CommandFormatAttribute>()?.Format);

            method.Name.Should().Be(methodName);
            trimmedArguments.Should().HaveCount(argumentsLeft);
        }

        private (T Method, string[] TrimmedArguments) MatchMethod<T>(string[] arguments, IEnumerable<T> methods, Func<T, string> commandSelector)
        {
            var match = methods
                .Select(x => (Method: x, Command: commandSelector(x)))
                .Where(x => x.Command != null).ToList()
                .Select(x => (x.Method, x.Command, Splitted: x.Command.Split(' ')))
                .OrderByDescending(x => x.Splitted.Length)
                .First(x => x.Splitted.SequenceEqual(arguments.Take(x.Splitted.Length)));
            // .First(x => arguments.StartsWithOrdinalIgnoreCase(x.Command));

            return (match.Method, arguments.Skip(match.Command.Split(' ').Length).ToArray());
        }

        [Fact]
        public void TestDataExtractor()
        {
            var properties = typeof(DotNetBuildSettings).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var arguments = ExtractMetadata(
                properties,
                x => x.GetCustomAttribute<ArgumentFormatAttribute>()?.Format,
                x => x.GetCustomAttribute<ItemFormatAttribute>()?.Format,
                x => x.GetCustomAttribute<SeparatorAttribute>()?.Separator,
                x => x.GetCustomAttributes<DelegateAttribute>().Select(x => (x.Delegate, x.Separator))).ToList();

            var arg1 = arguments.Single(x => x.Property.Name == nameof(DotNetBuildSettings.NoRestore));
            arg1.ArgumentFormat.Should().Be("--no-restore");
            arg1.ItemFormat.Should().Be(null);
            arg1.Separator.Should().Be(null);
        }

        private IEnumerable<ArgumentData<T>> ExtractMetadata<T>(
            IEnumerable<T> properties,
            Func<T, string> argumentFormatSelector,
            Func<T, string> itemFormatSelector,
            Func<T, string> separatorSelector,
            Func<T, IEnumerable<(string, string)>> delegateSelector)
        {
            return properties.Select(x =>
                    new ArgumentData<T>
                    {
                        Property = x,
                        ArgumentFormat = argumentFormatSelector(x),
                        ItemFormat = itemFormatSelector(x),
                        Separator = separatorSelector(x),
                        Delegates = delegateSelector(x).Select(x => new DelegateData { Name = x.Item1, Separator = x.Item2 }).ToArray()
                    })
                .Where(x => x.ArgumentFormat != null);
        }

        public struct ArgumentData<T>
        {
            public T Property { get; set; }
            public string ArgumentFormat { get; set; }
            public string ItemFormat { get; set; }
            public string Separator { get; set; }
            public DelegateData[] Delegates { get; set; }

            private const string Value = "{value}";
            private const string Key = "{key}";
            public (string Prefix, string Postfix) GetArgumentSuffixes()
            {
                var index = ArgumentFormat.IndexOf(Value);
                return index == -1
                    ? (ArgumentFormat, string.Empty)
                    : (ArgumentFormat.Substring(0, index), ArgumentFormat.Substring(index + Value.Length));
            }
        }

        public struct DelegateData
        {
            public string Name { get; set; }
            public string Separator { get; set; }
        }
    }

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
            Assert(x => x.Add("-arg {value}", "secret", secret: true).RenderForOutput(), "-arg [hidden]");
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
            Assert(x => x.Add("-arg {value}", "secret", secret: true).FilterSecrets("foosecretbar"), "foo[hidden]bar");
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
