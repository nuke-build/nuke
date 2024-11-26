// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using VerifyXunit;
using Xunit;

#pragma warning disable CS0169 // Field is never used

namespace Nuke.Common.Tests;

public class SchemaUtilityTest
{
    [Fact]
    public Task TestEmptyBuild()
    {
        var jsonSchema = SchemaUtility.GetJsonString(new EmptyBuild());
        return Verifier.Verify(jsonSchema, "json");
    }

    [Fact]
    public Task TestTargetBuild()
    {
        var jsonSchema = SchemaUtility.GetJsonString(new TargetBuild());
        return Verifier.Verify(jsonSchema, "json");
    }

    [Fact]
    public Task TestParameterBuild()
    {
        var jsonSchema = SchemaUtility.GetJsonString(new ParameterBuild());
        return Verifier.Verify(jsonSchema, "json");
    }

    [Fact]
    public Task TestCustomParameterAttribute()
    {
        var jsonSchema = SchemaUtility.GetJsonString(new CustomParameterAttributeBuild());
        return Verifier.Verify(jsonSchema, "json");
    }

    // ReSharper disable All
#pragma warning disable CS0414 // Field is assigned but its value is never used
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value
    private class EmptyBuild : NukeBuild
    {
    }

    private class TargetBuild : NukeBuild, ITargetComponent
    {
        Target RegularTarget => _ => _;
        public Target ImplementedTarget => _ => _;
        Target ITargetComponent.ExplicitTarget => _ => _;
    }

    private interface ITargetComponent : INukeBuild
    {
        Target InheritedTarget => _ => _;
        Target ImplementedTarget => _ => _;
        Target ExplicitTarget => _ => _;
    }

    private class ParameterBuild : NukeBuild, IParameterComponent
    {
        [Parameter] readonly string RegularParam;
        [Parameter] [Secret] readonly string SecretParam;

        [Parameter] readonly bool BooleanParam;
        [Parameter] readonly bool? NullableBooleanParam;

        [Parameter] readonly string[] StringArrayParam;
        [Parameter] readonly int[] IntegerArrayParam;

        [Parameter] readonly CustomEnumeration CustomEnumerationParam;
        [Parameter] readonly CustomEnumeration[] CustomEnumerationArrayParam;

        [Parameter] readonly ComplexType ComplexTypeParam;
        [Parameter] readonly ComplexType[] ComplexTypeArrayParam;
    }

    [ParameterPrefix("Component")]
    private interface IParameterComponent : INukeBuild
    {
        [Parameter] string InheritedParam => TryGetValue(() => InheritedParam);
    }

    private class ComplexType
    {
        public string String;
        public int Number;
        public AbsolutePath[] Paths;
        public ComplexSubType SubObject;
    }

    private class ComplexSubType
    {
        public bool? Boolean;
    }

    [TypeConverter(typeof(TypeConverter<CustomEnumeration>))]
    private class CustomEnumeration : Enumeration
    {
        public static CustomEnumeration Debug = new() { Value = nameof(Debug) };
        public static CustomEnumeration Release = new() { Value = nameof(Release) };

        public static implicit operator string(CustomEnumeration configuration)
        {
            return configuration.Value;
        }
    }

    private class CustomParameterAttributeBuild : NukeBuild
    {
        [CustomParameter] readonly ComplexType ComplexTypeParamWithAttribute;
    }

    private class CustomParameterAttribute : ParameterAttribute;

#pragma warning restore CS0649 // Field is never assigned to, and will always have its default value
#pragma warning restore CS0414 // Field is assigned but its value is never used
    // ReSharper restore All
}
