// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;
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
            return Verifier.Verify(schema.ToString());
        }

        [Fact]
        public void TestGetCompletionItemsFromSchema()
        {
            var schema = JObject.Parse(@"
{
  ""$schema"": ""http://json-schema.org/draft-04/schema#"",
  ""title"": ""Build Schema"",
  ""definitions"": {
    ""build"": {
      ""type"": ""object"",
      ""properties"": {
        ""NoLogo"": {
          ""type"": ""boolean"",
          ""description"": ""Disables displaying the NUKE logo""
        },
        ""Configuration"": {
          ""type"": ""string"",
          ""description"": ""Configuration to build - Default is 'Debug' (local) or 'Release' (server)"",
          ""enum"": [
            ""Debug"",
            ""Release""
          ]
        },
        ""Target"": {
          ""type"": ""array"",
          ""description"": ""List of targets to be executed. Default is '{default_target}'"",
          ""items"": {
            ""type"": ""string"",
            ""enum"": [
              ""Restore"",
              ""Compile""
            ]
          }
        }
      }
    }
  }
}
");
            var items = SchemaUtility.GetCompletionItemsFromSchema(schema);
            items.Should().BeEquivalentTo(
                new Dictionary<string, string[]>
                {
                    ["NoLogo"] = null,
                    ["Configuration"] = new[] { "Debug", "Release" },
                    ["Target"] = new[] { "Restore", "Compile" }
                });
        }

        class TestBuild : NukeBuild
        {
            [Parameter] private bool? NullableBool;
            [Parameter] private int? NullableInteger;
        }
    }
}
