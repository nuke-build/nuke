// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.OctoVersion;
using Xunit;

namespace Nuke.Common.Tests;

public class SettingsEntity_NewInstanceTest
{
    private class SimpleSettings : ISettingsEntity
    {
        public string stringField;
        public string StringProperty { get; set; }
        public int intField;
        public int IntProperty { get; set; }
    }

    [Fact]
    public void ClonesSimpleSettingsType()
    {
        var s = new SimpleSettings { stringField = "sf", StringProperty = "SP", intField = 1, IntProperty = 10 };
        var s2 = s.NewInstance();

        s2.Should().BeEquivalentTo(s);
    }

    private class ComplexSettings : ISettingsEntity
    {
        public class ComplexChildInit
        {
            public string Name { get; init; }
            public DateTimeOffset DateOfBirth { get; init; }
        }

        public class ComplexChildCtor
        {
            public ComplexChildCtor(string name, DateTimeOffset dateOfBirth)
            {
                Name = name;
                DateOfBirth = dateOfBirth;
            }

            public string Name { get; }
            public DateTimeOffset DateOfBirth { get; init; }
        }

        public record ComplexChildRecord(string[] Names, double Average);

        public ComplexSettings(Dictionary<string, ComplexChildCtor> childCtor, ComplexChildRecord childRecord)
        {
            ChildCtor = childCtor;
            ChildRecord = childRecord;
        }

        public ComplexChildInit ChildInit { get; set; }
        public Dictionary<string, ComplexChildCtor> ChildCtor { get; }
        public ComplexChildRecord ChildRecord { get; }
    }

    [Fact]
    public void ClonesComplexSettingsType()
    {
        var s = new ComplexSettings(
                    new Dictionary<string, ComplexSettings.ComplexChildCtor>
                    {
                        ["a"] = new("a", DateTimeOffset.UnixEpoch),
                        ["xyz"] = new("xyz", DateTimeOffset.UnixEpoch.AddDays(12))
                    },
                    new ComplexSettings.ComplexChildRecord(new[] { "Horse", "Cat", "Dog" }, Average: 7.5))
                { ChildInit = new ComplexSettings.ComplexChildInit { DateOfBirth = DateTimeOffset.FromUnixTimeSeconds(1698142718) } };
        var s2 = s.NewInstance();

        s2.Should().BeEquivalentTo(s);
    }

    private class PartiallySerializableSettings : ISettingsEntity
    {
        public string stringField;

        [field: NonSerialized]
        public string StringProperty { get; set; }

        [NonSerialized]
        public int intField;

        public int IntProperty { get; set; }
    }

    [Fact]
    public void IgnoresNonSerializableTypes()
    {
        var s = new PartiallySerializableSettings { stringField = "sf", StringProperty = "SP", intField = 1, IntProperty = 10 };
        var s2 = s.NewInstance();

        using var scope = new AssertionScope();

        s2.stringField.Should().Be(s.stringField);
        s2.StringProperty.Should().BeNull(); // nonserialized
        s2.intField.Should().Be(0); // nonserialized
        s2.IntProperty.Should().Be(s.IntProperty);
    }

    private class MyCustomToolSettings : ToolSettings
    {
        public string StringProperty { get; set; }
        public int IntProperty { get; set; }
        public Func<string, int> Calc { get; set; }
    }

    [Fact]
    public void IgnoresFuncTypesExceptToolSettings()
    {
        var s = new MyCustomToolSettings { StringProperty = "Str", IntProperty = 12, Calc = s => s.Length * 2 };

        var processLog = new List<(OutputType, string)>();

        s.ProcessArgumentConfigurator = arguments => arguments;
        s.ProcessLogger = (outputType, str) => processLog.Add((outputType, str));
        s.ProcessExitHandler = (_, _) => { };
        var s2 = s.NewInstance();

        using var scope = new AssertionScope();

        s2.StringProperty.Should().Be(s.StringProperty);
        s2.IntProperty.Should().Be(s.IntProperty);
        s2.Calc.Should().BeNull(); // can't copy a func

        // except these 3 have special handling
        s2.ProcessArgumentConfigurator.Should().NotBeNull();
        s2.ProcessLogger.Should().NotBeNull();
        s2.ProcessExitHandler.Should().NotBeNull();

        s2.ProcessLogger(OutputType.Err, "an err");

        processLog.Should().BeEquivalentTo(new (OutputType, string)[] { new(OutputType.Err, "an err") });
    }
    
    [Fact]
    public void CanCloneOctoVersion() // at least one "real" type
    {
        var s = new OctoVersionInfo
                {
                    BuildMetaData = "amazing",
                    MajorMinorPatch = "1.2.3",
                    Major = 1,
                    Minor = 2,
                    Patch = 3
                };
        
        var s2 = s.NewInstance();
        s2.Should().BeEquivalentTo(s);
    }
}
