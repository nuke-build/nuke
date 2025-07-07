// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Xunit;

namespace Nuke.Common.Tests;

public class ToolOptionsArgumentsTest
{
    [Fact] public void TestBool_Simple() => Assert<BoolToolOptions>(new { Bool = true }, ["/bool:true",]);
    [Fact] public void TestBool_FlagTrue() => Assert<BoolToolOptions>(new { Flag = true }, ["/flag"]);
    [Fact] public void TestBool_FlagFalse() => Assert<BoolToolOptions>(new { Flag = false }, []);

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    private class BoolToolOptions : ToolOptions
    {
        [Argument(Format = "/bool:{value}")] public bool Bool => Get<bool>(() => Bool);
        [Argument(Format = "/flag")] public bool? Flag => Get<bool>(() => Flag);
    }

    [Fact] public void TestString_Simple() => Assert<StringToolOptions>(new { String = "value" }, ["--string", "value"]);
    [Fact] public void TestString_Quoted() => Assert<StringToolOptions>(new { String = "white space" }, ["--string", "\"white space\""]);

    [Fact]
    public void TestString_Secret()
    {
        var options = SetInternalOptions<StringToolOptions>(new { Secret = "secret-value" });
        options.GetSecrets().Should().Equal("secret-value");
    }

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    private class StringToolOptions : ToolOptions
    {
        [Argument(Format = "--string {value}")] public string String => Get<string>(() => String);
        [Argument(Format = "--secret {value}", Secret = true)] public string Secret => Get<string>(() => Secret);
    }

    [Fact] public void TestImplicit() => Assert<ImplicitToolOptions>(new { String = "value" }, ["implicit argument", "--string", "value"]);

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    [Command(Arguments = "implicit argument")]
    private class ImplicitToolOptions : ToolOptions
    {
        [Argument(Format = "--string {value}")] public string String => Get<string>(() => String);
    }

    [Fact]
    public void TestOrder()
    {
        // ReSharper disable SimilarAnonymousTypeNearby
        Assert<OrderToolOptions>(new { Flag1 = true, Flag2 = true, }, ["/flag1", "/flag2"]);
        Assert<OrderToolOptions>(new { Flag2 = true, Flag1 = true, }, ["/flag2", "/flag1"]);
        // ReSharper restore SimilarAnonymousTypeNearby
    }

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    private class OrderToolOptions : ToolOptions
    {
        [Argument(Format = "/flag1")] public bool Flag1 => Get<bool>(() => Flag1);
        [Argument(Format = "/flag2")] public bool Flag2 => Get<bool>(() => Flag2);
    }

    [Fact] public void TestPosition() => Assert<PositionToolOptions>(
        new
        {
            SecondToLast = "second-last",
            Second = "second",
            Middle = "middle",
            First = "first",
            Last = "last"
        },
        arguments: ["first", "second", "middle", "second-last", "last"]);

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    private class PositionToolOptions : ToolOptions
    {
        [Argument(Format = "{value}")] public string Middle => Get<string>(() => Middle);
        [Argument(Format = "{value}", Position = -1)] public string Last => Get<string>(() => Last);
        [Argument(Format = "{value}", Position = 1)] public string First => Get<string>(() => First);
        [Argument(Format = "{value}", Position = 2)] public string Second => Get<string>(() => Second);
        [Argument(Format = "{value}", Position = -2)] public string SecondToLast => Get<string>(() => SecondToLast);
    }

    [Fact] public void TestFormatter_Method1() => Assert<FormatToolOptions>(new { Time = DateTime.UnixEpoch.AddHours(1).AddMinutes(15) }, ["01:15"]);
    [Fact] public void TestFormatter_Method2() => Assert<FormatToolOptions>(new { Date = DateTime.UnixEpoch }, ["01/01/1970"]);
    [Fact] public void TestFormatter_TypeMethod() => Assert<FormatToolOptions>(new { Minutes = TimeSpan.FromMinutes(10) }, ["10"]);

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    private class FormatToolOptions : ToolOptions
    {
        [Argument(Format = "{value}", FormatterMethod = nameof(FormatTime))]
        public DateTime Time => Get<DateTime>(() => Time);

        [Argument(Format = "{value}", FormatterMethod = nameof(FormatDate))]
        public DateTime Date => Get<DateTime>(() => Date);

        [Argument(Format = "{value}", FormatterType = typeof(Formatter), FormatterMethod = nameof(Formatter.FormatMinutes))]
        public TimeSpan Minutes => Get<TimeSpan>(() => Minutes);

        private string FormatTime(DateTime datetime, PropertyInfo property) => datetime.ToString("t", CultureInfo.InvariantCulture);
        private string FormatDate(DateTime datetime, PropertyInfo property) => datetime.ToString("d", CultureInfo.InvariantCulture);
    }

