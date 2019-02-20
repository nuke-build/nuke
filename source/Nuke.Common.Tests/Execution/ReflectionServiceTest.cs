// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using FluentAssertions;
using Nuke.Common.Execution;
using Xunit;

namespace Nuke.Common.Tests.Execution
{
    public class ReflectionServiceTest
    {
        [Theory]
        [InlineData(typeof(string), true)]
        [InlineData(typeof(int), false)]
        [InlineData(typeof(int?), true)]
        [InlineData(typeof(object), true)]
        [InlineData(typeof(bool), false)]
        [InlineData(typeof(bool[]), true)]
        [InlineData(typeof(ReflectionServiceTest), true)]
        public void TestIsNullableType(Type type, bool expected)
        {
            type.IsNullableType().Should().Be(expected);
        }

        [Theory]
        [InlineData(typeof(int), typeof(int?))]
        [InlineData(typeof(bool?), typeof(bool?))]
        [InlineData(typeof(string), typeof(string))]
        [InlineData(typeof(object[]), typeof(object[]))]
        [InlineData(typeof(ReflectionServiceTest), typeof(ReflectionServiceTest))]
        public void TestGetNullableType(Type type, Type expected)
        {
            type.GetNullableType().Should().Be(expected);
        }
    }
}
