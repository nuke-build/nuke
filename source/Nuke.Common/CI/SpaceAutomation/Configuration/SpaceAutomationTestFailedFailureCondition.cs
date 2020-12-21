using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.SpaceAutomation.Configuration
{
    public class SpaceAutomationTestFailedFailureCondition : SpaceAutomationFailureCondition
    {
        public bool? TestFailed { get; set; }
        
        public override void Write(CustomFileWriter writer)
        {
            if (TestFailed.HasValue && TestFailed.Value == false)
                writer.WriteLine($"testFailed {{ enabled = {TestFailed.ToString().ToLowerInvariant()} }}");
        }
    }
}