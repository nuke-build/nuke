// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using VerifyTests;
using VerifyXunit;
using Xunit;

namespace Nuke.Common.Tests;

public class CompletionUtilityTest
{
    private VerifySettings _verifySettings;

    public CompletionUtilityTest()
    {
        _verifySettings = new VerifySettings();
        _verifySettings.DontIgnoreEmptyCollections();
    }

    [Fact]
    public async Task TestGetCompletionItemsTargetBuild()
    {
        var file = (AbsolutePath)"/Users/matt/code/nuke/source/Nuke.Build.Tests/SchemaUtilityTest.TestTargetBuild.verified.json";
        var schema = JsonDocument.Parse(file.ReadAllText());
        var items = CompletionUtility.GetItemsFromSchema(schema, new[] { "dev" });
        await Verifier.Verify(items, _verifySettings);
    }

    [Fact]
    public async Task TestGetCompletionItemsParameterBuild()
    {
        var file = (AbsolutePath)"/Users/matt/code/nuke/source/Nuke.Build.Tests/SchemaUtilityTest.TestParameterBuild.verified.json";
        var schema = JsonDocument.Parse(file.ReadAllText());
        var items = CompletionUtility.GetItemsFromSchema(schema, []);
        await Verifier.Verify(items, _verifySettings);
    }

    [Fact]
    public async Task TestGetCompletionItemsFromSchema()
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
        await Verifier.Verify(items, _verifySettings);
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
                { Constants.InvokedTargetsParameterName, ["Compile", "GitHubPublish"] },
                { "ApiKey", [] },
                { "NuGetSource", [] }
            };
        CompletionUtility.GetRelevantItems(words, completionItems)
            .Should()
            .BeEquivalentTo(expectedItems);
    }
}
