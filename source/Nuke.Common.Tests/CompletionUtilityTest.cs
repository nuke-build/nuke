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
        [InlineData("", null, new[] { "Compile", "Pack", "--target", "--api-key", "--nuget-source" })]
        [InlineData("-", null, new[] { "--target", "--api-key", "--nuget-source"})]
        [InlineData("-t", null, new[] { "-target" })]
        [InlineData("-Api", null, new[] { "-ApiKey" })]
        [InlineData("--api", null, new[] { "--api-key" })]
        [InlineData("-ApiKey ", null, new[] { "--target", "--nuget-source" } )]
        [InlineData("--api-key ", null, new[] { "--target", "--nuget-source" } )]
        [InlineData("--target ", null, new[] { "Compile", "Pack", "--api-key", "--nuget-source" })]
        [InlineData("--target P", null, new[] { "Pack" })]
        [InlineData("--target -", null, new[] { "--api-key", "--nuget-source" })]
        [InlineData("--target Compile ", null, new[] { "Pack", "--api-key", "--nuget-source" })]
        [InlineData("P", null, new[] { "Pack" })]
        [InlineData("Pack ", null, new[] { "Compile", "--target", "--api-key", "--nuget-source" })]
        [InlineData("Pack comp", null, new[] { "compile" })]
        public void TestGetRelevantCompletionItems(string words, int? position, string[] expectedItems)
        {
            var completionItems =
                new Dictionary<string, string[]>
                {
                    { Constants.InvokedTargetsParameterName, new[] { "Compile", "Pack" } },
                    { "ApiKey", null },
                    { "NuGetSource", null }
                };
            CompletionUtility.GetRelevantCompletionItems(words, position, completionItems)
                .Should()
                .BeEquivalentTo(expectedItems);
        }
    }
}