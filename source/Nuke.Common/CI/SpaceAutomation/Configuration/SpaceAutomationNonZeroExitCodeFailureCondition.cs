using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.SpaceAutomation.Configuration
{
    public class SpaceAutomationNonZeroExitCodeFailureCondition : SpaceAutomationFailureCondition
    {
        public bool? NonZeroExitCode { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            if (NonZeroExitCode != null && NonZeroExitCode == false)
                writer.WriteLine($"nonZeroExitCode {{ enabled = {NonZeroExitCode.ToString().ToLowerInvariant()} }}");
        }
    }
}
