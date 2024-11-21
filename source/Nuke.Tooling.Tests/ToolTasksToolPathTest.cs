// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.ComponentModel;
using System.Linq;
using FluentAssertions;
using Nuke.Common.Tooling;
using Xunit;

namespace Nuke.Common.Tests;

public class ToolTasksToolPathTest
{
    public ToolTasksToolPathTest()
    {
        var rootDirectory = Constants.TryGetRootDirectoryFrom(EnvironmentInfo.WorkingDirectory);
        NuGetToolPathResolver.NuGetPackagesConfigFile = rootDirectory / "build" / "_build.csproj";
    }

    [Fact]
    public void TestFromAttribute()
    {
        new SimpleTool()
            .GetToolPathInternal()
            .Should().EndWith("xunit.console.dll");
    }

    [Fact]
    public void TestFromOptions()
    {
        new SimpleTool()
            .GetToolPathInternal(new SimpleToolOptions()
                .SetProcessToolPath("/some/path"))
            .Should().EndWith("/some/path");
    }

    [Fact]
    public void TestFromOptions_Framework()
    {
        new SimpleTool()
            .GetToolPathInternal(new FrameworkToolOptions()
                .SetFramework("netcoreapp2.0"))
            .Should().Contain("netcoreapp2.0").And.EndWith("xunit.console.dll");
    }


    [Fact]
    public void TestFromOverride()
    {
        new CustomPathTool()
            .GetToolPathInternal()
            .Should().Be(nameof(CustomPathTool));
    }
}

[NuGetTool(Id = "xunit.runner.console", Executable = "xunit.console.dll")]
file class SimpleTool : ToolTasks;

[Command(Type = typeof(SimpleTool))]
[TypeConverter(typeof(TypeConverter<SimpleToolOptions>))]
file class SimpleToolOptions : ToolOptions;

[Command(Type = typeof(SimpleTool))]
[TypeConverter(typeof(TypeConverter<FrameworkToolOptions>))]
file class FrameworkToolOptions : ToolOptions, IToolOptionsWithFramework;

[NuGetTool(Id = "xunit.runner.console", Executable = "xunit.console.dll")]
file class CustomPathTool : ToolTasks
{
    protected override string GetToolPath(ToolOptions options = null) => nameof(CustomPathTool);
}
