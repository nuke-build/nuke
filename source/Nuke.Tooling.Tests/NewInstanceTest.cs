// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using FluentAssertions;
using Nuke.Common.Tooling;
using System;
using Xunit;

namespace Nuke.Common.Tests;

public class NewInstanceTest
{
    [Serializable]
    public class SimpleEntity : ISettingsEntity
    {
        public int Integer { get; set; }
        public string String { get; set; }
    }

    [Fact]
    public void TestSimpleEntity()
    {
        var entity = new SimpleEntity { Integer = 1, String = "test" };
        var newInstance = entity.NewInstance();

        newInstance.Integer.Should().Be(entity.Integer);
        newInstance.String.Should().Be(entity.String);
    }

}
