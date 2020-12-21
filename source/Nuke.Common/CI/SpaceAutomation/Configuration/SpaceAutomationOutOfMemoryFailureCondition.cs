using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.SpaceAutomation.Configuration
{
    public class SpaceAutomationOutOfMemoryFailureCondition : SpaceAutomationFailureCondition
    {
        public bool? OutOfMemory { get; set; }
        
        public override void Write(CustomFileWriter writer)
        {
            if (OutOfMemory.HasValue && OutOfMemory.Value == false)
                writer.WriteLine($"outOfMemory {{ enabled = {OutOfMemory.ToString().ToLowerInvariant()} }}");
        }
    }
}