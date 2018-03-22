// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Nuke.Core.Utilities.Collections;
using Xunit;

namespace Nuke.Core.Tests
{
    public class EnumerableExtensionsTest
    {
        [Fact]
        public void SingleOrDefaultOrError_ThrowsExceptionWithMessage()
        {
            var x = new[] { "a", "a" };
            Action a = () => x.SingleOrDefaultOrError("error");
            a.Should().Throw<InvalidOperationException>().WithMessage("error");
        }

        [Theory]
        [InlineData(new[] { "a", "b", "c" }, "a", "a")]
        [InlineData(new[] { "a", "b", "c" }, "d", null)]
        public void SingleOrDefaultOrError(string[] enumerable, string equalsWith, string expectedValue)
        {
            enumerable.SingleOrDefaultOrError(x => x.Equals(equalsWith), "error").Should().Be(expectedValue);
        }
    }
}
