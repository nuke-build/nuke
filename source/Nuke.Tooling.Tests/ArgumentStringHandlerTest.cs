// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using FluentAssertions;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Xunit;

namespace Nuke.Common.Tests;

public class ArgumentStringHandlerTest
{
    [Fact]
    public void Test()
    {
        ArgsToString($"start {"regular-args"} end").Should().Be("start regular-args end");
    }

    [Fact]
    public void TestString()
    {
        ArgsToString("start end").Should().Be("start end");
    }

    [Fact]
    public void TestSpacedHole()
    {
        ArgsToString($"start {"spaced args"} end").Should().Be("start \"spaced args\" end");
    }

    [Theory]
    [InlineData("args", "start args end")]
    [InlineData("spaced args", "start \"spaced args\" end")]
    public void TestArgs(string args, string expected)
    {
        ArgsToString($"start {args} end").Should().Be(expected);
    }

    [Theory]
    [InlineData("/some/path", "start /some/path end")]
    [InlineData("/some/spaced path", "start \"/some/spaced path\" end")]
    public void TestAbsolutePath(string path, string expected)
    {
        ArgsToString($"start {(AbsolutePath)path} end").Should().Be(expected);
    }

    [Fact]
    public void TestFormat()
    {
        ArgsToString($"start {"spaced args":nq} end").Should().Be("start spaced args end");

        var path = (AbsolutePath)"/some/path";
        ArgsToString($"start {path:d} end").Should().Be("start \"/some/path\" end");
        ArgsToString($"start {path:s} end").Should().Be("start '/some/path' end");
        ArgsToString($"start {path:dn} end").Should().Be("start /some/path end");
        ArgsToString($"start {path:sn} end").Should().Be("start /some/path end");

        var spacedPath = (AbsolutePath)"/some/spaced path";
        ArgsToString($"start {spacedPath:d} end").Should().Be("start \"/some/spaced path\" end");
        ArgsToString($"start {spacedPath:s} end").Should().Be("start '/some/spaced path' end");
        ArgsToString($"start {spacedPath:dn} end").Should().Be("start \"/some/spaced path\" end");
        ArgsToString($"start {spacedPath:sn} end").Should().Be("start '/some/spaced path' end");
    }

    [Fact]
    public void TestUnquote()
    {
        ArgsToString($"{"start end"}").Should().Be("start end");
        ArgsToString($"start {"spaced end"}").Should().Be("start \"spaced end\"");
        ArgsToString($"{"spaced start"} end").Should().Be("\"spaced start\" end");
    }

    [Fact]
    public void TestSecret()
    {
        ArgumentStringHandler args = $"start {"this+is/some!secret":r} end";

        var filteredOutput = args.GetFilter().Invoke("There is a this+is/some!secret!");
        filteredOutput.Should().Be("There is a [REDACTED]!");
    }

    string ArgsToString(ArgumentStringHandler args) => args.ToStringAndClear();
}
