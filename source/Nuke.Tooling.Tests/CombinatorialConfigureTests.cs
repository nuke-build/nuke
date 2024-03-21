// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using FluentAssertions;
using Nuke.Common.Tooling;
using Xunit;

namespace Nuke.Common.Tests;

public class CombinatorialConfigureTests
{
    [Fact]
    public void TestLogger()
    {
        var logged = false;

        Configure<TestSettings> configureLogger = x => x
            .SetProcessLogger((_, _) =>
                logged = true);

        Invoke(x => x
            .CombineWith(configureLogger));

        logged.Should().BeTrue();
    }

    private void Invoke(CombinatorialConfigure<TestSettings> configure)
    {
        configure.Invoke(
            StubTool,
            ProcessTasks.DefaultLogger, 
            degreeOfParallelism: 2,
            completeOnFailure: false);
    }

    private IReadOnlyCollection<Output> StubTool(TestSettings settings)
    {
        return new []
               {
                   new Output
                   {
                       Type = OutputType.Std,
                       Text = "hello",
                   },
               };
    }
}

[Serializable]
internal class TestSettings : ToolSettings
{
}
