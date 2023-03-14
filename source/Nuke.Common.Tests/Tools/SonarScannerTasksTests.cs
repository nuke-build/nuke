using System;
using System.Linq;
using Nuke.Common.Tools.SonarScanner;
using Xunit;
using FluentAssertions;

namespace Nuke.Common.Tests.Tools
{
    public class SonarScannerBeginSettingsTests
    {
        [Fact]
        public void Verbose_logging_needs_lowercase_flag()
        {
            // Act
            var settings = new SonarScannerBeginSettings().EnableVerbose();

            // Assert
            var cliArguments = settings.GetProcessArguments().RenderForExecution();

            cliArguments.Should().Be("begin /d:sonar.verbose=true");
        }
    }
}

