using System;
using System.ComponentModel;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.CI.AzurePipelines
{
    public enum AzurePipelinesArtifactType
    {
        Container,
        FilePath ,
        VersionControl,
         GitRef ,
         TfvcLabel 
    }
}
