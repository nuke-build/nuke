// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Nuke.Common.Utilities;
using Xunit;

namespace Nuke.Common.Tests
{
    public class CompletionUtilityTest
    {
        [Fact]
        public void TestGetCompletionItemsFromSchema()
        {
            var schema = JsonDocument.Parse("""
                {
                  "$schema": "http://json-schema.org/draft-04/schema#",
                  "title": "Build Schema",
                  "definitions": {
                    "build": {
                      "type": "object",
                      "properties": {
                        "NoLogo": {
                          "type": "boolean",
                          "description": "Disables displaying the NUKE logo"
                        },
                        "Configuration": {
                          "type": "string",
                          "description": "Configuration to build - Default is 'Debug' (local) or 'Release' (server)",
                          "enum": [
                            "Debug",
                            "Release"
                          ]
                        },
                        "Profile": {
                          "type": "array",
                          "description": "Defines the profiles to load",
                          "items": {
                            "type": "string"
                          }
                        },
                        "Target": {
                          "type": "array",
                          "description": "List of targets to be invoked. Default is '{default_target}'",
                          "items": {
                            "type": "string",
                            "enum": [
                              "Restore",
                              "Compile"
                            ]
                          }
                        }
                      }
                    }
                  }
                }
                """);
            var profileNames = new[] { "dev" };
            var items = CompletionUtility.GetItemsFromSchema(schema, profileNames);
            items.Should().BeEquivalentTo(
                new Dictionary<string, string[]>
                {
                    ["NoLogo"] = null,
                    ["Configuration"] = new[] { "Debug", "Release" },
                    ["Target"] = new[] { "Restore", "Compile" },
                    [Constants.LoadedLocalProfilesParameterName] = profileNames
                });
        }

        [Theory]
        [InlineData("", new[] { "Compile", "GitHub-Publish", "--target", "--api-key", "--nuget-source" })]
        [InlineData("-", new[] { "--target", "--api-key", "--nuget-source" })]
        [InlineData("-t", new[] { "-target" })]
        [InlineData("-Api", new[] { "-ApiKey" })]
        [InlineData("--api", new[] { "--api-key" })]
        [InlineData("--Nu", new[] { "--Nuget-source" })]
        [InlineData("-ApiKey ", new[] { "--target", "--nuget-source" })]
        [InlineData("--api-key ", new[] { "--target", "--nuget-source" })]
        [InlineData("--target ", new[] { "Compile", "GitHub-Publish", "--api-key", "--nuget-source" })]
        [InlineData("--target G", new[] { "GitHub-Publish" })]
        [InlineData("--target -", new[] { "--api-key", "--nuget-source" })]
        [InlineData("--target compile ", new[] { "GitHub-Publish", "--api-key", "--nuget-source" })]
        [InlineData("C", new[] { "Compile" })]
        [InlineData("Compile ", new[] { "GitHub-Publish", "--target", "--api-key", "--nuget-source" })]
        [InlineData("Compile gith", new[] { "github-publish" })]
        [InlineData("Compile GITH", new[] { "GITHUB-PUBLISH" })]
        public void TestGetRelevantCompletionItems(string words, string[] expectedItems)
        {
            var completionItems =
                new Dictionary<string, string[]>
                {
                    { Constants.InvokedTargetsParameterName, new[] { "Compile", "GitHubPublish" } },
                    { "ApiKey", null },
                    { "NuGetSource", null }
                };
            CompletionUtility.GetRelevantItems(words, completionItems)
                .Should()
                .BeEquivalentTo(expectedItems);
        }
    }
}
