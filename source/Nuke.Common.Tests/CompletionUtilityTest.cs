// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Nuke.Common.Utilities;
using Xunit;

namespace Nuke.Common.Tests
{
    public class CompletionUtilityTest
    {
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
            CompletionUtility.GetRelevantCompletionItems(words, completionItems)
                .Should()
                .BeEquivalentTo(expectedItems);
        }
    }
}
