using System;
using System.IO;
using System.Linq;
using Nuke.Common.CI.AzurePipelines;

namespace Nuke.Common.Tests.CI
{
    public class TestAzurePipelinesAttribute : AzurePipelinesAttribute, ITestConfigurationGenerator
    {
        public TestAzurePipelinesAttribute(AzurePipelinesImage image, params AzurePipelinesImage[] images)
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