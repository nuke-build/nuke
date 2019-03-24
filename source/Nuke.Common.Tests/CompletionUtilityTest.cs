// Copyright 2019 Maintainers of NUKE.
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
        [InlineData("", new[] { "Compile", "Pack", "--target", "--api-key", "--nuget-source" })]
        [InlineData("-", new[] { "--target", "--api-key", "--nuget-source" })]
        [InlineData("-t", new[] { "-target" })]
        [InlineData("-Api", new[] { "-ApiKey" })]
        [InlineData("--api", new[] { "--api-key" })]
        [InlineData("-ApiKey ", new[] { "--target", "--nuget-source" })]
        [InlineData("--api-key ", new[] { "--target", "--nuget-source" })]
        [InlineData("--target ", new[] { "Compile", "Pack", "--api-key", "--nuget-source" })]
        [InlineData("--target P", new[] { "Pack" })]
        [InlineData("--target -", new[] { "--api-key", "--nuget-source" })]
        [InlineData("--target Compile ", new[] { "Pack", "--api-key", "--nuget-source" })]
        [InlineData("P", new[] { "Pack" })]
        [InlineData("Pack ", new[] { "Compile", "--target", "--api-key", "--nuget-source" })]
        [InlineData("Pack comp", new[] { "compile" })]
        public void TestGetRelevantCompletionItems(string words, string[] expectedItems)
        {
            var completionItems =
                new Dictionary<string, string[]>
                {
                    { Constants.InvokedTargetsParameterName, new[] { "Compile", "Pack" } },
                    { "ApiKey", null },
                    { "NuGetSource", null }
                };
            CompletionUtility.GetRelevantCompletionItems(words, completionItems)
                .Should()
                .BeEquivalentTo(expectedItems);
        }
    }
}