    private static class Formatter
    {
        public static string FormatMinutes(TimeSpan timespan, PropertyInfo _) => timespan.TotalMinutes.ToString(CultureInfo.InvariantCulture);
    }

    [Fact] public void TestList_Simple() => Assert<ListToolOptions>(new { SimpleList = new[] { "a", "b" } }, ["--param", "a", "--param", "b"]);
    [Fact] public void TestList_Quoted() => Assert<ListToolOptions>(new { SimpleList = new[] { "white space" } }, ["--param", "\"white space\""]);
    [Fact] public void TestList_Separator() => Assert<ListToolOptions>(new { SeparatorList = new[] { "a", "b" } }, ["--param", "a+b"]);
    [Fact] public void TestList_Whitespace() => Assert<ListToolOptions>(new { WhitespaceList = new[] { "a", "b" } }, ["--param", "a", "b"]);
    [Fact] public void TestList_QuoteMultiple() => Assert<ListToolOptions>(new { QuotedList = new[] { "a", "b" } }, ["--param:\"a b\""]);
    [Fact] public void TestList_QuoteMultiple_WhitespaceValue() => Assert<ListToolOptions>(new { QuotedList = new[] { "a", "white space" } }, ["--param:\"a \\\"white space\\\"\""]);
    [Fact] public void TestList_Formatted() => Assert<ListToolOptions>(new { FormattedList = new[] { "true", "false" } }, ["--param=TRUE", "--param=FALSE"]);

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    private class ListToolOptions : ToolOptions
    {
        [Argument(Format = "--param {value}")] public IReadOnlyList<string> SimpleList => Get<List<string>>(() => SimpleList);
        [Argument(Format = "--param {value}", Separator = "+")] public IReadOnlyList<string> SeparatorList => Get<List<string>>(() => SeparatorList);
        [Argument(Format = "--param {value}", Separator = " ")] public IReadOnlyList<string> WhitespaceList => Get<List<string>>(() => WhitespaceList);
        [Argument(Format = "--param:{value}", Separator = " ", QuoteMultiple = true)] public IReadOnlyList<string> QuotedList => Get<List<string>>(() => QuotedList);
        [Argument(Format = "--param={value}", FormatterMethod = nameof(Format))] public IReadOnlyList<bool> FormattedList => Get<List<bool>>(() => FormattedList);

        private string Format(bool value, PropertyInfo property) => value.ToString().ToUpperInvariant();
    }

    private readonly Dictionary<string, object> _simpleDictionary = new() { ["key1"] = 1, ["key2"] = "foobar" };

