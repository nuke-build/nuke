// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using VerifyXunit;
using Xunit;

namespace Nuke.Common.Tests;

public class OptionsTest
{
    // ReSharper disable UnassignedGetOnlyAutoProperty
    private string ScalarValue { get; }
    private List<int> ListValue { get; }
    private ReadOnlyDictionary<string, string> DictionaryValue { get; }
    private LookupTable<string, string> LookupValue { get; }
    private Options NestedValue { get; }
    // ReSharper restore UnassignedGetOnlyAutoProperty

    [Fact]
    public void TestScalar()
    {
        new Options().Modify(x =>
        {
            x.Set(() => ScalarValue, 1);
            x.Get<int>(() => ScalarValue).Should().Be(1);

            x.Set(() => ScalarValue, "string");
            x.Get<string>(() => ScalarValue).Should().Be("string");

            x.Set(() => ScalarValue, true);
            x.Get<bool>(() => ScalarValue).Should().Be(true);

            x.Set(() => ScalarValue, OutputType.Err);
            x.Get<OutputType>(() => ScalarValue).Should().Be(OutputType.Err);

            x.Set(() => ScalarValue, null);
            x.Get<OutputType?>(() => ScalarValue).Should().BeNull();

            x.Set(() => ScalarValue, CustomEnumeration.Quiet);
            x.Get<CustomEnumeration>(() => ScalarValue).Should().Be(CustomEnumeration.Quiet);
        });
    }

    [Fact]
    public void TestList()
    {
        new Options().Modify(x =>
        {
            x.Set(() => ListValue, new[] { 1, 2, 3 });
            x.Get<List<int>>(() => ListValue).Should().Equal(1, 2, 3);

            x.AddCollection(() => ListValue, [4, 5]);
            x.Get<List<int>>(() => ListValue).Should().EndWith(new[] { 4, 5 });

            x.RemoveCollection(() => ListValue, [2, 4]);
            x.Get<List<int>>(() => ListValue).Should().NotContain(new[] { 2, 4 });

            x.ClearCollection(() => ListValue);
            x.Get<List<int>>(() => ListValue).Should().BeEmpty();
        });
    }

    [Fact]
    public void TestDictionary()
    {
        new Options().Modify(x =>
        {
            x.SetDictionary(() => DictionaryValue, "key", "value");
            x.Get<Dictionary<string, string>>(() => DictionaryValue).Should().ContainKey("key").WhoseValue.Should().Be("value");

            x.AddDictionary(() => DictionaryValue, "key2", "value");
            x.Get<Dictionary<string, string>>(() => DictionaryValue).Should().HaveCount(2);

            x.RemoveDictionary(() => DictionaryValue, "key");
            x.Get<Dictionary<string, string>>(() => DictionaryValue).Should().ContainKey("key2");

            x.ClearDictionary(() => DictionaryValue);
            x.Get<Dictionary<string, string>>(() => DictionaryValue).Should().BeEmpty();
        });
    }

    [Fact]
    public void TestLookup()
    {
        new Options().Modify(x =>
        {
            x.SetLookup(() => LookupValue, "key", "value1", "value2");
            x.Get<LookupTable<string, string>>(() => LookupValue).Should()
                .Contain(x => x.Key == "key" && x.SequenceEqual(new[] { "value1", "value2" }));

            x.AddLookup(() => LookupValue, "key", "value3");
            x.AddLookup(() => LookupValue, "key2", "value1");
            x.Get<LookupTable<string, string>>(() => LookupValue).Should().Contain(x => x.Key == "key" && x.Last() == "value3");
            x.Get<LookupTable<string, string>>(() => LookupValue).Should().Contain(x => x.Key == "key2");

            x.RemoveLookup(() => LookupValue, "key", "value2");
            x.RemoveLookup(() => LookupValue, "key2");
            x.Get<LookupTable<string, string>>(() => LookupValue).Should().Contain(x => x.Key == "key" && x.Count() == 2);
            x.Get<LookupTable<string, string>>(() => LookupValue).Should().HaveCount(1);

            x.ClearLookup(() => LookupValue);
            x.Get<LookupTable<string, string>>(() => LookupValue).Should().BeEmpty();
        });
    }

    [Fact]
    public void TestNested()
    {
        new Options().Modify(x =>
        {
            x.Set(() => NestedValue,
                new Options().Modify(y =>
                {
                    y.Set(() => ScalarValue, "scalar-value");
                    y.Set(() => ListValue, new[] { 1, 2, 3 });
                    y.Set(() => DictionaryValue, new Dictionary<string, object> { ["key"] = "value" });
                    y.Set(() => LookupValue, new LookupTable<string, int> { ["key"] = new[] { 1, 2, 3 } });
                }));

            IOptions nested = x.Get<Options>(() => NestedValue);
            nested.Get<string>(() => ScalarValue).Should().Be("scalar-value");
            nested.Get<List<int>>(() => ListValue).Should().Equal(1, 2, 3);
            nested.Get<Dictionary<string, object>>(() => DictionaryValue).Should().ContainKey("key");
            nested.Get<LookupTable<string, int>>(() => LookupValue).Should().Contain(x => x.Key == "key");
        });
    }

    [Fact]
    public Task TestSerialization()
    {
        IOptions options = new Options();
        options.Set(() => ScalarValue, "scalar-value");
        options.Set(() => ListValue, new[] { 1, 2, 3 });
        options.Set(() => DictionaryValue, new Dictionary<string, object> { ["key"] = "value" });
        options.Set(() => LookupValue, new LookupTable<string, int> { ["key"] = new[] { 1, 2, 3 } });
        options.Set(() => NestedValue, options);

        return Verifier.Verify(options.ToJson(Options.JsonSerializerSettings));
    }
}

[TypeConverter(typeof(TypeConverter<CustomEnumeration>))]
public class CustomEnumeration : Enumeration
{
    public static CustomEnumeration Quiet = "quiet";
    public static implicit operator CustomEnumeration(string value)
    {
        return new CustomEnumeration { Value = value };
    }
}
