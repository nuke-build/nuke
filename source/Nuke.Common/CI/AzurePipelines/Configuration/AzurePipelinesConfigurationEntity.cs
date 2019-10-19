using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    public abstract class AzurePipelinesConfigurationEntity
    {
        public abstract void Write(CustomFileWriter writer);
    }
}