    [Fact] public void TestDictionary_Simple1() => Assert<DictionaryToolOptions>(new { SimpleDictionary = _simpleDictionary }, ["-p", "key1=1", "-p", "key2=foobar"]);
    [Fact] public void TestDictionary_Simple2() => Assert<DictionaryToolOptions>(new { Simple2Dictionary = _simpleDictionary }, ["-p", "key1", "1", "-p", "key2", "foobar"]);
    [Fact] public void TestDictionary_Separator() => Assert<DictionaryToolOptions>(new { SeparatorDictionary = _simpleDictionary }, ["/p:key1=1;key2=foobar"]);
    [Fact] public void TestDictionary_Whitespace() => Assert<DictionaryToolOptions>(new { WhitespaceDictionary = _simpleDictionary }, ["--", "key1=1", "key2=foobar"]);
    [Fact] public void TestDictionary_Formatted() => Assert<DictionaryToolOptions>(new { FormattedDictionary = _simpleDictionary }, ["/p:key1=1", "/p:key2=FOOBAR"]);

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    private class DictionaryToolOptions : ToolOptions
    {
        [Argument(Format = "-p {key}={value}")] public IReadOnlyDictionary<string, object> SimpleDictionary => Get<Dictionary<string, object>>(() => SimpleDictionary);
        [Argument(Format = "-p {key} {value}")] public IReadOnlyDictionary<string, object> Simple2Dictionary => Get<Dictionary<string, object>>(() => Simple2Dictionary);
        [Argument(Format = "/p:{key}={value}", Separator = ";")] public IReadOnlyDictionary<string, object> SeparatorDictionary => Get<Dictionary<string, object>>(() => SeparatorDictionary);
        [Argument(Format = "-- {key}={value}", Separator = " ")] public IReadOnlyDictionary<string, object> WhitespaceDictionary => Get<Dictionary<string, object>>(() => WhitespaceDictionary);
        [Argument(Format = "/p:{key}={value}", FormatterMethod = nameof(Format))] public IReadOnlyDictionary<string, object> FormattedDictionary => Get<Dictionary<string, object>>(() => FormattedDictionary);

        private string Format(object value, PropertyInfo property) => value?.ToString()?.ToUpperInvariant();
    }

    private readonly LookupTable<string, object> _simpleLookupTable = new() { ["key1"] = [1, 2], ["key2"] = [true, false] };

    [Fact] public void TestLookup_Simple() => Assert<LookupToolOptions>(new { SimpleLookup = _simpleLookupTable }, ["--param", "key1=1","--param", "key1=2", "--param", "key2=true", "--param", "key2=false"]);
    [Fact] public void TestLookup_InnerSeparator() => Assert<LookupToolOptions>(new { InnerSeparatorLookup = _simpleLookupTable }, ["--param:key1=1,2", "--param:key2=true,false"]);
    [Fact] public void TestLookup_Separator() => Assert<LookupToolOptions>(new { SeparatorLookup = _simpleLookupTable }, ["--param:key1=1,2;key2=true,false"]);
    [Fact] public void TestLookup_Formatted() => Assert<LookupToolOptions>(new { FormattedLookup = _simpleLookupTable }, ["--param", "key1", "1+2", "--param", "key2", "TRUE+FALSE"]);

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    private class LookupToolOptions : ToolOptions
    {
        [Argument(Format = "--param {key}={value}")] public ILookup<string, object> SimpleLookup => Get<LookupTable<string, object>>(() => SimpleLookup);
        [Argument(Format = "--param:{key}={value}", InnerSeparator = ",")] public ILookup<string, object> InnerSeparatorLookup => Get<LookupTable<string, object>>(() => InnerSeparatorLookup);
        [Argument(Format = "--param:{key}={value}", Separator = ";", InnerSeparator = ",")] public ILookup<string, object> SeparatorLookup => Get<LookupTable<string, object>>(() => SeparatorLookup);
        [Argument(Format = "--param {key} {value}", InnerSeparator = "+", FormatterMethod = nameof(Format))] public ILookup<string, object> FormattedLookup => Get<LookupTable<string, object>>(() => FormattedLookup);

        private string Format(object value, PropertyInfo property) => value?.ToString()?.ToUpperInvariant();
    }

    [Fact]
    public void TestAdditionalArguments() => Assert<AdditionalArgumentsToolOptions>(
        new
        {
            String = "value",
            ProcessAdditionalArguments = new[] { "first", "second" }
        },
        arguments: ["--string", "value", "first", "second"]);

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    private class AdditionalArgumentsToolOptions : ToolOptions
    {
        [Argument(Format = "--string {value}")] public string String => Get<string>(() => String);
    }

    private void Assert<T>(object obj, IEnumerable<string> arguments)
        where T : ToolOptions, new()
    {
        var options = SetInternalOptions<T>(obj);
        options.GetArguments().Should().Equal(arguments);
    }

    private static T SetInternalOptions<T>(object obj)
        where T : ToolOptions, new()
    {
        var options = new T();
        options.InternalOptions = obj.ToJObject(Options.JsonSerializer);
        return options;
    }
}
