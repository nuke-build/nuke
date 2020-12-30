using System;
using System.IO;
using System.Linq;
using Nuke.Common.CI.AzurePipelines;

namespace Nuke.Common.Tests.CI
{
    public class TestAzurePipelinesConfigurationGenerator : AzurePipelinesConfigurationGenerator, ITestConfigurationGenerator
    {
        public TestAzurePipelinesConfigurationGenerator(AzurePipelinesImage image, params AzurePipelinesImage[] images)
            : base(image, images)
        {
        }

        public StreamWriter Stream { get; set; }

        protected override StreamWriter CreateStream()
        {
            return Stream;
        }
    }
}
