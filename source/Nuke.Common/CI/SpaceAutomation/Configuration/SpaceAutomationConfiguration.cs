// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Linq;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.SpaceAutomation.Configuration
{
    public class SpaceAutomationConfiguration : ConfigurationEntity
    {
        public string Name { get; set; }
        public string VolumeSize { get; set; }
        public bool? CloneRepository { get; set; }
        
        /// <summary>
        /// Set to -1 for UNLIMITED_DEPTH
        /// </summary>
        public int? CloneDepth { get; set; }
        
        public SpaceAutomationContainer Container { get; set; }
        public SpaceAutomationTrigger[] Triggers { get; set; }
        public SpaceAutomationFailureCondition[] FailureConditions { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock($"job({Name.DoubleQuote()})"))
            {
                if (VolumeSize != null)
                    writer.WriteLine($"volumeSize = {VolumeSize}");
                
                if (CloneRepository != null)
                    writer.WriteLine($"cloneRepository = {CloneRepository.ToString().ToLowerInvariant()}");

                if (CloneDepth != null)
                {
                    using (writer.WriteBlock("git"))
                    {
                        writer.WriteLine($"depth = {(CloneDepth == -1 ? "UNLIMITED_DEPTH" : CloneDepth.ToString())}");
                    }
                }
                
                if (Triggers.Any())
                {
                    using (writer.WriteBlock("startOn"))
                    {
                        Triggers.ForEach(x => x.Write(writer));
                    }
                }

                if (FailureConditions.Any())
                {
                    using (writer.WriteBlock("failOn"))
                    {
                        FailureConditions.ForEach(x => x.Write(writer));
                    }
                }
                
                Container.Write(writer);
            }
        }
    }
}
