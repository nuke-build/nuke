// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using FluentAssertions;
using Nuke.Common.Tooling;
using Xunit;

namespace Nuke.Common.Tests.Tooling;

public class ToolSettingsTest
{
    [Serializable]
    private class ToolSettings : Nuke.Common.Tooling.ToolSettings
    {
    }
    
    [Fact]
    public void ShouldNotThrowSerializationException()
    {
        var toolSettings = new ToolSettings();
        Action<OutputType, string> action = (_, _) => { };
        
        toolSettings = toolSettings.SetProcessCustomLogger(action);
        toolSettings = toolSettings.NewInstance();

        toolSettings.ProcessCustomLogger.Should().Be(action);
    }
}
