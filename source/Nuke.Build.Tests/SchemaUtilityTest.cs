// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Nuke.Common.Execution;
using VerifyXunit;
using Xunit;

namespace Nuke.Common.Tests
{
    [UsesVerify]
    public class SchemaUtilityTest
    {
        [Fact]
        public Task TestGetBuildSchema()
        {
            var schema = SchemaUtility.GetBuildSchema(new TestBuild());
            var options = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
            var json = JsonSerializer.Serialize(schema, options);
            return Verifier.Verify(json);
        }

#pragma warning disable CS0649
        private class TestBuild : NukeBuild, ITestComponent
        {
            [Parameter] public string Param;
            [Parameter] public bool? NullableBool;
            [Parameter] public int? NullableInteger;
            [Parameter] public Verbosity[] Verbosities;
            [Parameter] [Secret] public string Secret;
            public string Param2 => "";
            string ITestComponent.Param3 => "";

            Target ITestComponent.Bar => _ => _;
            public Target Zoo => _ => _;
        }

        [ParameterPrefix("Component")]
        private interface ITestComponent : INukeBuild
        {
            [Parameter] string Param1 => TryGetValue(() => Param1);
            [Parameter] string Param2 => TryGetValue(() => Param2);
            [Parameter] string Param3 => TryGetValue(() => Param3);

            Target Foo => _ => _;
            Target Bar => _ => _;
            Target Zoo => _ => _;
        }
#pragma warning restore CS0649
    }
}
