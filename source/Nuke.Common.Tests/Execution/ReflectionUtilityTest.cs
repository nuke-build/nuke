// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using FluentAssertions;
using Nuke.Common.Utilities;
using Xunit;

namespace Nuke.Common.Tests.Execution
{
    public class ReflectionUtilityTest
    {
        [Theory]
        [InlineData(typeof(string), true)]
        [InlineData(typeof(int), false)]
        [InlineData(typeof(int?), true)]
        [InlineData(typeof(object), true)]
        [InlineData(typeof(bool), false)]
        [InlineData(typeof(bool[]), true)]
        [InlineData(typeof(ReflectionUtilityTest), true)]
        public void TestIsNullableType(Type type, bool expected)
        {
            type.IsNullableType().Should().Be(expected);
        }

        [Theory]
        [InlineData(typeof(int), typeof(int?))]
        [InlineData(typeof(bool?), typeof(bool?))]
        [InlineData(typeof(string), typeof(string))]
        [InlineData(typeof(object[]), typeof(object[]))]
        [InlineData(typeof(ReflectionUtilityTest), typeof(ReflectionUtilityTest))]
        public void TestGetNullableType(Type type, Type expected)
        {
            type.GetNullableType().Should().Be(expected);
        }

        [Theory]
        [InlineData(typeof(string[]), true)]
        [InlineData(typeof(IEnumerable<string>), true)]
        [InlineData(typeof(List<string>), true)]
        [InlineData(typeof(IReadOnlyCollection<string>), true)]
        [InlineData(typeof(int), false)]
        [InlineData(typeof(string), false)]
        [InlineData(typeof(Func<string>), false)]
        public void TestIsCollectionLike(Type type, bool expected)
        {
            type.IsCollectionLike().Should().Be(expected);
        }
    }
}
