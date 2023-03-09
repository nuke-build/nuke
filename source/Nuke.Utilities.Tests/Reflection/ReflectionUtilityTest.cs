// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Globalization;
using FluentAssertions;
using Nuke.Common.IO;
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

        [Theory]
        [InlineData("release", typeof(string), "release")]
        [InlineData("5", typeof(int), 5)]
        [InlineData(null, typeof(AbsolutePath), null)]
        public void TestConversion(string value, Type destinationType, object expectedValue)
        {
            ReflectionUtility.Convert(value, destinationType).Should().Be(expectedValue);
        }

        [Fact]
        public void TestConversionSpecial()
        {
            var datetime = DateTime.Now;
            ReflectionUtility.Convert(datetime.ToString(CultureInfo.InvariantCulture), typeof(DateTime))
                .Should().BeOfType<DateTime>().Which
                .Should().BeCloseTo(datetime, TimeSpan.FromSeconds(1));

            var guid = Guid.NewGuid();
            ReflectionUtility.Convert(guid, typeof(Guid))
                .Should().BeOfType<Guid>().Which
                .Should().Be(guid);

            var path = "/bin/etc";
            ReflectionUtility.Convert(path, typeof(AbsolutePath))
                .Should().BeOfType<AbsolutePath>().Which.ToString()
                .Should().Be(path);
        }

        [Fact]
        public void TestConversionCollections()
        {
            ReflectionUtility.Convert(new string[0], typeof(string[]))
                .Should().BeOfType<string[]>().Which
                .Should().BeEmpty();

            ReflectionUtility.Convert("A+B+C", typeof(string[]), separator: '+')
                .Should().BeOfType<string[]>().Which
                .Should().HaveCount(3);

            ReflectionUtility.Convert("1 2 3", typeof(int[]), separator: ' ')
                .Should().BeOfType<int[]>().Which
                .Should().HaveCount(3)
                .And.Contain(2);
        }
    }
}
